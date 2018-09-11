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
using IntegrationTesting.Aidi;
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
        Thread showPicLocation = null;
        bool m_endThread = false;

        CalibrationSetForm m_calibrateShow = new CalibrationSetForm();
        AcqusitionImageSet m_acqusitionImageSet = new AcqusitionImageSet();
        TemplateSetForm m_templateSet = new TemplateSetForm();
        AIDIManagementForm m_aidiMangement = new AIDIManagementForm();
        RobotManagementForm m_robotSeverForm = new RobotManagementForm();

        static VisionImpl m_visionImpl = new VisionImpl();
        Server m_server = null;
        string m_localIP = null;

        UInt32 m_locationCount = 0;
        UInt32 m_detectonCount = 0;
        DateTime m_begTime = DateTime.Now;

        List<LocationResultSet> triggerLocationResult = new List<LocationResultSet>();
        public MainForm()
        {
            InitializeComponent();
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
            m_Acquisition.CameraExposure[0] = Convert.ToUInt32(IniFile.ReadValue("Acquisition", "ExposureTimeLocation", "5000"));
            m_Acquisition.CameraExposure[1] = Convert.ToUInt32(IniFile.ReadValue("Acquisition", "ExposureTimeDetection", "5000"));
            IniFile.ReadValue("Acquisition", "CameraNameLocation", m_Acquisition.CameraName[0]);
            IniFile.ReadValue("Acquisition", "CameraNameDetection", m_Acquisition.CameraName[1]);
            string strValue = IniFile.ReadValue("Acquisition", "CameraBrandLocation", "DaHeng");
            if (strValue == "DaHeng")
            {
                m_Acquisition.CameraBrand[0] = AqCameraBrand.DaHeng;
            }
            else
            {
                m_Acquisition.CameraBrand[0] = AqCameraBrand.Basler;
            }

            IniFile.ReadValue("Acquisition", "CameraBrandDetection", strValue);
            if (strValue == "DaHeng")
            {
                m_Acquisition.CameraBrand[1] = AqCameraBrand.DaHeng;
            }
            else
            {
                m_Acquisition.CameraBrand[1] = AqCameraBrand.Basler;
            }
            m_Acquisition.InputImageFileLocation = IniFile.ReadValue("Acquisition", "InputImageFileLocation", "None");
            m_Acquisition.InputImageFileDetection = IniFile.ReadValue("Acquisition", "InputImageFileDetection", "None");
            m_Acquisition.InputImageFolderLocation = IniFile.ReadValue("Acquisition", "InputImageFolderLocation", "None");
            m_Acquisition.InputImageFolderDetection = IniFile.ReadValue("Acquisition", "InputImageFolderDetection", "None");
            strValue = IniFile.ReadValue("Acquisition", "AcquisitionStyle", "FromCamera");
            if(strValue == "FromCamera")
            {
               m_Acquisition.AcquisitionStyle = AcquisitionMode.FromCamera;
            }
            else if(strValue == "FromFile")
            {
                m_Acquisition.AcquisitionStyle = AcquisitionMode.FromFile;
            }
            else if(strValue == "FromFolder")
            {
                m_Acquisition.AcquisitionStyle = AcquisitionMode.FromFolder;
            }

            m_localIP = IniFile.ReadValue("Acquisition", "LocalIP", "127.0.0.1");
        }

        public void WriteConfigToIniFile()
        {
            IniFile.WriteValue("Acquisition", "ExposureTimeLocation", m_Acquisition.CameraExposure[0].ToString());
            IniFile.WriteValue("Acquisition", "ExposureTimeDetection", m_Acquisition.CameraExposure[1].ToString());
            IniFile.WriteValue("Acquisition", "CameraNameLocation", m_Acquisition.CameraName[0]);
            IniFile.WriteValue("Acquisition", "CameraNameDetection", m_Acquisition.CameraName[1]);
            IniFile.WriteValue("Acquisition", "CameraBrandLocation", m_Acquisition.CameraBrand[0].ToString());
            IniFile.WriteValue("Acquisition", "CameraBrandDetection", m_Acquisition.CameraBrand[1].ToString());

            IniFile.WriteValue("Acquisition", "InputImageFileLocation", m_Acquisition.InputImageFileLocation);
            IniFile.WriteValue("Acquisition", "InputImageFileDetection", m_Acquisition.InputImageFileDetection);
            IniFile.WriteValue("Acquisition", "InputImageFolderLocation", m_Acquisition.InputImageFolderLocation);
            IniFile.WriteValue("Acquisition", "InputImageFolderDetection", m_Acquisition.InputImageFolderDetection);
            IniFile.WriteValue("Acquisition", "AcquisitionStyle", m_Acquisition.AcquisitionStyle.ToString());
            IniFile.WriteValue("Acquisition", "LocalIP", m_localIP);
        }

        private int TriggerCamera(double robotX, double robotY, double robotRz)
        {
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
                        Bitmap location = null;
                        Bitmap detection = null;
                        m_Acquisition.Acquisition(ref location, ref detection); //853
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
                    if(triggerLocationResult.Count < 2)
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
                                result.Angle = m_templateSet.LocationResultPosTheta[i];
                                result.Transmited = false;
                                result.Score = m_templateSet.Score[i];
                                triggerLocationResult.Add(result);
                                m_templateSet.ShowGetResultsData(AqColorConstants.Green, aqDisplayLocation);
                            }
                        }
                    }

                    m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);
                    //AddMessageToListView("Suc");
                    string showScoreAll = null;
                    for (int i = 0; i < triggerLocationResult.Count; i++ )
                    {
                        showScoreAll += (triggerLocationResult[i].Score * 100).ToString("f3") + "\n";
                    }
                    labelLocationScore.Text = showScoreAll;
                    labelLocationScore.ForeColor = Color.Lime;

                    if (triggerLocationResult.Count == 1)
                    {
                        locationResult = 1; //定位到1个产品
                    }
                    else if(triggerLocationResult.Count == 2)
                    {
                        locationResult = 2; //定位到1个产品
                    }
                    else if(triggerLocationResult.Count > 2)
                    {
                        locationResult = triggerLocationResult.Count;
                    }
                }));
                //SaveImageToFile(aqDisplayLocation, m_templateSet.ImageInput, @"D:\Location\");//1146.88
                AddMessageToListView("TriggerCameraDone");
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TriggerCamera " + ex.Message);
                return -2;
            }
            m_locationCount++;
            return locationResult;
        }

        private bool GetLocalizeResult(ref double posX, ref double posY, ref double theta, ref int posture)
        {
            if (triggerLocationResult.Count > 0)
            {
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
                //AddMessageToListView(string.Format("GetCurrentCatchPosition: {0} {1} {2}", posX, posY, theta));
            }
            return true;
        }

        private bool GetWorkObjInfo(ref int detectCount)
        {
            try
            {
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
                        m_Acquisition.Acquisition(ref location, ref detection);
                        aqDisplayDetection.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayDetection.Image = detection;
                        }));

                        m_aidiMangement.SourceBitmap.Add(aqDisplayDetection.Image.Clone() as Bitmap);
                    }
                    aqDisplayDetection.FitToScreen();
                    aqDisplayDetection.Update();
                    m_aidiMangement.DetectPic();
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
                    //SaveImageToFile(aqDisplayDectection, m_aidiMangement.SourceBitmap[0], @"D:\Detect\");
                    GC.Collect();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetWorkObjInfo " + ex.Message);
            }

            m_detectonCount++;
            return true;// m_aidiMangement.DetectResult;
        }
            
        public bool SaveImageToFile(AqDisplay aqDisplay, Bitmap originBitmap, string strSavePath)
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

            string picSourceName = string.Format("{0}{1}_{2}_.jpg", sourcePath, count.ToString(), timeNowToString);
            string picResultFullName = string.Format("{0}{1}_{2}_.jpg", resultPath, count.ToString(), timeNowToString);

            bitmap.Save(picSourceName, System.Drawing.Imaging.ImageFormat.Jpeg);
            aqDisplay.CreateContentBitmap().Save(picResultFullName); // 1304.456

            gTemplate.Dispose();
            bitmap.Dispose();//1225.496
            originImage.Dispose();//1146.756
            return true;
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

        public void AcquisitionBmpOnce(bool firstFrameLocation, bool firstFrameDetection)
        {
            Bitmap location = null;
            Bitmap detection = null;
            m_Acquisition.Acquisition(ref location, ref detection);
            
            aqDisplayLocation.Invoke(new MethodInvoker(delegate
            {
                if (checkBoxCameraAcquisition.Checked)
                {
                    aqDisplayLocation.Image = location;
                    aqDisplayLocation.Update();

                    if (firstFrameLocation)
                    {
                        firstFrameLocation = false;
                        aqDisplayLocation.FitToScreen();
                    }
                }
                if (checkBoxCameraDetection.Checked)
                {
                    aqDisplayDetection.Image = detection;
                    aqDisplayDetection.Update();

                    if (firstFrameDetection)
                    {
                        firstFrameDetection = false;
                        aqDisplayDetection.FitToScreen();
                    }
                }
            }));
             
        }
        public void RegisterVisionAPI()
        {
            bool firstFrameLocation = true;
            bool firstFrameDetection = true;
            while (!m_endThread)
            {
                try
                {
                    AcquisitionBmpOnce(firstFrameLocation, firstFrameLocation);
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
            m_acqusitionImageSet.ExposureTimeLocation = m_Acquisition.CameraExposure[0];
            m_acqusitionImageSet.CameraNameLocation = m_Acquisition.CameraName[0];
            m_acqusitionImageSet.CameraBrandLocation = (int)m_Acquisition.CameraBrand[0];
            m_acqusitionImageSet.ExposureTimeDetection = m_Acquisition.CameraExposure[1];
            m_acqusitionImageSet.CameraNameDetection = m_Acquisition.CameraName[1];
            m_acqusitionImageSet.CameraBrandDetection = (int)m_Acquisition.CameraBrand[1];

            m_acqusitionImageSet.InputImageFileLocationPath = m_Acquisition.InputImageFileLocation;
            m_acqusitionImageSet.InputImageFileDetectionPath = m_Acquisition.InputImageFileDetection;
            m_acqusitionImageSet.InputImageFolderLocationPath = m_Acquisition.InputImageFolderLocation;
            m_acqusitionImageSet.InputImageFolderDetectionPath = m_Acquisition.InputImageFolderDetection;
            m_acqusitionImageSet.Mode = m_Acquisition.AcquisitionStyle;

            m_acqusitionImageSet.ShowDialog();

            UInt32[] exposure = new UInt32[2];
            string[] name = new string[2];
            AqCameraBrand[] brand = new AqCameraBrand[2];

            exposure[0] = m_acqusitionImageSet.ExposureTimeLocation;
            name[0] = m_acqusitionImageSet.CameraNameLocation;
            if (m_acqusitionImageSet.CameraBrandLocation == 0)
            {
                brand[0] = AqCameraBrand.DaHeng;
            }
            else if (m_acqusitionImageSet.CameraBrandLocation == 1)
            {
                brand[0] = AqCameraBrand.Basler;
            }

            exposure[1] = m_acqusitionImageSet.ExposureTimeDetection;
            name[1] = m_acqusitionImageSet.CameraNameDetection;
            if (m_acqusitionImageSet.CameraBrandDetection == 0)
            {
                brand[1] = AqCameraBrand.DaHeng;
            }
            else if (m_acqusitionImageSet.CameraBrandLocation == 1)
            {
                brand[1] = AqCameraBrand.Basler;
            }

            m_Acquisition.CameraExposure = exposure;
            m_Acquisition.CameraName = name;
            m_Acquisition.CameraBrand = brand;
            m_Acquisition.InputImageFileLocation = m_acqusitionImageSet.InputImageFileLocationPath;
            m_Acquisition.InputImageFileDetection = m_acqusitionImageSet.InputImageFileDetectionPath;
            m_Acquisition.InputImageFolderLocation = m_acqusitionImageSet.InputImageFolderLocationPath;
            m_Acquisition.InputImageFolderDetection = m_acqusitionImageSet.InputImageFolderDetectionPath;
            m_Acquisition.AcquisitionStyle = m_acqusitionImageSet.Mode;
        }

        private void ToolStripMenuItemSetCalibration_Click(object sender, EventArgs e)
        {
            if (m_calibrateShow == null || m_calibrateShow.IsDisposed)
            {
                m_calibrateShow = new CalibrationSetForm();
            }
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
                    Bitmap detection = null;
                    m_Acquisition.Acquisition(ref location, ref detection);
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
            m_aidiMangement.ShowDialog();
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
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "*.jpg(*.jpg)|*.jpg";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                aqDisplayDetection.Image.Save(fileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                aqDisplayDetection.CreateContentBitmap().Save(fileDialog.FileName + "result.jpg");
            }            
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