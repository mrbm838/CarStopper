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

namespace OP010.Forms
{
    public partial class FrmSelectCom : UIForm
    {
        /// <summary>
        /// 用于信息的返回
        /// </summary>
        private Action<string, string> returnResult;


        public FrmSelectCom(Action<string, string> returnResult)
        {
            InitializeComponent();
            this.returnResult = returnResult;
        }

        /// <summary>
        /// 确认选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (uicbx_Type.SelectedIndex==-1)
            {
                return;
            }
            if (StaticParam.listComObj.Exists(x => x.ControlName ==uitxt_Name.Text))
            {
                return;
            }
            returnResult(this.uicbx_Type.SelectedItem.ToString(), this.uitxt_Name.Text);
            this.Close();
        }
    }
}
