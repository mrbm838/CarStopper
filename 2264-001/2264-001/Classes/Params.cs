using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP001
{
    [Serializable]
    public class Params
    {
        //------------------------静音房IP------------------------------------------
        [DisplayName("静音房端口IP"),Category("静音房端口"),Description("静音房端口的IP地址")]
        public string SilenceIP { get; set; }

        //------------------------上传启用------------------------------------------
        [DisplayName("上传启用"),Category("功能启用"),Description("是否启用上传功能")]
        public bool b_UseMes { get; set; }

        //-----------------------PLC地址设置------------------------------------------------
        [DisplayName("触发扫码地址"), Category("PLC地址设置"), Description("扫码枪1触发地址")]
        public string TriggerScanAddr { get; set; }
        [DisplayName("扫码OK地址"), Category("PLC地址设置"), Description("扫码完成地址")]
        public string ScanOKAddr { get; set; }
        [DisplayName("气缸到位地址"), Category("PLC地址设置"), Description("气缸到位地址")]
        public string ReachAddr { get; set; }
        [DisplayName("完成信号地址"), Category("PLC地址设置"), Description("工站完成信号地址")]
        public string WorkDoneAddr { get; set; }
        [DisplayName("PLC启动地址"), Category("PLC地址设置"), Description("设备启动地址")]
        public string PLCStart { get; set; }
        [DisplayName("PLC停止地址"), Category("PLC地址设置"), Description("设备停止地址")]
        public string PLCStop { get; set; }
        [DisplayName("PLC复位地址"), Category("PLC地址设置"), Description("设备复位地址")]
        public string PLCReset { get; set; }
        [DisplayName("PLC急停地址"), Category("PLC地址设置"), Description("设备急停地址")]
        public string PLCEmg { get; set; }

        //---------------------设备参数---------------------------------------------------
        [DisplayName("设备名称"),Category("设备参数"),Description("主界面显示的设备名称")]
        public string MachineName { get; set; }
        [DisplayName("扫码时间"),Category("设备参数"),Description("扫码枪超时时间")]
        public int ScanTime { get; set; }

        //-----------------------数据路径地址------------------------------------------------
        [DisplayName("数据路径"), Category("数据路径地址"), Description("数据存储的路径")]
        public string DataPath { get; set; }

        #region 弃用
        ////------------------------扫码枪--------------------------------------------
        //[DisplayName("Scan Count"), Category("扫码枪设置"), Description("扫码枪的数量")]
        //public int ScanNum { get; set; }
        //[DisplayName("Scanner1_IP"), Category("扫码枪设置"), Description("扫码枪1的IP地址")]
        //public string Scanner1_IP { get; set; }
        //[DisplayName("Scanner1_Port"), Category("扫码枪设置"), Description("扫码枪1的端口号")]
        //public string Scanner1_Port { get; set; }
        //[DisplayName("Scanner2_IP"), Category("扫码枪设置"), Description("扫码枪2的IP地址")]
        //public string Scanner2_IP { get; set; }
        //[DisplayName("Scanner2_Port"), Category("扫码枪设置"), Description("扫码枪2的端口号")]
        //public string Scanner2_Port { get; set; }

        ////------------------------扭力抢---------------------------------------------
        //[DisplayName("Drive Count"), Category("扭力抢设置"), Description("扭力抢的数量")]
        //public int DriveNum { get; set; }
        //[DisplayName("Drive1_IP"), Category("扭力抢设置"), Description("扭力枪1的IP地址")]
        //public string Drive1_IP { get; set; }
        //[DisplayName("Drive1_Port"), Category("扭力抢设置"), Description("扭力枪1的端口号")]
        //public string Drive1_Port { get; set; }
        //[DisplayName("Drive2_IP"), Category("扭力抢设置"), Description("扭力枪2的IP地址")]
        //public string Drive2_IP { get; set; }
        //[DisplayName("Drive2_Port"), Category("扭力抢设置"), Description("扭力枪2的端口号")]
        //public string Drive2_Port { get; set; }
        //[DisplayName("Drive3_IP"), Category("扭力抢设置"), Description("扭力枪3的IP地址")]
        //public string Drive3_IP { get; set; }
        //[DisplayName("Drive3_Port"), Category("扭力抢设置"), Description("扭力枪3的端口号")]
        //public string Drive3_Port { get; set; }


        ////------------------------PLC-----------------------------------------------
        //[DisplayName("PLC_Type"), Category("PLC设置"), Description("PLC的类型")]
        //public PLCType PLC_Type { get; set; }
        //[DisplayName("PLC_IP"), Category("PLC设置"), Description("PLC的IP地址")]
        //public string PLC_IP { get; set; }
        //[DisplayName("PLC_Port"), Category("PLC设置"), Description("PLC的端口号")]
        //public string PLC_Port { get; set; }


        ////------------------------高迪涂油连接设置----------------------------------
        //[DisplayName("CommunicationType"),Category("高迪连接设置"),Description("与高迪连接的类型")]
        //public SocketType SocketType { get; set; }
        //[DisplayName("CommunicationIP"), Category("高迪连接设置"), Description("与高迪连接的IP")]
        //public string SocketIP { get; set; }
        //[DisplayName("CommunicationPort"), Category("高迪连接设置"), Description("与高迪连接的端口")]
        //public string SocketPort { get; set; }
        #endregion
    }
}
