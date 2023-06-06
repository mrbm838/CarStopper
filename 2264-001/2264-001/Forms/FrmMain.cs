using DataModel;
using cowain;
using cowain.FlowWork;
using Cowain;
using DAL;
using mySocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 通讯协议.串口;
using Sunny.UI;
using ReadAndWriteConfigSystem;
using System.Threading;
using OP001.Motion;
using OP001.PLC;
using OP001;
using OP001.Forms;

namespace OP001
{
    public partial class FrmMain : UIForm
    {

        public FrmLogin frmLogin;
        public FrmParam frmParam;
        public FrmShow frmShow;
        public FrmRewrite frmRewrite;
        public FrmMes frmMes;
        public FrmProcessBar processBar;

        LogClass myLog;
        Params myParams;
        IPLC plc;
        WorkProcess myWorkProcess;
        MachineState myMachineState;

        GT_Helper myGT_Helper;
        PLCWorkClass myPLCWorkClass;

        private MotionModule motion;

        public static event Action<int, string> HandleBarValue;

        public FrmMain()
        {
            processBar = new FrmProcessBar();
            processBar.Show();
            HandleBarValue(0, "开始加载程序信息！");

            motion = new MotionModule();
            MotionLoad.MotionLoading(motion, HandleBarValue);
            HandleBarValue(30, "初始化运动控制模块完成！");

            InitializeComponent();
            HandleBarValue(50, "初始化主界面控件完成！");

            //DBInit.InitDB();
            //HandleBarValue(60, "初始化数据库完成！");

            InitParam();
            HandleBarValue(70, "初始化参数完成！");

            InitConnect();
            HandleBarValue(80, "初始化通信连接完成!");

            //初始化工作流程
            InitWork();
            OpenForm(new FrmShow(myLog, plc, myGT_Helper, myWorkProcess));
            timer1.Enabled = true;
            timer1.Start();

            //-----------------------------异常捕获事件注册------------------------------------------------------------
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            HandleBarValue(100, "异常捕获事件注册完成！");
            Thread.Sleep(300);
            processBar.Close();
            processBar.Dispose();
        }

        #region 主界面控件点击事件
        /// <summary>
        /// 登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Login_Click(object sender, EventArgs e)
        {
            if (frmLogin == null)
            {
                frmLogin = new FrmLogin(motion, myLog);
            }
            frmLogin.Show += tsBtHome_Click;
            frmLogin.ShutDown += FrmLogin_ShutDown;
            OpenForm(frmLogin);
        }

        private void FrmLogin_ShutDown()
        {
            frmLogin = null;
        }

        /// <summary>
        /// 主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtHome_Click(object sender, EventArgs e)
        {
            if (frmShow == null)
            {
                frmShow = new FrmShow(myLog, plc, myGT_Helper, myWorkProcess);
            }
            OpenForm(frmShow);
        }

        /// <summary>
        /// 参数设置界面 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Setting_Click(object sender, EventArgs e)
        {
            if (frmParam == null)
            {
                frmParam = new FrmParam(myParams);
            }

            OpenForm(frmParam);
        }

        /// <summary>
        /// 重新写入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Rewrite_Click(object sender, EventArgs e)
        {
            if (frmRewrite == null)
            {
                frmRewrite = new FrmRewrite(myLog);
            }
            OpenForm(frmRewrite);
        }


        /// <summary>
        /// MES界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_MES_Click(object sender, EventArgs e)
        {
            if (frmMes == null)
            {
                frmMes = new FrmMes();
            }
            OpenForm(frmMes);
        }

        /// <summary>
        /// 手动继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LogClass.AddMsg(0, "手动点击继续按钮！");
            //if (myWorkProcess.m_Status == Base.Status.待命)
            {
                myWorkProcess.m_Status = LocalBase.Status.动作;
            }
        }

