using AqVision;
using AqVision.Controls;
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
        string m_title = null;
        private double[] m_locationResultPosX = null;
        public double[] LocationResultPosX
        {
            get { return m_locationResultPosX; }
            set { m_locationResultPosX = value; }
        }

        public double[] Score
        {
            get { return m_Location.Score; }
        }

        private double[] m_locationResultPosY = null;
        public double[] LocationResultPosY
        {
            get { return m_locationResultPosY; }
            set { m_locationResultPosY = value; }
        }

        private double[] m_locationResultPosTheta = null;
        public double[] LocationResultPosTheta
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

        string m_modelFilePath = null;
        public string ModelFilePath
        {
            get { return m_modelFilePath; }
            set { m_modelFilePath = value; }
        }


        public TemplateSetForm()
        {
            InitializeComponent();
            m_title = this.Text;
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
                    ShowGetResultsData(m_Location.ModeXldColsM, m_Location.ModeXldRowsM, m_Location.ModeXldPointCountsM, AqColorConstants.Blue, aqDisplayCreateModel);
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
                RunMatcher(ModelFilePath);
                ShowGetResultsData(m_Location.XldColsM, m_Location.XldRowsM, m_Location.XldPointCountsM, AqColorConstants.Green, aqDisplayCreateModel);
                //textBox1.Text = LocationResultPosX.ToString("0.000");
                //textBox2.Text = LocationResultPosY.ToString("0.000");
                //textBox3.Text = (LocationResultPosTheta / Math.PI * 180).ToString("0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int RunMatcher(string modeFilePath)
        {
            int iResult = -1;
            try
            {
                m_Location.LoadModel(modeFilePath);
                m_Location.RunMatcherByHalcon();
                LocationResultPosX = m_Location.CenterX;
                LocationResultPosY = m_Location.CenterY;
                LocationResultPosTheta = m_Location.Angle;
                if (m_Location.XldPointCountsM.Length > 0)
                {
                    iResult = 0;
                }
                else
                {
                    iResult = -2;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                iResult = -1;
            }
            return iResult;
        }

        public void ShowGetResultsData(AqColorConstants color, AqDisplay aqDisplayShow)
        {
            ShowGetResultsData(m_Location.XldColsM, m_Location.XldRowsM, m_Location.XldPointCountsM, color, aqDisplayShow);
        }

        private void ShowGetResultsData(double[] xPointList, double[] yPointList, long[] countPointList, AqColorConstants color, AqDisplay aqDisplayShow)
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
                aqDisplayShow.InteractiveGraphics.Add(lineSegment, "AAA 11111", true);
            }
            st.Stop();
            aqDisplayShow.Update();
//             for(int i = 0; i<countPointList.Length; i++)
//             {
//                 listBox1.Items.Add(string.Format("{0}, {1}", centerX[i], centerY[i]));
//             }
            //MessageBox.Show(string.Format("{0},{1},{2} ",st.Elapsed, st.ElapsedMilliseconds, iPointList));//fortest
        }

        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "shm file(*.shm)|*.shm";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelFilePath = fileDialog.FileName;
                m_Location.SaveModel(fileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AqLineSegment line = new AqLineSegment();
            line.StartX = 2092 - 20;
            line.StartY = 1151;
            line.EndX = 2092 + 20;
            line.EndY = 1151;

            AqLineSegment line2 = new AqLineSegment();
            line2.StartX = 2092;
            line2.StartY = 1151 - 20;
            line2.EndX = 2092;
            line2.EndY = 1151 + 20;

            aqDisplayCreateModel.InteractiveGraphics.Add(line,"a",false);
            aqDisplayCreateModel.InteractiveGraphics.Add(line2,"b",false);
            aqDisplayCreateModel.Update();
        }

        private void buttonLoadModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelFilePath = fileDialog.FileName;
                m_Location.LoadModel(ModelFilePath);
            }
        }
    }
}
