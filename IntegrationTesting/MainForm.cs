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

namespace IntegrationTesting
{
    public partial class MainForm : Form
    {
        AqVision.Acquistion.AqAcquisitionImage m_Acquisition = new AqVision.Acquistion.AqAcquisitionImage();
        Thread showPic = null;
        bool m_endThread = false;

        CalibrationSetForm m_calibrateShow = new CalibrationSetForm();
        AcqusitionImageSet m_acqusitionImageSet = new AcqusitionImageSet();
        TemplateSetForm m_templateSet = new TemplateSetForm();
        AIDIManagementForm m_aidiMangement = new AIDIManagementForm();
        RobotManagementForm m_robotSeverForm = new RobotManagementForm();

        public MainForm()
        {
            InitializeComponent();
            listViewRecord.Columns.Add("Serial NO", -2, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Time", -2, HorizontalAlignment.Center);
            listViewRecord.Columns.Add("Message", -2, HorizontalAlignment.Center);
        }

        ~MainForm()
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_endThread = true;
            m_Acquisition.DisConnect();
            if (!ReferenceEquals(showPic, null))
            {
                if (showPic.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    showPic.Resume();
                }
                showPic.Abort();
                while (showPic.ThreadState != System.Threading.ThreadState.Aborted)
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
                            aqDisplayLocation.Image = m_Acquisition.Acquisition();
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
        private void buttonRun_Click(object sender, EventArgs e)
        {
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

                    if (ReferenceEquals(showPic, null))
                    {
                        m_Acquisition.Connect();
                        showPic = new Thread(new ThreadStart(RegisterVisionAPI));
                        showPic.Start();
                    }
                    if (showPic.ThreadState == System.Threading.ThreadState.Suspended)
                    {
                        showPic.Resume();
                    }
                }
                catch (Exception ex)
                {
                    m_Acquisition.DisConnect();
                    MessageBox.Show(ex.Message);
                }

                checkBoxCameraAcquisition.Text = "停止采集";
                checkBoxCameraAcquisition.BackColor = Color.Red;
            }
            else
            {
                try
                {
                    if (!ReferenceEquals(showPic, null))
                    {
                        //if (showPic.ThreadState == ThreadState.Running)
                        {
                            showPic.Suspend();
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_Acquisition.DisConnect();
                    MessageBox.Show(ex.Message);
                }
                checkBoxCameraAcquisition.Text = "连续采集";
                checkBoxCameraAcquisition.BackColor = Color.Green;
            }
        }

        private void ToolStripMenuItemSetAcqusition_Click(object sender, EventArgs e)
        {
            m_acqusitionImageSet.ShowDialog();
            m_Acquisition.CameraExposure = m_acqusitionImageSet.ExposureTime;
            m_Acquisition.CameraName = m_acqusitionImageSet.CameraName;
            if (m_acqusitionImageSet.CameraBrand == 0)
            {
                m_Acquisition.CameraBrand = AqCameraBrand.DaHeng;
            }
            else if (m_acqusitionImageSet.CameraBrand == 1)
            {
                m_Acquisition.CameraBrand = AqCameraBrand.Basler;
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
    }
}