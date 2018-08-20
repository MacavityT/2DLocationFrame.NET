using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;

namespace AqVision.Interaction
{
    public class UI2LibInterface
    {
        #region Acqusition
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int key);

        [DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string sMsg);

        [DllImport("ProtoLayer.dll")]
        public static extern void GetErrorCode(uint flag, uint data);

        [DllImport("ProtoLayer.dll")]
        public static extern void RegisterErrorFunction(IntPtr pFn);

        [DllImport("ProtoLayer.dll")]
        public static extern void GetBitmap(uint flag, uint data);

        [DllImport("ProtoLayer.dll")]
        public static extern void RegisterBitmapFunction(IntPtr pFn);

        [DllImport("ProtoLayer.dll")]
        public static extern void Connect(int cameraType, string cameraName, UInt32 cameraExpose);

        [DllImport("ProtoLayer.dll")]
        public static extern void Disconnect();
        #endregion

        #region Location
        [DllImport("ProtoLayer.dll")]
        public static extern void GetImageSpecificLocation1(int centerX, int centerY,
                                                             int rectRoiX, int rectRoiY,
                                                             int rectRoiWidth, int rectRoiHeight,
                                                             string templatePath, ref int state,
                                                             ref int pointX, ref int pointY,
                                                             [Out, MarshalAs(UnmanagedType.LPArray)] char[] angle);
        #endregion 

        #region calibration
        [DllImport("ProtoLayer.dll")]
        public static extern bool add_move_match_point_pair(double imagePointX, double imagePointY,
                                                            double robotPointX, double robotPointY,
                                                            double robotPointZ);

        [DllImport("ProtoLayer.dll")]
        public static extern bool n_point_2angle_calibration(ref double resultRMS);

        [DllImport("ProtoLayer.dll")]
        public static extern bool set_catch_point(double imagePointX, double imagePointY, double imagePointZ,
                                                    double robotPointX, double robotPointY, double robotPointZ,
                                                    double catchPointX, double catchPointY, double catchPointZ);

        [DllImport("ProtoLayer.dll")]
        public static extern bool get_robot_point(double imagePointX, double imagePointY, double imagePointZ,
                                                  double robotPointX, double robotPointY, double robotPointZ,
                                                  ref double resultPointX, ref double resultPointY, ref double resultPointZ);

        [DllImport("ProtoLayer.dll")]
        public static extern bool save_calibration(string saveCalibrationParam);

        [DllImport("ProtoLayer.dll")]
        public static extern bool load_calibration(string loadCalibrationParam);


        /// <summary>
        ///     0-kCameraInHand, 1-kCameraOutHand
        /// </summary>
        /// <param name="calibMode"></param>
        /// <param name="isPositive"></param>
        /// <returns></returns>
        [DllImport("ProtoLayer.dll")]
        public static extern bool set_config_param(int calibMode, bool isPositive);

        #endregion
    }
}
