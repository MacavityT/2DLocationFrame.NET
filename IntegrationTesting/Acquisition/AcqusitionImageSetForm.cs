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
        string m_cameraName = "";

        public string CameraName
        {
            get { return m_cameraName; }
            set { m_cameraName = value; }
        }
        UInt32 m_exposureTime = 5000;

        public UInt32 ExposureTime
        {
            get { return m_exposureTime; }
            set { m_exposureTime = value; }
        }

        int m_cameraBrand;
        public int CameraBrand
        {
            get { return m_cameraBrand; }
            set { m_cameraBrand = value; }
        }
        public AcqusitionImageSet()
        {
            InitializeComponent();
            comboBoxCameraBrand.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CameraName = textBoxCameraName.Text;
            m_exposureTime = Convert.ToUInt32(textBoxExposureTime.Text);
            m_cameraBrand = comboBoxCameraBrand.SelectedIndex;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
