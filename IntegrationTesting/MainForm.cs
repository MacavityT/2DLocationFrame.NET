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

namespace IntegrationTesting
{
    public partial class MainForm : Form
    {
        AqVision.Acquistion.AqAcquisitionImage m_AcquisitionLocation = new AqVision.Acquistion.AqAcquisitionImage();
        Thread showPicLocation = null;
        bool m_endThread = false;

        CalibrationSetForm m_calibrateShow = new CalibrationSetForm();
        AcqusitionImageSet m_acqusitionImageSet = new AcqusitionImageSet();
        TemplateSetForm m_templateSet = new TemplateSetForm();
        AIDIManagementForm m_aidiMangement = new AIDIManagementForm();
        RobotManagementForm m_robotSeverForm = new RobotManagementForm();

        static VisionImpl m_visionImpl = new VisionImpl();
        Server m_server = new Server
        {
            Services = { Robot2dApp.BindService(m_visionImpl) },
            Ports = { new ServerPort("192.168.1.222", 50051, ServerCredentials.Insecure) }
        };        

        public MainForm()
        {
            InitializeComponent();
            listViewRecord.Columns.Add("Serial NO", 10, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Time", 10, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Message", 140, HorizontalAlignment.Center);
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
            m_AcquisitionLocation.CameraExposure[0] = Convert.ToUInt32(IniFile.ReadValue("Acquistion", "ExposureTimeLocation", "5000"));
            m_AcquisitionLocation.CameraExposure[1] = Convert.ToUInt32(IniFile.ReadValue("Acquistion", "ExposureTimeDetection", "5000"));
            IniFile.ReadValue("Acquistion", "CameraNameLocation", m_AcquisitionLocation.CameraName[0]);
            IniFile.ReadValue("Acquistion", "CameraNameDetection", m_AcquisitionLocation.CameraName[1]);
            string strValue = IniFile.ReadValue("Acquistion", "CameraBrandLocation", "DaHeng");
            if (strValue == "DaHeng")
            {
                m_AcquisitionLocation.CameraBrand[0] = AqCameraBrand.DaHeng;
            }
            else
            {
                m_AcquisitionLocation.CameraBrand[0] = AqCameraBrand.Basler;
            }

            IniFile.ReadValue("Acquistion", "CameraBrandDetection", strValue);
            if (strValue == "DaHeng")
            {
                m_AcquisitionLocation.CameraBrand[1] = AqCameraBrand.DaHeng;
            }
            else
            {
                m_AcquisitionLocation.CameraBrand[1] = AqCameraBrand.Basler;
            }
        }

        public void WriteConfigToIniFile()
        {
            IniFile.WriteValue("Acquistion", "ExposureTimeLocation", m_AcquisitionLocation.CameraExposure[0].ToString());
            IniFile.WriteValue("Acquistion", "ExposureTimeDetection", m_AcquisitionLocation.CameraExposure[1].ToString());
            IniFile.WriteValue("Acquistion", "CameraNameLocation", m_AcquisitionLocation.CameraName[0]);
            IniFile.WriteValue("Acquistion", "CameraNameDetection", m_AcquisitionLocation.CameraName[1]);
            IniFile.WriteValue("Acquistion", "CameraBrandLocation", m_AcquisitionLocation.CameraBrand[0].ToString());
            IniFile.WriteValue("Acquistion", "CameraBrandDetection", m_AcquisitionLocation.CameraBrand[1].ToString());
        }

        private int TriggerCamera(double robotX, double robotY, double robotRz)
        {
            checkBoxCameraAcquisition.Invoke(new MethodInvoker(delegate
            {
                if (checkBoxCameraAcquisition.Checked)
                {
                    checkBoxCameraAcquisition.Checked = false;
                    checkBoxCameraAcquisition_CheckedChanged(null, null);
                    m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                }
                else
                {
                    Bitmap detection = null;
                    Bitmap location = null;
                    m_AcquisitionLocation.Acquisition(ref location,ref detection);
                    m_templateSet.ImageInput = location.Clone() as Bitmap;
                }
                m_templateSet.RunMatcher();
                m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);
                AddMessageToListView(string.Format("robot location position: {0} {1} {2}", robotX, robotY, robotRz));
            }));

