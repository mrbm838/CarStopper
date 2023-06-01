using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OP010.Classes.Motion;

namespace OP010.Classes
{
    internal class MotorInit
    {
        private Motion motion;
        private Motion.enInitStep initStep;
        private Action<int, string> handleBarValue;

        public MotorInit(ref Motion motion, Action<int, string> handleBarValue)
        {
            this.motion = motion;
            this.handleBarValue = handleBarValue;
            initStep = Motion.enInitStep.StartLoading;
            var task = new Task(Init);
            task.Start();
            task.Wait();
        }

        private void Init()
        {
            int process = 0;
            while (true)
            {
                Thread.Sleep(5000);
                if (process >= 100)
                {
                    Thread.Sleep(500);
                    break;
                }
                //--------------------------
                string[] strStep = { "Start Initial", "Start Loading", "Loading Data", "Checking System", "Checking Data" };
                int iRetCode = 0;
                motion.GetInitialStatus(ref iRetCode);
                //--------------------------
                int iInitialStep = 0;
                if (iRetCode < 200)
                    iInitialStep = iRetCode - 100;
                //--------------------------
                if (process < 100 && iInitialStep >= 0)
                {
                    int iMax = iInitialStep * 20;
                    if (process < iMax)
                        process = process + 1;
                    else
                        process = iMax;
                    handleBarValue(process / 5, strStep[iInitialStep]);
                }

                if (iRetCode == 1001 || iRetCode == 1002)
                {
                    process = 100;
                    string strShow = (iRetCode == 1001) ? "Initialization Successful" : "Initialization Failed";
                    handleBarValue(process / 5, strStep[iInitialStep]);
                }
            }
        }
    }
}
