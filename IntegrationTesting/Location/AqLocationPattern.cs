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

        double m_minScore = 0.57;
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

        double m_centerX = 0;
        public double CenterX
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

        double m_centerY = 0;
        public double CenterY
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

        double m_angle = 0;
        public double Angle
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

        double m_scale = 1;
        public double Scale
        {
            get { return m_scale; }
            set { m_scale = value; }
        }

        double m_score = 1;
        public double Score
        {
            get { return m_score; }
            set { m_score = value; }
        }


        private string m_TemplatePath = @"D:\a.bmp";
        public string TemplatePath
        {
            get { return m_TemplatePath; }
            set { m_TemplatePath = value; }
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

        
        public bool CreateTempateImage()
        {
            if(File.Exists(m_TemplatePath))
            {
                File.Delete(m_TemplatePath);
            }
            Image originImage = Image.FromHbitmap(m_OriginImage.GetHbitmap());

            ImageRow = (int)(RoiRegionTemplate.RightBottomY-RoiRegionTemplate.LeftTopPointY);
            ImageColumn = (int)(RoiRegionTemplate.RightBottomX-RoiRegionTemplate.LeftTopPointX);

            Bitmap bitmap = new Bitmap(ImageColumn, ImageRow);

            Graphics gTemplate = Graphics.FromImage(bitmap);
            gTemplate.DrawImage(originImage, 0, 0, new Rectangle((int)(m_RoiRegionTemplate.LeftTopPointX), (int)(m_RoiRegionTemplate.LeftTopPointY),
                                           ImageColumn, ImageRow),System.Drawing.GraphicsUnit.Pixel);
            bitmap.Save(m_TemplatePath, System.Drawing.Imaging.ImageFormat.Bmp);
            gTemplate.Dispose();
            bitmap.Dispose();
            return true;
        }

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


        public bool CreateModel()
        {
            HTuple rows = new HTuple();
            rows[0] = (int)(m_RoiRegionTemplate.LeftTopPointX);
            rows[1] = (int)(m_RoiRegionTemplate.RightBottomX);
            rows[2] = (int)(m_RoiRegionTemplate.RightBottomX);
            rows[3] = (int)(m_RoiRegionTemplate.LeftTopPointX);
            rows[4] = (int)(m_RoiRegionTemplate.LeftTopPointX);

            int[] cols = new int[5];
            cols[0] = (int)(m_RoiRegionTemplate.LeftTopPointY);
            cols[1] = (int)(m_RoiRegionTemplate.LeftTopPointY);
            cols[2] = (int)(m_RoiRegionTemplate.RightBottomY);
            cols[3] = (int)(m_RoiRegionTemplate.RightBottomY);
            cols[4] = (int)(m_RoiRegionTemplate.LeftTopPointY);
            HTuple rowSource = new HTuple();
            HTuple columnSource = new HTuple();
            HTuple angleSource = new HTuple();
            HTuple modeXldRows = new HTuple();
            HTuple modeXldCols = new HTuple();
            HTuple modeXldPointCounts = new HTuple();
            ApplyHalcon.FindModel.CreateFeatureModel(new HImage(m_TemplatePath), new HTuple(rows), new HTuple(cols),
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

        public void RunMatcherByHalcon()
        {
            HTuple xldRowsM = new HTuple();
            HTuple xldColsM = new HTuple();
            HTuple xldPointCountsM = new HTuple();
            HTuple row = new HTuple();
            HTuple column = new HTuple();
            HTuple angle = new HTuple();
            HTuple scale = new HTuple();
            HTuple score = new HTuple();

            ApplyHalcon.FindModel.FindFeatureModel(new HImage(m_TemplatePath), new HTuple(AngleStart), new HTuple(AngleExtent),
                                        new HTuple(AngleStep), new HTuple(ScaleMin), new HTuple(ScaleMax), new HTuple(MinScore),
                                        new HTuple(NumMatches), m_modelID, out xldRowsM, out xldColsM,
                                        out xldPointCountsM, out row, out column,
                                        out angle, out scale, out score);
            Score = score.D;
            Scale = scale.D;
            Angle = angle.D;
            CenterX = column.D;
            CenterY = row.D;
            XldPointCountsM = xldPointCountsM.LArr;
            XldColsM = xldColsM.DArr;
            XldRowsM = xldRowsM.DArr;
        }
    }
}