            return 0;
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
            checkBoxCameraDetection.Invoke(new MethodInvoker(delegate
            {
                if (m_aidiMangement.SourceBitmap != null)
                {
                    m_aidiMangement.SourceBitmap.Clear();
                }
                
                if (checkBoxCameraDetection.Checked)
                {
                    checkBoxCameraDetection.Checked = false;
                    checkBoxCameraDetection_CheckedChanged(null, null);
                    m_aidiMangement.SourceBitmap.Add(aqDisplayDectection.Image.Clone() as Bitmap);                
                }
                m_aidiMangement.DetectBmp();
                aqDisplayDectection.Image = m_aidiMangement.SourceBitmap[0];
                m_aidiMangement.DrawContours(m_aidiMangement.ObjList[0], AqVision.AqColorConstants.Red, 1, aqDisplayDectection);
                aqDisplayDectection.FitToScreen();
                aqDisplayDectection.Update();
            }));
            if(m_aidiMangement.DetectResult)
            {
                AddMessageToListView("检测无错误");
            }
            else
            {
                AddMessageToListView("检测有错误");
            }
            return m_aidiMangement.DetectResult;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_endThread = true;
            m_AcquisitionLocation.DisConnect();
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

        public void RegisterVisionAPI()
        {
            bool firstFrameLocation = true;
            bool firstFrameDetection = true;
            while (!m_endThread)
            {
                try
                {
                    Bitmap location = null;
                    Bitmap detection = null;
                    m_AcquisitionLocation.Acquisition(ref location, ref detection); 
                    
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

                            if(firstFrameDetection)
                            {
                                firstFrameDetection = false;
                                aqDisplayDectection.FitToScreen();
                            }
                        }   
                        
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
                    m_AcquisitionLocation.Connect();
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
                m_AcquisitionLocation.DisConnect();
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
                m_AcquisitionLocation.DisConnect();
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
            m_acqusitionImageSet.ExposureTimeLocation = m_AcquisitionLocation.CameraExposure[0];
            m_acqusitionImageSet.CameraNameLocation = m_AcquisitionLocation.CameraName[0];
            m_acqusitionImageSet.CameraBrandLocation = (int)m_AcquisitionLocation.CameraBrand[0];
            m_acqusitionImageSet.ExposureTimeDetection = m_AcquisitionLocation.CameraExposure[1];
            m_acqusitionImageSet.CameraNameDetection = m_AcquisitionLocation.CameraName[1];
            m_acqusitionImageSet.CameraBrandDetection = (int)m_AcquisitionLocation.CameraBrand[1];

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

            m_AcquisitionLocation.CameraExposure = exposure;
            m_AcquisitionLocation.CameraName = name;
            m_AcquisitionLocation.CameraBrand = brand;
        }

        private void ToolStripMenuItemSetCalibration_Click(object sender, EventArgs e)
        {
            m_calibrateShow.ShowDialog();
        }

        private void ToolStripMenuItemSetLocation_Click(object sender, EventArgs e)
        {
            if (checkBoxCameraAcquisition.Checked)
            {
                checkBoxCameraAcquisition.Checked = false;
                checkBoxCameraAcquisition_CheckedChanged(null, null);
                m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
            }
            m_templateSet.ShowDialog();
        }

        private void ToolStripMenuItemSetDectection_Click(object sender, EventArgs e)
        {
            m_aidiMangement.ShowDialog();
        }

        private void ToolStripMenuItemSetRobotConnect_Click(object sender, EventArgs e)
        {
            m_robotSeverForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_server.ShutdownAsync();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int abc = 0;
            GetWorkObjInfo(ref abc);
        }
    }
}