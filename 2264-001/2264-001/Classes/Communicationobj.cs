using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP001
{
    public class Communicationobj
    {
        /// <summary>
        /// 通信对象名称
        /// </summary>
        public string ControlName;

        /// <summary>
        /// 通信对象类型
        /// </summary>
        public string Type;


        #region 网口/plc

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP;

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port;

        /// <summary>
        /// socket类型
        /// </summary>
        public string SocketType;

        /// <summary>
        /// plc类型
        /// </summary>
        public string PLCType;
        #endregion

        #region 串口

        /// <summary>
        /// COM口
        /// </summary>
        public string Com;

        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate;

        /// <summary>
        /// 数据位
        /// </summary>
        public string DataBits;

        /// <summary>
        /// 校验位
        /// </summary>
        public string Parity;

        /// <summary>
        /// 停止位
        /// </summary>
        public string StopBits;
        #endregion
    }
}
