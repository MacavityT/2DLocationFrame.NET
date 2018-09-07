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

        public MainForm()
        {
            InitializeComponent();
            listViewRecord.Columns.Add("Serial NO", 10, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Time", 10, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Message", 500, HorizontalAlignment.Center);
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
                        m_Acquisition.Acquisition(ref location, ref detection); 
                        aqDisplayLocation.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayLocation.Image = location;
                            aqDisplayLocation.FitToScreen();
                            aqDisplayLocation.Update();
                        }));
                        m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                    }
                    locationResult = m_templateSet.RunMatcher();
                    m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);
                    if (locationResult == 0)
                    {
                        m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);
                        m_templateSet.ShowGetResultsData(AqColorConstants.Green, aqDisplayLocation);
                        AddMessageToListView(string.Format("robot location suc position: {0} {1} {2}", robotX, robotY, robotRz));
                        labelLocationScore.Text = (m_templateSet.Score*100).ToString("f3");
                    }
                    else
                    {
                        AddMessageToListView(string.Format("robot location failed position: {0} {1} {2}, {3}", robotX, robotY, robotRz, locationResult));
                    }
                }));
                SaveImageToFile(aqDisplayLocation, m_templateSet.ImageInput, @"D:\Location\");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TriggerCamera " + ex.Message);
                return -2;
            }

            return locationResult;
        }

        private bool GetLocalizeResult(ref double posX, ref double posY, ref double theta)
        {
            m_calibrateShow.SetCurrentImagePosition(m_templateSet.LocationResultPosX, m_templateSet.LocationResultPosY, m_templateSet.LocationResultPosTheta);
            AddMessageToListView(string.Format("location result: {0} {1} {2}", m_templateSet.LocationResultPosX, m_templateSet.LocationResultPosY, m_templateSet.LocationResultPosTheta));
            m_calibrateShow.GetCurrentCatchPosition(ref posX, ref posY, ref theta);
            AddMessageToListView(string.Format("GetCurrentCatchPosition: {0} {1} {2}", posX, posY, theta));
            return true;
        }

        private bool GetWorkObjInfo(ref int detectCount)
        {
            try
            {
                aqDisplayDectection.InteractiveGraphics.Clear();
                aqDisplayDectection.Update();
                checkBoxCameraDetection.Invoke(new MethodInvoker(delegate
                {
                    if (m_aidiMangement.SourceBitmap != null)
                    {
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
                        m_aidiMangement.SourceBitmap.Add(aqDisplayDectection.Image.Clone() as Bitmap);
                    }
                    else
                    {
                        Bitmap location = null;
                        Bitmap detection = null;
                        m_Acquisition.Acquisition(ref location, ref detection);
                        aqDisplayDectection.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayDectection.Image = detection;
                        }));
                        m_aidiMangement.SourceBitmap.Add(aqDisplayDectection.Image.Clone() as Bitmap);
                    }
                    aqDisplayDectection.FitToScreen();
                    aqDisplayDectection.Update();
                    m_aidiMangement.DetectBmp();
                    aqDisplayDectection.Image = m_aidiMangement.SourceBitmap[0];
                    m_aidiMangement.DrawContours(m_aidiMangement.ObjList[0], AqVision.AqColorConstants.Red, 1, aqDisplayDectection);
                    aqDisplayDectection.Update();
                    SaveImageToFile(aqDisplayDectection, m_aidiMangement.SourceBitmap[0], @"D:\Detect\");
                }));
                if (m_aidiMangement.DetectResult)
                {
                    AddMessageToListView("检测无错误");
                }
                else
                {
                    AddMessageToListView("检测有错误");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetWorkObjInfo " + ex.Message);
            }
            return m_aidiMangement.DetectResult;
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
            
            int count = Directory.GetFiles(strSavePath).Length;
            Image originImage = Image.FromHbitmap(originBitmap.GetHbitmap());

            Bitmap bitmap = new Bitmap(originImage.Width, originImage.Height);

            Graphics gTemplate = Graphics.FromImage(bitmap);
            gTemplate.DrawImage(originImage, 0, 0, new Rectangle(0, 0, originImage.Width, originImage.Height), System.Drawing.GraphicsUnit.Pixel);

            string timeNowToString = string.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month,
                               DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            string picSourceName = string.Format("{0}{1}_{2}_.bmp", sourcePath, count.ToString(), timeNowToString);
            string picResultFullName = string.Format("{0}{1}_{2}_.bmp", resultPath, count.ToString(), timeNowToString);
            bitmap.Save(picSourceName, System.Drawing.Imaging.ImageFormat.Bmp);
            aqDisplay.CreateContentBitmap().Save(picResultFullName);
            gTemplate.Dispose();
            bitmap.Dispose();
            return true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_endThread = true;
            m_Acquisition.DisConnect();
            WriteConfigToIniFile();
//            m_AcquisitionDetection.DisConnect();
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
                    aqDisplayDectection.Image = detection;
                    aqDisplayDectection.Update();

                    if (firstFrameDetection)
                    {
                        firstFrameDetection = false;
                        aqDisplayDectection.FitToScreen();
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

        public void RegisterVisionAPI2()
        {
            bool firstFrame = true;
            while (!m_endThread)
            {
                try
                {
                    aqDisplayDectection.Invoke(new MethodInvoker(delegate
                    {
//                        aqDisplayDectection.Image = m_AcquisitionDetection.Acquisition();
                        if (firstFrame)
                        {
                            firstFrame = false;
                            aqDisplayDectection.FitToScreen();
                        }
                        aqDisplayDectection.Update();
                    }));
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
            ListViewItem item = new ListViewItem(listViewRecord.Items.Count.ToString(), 0);
            item.SubItems.Add(new DateTime().ToString());
            item.SubItems.Add(strMessage);
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

        private void splitUpContainerTitle_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitUpContainerTitle_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainerAqDisplayControls_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            label_Title.Location = new Point(Convert.ToInt32(panelTitle.ClientSize.Width / 2 - label_Title.Size.Width / 2),
                                              Convert.ToInt32(label_Title.Location.Y/*panelTitle.Height / 2*/));

             //splitContainerAqDisplayControls.Panel1.Width = Convert.ToInt32(splitContainerAqDisplayControls.ClientSize.Width/2);
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void 开启检测实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxCameraDetection.Checked = true;
            checkBoxCameraDetection_CheckedChanged(null, null);
            ClosedetectAcquistionToolStripMenuItem.Checked = false;
            OpendetectAcquistionToolStripMenuItem.Checked = true;
        }

        private void 关闭检测实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxCameraDetection.Checked = false;
            checkBoxCameraDetection_CheckedChanged(null, null);
            ClosedetectAcquistionToolStripMenuItem.Checked = true;
            OpendetectAcquistionToolStripMenuItem.Checked = false;
        }

        private void 开启定位实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxCameraAcquisition.Checked = true;
            checkBoxCameraAcquisition_CheckedChanged(null, null);
            CloseLocationAcquistionToolStripMenuItem.Checked = false;
            OpenLocationAcquistionToolStripMenuItem.Checked = true;
        }

        private void 关闭定位实时采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBoxCameraAcquisition.Checked = false;
            checkBoxCameraAcquisition_CheckedChanged(null, null);
            CloseLocationAcquistionToolStripMenuItem.Checked = true;
            OpenLocationAcquistionToolStripMenuItem.Checked = false;
        }

        private void 触发定位RPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TriggerCamera(0, 0, 0);
        }

        private void 触发检测RPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int abc = 0;
            GetWorkObjInfo(ref abc);
        }
    }
}