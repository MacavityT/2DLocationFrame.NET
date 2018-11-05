using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using HalconDotNet;

namespace AqVision.Location
{
    class AqLocationPattern
    {
        Bitmap m_OriginImage = null;
        public Bitmap OriginImage
        {
            get { return m_OriginImage; }
            set { m_OriginImage = value; }
        }

        double m_angleStart = -180;
        public double AngleStart
        {
          get { return m_angleStart; }
          set { m_angleStart = value; }
        }

        double m_angleExtent = 360;
        public double AngleExtent
        {
          get { return m_angleExtent; }
          set { m_angleExtent = value; }
        }

        double m_angleStep = 0.6955;
        public double AngleStep
        {
            get { return m_angleStep; }
            set { m_angleStep = value; }
        }

        int m_imageRow = 100;
        public int ImageRow
        {
            get { return (int)(RoiRegionTemplate.RightBottomY - RoiRegionTemplate.LeftTopPointY); }
          set { m_imageRow = value; }
        }

        int m_imageColumn = 100;
        public int ImageColumn
        {
            get { return (int)(RoiRegionTemplate.RightBottomX - RoiRegionTemplate.LeftTopPointX); }
          set { m_imageColumn = value; }
        }

        int m_numLevels = 5;
        public int NumLevels
        {
          get { return m_numLevels; }
          set { m_numLevels = value; }
        }

        double m_scaleMin = 0.96;
        public double ScaleMin
        {
          get { return m_scaleMin; }
          set { m_scaleMin = value; }
        }

        double m_scaleMax = 1.04;
        public double ScaleMax
        {
          get { return m_scaleMax; }
          set { m_scaleMax = value; }
        }

        int m_minContrast = 20;
        public int MinContrast
        {
          get { return m_minContrast; }
          set { m_minContrast = value; }
        }

        int m_maxContrast = 40;
        public int MaxContrast
        {
          get { return m_maxContrast; }
          set { m_maxContrast = value; }
        }

        double m_minLength = 24;
        public double MinLength
        {
          get { return m_minLength; }
          set { m_minLength = value; }
        }

        double m_minScore = 0.5;
        public double MinScore
        {
          get { return m_minScore; }
          set { m_minScore = value; }
        }

        double m_numMatches = 0;
        public double NumMatches
        {
          get { return m_numMatches; }
          set { m_numMatches = value; }
        }

        HTuple m_modelID;
        public HTuple ModelID
        {
          get { return m_modelID; }
          set { m_modelID = value; }
        }

        double[] m_xldRowsM;
        public double[] XldRowsM
        {
            get { return m_xldRowsM; }
            set { m_xldRowsM = value; }
        }

        double[] m_modeXldRowsM;
        public double[] ModeXldRowsM
        {
            get { return m_modeXldRowsM; }
            set { m_modeXldRowsM = value; }
        }

        double[] m_xldColsM;
        public double[] XldColsM
        {
            get { return m_xldColsM; }
            set { m_xldColsM = value; }
        }

        double[] m_modeXldColsM;
        public double[] ModeXldColsM
        {
            get { return m_modeXldColsM; }
            set { m_modeXldColsM = value; }
        }

        long[] m_xldPointCountsM;
        public long[] XldPointCountsM
        {
            get { return m_xldPointCountsM; }
            set { m_xldPointCountsM = value; }
        }

        long[] m_modexldPointCountsM;
        public long[] ModeXldPointCountsM
        {
            get { return m_modexldPointCountsM; }
            set { m_modexldPointCountsM = value; }
        }

        double m_modelCenterX = 0;
        public double ModelCenterX
        {
            get { return m_modelCenterX; }
            set { m_modelCenterX = value; }
        }

        double[] m_centerX = null;
        public double[] CenterX
        {
            get { return m_centerX; }
            set { m_centerX = value; }
        }

        double m_modelCenterY = 0;
        public double ModelCenterY
        {
            get { return m_modelCenterY; }
            set { m_modelCenterY = value; }
        }

        double[] m_centerY = null;
        public double[] CenterY
        {
            get { return m_centerY; }
            set { m_centerY = value; }
        }

        double m_modelAngle = 0;
        public double ModelAngle
        {
            get { return m_modelAngle; }
            set { m_modelAngle = value; }
        }

