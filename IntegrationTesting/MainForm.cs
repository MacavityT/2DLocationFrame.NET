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

namespace IntegrationTesting
{
    public partial class MainForm : Form
    {
        AqVision.Acquistion.AqAcquisitionImage m_AcquisitionLocation = new AqVision.Acquistion.AqAcquisitionImage();
        Thread showPicLocation = null;
        Thread showPicDetection = null;
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
            listViewRecord.Columns.Add("Serial NO", -2, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Time", -2, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Message", -2, HorizontalAlignment.Center);
            m_visionImpl.triggerCamerHandler = new TriggerCamerHandler(TriggerCamera);
            m_visionImpl.getLocalizeResultHandler = new GetLocalizeResultHandler(GetLocalizeResult);
        }

        ~MainForm()
        {
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
                    m_templateSet.RunMatcher();
                    m_calibrateShow.SetCurrentRobotPosition(robotX, robotY, robotRz);

                    AddMessageToListView(string.Format("robot location position: {0} {1} {2}", robotX, robotY, robotRz));
                }
                else
                {
                    MessageBox.Show("please open live show");
                }
            }));

            return 0;
        }

        private bool GetLocalizeResult(ref double posX, ref double posY, ref double theta)
        {
            m_calibrateShow.SetCurrentImagePosition(m_templateSet.LocationResultPosX, m_templateSet.LocationResultPosY,m_templateSet.LocationResultPosTheta);
            m_calibrateShow.GetCurrentCatchPosition(ref posX,ref posY,ref theta);
            return true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_endThread = true;
            m_AcquisitionLocation.DisConnect();
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
            bool firstFrame = true;
            while (!m_endThread)
            {
                try
                {
                    Bitmap location = null;
                    Bitmap detection = null;
                    m_AcquisitionLocation.Acquisition(ref location, ref detection); 
                    
                    aqDisplayLocation.Invoke(new MethodInvoker(delegate
                    {
                        if (firstFrame)
                        {
                            firstFrame = false;
                            if (checkBoxCameraAcquisition.Checked)
                            {
                                aqDisplayLocation.FitToScreen();
                            }
                            if (checkBoxCameraDetection.Checked)
                            {
                                aqDisplayDectection.FitToScreen();
                            }                            
                        }
                        if (checkBoxCameraAcquisition.Checked)
                        {
                            aqDisplayLocation.Image = location;
                            aqDisplayLocation.Update();
                        }
                        if (checkBoxCameraDetection.Checked)
                        {
                            aqDisplayDectection.Image = location;
                            aqDisplayDectection.Update();
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
            m_acqusitionImageSet.ShowDialog();
            m_AcquisitionLocation.CameraExposure = m_acqusitionImageSet.ExposureTimeLocation;
            m_AcquisitionLocation.CameraName = m_acqusitionImageSet.CameraNameLocation;
            if (m_acqusitionImageSet.CameraBrandLocation == 0)
            {
                m_AcquisitionLocation.CameraBrand = AqCameraBrand.DaHeng;
            }
            else if (m_acqusitionImageSet.CameraBrandLocation == 1)
            {
                m_AcquisitionLocation.CameraBrand = AqCameraBrand.Basler;
            }

//            m_AcquisitionDetection.CameraExposure = m_acqusitionImageSet.ExposureTimeDetection;
//            m_AcquisitionDetection.CameraName = m_acqusitionImageSet.CameraNameDetection;
            if (m_acqusitionImageSet.CameraBrandLocation == 0)
            {
//                m_AcquisitionDetection.CameraBrand = AqCameraBrand.DaHeng;
            }
            else if (m_acqusitionImageSet.CameraBrandLocation == 1)
            {
//                m_AcquisitionDetection.CameraBrand = AqCameraBrand.Basler;
            }
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
    }
}