using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTrans
{
    public class SerialPortDeal
    {
        public SerialPort sp;
        public DataTransForm form;
        public bool isOpen = false;

        public SerialPortDeal(string portno,string baudrate,string paritycheck,string databit,string stopbit,bool RTSEnable)
        {
            
            Parity parity;
            StopBits bits;
            
            switch (paritycheck)
            {
                case "none":
                    parity = Parity.None;
                    break;
                case "even":
                    parity = Parity.Even;
                    break;
                case "odd":
                    parity = Parity.Odd;
                    break;
                case "space":
                    parity = Parity.Space;
                    break;
                case "mark":
                    parity = Parity.Mark;
                    break;
                default:
                    parity = Parity.None;
                    break;
            }
            switch (stopbit)
            {
                case "none":
                    bits = StopBits.None;
                    break;
                case "1":
                    bits = StopBits.One;
                    break;
                case "1.5":
                    bits = StopBits.OnePointFive;
                    break;
                case "2":
                    bits = StopBits.Two;
                    break;
                default:
                    bits = StopBits.One;
                    break;
            }
            sp = new SerialPort(portno,int.Parse(baudrate),parity,int.Parse(databit),bits);
            sp.RtsEnable = RTSEnable;
            sp.ReadTimeout = -1;
            
        }
        
        public void send(string sendstr)
        {
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            byte[] writeBytes = utf8.GetBytes(sendstr);
            sp.Write(writeBytes, 0, writeBytes.Length); //发送数据内容
        }

        public void open()
        {
            try //打开串口
            {
                sp.Open();
                isOpen = true;
                //串口打开后相关的串口设置按钮不再可选择
            }
            catch (Exception ex)
            {   //失败后设置
                isOpen = false;
                //return ex.Message;
                throw ex;
            }
        }
    }
}
