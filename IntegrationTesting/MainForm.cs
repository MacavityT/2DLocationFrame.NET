using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IntegrationTesting.Aid;
using IntegrationTesting.Robot;
using Grpc.Core;
using App2D;
using IntegrationTesting.Tool;
using System.IO;
using AqVision;
using System.Diagnostics;
using AqVision.Controls;
using IntegrationTesting.Acquisition;

namespace IntegrationTesting
{
    public partial class MainForm : Form
    {
        AqVision.Acquisition.AqAcquisitionImage m_Acquisition = new AqVision.Acquisition.AqAcquisitionImage();
        CalibrationSetForm m_calibrateShow = new CalibrationSetForm();
        AcqusitionImageSet m_acqusitionImageSet = new AcqusitionImageSet();
        TemplateSetForm m_templateSet = new TemplateSetForm();

        public TemplateSetForm TemplateSet
        {
            get { return m_templateSet; }
            set { m_templateSet = value; }
        }
//        AIDIManagementForm m_aidiMangement = new AIDIManagementForm();
        RobotManagementForm m_robotSeverForm = new RobotManagementForm();

        static VisionImpl m_visionImpl = new VisionImpl();
        Server m_server = null;
        string m_localIP = null;

        UInt32 m_locationCount = 0;
        UInt32 m_detectonCount = 0;
        DateTime m_begTime = DateTime.Now;

        Thread showPicLocation = null;
        bool m_endThread = false;
        UInt16 _TriggerCount = 0;

        List<LocationResultSet> triggerLocationResult = new List<LocationResultSet>();
        string softwareTitle = "阿丘科技定位软件(V1.0)"; //软件标题名字

        

        public MainForm()
        {
            InitializeComponent();
            this.Text = softwareTitle;
            label_Title.Text = softwareTitle;

            listViewRecord.Columns.Add("Message", 1000, HorizontalAlignment.Center);

            m_visionImpl.triggerCamerHandler = new TriggerCamerHandler(TriggerCamera);
            m_visionImpl.getLocalizeResultHandler = new GetLocalizeResultHandler(GetLocalizeResult);
            m_visionImpl.getWorkObjInfoHandler = new GetWorkObjInfoHandler(GetWorkObjInfo);

            IniFile.IniFillFullPath = Application.StartupPath + "\\Config.ini";
            ReadConfigFromIniFile();
        }

        ~MainForm()
        {
        }

        public void ReadConfigFromIniFile()
        {
            UInt32 CameraCount = Convert.ToUInt32(IniFile.ReadValue("Acquisition", "CameraCount", "0"));
            m_Acquisition.CameraParamSet.CameraName.Clear();
            for (int i = 0; i < CameraCount; i++)
            {
                string strKey = string.Format("CameraName{0}", i);
                string strCameraName;
                string strValue = null;
                strCameraName = IniFile.ReadValue("Acquisition", strKey, "Location");
                m_Acquisition.CameraParamSet.CameraName.Add(strCameraName);

                strKey = string.Format("ExposureTime{0}", i);
                m_Acquisition.CameraParamSet.CameraNameExposure[strCameraName] = Convert.ToUInt32(IniFile.ReadValue("Acquisition", strKey, "5000"));

                strKey = string.Format("AcquisitionStyle{0}", i);
                strValue = IniFile.ReadValue("Acquisition", strKey, "FromCamera");
                if(strValue == "FromCamera")
                {
                    m_Acquisition.CameraParamSet.AcquisitionStyle[strCameraName] = AcquisitionMode.FromCamera;
                }
                else if(strValue == "FromFile")
                {
                    m_Acquisition.CameraParamSet.AcquisitionStyle[strCameraName] = AcquisitionMode.FromFile;
                }
                else if(strValue == "FromFolder")
                {
                    m_Acquisition.CameraParamSet.AcquisitionStyle[strCameraName] = AcquisitionMode.FromFolder;
                }

                strKey = string.Format("CameraBrand{0}", i);
                strValue = IniFile.ReadValue("Acquisition", strKey, "DaHeng");
                if (strValue == "DaHeng")
                {
                    m_Acquisition.CameraParamSet.CameraNameBrand[strCameraName] = AqCameraBrand.DaHeng;
                }
                else
                {
                    m_Acquisition.CameraParamSet.CameraNameBrand[strCameraName] = AqCameraBrand.Basler;
                }

                strKey = string.Format("InputImageFile{0}", i);
                strValue = IniFile.ReadValue("Acquisition", strKey, "");
                m_Acquisition.CameraParamSet.CameraNameInputFile[strCameraName] = strValue;

                strKey = string.Format("InputImageFolder{0}", i);
                strValue = IniFile.ReadValue("Acquisition", strKey, "");
                m_Acquisition.CameraParamSet.CameraNameInputFolder[strCameraName] = strValue;
                m_Acquisition.CameraParamSet.UpdateFilesUnderFolder();
            }
            m_localIP = IniFile.ReadValue("Acquisition", "LocalIP", "192.168.1.111");
            IniFile.WriteValue("Acquisition", "LocalIP", m_localIP);
        }

