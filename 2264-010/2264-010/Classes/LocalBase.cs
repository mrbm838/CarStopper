using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cowain
{
    public class LocalBase
    {
        public int m_nStep = 0;
        public Status m_Status = Status.待命;
        private Thread thread;
        public LocalBase Address;
        private static List<LocalBase> listBase = new List<LocalBase>();

        public enum Status
        {
            待命,
            动作,
            错误,
        }

        public void AddBase(LocalBase address)
        {
            listBase.Add(address);
        }

        public bool IsIDLE => m_Status == Status.待命;

        public LocalBase()
        {
            thread = new Thread(Work);
            thread.IsBackground = true;
            thread.Start();
            Address = this;//由于外部类都继承基类，将基类传出去，用作Status改变
        }

        private void Work()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (m_Status == Status.待命 || m_Status == Status.错误)
                {
                    continue;
                }
                StepCycle();
                //HomeCycle();
            }
        }

        public virtual void Stop()
        {
            listBase.ForEach(t => t.Stop());
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
