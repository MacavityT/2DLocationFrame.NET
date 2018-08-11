using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using AqVision.Shape;
using Newtonsoft.Json;
using Aqrose.Aidi;
using ApplyHalcon;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace IntegrationTesting.Aidi
{
    public partial class AIDIManagementForm : Form
    {
        #region aidi
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string sMsg);
        static string check_code = "7defbd49-99ef-11e8-b6b8-00163e06991b";

        AIDI dnn_factory_client = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code
        AIDI dnn_factory_client2 = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code
        AIDI dnn_factory_client3 = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code

        String root_path = "model_welding_slag";
        String root_path2 = "model_*****";
        String root_path3 = "model_*****";
        #endregion

        public AIDIManagementForm()
        {
            InitializeComponent();
        }

        private void AIDIManagementForm_Load(object sender, EventArgs e)
        {
            //先执行一次数据结构相同的json解析，这样下次json解析的时候时间就非常短了
            var arrdata0 = Newtonsoft.Json.Linq.JArray.Parse("[{\"area\":30.0,\"contours\":[{\"x\":1386,\"y\":583},{\"x\":1385,\"y\":584},{\"x\":1385,\"y\":585},{\"x\":1387,\"y\":587},{\"x\":1390,\"y\":587},{\"x\":1390,\"y\":584},{\"x\":1389,\"y\":583}],\"cx\":1388.0,\"cy\":585.0,\"height\":5.0,\"score\":3.5873240686715317e-043,\"type\":-1857038864,\"type_name\":\"\",\"width\":6.0},{\"area\":28.0,\"contours\":[{\"x\":1008,\"y\":581},{\"x\":1007,\"y\":582},{\"x\":1007,\"y\":584},{\"x\":1013,\"y\":584},{\"x\":1013,\"y\":582},{\"x\":1012,\"y\":582},{\"x\":1011,\"y\":581}],\"cx\":1010.0,\"cy\":583.0,\"height\":4.0,\"score\":3.5873240686715317e-043,\"type\":-1857038864,\"type_name\":\"\",\"width\":7.0}]");
            List<RootObject> objList0 = arrdata0.ToObject<List<RootObject>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sp2 = new Stopwatch();
            sp2.Start();

            InitAidiModel(dnn_factory_client, root_path, "LD", 1);
            sp2.Stop();
            MessageBox.Show("初始化完成，耗时" + sp2.ElapsedMilliseconds + " ms");
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //Bitmap bitmapTemp = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);//深拷贝
            label1.Text = "    ";
            List<Bitmap> bitmaps = GetBitmapsList("pics");
            BatchAidiImage batch_images = GetBatch_images(bitmaps);
            int batch_Capacity = batch_images.get_images_size();//获得batch_images一共有几张图片(容量)

            Stopwatch sp = new Stopwatch();
            sp.Start();
            StringVector result = dnn_factory_client.start_test(batch_images);// 多图测试接口
            sp.Stop();

            for (int i = 0; i < result.Count; i++)
            {
                AidiImage single_image = batch_images.at(i);
                richTextBox1.Text += result[i];
                //single_image.draw_result(result[i]);
                //single_image.show_image(0);
                richTextBox1.Text += result[i];
                richTextBox1.Text += "-----------------------------------" + i;
                richTextBox1.Refresh();

            }
            List<RootObject> objList = GetobjList(result[0]);//result[0]代表第一张图，以此类推
            // List<RootObject> objList1 = GetobjList(result[1]);

            ShowGraph(aqDisplay1, bitmaps[0]);

            Stopwatch sp3 = new Stopwatch();
            sp3.Start();

            DrawContours(objList, AqVision.AqColorConstants.Green, 1, aqDisplay1);

            sp3.Stop();
            richTextBox2.Text += "绘制contour时间：" + sp3.ElapsedMilliseconds + "\r\n";
            aqDisplay1.Update();

            string aidiTime = "AIDI检测时间：" + sp.ElapsedMilliseconds;
            richTextBox2.Text += aidiTime + "\r\n";
            richTextBox2.Refresh();

            richTextBox2.Text += batch_Capacity + "张" + "\r\n";
            richTextBox2.Refresh();

            label1.Text = "执行完毕" + batch_Capacity + "张";
            label1.ForeColor = Color.OrangeRed;
            //OutputDebugString("AAAAAA" + objList[0].contours[0].x);
        }


        /// <summary> Aidi模型初始化，添加所需要的Aidi模块
        /// 
        /// </summary>
        /// <param name="root_path"></param>
        public void InitAidiModel(AIDI dnn_factory_client, string root_path, string detectModel, int batch_size)
        {
            StringVector save_model_path_list = new StringVector();// 模型的加载路径，路径下应该有model.aqbin
            StringVector operator_type_list = new StringVector();
            IntVector batch_sizes = new IntVector(); // 一次测试几张图

            switch (detectModel)
            {
                case "L":
                    save_model_path_list.Add(root_path + "/Location_0");
                    operator_type_list.Add("Location");
                    batch_sizes.Add(batch_size);
                    break;

                case "D":
                    save_model_path_list.Add(root_path + "/Detect_0");
                    operator_type_list.Add("Detect");
                    batch_sizes.Add(batch_size);
                    break;

                case "LD":
                    save_model_path_list.Add(root_path + "/Location_0");
                    save_model_path_list.Add(root_path + "/Detect_1");
                    //save_model_path_list.Add(root_path + "/Classify_2/");

                    operator_type_list.Add("Location");
                    operator_type_list.Add("Detect");
                    //operator_type_list.Add("Classify");

                    batch_sizes.Add(batch_size);
                    batch_sizes.Add(batch_size);
                    //batch_sizes.Add(4);
                    break;

                default:
                    throw new Exception("detectModel只能填L、D、LD其中之一");

            }
            FactoryClientParamWrapper param = new FactoryClientParamWrapper();// 测试参数配置
            param.save_model_path_list = save_model_path_list;
            param.operator_type_list = operator_type_list;
            param.device_number = 0;
            param.use_gpu = true;


            dnn_factory_client.set_param(param);
            dnn_factory_client.set_detect_use_filter(false);// 检测模块是否开启过滤
            dnn_factory_client.set_batch_size(batch_sizes);
            dnn_factory_client.initial_test_model();
        }

        //获得Bitmap的list集合
        public List<Bitmap> GetBitmapsList(string DirPath)
        {
            List<string> imageList = ImageConvert.GetImageFiles(DirPath);
            List<Bitmap> bitmaps = new List<Bitmap>();
            for (int i = 0; i < imageList.Count - 8; i++)// imageList.Count = 6,这个地方可以控制传几张
            {
                string imagePath = DirPath + "\\" + imageList[i];
                Bitmap btmp = new Bitmap(imagePath);
                btmp = ZoomTo24Bitmap(btmp, 0.5, 24);
                bitmaps.Add(btmp);
            }
            return bitmaps;
        }

        public Bitmap ZoomTo24Bitmap(Bitmap srcBmp, double x, int bitDeep)
        {
            Bitmap decBmp = null;


            if (bitDeep == 24)
            {
                decBmp = new Bitmap((int)(srcBmp.Width * x), (int)(srcBmp.Height * x), PixelFormat.Format24bppRgb);
            }
            if (bitDeep == 32)
            {
                decBmp = new Bitmap((int)(srcBmp.Width * x), (int)(srcBmp.Height * x), PixelFormat.Format32bppRgb);
            }

            Graphics g = Graphics.FromImage(decBmp);
            g.DrawImage(srcBmp, new Rectangle(0, 0, decBmp.Width, decBmp.Height), 0, 0, srcBmp.Width, srcBmp.Height, GraphicsUnit.Pixel);
            return decBmp;
        }


        //灌入多张
        public BatchAidiImage GetBatch_images(List<Bitmap> bitmaps)
        {
            BatchAidiImage batch_images = new BatchAidiImage();

            int _count = bitmaps.Count;
            for (int i = 0; i < _count; i++)
            {
                int channelNum = Image.GetPixelFormatSize(bitmaps[i].PixelFormat) / 8;//判断8位、24位、32位

                int stride;
                byte[] data = GetBGRValues(bitmaps[i], out stride);
                //转换图片格式，供aidi使用
                AidiImage image = new AidiImage();

                image.char_ptr_to_mat(data, bitmaps[i].Height, bitmaps[i].Width, channelNum);
                batch_images.add_image(image);
            }
            return batch_images;
        }

        //灌入单张
        public BatchAidiImage GetBatch_images(Bitmap bitmap)
        {
            BatchAidiImage batch_images = new BatchAidiImage();
            int channelNum = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;//判断8位、24位、32位
            int stride;
            byte[] data = GetBGRValues(bitmap, out stride);
            //转换图片格式，供aidi使用
            AidiImage image = new AidiImage();
            image.char_ptr_to_mat(data, bitmap.Height, bitmap.Width, channelNum);
            batch_images.add_image(image);
            return batch_images;
        }

        void DrawLine(float sx, float sy, float ex, float ey, AqVision.AqColorConstants color, int lineWidth, AqVision.Controls.AqDisplay aqDisplay)
        {
            AqLineSegment lineSegment = new AqLineSegment();
            lineSegment.StartX = sx;
            lineSegment.StartY = sy;
            lineSegment.EndX = ex;
            lineSegment.EndY = ey;

            lineSegment.Color = color;
            lineSegment.LineWidthInScreenPixels = lineWidth;
            aqDisplay.InteractiveGraphics.Add(lineSegment, "", true);
        }

        public void ShowGraph(AqVision.Controls.AqDisplay aqDisplay, Bitmap bitmap)
        {
            aqDisplay.Image = bitmap;
            aqDisplay.FitToScreen();
        }

        //绘制轮廓
        public void DrawContours(List<RootObject> objList, AqVision.AqColorConstants color, int lineWidth, AqVision.Controls.AqDisplay aqDisplay)
        {
            for (int i = 0; i < objList.Count(); i++)
            {
                for (int j = 0; j < objList[i].contours.Count - 1; j++)
                {
                    int sx = Convert.ToInt32(objList[i].contours[j].x);
                    int sy = Convert.ToInt32(objList[i].contours[j].y);
                    int ex = Convert.ToInt32(objList[i].contours[j + 1].x);
                    int ey = Convert.ToInt32(objList[i].contours[j + 1].y);

                    DrawLine(sx, sy, ex, ey, color, lineWidth, aqDisplay);
                }
                //再设计一个点，补全多边形
                int n = objList[i].contours.Count;
                int nx = Convert.ToInt32(objList[i].contours[n - 1].x);
                int ny = Convert.ToInt32(objList[i].contours[n - 1].y);
                int zero_x = Convert.ToInt32(objList[i].contours[0].x);
                int zero_y = Convert.ToInt32(objList[i].contours[0].y);
                DrawLine(nx, ny, zero_x, zero_y, color, lineWidth, aqDisplay);

            }
        }

        //Json解析，生成方便抽取元素的objList
        public List<RootObject> GetobjList(string jsonText)
        {
            List<RootObject> objList = new List<RootObject>();
            if (jsonText.Length > 20)
            {
                //Json数据解析
                string str = jsonText;
                var arrdata = Newtonsoft.Json.Linq.JArray.Parse(jsonText);
                objList = arrdata.ToObject<List<RootObject>>();
                string arrayNum = "ROI_count is：" + objList.Count;
            }
            else  //数据长度<20的肯定是无效数据
            {
                objList = new List<RootObject>();
            }


            //richTextBox2.Text += aidiTime + "\r\n" + jsonTime + "\r\n" + arrayNum + "\r\n" +
            //    objList[0].area + "\r\n" + objList[0].contours[0].x + "\r\n";         
            return objList;
        }

        //这个方法可能多余
        public StringVector RunAidiTest(string defectModelPath, BatchAidiImage batch_images)
        {
            StringVector result = null;
            switch (defectModelPath)
            {
                case "dgg":
                    result = dnn_factory_client.start_test(batch_images); // 多图测试接口
                    break;

                case "ddgg ":
                    result = dnn_factory_client.start_test(batch_images); // 多图测试接口
                    break;

                case "dgg566":
                    //StringVector result = dnn_factory_client.start_test(batch_images); // 多图测试接口
                    break;
                default:
                    result = dnn_factory_client.start_test(batch_images); // 多图测试接口
                    break;
            }
            return result;
        }

        /// <summary> 将Bitmap转化为byte[]供Aidi使用
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="stride"></param>
        /// <returns></returns>

        public static byte[] GetBGRValues(Bitmap bmp, out int stride)
        {
            //var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //var bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            //stride = bmpData.Stride;
            ////int channel = bmpData.Stride / bmp.Width; 
            //var rowBytes = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            //var rowBytes1 = Image.GetPixelFormatSize(bmp.PixelFormat) / 8 - 1;
            //var imgBytes = bmp.Height * bmp.Width * rowBytes;
            //byte[] rgbValues = new byte[imgBytes];
            //IntPtr ptr = bmpData.Scan0;
            //for (var i = 0; i < bmp.Height * bmp.Width; i++)
            //{
            //    Marshal.Copy(ptr, rgbValues, i * rowBytes1, rowBytes1);   //对齐
            //    ptr += rowBytes; // next row
            //}
            //bmp.UnlockBits(bmpData);

            //return rgbValues;

            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            stride = bmpData.Stride;
            //int channel = bmpData.Stride / bmp.Width; 
            var rowBytes = bmpData.Width * Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            var imgBytes = bmp.Height * rowBytes;
            byte[] rgbValues = new byte[imgBytes];
            IntPtr ptr = bmpData.Scan0;
            for (var i = 0; i < bmp.Height; i++)
            {
                Marshal.Copy(ptr, rgbValues, i * rowBytes, rowBytes);   //对齐
                ptr += bmpData.Stride; // next row
            }
            bmp.UnlockBits(bmpData);

            return rgbValues;
        }

        public class Contours
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        public class RootObject
        {
            public string area { get; set; }
            public List<Contours> contours { get; set; }
            public string cx { get; set; }
            public string cy { get; set; }
            public string height { get; set; }
            public string score { get; set; }
            public string type { get; set; }
            public string type_name { get; set; }
            public string width { get; set; }
        }

        //   ***************************** 后面这几个方法没用到 ***********************
        /// <summary>  
        /// 将一个字节数组转换为8bit灰度位图  
        /// </summary>  
        /// <param name="rawValues">显示字节数组</param>  
        /// <param name="width">图像宽度</param>  
        /// <param name="height">图像高度</param>  
        /// <returns>位图</returns>  
        public static Bitmap ToGrayBitmap(byte[] rawValues, int width, int height)
        {
            //// 申请目标位图的变量，并将其内存区域锁定  
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height),
             ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            //// 获取图像参数  
            int stride = bmpData.Stride;  // 扫描线的宽度  
            int offset = stride - width;  // 显示宽度与扫描线宽度的间隙  
            IntPtr iptr = bmpData.Scan0;  // 获取bmpData的内存起始位置  
            int scanBytes = stride * height;// 用stride宽度，表示这是内存区域的大小  

            //// 下面把原始的显示大小字节数组转换为内存中实际存放的字节数组  
            int posScan = 0, posReal = 0;// 分别设置两个位置指针，指向源数组和目标数组  
            byte[] pixelValues = new byte[scanBytes];  //为目标数组分配内存  

            for (int x = 0; x < height; x++)
            {
                //// 下面的循环节是模拟行扫描  
                for (int y = 0; y < width; y++)
                {
                    pixelValues[posScan++] = rawValues[posReal++];
                }
                posScan += offset;  //行扫描结束，要将目标位置指针移过那段“间隙”  
            }

            //// 用Marshal的Copy方法，将刚才得到的内存字节数组复制到BitmapData中  
            System.Runtime.InteropServices.Marshal.Copy(pixelValues, 0, iptr, scanBytes);
            bmp.UnlockBits(bmpData);  // 解锁内存区域  

            //// 下面的代码是为了修改生成位图的索引表，从伪彩修改为灰度  
            ColorPalette tempPalette;
            using (Bitmap tempBmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                tempPalette = tempBmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                tempPalette.Entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = tempPalette;

            //// 算法到此结束，返回结果  
            return bmp;
        }

        public static byte[] Bitmap2Byte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }

        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }


    }
}
