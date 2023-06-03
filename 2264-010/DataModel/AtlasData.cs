using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;

namespace DataModel
{
    [Serializable]
    public class AtlasData
    {
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControlName { get; set; }

        /// <summary>
        /// The cell ID is four bytes long and specified by four ASCII digits.Range: 0000-9999
        /// 单元 ID， 长 4 个字节，由 四 ASCII 数字。范围： 0000-9999
        /// </summary>
        public string  CellID { get; set; }
        /// <summary>
        /// The channel ID is two bytes long and specified by two ASCII digits.Range: 00-99.
        /// 通道 ID ，为两个字节长并指定 通过两个 ASCII 数字。范围： 00-99
        /// </summary>
        public string  ChannelID { get; set; }
        /// <summary>
        /// The controller name is 25 bytes long and is specified by 25 ASCII characters
        /// 控制器名称长度为 25 个字节，并且是 指定的 由 25 个 ASCII 字符。
        /// </summary>
        public string  TorqueControlName { get; set; }
        /// <summary>
        /// The VIN number is 25 bytes long and is specified by 25 ASCII characters.
        /// VIN 号为 25 字节长，并指定 由 25 个 ASCII 字符。
        /// </summary>
        public string  VinNumber { get; set; }
        /// <summary>
        /// The Job ID is two bytes long and specified by two ASCII digits.Range: 00-99
        /// 作业 ID 长两个字节，由 二 ASCII 数字。范围： 00-99
        /// </summary>
        public string  JobID { get; set; }
        /// <summary>
        /// The parameter set ID is three bytes long and specified by three ASCII digits.Range: 000-999
        /// 参数集 ID 为三个字节长 和 由三个 ASCII 数字指定。范围： 000-999。
        /// </summary>
        public string  ParameterSetID { get; set; }
        /// <summary>
        /// This parameter gives the total number of tightening in the batch.The batch size is four bytes long and specified by four ASCII digits.Range: 0000-9999
        /// 该参数给出了拧紧的总次数 在 批次。批处理大小为四个字节长 和 由四个 ASCII 数字指定。范围： 0000-9999
        /// </summary>
        public string  BatchSize { get; set; }
        /// <summary>
        /// The batch counter information is four bytes long specifying and specified by four ASCII digits.Range:0000-9999.
        /// 批次计数器信息为四个字节 长 由四个 ASCII 数字指定和指定。 范围： 0000-9999
        /// </summary>
        public string  BatchCounter { get; set; }
        /// <summary>
        /// The tightening status is one byte long and specified by one ASCII digit. 0=tightening NOK, 1=tightening OK
        /// 拧紧状态为一字节长， 指定的 一位 ASCII 数字。 0=低， 1=拧紧 2=高
        /// </summary>
        public string  TighteningStatus { get; set; }
        /// <summary>
        /// 0=Low, 1=OK, 2=High
        /// 0=低，1=正常， 2=高
        /// </summary>
        public string  TorqueStatus { get; set; }
        /// <summary>
        /// 0=Low, 1=OK, 2=High
        /// 0=低，1=正常， 2=高
        /// </summary>
        public string  AngleStatus { get; set; }
        /// <summary>
        /// The torque min limit is multiplied by 100 and sent as an integer(2 decimals truncated). It is six bytes long and is specified by six ASCII digits.
        /// 扭矩最小限制乘以 100 并发送 作为整数（截断 2 位小数）。它是六个字节 长 并由六个 ASCII 指定 位数。
        /// </summary>
        public string  TorqueMin { get; set; }
        /// <summary>
        /// The torque max limit is multiplied by 100 and sent as an integer(2 decimals truncated). It is six bytes long and is specified by six ASCII digits
        /// 扭矩最大限制乘以 100 并发送 作为整数（截断 2 位小数）。它是六个字节 长 并由六个 ASCII 指定 位数
        /// </summary>
        public string  TorqueMax { get; set; }
        /// <summary>
        /// The torque final target is multiplied by 100 and sent as an integer(2 decimals truncated). It is six bytes long and is specified by six ASCII digits
        /// 扭矩最终目标乘以 100 和 发送 作为整数（截断 2 位小数）。是六 字节长，由六个 ASCII 指定 位数。
        /// </summary>
        public string  TorqueTarget { get; set; }
        /// <summary>
        /// The torque value is multiplied by 100 and sent as an integer(2 decimals truncated). It is six bytes long and is specified by six ASCII digits
        /// 扭矩值乘以 100 并发送为 一个 整数（截断 2 位小数）。它有六个字节长 和 由六个 ASCII 指定 位数
        /// </summary>
        public string  Torque { get; set; }
        /// <summary>
        /// The angle min value in degrees. Each turn represents 360 degrees.It is five bytes long and specified by five ASCII digits.Range: 00000-99999
        /// 以度为单位的角度最大值。每个 转动 代表 360 度。它有五个字节长 和 由五个 ASCII 数字指定。范围： 00000-99999
        /// </summary>
        public string AngleMax { get; set; }
        /// <summary>
        /// The angle max value in degrees. Each turn represents 360 degrees.It is five bytes long and specified by five ASCII digits.Range: 00000-99999.
        /// 以度为单位的角度最小值。每个 转动 代表 360 度。它有五个字节长 和 由五个 ASCII 数字指定。范围： 00000-99999
        /// </summary>
        public string AngleMin { get; set; }
        /// <summary>
        /// The target angle value in degrees. Each turn represents 360 degrees.It is five bytes long and specified by five ASCII digits.Range: 00000-99999
        /// 以度为单位的转向角度值。每个 转动 代表 360 度。它有五个字节长 和 由五个 ASCII 数字指定。范围： 00000-99999。
        /// </summary>
        public string AngleTarget { get; set; }
        /// <summary>
        /// The turning angle value in degrees. Each turn represents 360 degrees.It is five bytes long and specified by five ASCII digits.Range: 00000-99999
        /// 以度为单位的转向角度值。每个 转动 代表 360 度。它有五个字节长 和 由五个 ASCII 数字指定。范围： 00000-99999。
        /// </summary>
        public string  Angle { get; set; }
        /// <summary>
        /// Time stamp for each tightening. It is 19 bytes long  and is specified by 19 ASCII characters (YYYY-MM-DD:HH:MM:SS).
        /// 每次拧紧的时间戳。它是 19 个字节 长 并由 19 ASCII 指定 字符 (YYYY-MM-DD:HH:MM:SS)
        /// </summary>
        public string  TimeStamp { get; set; }
        /// <summary>
        /// Time stamp for the last change in the current parameter set settings.It is 19 bytes long and is specified by 19 ASCII characters(YYYY-MMDD:HH:MM:SS).
        /// 最后一次更改的时间戳 当前的 参数组设置。它长 19 个字节，并且 由 19 个 ASCII 字符指定 (YYYY-MM- DD:HH:MM:SS)。
        /// </summary>
        public string  DateTimeOfLastChange { get; set; }
        /// <summary>
        /// The batch status is specified by one ASCII character. 0=batch NOK, 1=batch OK, 2=batch not used, 3=batch running
        /// 批次状态由一个 ASCII 指定 特点。 0=批量 NOK，1=批量 好的，2=未使用批次，3=批次 跑步
        /// </summary>
        public string  BatchStatus { get; set; }
        /// <summary>
        /// The tightening ID is a unique ID for each tightening result.It is incremented after each tightening. 10 ASCII digits. Max 4294967295
        /// 拧紧 ID 是每个设备的唯一 ID 收紧 结果。每次拧紧后都会增加。 10 ASCII 数字。最大限度 4294967295
        /// </summary>
        public string  TightteningID { get; set; }

    }
}
