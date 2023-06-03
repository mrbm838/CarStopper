using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class ShiJieScanner
    {
        #region 网口
        public string IP { get; set; }
        public string Port { get; set; }
        #endregion

        #region 触发/释放指令
        public string TriggerCmd { get; set; } = "T";//串口"0x0A"
        public string ReleaseCmd { get; set; } = "R";
        #endregion


        #region 串口
        public string PortName { get; set; }
        public string BaudRate { get; set; }
        public string DataBits { get; set; }
        public string StopBits { get; set; }
        public string Parity { get; set; }
        #endregion

    }
}
