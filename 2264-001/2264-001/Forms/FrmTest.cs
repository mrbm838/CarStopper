using mySocket;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 通讯协议.串口;

namespace OP001.Forms
{
    public partial class FrmTest : UIPage
    {
        public ISocket socket;
        public SerialPortClass serial;
        string Mode = string.Empty;

        public FrmTest(ISocket Socket, string mode)
        {
            InitializeComponent();
            this.socket = Socket;
            if (mode == "Server")
            {
                ((SocketServer)socket).HandleMSGEvent += FrmTest_HandleMSGEvent;
            }
            if (mode == "Client")
            {
                ((SocketClient)socket).HandleMSGEvent += FrmTest_HandleMSGEvent;
            }
            Mode = mode;
        }

        private void FrmTest_HandleMSGEvent(string obj)
        {
            Invoke((EventHandler)delegate
            {
                this.txt_ReceiveMsg.Text = obj;
            });
        }

        public FrmTest(SerialPortClass serialPort)
        {
            InitializeComponent();
            serial = serialPort;
            serial.ReceiveEvent += Serial_ReceiveEvent;
        }

        private void Serial_ReceiveEvent(string msgStr, string portName)
        {
            Invoke((EventHandler)delegate
            {
                this.txt_ReceiveMsg.Text = msgStr;
            });
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (this.txt_SendMsg.Text == "")
            {
                return;
            }
            else
            {
                socket?.SendMSG(this.txt_SendMsg.Text);
                serial?.SendStringData(this.txt_SendMsg.Text);
            }
        }

        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial != null)
            {
                serial.ReceiveEvent -= Serial_ReceiveEvent;
            }
            if (socket != null)
            {
                if (socket is SocketServer)
                {
                    ((SocketServer)socket).HandleMSGEvent -= FrmTest_HandleMSGEvent;
                }
                if (socket is SocketClient)
                {
                    ((SocketClient)socket).HandleMSGEvent -= FrmTest_HandleMSGEvent;
                }
            }
        }
    }
}
