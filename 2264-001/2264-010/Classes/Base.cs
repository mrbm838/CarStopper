using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cowain
{
    public class Base
    {
        public int m_nStep = 0;
        public int m_nStep1 = 0;
        public System.Timers.Timer m_tmDelay;
        public System.Timers.Timer m_tmDelay1;
        public Status m_Status = Status.待命;
        private Thread thread;
        public  Base Address;
        public enum Status
        {
            待命,
            动作,
            错误,
        }
        public bool isIdle()
        {
            if (m_Status == Status.待命)
            {
                return true;
            }
            return false;
        }
        public Base()
        {
            m_tmDelay = new System.Timers.Timer(1000);
            m_tmDelay.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent_DelayTimeOut);
            m_tmDelay1 = new System.Timers.Timer(1000);
            m_tmDelay1.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent_DelayTimeOut1);
            thread = new Thread(work);
            thread.IsBackground = true;
            thread.Start();
            Address = this;//由于外部类都继承基类，将基类传出去，用作Status改变
        }
        private void OnTimedEvent_DelayTimeOut(object source, System.Timers.ElapsedEventArgs e) { m_tmDelay.Enabled = false; }
        private void OnTimedEvent_DelayTimeOut1(object source, System.Timers.ElapsedEventArgs e) { m_tmDelay1.Enabled = false; }
        private void work()
        {
            while(true)
            {
                Thread.Sleep(1);
                if (m_Status == Status.待命|| m_Status == Status.错误)
                {
                    continue;
                }
                StepCycle();
                //HomeCycle();
            }
        }
        public virtual void Stop()
        {

        }
        public virtual void StepCycle()
        {

        }
        public virtual void HomeCycle()
        {

        }
        public virtual void StepAction()
        {

        }
        public virtual void HomeAction()
        {

        }
    }
}