        /// <summary>
        /// 打开数据文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Data_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = "D:\\Data";
            process.StartInfo = psi;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                process?.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.currentAccount != Permission.UnLogin)
            {
                this.lbl_user.Text = "Admin";//Program.currentAccount.User = 
                switch (lbl_user.Text)//Program.currentAccount.User
                {
                    case "Engineer":
                        this.tsb_Setting.Enabled = true;
                        this.tsb_Rewrite.Enabled = true;
                        break;
                    case "Admin":
                        this.tsb_Setting.Enabled = true;
                        this.tsb_MES.Enabled = true;
                        this.tsb_Rewrite.Enabled = true;
                        break;
                }
            }
            else
            {
                this.lbl_user.Text = "未登录";
                this.tsb_Setting.Enabled = false;
                this.tsb_MES.Enabled = false;
                this.tsb_Rewrite.Enabled = false;
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("是否关闭软件？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly))
            {
                e.Cancel = true;
            }
        }

        #endregion



        #region 方法/函数

        /// <summary>
        /// 应用程序域的异常捕获
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, EventArgs e)
        {
            UnhandledExceptionEventArgs eventArgs = (UnhandledExceptionEventArgs)e;
            myLog.DispenserClosedSaveAuto(eventArgs.ExceptionObject.ToString());
            MessageBox.Show("程序数据异常，将停止软件" + e.ToString());
        }

        /// <summary>
        /// 线程的异常捕获
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_ThreadException(object sender, EventArgs e)
        {
            UnhandledExceptionEventArgs eventArgs = (UnhandledExceptionEventArgs)e;
            myLog.DispenserClosedSaveAuto(eventArgs.ExceptionObject.ToString());
            MessageBox.Show("程序数据异常，将关闭软件");
        }


        /// <summary>
        /// 关闭之前的界面
        /// </summary>
        private void HideForm()
        {
            foreach (Control item in this.panel_Form.Controls)
            {
                if (item is Form)
                {
                    Form objForm = (Form)item;
                    objForm.Hide();
                }
            }
        }

        /// <summary>
        /// 打开新窗体
        /// </summary>
        /// <param name="objForm"></param>
        private void OpenForm(Form objForm)
        {
            HideForm();
            objForm.TopLevel = false;
            objForm.FormBorderStyle = FormBorderStyle.None;
            objForm.Parent = this.panel_Form;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }


        /// <summary>
        /// 初始化连接及状态
        /// </summary>
        private void InitConnect()
        {
            try
            {
                //switch (StaticParam.PLC_Type)
                //{
                //    case PLCType.信捷:
                //        plc = new XinJieHelper();
                //        break;
                //    case PLCType.欧姆龙:
                //        plc = new OmronFinsUdp();
                //        break;
                //    case PLCType.汇川:
                //        plc = new InovanceAMTcp_my();
                //        break;
                //}
                //plc.Connect(StaticParam.PLC_IP, Convert.ToInt32(StaticParam.PLC_Port), "");


                #region 动态添加

                if (StaticParam.listComObj.Count != 0)
                {
                    for (int i = 0; i < StaticParam.listComObj.Count; i++)
                    {
                        Communicationobj obj = StaticParam.listComObj[i];
                        if (obj.Type == "网口")
                        {
                            switch (obj.SocketType)
                            {
                                case "Server":
                                    ISocket socketServer = new SocketServer(obj.IP, obj.Port);
                                    socketServer.Start();
                                    StaticParam.socketDic.Add(obj.ControlName, socketServer);
                                    break;
                                case "Client":
                                    ISocket socketClient = new SocketClient(obj.IP, obj.Port);
                                    socketClient.Start();
                                    StaticParam.socketDic.Add(obj.ControlName, socketClient);
                                    break;
                            }
                        }
                        if (obj.Type == "串口")
                        {
                            SerialPortClass serialPort = new SerialPortClass();
                            System.IO.Ports.Parity parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), obj.Parity);
                            System.IO.Ports.StopBits stopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), obj.StopBits);
                            serialPort.Open(obj.Com, Convert.ToInt32(obj.BaudRate), parity, stopBits, Convert.ToInt32(obj.DataBits));
                            StaticParam.serialDic.Add(obj.ControlName, serialPort);
                        }
                        if (obj.Type == "PLC")
                        {
                            switch (obj.PLCType)
                            {
                                case "信捷":
                                    plc = new XinJieHelper();
                                    break;
                                case "欧姆龙":
                                    plc = new OmronFinsUdp();
                                    break;
                                case "汇川":
                                    plc = new InovanceAMTcp_my();
                                    break;
                            }
                            plc.Connect(obj.IP, Convert.ToInt32(obj.Port), "");
                            StaticParam.plcDic.Add(obj.ControlName, plc);
                        }
                    }
                }

                #endregion


                #region 常规添加
                //for (int i = 0; i < StaticParam.ScanCount; i++)
                //{
                //    StaticParam.clientScanner[i] = new NetSocket();
                //    StaticParam.clientScanner[i].Open(StaticParam.Scanner_IP[i], Convert.ToInt32(StaticParam.Scanner_Port[i]));
                //}
                //for (int i = 0; i < StaticParam.DriveCount; i++)
                //{
                //    StaticParam.clientDrive[i] = new NetSocket(true);
                //    StaticParam.clientDrive[i].Open(StaticParam.Drive_IP[i], Convert.ToInt32(StaticParam.Drive_Port[i]));
                //    StaticParam.clientDrive[i].SendAsciiMsg("0001");
                //    if (StaticParam.clientDrive[i].StrBack != "")
                //    {
                //        string result = StaticParam.clientDrive[i].StrBack.Substring(4, 4).ToString();
                //        if (result == "0002")
                //        {
                //            StaticParam.clientDrive[i].connectOk = true;
                //        }
                //        else
                //        {
                //            StaticParam.clientDrive[i].connectOk = false;
                //        }
                //    }
                //}
                #endregion


                //Ping ping = new Ping();
                //PingReply reply = ping.Send(StaticParam.SilenceIP);
                //if (reply.Status == IPStatus.Success)
                //{
                //    StaticParam.b_Silence = true;
                //}
                //else
                //{
                //    StaticParam.b_Silence = false;
                //}
            }
            catch (Exception e)
            {
                LogClass.AddMsg(2, "初始化链接时出现异常，异常信息为;" + e.ToString());
            }

        }

        /// <summary>
        /// 初始化工作流程
        /// </summary>
        private void InitWork()
        {
            myGT_Helper = new GT_Helper();
            myPLCWorkClass = new PLCWorkClass(plc);
            myWorkProcess = new WorkProcess(myLog, plc, myGT_Helper);
            myMachineState = new MachineState(myLog, plc, myWorkProcess)
            {
                myWorkProcess = this.myWorkProcess
            };
            myMachineState.Action();
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitParam()
        {
            myParams = XmlSerializeHelper<Params>.DeSerializeFronFile(StaticParam.strBasePath);
            StaticParam.InitParams(myParams);
            myLog = new LogClass(this.lst_Log);
            StaticParam param = StaticParam.CreateInstance();
            this.tsl_MachineName.Text = myParams.MachineName;
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //frmMonitor = new FrmMonitor();
        }
    }
}
