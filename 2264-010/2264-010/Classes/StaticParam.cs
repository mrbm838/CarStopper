using DataModel;
using cowain.FlowWork;
using Cowain;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadAndWriteConfigSystem;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Windows.Forms;
using mySocket;
using 通讯协议.串口;
using Sunny.UI;
using System.Drawing;
using MotionBase;
using Cowain_AutoMachine.Flow.IO_Cylinder;

namespace OP010
{
    public class StaticParam
    {
        #region 静态字段/属性
        /// <summary>
        /// 配置文件地址
        /// </summary>
        public static string strBasePath = Directory.GetCurrentDirectory() + "\\Configuration.xml";

        /// <summary>
        /// 通信对象文件地址
        /// </summary>
        public static string jsonPath= Directory.GetCurrentDirectory() + "\\通信配置\\JsonObj.xml";

        /// <summary>
        /// MES的json文件夹地址
        /// </summary>
        public static string mesTypePath = Directory.GetCurrentDirectory() + "\\MESType";



        /// <summary>
        /// 扫码枪触发地址
        /// </summary>
        public static string TriggerScanAddr = string.Empty;
        /// <summary>
        /// 扫码完成地址
        /// </summary>
        public static string ScanOKAddr = string.Empty;
        /// <summary>
        /// 气缸到位地址
        /// </summary>
        public static string ReachAddr = string.Empty;

        /// <summary>
        /// 写完成信号地址
        /// </summary>
        public static string WorkDoneAddr = string.Empty;



        /// <summary>
        /// PLC启动地址
        /// </summary>
        public static string PLCStart = string.Empty;
        /// <summary>
        /// PLC停止地址
        /// </summary>
        public static string PLCStop = string.Empty;
        /// <summary>
        /// PLC复位d地址
        /// </summary>
        public static string PLCReset = string.Empty;
        /// <summary>
        /// PLC急停地址
        /// </summary>
        public static string PLCEMG = string.Empty;



        /// <summary>
        /// 静音房端口的IP
        /// </summary>
        public static string SilenceIP = string.Empty;

        /// <summary>
        /// 静音房连接状态
        /// </summary>
        public static bool b_Silence = false;

        /// <summary>
        /// 启用MES
        /// </summary>
        public static bool b_UseMES;

        /// <summary>
        /// 数据存储路径
        /// </summary>
        public static string DataPath = string.Empty;

        /// <summary>
        /// 扫码超时时间
        /// </summary>
        public static int ScanTime = 5;

        /// <summary>
        /// PLC启动
        /// </summary>
        public static bool b_Start = false;
        /// <summary>
        /// PLC复位
        /// </summary>
        public static bool b_Reset = false;
        /// <summary>
        /// PLC急停
        /// </summary>
        public static bool b_EMG = false;


        private static StaticParam instance;
        public static FrmError frmError;



        /// <summary>
        /// 动态通讯字典
        /// </summary>
        public static Dictionary<string, ISocket> socketDic = new Dictionary<string, ISocket>();
        /// <summary>
        /// 动态串口字典
        /// </summary>
        public static Dictionary<string, SerialPortClass> serialDic = new Dictionary<string, SerialPortClass>();
        /// <summary>
        /// PLC字典
        /// </summary>
        public static Dictionary<string, IPLC> plcDic = new Dictionary<string, IPLC>();


        /// <summary>
        /// 配置文件中的通信对象集合
        /// </summary>
        public static List<Communicationobj> listComObj = new List<Communicationobj>();

        /// <summary>
        /// 错误表
        /// </summary>
        public static DataTable ErrorTable = null;

        /// <summary>
        /// 错误集合
        /// </summary>
        public static List<ErrorInfo> errorInfos = new List<ErrorInfo>();

        /// <summary>
        /// MES要上传的字段集合
        /// </summary>
        public static List<string> lstMesParam = new List<string>();

        /// <summary>
        /// 点位标签字典
        /// </summary>
        public static List<UILabel> listLabels = new List<UILabel>();

        /// <summary>
        /// 轴点位字典
        /// </summary>
        public static Dictionary<string, clsMachinePoint> MachineAxesPoints = new Dictionary<string, clsMachinePoint>();

        /// <summary>
        /// 各点位数组
        /// </summary>
        public static Sys_Define.tyAXIS_XYZRA[] Points = new Sys_Define.tyAXIS_XYZRA[(int)EnumPosition.MaxCount];

        #endregion

        #region 电机、气缸、IO

        public static DrvMotor AxisR = null;
        public static DrvMotor AxisZ = null;

        public static DrvValve ValveSta1 = null;
        public static DrvValve ValveSta2 = null;
        public static DrvValve ValveSta3 = null;
        public static DrvValve ValveSta4 = null;
        public static DrvValve ValveSta5 = null;

        public static DrvIO InputPort1 = null;
        public static DrvIO InputPort2 = null;
        public static DrvIO InputPort3 = null;
        public static DrvIO InputPort4 = null;
        public static DrvIO InputPort5 = null;

        public static DrvIO OutputPort1 = null;
        public static DrvIO OutputPort2 = null;
        public static DrvIO OutputPort3 = null;
        public static DrvIO OutputPort4 = null;
        public static DrvIO OutputPort5 = null;

        #endregion

        #region 流道

        //public static DrvValve R_ValveSta1 = null;
        //public static DrvValve R_ValveSta2 = null;
        //public static DrvValve R_ValveSta3 = null;
        //public static DrvValve R_ValveSta4 = null;
        //public static DrvValve R_ValveSta5 = null;

