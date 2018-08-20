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
        public AcqusitionImageSet()
        {
            InitializeComponent();
            comboBoxCameraBrandLocation.SelectedIndex = 0;
            comboBoxCameraBrandDetection.SelectedIndex = 0;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CameraNameLocation = textBoxCameraNameLocation.Text;
            m_exposureTimeLocation = Convert.ToUInt32(textBoxExposureTimeLocation.Text);
            m_cameraBrandLocation = comboBoxCameraBrandLocation.SelectedIndex;

            CameraNameDetection = textBoxCameraNameDetection.Text;
            m_exposureTimeDetection = Convert.ToUInt32(textBoxExposureTimeDetection.Text);
            m_cameraBrandDetection = comboBoxCameraBrandDetection.SelectedIndex;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
