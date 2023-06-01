namespace OP010.Forms
{
    partial class FrmSelectCom
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
            this.uiBtn_Confirm = new Sunny.UI.UIButton();
            this.uitxt_Name = new Sunny.UI.UITextBox();
            this.uicbx_Type = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(153, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "通信类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(153, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "通信名称";
            // 
            // uiBtn_Confirm
            // 
            this.uiBtn_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Confirm.Location = new System.Drawing.Point(159, 353);
            this.uiBtn_Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Confirm.Name = "uiBtn_Confirm";
            this.uiBtn_Confirm.Size = new System.Drawing.Size(149, 39);
            this.uiBtn_Confirm.TabIndex = 5;
            this.uiBtn_Confirm.Text = "确认";
            this.uiBtn_Confirm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Confirm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // uitxt_Name
            // 
            this.uitxt_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitxt_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uitxt_Name.Location = new System.Drawing.Point(103, 265);
            this.uitxt_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitxt_Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.uitxt_Name.Name = "uitxt_Name";
            this.uitxt_Name.ShowText = false;
            this.uitxt_Name.Size = new System.Drawing.Size(270, 37);
            this.uitxt_Name.TabIndex = 6;
            this.uitxt_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitxt_Name.Watermark = "";
            this.uitxt_Name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uicbx_Type
            // 
            this.uicbx_Type.DataSource = null;
            this.uicbx_Type.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uicbx_Type.FillColor = System.Drawing.Color.White;
            this.uicbx_Type.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uicbx_Type.Items.AddRange(new object[] {
            "网口",
            "串口",
            "PLC"});
            this.uicbx_Type.Location = new System.Drawing.Point(103, 109);
            this.uicbx_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicbx_Type.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicbx_Type.Name = "uicbx_Type";
            this.uicbx_Type.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicbx_Type.Size = new System.Drawing.Size(270, 37);
            this.uicbx_Type.TabIndex = 7;
            this.uicbx_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicbx_Type.Watermark = "";
            this.uicbx_Type.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmSelectCom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(498, 425);
            this.Controls.Add(this.uicbx_Type);
            this.Controls.Add(this.uitxt_Name);
            this.Controls.Add(this.uiBtn_Confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmSelectCom";
            this.Text = "FrmSelectCom";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 498, 425);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UIButton uiBtn_Confirm;
        private Sunny.UI.UITextBox uitxt_Name;
        private Sunny.UI.UIComboBox uicbx_Type;
    }
}