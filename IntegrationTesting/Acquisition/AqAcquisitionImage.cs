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

namespace AqVision.Acquisition
{
    public delegate void DelegateOnError(int id);
    public delegate void DelegateOnBitmap(string strBmpBase64);
    class AqAcquisitionImage
    {
        private event DelegateOnError m_EventOnError;
        private event DelegateOnBitmap m_EventOnBitmap;
        private bool m_GetBitmapSuc = false;

        bool m_acquisitionParamChanged = false;
        public bool AcquisitionParamChanged
        {
            get { return m_acquisitionParamChanged; }
            set { m_acquisitionParamChanged = value; }
        }

        System.Drawing.Bitmap m_RevBitmap = null;
        string[] m_cameraName = new string[] { "Aqrose_L", "Aqrose_D" };

        public string[] CameraName
        {
            get { return m_cameraName; }
            set
            {
                if ((value[0] != m_cameraName[0]) || (value[1] != m_cameraName[1]))
                {
                    AcquisitionParamChanged = true;
                }
                m_cameraName = value;
            }
        }

        UInt32[] m_cameraExposure = new UInt32[] { 5000, 5000 };
        public UInt32[] CameraExposure
        {
            get { return m_cameraExposure; }
            set
            {
                if ((value[0] != m_cameraExposure[0]) || (value[1] != m_cameraExposure[1]))
                {
                    AcquisitionParamChanged = true;
                }
                m_cameraExposure = value;
            }
        }


        AqCameraBrand[] m_cameraBrand = new AqCameraBrand[] { AqCameraBrand.DaHeng, AqCameraBrand.DaHeng };
        public AqCameraBrand[] CameraBrand
        {
            get { return m_cameraBrand; }
            set
            {
                if ((value[0] != m_cameraBrand[0]) || (value[1] != m_cameraBrand[1]))
                {
                    AcquisitionParamChanged = true;
                }
                m_cameraBrand = value;
            }
        }

        public System.Drawing.Bitmap RevBitmap
        {
            get { return m_RevBitmap; }
            set { m_RevBitmap = value; }
        }

        string m_inputImageFileLocation = null;
        public string InputImageFileLocation
        {
            get { return m_inputImageFileLocation; }
            set { m_inputImageFileLocation = value; }
        }

        string m_inputImageFileDetection = null;
        public string InputImageFileDetection
        {
            get { return m_inputImageFileDetection; }
            set { m_inputImageFileDetection = value; }
        }

        string m_inputImageFolderLocation = null;
        public string InputImageFolderLocation
        {
            get { return m_inputImageFolderLocation; }
            set 
            { 
                m_inputImageFolderLocation = value;
                if(m_inputImageFolderLocation != "")
                {
                    if (Directory.Exists(m_inputImageFolderLocation))
                    {
                        if (Directory.GetFiles(m_inputImageFolderLocation).Length == 0)
                        {
                            m_imageListLocation = null;
                        }
                        else
                        {
                            m_imageListLocation = Directory.GetFiles(m_inputImageFolderLocation);
                        }
                    }
                }
            }
        }

        string m_inputImageFolderDetection = null;
        public string InputImageFolderDetection
        {
            get { return m_inputImageFolderDetection; }
            set 
            { 
                m_inputImageFolderDetection = value;
                if (m_inputImageFolderDetection != "")
                {
                    if (Directory.Exists(m_inputImageFolderDetection))
                    {
                        if (Directory.GetFiles(m_inputImageFolderDetection).Length == 0)
                        {
                            m_imageListDetection = null;
                        }
                        else
                        {
                            m_imageListDetection = Directory.GetFiles(m_inputImageFolderDetection);
                        }
                    }
                }
            }
        }
        string[] m_imageListLocation = null;
        public string[] ImageListLocation
        {
            get { return m_imageListLocation; }
        }

        string[] m_imageListDetection = null;
        public string[] ImageListDetection
        {
            get { return m_imageListDetection; }
        }


