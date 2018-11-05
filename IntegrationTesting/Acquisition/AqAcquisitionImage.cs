using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using IntegrationTesting;
using System.Drawing;
using System.Reflection;
using AqDevice;
using IntegrationTesting.Acquisition;
using System.IO;

//目前取像部分：支持到大恒相机，最多支持6个相机
namespace AqVision.Acquisition
{
    public delegate void DelegateOnError(int id);
    public delegate void DelegateOnBitmap(string strBmpBase64);

    class AqAcquisitionImage
    {
        private event DelegateOnError m_EventOnError;
        private event DelegateOnBitmap m_EventOnBitmap;
        private bool m_GetBitmapSuc = false;
        AqDevice.IAqCameraManager cameramanager = null;
        bool m_connected = false;
        
        System.Drawing.Bitmap m_RevBitmap = null;
        public System.Drawing.Bitmap RevBitmap
        {
            get { return m_RevBitmap; }
            set { m_RevBitmap = value; }
        }

        List<AqDevice.IAqCamera> cameras;
        Dictionary<string, int> m_cameraNameToIndex = new Dictionary<string,int>();

        CameraParam cameraParam = new CameraParam();
        public CameraParam CameraParamSet
        {
            get { return cameraParam; }
            set { cameraParam = value; }
        }

        public AqAcquisitionImage()
        {
        }

        public void RecCapture(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        public void RecCapture1(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        public void RecCapture2(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        public void RecCapture3(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        public void RecCapture4(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        public void RecCapture5(object objUserparam, Bitmap bitmap)
        {
            RevBitmap = bitmap;
            m_GetBitmapSuc = true;
        }

        ~AqAcquisitionImage()
        {
        }

        /// <summary>
        /// Connect() //连接相机，最多支持一个软件连接6个相机
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                if (!m_connected)
                {
                    string dllpath = System.IO.Directory.GetCurrentDirectory() + "\\DaHengCamera.dll";
                    Assembly assem = Assembly.LoadFile(dllpath);
                    Type type = assem.GetType("AqDevice.AqCameraFactory");
                    MethodInfo mi = type.GetMethod("GetInstance");
                    object obj = mi.Invoke(null, null);

                    cameramanager = (IAqCameraManager)obj;
                    cameramanager.Init();
                    cameras = cameramanager.GetCameras();

                    for(int i = 0; i < cameras.Count; i++)
                    {
                        cameras[i].TriggerMode = AqDevice.TriggerModes.Unknow;
                        if (i < CameraParamSet.CameraName.Count)  //防止出现连接了新相机,但是本地参数文件中没该新相机的名字等配置信息情况出现
                        {
                            cameras[i].ExposureTime = CameraParamSet.CameraNameExposure[CameraParamSet.CameraName[i]];
                            cameras[i].Name = CameraParamSet.CameraName[i];
                        }
                        else
                        {
                            CameraParamSet.CameraName.Add(cameras[i].Name);
                            CameraParamSet.CameraNameExposure[cameras[i].Name] = Convert.ToUInt32(cameras[i].ExposureTime);                            
                        }

                        m_cameraNameToIndex.Add(cameras[i].Name, i);

                        if(i == 0)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture));
                        }
                        else if (i == 1)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture1));
                        }
                        else if (i == 2)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture2));
                        }
                        else if (i == 3)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture3));
                        }
                        else if (i == 4)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture4));
                        }
                        else if (i == 5)
                        {
                            cameras[i].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture5));
                        }

                        cameras[i].OpenCamera();
                        cameras[i].OpenStream();
                    }
                    m_connected = true;
                }

            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting Connect Format error " + ex.Message);
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting Connect Format error " + ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting Connect error " + ex.Message);
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting Connect error " + ex.Message);
            }

            return true;
        }

        public bool DisConnect()
        {
            try
            {
                if (m_connected)
                {
                    for (int i = 0; i < cameras.Count; i++)
                    {
                        cameras[i].CloseCamera();
                    }
                }
                m_connected = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting DisConnect error " + ex.Message);
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting DisConnect error " + ex.Message);
            }
            return true;
        }

        /// <summary>
        /// Acquisition  目前只在取相处，支持一个图片的取像
        /// </summary>
        /// <param name="cameraLocationBmp"></param>
        /// <param name="cameraDetectionBmp"></param>
        /// <returns></returns>
        public bool Acquisition(ref List<System.Drawing.Bitmap> AcquisitionBmp, List<string> AcquisitionCameraName)
        {
            try
            {
                GC.Collect();
                for (int i = 0; i < AcquisitionCameraName.Count; i++)
                {
                    if (CameraParamSet.AcquisitionStyle[AcquisitionCameraName[i]] == AcquisitionMode.FromCamera)
                    {
                        if (CameraParamSet.AcquisitionParamChanged)
                        {
                            DisConnect();
                            Connect();
                            CameraParamSet.AcquisitionParamChanged = false;
                        }

                        if (!m_connected)
                        {
                            Connect();
                        }
                        if (cameras.Count < AcquisitionCameraName.Count)
                        {
                            return false;
                        }
                        m_GetBitmapSuc = false;
                        cameras[m_cameraNameToIndex[AcquisitionCameraName[i]]].TriggerSoftware();
                        while (!m_GetBitmapSuc)
                        {
                            //使用事件的等待
                            Thread.Sleep(10);
                        }
                        AcquisitionBmp.Add(RevBitmap);
                    }
                    else if (CameraParamSet.AcquisitionStyle[AcquisitionCameraName[i]] == AcquisitionMode.FromFile)
                    {
                        AcquisitionBmp.Add(Image.FromFile(CameraParamSet.CameraNameInputFile[AcquisitionCameraName[i]]) as Bitmap);
                    }
                    else if (CameraParamSet.AcquisitionStyle[AcquisitionCameraName[i]] == AcquisitionMode.FromFolder)
                    {
                        string strFolder = CameraParamSet.CameraNameInputFolder[AcquisitionCameraName[i]];
                        string strFile = CameraParamSet.FolderFiles[strFolder].ElementAt((int)CameraParamSet.FolderIndex[strFolder]);
                        int len = CameraParamSet.FolderFiles[strFolder].Count;
                        AcquisitionBmp.Add(Image.FromFile(strFile) as Bitmap);
                        CameraParamSet.FolderIndex[strFolder] = CameraParamSet.FolderIndex[strFolder]++;
                    }
                }

//                 //对图像将进行裁剪
//                 Image originImage = Image.FromHbitmap(cameraLocationBmp.GetHbitmap());
//                 Bitmap bitmap = new Bitmap(originImage.Width-156, originImage.Height);
//                 Graphics gTemplate = Graphics.FromImage(bitmap);
//                 gTemplate.DrawImage(originImage, 0, 0, new Rectangle(78, 0, originImage.Width-78, originImage.Height), System.Drawing.GraphicsUnit.Pixel);
//                 cameraLocationBmp = bitmap.Clone() as Bitmap;
//                 gTemplate.Dispose();
//                 bitmap.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting get bitmp error " + ex.Message);
                return false;
            }
        }
    }
}