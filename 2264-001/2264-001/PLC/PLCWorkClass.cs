using Cowain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP001.PLC
{
    public  class PLCWorkClass
    {
        IPLC pLC;
        Thread threadWrite;

        public PLCWorkClass(IPLC plc)
        {
            pLC = plc;
            threadWrite = new Thread(DoWrite)
            {
                IsBackground = true
            };
            threadWrite.Start();
        }



        private void DoWrite()
        {
            while (true)
            {
                PLCResult pLCResult = PLCQueueClass.GetCMD();
                if (pLCResult != null)
                {
                    bool result = false;
                    result = pLC.Write(pLCResult.address, pLCResult.value);
                    if (result)
                    {
                        PLCQueueClass.AddResult(pLCResult, true);
                    }
                }
                else
                {
                    continue;
                }
            }
            
        }
    }
}
