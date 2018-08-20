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
//        AqVision.Acquistion.AqAcquisitionImage m_AcquisitionDetection = new AqVision.Acquistion.AqAcquisitionImage();
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
            Ports = { new ServerPort("127.0.0.1", 50051, ServerCredentials.Insecure) }
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
            if (checkBoxCameraAcquisition.Checked)
            {
                checkBoxCameraAcquisition.Checked = false;
                checkBoxCameraAcquisition_CheckedChanged(null, null);
                m_templateSet.ImageInput = aqDisplayLocation.Image.Clone() as Bitmap;
                m_templateSet.RunMatcher();
            }
            else
            {
                MessageBox.Show("please open live show");
            }
            return 0;
        }

        private bool GetLocalizeResult(ref double posX, ref double posY, ref double theta)
        {
            posX = m_templateSet.LocationResultPosX;
            posY = m_templateSet.LocationResultPosY;
            theta = m_templateSet.LocationResultPosTheta;
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
                    aqDisplayLocation.Invoke(new MethodInvoker(delegate
                        {
                            aqDisplayLocation.Image = m_AcquisitionLocation.Acquisition();

                            if (firstFrame)
                            {
                                firstFrame = false;
                                aqDisplayLocation.FitToScreen();
                            }
                            aqDisplayLocation.Update();
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
        }

        public void AddMessageToListView(string strMessage)
        {
            ListViewItem item = new ListViewItem(listViewRecord.Items.Count.ToString(), 0);
            item.SubItems.Add(new DateTime().ToString());
            item.SubItems.Add(strMessage);
            listViewRecord.Items.Add(item);
        }

        private void checkBoxCameraAcquisition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCameraAcquisition.Checked)
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

                checkBoxCameraAcquisition.Text = "停止定位实时采集";
                checkBoxCameraAcquisition.Image = Properties.Resources.CameraStop;
            }
            else
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

        }

        private void checkBoxCameraDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCameraDetection.Checked)
            {
                try
                {
                    aqDisplayDectection.InteractiveGraphics.Clear();
                    aqDisplayDectection.Update();

                    if (ReferenceEquals(showPicDetection, null))
                    {
//                        m_AcquisitionDetection.Connect();
                        showPicDetection = new Thread(new ThreadStart(RegisterVisionAPI2));
                        showPicDetection.Start();
                    }
                    if (showPicDetection.ThreadState == System.Threading.ThreadState.Suspended)
                    {
                        showPicDetection.Resume();
                    }
                }
                catch (Exception ex)
                {
//                    m_AcquisitionDetection.DisConnect();
                    MessageBox.Show(ex.Message);
                }

                checkBoxCameraDetection.Text = "停止检测实时采集";
                checkBoxCameraDetection.Image = Properties.Resources.CameraStop;
            }
            else
            {
                try
                {
//                    if (!ReferenceEquals(m_AcquisitionDetection, null))
                    {
                        //if (showPic.ThreadState == ThreadState.Running)
                        {
                            showPicDetection.Suspend();
                        }
                    }
                }
                catch (Exception ex)
                {
 //                   m_AcquisitionDetection.DisConnect();
                    MessageBox.Show(ex.Message);
                }
                checkBoxCameraDetection.Text = "开启检测实时采集";
                checkBoxCameraDetection.Image = Properties.Resources.CameraRun;
            }
        }
    }
}