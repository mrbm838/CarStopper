using ReadAndWriteConfigSystem;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP010
{
    public partial class FrmProcessBar : UIForm
    {
        //public static event Action<int> HandleBarValue;
        public static bool b_Result;

        public FrmProcessBar()
        {
            InitializeComponent();
            FrmMain.HandleBarValue += FrmMain_HandleBarValue;
        }

        private void FrmMain_HandleBarValue(int obj,string str)
        {
            SetPos(obj,str);
        }

        private void FrmProcessBar_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            uiProcessBar1.Maximum = 100;
        }

        public static void LoadAndRun(UIForm form)
        {
            // form.HandleCreated += delegate
            //  {
            new Thread(new ThreadStart(delegate
            {
                FrmProcessBar splash = new FrmProcessBar();
                form.Shown += delegate
                {
                    b_Result = true;
                    splash.Invoke(new EventHandler(splash.Kill));
                    splash.Dispose();
                };
                Application.Run(splash);
            })).Start();
            // };
            Application.Run(form);
        }

        private void Kill(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProcessBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


        public void SetPos(int value, string str)
        {
            if (value < uiProcessBar1.Maximum)
            {
                uiProcessBar1.Value = value;
                uiLabel1.Text = str;
            }
            Application.DoEvents();
        }

    }
}
