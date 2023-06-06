namespace OP001
{
    partial class FrmParam
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
            this.components = new System.ComponentModel.Container();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.UIBtn_SetCom = new Sunny.UI.UIButton();
            this.UIBtn_Save = new Sunny.UI.UIButton();
            this.uiBtn_SetZero = new Sunny.UI.UIButton();
            this.ButtonAxes = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.propertyGrid1.CategorySplitterColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.propertyGrid1.CommandsBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.propertyGrid1.CommandsDisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyGrid1.HelpBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(711, 664);
            this.propertyGrid1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UIBtn_SetCom
            // 
            this.UIBtn_SetCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_SetCom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_SetCom.Location = new System.Drawing.Point(736, 533);
            this.UIBtn_SetCom.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_SetCom.Name = "UIBtn_SetCom";
            this.UIBtn_SetCom.Size = new System.Drawing.Size(150, 47);
            this.UIBtn_SetCom.TabIndex = 2;
            this.UIBtn_SetCom.Text = "设置通信";
            this.UIBtn_SetCom.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_SetCom.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_SetCom.Click += new System.EventHandler(this.btn_setCommunicate_Click);
            // 
            // UIBtn_Save
            // 
            this.UIBtn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Save.Location = new System.Drawing.Point(736, 603);
            this.UIBtn_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Save.Name = "UIBtn_Save";
            this.UIBtn_Save.Size = new System.Drawing.Size(150, 47);
            this.UIBtn_Save.TabIndex = 2;
            this.UIBtn_Save.Text = "保存";
            this.UIBtn_Save.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Save.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // uiBtn_SetZero
            // 
            this.uiBtn_SetZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_SetZero.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_SetZero.Location = new System.Drawing.Point(736, 463);
            this.uiBtn_SetZero.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_SetZero.Name = "uiBtn_SetZero";
            this.uiBtn_SetZero.Size = new System.Drawing.Size(150, 47);
            this.uiBtn_SetZero.TabIndex = 3;
            this.uiBtn_SetZero.Text = "零位设置";
            this.uiBtn_SetZero.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_SetZero.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ButtonAxes
            // 
            this.ButtonAxes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAxes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAxes.Location = new System.Drawing.Point(736, 393);
            this.ButtonAxes.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAxes.Name = "ButtonAxes";
            this.ButtonAxes.Size = new System.Drawing.Size(150, 47);
            this.ButtonAxes.TabIndex = 3;
            this.ButtonAxes.Text = "伺服手动";
            this.ButtonAxes.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAxes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ButtonAxes.Click += new System.EventHandler(this.ButtonAxes_Click);
            // 
            // FrmParam
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(909, 664);
            this.Controls.Add(this.ButtonAxes);
            this.Controls.Add(this.uiBtn_SetZero);
            this.Controls.Add(this.UIBtn_Save);
            this.Controls.Add(this.UIBtn_SetCom);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "FrmParam";
            this.Text = "FrmParam";
            this.Load += new System.EventHandler(this.FrmParam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIButton UIBtn_SetCom;
        private Sunny.UI.UIButton UIBtn_Save;
        private Sunny.UI.UIButton uiBtn_SetZero;
        private Sunny.UI.UIButton ButtonAxes;
    }
}