using cowain;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP001
{
    public partial class FrmError : UIForm
    {
        LocalBase baceClass1;
        int reTryStep1 = 999;
        int nextStep1 = 999;

        public FrmError()
        {
            InitializeComponent();
        }



        #region 窗体控件事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmError_Load(object sender, EventArgs e)
        {
            listView1.MultiSelect = false;
            Image img1 = Image.FromFile(Application.StartupPath + "\\SetOk.bmp");
            Image img2 = Image.FromFile(Application.StartupPath + "\\SetCanel_Disable.bmp");
            ImageList imgs = new ImageList();
            imgs.Images.Add(img1);
            imgs.Images.Add(img2);
            listView1.SmallImageList = imgs;
            listView1.LargeImageList = imgs;
        }

        /// <summary>
        /// 操作确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            this.Visible = false;
            if (listView1.SelectedItems[0].Index == 0)
            {
                baceClass1.m_nStep = reTryStep1;
                baceClass1.m_Status = LocalBase.Status.动作;
            }
            else if (listView1.SelectedItems[0].Index == 1)
            {
                baceClass1.m_nStep = nextStep1;
                baceClass1.m_Status = LocalBase.Status.动作;
            }
            else
            {
                baceClass1.Stop();
            }
            this.Visible = false;
        }


        /// <summary>
        /// 选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i == listView1.SelectedItems[0].Index)
                {
                    listView1.Items[i].ImageIndex = 0;
                }
                else
                {
                    listView1.Items[i].ImageIndex = 1;
                }
            }
        }


        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmError_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        #endregion


        #region 方法/函数
        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="baceClass">类</param>
        /// <param name="str">错误信息</param>
        /// <param name="reTrystep">重新执行哪步</param>
        /// <param name="nextStep">接下来执行哪步</param>
        public void ShowErr(ref LocalBase baceClass, string str, int reTrystep, int nextStep, string solution)
        {
            baceClass1 = baceClass;
            reTryStep1 = reTrystep;
            nextStep1 = nextStep;
            baceClass1.m_Status = LocalBase.Status.错误;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.Visible = true;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ImageIndex = 1;
                    }
                    listView1.Items[0].ImageIndex = 0;
                    if (textBox1.InvokeRequired)
                    {
                        textBox1.Invoke(new Action(() =>
                        {
                            textBox1.Text = str + "\r\n 解决方案为：" + solution;
                        }));
                    }
                    else
                    {
                        textBox1.Text = str + "\r\n 解决方案为：" + solution;
                    }
                    listView1.Items[0].Selected = true;
                }));
            }
            else
            {
                this.Visible = true;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].ImageIndex = 1;
                }
                listView1.Items[0].ImageIndex = 0;
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new Action(() =>
                    {
                        textBox1.Text = str + "\r\n 解决方案为：" + solution;
                    }));
                }
                else
                {
                    textBox1.Text = str + "\r\n 解决方案为：" + solution;
                }
                listView1.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="baceClass">类</param>
        /// <param name="errCode">错误代码</param>
        /// <param name="reTrystep">重新执行哪步</param>
        /// <param name="nextStep">执行下一步</param>
        public void ShowErr(ref LocalBase baceClass, string errCode, int reTrystep, int nextStep)
        {
            baceClass1 = baceClass;
            reTryStep1 = reTrystep;
            nextStep1 = nextStep;
            baceClass1.m_Status = LocalBase.Status.错误;
            ErrorInfo errorInfo = new HandErr().GetError(errCode);
            this.Invoke(new Action(() =>
            {
                this.Visible = true;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].ImageIndex = 1;
                }
                listView1.Items[0].ImageIndex = 0;
                textBox1.Invoke(new Action(() =>
                {
                    textBox1.Text = errorInfo.ErrMsg;
                }));
                txt_Solution.Invoke(new Action(() =>
                {
                    txt_Solution.Text = errorInfo.Solution;
                }));
                listView1.Items[0].Selected = true;
            }));

        }
        #endregion



        
    }
}

