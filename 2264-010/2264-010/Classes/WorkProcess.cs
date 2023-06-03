using cowain;
using Cowain;
using DAL;
using DataModel;
using mySocket;
using ReadAndWriteConfigSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP010
{
    public class WorkProcess : LocalBase
    {

        LogClass myLog;
        IPLC plc;
        WorkStep m_Step;

        /// <summary>
        /// 存储点位值
        /// </summary>
        List<double>[] pointList;
        List<double> AllPointList;

        Dictionary<string, bool> hasCorrectedDictionary;
        GT_Helper myGT_Helper;
        SaveData mySaveData;

        public event DelFlashCode DelSn;
        public event DelDgv DelPoint;
        public event DelFlashCode DelResult;
        public event DelTextBox DelTextBox;
        public event DelTextBox DelDgvClear;

        public event DelLabel DelLabel;

        public OP170Data data;

        string sn = string.Empty;

        int ngTime = 0;
        private long startTime;


        public WorkProcess(LogClass log, IPLC pLC, GT_Helper helper) : base()
        {
            myLog = log;
            plc = pLC;
            myGT_Helper = helper;
            mySaveData = new SaveData(DataType.CSV, StaticParam.DataPath);
            AllPointList = new List<double>();
            pointList = new List<double>[4];
            for (int i = 0; i < pointList.Length; i++)
            {
                pointList[i] = new List<double>();
            }
            hasCorrectedDictionary = new Dictionary<string, bool>();

            ((SocketClient)StaticParam.socketDic["Dlen1"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent;
            ((SocketClient)StaticParam.socketDic["Dlen2"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent1;
            ((SocketClient)StaticParam.socketDic["Dlen3"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent2;
            ((SocketClient)StaticParam.socketDic["Dlen4"]).HandleMSGEvent += WorkProcess_receiveDoneSocketEvent3;

            //Thread thread = new Thread(StepCycle)
            //{
            //    IsBackground = true
            //};
            //thread.Start();
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

        public override void StepCycle()
        {
            m_Step = (WorkStep)m_nStep;
            switch (m_Step)
            {
                case WorkStep.GetStart:
                    LogClass.AddMsg(0, "软件启动！");
                    m_nStep = (int)WorkStep.Start;
                    break;

                case WorkStep.Start:
                    LogClass.AddMsg(0, "流程开始，等待plc触发扫码信号！");
                    Thread.Sleep(1000);
                    m_nStep = (int)WorkStep.WaitSignal;
                    break;

                //等待PLC信号
                case WorkStep.WaitSignal:
                    var result = plc.ReadInt16(StaticParam.TriggerScanAddr);
                    Thread.Sleep(100);
                    DelResult("");
                    if (result == "1")
                    {
                        LogClass.AddMsg(0, "接收到PLC的触发信号！");
                        DelDgvClear();
                        m_nStep = (int)WorkStep.TriggerScan;
                    }
                    else
                    {
                        m_nStep = (int)WorkStep.WaitSignal;
                    }
                    break;

                //触发扫码
                case WorkStep.TriggerScan:
                    LogClass.AddMsg(0, "开始触发扫码！");
                    StaticParam.socketDic["扫码枪"].SendMSG("T");
                    startTime = DateTime.Now.Ticks;
                    m_nStep = (int)WorkStep.GetSN;
                    break;

                //获取SN
                case WorkStep.GetSN:
                    var span = (DateTime.Now.Ticks - startTime) / Math.Pow(10, 7);
                    if (StaticParam.socketDic["扫码枪"].returnStr != "")
                    {
                        m_nStep = (int)WorkStep.ScanOK;
                    }
                    else if (span > StaticParam.ScanTime)
                    {
                        m_nStep = (int)WorkStep.ScanNG;
                    }
                    break;

                case WorkStep.ScanOK:
                    sn = StaticParam.socketDic["扫码枪"].returnStr;
                    //将SN显示到界面
                    DelSn(sn);
                    LogClass.AddMsg(0, $"接收到SN为：{sn}");
                    StaticParam.socketDic["扫码枪"].SendMSG("R");
                    m_nStep = (int)WorkStep.ReturnScanOK;
                    break;

                //扫码NG
                case WorkStep.ScanNG:
                    StaticParam.socketDic["扫码枪"].SendMSG("R");
                    Thread.Sleep(1000);
                    LogClass.AddMsg(1, "扫码枪扫码NG，重新触发！");
                    ngTime++;
                    if (ngTime > 2)
                    {
                        //3次失败后暂停流程，检查硬件后手动点击主界面按钮继续
                        LogClass.AddMsg(2, "扫码失败，请人工检查硬件和条码！");
                        StaticParam.frmError.ShowErr(ref Address, "0003", (int)WorkStep.TriggerScan, (int)WorkStep.ReturnScanNG);
                        m_nStep = (int)WorkStep.ReturnScanNG;
                    }
                    else
                    {
                        m_nStep = (int)WorkStep.TriggerScan;
                    }
                    break;

                //扫码OK
                case WorkStep.ReturnScanOK:
                    ngTime = 0;
                    PLCQueueClass.AddCMD(StaticParam.ScanOKAddr, (short)1);
                    StaticParam.socketDic["扫码枪"].returnStr = "";
                    //Thread.Sleep(200);
                    LogClass.AddMsg(0, "扫码完成，并等待气缸到位信号!");
                    //PLCQueueClass.AddCMD(StaticParam.ScanOKAddr, (short)0);
                    m_nStep = (int)WorkStep.WaitReachSignal;
                    break;

                //写入PLC扫码NG
                case WorkStep.ReturnScanNG:
                    ngTime = 0;
                    PLCQueueClass.AddCMD(StaticParam.ScanOKAddr, (short)2);
                    m_nStep = (int)WorkStep.Completed;
                    break;

                //等待气缸到位信号
                case WorkStep.WaitReachSignal:
                    var result1 = plc.ReadInt16(StaticParam.ReachAddr);
                    Thread.Sleep(100);
                    if (result1 == "1")
                    {
                        LogClass.AddMsg(0, "气缸到位，开始收集点位数据！");
                        Thread.Sleep(millisecondsTimeout: 1000);
                        m_nStep = (int)WorkStep.SendCmd;
                    }
                    else
                    {
                        m_nStep = (int)WorkStep.WaitReachSignal;
                    }
                    break;

                //获取感应器数据
                case WorkStep.SendCmd:
                    //for (int i = 0; i < StaticParam.clientSensor.Length; i++)
                    //{
                    //    StaticParam.clientSensor[i].SendAsciiMsg("M0\r\n");
                    //    Thread.Sleep(100);
                    //}
                    StaticParam.socketDic["Dlen1"].SendMSG("M0\r\n");
                    StaticParam.socketDic["Dlen2"].SendMSG("M0\r\n");
                    StaticParam.socketDic["Dlen3"].SendMSG("M0\r\n");
                    StaticParam.socketDic["Dlen4"].SendMSG("M0\r\n");
                    Thread.Sleep(100);
                    AllPointList.Clear();
                    m_nStep = (int)WorkStep.GetPointData;
                    break;

                //获取点位信息
                case WorkStep.GetPointData:
                    if (pointList[0].Count != 0 && pointList[1].Count != 0 && pointList[2].Count != 0 && pointList[3].Count != 0)
                    {
                        for (int i = 0; i < pointList.Length; i++)
                        {
                            AllPointList.AddRange(pointList[i]);
                        }
                        m_nStep = (int)WorkStep.StartCorrect;
                    }
                    else
                    {
                        m_nStep = (int)WorkStep.GetPointData;
                    }
                    break;

                //开始矫正
                case WorkStep.StartCorrect:
                    for (int i = 0; i < pointList.Length; i++)
                    {
                        pointList[i].Clear();
                    }
                    //获取点位及结果
                    hasCorrectedDictionary = myGT_Helper.JudgeResult(AllPointList);
                    DelLabel(hasCorrectedDictionary);
                    //映射在表格里
                    DelPoint(AllPointList, hasCorrectedDictionary);
                    hasCorrectedDictionary.Clear();
                    //ng点位结果判断
                    if (myGT_Helper.NGCount > 0)
                    {
                        DelResult("NG");
                        AllPointList.Clear();
                        m_nStep = (int)WorkStep.SendCmd;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        LogClass.AddMsg(0, "点位矫正OK！");
                        m_nStep = (int)WorkStep.CorrectOK;
                    }
                    break;

                //矫正OK
                case WorkStep.CorrectOK:
                    DelResult("OK");
                    data = myGT_Helper.SetData(sn, AllPointList);
                    StaticParam.SaveData(data, mySaveData);
                    LogClass.AddMsg(0, "本地数据保存完成！");
                    m_nStep = (int)WorkStep.ReturnCorrectOKSignal;
                    break;

                //给PLC矫正OK信号
                case WorkStep.ReturnCorrectOKSignal:
                    PLCQueueClass.AddCMD(StaticParam.WorkDoneAddr, (short)1);
                    Thread.Sleep(200);
                    LogClass.AddMsg(0, "发送PLC矫正OK信号!");
                    m_nStep = (int)WorkStep.WriteToMysql;
                    //PLCQueueClass.AddCMD(StaticParam.WorkDoneAddr, (short)0);
                    break;

                //写入数据库
                case WorkStep.WriteToMysql:
                    if (StaticParam.b_UseMES)
                    {
                        LogClass.AddMsg(0, "开始写入数据库！");
                        int k = new OP170DataService().InsertData(data);
                        Thread.Sleep(500);
                        if (k > 0)
                        {
                            LogClass.AddMsg(0, "数据库写入成功！");
                        }
                        else
                        {
                            LogClass.AddMsg(1, "数据库写入失败！");
                            StaticParam.SaveConfig(data, data.SN);
                        }
                        m_nStep = (int)WorkStep.UpdatePassStation;
                    }
                    else
                    {
                        LogClass.AddMsg(0, "不上传，则不写入数据库！");
                        Thread.Sleep(500);
                        m_nStep = (int)WorkStep.Completed;
                    }
                    break;

                case WorkStep.UpdatePassStation:
                    DelTextBox();
                    //给此SN更新此战过站信息
                    int l = new SNClassService().Update(sn, "Station3", true);
                    if (l > 0)
                    {
                        LogClass.AddMsg(0, "数据库更新过站成功!");
                        m_nStep = (int)WorkStep.Completed;
                    }
                    else
                    {
                        LogClass.AddMsg(2, "数据库更新过站失败!");
                        //StaticParam.frmError.ShowErr(ref Address, $"{sn} ：向数据库写入过站信息失败！", (int)WorkStep.UpdatePassStation, (int)WorkStep.Completed, "请检查数据库的连接或是数据信息：查看网线链接状态或是数据库是否打开；或看配置文件中的数据是否合法！检查结束后点击重试这部或执行下一步！");
                        StaticParam.frmError.ShowErr(ref Address, "0004", (int)WorkStep.UpdatePassStation, (int)WorkStep.Completed);
                    }
                    break;

                //流程结束
                case WorkStep.Completed:
                    //清空条码框并聚焦
                    sn = string.Empty;
                    data = null;
                    LogClass.AddMsg(0, "流程结束，开始下一流程！");
                    Thread.Sleep(1000);
                    m_nStep = (int)WorkStep.Start;
                    break;
            }
        }

        public void Action()
        {
            m_Status = Status.动作;
            m_Step = (int)WorkStep.GetStart;
        }

        public bool IsIdle()
        {
            bool result = false;
            if (m_Status == Status.待命)
            {
                result = true;
            }
            return result;
        }

        public void Stop()
        {
            pointList.ToList().Clear();
            AllPointList.Clear();
            sn = string.Empty;
            DelResult("");
            DelTextBox();
            m_Status = Status.待命;
        }

    }
}
