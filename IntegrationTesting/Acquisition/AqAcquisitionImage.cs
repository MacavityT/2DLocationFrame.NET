using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using IntegrationTesting;

namespace AqVision.Acquistion
{
    public delegate void DelegateOnError(int id);
    public delegate void DelegateOnBitmap(string strBmpBase64);
    class AqAcquisitionImage
    {
        private event DelegateOnError m_EventOnError;
        private event DelegateOnBitmap m_EventOnBitmap;
        private bool m_GetBitmapSuc = false;
        private GCHandle m_gcError;
        private GCHandle m_gcBitmap;

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


        public AqAcquisitionImage()
        {
            m_EventOnError += new DelegateOnError(OnError);
            m_gcError = GCHandle.Alloc(m_EventOnError);
            IntPtr ptr = Marshal.GetFunctionPointerForDelegate(m_EventOnError);
            AqVision.Interaction.UI2LibInterface.RegisterErrorFunction(ptr);

            m_EventOnBitmap += new DelegateOnBitmap(OnReceiveBitmap);
            m_gcBitmap = GCHandle.Alloc(m_EventOnBitmap);
            IntPtr ptrBitmap = Marshal.GetFunctionPointerForDelegate(m_EventOnBitmap);
            AqVision.Interaction.UI2LibInterface.RegisterBitmapFunction(ptrBitmap);
        }

        ~AqAcquisitionImage()
        {
            m_gcError.Free();
            m_gcBitmap.Free();
        }

        void OnReceiveBitmap(string strBmpBase64)
        {
            int ibmpLen = strBmpBase64.Length;
            m_RevBitmap = AqVision.Utility.Base64.Base64ToBitmap(strBmpBase64);
            AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting OnReceiveBitmap end ");
            m_GetBitmapSuc = true;
        }

        void OnError(int id)
        {
            //System.Windows.Forms.MessageBox.Show(id.ToString());
        }

        public bool Connect()
        {
            try
            {
                AqVision.Interaction.UI2LibInterface.Disconnect();
                AqVision.Interaction.UI2LibInterface.Connect(Convert.ToInt32(CameraBrand), CameraName, CameraExposure);
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
                AqVision.Interaction.UI2LibInterface.Disconnect();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("IntegrationTesting DisConnect error " + ex.Message);
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting DisConnect error " + ex.Message);
            }
            
            return true;
        }

        public System.Drawing.Bitmap Acquisition()
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
                AqVision.Interaction.UI2LibInterface.GetBitmap(1, 0);
                while (!m_GetBitmapSuc)
                {
                    Thread.Sleep(10);
                }
                return RevBitmap;
            }
            catch (Exception ex)
            {
                AqVision.Interaction.UI2LibInterface.OutputDebugString("IntegrationTesting get bitmp error " + ex.Message);
                return null;
            }
        }
    }
}
