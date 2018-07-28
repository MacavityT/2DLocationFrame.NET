using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AqVision.Location
{
    class AqLocationPattern
    {
        private Bitmap m_OriginImage = null;
        public Bitmap OriginImage
        {
            get { return m_OriginImage; }
            set { m_OriginImage = value; }
        }

        private string m_TemplatePath = @"D:\Bitmap.bmp";
        public string TemplatePath
        {
            get { return m_TemplatePath; }
            set { m_TemplatePath = value; }
        }

        private AqVision.Shape.AqRectangleAffine m_RoiRegionTemplate = new Shape.AqRectangleAffine();
        public AqVision.Shape.AqRectangleAffine RoiRegionTemplate
        {
            get { return m_RoiRegionTemplate; }
            set { m_RoiRegionTemplate = value; }
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
            Bitmap bitmap = new Bitmap((int)(m_RoiRegionTemplate.Width), (int)(m_RoiRegionTemplate.Height));

            Graphics gTemplate = Graphics.FromImage(bitmap);
            gTemplate.DrawImage(originImage, 0, 0, new Rectangle((int)(m_RoiRegionTemplate.LeftTopPointX), (int)(m_RoiRegionTemplate.LeftTopPointY),
                                                   (int)(m_RoiRegionTemplate.Width), (int)(m_RoiRegionTemplate.Height)),System.Drawing.GraphicsUnit.Pixel);
            bitmap.Save(m_TemplatePath, System.Drawing.Imaging.ImageFormat.Bmp);
            gTemplate.Dispose();
            bitmap.Dispose();
            return true;
        }

        public bool RunMatcher()
        {
            m_TemplateRegionCenter.X = (int)(((int)(m_RoiRegionTemplate.LeftTopPointX)) + ((int)(m_RoiRegionTemplate.RightBottomX)) / 2);
            m_TemplateRegionCenter.Y = (int)(((int)(m_RoiRegionTemplate.LeftTopPointY)) + ((int)(m_RoiRegionTemplate.RightBottomY)) / 2);
            AqVision.Interaction.UI2LibInterface.GetImageSpecificLocation1(m_TemplateRegionCenter.X, m_TemplateRegionCenter.Y,
                                                                           (int)(m_RoiRegionTemplate.LeftTopPointX),
                                                                           (int)(m_RoiRegionTemplate.LeftTopPointY),
                                                                           (int)(m_RoiRegionTemplate.Width),
                                                                           (int)(m_RoiRegionTemplate.Height),
                                                                           m_TemplatePath,
                                                                           ref m_matherState,
                                                                           ref m_ResultX,  ref m_ResultY,
                                                                           m_ResultAngle);
            return MatherResult;
        }

    }
}
