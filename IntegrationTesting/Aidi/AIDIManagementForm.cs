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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ApplyHalcon;
using aidi_client;
using Aqrose.Aidi;
using HalconDotNet;
using AqVision.Shape;
using Newtonsoft.Json;
using TypeC_Aidi;


namespace IntegrationTesting.Aidi
{
    public partial class AIDIManagementForm : Form
    {
        static string check_code = "7defbd49-99ef-11e8-b6b8-00163e06991b";
        AIDI dnn_factory_client = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code
        AIDI dnn_factory_client2 = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code
        AIDI dnn_factory_client3 = new AIDI(check_code);// 构造测试类，没有加密狗请传入check_code
        String root_path = "model_welding_slag";
        String root_path2 = "model_*****";
        String root_path3 = "model_*****";
        //Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(@"******"));//转成utf-8
        string model_path =  Application.StartupPath + @"\model";//转成utf-8
        string pics_path = Application.StartupPath + @"\Detect";
        AidiRuner runer = new AidiRuner(check_code);
        IntVector batch_size = new IntVector();

        private Thread brightspotThread;

        List<RootObject>[] m_objList = null;
        public List<RootObject>[] ObjList
        {
            get { return m_objList; }
            set { m_objList = value; }
        }

        List<Bitmap> m_sourceBitmap = null;
        public List<Bitmap> SourceBitmap
        {
            get { return m_sourceBitmap; }
            set { m_sourceBitmap = value; }
        }

        public class Contours
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        public bool DetectResult
        {
            get 
            {
                if ((m_objList.Length <= 0 || m_objList == null))
                {
                    return true;    //产品没问题
                }
                else
                {
                    return false;   //产品有问题
                }
            }
        }

        public AIDIManagementForm()
        {
            InitializeComponent();
            button1_Click(null, null);
            brightspotThread = new Thread(brightspot);
        }

        public void brightspot()
        {
            AidiProcess();
        }

