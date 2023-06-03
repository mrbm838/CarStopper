using Cowain;
using HslCommunication.Core;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC通讯协议
{
    public partial class FrmPLCTest : UIForm
    {
        IPLC HSL_plc = null;
        private string IP = "192.168.1.188";
        private Int32 port = 502;
        private byte station = 1;
        private bool isAddressStartWithZero = true;
        private bool isStringReverse = false;
        private DataFormat dataFormat = DataFormat.CDAB;
        private int connectTimeOut = 2000;
        public FrmPLCTest(IPLC HSL_plc1,string ip,string port)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//在屏幕中心显示
            HSL_plc = HSL_plc1;
            this.uiTxt_IP.Text = ip;
            this.uiTxt_Port.Text = port;
        }

        public void SetParameter(string IP1, Int32 port1, byte station1, bool isAddressStartWithZero1, bool isStringReverse1, DataFormat dataFormat1, int connectTimeOut1)
        {
            IP = IP1;
            port = port1;
            station = station1;
            isAddressStartWithZero = isAddressStartWithZero1;
            isStringReverse = isStringReverse1;
            dataFormat = dataFormat1;
            connectTimeOut = connectTimeOut1;
        }

        private void OmronFinsTcpForm_Load(object sender, EventArgs e)
        {
            uiCbx_DataFormat.DataSource = HslCommunication.BasicFramework.SoftBasic.GetEnumValues<HslCommunication.Core.DataFormat>();
            uiCbx_DataFormat.SelectedItem = HslCommunication.Core.DataFormat.ABCD;
            uiCbx_AddrType.SelectedItem = "bool";
            this.TopMost = true;
            this.TopMost = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  if (HSL_plc.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToByte(textBox16.Text), checkBox1.Checked, checkBox2.Checked, (HslCommunication.Core.DataFormat)comboBox1.SelectedItem, Convert.ToInt32(textBox4.Text)))
            if (HSL_plc.Connect(uiTxt_IP.Text, Convert.ToInt16(uiTxt_Port.Text), ""))
            {
                MessageBox.Show("连接成功");
                uiBtn_Connect.Enabled = false;
                uiBtn_DisConnect.Enabled = true;
                panel2.Enabled = true;
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HSL_plc.Close();
            uiBtn_Connect.Enabled = true;
            uiBtn_DisConnect.Enabled = false;
            panel2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                switch (uiCbx_AddrType.SelectedItem.ToString())
                {
                    case "bool": uiTxt_Value.Text = HSL_plc.ReadBool(uiTxt_Addr.Text); break;
                    case "short": uiTxt_Value.Text = HSL_plc.ReadInt16(uiTxt_Addr.Text); break;
                    case "int": uiTxt_Value.Text = HSL_plc.ReadInt32(uiTxt_Addr.Text); break;
                    case "long": uiTxt_Value.Text = HSL_plc.ReadLong(uiTxt_Addr.Text); break;
                    case "double": uiTxt_Value.Text = HSL_plc.ReadDouble(uiTxt_Addr.Text); break;
                    case "string": uiTxt_Value.Text = HSL_plc.ReadString(uiTxt_Addr.Text, Convert.ToUInt16(uiTxt_Length.Text)); break;
                }
            }
            catch { }
            if (uiTxt_Value.Text != "Fail")
            {
                MessageBox.Show("读取成功");
            }
            else
            {
                MessageBox.Show("读取失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool isok = false;
            try
            {
                switch (uiCbx_AddrType.SelectedItem.ToString())
                {
                    case "bool": isok = HSL_plc.Write(uiTxt_Addr.Text, Convert.ToBoolean(uiTxt_Value.Text)); break;
                    case "short": isok = HSL_plc.Write(uiTxt_Addr.Text, Convert.ToInt16(uiTxt_Value.Text)); break;
                    case "int": isok = HSL_plc.Write(uiTxt_Addr.Text, Convert.ToInt32(uiTxt_Value.Text)); break;
                    case "long": isok = HSL_plc.Write(uiTxt_Addr.Text, Convert.ToInt64(uiTxt_Value.Text)); break;
                    case "double": isok = HSL_plc.Write(uiTxt_Addr.Text, Convert.ToDouble(uiTxt_Value.Text)); break;
                    case "float": isok = HSL_plc.Write(uiTxt_Addr.Text, (float)Convert.ToDouble(uiTxt_Value.Text)); break;
                    case "string": isok = HSL_plc.Write(uiTxt_Addr.Text, uiTxt_Value.Text); break;
                }
            }
            catch { }
            if (isok)
            {
                MessageBox.Show("写入成功");
            }
            else
            {
                MessageBox.Show("写入失败");
            }
        }
    }
}
