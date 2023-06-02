using OP010.Forms;
using DataModel;
using CommunicationControl;
using mySocket;
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
using System.IO.Ports;
using Sunny.UI;
using Cowain;
using PLC通讯协议;

namespace OP010
{
    public partial class FrmSetCommunicate : UIForm
    {
        Action<Dictionary<CommunicateConfig, string>> SaveConfig;
        List<Dictionary<CommunicateConfig, string>> listCom = new List<Dictionary<CommunicateConfig, string>>();
        ISocket socket;
        IPLC plc;
        SerialPortClass serialPort;

        FrmTest frmTest;
        FrmPLCTest pLCTest;
        Action action;

        public FrmSetCommunicate()
        {
            InitializeComponent();
        }

        public FrmSetCommunicate(Action<Dictionary<CommunicateConfig, string>> saveConfig1, List<Dictionary<CommunicateConfig, string>> list)
        {
            InitializeComponent();
            SaveConfig = saveConfig1;
            listCom = list;

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmSelectCom selectCom = new FrmSelectCom(SelectControl);
            selectCom.ShowDialog();
        }

        public void SelectControl(string arg1, string arg2)
        {
            int count = uiTabControl1.TabPages.Count;
            if (arg1 == "网口")
            {
                Dictionary<CommunicateConfig, string> tcpConfig = new Dictionary<CommunicateConfig, string>();
                tcpConfig.Add(CommunicateConfig.ControlName, arg2);
                tcpConfig.Add(CommunicateConfig.IP, "");
                tcpConfig.Add(CommunicateConfig.Port, "");
                tcpConfig.Add(CommunicateConfig.SocketType, "");
                TCPControl tCPControl = new TCPControl(tcpConfig, SaveConfig);
                tCPControl.Location = new Point(0, 0);
                AddControl(count + 1, tCPControl);
            }
            if (arg1 == "串口")
            {
                Dictionary<CommunicateConfig, string> serialConfig = new Dictionary<CommunicateConfig, string>();
                serialConfig.Add(CommunicateConfig.ControlName, arg2);
                serialConfig.Add(CommunicateConfig.COM, "");
                serialConfig.Add(CommunicateConfig.BaudRate, "");
                serialConfig.Add(CommunicateConfig.Parity, "");
                serialConfig.Add(CommunicateConfig.DataBits, "");
                serialConfig.Add(CommunicateConfig.StopBits, "");
                SerialControl serialControl = new SerialControl(serialConfig, SaveConfig);
                serialControl.Location = new Point(0, 0);
                AddControl(count + 1, serialControl);
            }
            if (arg1 == "PLC")
            {
                Dictionary<CommunicateConfig, string> plcConfig = new Dictionary<CommunicateConfig, string>();
                plcConfig.Add(CommunicateConfig.ControlName, arg2);
                plcConfig.Add(CommunicateConfig.IP, "");
                plcConfig.Add(CommunicateConfig.Port, "");
                plcConfig.Add(CommunicateConfig.PLCType, "");
                PLCControl plcControl = new PLCControl(plcConfig, SaveConfig);
                plcControl.Location = new Point(0, 0);
                AddControl(count + 1, plcControl);
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="count"></param>
        /// <param name="obj"></param>
        private void AddControl(int count, UserControl obj)
        {
            TabPage tabPage = new TabPage();
            uiTabControl1.TabPages.Add(tabPage);
            tabPage.Controls.Add(obj);
            obj.Show();
            uiTabControl1.TabPages[uiTabControl1.TabPages.Count - 1].Focus();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSetCommunicate_Load(object sender, EventArgs e)
        {
            try
            {
                uiTabControl1.TabPages.Clear();
                for (int i = 0; i < listCom.Count; i++)
                {
                    TabPage tabPage = new TabPage(listCom[i][CommunicateConfig.ControlName]);
                    uiTabControl1.TabPages.Add(tabPage);
                    if (listCom[i][CommunicateConfig.CommunicateType] == "网口")
                    {
                        TCPControl tCPControl = new TCPControl(listCom[i], SaveConfig);
                        tCPControl.Location = new Point(0, 0);
                        uiTabControl1.TabPages[i].Controls.Add(tCPControl);
                        tCPControl.Dock = DockStyle.Fill;
                        tCPControl.Show();
                    }
                    if (listCom[i][CommunicateConfig.CommunicateType] == "串口")
                    {
                        SerialControl serialControl = new SerialControl(listCom[i], SaveConfig);
                        serialControl.Location = new Point(0, 0);
                        uiTabControl1.TabPages[i].Controls.Add(serialControl);
                        serialControl.Dock = DockStyle.Fill;
                        serialControl.Show();
                    }
                    if (listCom[i][CommunicateConfig.CommunicateType] == "PLC")
                    {
                        PLCControl plcControl = new PLCControl(listCom[i], SaveConfig);
                        plcControl.Location = new Point(0, 0);
                        uiTabControl1.TabPages[i].Controls.Add(plcControl);
                        plcControl.Dock = DockStyle.Fill;
                        plcControl.Show();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int count = uiTabControl1.TabPages.Count;
            if (count <= 0)
            {
                return;
            }
            foreach (Control item in uiTabControl1.TabPages[uiTabControl1.SelectedIndex].Controls)
            {
                if (item is TCPControl)
                {
                    Dictionary<CommunicateConfig, string> currentTcpConfig = ((TCPControl)item).configs;
                    currentTcpConfig[CommunicateConfig.RemoveControl] = "1";
                    SaveConfig(currentTcpConfig);
                }
                if (item is SerialControl)
                {
                    Dictionary<CommunicateConfig, string> currentTcpConfig = ((SerialControl)item).SerialConfigs;
                    currentTcpConfig[CommunicateConfig.RemoveControl] = "1";
                    SaveConfig(currentTcpConfig);
                }
                if (item is PLCControl)
                {
                    Dictionary<CommunicateConfig, string> currentPLCConfig = ((PLCControl)item).configs;
                    currentPLCConfig[CommunicateConfig.RemoveControl] = "1";
                    SaveConfig(currentPLCConfig);
                }
            }
            uiTabControl1.TabPages.Remove(uiTabControl1.TabPages[uiTabControl1.SelectedIndex]);
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Test_Click(object sender, EventArgs e)
        {
            if (uiTabControl1.TabPages.Count <= 0)
            {
                return;
            }
            if (uiTabControl1.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                foreach (Control item in uiTabControl1.TabPages[uiTabControl1.SelectedIndex].Controls)
                {
                    if (item is TCPControl)
                    {
                        Dictionary<CommunicateConfig, string> currentTcpConfig = ((TCPControl)item).configs;
                        if (currentTcpConfig[CommunicateConfig.SocketType] == "Server")
                        {
                            socket = new SocketServer(currentTcpConfig[CommunicateConfig.IP], currentTcpConfig[CommunicateConfig.Port]);
                            socket.Start();
                            frmTest = new FrmTest(socket, "Server");
                            frmTest.TopLevel = false;
                            frmTest.Parent = this.splitContainer1.Panel2;
                            frmTest.Dock = DockStyle.Fill;
                            frmTest.Show();
                        }
                        if (currentTcpConfig[CommunicateConfig.SocketType] == "Client")
                        {
                            socket = new SocketClient(currentTcpConfig[CommunicateConfig.IP], currentTcpConfig[CommunicateConfig.Port]);
                            socket.Start();
                            frmTest = new FrmTest(socket, "Client");
                            frmTest.TopLevel = false;
                            frmTest.Parent = this.splitContainer1.Panel2;
                            frmTest.Dock = DockStyle.Fill;
                            frmTest.Show();
                        }
                    }
                    if (item is SerialControl)
                    {
                        Dictionary<CommunicateConfig, string> currentTcpConfig = ((SerialControl)item).SerialConfigs;
                        System.IO.Ports.Parity parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), currentTcpConfig[CommunicateConfig.Parity]);
                        System.IO.Ports.StopBits stopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), currentTcpConfig[CommunicateConfig.StopBits]);
                        serialPort = new SerialPortClass();
                        serialPort.Open(currentTcpConfig[CommunicateConfig.COM], Convert.ToInt32(currentTcpConfig[CommunicateConfig.BaudRate]), parity, stopBits, Convert.ToInt32(currentTcpConfig[CommunicateConfig.DataBits]));
                        frmTest = new FrmTest(serialPort);
                        frmTest.TopLevel = false;
                        frmTest.Parent = this.splitContainer1.Panel2;
                        frmTest.Dock = DockStyle.Fill;
                        frmTest.Show();
                    }
                    if (item is PLCControl)
                    {
                        Dictionary<CommunicateConfig, string> currentPLCConfig = ((PLCControl)item).configs;
                        switch (currentPLCConfig[CommunicateConfig.PLCType])
                        {
                            case "信捷":
                                plc = new XinJieHelper();
                                break;
                            case "汇川":
                                plc = new InovanceAMTcp_my();
                                break;
                            case "欧姆龙":
                                plc = new OmronFinsUdp();
                                break;
                        }
                        pLCTest = new FrmPLCTest(plc, currentPLCConfig[CommunicateConfig.IP], currentPLCConfig[CommunicateConfig.Port]);
                        pLCTest.Show();
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmTest != null)
            {
                frmTest.socket = null;
                frmTest.serial?.Close();
                frmTest.serial = null;
                frmTest.Close();
            }
        }

        private void FrmSetCommunicate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmTest != null)
            {
                frmTest.socket = null;
                frmTest.serial?.Close();
                frmTest.serial = null;
                frmTest.Close();
            }
        }
    }
}
