using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Profinet.Inovance;
using Cowain;
using HslCommunication.Core;
using BYD2181;

namespace Cowain
{
    public class InovanceAMTcp_my : IPLC
    {
        private InovanceAMTcp HSL_plc;
        public bool connected { get; set; } = false;
        private string IP1 = "";
        private int port1;
        private string keyName1;

        public InovanceAMTcp_my()
        {
            
        }
        

        public void Connect()
        {
            if (IP1 == "")
            {
                return;
            }
            Connect(IP1, port1, keyName1);
        }
        public bool Connect(string ip, int port, string keyName)
        {
            IP1 = ip;
            port1 = port;
            keyName1 = keyName;
            string station = "";
            bool b_IsAddressStartWithZero = false;
            bool b_IsStringReverse = false;
            string outTime = "";
            DataFormat df = DataFormat.ABCD;
            bool b_Connected = ConnectServer(ip, Convert.ToInt32(port), Convert.ToByte(station), b_IsAddressStartWithZero, b_IsStringReverse, df, Convert.ToInt32(outTime));
            return b_Connected;
        }
        /// <summary>
        /// 连接PLC
        ///  连接成功返回true
        /// </summary>
        /// <param name="ip">PLC的IP地址</param>
        /// <param name="port">PLC的端口</param>
        /// <param name="station">站号</param>
        /// <param name="isAddressStartWithZero">地址从零开始</param>
        /// <param name="isStringReverse">字符串反转</param>
        /// <param name="dataFormat">字节转换的数据格式</param>
        ///  <param name="connectTimeOut">连接超时时间</param>
        public bool ConnectServer(string ip, int port, byte station, bool isAddressStartWithZero, bool isStringReverse, HslCommunication.Core.DataFormat dataFormat, int connectTimeOut)
        {
            Close();
            try
            {
                HSL_plc?.ConnectClose();
                HSL_plc = new InovanceAMTcp(ip, port, station);
                HSL_plc.ConnectTimeOut = connectTimeOut;
                HSL_plc.AddressStartWithZero = isAddressStartWithZero;
                HSL_plc.DataFormat = dataFormat;
                HSL_plc.IsStringReverse = isStringReverse;

                OperateResult connect = HSL_plc.ConnectServer();
                if (connect.IsSuccess)
                {
                    connected = true;
                    return true;
                }
                else
                {
                    connected = false;
                    return false;
                }
            }
            catch
            {
                connected = false;
                return false;
            }
        }

        /// <summary>
        /// 断开PLC
        /// </summary>
        public void Close()
        {
            try
            {
                HSL_plc?.ConnectClose();
            }
            catch { }
        }

        /// <summary>
        /// bool读取
        ///  读取成功返回True或False
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadBool(string address)
        {
            try
            {
                OperateResult<bool> readBool = HSL_plc.ReadBool(address);
                if (readBool.IsSuccess)
                {
                    return readBool.Content.ToString();
                }
                else
                {
                    connected = readBool.IsSuccess;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }
        /// <summary>
        /// bool批量读取
        ///  数值首个元素代表读取是否成功
        /// </summary>
        /// <param name="address">PLC的寄存器首地址</param>
        /// <param name="length">读取个数</param>
        public string ReadBool(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<bool[]> result = HSL_plc.ReadBool(address, length);

                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }
        /// <summary>
        /// short读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadInt16(string address)
        {
            try
            {
                OperateResult<short> result = HSL_plc.ReadInt16(address);
                if (result.IsSuccess)
                {
                    return result.Content.ToString();
                }
                else
                {
                    connected = false;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }

        /// <summary>
        /// int32读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadInt32(string address)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<int> result = HSL_plc.ReadInt32(address);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }

        /// <summary>
        /// long读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadLong(string address)
        {
            try
            {
                OperateResult<long> result = HSL_plc.ReadInt64(address);
                if (result.IsSuccess)
                {
                    return result.Content.ToString();
                }
                else
                {
                    connected = false;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }

        /// <summary>
        /// Float读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadFloat(string address)
        {
            try
            {
                OperateResult<float> result = HSL_plc.ReadFloat(address);
                if (result.IsSuccess)
                {
                    return result.Content.ToString();
                }
                else
                {
                    connected = false;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }

        /// <summary>
        /// Double读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        public string ReadDouble(string address)
        {
            try
            {
                OperateResult<double> result = HSL_plc.ReadDouble(address);
                if (result.IsSuccess)
                {
                    return result.Content.ToString();
                }
                else
                {
                    connected = false;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }

        /// <summary>
        /// string读取
        ///  读取成功返回寄存器数值
        ///  读取失败返回Fail
        /// </summary>
        /// <param name="address">PLC的寄存器地址</param>
        /// <param name="length">字符串长度</param>
        public string ReadString(string address, ushort length)
        {
            try
            {
                OperateResult<string> result = HSL_plc.ReadString(address, length);
                if (result.IsSuccess)
                {
                    return result.Content.ToString();
                }
                else
                {
                    connected = false;
                    return "Fail";
                }
            }
            catch { return "Fail"; }
        }

        public string ReadInt16(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<short[]> result = HSL_plc.ReadInt16(address, length);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }

        public string ReadInt32(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<int[]> result = HSL_plc.ReadInt32(address, length);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }

        public bool Write(string address, object value)
        {
            try
            {
                OperateResult WriteResult = null;
                if(value is bool)
                {
                    WriteResult = HSL_plc.Write(address, (bool)(value));
                }
                else if(value is bool[])
                {
                    WriteResult = HSL_plc.Write(address, (bool[])(value));
                }
               else if (value is double)
                {
                    WriteResult = HSL_plc.Write(address, (double)(value));
                }
                else if (value is double[])
                {
                    WriteResult = HSL_plc.Write(address, (double[])value);
                }
                else if(value is Int16)
                {
                    WriteResult = HSL_plc.Write(address, (Int16)value);
                }
                else if(value is Int16[])
                {
                    WriteResult = HSL_plc.Write(address, (Int16[])value);
                }
                else if (value is Int32)
                {
                    WriteResult = HSL_plc.Write(address, (Int32)value);
                }
                else if (value is Int32[])
                {
                    WriteResult = HSL_plc.Write(address, (Int32[])value);
                }
                else if (value is long)
                {
                    WriteResult = HSL_plc.Write(address, (long)value);
                }
                else if (value is long[])
                {
                    WriteResult = HSL_plc.Write(address, (long[])value);
                }
                else if (value is float)
                {
                    WriteResult = HSL_plc.Write(address, (float)value);
                }
                else if (value is float[])
                {
                    WriteResult = HSL_plc.Write(address, (float[])value);
                }
                else if (value is string)
                {
                    WriteResult = HSL_plc.Write(address, (string)value);
                }

                return WriteResult.IsSuccess;
            }
            catch { return false; }
        }

        public string ReadLong(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<long[]> result = HSL_plc.ReadInt64(address, length);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }

        public string ReadFloat(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<float[]> result = HSL_plc.ReadFloat(address, length);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }

        public string ReadDouble(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<double[]> result = HSL_plc.ReadDouble(address, length);
                if (result.IsSuccess)
                {
                    strResult = String.Join(",", result.Content);
                }
                else
                {
                    connected = false;
                }
                return strResult;
            }
            catch { return strResult; }
        }
    }
}
