namespace OP010.Forms
{
    partial class FrmTest
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
            this.txt_ReceiveMsg = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_SendMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_ReceiveMsg
            // 
            this.txt_ReceiveMsg.Location = new System.Drawing.Point(6, 348);
            this.txt_ReceiveMsg.Multiline = true;
            this.txt_ReceiveMsg.Name = "txt_ReceiveMsg";
            this.txt_ReceiveMsg.Size = new System.Drawing.Size(218, 107);
            this.txt_ReceiveMsg.TabIndex = 5;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(66, 195);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(79, 33);
            this.btn_Send.TabIndex = 7;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_SendMsg
            // 
            this.txt_SendMsg.Location = new System.Drawing.Point(6, 42);
            this.txt_SendMsg.Multiline = true;
            this.txt_SendMsg.Name = "txt_SendMsg";
            this.txt_SendMsg.Size = new System.Drawing.Size(218, 107);
            this.txt_SendMsg.TabIndex = 6;
            // 
            // FrmTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(236, 496);
            this.Controls.Add(this.txt_ReceiveMsg);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_SendMsg);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTest_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ReceiveMsg;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_SendMsg;
    }
}