        double[] m_angle = null;
        public double[] Angle
        {
            get { return m_angle; }
            set { m_angle = value; }
        }

        double m_modelScale = 1;
        public double ModelScale
        {
            get { return m_modelScale; }
            set { m_modelScale = value; }
        }

        double[] m_scale = null;
        public double[] Scale
        {
            get { return m_scale; }
            set { m_scale = value; }
        }

        double[] m_score = null;
        public double[] Score
        {
            get { return m_score; }
            set { m_score = value; }
        }

        public int FindObjectCount
        {
            get { return Angle.Length; }
        }


        private string m_TemplatePath = "";
        public string TemplatePath
        {
            get { return m_TemplatePath; }
            set { m_TemplatePath = value; }
        }

        private double _leftTopLineHorX;
        public double LeftTopLineHorX
        {
            get { return _leftTopLineHorX; }
            set { _leftTopLineHorX = value; }
        }

        private double _leftTopLineHorY;
        public double LeftTopLineHorY
        {
            get { return _leftTopLineHorY; }
            set { _leftTopLineHorY = value; }
        }

        private double _rightBottomLineHorX;
        public double RightBottomLineHorX
        {
            get { return _rightBottomLineHorX; }
            set { _rightBottomLineHorX = value; }
        }

        private double _rightBottomLineHorY;
        public double RightBottomLineHorY
        {
            get { return _rightBottomLineHorY; }
            set { _rightBottomLineHorY = value; }
        }

        private double _leftTopLineVerX;
        public double LeftTopLineVerX
        {
            get { return _leftTopLineVerX; }
            set { _leftTopLineVerX = value; }
        }

        private double _leftTopLineVerY;
        public double LeftTopLineVerY
        {
            get { return _leftTopLineVerY; }
            set { _leftTopLineVerY = value; }
        }

        private double _rightBottomLineVerX;
        public double RightBottomLineVerX
        {
            get { return _rightBottomLineVerX; }
            set { _rightBottomLineVerX = value; }
        }

        private double _rightBottomLineVerY;
        public double RightBottomLineVerY
        {
            get { return _rightBottomLineVerY; }
            set { _rightBottomLineVerY = value; }
        }

        double _circleCenterX = 0;
        public double CircleCenterX
        {
            get { return _circleCenterX; }
            set { _circleCenterX = value; }
        }

        double _circleCenterY = 0;
        public double CircleCenterY
        {
            get { return _circleCenterY; }
            set { _circleCenterY = value; }
        }

        double _circleCenterAngle = 0;  //双圆角度
        public double CircleCenterAngle
        {
            get { return _circleCenterAngle; }
            set { _circleCenterAngle = value; }
        }

        double _circleRadius = 0;
        public double CircleRadius
        {
            get { return _circleRadius; }
            set { _circleRadius = value; }
        }

        double _modelCircleCenterX = 0;

        public double ModelCircleCenterX
        {
            get { return _modelCircleCenterX; }
            set { _modelCircleCenterX = value; }
        }

        double _modelCircleCenterY = 0;

        public double ModelCircleCenterY
        {
            get { return _modelCircleCenterY; }
            set { _modelCircleCenterY = value; }
        }

        double _modelCircleRadius = 0;

        public double ModelCircleRadius
        {
            get { return _modelCircleRadius; }
            set { _modelCircleRadius = value; }
        }


        double _modelCircleCenterX2 = 0;

        public double ModelCircleCenterX2
        {
            get { return _modelCircleCenterX2; }
            set { _modelCircleCenterX2 = value; }
        }

        double _modelCircleCenterY2 = 0;

        public double ModelCircleCenterY2
        {
            get { return _modelCircleCenterY2; }
            set { _modelCircleCenterY2 = value; }
        }

        double _modelCircleRadius2 = 0;

        public double ModelCircleRadius2
        {
            get { return _modelCircleRadius2; }
            set { _modelCircleRadius2 = value; }
        }

        private double _intersectionX;
        public double IntersectionX
        {
            get { return _intersectionX; }
            set { _intersectionX = value; }
        }

        private double _intersectionY;
        public double IntersectionY
        {
            get { return _intersectionY; }
            set { _intersectionY = value; }
        }

        private double _intersectionAngle;
        public double IntersectionAngle
        {
            get { return _intersectionAngle; }
            set { _intersectionAngle = value; }
        }

