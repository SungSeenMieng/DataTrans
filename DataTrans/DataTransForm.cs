using DotNetCacheInterface;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HZH_Controls;
using HZH_Controls.Forms;
using NPOI.SS.Formula.Functions;

namespace DataTrans
{
    public partial class DataTransForm : Form
    {
        SerialPortDeal serialPort;
        public string lisport, serverport,clientport, logpath,desktopenter,serialportno,serialbaudrate,serialparitycheck,serialdatabit,serialstopbit,filepath,filenameextension,filewritepath,filewriteextension;

        Socket MSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket LSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket MacSocket;
        Socket LISSocket;
        Thread threadlis;
        Thread threadmac;
        IPAddress clientip ;
        IPAddress ip = IPAddress.Parse("0.0.0.0");
        IPEndPoint ipl;
        IPEndPoint ipm;
        FileStream fsw;
        Socket client;
        //bool clientflag = false;
        public bool serialflag = false;
        public string serialrec = "";
        int timesleep = 10000;
        TransModule tm = new TransModule();
        byte ConnectWay = 0;
        ClassOperation operat = new ClassOperation();
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (int.Parse(Properties.Settings.Default.MainPage))
            {
                case 0:
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    break;
                case 1:
                    StringEditor se = new StringEditor();
                    se.Owner = this;
                    se.Show();
                    se.BringToFront();
                    break;
                default:
                    break;
            }
           
        }

