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
        string m_cameraNameLocation = "";

        public string CameraNameLocation
        {
            get { return m_cameraNameLocation; }
            set { m_cameraNameLocation = value; }
        }
        UInt32 m_exposureTimeLocation = 5000;

        public UInt32 ExposureTimeLocation
        {
            get { return m_exposureTimeLocation; }
            set { m_exposureTimeLocation = value; }
        }

        int m_cameraBrandLocation;
        public int CameraBrandLocation
        {
            get { return m_cameraBrandLocation; }
            set { m_cameraBrandLocation = value; }
        }

        string m_cameraNameDetection = "";

        public string CameraNameDetection
        {
            get { return m_cameraNameDetection; }
            set { m_cameraNameDetection = value; }
        }
        UInt32 m_exposureTimeDetection = 5000;

        public UInt32 ExposureTimeDetection
        {
            get { return m_exposureTimeDetection; }
            set { m_exposureTimeDetection = value; }
        }

        int m_cameraBrandDetection;
        public int CameraBrandDetection
        {
            get { return m_cameraBrandDetection; }
            set { m_cameraBrandDetection = value; }
        }

        string m_inputImageFileLocationPath = null;

        public string InputImageFileLocationPath
        {
            get { return m_inputImageFileLocationPath; }
            set { m_inputImageFileLocationPath = value; }
        }
        string m_inputImageFileDetectionPath = null;

        public string InputImageFileDetectionPath
        {
            get { return m_inputImageFileDetectionPath; }
            set { m_inputImageFileDetectionPath = value; }
        }
        string m_inputImageFolderLocationPath = null;

        public string InputImageFolderLocationPath
        {
            get { return m_inputImageFolderLocationPath; }
            set { m_inputImageFolderLocationPath = value; }
        }
        string m_inputImageFolderDetectionPath = null;

        public string InputImageFolderDetectionPath
        {
            get { return m_inputImageFolderDetectionPath; }
            set { m_inputImageFolderDetectionPath = value; }
        }

        AcquisitionMode mode = AcquisitionMode.FromCamera;

        public AcquisitionMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        public AcqusitionImageSet()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CameraNameLocation = textBoxCameraNameLocation.Text;
            m_exposureTimeLocation = Convert.ToUInt32(textBoxExposureTimeLocation.Text);
            m_cameraBrandLocation = comboBoxCameraBrandLocation.SelectedIndex;

            CameraNameDetection = textBoxCameraNameDetection.Text;
            m_exposureTimeDetection = Convert.ToUInt32(textBoxExposureTimeDetection.Text);
            m_cameraBrandDetection = comboBoxCameraBrandDetection.SelectedIndex;
            m_inputImageFileLocationPath = textBoxLocationFile.Text;
            m_inputImageFileDetectionPath = textBoxDetectionFile.Text;
            m_inputImageFolderLocationPath = textBoxLocationFile.Text;
            m_inputImageFolderDetectionPath = textBoxDetectionFile.Text;            
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AcqusitionImageSet_Load(object sender, EventArgs e)
        {
            comboBoxCameraBrandLocation.SelectedIndex = m_cameraBrandLocation;
            comboBoxCameraBrandDetection.SelectedIndex = m_cameraBrandDetection;

            textBoxCameraNameLocation.Text = CameraNameLocation;
            textBoxCameraNameDetection.Text = CameraNameDetection;

            textBoxExposureTimeLocation.Text = ExposureTimeLocation.ToString();
            textBoxExposureTimeDetection.Text = ExposureTimeDetection.ToString();

            textBoxLocationFile.Text = m_inputImageFileLocationPath;
            textBoxDetectionFile.Text = m_inputImageFileDetectionPath;
            textBoxLocationFile.Text = m_inputImageFolderLocationPath;
            textBoxDetectionFile.Text = m_inputImageFolderDetectionPath;  

            if (mode == AcquisitionMode.FromCamera)
            {
                radioButtonCamera_CheckedChanged(null, null);
            }
            else if (mode == AcquisitionMode.FromFile)
            {
                radioButtonLocalFile_CheckedChanged(null, null);
            }
            else if (mode == AcquisitionMode.FromFolder)
            {
                radioButtonLocalFolder_CheckedChanged(null, null);
            }
        }

        private void radioButtonCamera_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = true;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = false;
            mode = AcquisitionMode.FromCamera;
        }

        private void radioButtonLocalFile_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = true;
            panelLocalFolder.Enabled = false;
            mode = AcquisitionMode.FromFile;
        }

        private void radioButtonLocalFolder_CheckedChanged(object sender, EventArgs e)
        {
            panelCamera.Enabled = false;
            panelCamerapanelLocalFile.Enabled = false;
            panelLocalFolder.Enabled = true;
            mode = AcquisitionMode.FromFolder;
        }

        private void buttonLocationDirectory_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxLocationFile.Text = dialog.FileName;
            }
        }

        private void buttonDetectionDirectory_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "选择输入文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxDetectionFile.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {

                textBoxLocationDirectory.Text = folder.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBoxDetectionDirectory.Text = folder.SelectedPath;
            }
        }
    }
}
