using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.VisualBasic;
using HZH_Controls.Forms;
using HZH_Controls.Controls;
using NPOI.SS.Formula.Functions;
using HZH_Controls;

namespace DataTrans
{
    public partial class SetupForm : Form
    {
        public object notifyicon;
        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            ucPanelTitle1.IsExpand = true;
            MachineName.Text = Properties.Settings.Default.MachineName;
            ProgramName.Text = Properties.Settings.Default.ProgramName;
            ShortcutName.Text = Properties.Settings.Default.ShortcutName;
            CleaningTimer.Value = int.Parse(Properties.Settings.Default.CleaningTimer) / 60000;
            ApplyTimer.Value = int.Parse(Properties.Settings.Default.ApplyTimer) / 1000;
            serverport.Text = Properties.Settings.Default.ServerPort.ToString();
            clientip.Text = Properties.Settings.Default.ClientIP;
            clientport.Text = Properties.Settings.Default.ClientPort.ToString();
            clienttimer.Value = int.Parse(Properties.Settings.Default.ClientTimer)/1000;
            filepath.Text = Properties.Settings.Default.FilePath;
            filewritepath.Text = Properties.Settings.Default.FileWritePath;
            filetimer.Value = int.Parse(Properties.Settings.Default.FileTimer) / 1000;
            filenameextension.Text = Properties.Settings.Default.FileNameExtension;
            filewriteextension.Text = Properties.Settings.Default.FileWriteExtension;
            keepfile.Checked = Properties.Settings.Default.FileKeepFile;
            if (!comboBox1.Items.Contains(Properties.Settings.Default.SerialBaudRate))
            {
                comboBox1.Items.Add(Properties.Settings.Default.SerialBaudRate);
            }
            comboBox1.SelectedItem = Properties.Settings.Default.SerialBaudRate;
            comboBox2.SelectedItem = Properties.Settings.Default.SerialParityCheck;
            comboBox3.SelectedItem = Properties.Settings.Default.SerialDataBit;
            comboBox4.SelectedItem = Properties.Settings.Default.SerialStopBit;
            SendBuff.SelectedItem =Properties.Settings.Default.SendBuff;
            textBox1.Text = Properties.Settings.Default.TerminalPassword;
            textBox2.Text = Properties.Settings.Default.TerminalPort.ToString() ;
            LogsReserve.Value = int.Parse(Properties.Settings.Default.LogsReserve);
            LISport.Text = Properties.Settings.Default.LISport.ToString();
            FileConnectLIS.Checked = Properties.Settings.Default.FileConnectLIS;
            FileClassMethod.Text = Properties.Settings.Default.FileClassMethod;
            HostandPort.Text = Properties.Settings.Default.CacheHost + ":" + Properties.Settings.Default.CachePort;
            Namespace.Text = Properties.Settings.Default.CacheNamespace;
            UserID.Text = Properties.Settings.Default.CacheUserID;
            MachineID.Text = Properties.Settings.Default.FileMI;
            comboBox6.SelectedIndex = int.Parse(Properties.Settings.Default.MainPage);
            ucSwitch1.Checked = Properties.Settings.Default.SerialRTSEnable;
            bool comExist = false;
            comboBox5.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    comboBox5.Items.Add("COM" + (i + 1).ToString());
                    comExist = true;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            
            if (comExist)
            {
                
                comboBox5.SelectedItem = Properties.Settings.Default.SerialPortNo;
            }

            if (!comboBox5.Items.Contains(Properties.Settings.Default.SerialPortNo))
            {
                comboBox5.Items.Add(Properties.Settings.Default.SerialPortNo);
                comboBox5.SelectedItem = Properties.Settings.Default.SerialPortNo;
            }
            switch (int.Parse(Properties.Settings.Default.ConnectWay))
            {
                case 0:
                    checkBox2.Checked = true;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox2.Enabled = false;
                    break;
                case 1:
                    checkBox2.Checked = false;
                    checkBox1.Checked = true;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox1.Enabled = false;
                    break;
                case 2:
                    checkBox2.Checked = false;
                    checkBox1.Checked = false;
                    checkBox3.Checked = true;
                    checkBox4.Checked = false;
                    checkBox3.Enabled = false;
                    break;
                case 3:
                    checkBox2.Checked = false;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = true;
                    checkBox4.Enabled = false;
                    break;
            }
        }