        private AqVision.Shape.AqRectangleAffine m_RoiRegionTemplate = new Shape.AqRectangleAffine();
        public AqVision.Shape.AqRectangleAffine RoiRegionTemplate
        {
            get { return m_RoiRegionTemplate; }
            set 
            { 
                m_RoiRegionTemplate = value;
                m_TemplateRegionCenter.X = (int)(((int)(m_RoiRegionTemplate.LeftTopPointX)) + ((int)(m_RoiRegionTemplate.RightBottomX)) / 2);
                m_TemplateRegionCenter.Y = (int)(((int)(m_RoiRegionTemplate.LeftTopPointY)) + ((int)(m_RoiRegionTemplate.RightBottomY)) / 2);
            }
        }
        
        private Point m_TemplateRegionCenter = new Point();
        public Point TemplateRegionCenter
        {
            get { return m_TemplateRegionCenter; }
            set { m_TemplateRegionCenter = value; }
        }

        private Point m_CenterResult = new Point();
        public Point CenterResult
        {
            get { return m_CenterResult; }
            set { m_CenterResult = value; }
        }

        private int m_ResultX = 0;
        public int ResultX
        {
            get { return m_ResultX; }
            set { m_ResultX = value; }
        }

        private int m_ResultY = 0;
        public int ResultY
        {
            get { return m_ResultY; }
            set { m_ResultY = value; }
        }

        private string m_ResultAngle = null;
        public string ResultAngle
        {
            get { return m_ResultAngle; }
            set { m_ResultAngle = value; }
        }

        private int m_matherState = 0;
        public bool MatherResult
        {
            get
            {
                if(m_matherState == 1)
                    return true;
                else
                    return false;
            }
        }


        private double _lineLeftRow1;
        public double LineLeftRow1
        {
            get { return _lineLeftRow1; }
            set { _lineLeftRow1 = value; }
        }

        private double _lineLeftCol1;
        public double LineLeftCol1
        {
            get { return _lineLeftCol1; }
            set { _lineLeftCol1 = value; }
        }

        private double _lineLeftRow2;
        public double LineLeftRow2
        {
            get { return _lineLeftRow2; }
            set { _lineLeftRow2 = value; }
        }

        private double _lineLeftCol2;
        public double LineLeftCol2
        {
            get { return _lineLeftCol2; }
            set { _lineLeftCol2 = value; }
        }

        private double _lineUpRow1;
        public double LineUpRow1
        {
            get { return _lineUpRow1; }
            set { _lineUpRow1 = value; }
        }

        private double _lineUpCol1;
        public double LineUpCol1
        {
            get { return _lineUpCol1; }
            set { _lineUpCol1 = value; }
        }

        private double _lineUpRow2;
        public double LineUpRow2
        {
            get { return _lineUpRow2; }
            set { _lineUpRow2 = value; }
        }

        private double _lineUpCol2;
        public double LineUpCol2
        {
            get { return _lineUpCol2; }
            set { _lineUpCol2 = value; }
        }

        public bool CreateTempateImage(string createPath)
        {
            if (File.Exists(createPath))
            {
                File.Delete(createPath);
            }
            Image originImage = Image.FromHbitmap(m_OriginImage.GetHbitmap());

            ImageRow = (int)(RoiRegionTemplate.RightBottomY-RoiRegionTemplate.LeftTopPointY);
            ImageColumn = (int)(RoiRegionTemplate.RightBottomX-RoiRegionTemplate.LeftTopPointX);

            Bitmap bitmap = new Bitmap(ImageColumn, ImageRow);

            Graphics gTemplate = Graphics.FromImage(bitmap);
            gTemplate.DrawImage(originImage, 0, 0, new Rectangle((int)(m_RoiRegionTemplate.LeftTopPointX), (int)(m_RoiRegionTemplate.LeftTopPointY),
                                           ImageColumn, ImageRow),System.Drawing.GraphicsUnit.Pixel);
            bitmap.Save(createPath, System.Drawing.Imaging.ImageFormat.Bmp);
            gTemplate.Dispose();
            bitmap.Dispose();
            return true;
        }