        public void DetectPic()
        {
            if (m_sourceBitmap == null || m_sourceBitmap.Count == 0)
            {
                SourceBitmap = GetBitmapsList(pics_path);
            }

            int batch_Capacity = SourceBitmap.Count;//获得batch_images一共有几张图片(容量)
            m_objList = new List<RootObject>[SourceBitmap.Count];

            for (int k = 0; k < batch_Capacity; k++)
            {
                List<Bitmap> bit = new List<Bitmap>();
                bit.Add(SourceBitmap[k]);
                runer.set_detect_images(bit);
                List<string> results = new List<string>();
                results = runer.get_detect_result();

                int index = 0;
                List<RootObject> objList = TypeC_Aidi.ResultStructure.GetobjList(results[index], 0); //results[0]代表第一张图，以此类推,这里可以设置筛选条件
                m_objList[k] = objList;
                if (batch_Capacity > 1)
                {
                    Thread.Sleep(500);
                }
            }
        }
        public void AidiProcess()
        {            
            Stopwatch sp = new Stopwatch();
            DetectPic();

            for (int k = 0; k < SourceBitmap.Count; k++)
            {
                new TypeC_Aidi.ResultStructure().ShowAllGraph(aqDisplay1, SourceBitmap[k], m_objList[k], AqVision.AqColorConstants.Red, 1);

                comboBoxShowResultList.Invoke(new MethodInvoker(delegate
                {
                    comboBoxShowResultList.Items.Add(string.Format("{0}", k));
                }));
                
                string aidiTime = sp.ElapsedMilliseconds + "";
                sp.Stop();
                if (richTextBox1.InvokeRequired)
                {
                    richTextBox1.BeginInvoke(new Action(() =>
                    {
                        richTextBox1.Text += aidiTime + "\r\n";
                        richTextBox1.Refresh(); 
                    }));
                }
                else
                {
                    richTextBox1.Text += aidiTime + "\r\n";
                    richTextBox1.Refresh();
                }
                if (SourceBitmap.Count > 1)
                {
                    Thread.Sleep(500);
                }                
            }
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
            InitAidiModel();
            sp2.Stop();
            MessageBox.Show("AIDI初始化完成，耗时" + sp2.ElapsedMilliseconds + " ms");
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxShowResultList.Items.Clear();
                brightspotThread.Start();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        /// <summary>
        /// Aidi模型初始化，添加所需要的Aidi模块
        /// </summary>
        /// <param name="dnn_factory_client"></param>
        /// <param name="root_path"></param>
        /// <param name="detectModel"></param>
        /// <param name="batch_size"></param>
        public void InitAidiModel()
        {
            try
            {
                batch_size.Add(1);
                runer.Init(model_path, 0, batch_size);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 从路径读入Bitmap集合
        /// </summary>
        /// <param name="DirPath"></param>
        /// <returns></returns>
        public List<Bitmap> GetBitmapsList(string DirPath)
        {
            List<string> imageList = ImageConvert.GetImageFiles(DirPath);
            List<Bitmap> bitmaps = new List<Bitmap>();
            for (int i = 0; i < imageList.Count; i++)// imageList.Count = 6,这个地方可以控制传几张
            {
                string imagePath = DirPath + "\\" + imageList[i];
                Bitmap btmp = new Bitmap(imagePath);
               // btmp = ZoomTo24Bitmap(btmp, 0.5, 24);
                bitmaps.Add(btmp);
            }
            return bitmaps;
        }

        /// <summary>
        /// 转换图片通道深度
        /// </summary>
        /// <param name="srcBmp"></param>
        /// <param name="x"></param>
        /// <param name="bitDeep"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 将批量图片灌入Aidi对象
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 将单张图片灌入Aidi对象
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="ex"></param>
        /// <param name="ey"></param>
        /// <param name="color"></param>
        /// <param name="lineWidth"></param>
        /// <param name="aqDisplay"></param>
        void DrawLine(float sx, float sy, float ex, float ey, AqVision.AqColorConstants color, int lineWidth, AqVision.Controls.AqDisplay aqDisplay)
        {
            AqLineSegment lineSegment = new AqLineSegment();
            lineSegment.StartX = sx;
            lineSegment.StartY = sy;
            lineSegment.EndX = ex;
            lineSegment.EndY = ey;

            lineSegment.Color = color;
            lineSegment.LineWidthInScreenPixels = lineWidth;
            aqDisplay.InteractiveGraphics.Add(lineSegment, "", false);
            
        }

        /// <summary>
        /// 绘制轮廓
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="color"></param>
        /// <param name="lineWidth"></param>
        /// <param name="aqDisplay"></param>
        public void DrawContours(List<RootObject> objList, AqVision.AqColorConstants color, int lineWidth, AqVision.Controls.AqDisplay aqDisplay)
        {
            for (int i = 0; i < objList.Count(); i++)
            {
                for (int j = 0; j < objList[i].contours.Count - 1; j++)
                {
                    int sx = (int)Convert.ToDouble(objList[i].contours[j].x);
                    int sy = (int)Convert.ToDouble(objList[i].contours[j].y);
                    int ex = (int)Convert.ToDouble(objList[i].contours[j + 1].x);
                    int ey = (int)Convert.ToDouble(objList[i].contours[j + 1].y);
                    DrawLine(sx, sy, ex, ey, color, lineWidth, aqDisplay);
                }
                //再设计一个点，补全多边形
                int n = objList[i].contours.Count;
                int nx = (int)Convert.ToDouble(objList[i].contours[n - 1].x);
                int ny = (int)Convert.ToDouble(objList[i].contours[n - 1].y);
                int zero_x = (int)Convert.ToDouble(objList[i].contours[0].x);
                int zero_y = (int)Convert.ToDouble(objList[i].contours[0].y);
                DrawLine(nx, ny, zero_x, zero_y, color, lineWidth, aqDisplay);
            }
        }

        /// <summary>
        /// Json解析，生成方便抽取元素的objList
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
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
            return objList;
        }

        /// <summary>
        /// 获取图片的RGB值
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="stride"></param>
        /// <returns></returns>
        public static byte[] GetBGRValues(Bitmap bmp, out int stride)
        {
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

        private void comboBoxShowResultList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                aqDisplay1.InteractiveGraphics.Clear();
                aqDisplay1.Image = m_sourceBitmap[comboBoxShowResultList.SelectedIndex];
                aqDisplay1.FitToScreen();
                DrawContours(m_objList[comboBoxShowResultList.SelectedIndex], AqVision.AqColorConstants.Red, 1, aqDisplay1);
                aqDisplay1.Update();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
