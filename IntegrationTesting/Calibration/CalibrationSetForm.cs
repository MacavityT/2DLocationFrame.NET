using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace IntegrationTesting
{
    public partial class CalibrationSetForm : Form
    {
        AqCalibration m_calibrationCenter = new AqCalibration();
        public CalibrationSetForm()
        {
            InitializeComponent();
            listViewParameterSet.Columns.Add("Camera X", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Camera Y", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot X", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot Y", 100, HorizontalAlignment.Center);
            listViewParameterSet.Columns.Add("Robot Rz", 100, HorizontalAlignment.Center);

            string[] modeList = new string[]{"Camera in  Hand with Angle is Positive", "Camera in  Hand with Angle is Negative",
                                             "Camera out Hand with Angle is Positive", "Camera out Hand with Angle is Negative"};
            foreach(string mode in modeList)
            {
                comboBoxModeList.Items.Add(mode);
            }

            m_calibrationCenter.CalibrationResultSavePath = Application.StartupPath;

            IntegrationTesting.Tool.IniFile.IniFillFullPath = Application.StartupPath + "\\Config.ini";

            if (!File.Exists(IntegrationTesting.Tool.IniFile.IniFillFullPath))
            {
                File.Create(IntegrationTesting.Tool.IniFile.IniFillFullPath);
            }

        }


        private void listViewParameterSet_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        private void buttonNewLine_Click(object sender, EventArgs e)
        {
            ListViewItem line = new ListViewItem(textBoxCameraX.Text, 0);
            line.SubItems.Add(textBoxCameraY.Text);
            line.SubItems.Add(textBoxRobotX.Text);
            line.SubItems.Add(textBoxRobotY.Text);
            line.SubItems.Add(textBoxRobotRz.Text);
            listViewParameterSet.Items.Add(line);
        }

        private void buttonDeleteLine_Click(object sender, EventArgs e)
        {
            if (listViewParameterSet.SelectedItems.Count > 0)
            {
                listViewParameterSet.Items.Remove(listViewParameterSet.SelectedItems[0]);
            }            
        }

        private void buttonUpdateLine_Click(object sender, EventArgs e)
        {
            if(listViewParameterSet.SelectedItems.Count > 0)
            {
                listViewParameterSet.SelectedItems[0].SubItems[0].Text = textBoxCameraX.Text;
                listViewParameterSet.SelectedItems[0].SubItems[1].Text = textBoxCameraY.Text;
                listViewParameterSet.SelectedItems[0].SubItems[2].Text = textBoxRobotX.Text;
                listViewParameterSet.SelectedItems[0].SubItems[3].Text = textBoxRobotY.Text;
                listViewParameterSet.SelectedItems[0].SubItems[4].Text = textBoxRobotRz.Text;
            }
        }

        private void buttonCalibration_Click(object sender, EventArgs e)
        {
            int rowCounts = listViewParameterSet.Items.Count;
            for(int i=0; i<rowCounts; i++)
            {
                try
                {
                    m_calibrationCenter.ImagePoint.SetValue(
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[0].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[1].Text), 0);

                    m_calibrationCenter.RobotPoint.SetValue(
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[2].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[3].Text),
                    Convert.ToDouble(listViewParameterSet.Items[i].SubItems[4].Text));

                    if(!m_calibrationCenter.AddMoveMatchPointPair())
                    {
                        MessageBox.Show("Add Move Match Point Pair Error");
                        return ;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            if(!m_calibrationCenter.NPoint2AngleCalibartion())
            {
                MessageBox.Show("N Point to Angle Calibration Error");
                return;
            }
        }

        private void buttonSetCatchSet_Click(object sender, EventArgs e)
        {
            try
            {
                m_calibrationCenter.ImagePoint.SetValue(Convert.ToDouble(textBoxImageX.Text),
                                        Convert.ToDouble(textBoxImageY.Text),
                                        Convert.ToDouble(textBoxImageA.Text));

                m_calibrationCenter.RobotPoint.SetValue(Convert.ToDouble(textBoxRobotPosX.Text),
                                                        Convert.ToDouble(textBoxRobotPosY.Text),
                                                        Convert.ToDouble(textBoxRobotPosRz.Text));

                m_calibrationCenter.CatchPoint.SetValue(Convert.ToDouble(textBoxCatchRobotX.Text),
                                                        Convert.ToDouble(textBoxCatchRobotY.Text),
                                                        Convert.ToDouble(textBoxCatchRobotRz.Text));

                if (!m_calibrationCenter.SetCatchPoint())
                {
                    MessageBox.Show("Set Catch Point Error");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetResult_Click(object sender, EventArgs e)
        {
            try
            {
                m_calibrationCenter.ImagePoint.SetValue(Convert.ToDouble(textBoxImageX.Text),
                                        Convert.ToDouble(textBoxImageY.Text),
                                        Convert.ToDouble(textBoxImageA.Text));

                m_calibrationCenter.RobotPoint.SetValue(Convert.ToDouble(textBoxRobotPosX.Text),
                                                        Convert.ToDouble(textBoxRobotPosY.Text),
                                                        Convert.ToDouble(textBoxRobotPosRz.Text));

                if (!m_calibrationCenter.GetRobotPoint())
                {
                    MessageBox.Show("Set Catch Point Error");
                }

                textBoxCatchRobotX.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchX);
                textBoxCatchRobotY.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchY);
                textBoxCatchRobotRz.Text = Convert.ToString(m_calibrationCenter.CatchPoint.CatchRz);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonSaveResult_Click(object sender, EventArgs e)
        {
            m_calibrationCenter.SaveCalibrationResult();
        }

        private void buttonLoadResult_Click(object sender, EventArgs e)
        {
            m_calibrationCenter.LoadCalibrationResult();
        }
    }
}