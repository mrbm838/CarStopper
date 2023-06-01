using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cowain
{
   public interface IPLC
    {
        bool connected { get; set; }
        void Connect();
        bool Connect(string ip, int port,string keyName);
        void Close();
        string ReadBool(string address);
        string ReadBool(string address, ushort length);
        string ReadInt16(string address);
        string ReadInt16(string address, ushort length);
        string ReadInt32(string address);
        string ReadInt32(string address, ushort length);
        string ReadLong(string address);
        string ReadLong(string address, ushort length);
        string ReadFloat(string address);
        string ReadFloat(string address, ushort length);
        string ReadDouble(string address);
        string ReadDouble(string address, ushort length);
        string ReadString(string address, ushort length);
        bool Write(string address, object value);
    }
}
