using AqVision;
using AqVision.Shape;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTesting
{
    public partial class TemplateSetForm : Form
    {
        AqVision.Location.AqLocationPattern m_Location = new AqVision.Location.AqLocationPattern();
        private double m_locationResultPosX = 0;
        public double LocationResultPosX
        {
            get { return m_locationResultPosX; }
            set { m_locationResultPosX = value; }
        }

        private double m_locationResultPosY = 0;
        public double LocationResultPosY
        {
            get { return m_locationResultPosY; }
            set { m_locationResultPosY = value; }
        }

        private double m_locationResultPosTheta = 0;
        public double LocationResultPosTheta
        {
            get { return m_locationResultPosTheta; }
            set { m_locationResultPosTheta = value; }
        }



        Bitmap m_imageInput = null;
        public Bitmap ImageInput
        {
            get { return m_imageInput; }
            set 
            { 
                m_imageInput = value;
                m_Location.OriginImage = ImageInput.Clone() as Bitmap;
            }
        }

        public TemplateSetForm()
        {
            InitializeComponent();
            m_Location.LoadModel(@"D:\Model.shm");
        }

        private void TemplateSet_Load(object sender, EventArgs e)
        {
            if(!ReferenceEquals(m_imageInput, null))
            {
                aqDisplayCreateModel.Image = ImageInput.Clone() as Bitmap;
                aqDisplayCreateModel.FitToScreen();
                aqDisplayCreateModel.Update();
            }           
        }

        private void btn_LoadBitmap_Click(object sender, EventArgs e)
        {
            try
            {
                buttonRemoveGraph_Click(null, null);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.tif;*.tiff;*.wmf;*.emf|JPEG Files (*.jpg)|*.jpg;*.jpeg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp|PNG Files (*.png)|*.png|TIF files (*.tif;*.tiff)|*.tif;*.tiff|EMF/WMF Files (*.wmf;*.emf)|*.wmf;*.emf|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    aqDisplayCreateModel.Image = new Bitmap(openFileDialog.FileName);
                    m_Location.TemplatePath = openFileDialog.FileName;
                    m_Location.OriginImage = new Bitmap(openFileDialog.FileName);
                    aqDisplayCreateModel.FitToScreen();
                    aqDisplayCreateModel.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRemoveGraph_Click(object sender, EventArgs e)
        {
            aqDisplayCreateModel.InteractiveGraphics.Clear();
            aqDisplayCreateModel.Update();
        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            try
            {
                if (aqDisplayCreateModel.InteractiveGraphics.Count > 0)
                {
                    m_Location.OriginImage = aqDisplayCreateModel.Image;
                    m_Location.RoiRegionTemplate = (AqRectangleAffine)(aqDisplayCreateModel.InteractiveGraphics[0]);
                    m_Location.CreateTempateImage(@"D:\Bitmap.bmp");
                    m_Location.CreateModel();
                    aqDisplayCreateModel.InteractiveGraphics.Clear();
                    ShowGetResultsData(m_Location.ModeXldColsM, m_Location.ModeXldRowsM, m_Location.ModeXldPointCountsM, AqColorConstants.Blue);
//                     AddMessageToListView((new Rectangle((int)(m_Location.RoiRegionTemplate.LeftTopPointX), (int)(m_Location.RoiRegionTemplate.LeftTopPointY),
//                                            (int)(m_Location.RoiRegionTemplate.RightBottomX - m_Location.RoiRegionTemplate.LeftTopPointX),
//                                            (int)(m_Location.RoiRegionTemplate.RightBottomY - m_Location.RoiRegionTemplate.LeftTopPointY))).ToString());
                    aqDisplayCreateModel.Update();
                    MessageBox.Show("create Model success");
                }
                else
                {
                    //AddMessageToListView("aqDisplay1 is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddRectangleRegion_Click(object sender, EventArgs e)
        {
            try
            {
                aqDisplayCreateModel.InteractiveGraphics.Clear();
                AqRectangleAffine rectangle = new AqRectangleAffine();
                rectangle.LeftTopPointX = 120;
                rectangle.LeftTopPointY = 120;
                rectangle.RightBottomX = 300;
                rectangle.RightBottomY = 300;
                aqDisplayCreateModel.InteractiveGraphics.Add(rectangle, "AAA 22222", true);
                aqDisplayCreateModel.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLocation_Click(object sender, EventArgs e)
        {
            try
            {
                aqDisplayCreateModel.InteractiveGraphics.Clear();
                aqDisplayCreateModel.Update();
                RunMatcher();
                ShowGetResultsData(m_Location.XldColsM, m_Location.XldRowsM, m_Location.XldPointCountsM, AqColorConstants.Green);
                textBox1.Text = LocationResultPosX.ToString("0.000");
                textBox2.Text = LocationResultPosY.ToString("0.000");
                textBox3.Text = (LocationResultPosTheta / Math.PI * 180).ToString("0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RunMatcher()
        {
            m_Location.RunMatcherByHalcon();
            LocationResultPosX = m_Location.CenterX;
            LocationResultPosY = m_Location.CenterY;
            LocationResultPosTheta = m_Location.Angle;
        }

        private void ShowGetResultsData(double[] xPointList, double[] yPointList, long[] countPointList, AqColorConstants color)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            int iPointList = 0;
//             double[] centerX = new double[countPointList.Length];
//             double[] centerY = new double[countPointList.Length];
//             double PlusX = 0;
//             double PlusY = 0;

            for (int countList = 0, countSegement = 0; iPointList < xPointList.Length; iPointList++, countSegement++)
            {
//                 PlusX += xPointList[iPointList];
//                 PlusY += yPointList[iPointList];
                AqLineSegment lineSegment = new AqLineSegment();
                if ((countSegement + 1) == countPointList[countList])
                {
                    lineSegment.StartX = xPointList[iPointList];
                    lineSegment.StartY = yPointList[iPointList];

//                     //保存中心点
//                     centerX[countList] = PlusX / countPointList[countList];
//                     centerY[countList] = PlusY / countPointList[countList];
//                     PlusX = 0;
//                     PlusY = 0;

                    if (countList == 0)
                    {
                        lineSegment.EndX = xPointList[0];
                        lineSegment.EndY = yPointList[0];

                        if ((Math.Abs(xPointList[0] - xPointList[iPointList]) < 0.0001) &&
                           (Math.Abs(yPointList[0] - yPointList[iPointList]) < 0.0001))
                        {
                            lineSegment.EndX = xPointList[0];
                            lineSegment.EndY = yPointList[0];
                            countList++;
                            countSegement = -1;
                        }
                        else
                        {
                            countList++;
                            countSegement = -1;
                            continue;   //不连接
                        }
                    }
                    else
                    {
                        if ((Math.Abs(xPointList[countPointList[countList - 1]] - xPointList[iPointList]) < 0.0001) &&
                            (Math.Abs(yPointList[countPointList[countList - 1]] - yPointList[iPointList]) < 0.0001))
                        {
                            lineSegment.EndX = xPointList[countPointList[countList - 1]];
                            lineSegment.EndY = yPointList[countPointList[countList - 1]];
                            countList++;
                            countSegement = -1;
                        }
                        else
                        {
                            countList++;
                            countSegement = -1;
                            continue;
                        }
                    }
                }
                else
                {
                    lineSegment.StartX = xPointList[iPointList];
                    lineSegment.StartY = yPointList[iPointList];
                    lineSegment.EndX = xPointList[iPointList + 1];
                    lineSegment.EndY = yPointList[iPointList + 1];
                }
                lineSegment.Color = color;
                lineSegment.LineWidthInScreenPixels = 3;
                aqDisplayCreateModel.InteractiveGraphics.Add(lineSegment, "AAA 11111", true);
            }
            st.Stop();
            aqDisplayCreateModel.Update();
//             for(int i = 0; i<countPointList.Length; i++)
//             {
//                 listBox1.Items.Add(string.Format("{0}, {1}", centerX[i], centerY[i]));
//             }
            //MessageBox.Show(string.Format("{0},{1},{2} ",st.Elapsed, st.ElapsedMilliseconds, iPointList));//fortest
        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            m_Location.SaveModel(@"D:\Model.shm");
        }
    }
}
