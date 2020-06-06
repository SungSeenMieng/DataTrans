using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DataTrans
{
    public partial class DataTransForm
    {
        #region 内存回收
        public static class ClearMemoryInfo
        {
            [DllImport("kernel32.dll")]
            private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
            /// <summary>
                   /// 强制清理内存
                   /// </summary>
            public static void FlushMemory()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
                //System.Diagnostics.Process.GetCurrentProcess().MinWorkingSet = new System.IntPtr(5);
            }
        }
        #endregion
    }
}
