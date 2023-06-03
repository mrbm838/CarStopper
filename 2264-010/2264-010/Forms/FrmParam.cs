using DataModel;
using CommunicationControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Sunny.UI;
using OP010.Forms;

namespace OP010
{
    public partial class FrmParam : UIPage
    {
        public Params myParams;
        FrmMonitor frmMonitor;
        private FrmMotion frmAxes;

        public FrmParam(Params param)
        {
            InitializeComponent();
            myParams = param;
        }

        private void FrmParam_Load(object sender, EventArgs e)
        {
            this.propertyGrid1.SelectedObject = myParams;
            frmMonitor = new FrmMonitor();
            frmAxes = new FrmMotion();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                XmlSerializeHelper<Params>.SerializeToFile(StaticParam.strBasePath, myParams);
                LogClass.AddMsg(0, "配置参数保存成功！部分参数需重启生效！");
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.currentAccount != null)
            {
                if (Program.currentAccount.User == "Admin")
                {
                    this.propertyGrid1.Enabled = true;
                    this.UIBtn_Save.Enabled = true;
                    this.UIBtn_SetCom.Enabled = true;
                }
                else
                {
                    this.propertyGrid1.Enabled = false;
                    this.UIBtn_Save.Enabled = false;
                    this.UIBtn_SetCom.Enabled = false;
                }
            }
            else
            {
                this.propertyGrid1.Enabled = false;
                this.UIBtn_Save.Enabled = false;
                this.UIBtn_SetCom.Enabled = false;
            }

        }

        private void btn_setCommunicate_Click(object sender, EventArgs e)
        {
            List<Dictionary<CommunicateConfig, string>> listCom = new List<Dictionary<CommunicateConfig, string>>();
            for (int i = 0; i < StaticParam.listComObj.Count; i++)
            {
                Dictionary<CommunicateConfig, string> configs = new Dictionary<CommunicateConfig, string>();
                configs.Add(CommunicateConfig.ControlName, StaticParam.listComObj[i].ControlName);
                configs.Add(CommunicateConfig.CommunicateType, StaticParam.listComObj[i].Type);
                configs.Add(CommunicateConfig.IP, StaticParam.listComObj[i].IP);
                configs.Add(CommunicateConfig.Port, StaticParam.listComObj[i].Port);
                configs.Add(CommunicateConfig.SocketType, StaticParam.listComObj[i].SocketType);
                configs.Add(CommunicateConfig.PLCType, StaticParam.listComObj[i].PLCType);
                configs.Add(CommunicateConfig.COM, StaticParam.listComObj[i].Com);
                configs.Add(CommunicateConfig.BaudRate, StaticParam.listComObj[i].BaudRate);
                configs.Add(CommunicateConfig.DataBits, StaticParam.listComObj[i].DataBits);
                configs.Add(CommunicateConfig.Parity, StaticParam.listComObj[i].Parity);
                configs.Add(CommunicateConfig.StopBits, StaticParam.listComObj[i].StopBits);
                listCom.Add(configs);
            }
            FrmSetCommunicate frmSet = new FrmSetCommunicate(SaveConfig, listCom);
            frmSet.Show();
        }

        private void SaveConfig(Dictionary<CommunicateConfig, string> obj)
        {
            bool b_isExist = StaticParam.listComObj.Exists(x => x.ControlName == obj[CommunicateConfig.ControlName]);
            string controlRemove = string.Empty;
            foreach (KeyValuePair<CommunicateConfig, string> item in obj)
            {
                if (item.Key == CommunicateConfig.RemoveControl)
                {
                    controlRemove = item.Value;
                }
            }
            if (controlRemove == "1")
            {
                if (b_isExist)//删除
                {
                    StaticParam.listComObj.RemoveAll(t => t.ControlName == obj[CommunicateConfig.ControlName]);
                    XmlSerializeHelper<List<Communicationobj>>.SerializeToFile(StaticParam.jsonPath, StaticParam.listComObj);
                }
            }
            else
            {
                if (b_isExist)//更新
                {
                    int i = 0;
                    foreach (Communicationobj item in StaticParam.listComObj)
                    {
                        if (item.ControlName == obj[CommunicateConfig.ControlName])
                        {
                            i = StaticParam.listComObj.IndexOf(item);
                            StaticParam.listComObj[i].Type = obj[CommunicateConfig.CommunicateType];
                            if (item.Type == "网口")
                            {
                                StaticParam.listComObj[i].SocketType = obj[CommunicateConfig.CommunicateType];
                                StaticParam.listComObj[i].IP = obj[CommunicateConfig.IP];
                                StaticParam.listComObj[i].Port = obj[CommunicateConfig.Port];
                            }
                            if (item.Type == "串口")
                            {
                                StaticParam.listComObj[i].Com = obj[CommunicateConfig.COM];
                                StaticParam.listComObj[i].BaudRate = obj[CommunicateConfig.BaudRate];
                                StaticParam.listComObj[i].Parity = obj[CommunicateConfig.Parity];
                                StaticParam.listComObj[i].DataBits = obj[CommunicateConfig.DataBits];
                                StaticParam.listComObj[i].StopBits = obj[CommunicateConfig.StopBits];
                            }
                            if (item.Type == "PLC")
                            {
                                StaticParam.listComObj[i].PLCType = obj[CommunicateConfig.PLCType];
                                StaticParam.listComObj[i].IP = obj[CommunicateConfig.IP];
                                StaticParam.listComObj[i].Port = obj[CommunicateConfig.Port];
                            }
                        }
                    }
                    XmlSerializeHelper<List<Communicationobj>>.SerializeToFile(StaticParam.jsonPath, StaticParam.listComObj);
                }
                else//添加
                {
                    Communicationobj communicationobj = new Communicationobj();
                    communicationobj.ControlName = obj[CommunicateConfig.ControlName];
                    communicationobj.Type = obj[CommunicateConfig.CommunicateType];
                    if (communicationobj.Type == "网口")
                    {
                        communicationobj.IP = obj[CommunicateConfig.IP];
                        communicationobj.Port = obj[CommunicateConfig.Port];
                        communicationobj.SocketType = obj[CommunicateConfig.SocketType];
                    }
                    if (communicationobj.Type == "串口")
                    {
                        communicationobj.Com = obj[CommunicateConfig.COM];
                        communicationobj.BaudRate = obj[CommunicateConfig.BaudRate];
                        communicationobj.Parity = obj[CommunicateConfig.Parity];
                        communicationobj.DataBits = obj[CommunicateConfig.DataBits];
                        communicationobj.StopBits = obj[CommunicateConfig.StopBits];
                    }
                    if (communicationobj.Type == "PLC")
                    {
                        communicationobj.IP = obj[CommunicateConfig.IP];
                        communicationobj.Port = obj[CommunicateConfig.Port];
                        communicationobj.PLCType = obj[CommunicateConfig.PLCType];
                    }
                    StaticParam.listComObj.Add(communicationobj);
                    XmlSerializeHelper<List<Communicationobj>>.SerializeToFile(StaticParam.jsonPath, StaticParam.listComObj);
                }

            }
        }

        private void ButtonAxes_Click(object sender, EventArgs e)
        {
            frmAxes?.Show();
        }
    }
}
