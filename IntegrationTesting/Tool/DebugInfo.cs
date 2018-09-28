using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Tool
{
    public class DebugInfo
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public static void OutputProcessMessage(string labelString)
        {
            Process process = Process.GetCurrentProcess();
            string name = process.ProcessName;
            int thread = process.Threads.Count;
            PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", process.ProcessName);

            string message = string.Format("memory:{0}KB, Label({1}), Name: {2}, threadCount{3}",
                pf1.NextValue() / 1024,labelString, name, thread);
            OutputDebugString(message);
        }

    }
}
