using IntegrationTesting.Acquisition;
using IntegrationTesting.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTesting
{
    public partial class AcqusitionImageSet : Form
    {
        CameraParam cameraParam = new CameraParam();

        public CameraParam CameraParamSet
        {
            get { return cameraParam; }
            set { cameraParam = value; }
        }

        public AcqusitionImageSet()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(comboBoxCameraBrand.SelectedIndex == 0 )
            {
                CameraParamSet.CameraNameBrand[comboBoxCameraName.Text] = AqCameraBrand.DaHeng;
            }
            else
            {
                CameraParamSet.CameraNameBrand[comboBoxCameraName.Text] = AqCameraBrand.Basler;
            }

            CameraParamSet.CameraNameExposure[comboBoxCameraName.Text] = Convert.ToUInt32(textBoxExposureTime.Text);

            CameraParamSet.CameraNameInputFile[comboBoxCameraName.Text] = textBoxFile.Text;

            CameraParamSet.CameraNameInputFolder[comboBoxCameraName.Text] = textBoxFolder.Text;
            if (radioButtonCamera.Checked)
            {
                CameraParamSet.AcquisitionStyle[comboBoxCameraName.Text] = AcquisitionMode.FromCamera;
            }
            else if (radioButtonLocalFile.Checked)
            {
                CameraParamSet.AcquisitionStyle[comboBoxCameraName.Text] = AcquisitionMode.FromFile;
            }
            else if (radioButtonLocalFolder.Checked)
            {
                CameraParamSet.AcquisitionStyle[comboBoxCameraName.Text] = AcquisitionMode.FromFolder;
            }

            CameraParamSet.UpdateFilesUnderFolder();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AcqusitionImageSet_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < CameraParamSet.CameraName.Count; i++ )
            {
                comboBoxCameraName.Items.Add(CameraParamSet.CameraName[i]);
            }

            ShowCameraBaseCameraName(0);
        }

        void ShowCameraBaseCameraName(int index)
        {
            comboBoxCameraName.SelectedIndex = index;
            comboBoxCameraBrand.SelectedIndex = Convert.ToInt32(CameraParamSet.CameraNameBrand[CameraParamSet.CameraName[index]]);
            textBoxExposureTime.Text = CameraParamSet.CameraNameExposure[CameraParamSet.CameraName[index]].ToString();
            textBoxFile.Text = CameraParamSet.CameraNameInputFile[CameraParamSet.CameraName[index]];
            textBoxFolder.Text = CameraParamSet.CameraNameInputFolder[CameraParamSet.CameraName[index]];

            if (CameraParamSet.AcquisitionStyle[CameraParamSet.CameraName[index]] == AcquisitionMode.FromCamera)
            {
                radioButtonCamera.Checked = true;
            }
            else if (CameraParamSet.AcquisitionStyle[CameraParamSet.CameraName[index]] == AcquisitionMode.FromFile)
            {
                radioButtonLocalFile.Checked = true;
            }
            else if (CameraParamSet.AcquisitionStyle[CameraParamSet.CameraName[index]] == AcquisitionMode.FromFolder)
            {
                radioButtonLocalFolder.Checked = true;
            }
        }

        private void radioButtonCamera_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = true;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = false;
        }

        private void radioButtonLocalFile_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = true;
            panelLocalFolder.Enabled = false;
        }

        private void radioButtonLocalFolder_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = true;
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxFile.Text = dialog.FileName;
            }
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = folder.SelectedPath;
            }
        }

        private void comboBoxCameraName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCameraBaseCameraName(comboBoxCameraName.SelectedIndex);
        }
    }
}