        #region CIDI
        public bool RunMatcher()
        {
            char[] angle = new char[500];
            AqVision.Interaction.UI2LibInterface.GetImageSpecificLocation1(m_TemplateRegionCenter.X, m_TemplateRegionCenter.Y,
                                                                           (int)(m_RoiRegionTemplate.LeftTopPointX),
                                                                           (int)(m_RoiRegionTemplate.LeftTopPointY),
                                           (int)(RoiRegionTemplate.RightBottomX-RoiRegionTemplate.LeftTopPointX),
                                           (int)(RoiRegionTemplate.RightBottomY-RoiRegionTemplate.LeftTopPointY),
                                                                           m_TemplatePath,
                                                                           ref m_matherState,
                                                                           ref m_ResultX,  ref m_ResultY,
                                                                           angle);

            
            m_ResultAngle = new string(angle);
            return MatherResult;
        }
        #endregion

        public bool CreateModel()
        {
            HTuple rows = new HTuple();
            rows[0] = (int)(m_RoiRegionTemplate.LeftTopPointY);
            rows[1] = (int)(m_RoiRegionTemplate.RightBottomY);
            rows[2] = (int)(m_RoiRegionTemplate.RightBottomY);
            rows[3] = (int)(m_RoiRegionTemplate.LeftTopPointY);
            rows[4] = (int)(m_RoiRegionTemplate.LeftTopPointY);

            int[] cols = new int[5];
            cols[0] = (int)(m_RoiRegionTemplate.LeftTopPointX);
            cols[1] = (int)(m_RoiRegionTemplate.LeftTopPointX);
            cols[2] = (int)(m_RoiRegionTemplate.RightBottomX);
            cols[3] = (int)(m_RoiRegionTemplate.RightBottomX);
            cols[4] = (int)(m_RoiRegionTemplate.LeftTopPointX);
            HTuple rowSource = new HTuple();
            HTuple columnSource = new HTuple();
            HTuple angleSource = new HTuple();
            HTuple modeXldRows = new HTuple();
            HTuple modeXldCols = new HTuple();
            HTuple modeXldPointCounts = new HTuple();
            HImage image = null;
            if (m_TemplatePath.Length == 0)
            {
                image = ApplyHalcon.ImageConvert.Bitmap2HImage_24(OriginImage);
            }
            else
            {
                image = new HImage(m_TemplatePath);
            }

            ApplyHalcon.FindModel.CreateFeatureModel(image, new HTuple(rows), new HTuple(cols),
                                                    new HTuple(NumLevels), new HTuple(AngleStart), new HTuple(AngleExtent), new HTuple(AngleStep),
                                                    new HTuple(ScaleMin), new HTuple(ScaleMax), new HTuple(MinContrast), new HTuple(MaxContrast),
                                                    new HTuple(MinLength), out m_modelID, out rowSource, out columnSource,
                                                    out angleSource, out modeXldRows, out modeXldCols, out modeXldPointCounts);
            ModelAngle = angleSource.D;
            ModelCenterX = columnSource.D;
            ModelCenterY = rowSource.D;
            ModeXldPointCountsM = modeXldPointCounts.LArr;
            ModeXldColsM = modeXldCols.DArr;
            ModeXldRowsM = modeXldRows.DArr;
            return true;

        }

        public bool RunMatcherByHalcon()
        {
            HTuple xldRowsM = new HTuple();
            HTuple xldColsM = new HTuple();
            HTuple xldPointCountsM = new HTuple();
            HTuple row = new HTuple();
            HTuple column = new HTuple();
            HTuple angle = new HTuple();
            HTuple scale = new HTuple();
            HTuple score = new HTuple();
            HImage image = null;
            if(m_TemplatePath.Length == 0)
            {
                image = ApplyHalcon.ImageConvert.Bitmap2HImage_24(OriginImage);
            }
            else
            {
                image = new HImage(m_TemplatePath);
            }


            ApplyHalcon.FindModel.FindFeatureModel(image, new HTuple(AngleStart), new HTuple(AngleExtent),
                                        new HTuple(AngleStep), new HTuple(ScaleMin), new HTuple(ScaleMax), new HTuple(MinScore),
                                        new HTuple(NumMatches), m_modelID, out xldRowsM, out xldColsM,
                                        out xldPointCountsM, out row, out column,
                                        out angle, out scale, out score);

            if(score.Length == 0)
            {
                return false;
            }
            Score = score.DArr;
            Scale = scale.DArr;
            Angle = angle.DArr;
            CenterX = column.DArr;
            CenterY = row.DArr;
            XldPointCountsM = xldPointCountsM.LArr;
            XldColsM = xldColsM.DArr;
            XldRowsM = xldRowsM.DArr;

            image.Dispose();//1061.388
            return true;
        }

