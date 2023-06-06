namespace OP001
{
    partial class FrmSetCommunicate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UIBtn_Add = new Sunny.UI.UIButton();
            this.UIBtn_Del = new Sunny.UI.UIButton();
            this.UIBtn_Test = new Sunny.UI.UIButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "发送信息：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "接收信息：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(728, 497);
            this.splitContainer1.SplitterDistance = 415;
            this.splitContainer1.TabIndex = 5;
            // 
            // UIBtn_Add
            // 
            this.UIBtn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Add.Location = new System.Drawing.Point(44, 537);
            this.UIBtn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Add.Name = "UIBtn_Add";
            this.UIBtn_Add.Size = new System.Drawing.Size(129, 46);
            this.UIBtn_Add.TabIndex = 6;
            this.UIBtn_Add.Text = "添加";
            this.UIBtn_Add.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Add.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // UIBtn_Del
            // 
            this.UIBtn_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Del.Location = new System.Drawing.Point(303, 537);
            this.UIBtn_Del.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Del.Name = "UIBtn_Del";
            this.UIBtn_Del.Size = new System.Drawing.Size(129, 46);
            this.UIBtn_Del.TabIndex = 6;
            this.UIBtn_Del.Text = "删除";
            this.UIBtn_Del.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Del.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Del.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // UIBtn_Test
            // 
            this.UIBtn_Test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Test.Location = new System.Drawing.Point(562, 538);
            this.UIBtn_Test.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Test.Name = "UIBtn_Test";
            this.UIBtn_Test.Size = new System.Drawing.Size(129, 46);
            this.UIBtn_Test.TabIndex = 6;
            this.UIBtn_Test.Text = "测试";
            this.UIBtn_Test.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Test.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.FillColor = System.Drawing.Color.Black;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.Frame = null;
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(415, 497);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTabControl1.TabBackColor = System.Drawing.SystemColors.Control;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.uiTabControl1.TabUnSelectedForeColor = System.Drawing.Color.Black;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmSetCommunicate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(728, 586);
            this.Controls.Add(this.UIBtn_Del);
            this.Controls.Add(this.UIBtn_Test);
            this.Controls.Add(this.UIBtn_Add);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmSetCommunicate";
            this.Text = "FrmSetCommunicate";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 728, 586);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetCommunicate_FormClosing);
            this.Load += new System.EventHandler(this.FrmSetCommunicate_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sunny.UI.UIButton UIBtn_Add;
        private Sunny.UI.UIButton UIBtn_Del;
        private Sunny.UI.UIButton UIBtn_Test;
        private Sunny.UI.UITabControl uiTabControl1;
    }
}