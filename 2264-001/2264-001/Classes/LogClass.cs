using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP001
{
    public class Msg
    {
        public int index;
        public string str = string.Empty;

        public Msg(int i, string msg)
        {
            index = i;
            str = msg;
        }
    }
    public class LogClass
    {

        private static ConcurrentQueue<Msg> msgQueue = new ConcurrentQueue<Msg>();
        Thread thread;

        #region 
        private ListView _lvLog;
        private ListBox _lvOnline;

        public ListView lst
        {
            get
            {
                return _lvLog;
            }
            set
            {
                _lvLog = value;
            }
        }

        public ListBox lvOnline
        {
            get
            {
                return _lvOnline;
            }
            set
            {
                _lvOnline = value;
            }
        }

        #endregion


        public LogClass(ListView listView, ListBox list)
        {
            lst = listView;
            lvOnline = list;
        }
        public LogClass(ListView listView)
        {
            lst = listView;
            thread = new Thread(WriteLog)
            {
                IsBackground = true
            };
            thread.Start();
        }


        public void WriteLog()
        {
            while (true)
            {
                if (!msgQueue.IsEmpty)
                {
                    Msg msg = null;
                    msgQueue.TryDequeue(out msg);
                    AddLog(msg.index, msg.str);
                    SaveLog(msg.str);
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }


        public static void AddMsg(int index, string str)
        {
            Msg msg = new Msg(index, str);
            msgQueue.Enqueue(msg);
        }


        /// <summary>
        /// 添加log
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        private void AddLog(int index, string info)
        {
            if (!lst.InvokeRequired)
            {
                if (lst.Items.Count > 500)
                {
                    lst.Items.Clear();
                }
                ListViewItem Lvi = new ListViewItem("  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), index);
                switch (index)
                {
                    case 0:
                        break;
                    case 1:
                        Lvi.BackColor = Color.Yellow;
                        break;
                    case 2:
                        Lvi.BackColor = Color.Red;
                        break;
                }
                Lvi.SubItems.Add(info);
                lst.Items.Insert(0, Lvi);
            }
            else
            {
                lst.Invoke(new Action(() =>
                {
                    if (lst.Items.Count > 500)
                    {
                        lst.Items.Clear();
                    }
                    ListViewItem Lvi = new ListViewItem("  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), index);
                    switch (index)
                    {
                        case 0:
                            break;
                        case 1:
                            Lvi.BackColor = Color.Yellow;
                            break;
                        case 2:
                            Lvi.BackColor = Color.Red;
                            break;
                    }
                    Lvi.SubItems.Add(info);
                    lst.Items.Insert(0, Lvi);
                }));

                #region 只支持第一次跨线程调用，再多就不适用
                //Task task = Task.Factory.StartNew(new Action(() =>
                //{
                //    ListViewItem Lvi = new ListViewItem("  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + info, index);
                //    Lvi.SubItems.Add(info);
                //    lst.Items.Insert(0, Lvi);
                //}));
                //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
                #endregion
            }
        }

        /// <summary>
        /// 保存软件运行LOG
        /// </summary>
        /// <param name="str"></param>
        public void SaveLog(string str)
        {
            try
            {
                string logPath = @"D:\DATA\Log\";
                string stringText = DateTime.Now.ToString("HH:mm:ss:fff") + ":" + str;
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                using (StreamWriter sw = File.AppendText(logPath + DateTime.Now.ToShortDateString().Replace('/', '-') + ".txt"))
                {
                    sw.WriteLine(stringText);
                }
            }
            catch (Exception ex)
            {
                AddLog(1, "保存到log文件失败，原因：" + ex.ToString());
            }
        }

        /// <summary>
        /// 保存软件异常关闭LOG
        /// </summary>
        /// <param name="message"></param>
        public void DispenserClosedSaveAuto(string message)
        {
            try
            {
                string fileName;
                fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy_MM_dd"));
                string outputPath = @"D:\DATA\Log\软件异常关闭记录";
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }
                string fullFileName = Path.Combine(outputPath, fileName);
                System.IO.FileStream fs;
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                StreamWriter sw;
                fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Append, System.IO.FileAccess.Write, FileShare.Read);
                //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "    " + message);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }


        /// <summary>
        /// 更新listbox中在线的客户端
        /// </summary>
        /// <param name="client"></param>
        /// <param name="IsAdd"></param>
        public void UpdateOnline(string client, bool IsAdd)
        {
            if (!lvOnline.InvokeRequired)
            {
                if (IsAdd)
                {
                    lvOnline.Items.Add(client);
                }
                else
                {
                    foreach (string item in lvOnline.Items)
                    {
                        if (item == client)
                        {
                            lvOnline.Items.Remove(item);
                            break;
                        }
                    }
                }
            }
            else
            {
                lvOnline.Invoke(new Action(() =>
                {
                    if (IsAdd)
                    {
                        lvOnline.Items.Add(client);
                    }
                    else
                    {
                        foreach (string item in lvOnline.Items)
                        {
                            if (item == client)
                            {
                                lvOnline.Items.Remove(item);
                                break;
                            }
                        }
                    }
                }));
                #region 这种方法不适用于中间类的调用
                //Task task = Task.Factory.StartNew(new Action(() =>
                //{
                //    if (IsAdd)
                //    {
                //        lvOnline.Items.Add(client);
                //    }
                //    else
                //    {
                //        foreach (string item in lvOnline.Items)
                //        {
                //            if (item == client)
                //            {
                //                lvOnline.Items.RemoveByKey(item);
                //                break;
                //            }
                //        }
                //    }
                //}));
                //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
                #endregion
            }
        }
    }
}



