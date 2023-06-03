using OP010;
using DataModel;
using Cowain;
using mySocket;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NPOI.HSSF.Util.HSSFColor;

namespace OP010
{
    public partial class FrmShow : UIPage
    {
        LogClass myLog;
        SaveData mySaveData;
        IPLC PLC;
        GT_Helper myGT_Helper;

        WorkProcess myWorkProcess;


        public FrmShow(LogClass log, IPLC pLC, GT_Helper helper, WorkProcess work)
        {
            InitializeComponent();
            InitLabels();
            myLog = log;
            myGT_Helper = helper;
            PLC = pLC;
            myWorkProcess = work;
            myWorkProcess.DelSn += MyWorkProcess_DelSn;
            myWorkProcess.DelPoint += MyWorkProcess_DelPoint;
            myWorkProcess.DelResult += MyWorkProcess_DelResult;
            myWorkProcess.DelTextBox += MyWorkProcess_DelTextBox;
            myWorkProcess.DelDgvClear += MyWorkProcess_DelDgv;
            myWorkProcess.DelLabel += MyWorkProcess_DelLabel;

            StaticParam.b_Silence = new Ping().Send(StaticParam.SilenceIP).Status == IPStatus.Success;
            timer1.Enabled = true;
        }

        private void MyWorkProcess_DelLabel(Dictionary<string, bool> pairs)
        {
            Invoke((EventHandler)delegate
            {
                for (int i = 0; i < pairs.Count; i++)
                {
                    KeyValuePair<string, bool> keyValuePair = pairs.ElementAt(i);
                    if (!keyValuePair.Value)
                    {
                        StaticParam.listLabels[i].Visible = true;
                        StaticParam.listLabels[i].BackColor = Color.Red;
                    }
                    else
                    {
                        StaticParam.listLabels[i].Visible = true;
                        StaticParam.listLabels[i].BackColor = Color.Green;
                    }
                }
            });

        }

        /// <summary>
        /// 将label加入集合中
        /// </summary>
        private void InitLabels()
        {
            StaticParam.listLabels.Add(uiLbl_P1);
            StaticParam.listLabels.Add(uiLbl_P2);
            StaticParam.listLabels.Add(uiLbl_P3);
            StaticParam.listLabels.Add(uiLbl_P4);
            StaticParam.listLabels.Add(uiLbl_P5);
            StaticParam.listLabels.Add(uiLbl_P6);
            StaticParam.listLabels.Add(uiLbl_P7);
            StaticParam.listLabels.Add(uiLbl_P8);
            StaticParam.listLabels.Add(uiLbl_P9);
            StaticParam.listLabels.Add(uiLbl_P10);
            StaticParam.listLabels.Add(uiLbl_P11);
            StaticParam.listLabels.Add(uiLbl_P12);
            StaticParam.listLabels.Add(uiLbl_P13);
            StaticParam.listLabels.Add(uiLbl_P14);
            StaticParam.listLabels.Add(uiLbl_P15);
            StaticParam.listLabels.Add(uiLbl_P16);
            StaticParam.listLabels.Add(uiLbl_P17);
            StaticParam.listLabels.Add(uiLbl_P18);
            StaticParam.listLabels.Add(uiLbl_P19);
            StaticParam.listLabels.Add(uiLbl_P20);
            StaticParam.listLabels.Add(uiLbl_P21);
            StaticParam.listLabels.Add(uiLbl_P22);
            StaticParam.listLabels.Add(uiLbl_P23);
            StaticParam.listLabels.Add(uiLbl_P24);
            StaticParam.listLabels.Add(uiLbl_P25);
            StaticParam.listLabels.Add(uiLbl_P26);
            StaticParam.listLabels.Add(uiLbl_P27);
            StaticParam.listLabels.Add(uiLbl_P28);
            StaticParam.listLabels.Add(uiLbl_P29);
            StaticParam.listLabels.Add(uiLbl_P30);
            StaticParam.listLabels.Add(uiLbl_P31);
            StaticParam.listLabels.Add(uiLbl_P32);
            StaticParam.listLabels.Add(uiLbl_P33);
            StaticParam.listLabels.Add(uiLbl_P34);

            //for (int i = 0; i < 34; i++)
            //{
            //    //StaticParam.listLabels[i].BackColor = Color.Green;
            //    StaticParam.listLabels[i].Visible = false;
            //}
        }

        /// <summary>
        /// 清空表格
        /// </summary>
        private void MyWorkProcess_DelDgv()
        {
            Invoke((EventHandler)delegate
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                dataGridView5.Rows.Clear();
            });
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        private void MyWorkProcess_DelTextBox()
        {
            Invoke((EventHandler)delegate
            {
                this.txt_Scan.Clear();
                this.txt_Scan.Focus();
            });
        }

        /// <summary>
        /// 纠正结果映射
        /// </summary>
        /// <param name="code"></param>
        private void MyWorkProcess_DelResult(string code)
        {
            Invoke((EventHandler)delegate
            {
                this.lbl_Result.Text = code;
                if (code == "OK")
                {
                    this.lbl_Result.BackColor = Color.Green;
                }
                else
                {
                    this.lbl_Result.BackColor = Color.Red;
                }
            });
        }

