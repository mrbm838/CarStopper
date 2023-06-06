namespace OP001
{
    partial class FrmRewrite
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.UIBtn_Get = new Sunny.UI.UIButton();
            this.UIBtn_Write = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 184);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Location = new System.Drawing.Point(3, 205);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(901, 184);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView3.Location = new System.Drawing.Point(3, 402);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(901, 184);
            this.dataGridView3.TabIndex = 0;
            // 
            // UIBtn_Get
            // 
            this.UIBtn_Get.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Get.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Get.Location = new System.Drawing.Point(107, 611);
            this.UIBtn_Get.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Get.Name = "UIBtn_Get";
            this.UIBtn_Get.Size = new System.Drawing.Size(169, 41);
            this.UIBtn_Get.TabIndex = 2;
            this.UIBtn_Get.Text = "获取写入失败数据";
            this.UIBtn_Get.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Get.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // UIBtn_Write
            // 
            this.UIBtn_Write.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UIBtn_Write.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Write.Location = new System.Drawing.Point(620, 611);
            this.UIBtn_Write.MinimumSize = new System.Drawing.Size(1, 1);
            this.UIBtn_Write.Name = "UIBtn_Write";
            this.UIBtn_Write.Size = new System.Drawing.Size(169, 41);
            this.UIBtn_Write.TabIndex = 2;
            this.UIBtn_Write.Text = "重新写入数据库";
            this.UIBtn_Write.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UIBtn_Write.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UIBtn_Write.Click += new System.EventHandler(this.btn_WriteAll_Click);
            // 
            // FrmRewrite
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(909, 664);
            this.Controls.Add(this.UIBtn_Write);
            this.Controls.Add(this.UIBtn_Get);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmRewrite";
            this.Text = "FrmRewrite";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private Sunny.UI.UIButton UIBtn_Get;
        private Sunny.UI.UIButton UIBtn_Write;
    }
}