        AcquisitionMode m_acquisitionStyle;
        public AcquisitionMode AcquisitionStyle
        {
            get { return m_acquisitionStyle; }
            set { m_acquisitionStyle = value; }
        }

        UInt16 m_indexPicInFolderLocation = 0;
        UInt16 m_indexPicInFolderDetection = 0;
        AqDevice.IAqCameraManager cameramanager = null;
        List<AqDevice.IAqCamera> cameras;
        bool m_connected = false;

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
        ~AqAcquisitionImage()
        {
        }


        public bool Connect()
        {
            try
            {
                if (!m_connected && AcquisitionStyle == AcquisitionMode.FromCamera)
                {
                    string dllpath = System.IO.Directory.GetCurrentDirectory() + "\\DaHengCamera.dll";
                    Assembly assem = Assembly.LoadFile(dllpath);
                    Type type = assem.GetType("AqDevice.AqCameraFactory");
                    MethodInfo mi = type.GetMethod("GetInstance");
                    object obj = mi.Invoke(null, null);

                    cameramanager = (IAqCameraManager)obj;
                    cameramanager.Init();
                    cameras = cameramanager.GetCameras();
                    cameras[0].TriggerMode = AqDevice.TriggerModes.Unknow;
                    cameras[0].ExposureTime = CameraExposure[0];
                    cameras[0].Name = CameraName[0];
                    cameras[0].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture));
                    cameras[0].OpenCamera();
                    cameras[0].OpenStream();

                    cameras[1].TriggerMode = AqDevice.TriggerModes.Unknow;
                    cameras[1].ExposureTime = CameraExposure[1];
                    cameras[1].Name = CameraName[1];
                    cameras[1].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture1));
                    cameras[1].OpenCamera();
                    cameras[1].OpenStream();

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
                    cameras[0].CloseCamera();
                    cameras[1].CloseCamera();
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

        public bool Acquisition(ref System.Drawing.Bitmap cameraLocationBmp, ref System.Drawing.Bitmap cameraDetectionBmp)
        {
            try
            {
                GC.Collect();
                if (AcquisitionStyle == AcquisitionMode.FromCamera)
                {
                    if (AcquisitionParamChanged)
                    {
                        DisConnect();
                        Connect();
                        AcquisitionParamChanged = false;
                    }

                    if (!m_connected)
                    {
                        Connect();
                    }
                    m_GetBitmapSuc = false;
                    cameras[0].TriggerSoftware();
                    while (!m_GetBitmapSuc)
                    {
                        //使用事件的等待
                        Thread.Sleep(10);
                    }
                    cameraLocationBmp = RevBitmap;
                    m_GetBitmapSuc = false;
                    cameras[1].TriggerSoftware();
                    while (!m_GetBitmapSuc)
                    {
                        Thread.Sleep(10);
                    }
                    cameraDetectionBmp = RevBitmap;
                }
                else if (AcquisitionStyle == AcquisitionMode.FromFile)
                {
                    cameraLocationBmp = Image.FromFile(InputImageFileLocation) as Bitmap;
                    cameraDetectionBmp = Image.FromFile(InputImageFileDetection) as Bitmap;
                }
                else if (AcquisitionStyle == AcquisitionMode.FromFolder)
                {
                    cameraLocationBmp = Image.FromFile( m_imageListLocation[m_indexPicInFolderLocation]) as Bitmap;
                    if(m_indexPicInFolderLocation == m_imageListLocation.Length-1)
                    {
                        m_indexPicInFolderLocation = 0;
                    }
                    else
                    {
                        m_indexPicInFolderLocation++;
                    }

                    cameraDetectionBmp = Image.FromFile(m_imageListDetection[m_indexPicInFolderDetection]) as Bitmap;
                    if(m_indexPicInFolderDetection == m_imageListDetection.Length-1)
                    {
                        m_indexPicInFolderDetection = 0;
                    }
                    else
                    {
                        m_indexPicInFolderDetection++;
                    }
                }

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