        /// <summary>
        /// 映射结果到表格显示
        /// </summary>
        /// <param name="list">点位集合</param>
        /// <param name="pairs">点位及结果地址</param>
        private void MyWorkProcess_DelPoint(List<double> list, Dictionary<string, bool> pairs)
        {
            Invoke((EventHandler)delegate
            {
                dataGridView1.Rows.Clear();
                Show(dataGridView1, list, pairs, 0, 7);
                dataGridView2.Rows.Clear();
                Show(dataGridView2, list, pairs, 7, 14);
                dataGridView3.Rows.Clear();
                Show(dataGridView3, list, pairs, 14, 21);
                dataGridView4.Rows.Clear();
                Show(dataGridView4, list, pairs, 21, 28);
                dataGridView5.Rows.Clear();
                Show(dataGridView5, list, pairs, 28, 34);
            });
        }

        private void Show(DataGridView gridView, List<double> list, Dictionary<string, bool> pairs, int start, int end)
        {
            //Invoke((EventHandler)delegate
            {
                for (int i = start; i < end; i++)
                {
                    KeyValuePair<string, bool> kv = pairs.ElementAt(i);
                    int key = Convert.ToInt32(kv.Key) + 1;
                    gridView.Rows.Add(key.ToString(), list[i]);
                    if (kv.Value)
                    {
                        gridView.Rows[i - start].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        gridView.Rows[i - start].Cells[1].Style.BackColor = Color.Red;
                    }
                }
            } //);
        }

        /// <summary>
        /// 映射SN到textbox
        /// </summary>
        /// <param name="code">sn信息</param>
        private void MyWorkProcess_DelSn(string code)
        {
            Invoke((EventHandler)delegate
            {
                this.txt_Scan.Text = code;
                this.txt_Scan.Enabled = false;
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //---------------PLC---------------------
            if (PLC.connected)
            {
                this.lbl_plc.Text = "已连接";
                this.lbl_plc.BackColor = Color.Green;
            }
            else
            {
                this.lbl_plc.Text = "未连接";
                this.lbl_plc.BackColor = Color.Red;
            }

            //--------------扫码枪-------------------
            if (StaticParam.socketDic["扫码枪"].str_ClientConnectionOK == "OK")
            {
                this.lbl_scan.Text = "已连接";
                this.lbl_scan.BackColor = Color.Green;
            }
            else
            {
                this.lbl_scan.Text = "未连接";
                this.lbl_scan.BackColor = Color.Red;
            }

            //--------------网络通信单元--------------
            if (StaticParam.socketDic["Dlen1"].str_ClientConnectionOK == "OK")
            {
                this.lbl_dlen1.Text = "已连接";
                this.lbl_dlen1.BackColor = Color.Green;
            }
            else
            {
                this.lbl_dlen1.Text = "未连接";
                this.lbl_dlen1.BackColor = Color.Red;
            }

            if (StaticParam.socketDic["Dlen2"].str_ClientConnectionOK == "OK")
            {
                this.lbl_dlen2.Text = "已连接";
                this.lbl_dlen2.BackColor = Color.Green;
            }
            else
            {
                this.lbl_dlen2.Text = "未连接";
                this.lbl_dlen2.BackColor = Color.Red;
            }

            if (StaticParam.socketDic["Dlen3"].str_ClientConnectionOK == "OK")
            {
                this.lbl_dlen3.Text = "已连接";
                this.lbl_dlen3.BackColor = Color.Green;
            }
            else
            {
                this.lbl_dlen3.Text = "未连接";
                this.lbl_dlen3.BackColor = Color.Red;
            }

            if (StaticParam.socketDic["Dlen4"].str_ClientConnectionOK == "OK")
            {
                this.lbl_dlen4.Text = "已连接";
                this.lbl_dlen4.BackColor = Color.Green;
            }
            else
            {
                this.lbl_dlen4.Text = "未连接";
                this.lbl_dlen4.BackColor = Color.Red;
            }

            //---------------静音房---------------------
            if (StaticParam.b_Silence)
            {
                this.lbl_sql.Text = "已连接";
                this.lbl_sql.BackColor = Color.Green;
            }
            else
            {
                this.lbl_sql.Text = "未连接";
                this.lbl_sql.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// plc重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_plc_Click(object sender, EventArgs e)
        {
            StaticParam.plcDic["PLC"]?.Connect();
        }

        /// <summary>
        /// 扫码枪重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_scan_Click(object sender, EventArgs e)
        {
            ((SocketClient)StaticParam.socketDic["扫码枪"])?.ReStart();
        }

        /// <summary>
        /// 通信模块1重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_dlen1_Click(object sender, EventArgs e)
        {
            ((SocketClient)StaticParam.socketDic["Dlen1"])?.ReStart();
        }

        /// <summary>
        /// 通信模块2重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_dlen2_Click(object sender, EventArgs e)
        {
            ((SocketClient)StaticParam.socketDic["Dlen2"])?.ReStart();
        }

        /// <summary>
        /// 通信模块3重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_dlen3_Click(object sender, EventArgs e)
        {
            ((SocketClient)StaticParam.socketDic["Dlen3"])?.ReStart();
        }

        /// <summary>
        /// 通信模块4重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_dlen4_Click(object sender, EventArgs e)
        {
            ((SocketClient)StaticParam.socketDic["Dlen4"])?.ReStart();
        }

        /// <summary>
        /// 静音房链接状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_sql_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(StaticParam.SilenceIP, 2000);
            StaticParam.b_Silence = reply.Status == IPStatus.Success;
        }
    }
}
