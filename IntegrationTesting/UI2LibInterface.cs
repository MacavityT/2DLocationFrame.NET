using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqVision.Interaction
{
    public class UI2LibInterface
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(int key);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string sMsg);

#if DEBUG
        [System.Runtime.InteropServices.DllImport("CppEntityd.dll")]
        public static extern void GetErrorCode(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("CppEntityd.dll")]
        public static extern void RegisterErrorFunction(IntPtr pFn);

        [System.Runtime.InteropServices.DllImport("CppEntityd.dll")]
        public static extern void GetBitmap(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("CppEntityd.dll")]
        public static extern void RegisterBitmapFunction(IntPtr pFn);
     
        [System.Runtime.InteropServices.DllImport("CppEntityd.dll")]
        public static extern void Connect();
#else
        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void GetErrorCode(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void RegisterErrorFunction(IntPtr pFn);

        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void GetBitmap(uint flag, uint data);

        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void RegisterBitmapFunction(IntPtr pFn);

        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void Connect();

        [System.Runtime.InteropServices.DllImport("CppEntity.dll")]
        public static extern void Disconnect();
#endif
    }
}
