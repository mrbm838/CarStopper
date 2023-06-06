namespace OP001
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uibtn_Exit = new Sunny.UI.UIButton();
            this.uibtn_Login = new Sunny.UI.UIButton();
            this.uitxt_Pwd = new Sunny.UI.UITextBox();
            this.uicbx_User = new Sunny.UI.UIComboBox();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.lbl_User = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiBtn_Modify = new Sunny.UI.UIButton();
            this.uiBtn_Check = new Sunny.UI.UIButton();
            this.uiTxt_NewPwd = new Sunny.UI.UITextBox();
            this.uiTxt_OldPwd = new Sunny.UI.UITextBox();
            this.uiTxt_User = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.Frame = null;
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(909, 664);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uibtn_Exit);
            this.tabPage1.Controls.Add(this.uibtn_Login);
            this.tabPage1.Controls.Add(this.uitxt_Pwd);
            this.tabPage1.Controls.Add(this.uicbx_User);
            this.tabPage1.Controls.Add(this.lbl_Pwd);
            this.tabPage1.Controls.Add(this.lbl_User);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(909, 624);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uibtn_Exit
            // 
            this.uibtn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibtn_Exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uibtn_Exit.Location = new System.Drawing.Point(476, 475);
            this.uibtn_Exit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibtn_Exit.Name = "uibtn_Exit";
            this.uibtn_Exit.Size = new System.Drawing.Size(145, 35);
            this.uibtn_Exit.TabIndex = 33;
            this.uibtn_Exit.Text = "退出";
            this.uibtn_Exit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uibtn_Exit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uibtn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // uibtn_Login
            // 
            this.uibtn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibtn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uibtn_Login.Location = new System.Drawing.Point(236, 475);
            this.uibtn_Login.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibtn_Login.Name = "uibtn_Login";
            this.uibtn_Login.Size = new System.Drawing.Size(145, 35);
            this.uibtn_Login.TabIndex = 33;
            this.uibtn_Login.Text = "登录";
            this.uibtn_Login.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uibtn_Login.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uibtn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // uitxt_Pwd
            // 
            this.uitxt_Pwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitxt_Pwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uitxt_Pwd.Location = new System.Drawing.Point(385, 340);
            this.uitxt_Pwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitxt_Pwd.MinimumSize = new System.Drawing.Size(1, 16);
            this.uitxt_Pwd.Name = "uitxt_Pwd";
            this.uitxt_Pwd.PasswordChar = '*';
            this.uitxt_Pwd.ShowText = false;
            this.uitxt_Pwd.Size = new System.Drawing.Size(236, 29);
            this.uitxt_Pwd.TabIndex = 32;
            this.uitxt_Pwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitxt_Pwd.Watermark = "";
            this.uitxt_Pwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uicbx_User
            // 
            this.uicbx_User.DataSource = null;
            this.uicbx_User.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uicbx_User.FillColor = System.Drawing.Color.White;
            this.uicbx_User.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uicbx_User.Items.AddRange(new object[] {
            "操作员",
            "维护工程师",
            "工程师"});
            this.uicbx_User.Location = new System.Drawing.Point(385, 199);
            this.uicbx_User.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicbx_User.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicbx_User.Name = "uicbx_User";
            this.uicbx_User.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicbx_User.Size = new System.Drawing.Size(236, 29);
            this.uicbx_User.TabIndex = 31;
            this.uicbx_User.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicbx_User.Watermark = "";
            this.uicbx_User.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.AutoSize = true;
            this.lbl_Pwd.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Pwd.Location = new System.Drawing.Point(231, 340);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(103, 29);
            this.lbl_Pwd.TabIndex = 23;
            this.lbl_Pwd.Text = "密码：";
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_User.Location = new System.Drawing.Point(231, 196);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(133, 29);
            this.lbl_User.TabIndex = 24;
            this.lbl_User.Text = "用户名：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiBtn_Modify);
            this.tabPage2.Controls.Add(this.uiBtn_Check);
            this.tabPage2.Controls.Add(this.uiTxt_NewPwd);
            this.tabPage2.Controls.Add(this.uiTxt_OldPwd);
            this.tabPage2.Controls.Add(this.uiTxt_User);
            this.tabPage2.Controls.Add(this.uiLabel3);
            this.tabPage2.Controls.Add(this.uiLabel2);
            this.tabPage2.Controls.Add(this.uiLabel1);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 60);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "权限设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiBtn_Modify
            // 
            this.uiBtn_Modify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Modify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Modify.Location = new System.Drawing.Point(297, 472);
            this.uiBtn_Modify.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Modify.Name = "uiBtn_Modify";
            this.uiBtn_Modify.Size = new System.Drawing.Size(265, 49);
            this.uiBtn_Modify.TabIndex = 3;
            this.uiBtn_Modify.Text = "修改";
            this.uiBtn_Modify.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Modify.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // uiBtn_Check
            // 
            this.uiBtn_Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Check.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Check.Location = new System.Drawing.Point(630, 169);
            this.uiBtn_Check.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Check.Name = "uiBtn_Check";
            this.uiBtn_Check.Size = new System.Drawing.Size(100, 35);
            this.uiBtn_Check.TabIndex = 2;
            this.uiBtn_Check.Text = "Check";
            this.uiBtn_Check.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Check.TipsText = "检测用户是否存在";
            this.uiBtn_Check.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Check.Click += new System.EventHandler(this.uiBtn_Check_Click);
            // 
            // uiTxt_NewPwd
            // 
            this.uiTxt_NewPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_NewPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_NewPwd.Location = new System.Drawing.Point(297, 344);
            this.uiTxt_NewPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_NewPwd.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_NewPwd.Name = "uiTxt_NewPwd";
            this.uiTxt_NewPwd.PasswordChar = '*';
            this.uiTxt_NewPwd.ShowText = false;
            this.uiTxt_NewPwd.Size = new System.Drawing.Size(265, 40);
            this.uiTxt_NewPwd.TabIndex = 1;
            this.uiTxt_NewPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_NewPwd.Watermark = "";
            this.uiTxt_NewPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_OldPwd
            // 
            this.uiTxt_OldPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_OldPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_OldPwd.Location = new System.Drawing.Point(297, 258);
            this.uiTxt_OldPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_OldPwd.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_OldPwd.Name = "uiTxt_OldPwd";
            this.uiTxt_OldPwd.PasswordChar = '*';
            this.uiTxt_OldPwd.ShowText = false;
            this.uiTxt_OldPwd.Size = new System.Drawing.Size(265, 40);
            this.uiTxt_OldPwd.TabIndex = 1;
            this.uiTxt_OldPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_OldPwd.Watermark = "";
            this.uiTxt_OldPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_User
            // 
            this.uiTxt_User.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_User.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_User.Location = new System.Drawing.Point(297, 170);
            this.uiTxt_User.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_User.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_User.Name = "uiTxt_User";
            this.uiTxt_User.ShowText = false;
            this.uiTxt_User.Size = new System.Drawing.Size(265, 40);
            this.uiTxt_User.TabIndex = 1;
            this.uiTxt_User.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_User.Watermark = "";
            this.uiTxt_User.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(190, 355);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "新密码";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(190, 269);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "旧密码：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(190, 181);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "用户名：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(909, 664);
            this.Controls.Add(this.uiTabControl1);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UIComboBox uicbx_User;
        private Sunny.UI.UITextBox uitxt_Pwd;
        private Sunny.UI.UIButton uibtn_Exit;
        private Sunny.UI.UIButton uibtn_Login;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton uiBtn_Modify;
        private Sunny.UI.UIButton uiBtn_Check;
        private Sunny.UI.UITextBox uiTxt_NewPwd;
        private Sunny.UI.UITextBox uiTxt_OldPwd;
        private Sunny.UI.UITextBox uiTxt_User;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
    }
}