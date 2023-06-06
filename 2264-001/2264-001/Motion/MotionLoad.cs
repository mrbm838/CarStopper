using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP001.Motion
{
    public class MotionLoad
    {
        private static MotionModule motion;
        private static MotionModule.enInitStep initStep;
        private static Action<int, string> handleBarValue;

        public static void MotionLoading(MotionModule motionTemp, Action<int, string> handleBarValueTemp)
        {
            motion = motionTemp;
            handleBarValue = handleBarValueTemp;
            initStep = MotionModule.enInitStep.StartLoading;
            var task = new Task(Init);
            task.Start();
            task.Wait();
        }

        private static void Init()
        {
            int process = 0;
            while (true)
            {
                Thread.Sleep(500);
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