        public void WriteConfigToIniFile()
        {
            IniFile.WriteValue("Acquisition", "CameraCount", m_Acquisition.CameraParamSet.CameraName.Count);
            for (int i = 0; i < m_Acquisition.CameraParamSet.CameraName.Count; i++ )
            {
                string strKey = string.Format("CameraName{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.CameraName[i]);

                strKey = string.Format("ExposureTime{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.CameraNameExposure[m_Acquisition.CameraParamSet.CameraName[i]].ToString());

                strKey = string.Format("CameraBrand{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.CameraNameBrand[m_Acquisition.CameraParamSet.CameraName[i]].ToString());

                strKey = string.Format("InputImageFile{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.CameraNameInputFile[m_Acquisition.CameraParamSet.CameraName[i]].ToString());

                strKey = string.Format("InputImageFolder{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.CameraNameInputFolder[m_Acquisition.CameraParamSet.CameraName[i]].ToString());

                strKey = string.Format("AcquisitionStyle{0}", i);
                IniFile.WriteValue("Acquisition", strKey, m_Acquisition.CameraParamSet.AcquisitionStyle[m_Acquisition.CameraParamSet.CameraName[i]].ToString());
            }
            IniFile.WriteValue("Acquisition", "LocalIP", m_localIP);
        }

        private int TriggerCamera(double robotX, double robotY, double robotRz)
        {
            Tool.DebugInfo.OutputProcessMessage("Integraton TriggerCamera beg< ");
            int locationResult = -1;
            try
            {
                if (m_templateSet.IsDisposed || m_templateSet == null)
                {
                    m_templateSet = new TemplateSetForm();
                }
                if (m_calibrateShow.IsDisposed || m_calibrateShow == null)
                {
                    m_calibrateShow = new CalibrationSetForm();
                }
                checkBoxCameraAcquisition.Invoke(new MethodInvoker(delegate
                {
                    aqDisplayLocation.InteractiveGraphics.Clear();
                    aqDisplayLocation.Update();
                    if (checkBoxCameraAcquisition.Checked)
                    {
                        checkBoxCameraAcquisition.Checked = false;
                        checkBoxCameraAcquisition_CheckedChanged(null, null);
                        m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                    }
                    else
                    {
                        Tool.DebugInfo.OutputProcessMessage("Integraton Integraton TriggerCamera acquisition beg< ");

                        Bitmap location = null;
                        List<System.Drawing.Bitmap> acquisitionBmp = new List<Bitmap>();
                        List<string> acquisitionCameraName = new List<string>();
                        acquisitionCameraName.Add("Aqrose_L");
                        m_Acquisition.Acquisition(ref acquisitionBmp, acquisitionCameraName);
                        location = acquisitionBmp[0];

                        aqDisplayLocation.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayLocation.Image = location;
                            aqDisplayLocation.FitToScreen();
                            aqDisplayLocation.Update();
                        }));
                        if (m_templateSet.ImageInput != null)//936.9
                        {
                            m_templateSet.ImageInput.Dispose();
                        }
                        m_templateSet.ImageInput = location.Clone() as Bitmap;
                        Tool.DebugInfo.OutputProcessMessage("Integraton TriggerCamera acquisition end> ");
                    }

                    triggerLocationResult.Clear();
                    locationResult = m_templateSet.RunMatcher(Application.StartupPath + @"\location\ModelNormal.shm");

                    if(locationResult == 0)
                    {
                        for(int i=0; i<m_templateSet.LocationResultPosTheta.Length; i++ )
                        {
                            LocationResultSet result = new LocationResultSet();
                            result.CenterX = m_templateSet.LocationResultPosX[i];
                            result.CenterY = m_templateSet.LocationResultPosY[i];
                            result.Posture = ProductPosture.Normal;
                            result.Angle = m_templateSet.LocationResultPosTheta[i];
                            result.Transmited = false;
                            result.Score = m_templateSet.Score[i];
                            triggerLocationResult.Add(result);
                            m_templateSet.ShowGetResultsData(AqColorConstants.Green, aqDisplayLocation);
                        }
                    }
                    if(triggerLocationResult.Count == 0) //未抓到水平放置，才去抓取竖直放置
                    {
                        locationResult = m_templateSet.RunMatcher(Application.StartupPath + @"\location\ModelVertical.shm");
                        if (locationResult == 0)
                        {
                            for (int i = 0; i < m_templateSet.LocationResultPosTheta.Length; i++)
                            {
                                LocationResultSet result = new LocationResultSet();
                                result.CenterX = m_templateSet.LocationResultPosX[i];
                                result.CenterY = m_templateSet.LocationResultPosY[i];
                                result.Posture = ProductPosture.Vertical;
                                result.Angle = m_templateSet.LocationResultPosTheta[i]*180/Math.PI;
                                result.Transmited = false;
                                result.Score = m_templateSet.Score[i];
                                triggerLocationResult.Add(result);
                                m_templateSet.ShowGetResultsData(AqColorConstants.Green, aqDisplayLocation);
                            }
                        }
                    }
                    
                    Tool.DebugInfo.OutputProcessMessage("Integraton TriggerCamera RunMatcher end> ");
                    m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);
                    //AddMessageToListView("Suc");
                    string showScoreAll = null;
                    for (int i = 0; i < triggerLocationResult.Count; i++ )
                    {
                        showScoreAll += (triggerLocationResult[i].Score * 100).ToString("f3") + "\n";
                    }
                    labelLocationScore.Text = showScoreAll;
                    labelLocationScore.ForeColor = Color.Lime;

                    label_LocationX.Text = triggerLocationResult[0].CenterX.ToString("f3");
                    label_LocationY.Text = triggerLocationResult[0].CenterY.ToString("f3");
                    label_LocationR.Text = (triggerLocationResult[0].Angle * 180 / Math.PI).ToString("f3");

                    //if ((_TriggerCount % 2) == 0)
                    {
                        string PicName = SaveImageToFile(aqDisplayLocation, m_templateSet.ImageInput, @"D:\Location\");
                        StreamWriter sw = File.AppendText(@"D:\Debug.csv");
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", PicName, label_LocationX.Text, label_LocationY.Text, label_LocationR.Text
                            ,robotX, robotY,robotRz));
                        sw.Flush();
                        sw.Close();
                    }

                    _TriggerCount++;
                }));
                //AddMessageToListView("TriggerCameraDone");
                
                GC.Collect();
                Tool.DebugInfo.OutputProcessMessage("Integraton TriggerCamera collect ------------------");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("TriggerCamera " + ex.Message);
                locationResult = -2;
            }
            m_locationCount++;
            Tool.DebugInfo.OutputProcessMessage(string.Format("Integraton TriggerCamera locationResult = {0}", locationResult));
            return locationResult;
        }

