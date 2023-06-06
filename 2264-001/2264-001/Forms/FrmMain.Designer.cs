namespace OP001
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel_Form = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tsBtHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Setting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Rewrite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Login = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_MachineName = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_MES = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Start = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Data = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.lst_Log = new ListViewBuff();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Form
            // 
            this.panel_Form.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Form.Location = new System.Drawing.Point(0, 96);
            this.panel_Form.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(913, 664);
            this.panel_Form.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.ico");
            this.imageList1.Images.SetKeyName(1, "warning.ico");
            this.imageList1.Images.SetKeyName(2, "error.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(1102, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "  当前用户：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_user.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_user.Location = new System.Drawing.Point(1266, 55);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(73, 21);
            this.lbl_user.TabIndex = 12;
            this.lbl_user.Text = "未登录";
            this.lbl_user.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(254, 96);
            this.toolStripButton6.Text = "首页";
            this.toolStripButton6.ToolTipText = "LOGO";
            // 
            // tsBtHome
            // 
            this.tsBtHome.AutoSize = false;
            this.tsBtHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtHome.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsBtHome.Image = ((System.Drawing.Image)(resources.GetObject("tsBtHome.Image")));
            this.tsBtHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtHome.Name = "tsBtHome";
            this.tsBtHome.Size = new System.Drawing.Size(50, 56);
            this.tsBtHome.Text = "首页";
            this.tsBtHome.Click += new System.EventHandler(this.tsBtHome_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 58);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator1.Visible = false;
            // 
            // tsb_Setting
            // 
            this.tsb_Setting.AutoSize = false;
            this.tsb_Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Setting.Enabled = false;
            this.tsb_Setting.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_Setting.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Setting.Image")));
            this.tsb_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Setting.Name = "tsb_Setting";
            this.tsb_Setting.Size = new System.Drawing.Size(50, 56);
            this.tsb_Setting.Text = "设置";
            this.tsb_Setting.Click += new System.EventHandler(this.tsb_Setting_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator3.Visible = false;
            // 
            // tsb_Rewrite
            // 
            this.tsb_Rewrite.AutoSize = false;
            this.tsb_Rewrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Rewrite.Enabled = false;
            this.tsb_Rewrite.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_Rewrite.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Rewrite.Image")));
            this.tsb_Rewrite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Rewrite.Name = "tsb_Rewrite";
            this.tsb_Rewrite.Size = new System.Drawing.Size(50, 56);
            this.tsb_Rewrite.Text = "设置";
            this.tsb_Rewrite.ToolTipText = "重新写入";
            this.tsb_Rewrite.Click += new System.EventHandler(this.tsb_Rewrite_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator2.Visible = false;
            // 
            // tsb_Login
            // 
            this.tsb_Login.AutoSize = false;
            this.tsb_Login.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Login.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_Login.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Login.Image")));
            this.tsb_Login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Login.Name = "tsb_Login";
            this.tsb_Login.Size = new System.Drawing.Size(50, 56);
            this.tsb_Login.Text = "登录";
            this.tsb_Login.Click += new System.EventHandler(this.tsb_Login_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(6, 61);
            this.toolStripLabel4.Visible = false;
            // 
            // tsl_MachineName
            // 
            this.tsl_MachineName.AutoSize = false;
            this.tsl_MachineName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsl_MachineName.Name = "tsl_MachineName";
            this.tsl_MachineName.Size = new System.Drawing.Size(150, 58);
            this.tsl_MachineName.Text = "曲率测试";
            this.tsl_MachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip.BackgroundImage")));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.tsBtHome,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsb_Setting,
            this.toolStripSeparator6,
            this.tsb_MES,
            this.toolStripSeparator3,
            this.tsb_Rewrite,
            this.toolStripSeparator4,
            this.tsb_Start,
            this.toolStripSeparator5,
            this.tsb_Data,
            this.toolStripSeparator2,
            this.tsb_Login,
            this.toolStripLabel4,
            this.toolStripLabel3,
            this.toolStripLabel2,
            this.tsl_MachineName});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 35);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(1366, 61);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator6.Visible = false;
            // 
            // tsb_MES
            // 
            this.tsb_MES.AutoSize = false;
            this.tsb_MES.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MES.Enabled = false;
            this.tsb_MES.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_MES.Image = ((System.Drawing.Image)(resources.GetObject("tsb_MES.Image")));
            this.tsb_MES.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MES.Name = "tsb_MES";
            this.tsb_MES.Size = new System.Drawing.Size(50, 56);
            this.tsb_MES.Text = "MES";
            this.tsb_MES.Click += new System.EventHandler(this.tsb_MES_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator4.Visible = false;
            // 
            // tsb_Start
            // 
            this.tsb_Start.AutoSize = false;
            this.tsb_Start.BackColor = System.Drawing.SystemColors.Control;
            this.tsb_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Start.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_Start.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Start.Image")));
            this.tsb_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Start.Name = "tsb_Start";
            this.tsb_Start.Size = new System.Drawing.Size(50, 56);
            this.tsb_Start.Text = "开始";
            this.tsb_Start.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 61);
            this.toolStripSeparator5.Visible = false;
            // 
            // tsb_Data
            // 
            this.tsb_Data.AutoSize = false;
            this.tsb_Data.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Data.Font = new System.Drawing.Font("Microsoft YaHei UI", 21F);
            this.tsb_Data.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Data.Image")));
            this.tsb_Data.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Data.Name = "tsb_Data";
            this.tsb_Data.Size = new System.Drawing.Size(50, 56);
            this.tsb_Data.Text = "数据文件";
            this.tsb_Data.Click += new System.EventHandler(this.tsb_Data_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(150, 58);
            this.toolStripLabel3.Text = "                       ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(150, 58);
            this.toolStripLabel2.Text = "                       ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.DPIScale = true;
            // 
            // lst_Log
            // 
            this.lst_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Content});
            this.lst_Log.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_Log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_Log.HideSelection = false;
            this.lst_Log.Location = new System.Drawing.Point(916, 96);
            this.lst_Log.Name = "lst_Log";
            this.lst_Log.Size = new System.Drawing.Size(450, 664);
            this.lst_Log.SmallImageList = this.imageList1;
            this.lst_Log.TabIndex = 10;
            this.lst_Log.UseCompatibleStateImageBehavior = false;
            this.lst_Log.View = System.Windows.Forms.View.Details;
            // 
            // Time
            // 
            this.Time.Text = "时间";
            this.Time.Width = 187;
            // 
            // Content
            // 
            this.Content.Text = "文本";
            this.Content.Width = 280;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 760);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_Log);
            this.Controls.Add(this.panel_Form);
            this.Controls.Add(this.toolStrip);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "主界面";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1192, 911);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton tsBtHome;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_Rewrite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_Login;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel tsl_MachineName;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_Start;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsb_Data;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsb_MES;
        private ListViewBuff lst_Log;
        private Sunny.UI.UIStyleManager uiStyleManager1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
    }
}

