using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using AqVision.Shape;

namespace IntegrationTesting
{

    public partial class Form1 : Form
    {
        AqVision.Acquistion.AqAcquisitionImage acquisition = new AqVision.Acquistion.AqAcquisitionImage();
        public Thread showPic = null;
        public bool m_bExit = false;

        public Form1()
        {
            InitializeComponent();
            acquisition.Connect();
        }

        ~Form1()
        {
            acquisition.DisConnect();
        }

        private void buttonAcquisition_Click(object sender, EventArgs e)
        {
            showPic = new Thread(new ThreadStart(RegisterVisionAPI));
            showPic.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bExit = true;
            Thread.Sleep(4000);
        }

        public void RegisterVisionAPI()
        {
            while (!m_bExit)
            {
                try
                {
                    aqDisplay1.Image = acquisition.Acquisition();
                    aqDisplay1.Update();
                }
                catch (SEHException e)
                {
                    AqVision.Interaction.UI2LibInterface.OutputDebugString("SEH Exception: " + e.ToString());
                }
                finally
                {
                    AqVision.Interaction.UI2LibInterface.OutputDebugString("Thread Exception");
                }
                Thread.Sleep(10);
            }
        }

        private void btn_LoadBitmap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.tif;*.tiff;*.wmf;*.emf|JPEG Files (*.jpg)|*.jpg;*.jpeg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|TIF files (*.tif;*.tiff)|*.tif;*.tiff|EMF/WMF Files (*.wmf;*.emf)|*.wmf;*.emf|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                aqDisplay1.Image = new Bitmap(openFileDialog.FileName);
                aqDisplay1.FitToScreen();
            }
        }

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            AqLineSegment lineSegment = new AqLineSegment();
            lineSegment.StartX = 20;
            lineSegment.StartY = 20;
            lineSegment.EndX = 200;
            lineSegment.EndY = 200;
            aqDisplay1.InteractiveGraphics.Add(lineSegment, "AAA 11111", true);
            aqDisplay1.Update();
        }

        private void buttonAddRectangle_Click(object sender, EventArgs e)
        {
            AqRectangleAffine rectangle = new AqRectangleAffine();
            rectangle.LeftTopPointX = 120;
            rectangle.LeftTopPointY = 120;
            rectangle.RightBottomX = 300;
            rectangle.RightBottomY = 300;
            aqDisplay1.InteractiveGraphics.Add(rectangle, "AAA 22222", true);
            aqDisplay1.Update();
        }

        private void buttonAddCircle_Click(object sender, EventArgs e)
        {
            AqGdiPointF LeftTopPoint = new AqGdiPointF(200, 200);
            AqGdiPointF RightBottomPoint = new AqGdiPointF(500, 500);
            AqCircularArc arc = new AqCircularArc(LeftTopPoint, RightBottomPoint, 0, 315);
            aqDisplay1.InteractiveGraphics.Add(arc, "AAA 33333", true);
            aqDisplay1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aqDisplay1.InteractiveGraphics.Clear();
            aqDisplay1.Update();
        }
    }
}
