using Cowain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.ModBus;
using System.Text.RegularExpressions;
using BYD2181;

namespace Cowain
{
    /// <summary>
    /// 信捷PLC通信类，目前封装的为XD5、XDM、XDC、XD5E、XDME、XL5、XL5E、XLME 系列
    /// 且X、Y、R、D均为CPU本体的地址，不包含拓展模块。
    /// 即此类的地址映射不全面
    /// </summary>
    public class XinJieHelper : IPLC
    {
        

        private ModbusTcpNet Hsl_XJ;
        public bool connected
        {
            get;
            set;
        } = false;


        public XinJieHelper()
        {
            
        }

        #region PLC的连接和断开

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Close()
        {
            try
            {
                OperateResult connect = Hsl_XJ.ConnectClose();
                if (connect.IsSuccess)
                {
                    connected = false;
                }
                else
                {
                    connected = true;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 不用
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Connect()
        {
            Connect(Hsl_XJ.IpAddress, Convert.ToInt32(Hsl_XJ.Port), "");
        }

        /// <summary>
        /// 不用
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Connect(string ip, int port, string keyName)
        {
            try
            {
                Hsl_XJ = new ModbusTcpNet(ip, port);
                Hsl_XJ.ConnectClose();
                OperateResult result = Hsl_XJ.ConnectServer();
                Hsl_XJ.DataFormat = DataFormat.CDAB;
                if (!result.IsSuccess)
                {
                    connected = false;
                }
                else
                {
                    connected = true;
                }
                return connected;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 不用
        /// </summary>
        public void DisConnect()
        {
        }
        #endregion


        /// <summary>
        /// 读取多个线圈/布尔值
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns>多个值</returns>
        public string ReadBool(string address, ushort length)
        {
            string returnStr = string.Empty;
            string ad = string.Empty;
            for (int i = 0; i < length; i++)
            {
                ad = (Convert.ToInt32(ParseInputAddress(address)) + i).ToString();
                OperateResult<bool> result = Hsl_XJ.ReadCoil(ad);
                connected = result.IsSuccess;
                returnStr += (result.Content.ToString() + ",");
            }
            if (returnStr.Length > 0)
            {
                returnStr = returnStr.Substring(0, returnStr.Length - 1);
            }
            return returnStr;
        }

        /// <summary>
        /// 单个读取线圈/布尔值
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>值</returns>
        public string ReadBool(string address)
        {
            OperateResult<bool> result = Hsl_XJ.ReadCoil(ParseInputAddress(address));
            connected = result.IsSuccess;
            return result.Content.ToString();
        }

        /// <summary>
        /// 读取单个Double类型值
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>值</returns>
        public string ReadDouble(string address)
        {
            string ad = ReflectModbusDAddress(address).ToString();
            OperateResult<double> result = Hsl_XJ.ReadDouble(ad);
            connected = result.IsSuccess;
            return result.Content.ToString();
        }

        /// <summary>
        /// 读取多个Double类型值
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns>多个值</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string ReadDouble(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < 4 * length; i += 4)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<double> result = Hsl_XJ.ReadDouble(ad);
                connected = result.IsSuccess;
                values += (result.Content.ToString() + ",");
            }
            if (values.Length>0)
            {
                values = values.Substring(0, values.Length - 1);
            }
            return values;
        }

        /// <summary>
        /// 读取单个Float类型值
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>值</returns>
        public string ReadFloat(string address)
        {
            string ad = ReflectModbusDAddress(address).ToString();
            OperateResult<float> result = Hsl_XJ.ReadFloat(ad);
            connected = result.IsSuccess;
            return result.Content.ToString();
        }

        /// <summary>
        /// 读取多个Float类型值
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns>多个值</returns>
        public string ReadFloat(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < 2 * length; i += 2)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<float> result = Hsl_XJ.ReadFloat(ad);
                connected = result.IsSuccess;
                values += (result.Content.ToString() + ",");
            }
            if (values.Length > 0)
            {
                values = values.Substring(0, values.Length - 1);
            }
            return values;
        }

        /// <summary>
        /// 读取单个Int16类型值（单字）
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>值</returns>
        public string ReadInt16(string address)
        {
            string ad = ReflectModbusDAddress(address).ToString();
            OperateResult<Int16> result = Hsl_XJ.ReadInt16(ad);
            connected = result.IsSuccess;
            return result.Content.ToString();
        }

        /// <summary>
        /// 读取多个Int16类型值（单字）
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns>多个值</returns>
        public string ReadInt16(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<Int16> result = Hsl_XJ.ReadInt16(ad);
                connected = result.IsSuccess;
                values += (result.Content.ToString() + ",");
            }
            if (values.Length > 0)
            {
                values = values.Substring(0, values.Length - 1);
            }
            return values;
        }