        public bool GetSingleCircleCenter()
        {
            HObject ho_Circle, ho_Cross = null;
            HObject ho_PartCircleXLD = null, ho_Regions = null;

            HImage image = null;
            if (m_TemplatePath.Length == 0)
            {
                image = ApplyHalcon.ImageConvert.Bitmap2HImage_24(OriginImage);
            }
            else
            {
                image = new HImage(m_TemplatePath);
            }

            HTuple hv_RowCenter = new HTuple();
            HTuple hv_ColCenter = new HTuple();
            HTuple hv_Radius = new HTuple();
            HTuple hv_RowCenter2 = new HTuple();
            HTuple hv_ColCenter2 = new HTuple();
            HTuple hv_Radius2 = new HTuple();
            HTuple hv_Phi = new HTuple();

            ApplyHalcon.FindModel.detect_circle(image, out ho_PartCircleXLD, out ho_Regions, out ho_Cross,
                out ho_Circle, new HTuple(ModelCenterY), new HTuple(ModelCenterX), new HTuple(ModelAngle),
                  new HTuple(CenterY[0]), new HTuple(CenterX[0]), new HTuple(Angle[0]),
                  new HTuple(ModelCircleCenterY), new HTuple(ModelCircleCenterX), new HTuple(ModelCircleRadius),
                0, 360, 30, 100, 20, 1, 20, "positive", "first", "outer", 10, "circle",
                out hv_RowCenter, out hv_ColCenter, out hv_Radius);

            CircleCenterX = hv_ColCenter.D;
            CircleCenterY = hv_RowCenter.D;
            CircleRadius = hv_Radius.D;
            return true;
        }

