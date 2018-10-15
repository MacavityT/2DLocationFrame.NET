using AqVision;
using AqVision.Controls;
using AqVision.Shape;
using IntegrationTesting.Tool;
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
        AqVision.Location.AqLocationPattern _location = new AqVision.Location.AqLocationPattern();

        internal AqVision.Location.AqLocationPattern Location1
        {
            get { return _location; }
            set { _location = value; }
        }
        string m_title = null;
        private double[] m_locationResultPosX = null;
        public double[] LocationResultPosX
        {
            get { return m_locationResultPosX; }
            set { m_locationResultPosX = value; }
        }

        public double[] Score
        {
            get { return _location.Score; }
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
                _location.OriginImage = ImageInput.Clone() as Bitmap;
            }
        }

        string m_modelFilePath = null;
        public string ModelFilePath
        {
            get { return m_modelFilePath; }
            set { m_modelFilePath = value; }
        }

        double _roiLTX = 0;
        public double ROILTX
        {
            get { return _roiLTX; }
            set { _roiLTX = value; }
        }

        double _roiLTY = 0;
        public double ROILTY
        {
            get { return _roiLTY; }
            set { _roiLTY = value; }
        }

        double _roiRBX = 0;
        public double ROIRBX
        {
            get { return _roiRBX; }
            set { _roiRBX = value; }
        }

        double _roiRBY = 0;
        public double ROIRBY
        {
            get { return _roiRBY; }
            set { _roiRBY = value; }
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
            if (isCreateROIHorVerRectangle())
            {
                buttonTraining.Visible = true;
            }
            else
            {
                VisionControls(false);
            }
        }

        private void VisionControls(bool bShow)
        {
            buttonTraining.Visible = bShow;
            buttonLocation.Visible = bShow;
            buttonSaveModel.Visible = bShow;
        }
        private void buttonTraining_Click(object sender, EventArgs e)
        {
            try
            {
                _location.OriginImage = aqDisplayCreateModel.Image;
                int index = aqDisplayCreateModel.InteractiveGraphics.FindItem("ROI_Region_Create_Model", AqDisplayZOrderConstants.Back);
                _location.RoiRegionTemplate = (AqRectangleAffine)(aqDisplayCreateModel.InteractiveGraphics[index]);
                ROILTX = _location.RoiRegionTemplate.LeftTopPointX;
                ROILTY = _location.RoiRegionTemplate.LeftTopPointY;
                ROIRBX = _location.RoiRegionTemplate.RightBottomX;
                ROIRBY = _location.RoiRegionTemplate.RightBottomY;

                _location.CreateTempateImage(@"D:\Bitmap.bmp");
                if (_location.CreateModel())
                {
                    //保存横线和竖线
                    index = aqDisplayCreateModel.InteractiveGraphics.FindItem("Find_Line_Hor",AqDisplayZOrderConstants.Front);
                    AqRectangleAffine rectangle = (AqRectangleAffine)(aqDisplayCreateModel.InteractiveGraphics[index]);
                    _location.LeftTopLineHorX = rectangle.LeftTopPointX;
                    _location.LeftTopLineHorY = rectangle.LeftTopPointY;
                    _location.RightBottomLineHorX = rectangle.RightBottomX;
                    _location.RightBottomLineHorY = rectangle.RightBottomY;

                    index = aqDisplayCreateModel.InteractiveGraphics.FindItem("Find_Line_Ver", AqDisplayZOrderConstants.Front);
                    rectangle = (AqRectangleAffine)(aqDisplayCreateModel.InteractiveGraphics[index]);
                    _location.LeftTopLineVerX = rectangle.LeftTopPointX;
                    _location.LeftTopLineVerY = rectangle.LeftTopPointY;
                    _location.RightBottomLineVerX = rectangle.RightBottomX;
                    _location.RightBottomLineVerY = rectangle.RightBottomY;

                    index = aqDisplayCreateModel.InteractiveGraphics.FindItem("Circle", AqDisplayZOrderConstants.Front);
                    AqCircularArc circle = (AqCircularArc)(aqDisplayCreateModel.InteractiveGraphics[index]);
                    _location.ModelCircleCenterX = circle.CenterPoint.X;
                    _location.ModelCircleCenterY = circle.CenterPoint.Y;
                    _location.ModelCircleRadius = circle.Radius;

                    SaveModelParam();
                    ShowGetContourData(_location.ModeXldColsM, _location.ModeXldRowsM, _location.ModeXldPointCountsM, AqColorConstants.Blue, aqDisplayCreateModel);
                    ShowCenterCross(_location.ModelCenterX, _location.ModelCenterY);
                    ShowCenterCross(_location.ModelCircleCenterX, _location.ModelCircleCenterY); //圆心
                    aqDisplayCreateModel.Update();
                    MessageBox.Show("create Model success");

                    buttonSaveModel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddRectangleRegion_Click(object sender, EventArgs e)
        {
            AddRectangelToAqDisplay("ROI_Region_Create_Model", AqColorConstants.Magenta);
        }

        private void buttonLocation_Click(object sender, EventArgs e)
        {
            try
            {
                aqDisplayCreateModel.InteractiveGraphics.Clear();
                aqDisplayCreateModel.Update();
                if (RunMatcher(ModelFilePath) == 0)
                {
                    ShowGetContourData(_location.XldColsM, _location.XldRowsM, _location.XldPointCountsM, AqColorConstants.Green, aqDisplayCreateModel);
                    ShowIntersectionHorVerLine();
                    textBox1.Text = LocationResultPosX[0].ToString("0.000");
                    textBox2.Text = LocationResultPosY[0].ToString("0.000");
                    textBox3.Text = (LocationResultPosTheta[0] / Math.PI * 180).ToString("0.000");
                    ShowCenterCross(LocationResultPosX[0], LocationResultPosY[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveModelParam()
        {
            IniFile.WriteValue("TemplateParam", "FindLineHorRectangelLTX", _location.LeftTopLineHorX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineHorRectangelLTY", _location.LeftTopLineHorY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineHorRectangelRBX", _location.RightBottomLineHorX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineHorRectangelRBY", _location.RightBottomLineHorY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineVerRectangelLTX", _location.LeftTopLineVerX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineVerRectangelLTY", _location.LeftTopLineVerY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineVerRectangelRBX", _location.RightBottomLineVerX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "FindLineVerRectangelRBY", _location.RightBottomLineVerY.ToString("f3"));

            IniFile.WriteValue("TemplateParam", "ModelCenterX", _location.ModelCenterX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ModelCenterY", _location.ModelCenterY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ModelAngle", _location.ModelAngle.ToString("f3"));

            IniFile.WriteValue("TemplateParam", "ROILTX", ROILTX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ROILTY", ROILTY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ROIRBX", ROIRBX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ROIRBY", ROIRBY.ToString("f3"));

            IniFile.WriteValue("TemplateParam", "ModelCircleCenterX", _location.ModelCircleCenterX.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ModelCircleCenterY", _location.ModelCircleCenterY.ToString("f3"));
            IniFile.WriteValue("TemplateParam", "ModelCircleCenterRadius", _location.ModelCircleRadius.ToString("f3"));
        }

        private void LoadModelParam()
        {
            string strValue;
            strValue = IniFile.ReadValue("TemplateParam", "ROILTX", "0.00");
            ROILTX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ROILTY", "0.00");
            ROILTY = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ROIRBX", "0.00");
            ROIRBX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ROIRBY", "0.00");
            ROIRBY = Convert.ToDouble(strValue);

            strValue = IniFile.ReadValue("TemplateParam", "FindLineHorRectangelLTX", "0.00");
            _location.LeftTopLineHorX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineHorRectangelLTY", "0.00");
            _location.LeftTopLineHorY = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineHorRectangelRBX", "0.00");
            _location.RightBottomLineHorX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineHorRectangelRBY", "0.00");
            _location.RightBottomLineHorY = Convert.ToDouble(strValue);

            strValue = IniFile.ReadValue("TemplateParam", "FindLineVerRectangelLTX", "0.00");
            _location.LeftTopLineVerX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineVerRectangelLTY", "0.00");
            _location.LeftTopLineVerY = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineVerRectangelRBX", "0.00");
            _location.RightBottomLineVerX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "FindLineVerRectangelRBY", "0.00");
            _location.RightBottomLineVerY = Convert.ToDouble(strValue);

            strValue = IniFile.ReadValue("TemplateParam", "ModelCenterX", "0.00");
            _location.ModelCenterX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ModelCenterY", "0.00");
            _location.ModelCenterY = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ModelAngle", "0.00");
            _location.ModelAngle = Convert.ToDouble(strValue);


            strValue = IniFile.ReadValue("TemplateParam", "ModelCircleCenterX", "0.00");
            _location.ModelCircleCenterX = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ModelCircleCenterY", "0.00");
            _location.ModelCircleCenterY = Convert.ToDouble(strValue);
            strValue = IniFile.ReadValue("TemplateParam", "ModelCircleCenterRadius", "0.00");
            _location.ModelCircleRadius = Convert.ToDouble(strValue);
        }
        public int RunMatcher(string modeFilePath)
        {
            int iResult = -1;
            try
            {
                _location.LoadModel(modeFilePath);
                LoadModelParam();

                if (_location.RunMatcherByHalcon())
                {
                    if (_location.XldPointCountsM.Length > 0)
                    {
                        iResult = 0;
                    }
                    else
                    {
                        iResult = -2;
                    }
                    if (iResult == 0)
                    {
                        _location.CalHorVerLineIntersection();
//                         LocationResultPosX = new double[1] { _location.IntersectionX };
//                         LocationResultPosY = new double[1] { _location.IntersectionY };
//                         LocationResultPosTheta = new double[1] { _location.IntersectionAngle };
//                         LocationResultPosX = _location.CenterX;
//                         LocationResultPosY = _location.CenterY;
//                         LocationResultPosTheta = _location.Angle;
                        _location.GetCircleCenter();
                        LocationResultPosX = new double[1] { _location.CircleCenterX };
                        LocationResultPosY = new double[1] { _location.CircleCenterY };
                        LocationResultPosTheta = new double[1] { _location.IntersectionAngle };
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                iResult = -1;
            }
            return iResult;
        }

        public void ShowGetResultsData(AqColorConstants color, AqDisplay aqDisplayShow)
        {
            ShowGetContourData(_location.XldColsM, _location.XldRowsM, _location.XldPointCountsM, color, aqDisplayShow);
        }

        private void ShowCenterCross(double centerX, double centerY)
        {
            AqLineSegment line = new AqLineSegment();
            line.StartX = centerX - 20;
            line.StartY = centerY;
            line.EndX = centerX + 20;
            line.EndY = centerY;
            line.Color = AqColorConstants.Red;
            line.LineWidthInScreenPixels = 5;

            AqLineSegment line2 = new AqLineSegment();
            line2.StartX = centerX;
            line2.StartY = centerY - 20;
            line2.EndX = centerX;
            line2.EndY = centerY + 20;
            line2.Color = AqColorConstants.Red;
            line2.LineWidthInScreenPixels = 5;

            aqDisplayCreateModel.InteractiveGraphics.Add(line, "LineHor", false);
            aqDisplayCreateModel.InteractiveGraphics.Add(line2, "LineVer", false);
            aqDisplayCreateModel.Update();
        }
        private void ShowGetContourData(double[] xPointList, double[] yPointList, long[] countPointList, AqColorConstants color, AqDisplay aqDisplayShow)
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

            //MessageBox.Show(string.Format("{0},{1},{2} ",st.Elapsed, st.ElapsedMilliseconds, iPointList));//fortest
        }

        private void ShowIntersectionHorVerLine()
        {
            ShowCenterCross(_location.IntersectionX, _location.IntersectionY);

            AqLineSegment line = new AqLineSegment();
            line.StartX = _location.LineLeftCol1;
            line.StartY = _location.LineLeftRow1;
            line.EndX = _location.LineLeftCol2;
            line.EndY = _location.LineLeftRow2;
            line.Color = AqColorConstants.Red;
            line.LineWidthInScreenPixels = 5;

            AqLineSegment line2 = new AqLineSegment();
            line2.StartX = _location.LineUpCol1;
            line2.StartY = _location.LineUpRow1;
            line2.EndX = _location.LineUpCol2;
            line2.EndY = _location.LineUpRow2;
            line2.Color = AqColorConstants.Red;
            line2.LineWidthInScreenPixels = 5;
            
            aqDisplayCreateModel.InteractiveGraphics.Add(line, "LineHor", false);
            aqDisplayCreateModel.InteractiveGraphics.Add(line2, "LineVer", false);
        }
        private void buttonSaveModel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "shm file(*.shm)|*.shm";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelFilePath = fileDialog.FileName;
                _location.SaveModel(fileDialog.FileName);
                SaveModelParam();
                buttonLocation.Visible = true;
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
            fileDialog.Filter = "shm file(*.shm)|*.shm";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                aqDisplayCreateModel.InteractiveGraphics.Clear();
                ModelFilePath = fileDialog.FileName;
                _location.LoadModel(ModelFilePath);
                LoadModelParam();
                AddRectangelToAqDisplay("ROI_Region_Create_Model", AqColorConstants.Magenta,ROILTX, ROILTY, ROIRBX, ROIRBY);
                AddRectangelToAqDisplay("Find_Line_Hor", AqColorConstants.Orange,_location.LeftTopLineHorX, _location.LeftTopLineHorY,
                                        _location.RightBottomLineHorX, _location.RightBottomLineHorY);
                AddRectangelToAqDisplay("Find_Line_Ver", AqColorConstants.Green,_location.LeftTopLineVerX, _location.LeftTopLineVerY,
                                        _location.RightBottomLineVerX, _location.RightBottomLineVerY);
                AqGdiPointF leftTopPoint = new AqGdiPointF((float)(_location.ModelCircleCenterX - _location.ModelCircleRadius),
                                                            (float)(_location.ModelCircleCenterY - _location.ModelCircleRadius));
                AqGdiPointF rightBottomPoint = new AqGdiPointF((float)(_location.ModelCircleCenterX + _location.ModelCircleRadius),
                                                            (float)(_location.ModelCircleCenterY + _location.ModelCircleRadius));
                AqCircularArc arc = new AqCircularArc(leftTopPoint, rightBottomPoint, 0, 360);
                arc.Color = AqColorConstants.Cyan;
                arc.LineWidthInScreenPixels = 5;
                aqDisplayCreateModel.InteractiveGraphics.Add(arc, "Circle", true);
                aqDisplayCreateModel.Update();
            }
        }

        private void buttonLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "bmp file(*.bmp)|*.bmp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string picPath = fileDialog.FileName;
                aqDisplayCreateModel.Image = Image.FromFile(picPath) as Bitmap;
                this.Text = picPath;
                aqDisplayCreateModel.FitToScreen();
                ImageInput = aqDisplayCreateModel.Image.Clone() as Bitmap;
            }
            aqDisplayCreateModel.InteractiveGraphics.Clear();
            aqDisplayCreateModel.Update();
        }


        private bool isCreateROIHorVerRectangle()
        {
            if ((aqDisplayCreateModel.InteractiveGraphics.FindItem("Find_Line_Hor", AqDisplayZOrderConstants.Back) >= 0) &&
                (aqDisplayCreateModel.InteractiveGraphics.FindItem("Find_Line_Ver", AqDisplayZOrderConstants.Back) >= 0) &&
                (aqDisplayCreateModel.InteractiveGraphics.FindItem("ROI_Region_Create_Model", AqDisplayZOrderConstants.Back) >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddRectangelToAqDisplay(string rectangleName, AqColorConstants color, double leftTopX,
                                                double leftTopY, double rightBottomX, double rightBottomY)
        {
            if (Math.Abs(leftTopX - rightBottomX) < 0.0001 &&
                Math.Abs(leftTopY - rightBottomY) < 0.0001)
            {
                leftTopX = 120;
                leftTopY = 120;
                rightBottomX = 300;
                rightBottomY = 300;
            }

            try
            {
                if (aqDisplayCreateModel.InteractiveGraphics.FindItem(rectangleName, AqDisplayZOrderConstants.Back) < 0)
                {
                    AqRectangleAffine rectangle = new AqRectangleAffine();
                    rectangle.LeftTopPointX = leftTopX;
                    rectangle.LeftTopPointY = leftTopY;
                    rectangle.RightBottomX = rightBottomX;
                    rectangle.RightBottomY = rightBottomY;
                    rectangle.Color = color;
                    rectangle.LineWidthInScreenPixels = 5;
                    aqDisplayCreateModel.InteractiveGraphics.Add(rectangle, rectangleName, true);
                    aqDisplayCreateModel.Update();
                }
                if (isCreateROIHorVerRectangle())
                {
                    buttonTraining.Visible = true;
                }
                else
                {
                    //VisionControls(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddRectangelToAqDisplay(string rectangleName, AqColorConstants color)
        {
            AddRectangelToAqDisplay(rectangleName, color, 120, 120, 300, 300);
        }
        private void buttonAddHorZone_Click(object sender, EventArgs e)
        {
            AddRectangelToAqDisplay("Find_Line_Hor", AqColorConstants.Orange);
        }

        private void buttonAddVerZone_Click(object sender, EventArgs e)
        {
            AddRectangelToAqDisplay("Find_Line_Ver",AqColorConstants.Green);
        }

        private void buttonCircleZone_Click(object sender, EventArgs e)
        {
            int index = aqDisplayCreateModel.InteractiveGraphics.FindItem("Circle", AqDisplayZOrderConstants.Front);
            if (index < 0)
            {
                AqGdiPointF leftTopPoint = new AqGdiPointF(120, 120);
                AqGdiPointF rightBottomPoint = new AqGdiPointF(300, 300);
                AqCircularArc arc = new AqCircularArc(leftTopPoint, rightBottomPoint, 0, 360);
                arc.Color = AqColorConstants.Cyan;
                arc.LineWidthInScreenPixels = 5;
                aqDisplayCreateModel.InteractiveGraphics.Add(arc, "Circle", true);
                aqDisplayCreateModel.Update();
            }
        }

        private void buttonUpdateCircle_Click(object sender, EventArgs e)
        {
            int index = aqDisplayCreateModel.InteractiveGraphics.FindItem("Circle", AqDisplayZOrderConstants.Front);
            if (index >= 0)
            {
                AqCircularArc arc = (AqCircularArc)(aqDisplayCreateModel.InteractiveGraphics[index]);
                float leftTopX =(float)(arc.LeftTopPoint.X-(Convert.ToDouble(textBoxCircleWidth.Text)-(arc.RightBottomPoint.X-arc.LeftTopPoint.X))/2.0);
                float rightBottomX = (float)(arc.RightBottomPoint.X+(Convert.ToDouble(textBoxCircleWidth.Text)-(arc.RightBottomPoint.X-arc.LeftTopPoint.X))/2.0);

                float leftTopY = (float)(arc.LeftTopPoint.Y-(Convert.ToDouble(textBoxCircleHeight.Text)-(arc.RightBottomPoint.Y-arc.LeftTopPoint.Y))/2.0);
                float rightBottomY = (float)(arc.RightBottomPoint.Y+(Convert.ToDouble(textBoxCircleHeight.Text)-(arc.RightBottomPoint.Y-arc.LeftTopPoint.Y))/2.0);

                AqGdiPointF leftTopPoint = new AqGdiPointF(leftTopX, leftTopY);
                AqGdiPointF rightBottomPoint = new AqGdiPointF(rightBottomX, rightBottomY);

                aqDisplayCreateModel.InteractiveGraphics.Remove(index);

                AqCircularArc arcNew = new AqCircularArc(leftTopPoint, rightBottomPoint, 0, 360);
                arcNew.Color = AqColorConstants.Cyan;
                arcNew.LineWidthInScreenPixels = 5;
                aqDisplayCreateModel.InteractiveGraphics.Add(arcNew, "Circle", true);
                aqDisplayCreateModel.Update();
                
            }
        }
    }
}
