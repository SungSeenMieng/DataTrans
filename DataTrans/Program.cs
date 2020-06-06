using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataTrans
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadResoureDll.RegistDLL();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                //FrmDialog.ShowDialog(new BlankForm(), "已启动了一个进程点击确定退出","提醒" );
                MessageBox.Show("已经打开了一个进程","退出提示");
                Environment.Exit(0);
            }
            else
            {
                Application.Run(new DataTransForm());
            }
        }
    }
}
