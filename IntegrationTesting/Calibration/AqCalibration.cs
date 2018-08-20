using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    class AqCalibration
    {
        string m_calibrationResultSavePath;
        public string CalibrationResultSavePath
        {
            get { return m_calibrationResultSavePath; }
            set { m_calibrationResultSavePath = value; }
        }

        double [,] m_resultPoint = null;
        public double[,] ResultPoint
        {
          get { return m_resultPoint; }
          set { m_resultPoint = value; }
        }

        double m_resultRMS = 1;
        public double ResultRMS
        {
            get { return m_resultRMS; }
            set { m_resultRMS = value; }
        }

        public class ImageCoordinateGroup
        {
            double m_ImageX;
            public double ImageX
            {
                get { return m_ImageX; }
                set { m_ImageX = value; }
            }
            double m_ImageY;
            public double ImageY
            {
                get { return m_ImageY; }
                set { m_ImageY = value; }
            }
            double m_ImageA;
            public double ImageA
            {
                get { return m_ImageA; }
                set { m_ImageA = value; }
            }
            public ImageCoordinateGroup(double imageX, double imageY, double imageA)
            {
                m_ImageX = imageX;
                m_ImageY = imageY;
                m_ImageA = imageA;
            }
            public bool SetValue(double imageX, double imageY, double imageA)
            {
                m_ImageX = imageX;
                m_ImageY = imageY;
                m_ImageA = imageA;
                return true;
            }
        }

        public class CalibrationDataGroup
        {
            private ImageCoordinateGroup cameraPosition = new ImageCoordinateGroup(0, 0, 0);
            public ImageCoordinateGroup CameraPosition
            {
              get { return cameraPosition; }
              set { cameraPosition = value; }
            }

            private RobotCoordinateGroup robotCoordinate = new RobotCoordinateGroup(0, 0, 0);
            public RobotCoordinateGroup RobotCoordinate
            {
              get { return robotCoordinate; }
              set { robotCoordinate = value; }
            }
        }

        public class RobotCoordinateGroup
        {
            double m_robotX;
            public double RobotX
            {
                get { return m_robotX; }
                set { m_robotX = value; }
            }
            double m_robotY;
            public double RobotY
            {
                get { return m_robotY; }
                set { m_robotY = value; }
            }
            double m_robotRz;
            public double RobotRz
            {
                get { return m_robotRz; }
                set { m_robotRz = value; }
            }
            public RobotCoordinateGroup(double robotX, double robotY, double robotRz)
            {
                m_robotX = robotX;
                m_robotY = robotY;
                m_robotRz = robotRz;
            }
            public bool SetValue(double robotX, double robotY, double robotRz)
            {
                m_robotX = robotX;
                m_robotY = robotY;
                m_robotRz = robotRz;
                return true;
            }
        }

        public class CatchCoordinateGroup
        {
            double m_catchX;
            public double CatchX
            {
                get { return m_catchX; }
            }
            double m_catchY;
            public double CatchY
            {
                get { return m_catchY; }
            }
            double m_catchRz;
            public double CatchRz
            {
                get { return m_catchRz; }
            }
            public CatchCoordinateGroup(double catchX, double catchY, double catchRz)
            {
                m_catchX = catchX;
                m_catchY = catchY;
                m_catchRz = catchRz;
            }
            public bool SetValue(double catchX, double catchY, double catchRz)
            {
                m_catchX = catchX;
                m_catchY = catchY;
                m_catchRz = catchRz;
                return true;
            }
        }

        ImageCoordinateGroup m_ImagePoint = new ImageCoordinateGroup(1, 1, 1);
        public ImageCoordinateGroup ImagePoint
        {
            get { return m_ImagePoint; }
        }

        RobotCoordinateGroup m_RobotPoint = new RobotCoordinateGroup(2, 2, 2);
        internal RobotCoordinateGroup RobotPoint
        {
            get { return m_RobotPoint; }
        }

        CatchCoordinateGroup m_catchPoint = new CatchCoordinateGroup(3, 3, 3);
        public CatchCoordinateGroup CatchPoint
        {
            get { return m_catchPoint; }
        }

        List<CalibrationDataGroup> m_allLineData = new List<CalibrationDataGroup>();
        public List<CalibrationDataGroup> AllLineData
        {
            get { return m_allLineData; }
            set { m_allLineData = value; }
        }

        public AqCalibration()
        {
        }

        public bool AddMoveMatchPointPair()
        {
           return AqVision.Interaction.UI2LibInterface.add_move_match_point_pair(ImagePoint.ImageX,ImagePoint.ImageY,
                                                                            RobotPoint.RobotX,RobotPoint.RobotY,RobotPoint.RobotRz);
        }

        public bool NPoint2AngleCalibartion()
        {
            return AqVision.Interaction.UI2LibInterface.n_point_2angle_calibration(ref m_resultRMS);
        }

        public bool SetCatchPoint()
        {
            return AqVision.Interaction.UI2LibInterface.set_catch_point(ImagePoint.ImageX, ImagePoint.ImageY, ImagePoint.ImageA,
                                                                        RobotPoint.RobotX, RobotPoint.RobotY, RobotPoint.RobotRz,
                                                                        CatchPoint.CatchX, CatchPoint.CatchY, CatchPoint.CatchRz);
        }

        public bool GetRobotPoint()
        {
            double catchX = CatchPoint.CatchX;
            double catchY = CatchPoint.CatchY;
            double catchRz = CatchPoint.CatchRz;
            if (!AqVision.Interaction.UI2LibInterface.get_robot_point(ImagePoint.ImageX, ImagePoint.ImageY, ImagePoint.ImageA, RobotPoint.RobotX, RobotPoint.RobotY, RobotPoint.RobotRz,
                                                                        ref catchX, ref catchY, ref catchRz))
           {
               return false;
           }
           else
           {
               m_catchPoint.SetValue(catchX, catchY, catchRz);
               return true;
           }
        }

        public bool SaveCalibrationResult()
        {
            return AqVision.Interaction.UI2LibInterface.save_calibration(CalibrationResultSavePath);
        }

        public bool LoadCalibrationResult()
        {
            return AqVision.Interaction.UI2LibInterface.load_calibration(CalibrationResultSavePath);
        }
        public bool SetConfig(int calibMode, bool isPositive)
        {
            return AqVision.Interaction.UI2LibInterface.set_config_param(calibMode, isPositive);
        }
    }
}
