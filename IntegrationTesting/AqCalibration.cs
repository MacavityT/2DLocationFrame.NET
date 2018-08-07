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

        double m_resultRMS = 0;
        public double ResultRMS
        {
            get { return m_resultRMS; }
            set { m_resultRMS = value; }
        }

        public struct ImageCoordinateGroup
        {
            double m_ImageX;
            public double ImageX
            {
                get { return m_ImageX; }
            }
            double m_ImageY;
            public double ImageY
            {
                get { return m_ImageY; }
            }
            double m_ImageA;
            public double ImageA
            {
                get { return m_ImageA; }
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
//         public struct ResultCoordinateGroup
//         {
//             double m_resultX;
//             public double ResultX
//             {
//                 get { return m_resultX; }
//             }
//             double m_resultY;
//             public double ResultY
//             {
//                 get { return m_resultY; }
//             }
//             double m_resultA;
//             public double ResultA
//             {
//                 get { return m_resultA; }
//             }
//             public ResultCoordinateGroup(double resultX, double resultY, double resultA)
//             {
//                 m_resultX = resultX;
//                 m_resultY = resultY;
//                 m_resultA = resultA;
//             }
//             public bool SetValue(double resultX, double resultY, double resultA)
//             {
//                 m_resultX = resultX;
//                 m_resultY = resultY;
//                 m_resultA = resultA;
//                 return true;
//             }
//         }

        public struct RobotCoordinateGroup
        {
            double m_robotX;
            public double RobotX
            {
                get { return m_robotX; }
            }
            double m_robotY;
            public double RobotY
            {
                get { return m_robotY; }
            }
            double m_robotRz;
            public double RobotRz
            {
                get { return m_robotRz; }
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

        public struct CatchCoordinateGroup
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

//         ResultCoordinateGroup m_resultPoint = new ResultCoordinateGroup(0, 0, 0);
//         public ResultCoordinateGroup ResultPoint
//         {
//             get { return m_resultPoint; }
//         }

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
    }
}
