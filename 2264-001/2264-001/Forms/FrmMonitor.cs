using OP001;
using DataModel;
using mySocket;
using NPOI.Util;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP001.Forms
{
    public partial class FrmMonitor : UIForm
    {
        GT_Helper myGT_Helper;
        Thread thread;

        List<double>[] pointList;
        List<double> AllPointList = new List<double>();
        Dictionary<string, bool> correctOK;
        private ManualResetEvent manualReset;
        private bool autoRun = false;

        public FrmMonitor()
        {
            InitializeComponent();
            myGT_Helper = new GT_Helper();
            pointList = new List<double>[4];
            correctOK = new Dictionary<string, bool>();
            for (int i = 0; i < pointList.Length; i++)
            {
                pointList[i] = new List<double>();
            }
            ((SocketClient)StaticParam.socketDic["Dlen1"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent;
            ((SocketClient)StaticParam.socketDic["Dlen2"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent1;
            ((SocketClient)StaticParam.socketDic["Dlen3"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent2;
            ((SocketClient)StaticParam.socketDic["Dlen4"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent3;
            thread = new Thread(GetValue)
            {
                IsBackground = true
            };
            thread.Start();
            manualReset = new ManualResetEvent(false);
        }

        private void WorkProcess_receiveDoneSocketEvent3(string msgStr)
        {
            if (msgStr != "")
            {
                pointList[3] = myGT_Helper.GetPointsValue(msgStr);
            }
        }

        private void WorkProcess_receiveDoneSocketEvent2(string msgStr)
        {
            if (msgStr != "")
            {
                pointList[2] = myGT_Helper.GetPointsValue(msgStr);
            }
        }

        private void WorkProcess_receiveDoneSocketEvent1(string msgStr)
        {
            if (msgStr != "")
            {
                pointList[1] = myGT_Helper.GetPointsValue(msgStr);
            }
        }

        private void WorkProcess_receiveDoneSocketEvent(string msgStr)
        {
            if (msgStr != "")
            {
                pointList[0] = myGT_Helper.GetPointsValue(msgStr);
            }
        }

        /// <summary>
        /// 单词获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiBtn_Once_Click(object sender, EventArgs e)
        {
            DataGridViewsClear();
            StaticParam.socketDic["Dlen1"].SendMSG("M0\r\n");
            StaticParam.socketDic["Dlen2"].SendMSG("M0\r\n");
            StaticParam.socketDic["Dlen3"].SendMSG("M0\r\n");
            StaticParam.socketDic["Dlen4"].SendMSG("M0\r\n");
            Thread.Sleep(500);
            ShowData();
        }

        /// <summary>
        /// 连续获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiBtn_Run_Click(object sender, EventArgs e)
        {
            autoRun = !autoRun;
            if (autoRun)
            {
                manualReset.Set();
                uiBtn_Run.Text = "停止获取";
            }
            else
            {
                manualReset.Reset();
                uiBtn_Run.Text = "循环获取";
            }
        }

        private void DataGridViewsClear()
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

        private void GetValue()
        {
            while (true)
            {
                manualReset.WaitOne();
                Thread.Sleep(1000);
                AllPointList.Clear();
                DataGridViewsClear();
                StaticParam.socketDic["Dlen1"].SendMSG("M0\r\n");
                StaticParam.socketDic["Dlen2"].SendMSG("M0\r\n");
                StaticParam.socketDic["Dlen3"].SendMSG("M0\r\n");
                StaticParam.socketDic["Dlen4"].SendMSG("M0\r\n");
                ShowData();
            }
        }

        private void ShowData()
        {
            if (pointList[0].Count != 0 && pointList[1].Count != 0 && pointList[2].Count != 0 && pointList[3].Count != 0)
            {
                for (int i = 0; i < pointList.Length; i++)
                {
                    AllPointList.AddRange(pointList[i]);
                }
                correctOK = myGT_Helper.JudgeResult(AllPointList);
                Show(dataGridView1, AllPointList, correctOK, 0, 7);
                Show(dataGridView2, AllPointList, correctOK, 7, 14);
                Show(dataGridView3, AllPointList, correctOK, 14, 21);
                Show(dataGridView4, AllPointList, correctOK, 21, 28);
                Show(dataGridView5, AllPointList, correctOK, 28, 34);
                Invoke((EventHandler)delegate
                {
                    dataGridView1.Refresh();
                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                    dataGridView4.Refresh();
                    dataGridView5.Refresh();
                });
            }
        }

        private void Show(DataGridView gridView, List<double> list, Dictionary<string, bool> pairs, int start, int end)
        {
            Invoke((EventHandler)delegate
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
            });
        }
    }
}