        private void filenameextension_TextChanged(object sender, EventArgs e)
        {
            if (filenameextension.Text != Properties.Settings.Default.FileNameExtension)
            {
                Properties.Settings.Default.FileNameExtension = filenameextension.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void filetimer_ValueChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FileTimer != (filetimer.Value * 1000).ToString())
            {
                Properties.Settings.Default.FileTimer = (filetimer.Value * 1000).ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void keepfile_CheckedChanged(object sender, EventArgs e)
        {
            if (keepfile.Checked != Properties.Settings.Default.FileKeepFile)
            {
                Properties.Settings.Default.FileKeepFile = keepfile.Checked;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void serverport_TextChanged(object sender, EventArgs e)
        {
            if (serverport.Text.Length > 0)
            {
                if (serverport.Text != Properties.Settings.Default.ServerPort)
                {
                    Properties.Settings.Default.ServerPort =serverport.Text;
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                }
            }
        }

        private void clientport_TextChanged(object sender, EventArgs e)
        {
            if (clientport.Text.Length > 0)
            {
                if (clientport.Text != Properties.Settings.Default.ClientPort)
                {
                    Properties.Settings.Default.ClientPort = clientport.Text;
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                }
            }
        }

        private void clienttimer_ValueChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ClientTimer != (clienttimer.Value * 1000).ToString())
            {
                Properties.Settings.Default.ClientTimer = (clienttimer.Value * 1000).ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void clientip_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(clientip.Text);
                if (Properties.Settings.Default.ClientIP != clientip.Text)
                {
                    try
                    {
                        Properties.Settings.Default.ClientIP = clientip.Text;
                        Properties.Settings.Default.Save();
                        FrmTips.ShowTipsSuccess(this, "设置已保存");
                    }
                    catch (Exception ex)
                    {
                        FrmTips.ShowTipsError(this, "设置保存失败:" + ex.Message);
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        private void filewriteextension_TextChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FileWriteExtension != filewriteextension.Text)
            {
                Properties.Settings.Default.FileWriteExtension = filewriteextension.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SerialPortNo != comboBox5.SelectedItem.ToString())
            {
                Properties.Settings.Default.SerialPortNo = comboBox5.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SerialBaudRate != comboBox1.SelectedItem.ToString())
            {
                Properties.Settings.Default.SerialBaudRate = comboBox1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SerialParityCheck != comboBox2.SelectedItem.ToString())
            {
                Properties.Settings.Default.SerialParityCheck = comboBox2.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SerialDataBit != comboBox3.SelectedItem.ToString())
            {
                Properties.Settings.Default.SerialDataBit = comboBox3.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SerialStopBit != comboBox4.SelectedItem.ToString())
            {
                Properties.Settings.Default.SerialStopBit = comboBox4.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.MachineName = MachineName.Text;
                Properties.Settings.Default.ProgramName = ProgramName.Text;
                Properties.Settings.Default.ShortcutName = ShortcutName.Text;
                Properties.Settings.Default.CleaningTimer = (CleaningTimer.Value * 60000).ToString();
                Properties.Settings.Default.ApplyTimer = (ApplyTimer.Value * 1000).ToString();
                Properties.Settings.Default.SendBuff = SendBuff.SelectedItem.ToString();
                Properties.Settings.Default.LogsReserve = LogsReserve.Value.ToString();
                Properties.Settings.Default.LISport =LISport.Text;
                Properties.Settings.Default.TerminalPort = textBox2.Text;
                Properties.Settings.Default.MainPage = comboBox6.SelectedIndex.ToString();
                Properties.Settings.Default.TerminalPassword = textBox1.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
                //MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                FrmTips.ShowTipsError(this, "设置保存失败:" + ex.Message);
                //MessageBox.Show("保存失败：" + ex.Message);
            }
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            MachineName.Text = Properties.Settings.Default.MachineName;
            ProgramName.Text = Properties.Settings.Default.ProgramName;
            ShortcutName.Text = Properties.Settings.Default.ShortcutName;
            CleaningTimer.Value = int.Parse(Properties.Settings.Default.CleaningTimer )/ 60000;
            ApplyTimer.Value = int.Parse(Properties.Settings.Default.ApplyTimer) / 1000;
        }

        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                //Console.WriteLine(path);
                try
                {
                    System.IO.File.Delete(path);
                    System.IO.File.Copy(openFileDialog1.FileName, path);
                }
                catch (Exception ex)
                {
                    FrmTips.ShowTipsError(this, "导入设置失败:" + ex.Message);
                    //MessageBox.Show(ex.Message);
                }
                ((NotifyIcon)notifyicon).Visible = false;
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
        }

        private void ucBtnExt4_BtnClick(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Delete(saveFileDialog1.FileName);
                    }
                    System.IO.File.Copy(path, saveFileDialog1.FileName);
                    FrmTips.ShowTipsSuccess(this, "设置已导出:" + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    FrmTips.ShowTipsError(this, "设置导出错误:" + saveFileDialog1.FileName);
                }
            }
        }

        private void ucBtnExt5_BtnClick(object sender, EventArgs e)
        {
            FrmInputs frm = new FrmInputs("输入数据库密码",
               new string[] { "Cache密码" },
                new Dictionary<string, HZH_Controls.TextInputType>() { { "Cache密码",HZH_Controls.TextInputType.NotControl} },
               new Dictionary<string, string>() { },
               new Dictionary<string, KeyBoardType>() { { "Cache密码", KeyBoardType.UCKeyBorderAll_EN } },
               new List<string>() { "Cache密码" });
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.FileConnectLIS = FileConnectLIS.Checked;
                Properties.Settings.Default.FileClassMethod = FileClassMethod.Text;
                Properties.Settings.Default.FileMI = MachineID.Text;
                Properties.Settings.Default.CacheHost = HostandPort.Text.Split(':')[0];
                Properties.Settings.Default.CachePort = HostandPort.Text.Split(':')[1];
                Properties.Settings.Default.CacheNamespace = Namespace.Text;
                Properties.Settings.Default.CacheUserID = UserID.Text;
                Properties.Settings.Default.CachePassword = frm.Values[0];
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
                ucPanelTitle1.IsExpand = false;
            }
        }