        //public static DrvIO R_InputPort1 = null;
        //public static DrvIO R_InputPort2 = null;
        //public static DrvIO R_InputPort3 = null;
        //public static DrvIO R_InputPort4 = null;
        //public static DrvIO R_InputPort5 = null;

        //public static DrvIO R_OutputPort1 = null;
        //public static DrvIO R_OutputPort2 = null;
        //public static DrvIO R_OutputPort3 = null;
        //public static DrvIO R_OutputPort4 = null;
        //public static DrvIO R_OutputPort5 = null;

        public static DrvIO[] R_InputArray = null;
        public static DrvIO[] R_OutputArray = null;

        #endregion

        public StaticParam()
        {
            frmError = new FrmError();
            frmError.Show();
            frmError.Visible = false;
        }

        #region 静态方法

        public static StaticParam CreateInstance()
        {
            if (instance == null)
            {
                instance = new StaticParam();
            }
            return instance;
        }

        /// <summary>
        /// 初始化用到的参数
        /// </summary>
        /// <param name="p"></param>
        public static void InitParams(Params p)
        {
            TriggerScanAddr = p.TriggerScanAddr;
            ScanOKAddr = p.ScanOKAddr;
            ReachAddr = p.ReachAddr;
            WorkDoneAddr = p.WorkDoneAddr;
            PLCStart = p.PLCStart;
            PLCStop = p.PLCStop;
            PLCReset = p.PLCReset;
            PLCEMG = p.PLCEmg;

            b_UseMES = p.b_UseMes;
            SilenceIP = p.SilenceIP;
            DataPath = p.DataPath;
            ScanTime = p.ScanTime;

            listComObj = XmlSerializeHelper<List<Communicationobj>>.DeSerializeFronFile(jsonPath);

            ErrorTable = GetConfigDT("ERROR", true);
            AddError(ErrorTable);
        }


        /// <summary>
        /// 保存数据到CSV
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="saveData"></param>
        public static void SaveData(object obj,SaveData saveData)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    foreach (var item in obj.GetType().GetProperties())
                    {
                        if (item.Name.Contains("ID"))
                        {
                            continue;
                        }
                        saveData.myDictionary.Add(item.Name.ToString(), item.GetValue(obj, null));
                    }
                    saveData.save();
                    LogClass.AddMsg(0, "本地数据保存成功！");
                }
                catch (Exception e)
                {
                    LogClass.AddMsg(2, "本地数据保存失败，原因为：" + e.Message);
                }
            }));
        }


        /// <summary>
        /// 保存数据到配置文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sn"></param>
        public static void SaveConfig(object obj,string sn)
        {
            //失败后将SN及数据信息保存到配置文件，后面人工界面写入
            Task.Run(new Action(() =>
            {
                foreach (var item in obj.GetType().GetProperties())
                {
                    if (item.Name.Contains("SN") || item.Name.Contains("ID"))
                    {
                        continue;
                    }
                    ConfigHelperSystem.AddAppConfig("工站1写数据库失败SN及数据", "SN_" + sn, item.GetValue(obj, null).ToString());
                }
            }));
        }


        /// <summary>
        /// 获取配置相应的表
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="IsHasColumnName">有无表头</param>
        /// <returns></returns>
        public static DataTable GetConfigDT(string SheetName, bool IsHasColumnName)
        {
            DataTable oldDataTable = null;
            try
            {
                if (SheetName == null || SheetName.Length == 0)
                {
                    MessageBox.Show("读取Excel文件未指定Sheet名称");
                }
                else
                {
                    string XlsxFilePath = string.Format("{0}\\Config\\{1}", Application.StartupPath, "ERROR.xls");
                    oldDataTable = ExcelHelper.ExcelToDataTable(XlsxFilePath, SheetName, IsHasColumnName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return oldDataTable;
        }


        /// <summary>
        /// 将表行列对换,不含表头
        /// </summary>
        /// <param name="tableData"></param>
        /// <returns></returns>
        public static DataTable SwapTable(DataTable tableData)
        {
            try
            {
                int intRows = tableData.Rows.Count;
                int intColumns = tableData.Columns.Count;

                //转二维数组
                string[,] arrayData = new string[intRows, intColumns];
                for (int i = 0; i < intRows; i++)
                {
                    for (int j = 0; j < intColumns; j++)
                    {
                        arrayData[i, j] = tableData.Rows[i][j].ToString();
                    }
                }
                //下标对换
                string[,] arrSwap = new string[intColumns, intRows];
                for (int m = 0; m < intColumns; m++)
                {
                    for (int n = 0; n < intRows; n++)
                    {
                        arrSwap[m, n] = arrayData[n, m];
                    }
                }
                DataTable dt = new DataTable();
                //添加列
                for (int k = 0; k < intRows; k++)
                {
                    dt.Columns.Add(
                            new DataColumn(arrSwap[0, k])
                        );
                }
                //添加行
                for (int r = 1; r < intColumns; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 0; c < intRows; c++)
                    {
                        dr[c] = arrSwap[r, c].ToString();
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 初始化加载错误信息
        /// </summary>
        /// <param name="dataTable"></param>
        public static void AddError(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.ErrorCode = dataTable.Rows[i][0].ToString();
                errorInfo.ErrMsg = dataTable.Rows[i][2].ToString();
                errorInfo.Solution = dataTable.Rows[i][4].ToString();
                errorInfos.Add(errorInfo);
            }
        }

        #endregion

    }
}
