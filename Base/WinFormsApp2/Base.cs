using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Base
    {
        public bool b = true;
        public Action actionBase;
        public Base address;
        private static List<Base> list = new();

        public Base()
        {
            new Thread(Cycle) { IsBackground = true }.Start();
            address = this;
        }

        public Base(Action ab) : this()
        {
            actionBase = ab;
        }

        void Cycle()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (!b)
                {
                    continue;
                }
                CycleStep();
            }
        }

        public virtual void Stop()
        {
            //b = !b;
            list.ForEach(a => a.b = !a.b);
        }

        public virtual void CycleStep()
        {
            actionBase?.Invoke();

        }

        public void Add(ref Base a)
        {
            list.Add(a);
        }
    }

    class AA : Base
    {
        public Action actionAA;

        public AA(Action actionAA) : base()
        {
            this.actionAA = actionAA;
        }

        public override void CycleStep()
        {
            //base.CycleStep();

            actionAA?.Invoke();

        }

        public override void Stop()
        {
            //base.Stop();
            base.b = !b;
        }
    }

    class BB : Base
    {
        public Action actionBB;
        public BB(Action actionBB) : base()
        {
            this.actionBB = actionBB;
        }

        public override void CycleStep()
        {
            //base.CycleStep();
            actionBB?.Invoke();


        }

        public override void Stop()
        {
            base.b = !b;
        }
    }
}
