using OP010;
using cowain;
using Cowain;
using HslCommunication.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP010
{
    public class MachineState : Base
    {

        IPLC plc;
        LogClass myLog;

        public WorkProcess myWorkProcess;

        public enum Step
        {
            Start,
            GetStart,
            Action,
            GetStop,
            Restart,
            GetEMG,
            Completed
        }
        Step m_Step;

        public MachineState(LogClass log, IPLC pLC, WorkProcess work1) : base()
        {
            myLog = log;
            plc = pLC;
            myWorkProcess = work1;
        }


        public override void StepCycle()
        {
            m_Step = (Step)m_nStep;
            switch (m_Step)
            {
                case Step.Start:
                    m_nStep = (int)Step.GetStart;
                    LogClass.AddMsg(0, "程序启动！");
                    break;

                case Step.GetStart:
                    if (Convert.ToInt32(plc.ReadInt16(StaticParam.PLCStart)) == 1)
                    {
                        LogClass.AddMsg(0, "收到PLC启动信号！");
                        StaticParam.b_Start = true;
                        m_nStep = (int)Step.Action;
                    }
                    else
                    {
                        m_nStep = (int)Step.GetStart;
                    }
                    break;

                case Step.Action:
                    if (StaticParam.b_Start && myWorkProcess.IsIDLE)
                    {
                        myWorkProcess.Action();
                        m_nStep = (int)Step.GetStop;
                    }
                    else
                    {
                        m_nStep = (int)Step.Action;
                    }
                    break;

                case Step.GetStop:
                    Thread.Sleep(1000);
                    if (Convert.ToInt32(plc.ReadInt16(StaticParam.PLCEMG)) == 1)
                    {
                        LogClass.AddMsg(2, "收到PLC急停信号，程序停止运行！");
                        StaticParam.b_EMG = true;
                        StaticParam.b_Start = false;
                        m_nStep = (int)Step.GetEMG;
                    }
                    if (Convert.ToInt32(plc.ReadInt16(StaticParam.PLCReset)) == 1)
                    {
                        LogClass.AddMsg(1, "收到PLC复位信号，程序停止运行，并进行复位！");
                        StaticParam.b_Reset = true;
                        StaticParam.b_Start = false;
                        m_nStep = (int)Step.Restart;
                    }
                    break;

                case Step.Restart:
                    if (StaticParam.b_Reset)
                    {
                        myWorkProcess.Stop();
                    }
                    m_nStep = (int)Step.Start;
                    break;

                case Step.GetEMG:
                    if (StaticParam.b_EMG)
                    {
                        myWorkProcess.Stop();
                        StaticParam.b_EMG = false;
                    }
                    m_nStep = (int)Step.GetStart;
                    break;

                case Step.Completed:
                    m_Status = Status.待命;
                    break;
            }
        }


        public void Action()
        {
            m_Status = Status.动作;
            m_nStep = (int)Step.Start;
        }
    }
}