        private bool GetLocalizeResult(ref double posX, ref double posY, ref double theta, ref int posture)
        {
            if (triggerLocationResult.Count > 0)
            {
                Tool.DebugInfo.OutputProcessMessage("Integraton GetLocalizeResult beg< ");
                m_calibrateShow.SetCurrentImagePosition(triggerLocationResult[0].CenterX, triggerLocationResult[0].CenterY, triggerLocationResult[0].Angle);
                //AddMessageToListView(string.Format("location result: {0} {1} {2}", m_templateSet.LocationResultPosX, m_templateSet.LocationResultPosY, m_templateSet.LocationResultPosTheta));
                string calibrationPath  = null;
                if(triggerLocationResult[0].Posture == ProductPosture.Normal)
                {
                    calibrationPath = Application.StartupPath + @"\location\ResultNormal.txt";
                    posture = 1;
                }
                else if(triggerLocationResult[0].Posture == ProductPosture.Vertical)
                {
                    calibrationPath = Application.StartupPath + @"\location\ResultVertical.txt";
                    posture = 2;
                }
                m_calibrateShow.GetCurrentCatchPosition(ref posX, ref posY, ref theta, calibrationPath);
                triggerLocationResult.RemoveAt(0);
                Tool.DebugInfo.OutputProcessMessage("Integraton GetLocalizeResult end> ");
                //AddMessageToListView(string.Format("GetCurrentCatchPosition: {0} {1} {2}", posX, posY, theta));
                Tool.DebugInfo.OutputProcessMessage(string.Format("Integraton TriggerCamera GetLocalizeResult = {0}, {1}, {2}, {3}.", posX, posY, theta, posture));
                labelRobotX.Text = posX.ToString("f3");
                labelRobotY.Text = posY.ToString("f3");
                labelRobotRz.Text = theta.ToString("f3");
            }
            return true;
        }