        private void 退出监听程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否确认退出程序？", "提示", true) == DialogResult.OK)
            {
                LogPathTimer.Stop();
                CleaningTimer.Stop();
                TransModuleRefresh.Stop();
                fsw.Flush();
                fsw.Close();
                NotifyIcon.Visible = false;
                System.Environment.Exit(0);
            }
        }

        private void 打开日志目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "//logs");
        }

        private void 打开监听程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void 设为开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            try
            {
                if (设为开机启动ToolStripMenuItem.Checked==false) //设置开机自启动  
                {
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.SetValue("JcShutdown", path);
                    rk2.Close();
                    rk.Close();
                    设为开机启动ToolStripMenuItem.Checked = true;
                    Properties.Settings.Default.Startup = true;
                }
                else //取消开机自启动  
                {
                    string path = Application.ExecutablePath;
                    RegistryKey rk = Registry.LocalMachine;
                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                    rk2.DeleteValue("JcShutdown", false);
                    rk2.Close();
                    rk.Close();
                    设为开机启动ToolStripMenuItem.Checked = false;
                    Properties.Settings.Default.Startup = false;
                }
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsWarning(this, "请使用管理员模式运行");
                //MessageBox.Show(ex.Message,"请使用管理员模式"); 
            }
            NotifyMenu.Show();
        }

        private void 打开监听配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm setup = new SetupForm();
            setup.Owner = this;
            setup.notifyicon = NotifyIcon;
            setup.ShowDialog();
        }

        private void 清空窗口日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LISLogBox.Clear();
            MacLogBox.Clear();
            FrmTips.ShowTipsInfo(this, "清除日志窗口");
        }

        private void DM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            NotifyIcon.Visible = true;
        }

        public DataTransForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void DM_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartTime = DateTime.Now;
            label7.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.MaximizeBox = false;
            this.MinimumSize = new Size(280, 563);
            this.Size = new Size(280, 563);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            splitContainer1.Panel1Collapsed = true;
            if (!System.IO.File.Exists(Application.StartupPath + "/Config.mdb"))
            {
                
                FrmTips.ShowTipsInfo(this, "检测不到中继数据库，正在生成，请稍候");
                //MessageBox.Show("检测不到数据库，自动生成，请重启程序后使用", "数据传输中继");
                byte[] config = Properties.Resources.Config;
                System.IO.File.WriteAllBytes(Application.StartupPath + "/Config.mdb", config);
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                System.Environment.Exit(0);
            }
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                string[] rest = rk2.GetValueNames();
                foreach (string line in rest)
                {
                    if (line == "JcShutdown")
                    { 设为开机启动ToolStripMenuItem.Checked = true; }
                }
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsWarning(this, "请使用管理员模式运行");
                //MessageBox.Show(ex.Message, "请使用管理员模式运行本程序");
            }
            if (Properties.Settings.Default.LogsReserve != "0")
            {
                LogsCleaningTimer.Start();
            }
            CleaningTimer.Start();
            LogPathTimer.Start();
            TransModuleRefresh.Start();
            LogPathTimer_Tick(null, null);
            try
            {
                fsw = new FileStream(logpath, FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite);
            }
            catch (Exception ex)
            {
                FrmDialog.ShowDialog(this, "写日志线程异常:" + ex.Message);
            }
            LogPrint("*************************************",2);
            LogPrint("正在启动LIS系统网口仪器中继程序",2);
            LogPrint("*************************************",2);
            try
            {
                MachineName.Text = Properties.Settings.Default.MachineName;
                MenuMachineName.Text = "仪器：" + Properties.Settings.Default.MachineName;
                this.Text = Properties.Settings.Default.ProgramName;
                this.NotifyIcon.Text = Properties.Settings.Default.ProgramName;
                this.NotifyIcon.BalloonTipText = Properties.Settings.Default.ProgramName;
                desktopenter = Properties.Settings.Default.ShortcutName;
                CleaningTimer.Interval = int.Parse(Properties.Settings.Default.CleaningTimer);
                TransModuleRefresh.Interval = int.Parse(Properties.Settings.Default.ApplyTimer);
                lisport = Properties.Settings.Default.LISport.ToString();
                ConnectWay = byte.Parse(Properties.Settings.Default.ConnectWay);
                serialportno = Properties.Settings.Default.SerialPortNo.ToString();
                serialbaudrate = Properties.Settings.Default.SerialBaudRate;
                serialparitycheck = Properties.Settings.Default.SerialParityCheck;
                serialdatabit = Properties.Settings.Default.SerialDataBit;
                serialstopbit = Properties.Settings.Default.SerialStopBit;
                filenameextension = Properties.Settings.Default.FileNameExtension;
                filepath = Properties.Settings.Default.FilePath;
                filewritepath = Properties.Settings.Default.FileWritePath;
                filewriteextension = Properties.Settings.Default.FileWriteExtension;
                clientport = Properties.Settings.Default.ClientPort.ToString();
                serverport = Properties.Settings.Default.ServerPort.ToString();
                timesleep = int.Parse(Properties.Settings.Default.ClientTimer);
                FileTimer.Interval = int.Parse(Properties.Settings.Default.FileTimer);
                clientip = IPAddress.Parse(Properties.Settings.Default.ClientIP.Replace(" ", ""));
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsError(this, "服务启动错误:"+ex.Message);
            }
            LogPrint("LIS连接IP：" + ip.ToString(), 0);
            LogPrint("LIS连接端口：" + lisport, 0);
            ConfigConsole terminal = new ConfigConsole(fsw);
            threadlis = new Thread(WaitLIS);
            threadlis.Start(); 
            terminal.start();

            ClearMemoryInfo.FlushMemory();

            switch (ConnectWay)
            {
                case 0:
                    LogPrint("仪器连接方式：客户端连接", 1);
                    LogPrint("仪器连接IP端口：" +ip+":"+serverport, 1);
                    threadmac = new Thread(WaitMac);
                    threadmac.Start();
                    LogPrint("*************************************", 2);
                    break;
                case 1:
                    LogPrint("仪器连接方式：服务端监听", 1);
                    LogPrint("仪器监听IP端口：" + clientip + ":" + clientport, 1);
                    threadmac = new Thread(ConnMac);
                    threadmac.Start();
                    LogPrint("*************************************", 2);
                    break;
                case 2:
                    LogPrint("仪器连接方式：串口连接", 1);
                    LogPrint("仪器连接串口号：" + serialportno, 1);
                    LogPrint("波特率：" +serialbaudrate , 1);
                    LogPrint("校验：" +serialparitycheck , 1);
                    LogPrint("数据位：" +serialdatabit , 1);
                    LogPrint("停止位：" +serialstopbit , 1);
                    LogPrint("RTS/CTS：" + Properties.Settings.Default.SerialRTSEnable, 1);
                    threadmac = new Thread(SerialPort);
                    threadmac.Start();
                    LogPrint("*************************************", 2);
                    break;
                case 3:
                    LogPrint("仪器连接方式：读文件", 1);
                    LogPrint("仪器数据目录：" + filepath +"\\*."+filenameextension, 1);
                    LogPrint("写入数据目录：" + filewritepath + "\\*." + filewriteextension, 1);
                    FileTimer.Start();
                   ucWave1.WaveColor=Color.FromArgb(0, 155, 144);
                    
                    if (Properties.Settings.Default.FileConnectLIS)
                    {
                        LogPrint("链接Cache模式", 1);
                        MACIP.Text = "读文件(链接Cache)模式";
                        Properties.Settings.Default.MacStatus= "读文件(链接Cache)模式";
                        string ret = operat.Login(Properties.Settings.Default.CacheHost, int.Parse(Properties.Settings.Default.CachePort), Properties.Settings.Default.CacheNamespace, Properties.Settings.Default.CacheUserID, Properties.Settings.Default.CachePassword);
                        if( ret== "Login Cache OK")
                        {
                            LogPrint("登录LIS数据库成功", 1);
                        }
                        else
                        {
                            LogPrint("登录LIS数据库失败:"+ret.Split(':')[1], 1);
                            FileTimer.Stop();
                           ucWave1.WaveColor=Color.FromArgb(255, 77, 59);
                        }
                    }
                    else {
                        LogPrint("转网络传输模式", 1);
                        MACIP.Text = "读文件(转网络)模式";
                        Properties.Settings.Default.MacStatus = "读文件(转网络)模式";
                    }
                    LogPrint("*************************************", 2);
                    break;
            }
        }

        private void ConnMac()
        {
            LogPrint("当前仪器连接方式为客户端请求方式", 1);
            LogPrint("仪器地址：" + ipm, 1);
            ipm = new IPEndPoint(clientip,int.Parse(clientport));
            while (true)
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                   ucWave1.WaveColor=Color.FromArgb(255, 77, 59);
                    MACIP.Clear();
                    Properties.Settings.Default.MacStatus = "";
                    LogPrint("正在连接仪器...", 1);
                    client.Connect(ipm);
                    LogPrint("仪器连接成功", 1);
                    Properties.Settings.Default.MacStatus = client.RemoteEndPoint.ToString();
                    MACIP.Text = client.RemoteEndPoint.ToString();
                   ucWave1.WaveColor=Color.FromArgb(0, 155, 144);
                    while (true)
                    {
                        try
                        {
                            NotifyIcon.Icon = Properties.Resources.icon;
                            string recStr = ReceiveMac(client);
                            if (recStr != "" || recStr.Length > 1)

                            {
                                NotifyIcon.Icon = Properties.Resources.transfer;
                                SendLIS(tm.Trans(tm.Trans(recStr, "MTL"), "==")); }
                            else { break; }
                        }
                        catch (Exception ex)
                        {
                            LogPrint(ex.Message + ",重新尝试连接仪器...", 1);
                            break;
                        }
                    }
                }
                catch (Exception e) { LogPrint("检查仪器监听及配置",1);Thread.Sleep(timesleep); continue; }
            }
        }
        public void sp_DataReceived(object sender, EventArgs e)
        {
            NotifyIcon.Icon = Properties.Resources.transfer;
            System.Threading.Thread.Sleep(100);  //延迟100ms等待接收完成数据
            //System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();// 显示汉字与字符
                Byte[] readBytes = new Byte[serialPort.sp.BytesToRead];
                serialPort.sp.Read(readBytes, 0, readBytes.Length);
            if (Properties.Settings.Default.RecEncode == "Default")
            {
                serialrec = Encoding.Default.GetString(readBytes);
            }
            else
            {
                Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.RecEncode);
                serialrec = encode.GetString(readBytes);
            }
            string Str = serialrec;
            string recStr = Str;
            foreach (char c in recStr)
            {
                if ((int)c < 33)
                {
                    Str = Str.Replace(c.ToString(), "<" + (c % 16 + c / 16 * 10).ToString() + ">");
                }
            }
            if (recStr != "" || recStr.Length > 1)
            {
                SendLIS(tm.Trans(tm.Trans(recStr, "MTL"), "=="));
            }
            LogPrint("T<--M:" + Str, 1);
            serialrec = "";
            NotifyIcon.Icon = Properties.Resources.icon;
        }
        private void SerialPort()
        {
            try
            {
                serialPort = new SerialPortDeal(Properties.Settings.Default.SerialPortNo, Properties.Settings.Default.SerialBaudRate, Properties.Settings.Default.SerialParityCheck, Properties.Settings.Default.SerialDataBit, Properties.Settings.Default.SerialStopBit,Properties.Settings.Default.SerialRTSEnable);
                serialPort.sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                serialPort.open();
                ucWave1.WaveColor=Color.FromArgb(0, 155, 144);
                MACIP.Text = serialportno;
                Properties.Settings.Default.MacStatus =serialportno;
                LogPrint("仪器串口连接成功", 1);
            }
            catch (Exception ex)
            {
               ucWave1.WaveColor=Color.FromArgb(255, 77, 59);
                LogPrint(ex.Message, 1);
                FrmTips.ShowTipsError(this, "串口设置出错:"+ex.Message);
                //MessageBox.Show(ex.Message);
            }
           
        }
        private void WaitMac()
        {
            LogPrint("当前仪器连接方式为服务端监听方式", 1);
            ipm = new IPEndPoint(ip, int.Parse(serverport));
            LogPrint("正在 "+ipm+" 端口启动仪器监听...",1);          
                MSocket.Bind(ipm);
                MSocket.Listen(0);
                while (true)
                {
               ucWave1.WaveColor=Color.FromArgb(255, 77, 59);
                MACIP.Clear();
                Properties.Settings.Default.MacStatus = "";
                LogPrint("正在等待仪器连接...", 1);
                    MacSocket = MSocket.Accept();
                    LogPrint("仪器连接成功", 1);
                
                    MACIP.Text = MacSocket.RemoteEndPoint.ToString();
                    Properties.Settings.Default.MacStatus = MacSocket.RemoteEndPoint.ToString();
                ucWave1.WaveColor=Color.FromArgb(0, 155, 144);
                    while (true)
                    {
                    NotifyIcon.Icon = Properties.Resources.icon;
                    try
                        {
                            string recStr = ReceiveMac(MacSocket);
                        if (recStr != "" || recStr.Length > 1)
                        {
                            NotifyIcon.Icon = Properties.Resources.transfer;
                            SendLIS(tm.Trans(tm.Trans(recStr, "MTL"),"==")); 
                        }
                        else {
                            break; }    
                    }
                        catch (Exception ex)
                        { 
                            LogPrint(ex.Message+",重新启动仪器监听...",1);
                        break;
                        }
                    }
                }            
        }
        private string ReceiveMac(Socket MacSocket)
        {
            string Str = "";
            string recStr = "";
            try
            {
                byte[] recByte = new byte[int.Parse(Properties.Settings.Default.SendBuff)];
                int bytes = MacSocket.Receive(recByte, recByte.Length, 0);
                if (Properties.Settings.Default.RecEncode == "Default")
                {
                    recStr += Encoding.Default.GetString(recByte, 0, bytes);
                }
                else
                {
                    Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.RecEncode);
                    recStr += encode.GetString(recByte, 0, bytes);
                }
                Str = recStr;
                foreach (char c in recStr) 
                {
                    if ((int)c < 33)
                    {
                        Str = Str.Replace(c.ToString(), "<" + (c % 16 + c / 16 * 10).ToString() + ">");
                    }    
                }
                LogPrint("T<--M:" + Str, 1);
                return recStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FileSend(string sendStr)
        {
            string[] lines = sendStr.Split('\r');
            string filename="";
            string filecontent="";
            if (lines.Length == 1)
            {
                lines = lines[0].Split('\n');
            }
            filename = lines[0].Replace("\r","").Replace("\n","");
            for (int i = 1; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\r","").Replace("\n","");
                filecontent += lines[i]+"\r\n";
            }
            if (System.IO.File.Exists(filewritepath + "\\" + filename + "." + filewriteextension))
            {
                LogPrint("写入文件失败 文件已存在:文件名" + filename, 1);
            }
            else 
            {
                //System.IO.File.Create(filewritepath + "\\" + filename + "." + filewriteextension);
                System.IO.File.WriteAllText(filewritepath + "\\" + filename + "." + filewriteextension,filecontent);
            }
        }
        private int SendMac(string sendStr)
        {
            try
            {
                string Str = sendStr;
                foreach (char c in sendStr)
                {
                    if ((int)c < 33)
                    {
                        Str = Str.Replace(c.ToString(), "<" + (c % 16 + c / 16 * 10).ToString() + ">");
                    }
                }
                LogPrint("T-->M:" + Str, 1);
                byte[] sendByte;
                if (Properties.Settings.Default.SendEncode == "Default")
                {
                    sendByte = Encoding.Default.GetBytes(sendStr);
                }
                else
                {
                    Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.SendEncode);
                    sendByte = encode.GetBytes(sendStr);
                }
                switch (int.Parse(Properties.Settings.Default.ConnectWay))
                {
                    case 0:
                        MacSocket.Send(sendByte, sendByte.Length, 0);
                        break;
                    case 1:
                        client.Send(sendByte, sendByte.Length, 0);
                        break;
                    case 2:
                        serialPort.send(sendStr);
                        break;
                    case 3:
                        FileSend(sendStr);
                        break;
                }
                return 1;
            }
            catch
            {
                LogPrint("发送数据到仪器失败,数据["+sendStr+"]",1);
                return 0;
            }
        }

        private void FileTimer_Tick(object sender, EventArgs e)
        {
            
            if (Directory.Exists(filepath))
            {
                string[] list=Directory.GetFiles(filepath, "*." + filenameextension);
                if (list.Length > 0)
                {
                    foreach (string filename in list)
                    {
                        NotifyIcon.Icon = Properties.Resources.transfer;
                        if (!Properties.Settings.Default.FileConnectLIS) {
                            SendLIS("filename:" + filename + "\r\n"); }
                        if (filenameextension.Contains("xls"))
                        {
                            string importExcelPath = filename;
                            IWorkbook workbook = WorkbookFactory.Create(importExcelPath);
                            ISheet sheet = workbook.GetSheetAt(0);
                            string content = "";
                            foreach (IRow row in sheet)
                            {
                                content = "";
                                foreach (ICell cell in row)
                                {
                                    content += cell+"\t";
                                }
                                content += "\r\n";
                                if (Properties.Settings.Default.FileConnectLIS)
                                {
                                    object ret = operat.RunClassMethod(Properties.Settings.Default.FileClassMethod, "fileMTHD", Properties.Settings.Default.FileMI, tm.Trans(tm.Trans(content, "MTL"), "=="));
                                    if (ret.ToString().Length > 0)
                                    {
                                        LogPrint("直接传输数据到LIS失败[" + ret.ToString() + "]:" + content, 0);
                                    }
                                    else
                                    {
                                        LogPrint("直接传输数据到LIS成功:" + content, 0);
                                    }
                                }
                                else
                                {
                                    SendLIS(tm.Trans(tm.Trans(content, "MTL"), "==") + "\r\n");
                                }
                                LogPrint("T<--M:" + content, 1);
                            }
                            workbook.Close();
                        }
                        else
                        {
                            string[] lines = System.IO.File.ReadAllLines(filename);
                            foreach (string line in lines)
                            {
                                string Str = line;
                                foreach (char c in Str)
                                {
                                    if ((int)c < 33)
                                    {
                                        Str = Str.Replace(c.ToString(), "<" + (c % 16 + c / 16 * 10).ToString() + ">");
                                    }
                                }
                                if (line != "" || line.Length > 1)
                                {
                                    if (Properties.Settings.Default.FileConnectLIS)
                                    {
                                        object ret = operat.RunClassMethod(Properties.Settings.Default.FileClassMethod, "fileMTHD", Properties.Settings.Default.FileMI, tm.Trans(tm.Trans(line, "MTL"), "=="));
                                        if (ret.ToString().Length > 0)
                                        {
                                            LogPrint("直接传输数据到LIS失败[" + ret.ToString() + "]:" + Str, 0);
                                        }
                                        else
                                        {
                                            LogPrint("直接传输数据到LIS成功:" + Str, 0);
                                        }
                                    }
                                    else
                                    {
                                        SendLIS(tm.Trans(tm.Trans(line, "MTL"), "==") + "\r\n");
                                    }
                                }
                                LogPrint("T<--M:" + Str, 1);
                            }
                        }
                        NotifyIcon.Icon = Properties.Resources.icon;
                        if (!Properties.Settings.Default.FileKeepFile)
                        {
                            System.IO.File.Delete(filename);
                        }
                    }
                }
            }
        }

        private void DataEditorbtn_Click(object sender, EventArgs e)
        {
            StringEditor se = new StringEditor();
            se.Owner = this;
            se.ShowDialog();
        }

        private void LogsCleaningTimer_Tick(object sender, EventArgs e)
        {
            string[] loglist = Directory.GetFiles(Path.GetDirectoryName(logpath), "*.log");
            foreach (string log in loglist)
            {
                DateTime start = DateTime.ParseExact(Path.GetFileNameWithoutExtension(log), "yyyyMMdd", Thread.CurrentThread.CurrentCulture);
                TimeSpan sp = DateTime.Now.Subtract(start);
                if (sp.Days > int.Parse(Properties.Settings.Default.LogsReserve))
                {
                    try
                    {
                        System.IO.File.Delete(log);
                        LogPrint("清理过期日志文件成功："+log,2);
                    }
                    catch (Exception ex)
                    {
                        LogPrint("清理过期日志文件失败：" + log, 2);
                    }
                }
            }
        }

        private void WaitLIS()
        {
            ipl = new IPEndPoint(ip, int.Parse(lisport));
            LogPrint("正在 " + ipl + " 端口启动LIS监听...", 0);
            LSocket.Bind(ipl);
            LSocket.Listen(0);
            while (true)
            {
                ucWave2.WaveColor=Color.FromArgb(255, 77, 59);
                LISIP.Clear();
                Properties.Settings.Default.LISStatus = "";
                LogPrint("正在等待LIS系统连接，请在LIS系统中启动仪器...", 0);
                LISSocket = LSocket.Accept();
                LogPrint("LIS连接成功", 0);
                ucWave2.WaveColor=Color.FromArgb(0, 155, 144);
                LISIP.Text = LISSocket.RemoteEndPoint.ToString();
                Properties.Settings.Default.LISStatus = LISSocket.RemoteEndPoint.ToString();
                while (true)
                {
                    try
                    {
                        NotifyIcon.Icon = Properties.Resources.icon;
                        string recStr = ReceiveLIS();
                        if (recStr != "" || recStr.Length > 1)
                        {
                            NotifyIcon.Icon = Properties.Resources.transfer;
                            SendMac(tm.Trans(tm.Trans(recStr, "LTM"), "=="));
                        }
                        else 
                        {
                            break;
                        }
                    }

                    catch (Exception ex)
                    {
                        LogPrint(ex.Message+",重新启动LIS监听", 0);
                        break;
                    }
                }
            }
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            SetupForm setup = new SetupForm();
            setup.Owner = this;
            setup.notifyicon = NotifyIcon;
            setup.ShowDialog();
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this,"将重启服务，确定吗？", "提示",true) == DialogResult.OK)
            {
                NotifyIcon.Visible = false;
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
        }

        private void ucBtnExt4_BtnClick(object sender, EventArgs e)
        {
            MacLogBox.Clear();
            FrmTips.ShowTipsInfo(this,"清除仪器通信日志");
        }

        private void ucBtnExt5_BtnClick(object sender, EventArgs e)
        {
            LISLogBox.Clear();
            FrmTips.ShowTipsInfo(this, "清除LIS通信日志");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "将重启服务，确定吗？", "提示", true) == DialogResult.OK)
            {
                NotifyIcon.Visible = false;
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
        }
        private void NotifyMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                string[] rest = rk2.GetValueNames();
                foreach (string line in rest)
                {
                    if (line == "JcShutdown")
                    { 设为开机启动ToolStripMenuItem.Checked = true; }
                    else { 设为开机启动ToolStripMenuItem.Checked = false; }
                }
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsWarning(this, "请使用管理员模式运行");
                //MessageBox.Show(ex.Message, "请使用管理员模式运行本程序");
            }
        }

        private void ucBtnExt6_BtnClick(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                this.MaximizeBox = true;
                this.Size = new Size(1166, 563);
                this.MinimumSize = new Size(1166, 563);
                this.FormBorderStyle = FormBorderStyle.Sizable;
                splitContainer1.Panel1Collapsed = false;
            }
            else 
            {
                this.MaximizeBox = false;
                this.MinimumSize = new Size(280, 563);
                this.Size = new Size(280, 563);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                splitContainer1.Panel1Collapsed = true;
            }
                       
        }


        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            StringEditor se = new StringEditor();
            se.Owner = this;
            se.ShowDialog();
        }

        private string ReceiveLIS()
        {
            string Str = "";
            string recStr = "";
            try
            {
                byte[] recByte = new byte[int.Parse(Properties.Settings.Default.SendBuff)];
                int bytes = LISSocket.Receive(recByte, recByte.Length, 0);
                if (Properties.Settings.Default.SendEncode == "Default")
                {
                    recStr += Encoding.Default.GetString(recByte, 0, bytes);
                }
                else
                {
                    Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.SendEncode);
                    recStr += encode.GetString(recByte, 0, bytes);
                }
                Str = recStr;
                foreach (char c in recStr)
                {
                    if ((Byte)c < 33)
                    {
                        Str = Str.Replace(c.ToString(), "<" + (c%16+c/16*10).ToString() + ">");
                    }
                }
                LogPrint("H-->T:" + Str, 0);
                return recStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string HexString2BinString(string hexString)
        {
            string result = string.Empty;
            foreach (char c in hexString)
            {
                int v = Convert.ToInt32(c.ToString(), 16);
                int v2 = int.Parse(Convert.ToString(v, 2));
                // 去掉格式串中的空格，即可去掉每个4位二进制数之间的空格，
                result += string.Format("{0:d4}", v2);
            }
            return result;
        }
        private int SendLIS(string sendStr)
        {
            try
            {
                string Str = sendStr;
                foreach (char c in sendStr)
                {
                    if ((int)c < 33)
                    {
                        Str = Str.Replace(c.ToString(), "<" + (c % 16 + c / 16 * 10).ToString() + ">");
                    }
                }
                LogPrint("H<--T:" + Str,0);
                byte[] sendByte;
                if (Properties.Settings.Default.RecEncode == "Default")
                {
                    sendByte = Encoding.Default.GetBytes(sendStr);
                    Console.WriteLine(sendStr);
                }
                else
                {
                    Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.RecEncode);
                   sendByte = encode.GetBytes(sendStr);
                }
                LISSocket.Send(sendByte, sendByte.Length, 0);
                return 1;
            }
            catch
            {
                LogPrint("发送数据到LIS失败,数据["+sendStr.Replace("\r", "<13>").Replace("\n", "<10>") + "]",0);
                return 0;
            }
        }

        private void 添加桌面快捷方式toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                FileInfo fileDesktop = new FileInfo(desktopPath + "\\"+desktopenter+".lnk");
                if (!fileDesktop.Exists)
                {
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +"\\"+desktopenter+".lnk");
                    shortcut.TargetPath = typeof(Program).Assembly.Location;
                    shortcut.WorkingDirectory = Application.StartupPath;
                    shortcut.WindowStyle = 1;
                    shortcut.Description = "iMedicalLIS";
                    shortcut.IconLocation = Application.ExecutablePath;
                    shortcut.Save();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "创建快捷方式失败"); 
                FrmTips.ShowTipsError(this, "创建快捷方式失败");
            }
        }

        private void LISLogClear_Click(object sender, EventArgs e)
        {
           
        }

        private void CleaningTimer_Tick(object sender, EventArgs e)
        {
            LISLogBox.Clear();
            MacLogBox.Clear();
            LogPrint("定时清理程序垃圾缓存开始", 2);
            ClearMemoryInfo.FlushMemory();
            LogPrint("定时清理程序垃圾缓存完成",2);
        }

        private void 数据编辑器toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StringEditor se = new StringEditor();
            se.Owner = this;
            se.ShowDialog();
        }

        private void setupbtn_Click(object sender, EventArgs e)
        {
            SetupForm setup = new SetupForm();
            setup.Owner = this;
            setup.ShowDialog();
        }


        private void TransModuleRefresh_Tick(object sender, EventArgs e)
        {
            tm.RefreshList();
        }

        private void MacLogClear_Click(object sender, EventArgs e)
        {
           
        }

        private void LogPathTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string tmppath = logpath;
                if (!Directory.Exists(Application.StartupPath + "\\logs\\"))
                { Directory.CreateDirectory(Application.StartupPath + "\\logs\\"); }
                logpath = Application.StartupPath + "\\logs\\" + System.DateTime.Now.ToString("yyyyMMdd") + ".log";
                if (logpath != tmppath && tmppath != null)
                {
                    fsw.Close();
                    fsw = new FileStream(logpath, FileMode.Append);
                    MacLogBox.Clear();
                    LISLogBox.Clear();
                }
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsError(this, "获取日志路径出错:" + ex.Message);
            }
        }

        public void LogPrint(string log,int flag)
        { 
            if (flag == 0)
            {
                this.LISLogBox.AppendText("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
            }
            if (flag == 1)
            { 
                this.MacLogBox.AppendText("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
            }
            if (flag == 2)
            { this.MacLogBox.AppendText("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
                this.LISLogBox.AppendText("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
            }
            try
            {
                byte[] writeBytes;
                if (Properties.Settings.Default.LogEncode == "Default")
                {
                   writeBytes= Encoding.Default.GetBytes("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
                }
                else
                {
                    Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.LogEncode);
                    writeBytes = encode.GetBytes("[" + System.DateTime.Now.ToString() + "]:" + log + "\r\n");
                }
                fsw.Position = fsw.Length;
                fsw.Write(writeBytes,0, writeBytes.Length);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                FrmTips.ShowTipsError(this,ex.Message);
            }
        }
    }
}
