using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using NPOI.SS.Formula.Functions;
using System.Threading;
using System.Reflection;
using NPOI.OpenXml4Net.OPC;
using NPOI.OpenXmlFormats.Spreadsheet;
using System.Dynamic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using static DataTrans.DataTransForm;

namespace DataTrans
{
    public class ConfigConsole
    {
        public FileStream fsw { get; set; }
        Server server;
        IPAddress ip = IPAddress.Parse("0.0.0.0");
        int port = int.Parse(Properties.Settings.Default.TerminalPort);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Process ps;
        PerformanceCounter pf1;
        public ConfigConsole(FileStream fsw)
        {
            this.fsw = fsw;
            server = new Server(fsw);
        }
        public void start()
        {
            //byte[] buf = new byte[20480];
            //fsw.Seek(0, SeekOrigin.Begin);
            //fsw.Read(buf, 0, (int)(fsw.Length));
            //string todaylog = Encoding.UTF8.GetString(buf);
            Thread thread = new Thread(run);
            thread.Start();
        }
        public void run()
        {
            IPEndPoint ep;
            ep = new IPEndPoint(ip, port);

            socket.Bind(ep);
            socket.Listen(0);
            while (true)
            {
                Socket conn;
                conn = socket.Accept();
                Thread newconn = new Thread(new ParameterizedThreadStart(newClient));
                newconn.Start(conn);
            }
        }
        public void newClient(object obj)
        {
            Socket conn = (Socket)obj;
            send(conn, "\r\n\r\n-------------------------------------\r\n| DataTrans Remote Terminal Service |\r\n-------------------------------------\r\n\r\n---Server Time---\r\n---" + DateTime.Now.ToString()+"---\r\n\r\n---Login---\r\n-Enter Password-");
            if (Properties.Settings.Default.TerminalPassword==""||Properties.Settings.Default.TerminalPassword.Length==0)
            {
                send(conn, "\r\n---Unsafe Terminal Password Setting---\r\n---Connection Lost---\r\n");
                conn.Close();
                return;
            }
                string password = rec(conn);
            if (password == Properties.Settings.Default.TerminalPassword)
            {
                send(conn, "\r\n---Login Success---");
                while (true)
                {
                    send(conn, "\r\n---Type Command(\"h\" \"help\" to help)---");
                    string recstr = rec(conn);
                    if (recstr != "" || recstr.Length > 0)
                    {
                        string cmd = recstr;
                        if (cmd == "restart")
                        {
                            send(conn, "\r\n---Restart Request---\r\n-Enter Password-");
                            if (rec(conn) == Properties.Settings.Default.TerminalPassword)
                            {
                                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                Environment.Exit(0);
                            }
                            else
                            {
                                send(conn, "\r\n---Incorrect key---");
                                continue;
                            }
                        }
                        if (cmd == "quit")
                        {
                            send(conn, "\n---Log out---\r\n---Bye---");
                            conn.Close();
                            break;
                        }
                        if (cmd.Contains( "remote log on"))
                        {
                            if (cmd.Split(' ').Length == 4)
                            {
                                Properties.Settings.Default.RemoteLogPort = cmd.Split(' ')[3];
                                Properties.Settings.Default.Save();
                            }    
                            if (!server.running)
                            { server.start(IPAddress.Parse("0.0.0.0"), int.Parse(Properties.Settings.Default.RemoteLogPort), 5, Environment.CurrentDirectory); }
                            Properties.Settings.Default.RemoteLog = true;
                            send(conn, "\r\n-Remote Log is now on Port:"+Properties.Settings.Default.RemoteLogPort+"-\r\n");
                        }
                        if (cmd == "remote log off")
                        {
                            if (server.running)
                            { server.stop(); }
                            Properties.Settings.Default.RemoteLog = false;
                            send(conn, "\r\n-Remote Log is now off-\r\n");
                        }
                        if (cmd == "help"||cmd=="h"||cmd=="H")
                        {
                            send(conn, "\r\n---Command List---\t" +
                                "\t\r\n---\"*\" must be filled---" +
                                "\t\r\n\"shutdown service\" \t\t -shutdown the service" +
                                "\t\r\n\"quit\" \t\t\t\t -log out the remote terminal" +
                                "\t\r\n\"clean cache\" \t\t\t -clean memory cache" +
                                "\t\r\n\"remote log on [port]\" \t\t -turn on the remote log view on port" +
                                "\t\r\n\"remote log off\" \t\t -turn off the remote log view" +
                                "\t\r\n\"restart\" \t\t\t -remote restart service" +
                                "\t\r\n\"version\" \t\t\t -check version" +
                                "\t\r\n\"status\" \t\t\t -view service status" +
                                "\t\r\n\"display all\" \t\t\t -display all settings" +
                                "\t\r\n\"display [*key],[key]\" \t\t -display picked setting(s)" +
                                "\t\r\n\"set [*key]=[*value]\" \t\t -remote set key's value" +
                                "\t\r\n\"reset all\" \t\t\t -reset all settings" +
                                "\t\r\n\"reset [*key],[key]\" \t\t -reset key(s)" +
                                "\t\r\n\"startup\" \t\t\t -switch windows startup" +
                                "\t\r\n\"trans list\" \t\t\t -show trans mission list" +
                                "\t\r\n\"trans active [*id],[id]\" \t -active trans mission(s)" +
                                "\t\r\n\"trans cancel [*id],[id]\" \t -cancel trans mission(s)" +
                                "\t\r\n\"trans remove [*id],[id]\" \t -remove trans mission(s)"+
                                "\t\r\n\"trans add [*oldstring] [*direction] [*newstring] [*info]\"\r\n\t\t\t\t -add trans mission (direction=\"LTM\"\"MTL\"\"==\")");
                        }
                        if (cmd == "version")
                        {
                            send(conn, "\r\n-MachineName:" + Properties.Settings.Default.MachineName + "\r\n-Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\r\n");
                        }
                        if (cmd == "status")
                        {
                            string mac = Properties.Settings.Default.MacStatus;
                            string lis = Properties.Settings.Default.LISStatus;
                            string msg = "\r\n---Connect Status View---\r\n-Machine Status:";
                            if (mac == "")
                            { msg += "false\r\n"; }
                            else
                            {
                                msg += "true\r\n";
                                msg += "-Machine Client:" + mac+"\r\n";
                            }
                            msg += "-LIS Status:";
                            if (lis == "")
                            {
                                msg += "false\r\n";
                            }
                            else
                            {
                                msg += "true";
                                msg += "-LIS Client:" + lis + "\r\n";
                            }
                            msg += "\r\n---Start Time---\r\n" + Properties.Settings.Default.StartTime.ToString() + "\r\n";
                            ps = Process.GetCurrentProcess();
                            pf1= new PerformanceCounter("Process", "Working Set - Private", ps.ProcessName);
                            msg += "\r\n---Physic Memory Used---\r\n" +( pf1.NextValue()/(1024*1024)) + "MB";
                            ps.Close();
                            pf1.Close();
                            pf1.Dispose();
                            ps.Dispose();
                            send(conn, msg);
                        }
                       
                        if (cmd.Contains("display"))
                        {
                            if (cmd == "display all")
                            {
                                string msg = "\r\n---Settings List---\r\n";
                                System.Configuration.SettingsPropertyValueCollection values = Properties.Settings.Default.PropertyValues;
                                foreach (object set in values)
                                {
                                    if (!(((System.Configuration.SettingsPropertyValue)set).Name.Contains("Password") || ((System.Configuration.SettingsPropertyValue)set).Name.Contains("Status")))
                                    {
                                        msg += ((System.Configuration.SettingsPropertyValue)set).Name + ":" + ((System.Configuration.SettingsPropertyValue)set).PropertyValue + "\r\n";
                                    }
                                }
                                msg += "---List Load Done---";
                                send(conn, msg);
                            }
                            else
                            {
                                if (cmd.Split(' ').Count() > 1)
                                {
                                    string list = "," + cmd.Split(' ')[1] + ",";
                                    string msg = "\r\n---Settings List---\r\n";
                                    System.Configuration.SettingsPropertyValueCollection values = Properties.Settings.Default.PropertyValues;
                                    foreach (object set in values)
                                    {
                                        if (!(((System.Configuration.SettingsPropertyValue)set).Name.Contains("Password") || ((System.Configuration.SettingsPropertyValue)set).Name.Contains("Status")))
                                        {
                                            if (list.Contains("," + ((System.Configuration.SettingsPropertyValue)set).Name + ","))
                                            {
                                                msg += ((System.Configuration.SettingsPropertyValue)set).Name + ":" + ((System.Configuration.SettingsPropertyValue)set).PropertyValue + "\r\n";
                                            }
                                        }
                                    }
                                    msg += "---List Load Done---";
                                    send(conn, msg);
                                }
                            }
                        }
                        if (cmd.Contains("set") && cmd.Split('=').Length == 2)
                        {
                            System.Configuration.SettingsPropertyValueCollection values = Properties.Settings.Default.PropertyValues;
                            foreach (object set in values)
                            {
                                if (!(((System.Configuration.SettingsPropertyValue)set).Name.Contains("Password") || ((System.Configuration.SettingsPropertyValue)set).Name.Contains("Status")))
                                {
                                    if (((System.Configuration.SettingsPropertyValue)set).Name == cmd.Split('=')[0].Split(' ')[1])
                                    {
                                        bool result = false;
                                        if (Boolean.TryParse(cmd.Split('=')[1], out result))
                                        {
                                            ((System.Configuration.SettingsPropertyValue)set).PropertyValue = result;
                                        }
                                        else
                                        {
                                            ((System.Configuration.SettingsPropertyValue)set).PropertyValue = cmd.Split('=')[1];
                                        }
                                        Properties.Settings.Default.Save();
                                        send(conn, "\r\n---Remote Set Up---\r\n-" + ((System.Configuration.SettingsPropertyValue)set).Name + "="+((System.Configuration.SettingsPropertyValue)set).PropertyValue + "\r\n");      
                                    }
                                }
                            }
                           
                        }
                        if (cmd.Contains("reset"))
                        {
                            if (cmd.Contains(" all"))
                            {
                                System.Configuration.SettingsPropertyValueCollection values = Properties.Settings.Default.PropertyValues;
                                foreach (object set in values)
                                {
                                    bool result = false;
                                    if (Boolean.TryParse(((System.Configuration.SettingsPropertyValue)set).Property.DefaultValue.ToString(), out result))
                                    {
                                        ((System.Configuration.SettingsPropertyValue)set).PropertyValue = result;
                                    }
                                    else 
                                    {
                                        ((System.Configuration.SettingsPropertyValue)set).PropertyValue = ((System.Configuration.SettingsPropertyValue)set).Property.DefaultValue;
                                    }                                     
                                }
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                if (cmd.Split(' ').Count()> 1)
                                {
                                    string rest = "," + cmd.Split(' ')[1] + ",";
                                    System.Configuration.SettingsPropertyValueCollection values = Properties.Settings.Default.PropertyValues;
                                    foreach (object set in values)
                                    {
                                        if (rest.Contains("," + ((System.Configuration.SettingsPropertyValue)set).Name + ","))
                                        {
                                            bool result = false;
                                            if (Boolean.TryParse(((System.Configuration.SettingsPropertyValue)set).Property.DefaultValue.ToString(), out result))
                                            {
                                                ((System.Configuration.SettingsPropertyValue)set).PropertyValue = result;
                                            }
                                            else
                                            {
                                                ((System.Configuration.SettingsPropertyValue)set).PropertyValue = ((System.Configuration.SettingsPropertyValue)set).Property.DefaultValue;
                                            }
                                        }
                                    }
                                    Properties.Settings.Default.Save();
                                }
                            }
                            send(conn, "\r\n---Reset Settings Complete---\r\n");
                        }
                        if (cmd == "startup")
                        {
                            try
                            {
                                if (Properties.Settings.Default.Startup== false) //设置开机自启动  
                                {
                                    string path = Application.ExecutablePath;
                                    RegistryKey rk = Registry.LocalMachine;
                                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                                    rk2.SetValue("JcShutdown", path);
                                    rk2.Close();
                                    rk.Close();
                                    Properties.Settings.Default.Startup = true;
                                    send(conn, "\r\n---Startup setup---\r\n");
                                }
                                else //取消开机自启动  
                                {
                                    string path = Application.ExecutablePath;
                                    RegistryKey rk = Registry.LocalMachine;
                                    RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                                    rk2.DeleteValue("JcShutdown", false);
                                    rk2.Close();
                                    rk.Close();
                                    Properties.Settings.Default.Startup= false;
                                    send(conn, "\r\n---Startup cancel---\r\n");
                                }
                               
                            }
                            catch (Exception ex)
                            {
                                send(conn, "\r\n---Startup setup failed---\r\n");
                            }
                        }
                        if(cmd=="trans list")
                        {
                            DataSet ds = AcceseDatabase.GetAll();
                            string direc = "";
                            string status = "";
                            string msg = "\r\n---数据转换任务列表---\r\n序号\t旧字符串\t方向\t\t\t新字符串\t说明\t\t激活状态\r\n";
                            for (int i = 0; i < ds.Tables["TransData"].Rows.Count; i++)//遍历BookInfo中所有行
                            {
                                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "LTM") { direc = "LIS>>仪器"; }
                                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "MTL") { direc = "仪器>>LIS"; }
                                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "==") { direc = "LIS==仪器"; }
                                if (ds.Tables["TransData"].Rows[i]["ActiveStatus"].ToString() == "active") { status = "激活"; }
                                if (ds.Tables["TransData"].Rows[i]["ActiveStatus"].ToString() == "cancel") { status = "未激活"; }
                                ListViewItem lvi = new ListViewItem();
                                lvi.SubItems[0].Text = ds.Tables["TransData"].Rows[i]["ID"].ToString();
                                lvi.SubItems.AddRange
                                (new string[]{
                                ds.Tables["TransData"].Rows[i]["MacString"].ToString(),
                                direc,
                                ds.Tables["TransData"].Rows[i]["LISString"].ToString(),
                                ds.Tables["TransData"].Rows[i]["Note"].ToString(),
                                status,
                                });
                                msg += ds.Tables["TransData"].Rows[i]["ID"].ToString() +"\t"+ ds.Tables["TransData"].Rows[i]["MacString"].ToString() +"\t\t"+ direc +"\t\t"+ ds.Tables["TransData"].Rows[i]["LISString"].ToString() +"\t\t"+ ds.Tables["TransData"].Rows[i]["Note"].ToString() +"\t\t"+ status+"\r\n";
                            }
                            msg += "---list load done---\r\n";
                            send(conn,msg);
                        }
                        if (cmd.Contains("trans active"))
                        {
                            if (cmd.Split(' ').Count() != 3)
                            {
                                send(conn, "\r\n---Invalid Options---");
                            }
                            else
                            {
                                string list = cmd.Split(' ')[2];
                                foreach (string a in list.Split(','))
                                {
                                    AcceseDatabase.ToggleActive(a, "active");
                                    send(conn, "\r\n-Active Trans Mission " + a);
                                }
                                send(conn, "\r\n---Active Done---");
                            }
                        }
                        if (cmd.Contains("trans cancel"))
                        {
                            if (cmd.Split(' ').Count() != 3)
                            {
                                send(conn, "\r\n---Invalid Options---");
                            }
                            else
                            {
                                string list = cmd.Split(' ')[2];
                                foreach (string a in list.Split(','))
                                {
                                    AcceseDatabase.ToggleActive(a, "cancel");
                                    send(conn, "\r\n-Cancel Trans Mission " + a);
                                }
                                send(conn, "\r\n---Cancel Done---");
                            }
                        }
                        if (cmd.Contains("trans add"))
                        {
                            if (cmd.Split(' ').Length == 6)
                            {
                                AcceseDatabase.InsertItem(cmd.Split(' ')[2], cmd.Split(' ')[3], cmd.Split(' ')[4], cmd.Split(' ')[5]);
                                send(conn, "\r\n---Insert New Mission Done---");
                            }
                            else
                            {
                                send(conn, "\r\n---Invalid Options---");
                            }
                        }
                        if (cmd.Contains("trans remove"))
                        {
                            if (cmd.Split(' ').Count() != 3)
                            {
                                send(conn, "\r\n---Invalid Options---");
                            }
                            else
                            {
                                string list = cmd.Split(' ')[2];
                                foreach (string a in list.Split(','))
                                {
                                    AcceseDatabase.RemoveItem(a);
                                    send(conn, "\r\n-Remove Trans Mission " + a);
                                }
                                send(conn, "\r\n---Remove Done---");
                            }
                        }
                        if (cmd == "shutdown service")
                        {
                            send(conn, "\r\n!!! Warning: You are Request to Shut the Service Down!!!\r\n!! Enter Password !!");
                            if (rec(conn) == Properties.Settings.Default.TerminalPassword)
                            {
                                send(conn, "\r\n---Service Shutdown Now---");
                                Environment.Exit(0);
                            }
                            else
                            {
                                send(conn, "\r\n---Incorrect key---");
                                continue;
                            }
                        }
                        if (cmd == "clean cache")
                        {
                            ClearMemoryInfo.FlushMemory();
                            send(conn,"\r\n---Clean Cache Done---");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                send(conn, "\r\nIncorrect key\r\nLog out\r\nBye");
                conn.Close();
                return;
            }
}
        public void send(Socket conn, string msg)
        {
            try
            {
                byte[] byffer = Encoding.UTF8.GetBytes(msg);
                conn.Send(byffer, byffer.Length, 0);
            }
            catch
            { 
            }
        }
        public string rec(Socket conn)
        {
            string recStr = "";
            try
            {
                byte[] recByte = new byte[int.Parse(Properties.Settings.Default.SendBuff)];
                int bytes = conn.Receive(recByte, recByte.Length, 0);
                recStr += Encoding.UTF8.GetString(recByte, 0, bytes);
                return recStr;
            }
            catch
            {
                return "";
            }
        }
    }
}
