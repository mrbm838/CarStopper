using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace cowain.FlowWork
{
    public class NetSocket// : NetClient
    {
        public delegate void SocketDelegate(string msgStr);
        //IP地址和端口号（用于服务器端）
        private IPEndPoint ServerInfo;
        //客户端运行的Socket
        public Socket ClientSocket;
        //接收缓冲区大小
        private Byte[] MsgReceiveBuffer;
        //发送缓冲区大小
        private Byte[] MsgSendBuffer;
        public bool connectOk;
        public string RemoteStrIP { get; set; }
        public Int32 RemotePort { get; set; }
        public string SN = "";
        public event SocketDelegate receiveDoneSocketEvent;
        public event SocketDelegate waitConnectEvent;
        public event SocketDelegate sendDone;
        public string StrBack = "";
        public bool TCPStatic = false;
        private object locker = new object();

        public bool b_Ascii { get; set; } = false;


        public NetSocket(bool b=false)
        {
            MsgReceiveBuffer = new Byte[65535];
            MsgSendBuffer = new Byte[65535];
            b_Ascii = b;
        }

        public void Open(string strIP, Int32 port)
        {
            this.RemoteStrIP = strIP;
            this.RemotePort = port;
            if (!connectOk)
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //实例化一个IP地址和端口号（用于服务器端）
                ServerInfo = new IPEndPoint(IPAddress.Parse(this.RemoteStrIP), this.RemotePort);
                try
                {
                    //通过“套接字”“根据IP地址和端口号”连接服务器
                    ClientSocket.Connect(ServerInfo);
                    if (waitConnectEvent != null)
                    {
                        waitConnectEvent("连接服务器 " + ServerInfo.ToString() + " 成功");
                        SaveNetClientLog("IP:" + RemoteStrIP + "Port:" + RemotePort + "   服务器连接成功！");
                    }
                    //从服务器端异步接收返回的消息（通过“ReceiveCallBack”方法异步接收消息）
                    if (!b_Ascii)
                    {
                        ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                    }
                    else
                    {
                        ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBackASCII), null);
                    }
                    
                    connectOk = true;
                    TCPStatic = true;
                }
                catch (Exception ex)
                {
                    if (waitConnectEvent != null)
                    {
                        waitConnectEvent("服务器" + ServerInfo.ToString() + "无响应");
                        SaveNetClientLog("IP:" + RemoteStrIP + "Port:" + RemotePort + ServerInfo.ToString() + "服务器 无响应");
                    }
                }
            }
        }

        private void ReceiveCallBackASCII(IAsyncResult ar)
        {
            try
            {

                //结束接收（返回接收数据的大小）
                int REnd = ClientSocket.EndReceive(ar);
                //MessageBox.Show(REnd.ToString());
                if (REnd == 0 && connectOk)
                {
                    connectOk = false;
                    TCPStatic = false;
                    //  ClientSocket.Shutdown(SocketShutdown.Both);
                    Thread.Sleep(10);
                    // ClientSocket.Disconnect(false);
                    ClientSocket.Close();
                    //  ClientSocket = null;
                    if (waitConnectEvent != null)
                    {
                        SaveNetClientLog("【接收到信息时，服务器断开了连接】" + StrBack);
                        return;
                    }
                }
                //显示所接收的消息
                //this.RecieveMsg.AppendText(Encoding.Unicode.GetString(MsgReceiveBuffer, 0, REnd));
                //触发事件

                if (receiveDoneSocketEvent != null)
                    receiveDoneSocketEvent(Encoding.Default.GetString(MsgReceiveBuffer, 0, REnd));

                StrBack = Encoding.Default.GetString(MsgReceiveBuffer, 0, REnd);

                //if (StrBack.Contains("No response from SFC") || StrBack.Contains("err"))
                //{
                //    TCPStatic = false;
                //    connectOk = false;
                //}

                //if (StrBack.Contains("err"))
                //    StrBack = "MES反馈Error";
                //StrBack = "";

                //再次开始异步接收
                if (!b_Ascii)
                {
                    ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                }
                else
                {
                    ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBackASCII), null);
                }

                //TCPStatic = true;

                SaveNetClientLog("【接收到信息，  字符串内容】" + "(" + RemoteStrIP + ":" + RemotePort + ")" + StrBack);
            }
            catch
            {
                TCPStatic = false;
                connectOk = false;
                StrBack = "err";
                SaveNetClientLog("【接收到信息，字符串内容】" + StrBack);
            }
        }

        public void ReceiveCallBack(IAsyncResult AR)
        {
            //string str = "";
            try
            {

                //结束接收（返回接收数据的大小）
                int REnd = ClientSocket.EndReceive(AR);
                //MessageBox.Show(REnd.ToString());
                if (REnd == 0 && connectOk)
                {
                    connectOk = false;
                    TCPStatic = false;
                    //  ClientSocket.Shutdown(SocketShutdown.Both);
                    Thread.Sleep(10);
                    // ClientSocket.Disconnect(false);
                    ClientSocket.Close();
                    //  ClientSocket = null;
                    if (waitConnectEvent != null)
                    {
                        SaveNetClientLog("【接收到信息时，服务器断开了连接】" + StrBack);
                        return;
                    }
                }
                //显示所接收的消息
                //this.RecieveMsg.AppendText(Encoding.Unicode.GetString(MsgReceiveBuffer, 0, REnd));
                //触发事件

                if (receiveDoneSocketEvent != null)
                    receiveDoneSocketEvent(Encoding.Default.GetString(MsgReceiveBuffer, 0, REnd));

                StrBack = Encoding.Default.GetString(MsgReceiveBuffer, 0, REnd);

                //if (StrBack.Contains("No response from SFC") || StrBack.Contains("err"))
                //{
                //    TCPStatic = false;
                //    connectOk = false;
                //}

                //if (StrBack.Contains("err"))
                //    StrBack = "MES反馈Error";
                //StrBack = "";

                //再次开始异步接收
                if (!b_Ascii)
                {
                    ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                }
                else
                {
                    ClientSocket.BeginReceive(MsgReceiveBuffer, 0, MsgReceiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBackASCII), null);
                }
                
                //TCPStatic = true;

                SaveNetClientLog("【接收到信息，  字符串内容】" + "(" + RemoteStrIP + ":" + RemotePort + ")" + StrBack);
            }
            catch
            {
                TCPStatic = false;
                connectOk = false;
                StrBack = "err";
                SaveNetClientLog("【接收到信息，字符串内容】" + StrBack);
            }

        }

        public void StopConnect()
        {
            if (connectOk && ClientSocket != null)
            {
                connectOk = false;
                TCPStatic = false;
                Thread.Sleep(10);
                // ClientSocket.Disconnect(false);
                ClientSocket.Close();
                // ClientSocket = null;
                if (waitConnectEvent != null)
                    waitConnectEvent(ServerInfo.ToString() + " 断开了连接！\n");
            }
        }

        public void SendMsg(string sendMsg)
        {
            StrBack = "";
            if (sendMsg.Length == 0)
            {
                if (waitConnectEvent != null)
                {
                    SaveNetClientLog("【发送信息，字符串内容为空】" + sendMsg);
                    return;
                }
            }
            //如果已连接则发送消息
            if (ClientSocket.Connected && connectOk)
            {
                //发送消息（同时异步调用“ReceiveCallBack”方法接收数据）L
                ClientSocket.Send(Encoding.Default.GetBytes(sendMsg), 0, sendMsg.Length, 0);
                SaveNetClientLog("【发送信息，    字符串内容】" + "(" + RemoteStrIP + ":" + RemotePort + ")" + sendMsg);
                if (sendDone != null)
                {
                    sendDone("Ok");
                }
            }
            else
            {
                TCPStatic = false;
                StrBack = "err";
                //WriteErrorLog("当前与服务器断开连接,无法发送信息！");
                if (waitConnectEvent != null)
                    SaveNetClientLog("【当前与服务器断开连接,无法发送信息！】" + sendMsg);/* waitConnectEvent("");*/
            }
        }

        public void SendMsg2(string sendMsg)//字符串以16进制发送
        {
            if (sendMsg.Length == 0)
            {
                if (waitConnectEvent != null)
                    waitConnectEvent("发送内容不能为空");
                return;
            }
            //如果已连接则发送消息
            if (ClientSocket.Connected && connectOk)
            {
                //发送消息（同时异步调用“ReceiveCallBack”方法接收数据）
                //    ClientSocket.Send(Encoding.Default.GetBytes(sendMsg), 0, sendMsg.Length, 0);

                byte[] array = HexStringToByteArray(sendMsg);
                ClientSocket.Send(array, 0, array.Length, 0);

                //      WriteErrorLog("发送的字符串内容---" + sendMsg);
                if (sendDone != null)
                {
                    sendDone("Ok");
                }
            }
            else
            {
                TCPStatic = false;
                //WriteErrorLog("当前与服务器断开连接,无法发送信息！");
                if (waitConnectEvent != null)
                    waitConnectEvent("当前与服务器断开连接,无法发送信息！");
            }
        }


        /// <summary>
        /// 发送ASCII指令
        /// </summary>
        /// <param name="str"></param>
        public void SendAsciiMsg(string str)
        {
            //00200001000000000000\0
            string message = "0020" + str + "000000000000\0";
            StrBack = "";
            if (str.Length == 0)
            {
                if (waitConnectEvent != null)
                {
                    SaveNetClientLog("【发送信息，字符串内容为空】" + message);
                    return;
                }
            }
            if (ClientSocket.Connected && connectOk)
            {
                ClientSocket.Send(Encoding.ASCII.GetBytes(message), 0, message.Length, SocketFlags.None);
                SaveNetClientLog("【发送信息，    字符串内容】" + "(" + RemoteStrIP + ":" + RemotePort + ")" + message);
                if (sendDone != null)
                {
                    sendDone("Ok");
                }
            }
            else
            {
                TCPStatic = false;
                StrBack = "err";
                if (waitConnectEvent != null)
                    SaveNetClientLog("【当前与服务器断开连接,无法发送信息！】" + message);
            }

        }




        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        public void SaveNetClientLog(string mes, bool iswrite = true)
        {
            try
            {
                lock (locker)
                {
                    string fileName;
                    fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy_MM_dd"));
                    string outputPath = @"D:\DATA\TCP通信Log";
                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }
                    string fullFileName = Path.Combine(outputPath, fileName);
                    System.IO.FileStream fs;
                    //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                    StreamWriter sw;
                    if (!File.Exists(fullFileName))
                    {
                        fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                        sw = new StreamWriter(fs, System.Text.Encoding.Default);
                        if (iswrite)
                            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "    " + mes);
                        else
                            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "    " + mes);
                        sw.Close();
                        fs.Close();

                    }
                    else
                    {
                        fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                        //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                        sw = new StreamWriter(fs, System.Text.Encoding.Default);
                        if (iswrite)
                            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "    " + mes);
                        else
                            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "    " + mes);
                        sw.Close();
                        fs.Close();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