        private void ucBtnExt6_BtnClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.FilePath = filepath.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void ucBtnExt7_BtnClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                filewritepath.Text = folderBrowserDialog2.SelectedPath;
                Properties.Settings.Default.FileWritePath = filewritepath.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void checkBox2_CheckedChangeEvent(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (Properties.Settings.Default.ConnectWay != "0")
                {
                    Properties.Settings.Default.ConnectWay = "0";
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                }
            }
        }

        private void checkBox1_CheckedChangeEvent(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                if (Properties.Settings.Default.ConnectWay != "1")
                {
                    Properties.Settings.Default.ConnectWay = "1";
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                }
            }
        }

        private void checkBox4_CheckedChangeEvent(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                if (Properties.Settings.Default.ConnectWay != "3")
                {
                    Properties.Settings.Default.ConnectWay = "3";
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = false;
                }
            }
        }

        private void checkBox3_CheckedChangeEvent(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                if (Properties.Settings.Default.ConnectWay != "2")
                {
                    Properties.Settings.Default.ConnectWay = "2";
                    Properties.Settings.Default.Save();
                    FrmTips.ShowTipsSuccess(this, "设置已保存");
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox4.Checked = false;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = false;
                    checkBox4.Enabled = true;
                }
            }
        }

        private void LogsReserve_MouseEnter(object sender, EventArgs e)
        {
            FrmAnchorTips.ShowTips(LogsReserve, LogsReserve.Value + "天", AnchorTipsLocation.LEFT, Color.FromArgb(0, 155, 144), null, null, 10, 1000, true);
        }

        private void ucBtnExt8_BtnClick(object sender, EventArgs e)
        {
            comboBox1.Items.Add(comboBox1.Text);
            if (Properties.Settings.Default.SerialBaudRate != comboBox1.Text)
            {
                Properties.Settings.Default.SerialBaudRate = comboBox1.Text;
                Properties.Settings.Default.Save();
                FrmTips.ShowTipsSuccess(this, "设置已保存");
            }
        }

        private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SerialRTSEnable = ucSwitch1.Checked;
            Properties.Settings.Default.Save();
            FrmTips.ShowTipsSuccess(this, "设置已保存");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
