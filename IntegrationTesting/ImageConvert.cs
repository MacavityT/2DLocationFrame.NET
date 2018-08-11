using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HalconDotNet;

namespace ApplyHalcon
{
    class ImageConvert
    {
        public static HImage Bitmap2HImage_24(Bitmap bImage)
        {
            Bitmap bImage24;
            BitmapData bmData = null;
            Rectangle rect;
            IntPtr pBitmap;
            IntPtr pPixels;
            HImage hImage = new HImage();
            rect = new Rectangle(0, 0, bImage.Width, bImage.Height);
            bImage24 = new Bitmap(bImage.Width, bImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bImage24);
            g.DrawImage(bImage, rect);
            g.Dispose();
            bmData = bImage24.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pBitmap = bmData.Scan0;
            pPixels = pBitmap;
            hImage.GenImageInterleaved(pPixels, "bgr", bImage.Width, bImage.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
            bImage24.UnlockBits(bmData);

            return hImage;
        }

        public static HImage Bitmap2HImage_8(Bitmap bImage)
        {
            BitmapData bmData = null;
            Rectangle rect;
            IntPtr pBitmap;
            IntPtr pPixels;
            var hImage = new HImage();
            rect = new Rectangle(0, 0, bImage.Width, bImage.Height);
            bmData = bImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            pBitmap = bmData.Scan0;
            pPixels = pBitmap;
            hImage.GenImage1("byte", bImage.Width, bImage.Height, pPixels);
            bImage.UnlockBits(bmData);
            //formathimage = hImage;
            return hImage;
        }

        // 8bit , 24bit
        public static void Hobject2Himage(HObject hobject, ref HImage image)
        {
            HTuple channel;
            HTuple type, width, height;
            HTuple hv_PointerR, hv_PointerG, hv_PointerB;
            HOperatorSet.CountChannels(hobject, out channel);
            if (channel == 1)
            {
                HTuple pointer;
                HOperatorSet.GetImagePointer1(hobject, out pointer, out type, out width, out height);
                image.GenImage1(type, width, height, pointer);
            }
            else
            {
                HOperatorSet.GetImagePointer3(hobject, out hv_PointerR, out  hv_PointerG, out  hv_PointerB, out  type, out  width, out  height);
                image.GenImage3("byte", width, height, hv_PointerR, hv_PointerG, hv_PointerB);
            }
        }

        public static Bitmap DeepCopyBitmap(Bitmap bitmap)
        {
            try
            {
                Bitmap dstBitmap = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, bitmap);
                    ms.Seek(0, SeekOrigin.Begin);
                    dstBitmap = (Bitmap) bf.Deserialize(ms);
                    ms.Close();
                }
                return dstBitmap;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static List<string> GetImageFiles(string filePath)
        {
            var di = new DirectoryInfo(filePath);
            var files = di.GetFiles();
            var list = new List<string>();
            foreach (FileInfo t in files)
            {
                var fileName = t.Name.ToLower();
                if (fileName.EndsWith(".bmp") || fileName.EndsWith(".jpg") || fileName.EndsWith(".png") || fileName.EndsWith(".tiff"))
                {
                    list.Add(fileName);
                }
            }
            return list;
        }
    }
}
