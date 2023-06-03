using DataModel;
using Cowain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP010
{
    public class PLCResult
    {
        public string address = string.Empty;
        public object value = string.Empty;
        public string result = string.Empty;
        public PLCResult(string address, object value)
        {
            this.address = address;
            this.value = value;
            result = string.Empty;
        }
    }

    public class PLCAddress
    {
        public string address;


        public PLCAddress(string address)
        {
            this.address = address;
        }
    }

    public class PLCQueueClass
    {
        /// <summary>
        /// 存储命令的队列
        /// </summary>
        public static ConcurrentQueue<PLCResult> myQueue = new ConcurrentQueue<PLCResult>();
        /// <summary>
        /// 地址结果集合
        /// </summary>
        public static List<PLCResult> listResult = new List<PLCResult>();
        /// <summary>
        /// 写的地址集合
        /// </summary>
        public static List<PLCResult> listWriteResult = new List<PLCResult>();
        public static object locker = new object();


        /// <summary>
        /// 将要写的命令压入队列
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        public static void AddCMD(string address, object value)
        {
            PLCResult pLCResult = new PLCResult(address, value);
            myQueue.Enqueue(pLCResult);
            bool b_Exist = false;
            for (int i = 0; i < listResult.Count; i++)
            {
                if (listResult[i].address == address)
                {
                    listResult[i].value = "";
                    b_Exist = true;
                    break;
                }
            }
            if (!b_Exist)
            {
                listResult.Add(pLCResult);
            }
        }

        /// <summary>
        /// 从队列中获取要写的命令执行
        /// </summary>
        /// <returns></returns>
        public static PLCResult GetCMD()
        {
            PLCResult pLCResult = null;
            if (!myQueue.IsEmpty)
            {
                myQueue.TryDequeue(out pLCResult);
            }
            return pLCResult;
        }

        ///// <summary>
        ///// 将要写的PLC地址值写入队列
        ///// </summary>
        ///// <param name="address"></param>
        ///// <param name="value"></param>
        //public void AddValue(string address,object value)
        //{
        //    AddCMD(address,value);
        //}


        public static void AddResult(PLCResult pLCResult,bool result)
        {
            for (int i = 0; i < listResult.Count; i++)
            {
                if (listResult[i].address==pLCResult.address)
                {
                    if (result)
                    {
                        listResult[i].result = "OK";
                    }
                    else
                    {
                        listResult[i].result = "NG";
                    }
                }
            }
        }
    }
}
