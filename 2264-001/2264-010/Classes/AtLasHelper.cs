using cowain.FlowWork;
using DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP010
{
    public class AtLasHelper
    {
        //发送20（字节）：
        //数据总长度（1-4）+订阅的MID（5-8）+版本（9-11）+确认标志（12）+staion ID（13-14）+splind ID(15-16)+


        public static string GetData(string msg)
        {
            char[] chars = msg.ToCharArray();

            return "";
        }

        /// <summary>
        /// 通信错误
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CommunicationError(string code)
        {
            string error = string.Empty;
            switch (code)
            {
                case "0001"://Invalid Length
                    error = "Invalid Length";
                    break;
                case "0002"://Invalid revision=Not equalto an ASCII number 0 to 99
                    error = "Invalid revision=Not equalto an ASCII number 0 to 99";
                    break;
                case "0003"://Invalid sequence number = Not next expected
                    error = "Invalid sequence number = Not next expected";
                    break;
                case "0004"://Inconsistency of "Number of message" ,"Message number"
                    error = "Inconsistency of \"Number of message\" ,\"Message number";
                    break;
            }
            return error;
        }


        
    }
}
