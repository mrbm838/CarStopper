using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Core;
using Cowain;
using BYD2181;

namespace Cowain
{
    public class OmronFinsUdp : IPLC
    {

        private HslCommunication.Profinet.Omron.OmronFinsUdp omronFinsUdp;
        string addrExist = "D100";

        public bool connected { get; set; } = false;


        public OmronFinsUdp()
        {
            
        }


        public void Close() { }

        public void Connect() 
        {
            Connect(omronFinsUdp.IpAddress, Convert.ToInt32(omronFinsUdp.Port), "");
        }

        public bool Connect(string ip, int port, string keyName)
        {
            omronFinsUdp = new HslCommunication.Profinet.Omron.OmronFinsUdp(ip, port);

            DataFormat df = DataFormat.ABCD;
            omronFinsUdp.ByteTransform.DataFormat = df;
            connected = omronFinsUdp.ReadInt16(addrExist).IsSuccess;
            return connected;
        }
        public string ReadBool(string address)
        {
            string strResult = "FALSE";
            try
            {
                OperateResult<bool> result = omronFinsUdp.ReadBool(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadBool(string address, ushort length)
        {
            string strResult = "FALSE";
            try
            {
                OperateResult<bool[]> result = omronFinsUdp.ReadBool(address, length);
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

        public string ReadShort(string address)
        {
            string strResult = "0";
            try
            {
                OperateResult<short> result = omronFinsUdp.ReadInt16(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadShort(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<short[]> result = omronFinsUdp.ReadInt16(address, length);
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

        public string ReadInt32(string address)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<int> result = omronFinsUdp.ReadInt32(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadInt32(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<int[]> result = omronFinsUdp.ReadInt32(address, length);
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

        public string ReadLong(string address)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<long> result = omronFinsUdp.ReadInt64(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadLong(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<long[]> result = omronFinsUdp.ReadInt64(address, length);
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

        public string ReadFloat(string address)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<float> result = omronFinsUdp.ReadFloat(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadFloat(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<float[]> result = omronFinsUdp.ReadFloat(address, length);
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

        public string ReadDouble(string address)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<double> result = omronFinsUdp.ReadDouble(address);
                connected = result.IsSuccess;
                return result.IsSuccess ? result.Content.ToString() : strResult;
            }
            catch { return strResult; }
        }

        public string ReadDouble(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<double[]> result = omronFinsUdp.ReadDouble(address, length);
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

        public string ReadString(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<string> result = omronFinsUdp.ReadString(address, length);
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
         bool   bResult = false;
            Type type = value.GetType();
            if (value is Boolean)
            {
                bResult = omronFinsUdp.Write(address, (Boolean)value).IsSuccess;
            }
            else if (value is Boolean[])
            {
                bResult = omronFinsUdp.Write(address, (Boolean[])value).IsSuccess;
            }
            else if (value is Int16)
            {
                bResult = omronFinsUdp.Write(address, (Int16)value).IsSuccess;
            }
            else if (value is Int16[])
            {
                bResult = omronFinsUdp.Write(address, (Int16[])value).IsSuccess;
            }
            else if (value is Int32)
            {
                bResult = omronFinsUdp.Write(address, (Int32)value).IsSuccess;
            }
            else if (value is Int32[])
            {
                bResult = omronFinsUdp.Write(address, (Int32[])value).IsSuccess;
            }
            else if (value is Int64)
            {
                bResult = omronFinsUdp.Write(address, (Int64)value).IsSuccess;
            }
            else if (value is Int64[])
            {
                bResult = omronFinsUdp.Write(address, (Int64[])value).IsSuccess;
            }
            else if (value is Single)
            {
                bResult = omronFinsUdp.Write(address, (Single)value).IsSuccess;
            }
            else if (value is Single[])
            {
                bResult = omronFinsUdp.Write(address, (Single[])value).IsSuccess;
            }
            else if (value is Double)
            {
                bResult = omronFinsUdp.Write(address, (Double)value).IsSuccess;
            }
            else if (value is Double[])
            {
                bResult = omronFinsUdp.Write(address, (Double[])value).IsSuccess;
            }
            else if (value is String)
            {
                bResult = omronFinsUdp.Write(address, (String)value).IsSuccess;
            }
            return bResult;
        }

        public string ReadInt16(string address)
        {
            return ReadShort(address);
            //string strResult = "Fail";
            //try
            //{
            //    OperateResult<int> result = omronFinsUdp.ReadInt32(address);
            //    connected = result.IsSuccess;
            //    return result.IsSuccess ? result.Content.ToString() : strResult;
            //}
            //catch { return strResult; }
        }

        public string ReadInt16(string address, ushort length)
        {
            string strResult = "Fail";
            try
            {
                OperateResult<short[]> result = omronFinsUdp.ReadInt16(address, length);
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