        private bool GetWorkObjInfo(ref int detectCount)
        {
            /*
            try
            {
                Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo beg< ");
                aqDisplayDetection.InteractiveGraphics.Clear();
                aqDisplayDetection.Update();
                checkBoxCameraDetection.Invoke(new MethodInvoker(delegate
                {
                    if (m_aidiMangement.SourceBitmap != null)
                    {
                        for (int i = 0; i < m_aidiMangement.SourceBitmap.Count; i++)
                        {
                            m_aidiMangement.SourceBitmap[i].Dispose();
                        }
                        m_aidiMangement.SourceBitmap.Clear();
                    }
                    else
                    {
                        m_aidiMangement.SourceBitmap = new List<Bitmap>();
                    }

                    if (checkBoxCameraDetection.Checked)
                    {
                        checkBoxCameraDetection.Checked = false;
                        checkBoxCameraDetection_CheckedChanged(null, null);
                        m_aidiMangement.SourceBitmap.Add(aqDisplayDetection.Image.Clone() as Bitmap);
                    }
                    else
                    {
                        Bitmap location = null;
                        Bitmap detection = null;
                        Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo acquisition beg< ");
                        m_Acquisition.Acquisition(ref location, ref detection);
                        aqDisplayDetection.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayDetection.Image = detection;
                        }));

                        m_aidiMangement.SourceBitmap.Add(aqDisplayDetection.Image.Clone() as Bitmap);
                        Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo acquisition end> ");
                    }
                    aqDisplayDetection.FitToScreen();
                    aqDisplayDetection.Update();
                    m_aidiMangement.DetectPic();
                    Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo DetectPic end> ");
                    aqDisplayDetection.Image = m_aidiMangement.SourceBitmap[0];
                    m_aidiMangement.DrawContours(m_aidiMangement.ObjList[0], AqVision.AqColorConstants.Red, 5, aqDisplayDetection);
                    aqDisplayDetection.Update();
                    if (m_aidiMangement.ObjList[0].Count == 0)
                    {
                        labelDetectResult.Text = "良品";
                        labelDetectResult.ForeColor = Color.Lime;
                        labelErrorCount.Text = "无";
                        labelErrorCount.ForeColor = Color.Lime;
                    }
                    else
                    {
                        labelDetectResult.Text = "差品";
                        labelDetectResult.ForeColor = Color.Red;
                        labelErrorCount.Text = string.Format("{0}", m_aidiMangement.ObjList[0].Count);
                        labelErrorCount.ForeColor = Color.Red;
                    }
                    Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo ShowResult end> ");
                    //SaveImageToFile(aqDisplayDectection, m_aidiMangement.SourceBitmap[0], @"D:\Detect\");
                    GC.Collect();
                    Tool.DebugInfo.OutputProcessMessage("Integraton GetWorkObjInfo Collect ------------------");
                    Tool.DebugInfo.OutputProcessMessage(string.Format("Integraton GetWorkObjInfo = {0}, {1}.Count={2}", labelDetectResult.Text, labelErrorCount.Text, m_detectonCount));
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetWorkObjInfo " + ex.Message);
            }
            m_detectonCount++;
            */
            return true;// m_aidiMangement.DetectResult;
        }
            