        /// <summary>
        /// 读取Int32类型值（双字）
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns>写入结果</returns>
        public string ReadInt32(string address)
        {
            string ad = ReflectModbusDAddress(address).ToString();
            OperateResult<Int32> result = Hsl_XJ.ReadInt32(ad);
            connected = result.IsSuccess;
            return result.Content.ToString();

        }

        /// <summary>
        /// 读取多个Int32类型值（双字）
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string ReadInt32(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < 2 * length; i += 2)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<Int32> result = Hsl_XJ.ReadInt32(ad);
                connected = result.IsSuccess;
                values += (result.Content.ToString() + ",");
            }
            if (values.Length > 0)
            {
                values = values.Substring(0, values.Length - 1);
            }
            return values;
        }

        /// <summary>
        /// 读取单个Long类型值（四字）
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string ReadLong(string address)
        {
            string ad = ReflectModbusDAddress(address).ToString();
            OperateResult<Int64> result = Hsl_XJ.ReadInt64(ad);
            connected = result.IsSuccess;
            return result.Content.ToString();
        }

        /// <summary>
        /// 读取多个Long类型值（四字）
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string ReadLong(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < 4 * length; i += 4)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<Int64> result = Hsl_XJ.ReadInt64(ad);
                connected = result.IsSuccess;
                values += (result.Content.ToString() + ",");
            }
            if (values.Length > 0)
            {
                values = values.Substring(0, values.Length - 1);
            }
            return values;
        }

        /// <summary>
        /// 读取字符串
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public string ReadString(string address, ushort length)
        {
            string values = string.Empty;
            for (int i = 0; i < 4 * length; i += 4)
            {
                string ad = (Convert.ToInt32(ReflectModbusDAddress(address)) + i).ToString();
                OperateResult<string> result = Hsl_XJ.ReadString(ad, length);
                connected = result.IsSuccess;
                return result.Content.ToString();
            }
            return values;
        }

        /// <summary>
        /// 通用写
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="value">值</param>
        /// <returns>写入结果</returns>
        public bool Write(string address, object value)
        {
            try
            {
                bool bResult = false;
                string ad = ReflectModbusDAddress(address);
                if (value is Boolean)
                {
                    bResult = Hsl_XJ.Write(ParseInputAddress(address), (Boolean)value).IsSuccess;
                    //bResult = WriteBool(address,value);
                }
                else if (value is Boolean[])
                {
                    bResult = Hsl_XJ.Write(ParseInputAddress(address), (Boolean[])value).IsSuccess;
                }
                else if (value is Int16)
                {
                    bResult = Hsl_XJ.Write(ad, (Int16)value).IsSuccess;
                }
                else if (value is Int16[])
                {
                    bResult = Hsl_XJ.Write(ad, (Int16[])value).IsSuccess;
                }
                else if (value is Int32)
                {
                    bResult = Hsl_XJ.Write(ad, (Int32)value).IsSuccess;
                }
                else if (value is Int32[])
                {
                    bResult = Hsl_XJ.Write(ad, (Int32[])value).IsSuccess;
                }
                else if (value is Int64)
                {
                    bResult = Hsl_XJ.Write(ad, (Int64)value).IsSuccess;
                }
                else if (value is Int64[])
                {
                    bResult = Hsl_XJ.Write(ad, (Int64[])value).IsSuccess;
                }
                else if (value is Single)
                {
                    bResult = Hsl_XJ.Write(ad, (Single)value).IsSuccess;
                }
                else if (value is Single[])
                {
                    bResult = Hsl_XJ.Write(ad, (Single[])value).IsSuccess;
                }
                else if (value is Double)
                {
                    bResult = Hsl_XJ.Write(ad, (Double)value).IsSuccess;
                }
                else if (value is Double[])
                {
                    bResult = Hsl_XJ.Write(ad, (Double[])value).IsSuccess;
                }
                else if (value is String)
                {
                    bResult = Hsl_XJ.Write(ad, (String)value).IsSuccess;
                }
                return bResult;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        #region 不用的方法
        /// <summary>
        /// 写Float类型值
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="value">值</param>
        /// <returns>写入结果</returns>
        //public bool Writefloat(string address, object value)
        //{
        //    string ad = string.Empty;
        //    char[] type = address.ToUpper().ToCharArray();
        //    char[] newChar = new char[type.Length - 1];
        //    Array.Copy(type, 1, newChar, 0, type.Length - 1);
        //    string str = string.Empty;
        //    for (int i = 0; i < newChar.Length; i++)
        //    {
        //        str += newChar[i];
        //    }
        //    ad = str;
        //    OperateResult result = Hsl_XJ.Write(ad, (float)value);
        //    if (result.IsSuccess)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 写Bool值
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns>写入结果</returns>
        //public bool WriteBool(string address, object value)
        //{
        //    bool writeValue = false;
        //    string ad = ParseInputAddress(address);
        //    if (value.ToString() == "0" || value.ToString().ToLower() == "false")
        //    {
        //        writeValue = false;
        //    }
        //    if (value.ToString() == "1" || value.ToString().ToLower() == "true")
        //    {
        //        writeValue = true;
        //    }
        //    OperateResult result = Hsl_XJ.Write(ad, writeValue);
        //    if (result.IsSuccess)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion



        /// <summary>
        /// 解析输入的地址
        /// </summary>
        /// <param name="address">输入的地址</param>
        /// <returns></returns>
        private string ParseInputAddress(string address)
        {
            string ad = string.Empty;
            char[] type = address.ToUpper().ToCharArray();
            char[] newChar = new char[type.Length - 1];
            Array.Copy(type, 1, newChar, 0, type.Length - 1);
            string str = string.Empty;
            for (int i = 0; i < newChar.Length; i++)
            {
                str += newChar[i];
            }
            int num = int.Parse(str);
            switch (type[0])
            {
                case 'M':
                    ad = str;
                    break;
                case 'X':
                    ad = ReflectModbusAddress(num, 20480);
                    break;
                case 'Y':
                    ad = ReflectModbusAddress(num, 24576);
                    break;
                default:
                    break;
            }
            return ad;
        }

        /// <summary>
        /// 三个类型PLC通用的X、Y映射Modbus地址
        /// </summary>
        /// <param name="num">输入的数字部分</param>
        /// <param name="startNum">Modbus起始地址</param>
        /// <returns>对应的modbus地址（十进制）</returns>
        private string ReflectModbusAddress(int num, int startNum)
        {
            string modbusAddress = string.Empty;
            if (num <= 77)
            {
                modbusAddress = (startNum + 8 * (num / 10) + (num % 10)).ToString();
            }
            return modbusAddress;
        }

        /// <summary>
        /// 三个类型PLC通用的D寄存器映射Modbus地址
        /// </summary>
        /// <param name="address">输入的地址</param>
        /// <returns>映射的地址</returns>
        private string ReflectModbusDAddress(string address)
        {
            //string ad = string.Empty;
            //char[] c = address.ToUpper().ToCharArray();
            //char[] newChar = new char[c.Length - 1];
            //Array.Copy(c, 1, newChar, 0, c.Length - 1);
            //string str = string.Empty;
            //for (int i = 0; i < newChar.Length; i++)
            //{
            //    str += newChar[i];
            //}
            //ad = str;

            string ad = string.Empty;
            string charName = string.Empty;
            string charNum = string.Empty;
            char[] chars= address.ToUpper().ToCharArray();
            bool bResult=false;
            int a = 0;
            int b = 0;
            for (int i = chars.Length-1; i >= 0; i--)
            {
                bResult = int.TryParse(chars[i].ToString(),out a);
                if (!bResult)
                {
                    b = i;
                    break;
                }
            }
            for (int i = 0; i <= b; i++)
            {
                charName += chars[i];
            }
            for (int i = b+1; i < chars.Length; i++)
            {
                charNum += chars[i];
            }
            switch (charName)
            {
                case "D":
                    ad = charNum;
                    break;
                case "ID":
                    ad = ReflectDifferentModuleAddress(charName, charNum);
                    break;
                case "QD":
                    ad = ReflectDifferentModuleAddress(charName, charNum);
                    break;
                case "SD":
                    ad = (28672 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "TD":
                    ad = (32768 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "CD":
                    ad = (36864 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "ETD":
                    ad = (40960 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "HD":
                    ad = (41088 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "HSD":
                    ad = (47232 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "HTD":
                    ad = (48256 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "HCD":
                    ad = (49280 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "HSCD":
                    ad = (50304 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "FD":
                    ad = (50368 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "SFD":
                    ad = (58560 + Convert.ToInt32(charNum)).ToString();
                    break;
                case "FS":
                    ad = (62656 + Convert.ToInt32(charNum)).ToString();
                    break;
            }
            return ad;
        }


        private string ReflectDifferentModuleAddress(string name, string num)
        {
            int a = (Convert.ToInt32(num)) / 100;
            int b = (Convert.ToInt32(num)) % 100;
            string strNum = string.Empty;
            switch (a)
            {
                case 0:
                    if (name == "ID")
                    {
                        strNum = (20480 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (24576 + b).ToString();
                    }
                    break;
                case 100:
                    if (name=="ID")
                    {
                        strNum = (20736 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (24832 + b).ToString();
                    }
                    break;
                case 101:
                    if (name == "ID")
                    {
                        strNum = (20836 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (24932 + b).ToString();
                    }
                    break;
                case 102:
                    if (name == "ID")
                    {
                        strNum = (20936 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25032 + b).ToString();
                    }
                    break;
                case 103:
                    if (name == "ID")
                    {
                        strNum = (21036 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25132 + b).ToString();
                    }
                    break;
                case 104:
                    if (name == "ID")
                    {
                        strNum = (21136 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25232 + b).ToString();
                    }
                    break;
                case 105:
                    if (name == "ID")
                    {
                        strNum = (21236 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25332 + b).ToString();
                    }
                    break;
                case 106:
                    if (name == "ID")
                    {
                        strNum = (21336 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25432 + b).ToString();
                    }
                    break;
                case 107:
                    if (name == "ID")
                    {
                        strNum = (21436 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25532 + b).ToString();
                    }
                    break;
                case 108:
                    if (name == "ID")
                    {
                        strNum = (21536 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25632 + b).ToString();
                    }
                    break;
                case 109:
                    if (name == "ID")
                    {
                        strNum = (21636 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25732 + b).ToString();
                    }
                    break;
                case 110:
                    if (name == "ID")
                    {
                        strNum = (21736 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25832 + b).ToString();
                    }
                    break;
                case 111:
                    if (name == "ID")
                    {
                        strNum = (21836 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (25932 + b).ToString();
                    }
                    break;
                case 112:
                    if (name == "ID")
                    {
                        strNum = (21936 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26032 + b).ToString();
                    }
                    break;
                case 113:
                    if (name == "ID")
                    {
                        strNum = (22036 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26132 + b).ToString();
                    }
                    break;
                case 114:
                    if (name == "ID")
                    {
                        strNum = (22136 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26232 + b).ToString();
                    }
                    break;
                case 115:
                    if (name == "ID")
                    {
                        strNum = (22236 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26332 + b).ToString();
                    }
                    break;
                case 200:
                    if (name == "ID")
                    {
                        strNum = (22736 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26832 + b).ToString();
                    }
                    break;
                case 201:
                    if (name == "ID")
                    {
                        strNum = (22836 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (26932 + b).ToString();
                    }
                    break;
                case 300:
                    if (name == "ID")
                    {
                        strNum = (23536 + b).ToString();
                    }
                    if (name == "QD")
                    {
                        strNum = (27632 + b).ToString();
                    }
                    break;
            }
            return strNum;
        }
    }
}
