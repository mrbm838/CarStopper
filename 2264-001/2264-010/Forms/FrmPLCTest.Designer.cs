namespace PLC通讯协议
{
    partial class FrmPLCTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiCbx_DataFormat = new Sunny.UI.UIComboBox();
            this.uiCbx_Reverse = new Sunny.UI.UICheckBox();
            this.uiTxt_Timeout = new Sunny.UI.UITextBox();
            this.uiTxt_StationNum = new Sunny.UI.UITextBox();
            this.uiCbx_StartZero = new Sunny.UI.UICheckBox();
            this.uiTxt_Port = new Sunny.UI.UITextBox();
            this.uiTxt_IP = new Sunny.UI.UITextBox();
            this.uiBtn_DisConnect = new Sunny.UI.UIButton();
            this.uiBtn_Connect = new Sunny.UI.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiCbx_AddrType = new Sunny.UI.UIComboBox();
            this.uiTxt_Value = new Sunny.UI.UITextBox();
            this.uiTxt_Length = new Sunny.UI.UITextBox();
            this.uiTxt_Addr = new Sunny.UI.UITextBox();
            this.uiBtn_Write = new Sunny.UI.UIButton();
            this.uiBtn_Read = new Sunny.UI.UIButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.uiCbx_DataFormat);
            this.panel1.Controls.Add(this.uiCbx_Reverse);
            this.panel1.Controls.Add(this.uiTxt_Timeout);
            this.panel1.Controls.Add(this.uiTxt_StationNum);
            this.panel1.Controls.Add(this.uiCbx_StartZero);
            this.panel1.Controls.Add(this.uiTxt_Port);
            this.panel1.Controls.Add(this.uiTxt_IP);
            this.panel1.Controls.Add(this.uiBtn_DisConnect);
            this.panel1.Controls.Add(this.uiBtn_Connect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 219);
            this.panel1.TabIndex = 1;
            // 
            // uiCbx_DataFormat
            // 
            this.uiCbx_DataFormat.DataSource = null;
            this.uiCbx_DataFormat.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiCbx_DataFormat.FillColor = System.Drawing.Color.White;
            this.uiCbx_DataFormat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCbx_DataFormat.Location = new System.Drawing.Point(481, 11);
            this.uiCbx_DataFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCbx_DataFormat.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCbx_DataFormat.Name = "uiCbx_DataFormat";
            this.uiCbx_DataFormat.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiCbx_DataFormat.Size = new System.Drawing.Size(150, 29);
            this.uiCbx_DataFormat.TabIndex = 29;
            this.uiCbx_DataFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiCbx_DataFormat.Watermark = "";
            this.uiCbx_DataFormat.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCbx_Reverse
            // 
            this.uiCbx_Reverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCbx_Reverse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCbx_Reverse.Location = new System.Drawing.Point(377, 125);
            this.uiCbx_Reverse.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCbx_Reverse.Name = "uiCbx_Reverse";
            this.uiCbx_Reverse.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCbx_Reverse.Size = new System.Drawing.Size(150, 29);
            this.uiCbx_Reverse.TabIndex = 28;
            this.uiCbx_Reverse.Text = "字符串颠倒";
            this.uiCbx_Reverse.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_Timeout
            // 
            this.uiTxt_Timeout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_Timeout.DoubleValue = 2000D;
            this.uiTxt_Timeout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_Timeout.IntValue = 2000;
            this.uiTxt_Timeout.Location = new System.Drawing.Point(106, 177);
            this.uiTxt_Timeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_Timeout.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_Timeout.Name = "uiTxt_Timeout";
            this.uiTxt_Timeout.ShowText = false;
            this.uiTxt_Timeout.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_Timeout.TabIndex = 26;
            this.uiTxt_Timeout.Text = "2000";
            this.uiTxt_Timeout.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_Timeout.Watermark = "";
            this.uiTxt_Timeout.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_StationNum
            // 
            this.uiTxt_StationNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_StationNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_StationNum.Location = new System.Drawing.Point(106, 121);
            this.uiTxt_StationNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_StationNum.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_StationNum.Name = "uiTxt_StationNum";
            this.uiTxt_StationNum.ShowText = false;
            this.uiTxt_StationNum.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_StationNum.TabIndex = 25;
            this.uiTxt_StationNum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_StationNum.Watermark = "";
            this.uiTxt_StationNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiCbx_StartZero
            // 
            this.uiCbx_StartZero.Checked = true;
            this.uiCbx_StartZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCbx_StartZero.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCbx_StartZero.Location = new System.Drawing.Point(377, 64);
            this.uiCbx_StartZero.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCbx_StartZero.Name = "uiCbx_StartZero";
            this.uiCbx_StartZero.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCbx_StartZero.Size = new System.Drawing.Size(150, 29);
            this.uiCbx_StartZero.TabIndex = 27;
            this.uiCbx_StartZero.Text = "首地址从0开始";
            this.uiCbx_StartZero.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_Port
            // 
            this.uiTxt_Port.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_Port.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_Port.Location = new System.Drawing.Point(106, 65);
            this.uiTxt_Port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_Port.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_Port.Name = "uiTxt_Port";
            this.uiTxt_Port.ShowText = false;
            this.uiTxt_Port.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_Port.TabIndex = 24;
            this.uiTxt_Port.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_Port.Watermark = "";
            this.uiTxt_Port.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_IP
            // 
            this.uiTxt_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_IP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_IP.Location = new System.Drawing.Point(106, 9);
            this.uiTxt_IP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_IP.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_IP.Name = "uiTxt_IP";
            this.uiTxt_IP.ShowText = false;
            this.uiTxt_IP.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_IP.TabIndex = 23;
            this.uiTxt_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_IP.Watermark = "";
            this.uiTxt_IP.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiBtn_DisConnect
            // 
            this.uiBtn_DisConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_DisConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_DisConnect.Location = new System.Drawing.Point(562, 177);
            this.uiBtn_DisConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_DisConnect.Name = "uiBtn_DisConnect";
            this.uiBtn_DisConnect.Size = new System.Drawing.Size(100, 35);
            this.uiBtn_DisConnect.TabIndex = 22;
            this.uiBtn_DisConnect.Text = "断开";
            this.uiBtn_DisConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_DisConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_DisConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiBtn_Connect
            // 
            this.uiBtn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Connect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Connect.Location = new System.Drawing.Point(377, 177);
            this.uiBtn_Connect.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Connect.Name = "uiBtn_Connect";
            this.uiBtn_Connect.Size = new System.Drawing.Size(100, 35);
            this.uiBtn_Connect.TabIndex = 21;
            this.uiBtn_Connect.Text = "连接";
            this.uiBtn_Connect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Connect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "数据格式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "连接超时：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 127);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 21);
            this.label24.TabIndex = 10;
            this.label24.Text = "站号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip地址：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "地址：";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uiCbx_AddrType);
            this.panel2.Controls.Add(this.uiTxt_Value);
            this.panel2.Controls.Add(this.uiTxt_Length);
            this.panel2.Controls.Add(this.uiTxt_Addr);
            this.panel2.Controls.Add(this.uiBtn_Write);
            this.panel2.Controls.Add(this.uiBtn_Read);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(12, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 254);
            this.panel2.TabIndex = 6;
            // 
            // uiCbx_AddrType
            // 
            this.uiCbx_AddrType.DataSource = null;
            this.uiCbx_AddrType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiCbx_AddrType.FillColor = System.Drawing.Color.White;
            this.uiCbx_AddrType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCbx_AddrType.Items.AddRange(new object[] {
            "bool",
            "short",
            "int",
            "long",
            "float",
            "double",
            "string"});
            this.uiCbx_AddrType.Location = new System.Drawing.Point(154, 100);
            this.uiCbx_AddrType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCbx_AddrType.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCbx_AddrType.Name = "uiCbx_AddrType";
            this.uiCbx_AddrType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiCbx_AddrType.Size = new System.Drawing.Size(192, 29);
            this.uiCbx_AddrType.TabIndex = 29;
            this.uiCbx_AddrType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiCbx_AddrType.Watermark = "";
            this.uiCbx_AddrType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_Value
            // 
            this.uiTxt_Value.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_Value.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_Value.Location = new System.Drawing.Point(439, 58);
            this.uiTxt_Value.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_Value.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_Value.Name = "uiTxt_Value";
            this.uiTxt_Value.ShowText = false;
            this.uiTxt_Value.Size = new System.Drawing.Size(234, 60);
            this.uiTxt_Value.TabIndex = 28;
            this.uiTxt_Value.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_Value.Watermark = "";
            this.uiTxt_Value.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_Length
            // 
            this.uiTxt_Length.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_Length.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_Length.Location = new System.Drawing.Point(154, 188);
            this.uiTxt_Length.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_Length.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_Length.Name = "uiTxt_Length";
            this.uiTxt_Length.ShowText = false;
            this.uiTxt_Length.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_Length.TabIndex = 28;
            this.uiTxt_Length.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_Length.Watermark = "";
            this.uiTxt_Length.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTxt_Addr
            // 
            this.uiTxt_Addr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxt_Addr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxt_Addr.Location = new System.Drawing.Point(154, 16);
            this.uiTxt_Addr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxt_Addr.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxt_Addr.Name = "uiTxt_Addr";
            this.uiTxt_Addr.ShowText = false;
            this.uiTxt_Addr.Size = new System.Drawing.Size(192, 29);
            this.uiTxt_Addr.TabIndex = 28;
            this.uiTxt_Addr.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTxt_Addr.Watermark = "";
            this.uiTxt_Addr.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiBtn_Write
            // 
            this.uiBtn_Write.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Write.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Write.Location = new System.Drawing.Point(578, 188);
            this.uiBtn_Write.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Write.Name = "uiBtn_Write";
            this.uiBtn_Write.Size = new System.Drawing.Size(100, 35);
            this.uiBtn_Write.TabIndex = 27;
            this.uiBtn_Write.Text = "写入";
            this.uiBtn_Write.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Write.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Write.Click += new System.EventHandler(this.button4_Click);
            // 
            // uiBtn_Read
            // 
            this.uiBtn_Read.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiBtn_Read.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Read.Location = new System.Drawing.Point(422, 188);
            this.uiBtn_Read.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBtn_Read.Name = "uiBtn_Read";
            this.uiBtn_Read.Size = new System.Drawing.Size(100, 35);
            this.uiBtn_Read.TabIndex = 26;
            this.uiBtn_Read.Text = "读取";
            this.uiBtn_Read.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBtn_Read.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBtn_Read.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 25;
            this.label7.Text = "值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "字符串读取长度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 4;
            this.label8.Text = "地址类型：";
            // 
            // FrmPLCTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(725, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPLCTest";
            this.Text = "PLC测试界面";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 973, 450);
            this.Load += new System.EventHandler(this.OmronFinsTcpForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Sunny.UI.UIButton uiBtn_Write;
        private Sunny.UI.UIButton uiBtn_Read;
        private Sunny.UI.UITextBox uiTxt_Port;
        private Sunny.UI.UITextBox uiTxt_IP;
        private Sunny.UI.UIButton uiBtn_DisConnect;
        private Sunny.UI.UIButton uiBtn_Connect;
        private Sunny.UI.UITextBox uiTxt_Timeout;
        private Sunny.UI.UITextBox uiTxt_StationNum;
        private Sunny.UI.UICheckBox uiCbx_Reverse;
        private Sunny.UI.UICheckBox uiCbx_StartZero;
        private Sunny.UI.UIComboBox uiCbx_DataFormat;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox uiTxt_Addr;
        private Sunny.UI.UIComboBox uiCbx_AddrType;
        private System.Windows.Forms.Label label8;
        private Sunny.UI.UITextBox uiTxt_Length;
        private Sunny.UI.UITextBox uiTxt_Value;
    }
}