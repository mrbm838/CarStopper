using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Sunny.UI;
using Org.BouncyCastle.Tls.Crypto;
using System.Globalization;
using OP001.Motion;

namespace OP001
{
    public partial class FrmLogin : UIPage
    {
        LogClass myLog;
        public event DelShow Show;
        public event Action ShutDown;

        private MotionModule motion;

        public FrmLogin(MotionModule motion, LogClass log)
        {
            InitializeComponent();
            this.motion = motion;
            this.myLog = log;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //Account objAccount = new Account()
            //{
            //    User = this.uicbx_User.SelectedItem.ToString(),
            //    Pwd = this.uitxt_Pwd.Text.Trim()
            //};
            //try
            //{
            //    Program.currentAccount = new AdminService().AdminLogin(objAccount);
            //    if (Program.currentAccount == null)
            //    {
            //        LogClass.AddMsg(2, "用户名或密码错误！请重新输入！");
            //        this.uicbx_User.SelectedIndex = -1;
            //        this.uitxt_Pwd.Clear();
            //    }
            //    else
            //    {
            //        LogClass.AddMsg(0, $"{objAccount.User}登录成功！");
            //        this.DialogResult = DialogResult.OK;
            //        if (Program.currentAccount.User=="Admin")
            //        {
            //            if (uiTabControl1.TabPages.Count==1)
            //            {
            //                uiTabControl1.TabPages.Add(tabPage2);
            //            }
            //        }
            //        this.uitxt_Pwd.Clear();
            //        //this.Close();
            //        Show(null, null);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.ToString());
            //}


            string strLoginUserName = uicbx_User.SelectedItem.ToString();
            string strLoginPassWord = uitxt_Pwd.Text.Trim();
            if (strLoginUserName == string.Empty || strLoginPassWord == string.Empty)
            {
                LogClass.AddMsg(2, "用户名或密码为空！请重新输入！");
                this.uicbx_User.SelectedIndex = -1;
                this.uitxt_Pwd.Clear();
                return;
            }

            string strPassword = "", strUserEName = "";
            string strMachinePath = motion.GetDataBasePath();
            //-------------------------------------
            bool bGetPassword = motion.GetDataBaseData(strMachinePath, "PWD", "UserName", strLoginUserName, "thePassword", ref strPassword);
            bool bGetName = motion.GetDataBaseData(strMachinePath, "PWD", "UserName", strLoginUserName, "CName", ref strUserEName);
            //-------------------------------------
            strPassword = strPassword.Trim();
            strUserEName = strUserEName.Trim();

            if (bGetPassword && bGetName && strPassword == strLoginPassWord)
            {
                if (strUserEName == "厂商")
                    motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.Maker;
                else if (strUserEName == "MacEng")
                    motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.MacEng;
                else if (strUserEName == "工程师")
                    motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.ItEng;
                else if (strUserEName == "维护工程师")
                    motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.Eng;
                else if (strUserEName == "操作员")
                    motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.Operator;
            }
            else
            {
                motion.m_LoginUser = MotionBase.Sys_Define.enPasswordType.UnLogin;
            }

            try
            {
                Program.currentAccount = (Permission)Enum.Parse(typeof(Permission), motion.m_LoginUser.ToString());
                if (Program.currentAccount == Permission.UnLogin)
                {
                    LogClass.AddMsg(2, "用户名或密码错误！请重新输入！");
                    this.uicbx_User.SelectedIndex = -1;
                    this.uitxt_Pwd.Clear();
                }
                else
                {
                    LogClass.AddMsg(0, $"{Program.currentAccount}登录成功！");
                    this.DialogResult = DialogResult.OK;
                    if (Program.currentAccount == Permission.ItEng)
                    {
                        if (uiTabControl1.TabPages.Count == 1)
                        {
                            uiTabControl1.TabPages.Add(tabPage2);
                        }
                    }
                    this.uitxt_Pwd.Clear();
                    Show(null, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Program.currentAccount = Permission.UnLogin;
            this.Close();
            this.Dispose();
            ShutDown();
            Show(null, null);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            Account objAccount = new Account()
            {
                User = this.uiTxt_User.Text,
                Pwd = this.uiTxt_NewPwd.Text.Trim()
            };
            int i = new AdminService().ModifyPwd(objAccount, this.uiTxt_NewPwd.Text.Trim());
            if (i > 0)
            {
                LogClass.AddMsg(1, $"请注意，{objAccount.User}修改密码成功！请重新登录！");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Remove(tabPage2);
        }

        private void uiBtn_Check_Click(object sender, EventArgs e)
        {
            if (uiTxt_User.Text=="")
            {
                return;
            }
            bool b_result = new AdminService().QueryUser(uiTxt_User.Text.Trim());
            if (b_result) 
            {
                MessageBox.Show("该用户存在，可以改密码！");
            }
            else
            {
                MessageBox.Show("该用户不存在，请重新输入！");
            }
        }
    }
}
