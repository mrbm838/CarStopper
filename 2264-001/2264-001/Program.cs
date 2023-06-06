using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP001
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mutex mutex = null;
            bool mutexCreated;
            bool b_result = Mutex.TryOpenExisting("IPC_Frame(32位)", out mutex);
            if (!b_result)
            {
                mutex = new Mutex(true, "IPC_Frame(32位)", out mutexCreated);
            }
            else
            {
                MessageBox.Show("程序已打开！");
                return;
            }
            Application.Run(new FrmMain());
        }

        public static Permission currentAccount = Permission.UnLogin;
    }
}