        public bool GetDoubleCircleCenterAngle()
        {
            HObject ho_Circle, ho_Cross = null;
            HObject ho_PartCircleXLD = null, ho_Regions = null;

            HImage image = null;
            if (m_TemplatePath.Length == 0)
            {
                image = ApplyHalcon.ImageConvert.Bitmap2HImage_24(OriginImage);
            }
            else
            {
                image = new HImage(m_TemplatePath);
            }

            HTuple hv_RowCenter = new HTuple();
            HTuple hv_ColCenter = new HTuple();
            HTuple hv_Radius = new HTuple();
            HTuple hv_RowCenter2 = new HTuple();
            HTuple hv_ColCenter2 = new HTuple();
            HTuple hv_Radius2 = new HTuple();
            HTuple hv_Phi = new HTuple();

            ApplyHalcon.FindModel.detect_circle(image, out ho_PartCircleXLD, out ho_Regions, out ho_Cross,
                out ho_Circle, new HTuple(ModelCenterY), new HTuple(ModelCenterX), new HTuple(ModelAngle),
                  new HTuple(CenterY[0]), new HTuple(CenterX[0]), new HTuple(Angle[0]),
                  new HTuple(ModelCircleCenterY), new HTuple(ModelCircleCenterX), new HTuple(ModelCircleRadius),
                0, 360, 30, 100, 20, 1, 20, "positive", "first", "outer", 10, "circle",
                out hv_RowCenter, out hv_ColCenter, out hv_Radius);

            ApplyHalcon.FindModel.detect_circle(image, out ho_PartCircleXLD, out ho_Regions, out ho_Cross,
                            out ho_Circle, new HTuple(ModelCenterY), new HTuple(ModelCenterX), new HTuple(ModelAngle),
                              new HTuple(CenterY[0]), new HTuple(CenterX[0]), new HTuple(Angle[0]),
                              new HTuple(ModelCircleCenterY2), new HTuple(ModelCircleCenterX2), new HTuple(ModelCircleRadius2),
                            0, 360, 30, 100, 20, 1, 20, "positive", "first", "outer", 10, "circle",
                            out hv_RowCenter2, out hv_ColCenter2, out hv_Radius2);

            CircleCenterX = (hv_ColCenter.D + hv_ColCenter2.D) / 2.0;
            CircleCenterY = (hv_RowCenter.D + hv_RowCenter2.D) / 2.0;
            CircleRadius = (hv_Radius.D + hv_Radius2.D) / 2.0;

            HOperatorSet.TupleAtan2(hv_RowCenter - hv_RowCenter2, hv_ColCenter - hv_ColCenter2, out hv_Phi);
            CircleCenterAngle = hv_Phi.D;
            return true;
        }
        //按照只能定位一个图形处理
        public bool CalHorVerLineIntersection()
        {
            HTuple hv_LineLeftRow1 = new HTuple();
            HTuple hv_LineLeftCol1 = new HTuple();
            HTuple hv_LineLeftRow2 = new HTuple();
            HTuple hv_LineLeftCol2 = new HTuple();

            HTuple hv_LineUpRow1 = new HTuple();
            HTuple hv_LineUpCol1 = new HTuple();
            HTuple hv_LineUpRow2 = new HTuple();
            HTuple hv_LineUpCol2 = new HTuple();

            HTuple hv_RowCross = new HTuple();
            HTuple hv_ColCross = new HTuple();
            HTuple hv_Phi = new HTuple();
            HTuple hv_IsOverlapping = new HTuple();

            HImage image = null;
            if (m_TemplatePath.Length == 0)
            {
                image = ApplyHalcon.ImageConvert.Bitmap2HImage_24(OriginImage);
            }
            else
            {
                image = new HImage(m_TemplatePath);
            }

            ApplyHalcon.FindModel.detect_line(image, new HTuple(ModelCenterY), new HTuple(ModelCenterX), new HTuple(ModelAngle),
                  new HTuple(CenterY[0]), new HTuple(CenterX[0]), new HTuple(Angle[0]),
                  new HTuple(LeftTopLineVerY), new HTuple(LeftTopLineVerX), new HTuple(RightBottomLineVerY), new HTuple(RightBottomLineVerX),
                  30, "vertical", 3, 20, "negative", "first", out hv_LineLeftRow1, out hv_LineLeftCol1, out hv_LineLeftRow2,
                  out hv_LineLeftCol2);

            ApplyHalcon.FindModel.detect_line(image, new HTuple(ModelCenterY), new HTuple(ModelCenterX), new HTuple(ModelAngle),
                  new HTuple(CenterY[0]), new HTuple(CenterX[0]), new HTuple(Angle[0]),
                  new HTuple(LeftTopLineHorY), new HTuple(LeftTopLineHorX), new HTuple(RightBottomLineHorY), new HTuple(RightBottomLineHorX),
                  30, "horizontal", 3, 20, "positive", "last", out hv_LineUpRow1,
                         out hv_LineUpCol1, out hv_LineUpRow2, out hv_LineUpCol2);
  
            ApplyHalcon.FindModel.IntersetionPtAngle(hv_LineLeftRow1, hv_LineLeftCol1, hv_LineLeftRow2, hv_LineLeftCol2, 
                hv_LineUpRow1, hv_LineUpCol1, hv_LineUpRow2, hv_LineUpCol2,
                out hv_RowCross, out hv_ColCross, out hv_Phi, out hv_IsOverlapping);

            IntersectionX = hv_ColCross.D;
            IntersectionY = hv_RowCross.D;
            IntersectionAngle = hv_Phi;

            LineLeftRow1 = hv_LineLeftRow1;
            LineLeftCol1 = hv_LineLeftCol1;
            LineLeftRow2 = hv_LineLeftRow2;
            LineLeftCol2 = hv_LineLeftCol2;

            LineUpRow1 = hv_LineUpRow1;
            LineUpCol1 = hv_LineUpCol1;
            LineUpRow2 = hv_LineUpRow2;
            LineUpCol2 = hv_LineUpCol2;

            image.Dispose();
            return true;            
        }

        public bool SaveModel(string modelFullPath)
        {
            if (!ReferenceEquals(modelFullPath, null))
            { 
                ApplyHalcon.FindModel.SaveModel(ModelID, modelFullPath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoadModel(string modelFullPath)
        {
            if (File.Exists(modelFullPath)) 
            {
                ModelID = ApplyHalcon.FindModel.LoadModel(modelFullPath);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