        public string SaveImageToFile(AqDisplay aqDisplay, Bitmap originBitmap, string strSavePath)
        {
            string sourcePath = strSavePath + @"Source\";
            string resultPath = strSavePath + @"Result\";
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
            }
            if (!Directory.Exists(resultPath))
            {
                Directory.CreateDirectory(resultPath);
            }
            
            int count = Directory.GetFiles(strSavePath).Length;//1063.216
            Image originImage = Image.FromHbitmap(originBitmap.GetHbitmap());//1221.3

            Bitmap bitmap = new Bitmap(originImage.Width, originImage.Height);//1299.576

            Graphics gTemplate = Graphics.FromImage(bitmap);
            gTemplate.DrawImage(originImage, 0, 0, new Rectangle(0, 0, originImage.Width, originImage.Height), System.Drawing.GraphicsUnit.Pixel);

            string timeNowToString = string.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month,
                               DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            string picSourceName = string.Format("{0}{1}_{2}_.bmp", sourcePath, count.ToString(), timeNowToString);
            string picResultFullName = string.Format("{0}{1}_{2}_.jpg", resultPath, count.ToString(), timeNowToString);

            bitmap.Save(picSourceName, System.Drawing.Imaging.ImageFormat.Bmp);
            aqDisplay.CreateContentBitmap().Save(picResultFullName); // 1304.456

            gTemplate.Dispose();
            bitmap.Dispose();//1225.496
            originImage.Dispose();//1146.756
            return picSourceName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_endThread = true;
            m_Acquisition.DisConnect();
            WriteConfigToIniFile();
            if (!ReferenceEquals(showPicLocation, null))
            {
                if (showPicLocation.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    showPicLocation.Resume();
                }
                showPicLocation.Abort();
                while (showPicLocation.ThreadState != System.Threading.ThreadState.Aborted)
                {
                    Thread.Sleep(10);
                }
            }
        }

