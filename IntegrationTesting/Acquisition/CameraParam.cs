using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Acquisition
{
    public class CameraParam
    {
        bool m_acquisitionParamChanged = false;
        public bool AcquisitionParamChanged
        {
            get { return m_acquisitionParamChanged; }
            set { m_acquisitionParamChanged = value; }
        }

        List<string> m_cameraName = new List<string>();
        public List<string> CameraName
        {
            get { return m_cameraName; }
            set { m_cameraName = value; }
        }

        Dictionary<string, UInt32> m_cameraNameExposure = new Dictionary<string,uint>();
        public Dictionary<string, UInt32> CameraNameExposure
        {
            get { return m_cameraNameExposure; }
            set
            {
                m_cameraNameExposure = value;
                AcquisitionParamChanged = true;
            }
        }

        Dictionary<string, AqCameraBrand> m_cameraNameBrand = new Dictionary<string,AqCameraBrand>();
        public Dictionary<string, AqCameraBrand> CameraNameBrand
        {
            get { return m_cameraNameBrand; }
            set
            {
                m_cameraNameBrand = value;
                AcquisitionParamChanged = true;
            }
        }

        Dictionary<string, string> m_cameraNameInputFile = new Dictionary<string,string>();
        public Dictionary<string, string> CameraNameInputFile
        {
            get { return m_cameraNameInputFile; }
            set { m_cameraNameInputFile = value; }
        }

        Dictionary<string, string> m_cameraNameInputFolder = new Dictionary<string, string>();
        public Dictionary<string, string> CameraNameInputFolder
        {
            get { return m_cameraNameInputFolder; }
            set { m_cameraNameInputFolder = value;}
        }
        
        Dictionary<string, List<string>> m_folderFiles = new Dictionary<string,List<string>>();
        public Dictionary<string, List<string>> FolderFiles
        {
            get { return m_folderFiles; }
            set { m_folderFiles = value; }
        }

        Dictionary<string, UInt32> m_folderIndex = new Dictionary<string,uint>();
        public Dictionary<string, UInt32> FolderIndex
        {
            get { return m_folderIndex; }
            set { m_folderIndex = value; }
        }

        Dictionary<string, AcquisitionMode> m_acquisitionStyle = new Dictionary<string,AcquisitionMode>();
        public Dictionary<string, AcquisitionMode> AcquisitionStyle
        {
            get { return m_acquisitionStyle; }
            set { m_acquisitionStyle = value; }
        }

        public void UpdateFilesUnderFolder()
        {
            FolderFiles.Clear();
            FolderIndex.Clear();
            
            foreach (string folder in CameraNameInputFolder.Values)
            {
                if (folder != "")
                {
                    if (Directory.Exists(folder))
                    {
                        if (Directory.GetFiles(folder).Length != 0)
                        {
                            FolderFiles.Add(folder, new List<string>(Directory.GetFiles(folder)));
                            FolderIndex.Add(folder, 0);
                        }
                    }
                }
            }
            
        }
    }
}
