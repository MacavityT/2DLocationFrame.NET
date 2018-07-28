using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AqVision.Interaction
{
    public class UI2LibInterface
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(int key);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string sMsg);

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void GetErrorCode(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void RegisterErrorFunction(IntPtr pFn);

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void GetBitmap(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void RegisterBitmapFunction(IntPtr pFn);

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void Connect();

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void Disconnect();

        [System.Runtime.InteropServices.DllImport("ProtoLayer.dll")]
        public static extern void GetImageSpecificLocation1(int _center_x, int _center_y,
                                                             int _rect_roi_x, int _rect_roi_y,
                                                             int _rect_roi_width, int _rect_roi_height,
                                                             string _template_path, ref int _state,
                                                             ref int _point_x, ref int _point_y,
                                                             [Out, MarshalAs(UnmanagedType.LPArray)] char[] _angle);
    }
}