        public void AcquisitionBmpOnce(ref bool firstFrameLocation,ref bool firstFrameDetection)
        {
            Bitmap location = null;
            
            List<System.Drawing.Bitmap> acquisitionBmp = new List<Bitmap>();
            List<string> acquisitionCameraName = new List<string>();
            acquisitionCameraName.Add("Aqrose_L");
            m_Acquisition.Acquisition(ref acquisitionBmp, acquisitionCameraName);
            location = acquisitionBmp[0];

            aqDisplayLocation.Invoke(new MethodInvoker(delegate
            {
                if (checkBoxCameraAcquisition.Checked)
                {
                    aqDisplayLocation.Image = location;
                    aqDisplayLocation.Update();
                }
            }));

            if (firstFrameLocation)
            {
                firstFrameLocation = false;
                aqDisplayLocation.FitToScreen();
            }
             
        }
        public void RegisterVisionAPI()
        {
            bool firstFrameLocation = true;
            bool firstFrameDetection = true;
            while (!m_endThread)
            {
                try
                {
                    AcquisitionBmpOnce(ref firstFrameLocation,ref firstFrameDetection);
                }
                catch (SEHException e)
                {
                    AqVision.Interaction.UI2LibInterface.OutputDebugString("SEH Exception: " + e.ToString());
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    AqVision.Interaction.UI2LibInterface.OutputDebugString("Thread Exception");
                    //MessageBox.Show("Thread Exception");
                }
                Thread.Sleep(10);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            m_server = new Server
            {
                Services = { Robot2dApp.BindService(m_visionImpl) },
                Ports = { new ServerPort(m_localIP, 50051, ServerCredentials.Insecure) }
            };  
            m_server.Start();
            buttonRun.Enabled = false;
            buttonStop.Enabled = true;
            _TriggerCount = 0;
            if (File.Exists(@"D:\Debug.csv"))
            {
                File.Delete(@"D:\Debug.csv");
            }

            DeleteDirectory(@"D:\Location\Result");
            DeleteDirectory(@"D:\Location\Source");
        }

        void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                string[] allFiles = Directory.GetFiles(path);
                while (allFiles.Length != 0)
                {
                    File.Delete(allFiles[0]);
                    allFiles = Directory.GetFiles(path);
                }
                Directory.Delete(path);
            }
        }


        public void AddMessageToListView(string strMessage)
        {
            ListViewItem item = new ListViewItem(strMessage, 0);
            listViewRecord.Items.Add(item);
        }

        public void StartAcqusitionBmp()
        {
            try
            {
                aqDisplayLocation.InteractiveGraphics.Clear();
                aqDisplayLocation.Update();

                if (ReferenceEquals(showPicLocation, null))
                {
                    m_Acquisition.Connect();
                    showPicLocation = new Thread(new ThreadStart(RegisterVisionAPI));
                    showPicLocation.Start();
                }
                if (showPicLocation.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    showPicLocation.Resume();
                }
            }
            catch (Exception ex)
            {
                m_Acquisition.DisConnect();
                MessageBox.Show(ex.Message);
            }
        }

        public void StopAcquistionBmp()
        {
            try
            {
                if (!ReferenceEquals(showPicLocation, null))
                {
                    //if (showPic.ThreadState == ThreadState.Running)
                    {
                        showPicLocation.Suspend();
                    }
                }
            }
            catch (Exception ex)
            {
                m_Acquisition.DisConnect();
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxCameraAcquisition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCameraAcquisition.Checked)
            {
                StartAcqusitionBmp();
                checkBoxCameraAcquisition.Text = "停止定位实时采集";
                checkBoxCameraAcquisition.Image = Properties.Resources.CameraStop;
            }
            else
            {
                StopAcquistionBmp();
                checkBoxCameraAcquisition.Text = "开启定位实时采集";
                checkBoxCameraAcquisition.Image = Properties.Resources.CameraRun;
            }
        }

        private void ToolStripMenuItemSetAcqusition_Click(object sender, EventArgs e)
        {
            m_acqusitionImageSet.CameraParamSet = m_Acquisition.CameraParamSet;

            m_acqusitionImageSet.ShowDialog();

            m_Acquisition.CameraParamSet = m_acqusitionImageSet.CameraParamSet;
        }

        private void ToolStripMenuItemSetCalibration_Click(object sender, EventArgs e)
        {
            if (m_calibrateShow == null || m_calibrateShow.IsDisposed)
            {
                m_calibrateShow = new CalibrationSetForm();
            }
            m_calibrateShow.GetMainForm = this;
            m_calibrateShow.Show();

            m_calibrateShow.Focus();
        }

        private void ToolStripMenuItemSetLocation_Click(object sender, EventArgs e)
        {
            if(m_templateSet == null || m_templateSet.IsDisposed)
            {
                m_templateSet = new TemplateSetForm();
                if (checkBoxCameraAcquisition.Checked)
                {
                    checkBoxCameraAcquisition.Checked = false;
                    checkBoxCameraAcquisition_CheckedChanged(null, null);
                    m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                }
                else
                {
                    Bitmap location = null;

                    List<System.Drawing.Bitmap> acquisitionBmp = new List<Bitmap>();
                    List<string> acquisitionCameraName = new List<string>();
                    acquisitionCameraName.Add("Aqrose_L");
                    m_Acquisition.Acquisition(ref acquisitionBmp, acquisitionCameraName);
                    location = acquisitionBmp[0];

                    aqDisplayLocation.Invoke(new MethodInvoker(delegate
                    {
                        aqDisplayLocation.Image = location;
                        aqDisplayLocation.FitToScreen();
                        aqDisplayLocation.Update();
                    }));
                    m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                }
            }
            m_templateSet.Show();
            m_templateSet.Focus();
        }

        private void ToolStripMenuItemSetDectection_Click(object sender, EventArgs e)
        {
            //m_aidiMangement.ShowDialog();
        }

        private void ToolStripMenuItemSetRobotConnect_Click(object sender, EventArgs e)
        {
            m_robotSeverForm.ShowDialog();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_server.ShutdownAsync();
            m_server.KillAsync();
            buttonRun.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void checkBoxCameraDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCameraDetection.Checked)
            {
                StartAcqusitionBmp();
                checkBoxCameraDetection.Text = "停止检测实时采集";
                checkBoxCameraDetection.Image = Properties.Resources.CameraStop;
            }
            else
            {
                StopAcquistionBmp();
                checkBoxCameraDetection.Text = "开启检测实时采集";
                checkBoxCameraDetection.Image = Properties.Resources.CameraRun;
            }
        }

        private void buttonTriggerLocationRPC_Click(object sender, EventArgs e)
        {
            TriggerCamera(0, 0, 0);
        }

        private void buttonTriggerDetectionRPC_Click(object sender, EventArgs e)
        {
            int abc = 0;
            GetWorkObjInfo(ref abc);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            label_Title.Location = new Point(Convert.ToInt32(panelTitle.ClientSize.Width / 2 - label_Title.Size.Width / 2),
                                              Convert.ToInt32(label_Title.Location.Y/*panelTitle.Height / 2*/));
        }

        private void 开启检测实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpendetectAcquistionToolStripMenuItem.Checked = true;
            ClosedetectAcquistionToolStripMenuItem.Checked = false;
            checkBoxCameraAcquisition.Visible = true;
            buttonTriggerLocationRPC.Visible = true;
            listViewRecord.Visible = true;
        }

        private void 关闭检测实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpendetectAcquistionToolStripMenuItem.Checked = false;
            ClosedetectAcquistionToolStripMenuItem.Checked = true;
            checkBoxCameraAcquisition.Visible = false;
            buttonTriggerLocationRPC.Visible = false;
            if (!checkBoxCameraDetection.Visible)
            {
                listViewRecord.Visible = false;
            }
        }

        private void 开启定位实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLocationAcquistionToolStripMenuItem.Checked = true;
            CloseLocationAcquistionToolStripMenuItem.Checked = false;
            checkBoxCameraDetection.Visible = true;
            buttonTriggerDetectionRPC.Visible = true;
            listViewRecord.Visible = true;
        }

        private void 关闭定位实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLocationAcquistionToolStripMenuItem.Checked = false;
            CloseLocationAcquistionToolStripMenuItem.Checked = true;
            checkBoxCameraDetection.Visible = false;
            buttonTriggerDetectionRPC.Visible = false;
            if (!checkBoxCameraAcquisition.Visible)
            {
                listViewRecord.Visible = false;
            }
        }

        private void 保存检测图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             SaveFileDialog fileDialog = new SaveFileDialog();
//             fileDialog.Filter = "*.jpg(*.jpg)|*.jpg";
//             if(fileDialog.ShowDialog() == DialogResult.OK)
//             {      
//                  aqDisplayDetection.Image.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
//                  aqDisplayDetection.CreateContentBitmap().Save(fileDialog.FileName + "result.jpg");
//             }            
        }

        private void 保存定位图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "*.jpg(*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                aqDisplayLocation.Image.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                aqDisplayLocation.CreateContentBitmap().Save(fileDialog.FileName + "result.jpg");
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            labellocationCount.Text = string.Format("{0}", m_locationCount);
            labeldetectionCount.Text = string.Format("{0}", m_detectonCount);
            TimeSpan tsRet = DateTime.Now - m_begTime;
            toolStripStatusLabelRunningTime.Text = tsRet.ToString("hh\\:mm\\:ss");
        }
    }
}