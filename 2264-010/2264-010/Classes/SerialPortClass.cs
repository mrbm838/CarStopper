using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace 通讯协议.串口
{
    public class SerialPortClass
    {
        public delegate void SerialPortDelegate(string msgStr, string portName);
        /// <summary>
        /// 接收数据事件
        /// </summary>
        public event SerialPortDelegate ReceiveEvent;
        public string ComName = "";
        public string strData = string.Empty;
        int baudRate1 = 9600;

        SerialPort serialPort;
        Thread th_ReceiveData;
        /// <summary>
        /// 判断串口是否存在
        /// </summary>
        bool IsSerialPortName(string com)
        {
            try
            {
                string[] PortNames = System.IO.Ports.SerialPort.GetPortNames();
                int num_ = Array.IndexOf(PortNames, com);
                if (num_ >= 0) { return true; }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName">串口号</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验</param>
        /// <param name="stopBits">停止位</param>
        /// <param name="dataBits">数据位</param>
        public bool Open(string portName, int baudRate, Parity parity, StopBits stopBits, int dataBits)
        {
            try
            {
                baudRate1 = baudRate;
                try { Close(); } catch { }
                if (IsSerialPortName(portName))
                {
                    serialPort = new SerialPort();
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.Parity = parity;
                    serialPort.StopBits = stopBits;
                    serialPort.DataBits = dataBits;
                    serialPort.WriteTimeout = 1000;
                    serialPort.ReadBufferSize = 2000;

                    serialPort.Open();
                    ComName = portName;
                    th_ReceiveData = new Thread(ReceiveData);
                    th_ReceiveData.IsBackground = true;
                    th_ReceiveData.Start();
                    return true;
                }
            }
            catch { }
            try { Close(); } catch { }
            return false;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            try
            {
                //if (isSerialPortName(ComName))
                //{
                if (serialPort != null)
                {
                    serialPort.Close();
                }
                //}
            }
            catch { }

            try
            {
                try { Flag_Receive = false; } catch { }
                if (serialPort != null)
                {
                    try { serialPort.ReadTimeout = 0; } catch { }
                }
                Thread.Sleep(10);
                if (th_ReceiveData != null)
                {
                    try { th_ReceiveData.Abort(); } catch { }
                }
            }
            catch { }
        }

        bool Flag_Receive = false;
        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveData()
        {
            try
            {
                Flag_Receive = true;
                serialPort.ReadTimeout = -1;
                string getStr = "";
                while (Flag_Receive)
                {
                    try
                    {
                        byte firstByte = Convert.ToByte(serialPort.ReadByte());
                        try
                        {
                            int bytesRead = serialPort.BytesToRead;
                            byte[] bytesData = new byte[bytesRead + 1];
                            bytesData[0] = firstByte;
                            for (int i = 1; i <= bytesRead; i++)
                            {
                                bytesData[i] = Convert.ToByte(serialPort.ReadByte());
                            }

                            if (getStr.Length < 10000)
                            {
                                getStr += System.Text.Encoding.Default.GetString(bytesData);
                                strData = getStr;
                                //for(int i=0;i<bytesData.Count();i++)
                                //{
                                //    string str_ = String.Format("{0:X}", bytesData[i]);
                                //    if (str_.Length == 1) { str_="0"+str_; }
                                //    getStr += str_ + " ";
                                //}
                            }

                            if (bytesData[bytesRead] == 0X0A)//换行符未结束符号
                            {
                                ReceiveEvent(getStr, ComName);
                                getStr = "";
                            }
                            //if (bytesData[bytesRead] == 0X16)//LM-Q 系列 485输出 结束码为0x16
                            //{
                            //    ReceiveEvent(getStr.Replace("\r","").Replace("\n", ""), ComName);
                            //    getStr = "";
                            //}
                            if (Flag_Receive) { Thread.Sleep(10); }
                        }
                        catch { }
                    }
                    catch
                    {
                        Flag_Receive = false;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 发送字符串数据
        /// </summary>
        public void SendStringData(string str)
        {
            try
            {
                if (IsSerialPortName(ComName))
                {
                    serialPort.Write(str);
                    return;
                }
            }
            catch { }
            try
            {
                if (Open(ComName, baudRate1, System.IO.Ports.Parity.None, System.IO.Ports.StopBits.One, 8))
                {
                    serialPort.Write(str);
                    return;
                }
            }
            catch { }
        }

        /// <summary>
        /// 发送二进制数据
        /// </summary>
        public void SendBytesData(string str)
        {
            try
            {
                if (IsSerialPortName(ComName))
                {
                    byte[] bytesSend = System.Text.Encoding.Default.GetBytes(str);
                    serialPort.Write(bytesSend, 0, bytesSend.Length);
                }
            }
            catch { }
        }

        /// <summary>
        /// 发送16进制数据
        /// </summary>
        public void SendHexBytesData(string str)
        {
            try
            {
                if (IsSerialPortName(ComName))
                {
                    byte[] bytesSend = strToToHexByte(str);
                    serialPort.WriteTimeout = 1000;
                    serialPort.Write(bytesSend, 0, bytesSend.Length);
                }
            }
            catch { }
        }

        /// <summary> 
        /// 字符串转16进制字节数组 
        /// </summary> 
        /// <param name="hexString"></param> 
        /// <returns></returns> 
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Substring(0, 2) == "0x" || hexString.Substring(0, 2) == "0X")
                hexString = hexString.Substring(2, hexString.Length - 2);
            byte[] returnBytes = new byte[hexString.Length / 2];
            try
            {
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                //returnBytes[returnBytes.Length - i - 1] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            catch
            {
                return null;
            }
            return returnBytes;
        }

        /// <summary> 
        /// 获取当前计算机的串行端口名的数组
        /// </summary> 
        /// <param name=""></param> 
        /// <returns></returns> 
        public string[] check()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }
    }
}
