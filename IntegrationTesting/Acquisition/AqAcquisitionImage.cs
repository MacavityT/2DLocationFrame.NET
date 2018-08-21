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

namespace AqVision.Acquistion
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
        string m_cameraName = "Aqrose_L";
        public string CameraName
        {
            get { return m_cameraName; }
            set 
            {
                if(value != m_cameraName)
                {
                    AcquisitionParamChanged = true;
                }
                m_cameraName = value; 
            }
        }
        UInt32 m_cameraExposure = 5000;
        public UInt32 CameraExposure
        {
            get { return m_cameraExposure; }
            set 
            {
                if (value != m_cameraExposure)
                {
                    AcquisitionParamChanged = true;
                }
                m_cameraExposure = value; 
            }
        }


        AqCameraBrand m_cameraBrand = AqCameraBrand.DaHeng;
        public AqCameraBrand CameraBrand
        {
            get { return m_cameraBrand; }
            set 
            { 
                if(m_cameraBrand != value)
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

        ////////////////////////////////////////////////
        AqDevice.IAqCameraManager cameramanager = null;
        List<AqDevice.IAqCamera> cameras;
        bool m_connected = false;
        ////////////////////////////////////////////////

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
                if(!m_connected)
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
                    cameras[0].ExposureTime = 2000;
                    cameras[0].Name = "Aqrose_L";
                    cameras[0].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture));
                    cameras[0].OpenCamera();
                    cameras[0].OpenStream();

                    cameras[1].TriggerMode = AqDevice.TriggerModes.Unknow;
                    cameras[1].ExposureTime = 2000;
                    cameras[1].Name = "Aqrose_D";
                    cameras[1].RegisterCaptureCallback(new AqCaptureDelegate(RecCapture1));
                    cameras[1].OpenCamera();
                    cameras[1].OpenStream();

                    m_connected = true;
                }

            }
            catch(FormatException ex)
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
                if(m_connected)
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

        public bool Acquisition(ref System.Drawing.Bitmap cameraLocationBmp,ref System.Drawing.Bitmap cameraDetectionBmp)
        {
            try
            {
                GC.Collect();
                if (AcquisitionParamChanged)
                {
                    Connect();
                    AcquisitionParamChanged = false;
                }
                m_GetBitmapSuc = false;
                cameras[0].TriggerSoftware();
                while (!m_GetBitmapSuc)
                {
                    Thread.Sleep(10);
                }
                cameraLocationBmp = RevBitmap;
                m_GetBitmapSuc = false;
                cameras[0].TriggerSoftware();
                while (!m_GetBitmapSuc)
                {
                    Thread.Sleep(10);
                }
                cameraDetectionBmp = RevBitmap;
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
