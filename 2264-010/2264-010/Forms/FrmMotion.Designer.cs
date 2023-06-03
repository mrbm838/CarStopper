namespace OP010.Forms
{
    partial class FrmMotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMotion));
            this.CheckBoxGroupPos = new Sunny.UI.UICheckBoxGroup();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.ButtonMove = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ComboBoxPos = new Sunny.UI.UIComboBox();
            this.ButtonSave = new Sunny.UI.UIButton();
            this.TextBoxCurLocationR = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TextBoxCurLocationZ = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.ComboBoxDistanceZ = new Sunny.UI.UIComboBox();
            this.uiTabControlMenu1 = new Sunny.UI.UITabControlMenu();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TextBoxSpeedZ = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.ButtonStopZ = new Sunny.UI.UIButton();
            this.ButtonReversionZ = new Sunny.UI.UIButton();
            this.ImageButtonDistanceReduceZ = new Sunny.UI.UIImageButton();
            this.ImageButtonDistancePlusZ = new Sunny.UI.UIImageButton();
            this.ButtonSevOnZ = new Sunny.UI.UIButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiTabControlMenu2 = new Sunny.UI.UITabControlMenu();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.TableLayoutPanelOutput = new Sunny.UI.UITableLayoutPanel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.TableLayoutPanelInput = new Sunny.UI.UITableLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.TableLayoutPanelRunnerOutput = new Sunny.UI.UITableLayoutPanel();
            this.uiGroupBox5 = new Sunny.UI.UIGroupBox();
            this.TableLayoutPanelRunnerInput2 = new Sunny.UI.UITableLayoutPanel();
            this.TableLayoutPanelRunnerInput1 = new Sunny.UI.UITableLayoutPanel();
            this.TimerFlash = new System.Windows.Forms.Timer(this.components);
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiGroupBox1.SuspendLayout();
            this.uiTabControlMenu1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageButtonDistanceReduceZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageButtonDistancePlusZ)).BeginInit();
            this.uiTabControlMenu2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxGroupPos
            // 
            this.CheckBoxGroupPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBoxGroupPos.Items.AddRange(new object[] {
            "点位1",
            "点位2",
            "点位3",
            "点位4",
            "点位5"});
            this.CheckBoxGroupPos.Location = new System.Drawing.Point(58, 472);
            this.CheckBoxGroupPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxGroupPos.MinimumSize = new System.Drawing.Size(1, 1);
            this.CheckBoxGroupPos.Name = "CheckBoxGroupPos";
            this.CheckBoxGroupPos.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.CheckBoxGroupPos.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("CheckBoxGroupPos.SelectedIndexes")));
            this.CheckBoxGroupPos.Size = new System.Drawing.Size(307, 10);
            this.CheckBoxGroupPos.TabIndex = 1;
            this.CheckBoxGroupPos.Text = "点位启用";
            this.CheckBoxGroupPos.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxGroupPos.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.ButtonMove);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.ComboBoxPos);
            this.uiGroupBox1.Controls.Add(this.ButtonSave);
            this.uiGroupBox1.Controls.Add(this.TextBoxCurLocationR);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Controls.Add(this.TextBoxCurLocationZ);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(34, 31);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(806, 216);
            this.uiGroupBox1.TabIndex = 2;
            this.uiGroupBox1.Text = "位置保存";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ButtonMove
            // 
            this.ButtonMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMove.Enabled = false;
            this.ButtonMove.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonMove.Location = new System.Drawing.Point(430, 112);
            this.ButtonMove.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonMove.Name = "ButtonMove";
            this.ButtonMove.Size = new System.Drawing.Size(132, 35);
            this.ButtonMove.TabIndex = 10;
            this.ButtonMove.Text = "运动";
            this.ButtonMove.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonMove.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(34, 118);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(90, 23);
            this.uiLabel3.TabIndex = 9;
            this.uiLabel3.Text = "当前点位：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ComboBoxPos
            // 
            this.ComboBoxPos.DataSource = null;
            this.ComboBoxPos.FillColor = System.Drawing.Color.White;
            this.ComboBoxPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxPos.Location = new System.Drawing.Point(131, 112);
            this.ComboBoxPos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxPos.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxPos.Name = "ComboBoxPos";
            this.ComboBoxPos.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxPos.Size = new System.Drawing.Size(268, 35);
            this.ComboBoxPos.TabIndex = 8;
            this.ComboBoxPos.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxPos.Watermark = "";
            this.ComboBoxPos.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSave.Location = new System.Drawing.Point(430, 153);
            this.ButtonSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(132, 35);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "保存";
            this.ButtonSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TextBoxCurLocationR
            // 
            this.TextBoxCurLocationR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxCurLocationR.DoubleValue = 100.001D;
            this.TextBoxCurLocationR.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxCurLocationR.Location = new System.Drawing.Point(312, 43);
            this.TextBoxCurLocationR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxCurLocationR.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxCurLocationR.Name = "TextBoxCurLocationR";
            this.TextBoxCurLocationR.ShowText = false;
            this.TextBoxCurLocationR.Size = new System.Drawing.Size(87, 29);
            this.TextBoxCurLocationR.TabIndex = 5;
            this.TextBoxCurLocationR.Text = "100.001";
            this.TextBoxCurLocationR.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBoxCurLocationR.Watermark = "";
            this.TextBoxCurLocationR.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(273, 46);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(44, 23);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "R：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TextBoxCurLocationZ
            // 
            this.TextBoxCurLocationZ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxCurLocationZ.DoubleValue = 100.001D;
            this.TextBoxCurLocationZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxCurLocationZ.Location = new System.Drawing.Point(170, 43);
            this.TextBoxCurLocationZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxCurLocationZ.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxCurLocationZ.Name = "TextBoxCurLocationZ";
            this.TextBoxCurLocationZ.ShowText = false;
            this.TextBoxCurLocationZ.Size = new System.Drawing.Size(87, 29);
            this.TextBoxCurLocationZ.TabIndex = 3;
            this.TextBoxCurLocationZ.Text = "100.001";
            this.TextBoxCurLocationZ.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBoxCurLocationZ.Watermark = "";
            this.TextBoxCurLocationZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(132, 46);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(40, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Z：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ComboBoxDistanceZ
            // 
            this.ComboBoxDistanceZ.DataSource = null;
            this.ComboBoxDistanceZ.FillColor = System.Drawing.Color.White;
            this.ComboBoxDistanceZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxDistanceZ.Items.AddRange(new object[] {
            "0.01",
            "0.1",
            "1",
            "5",
            "10",
            "20",
            "40",
            "100"});
            this.ComboBoxDistanceZ.Location = new System.Drawing.Point(107, 9);
            this.ComboBoxDistanceZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxDistanceZ.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxDistanceZ.Name = "ComboBoxDistanceZ";
            this.ComboBoxDistanceZ.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxDistanceZ.Size = new System.Drawing.Size(123, 31);
            this.ComboBoxDistanceZ.TabIndex = 6;
            this.ComboBoxDistanceZ.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxDistanceZ.Watermark = "";
            this.ComboBoxDistanceZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTabControlMenu1
            // 
            this.uiTabControlMenu1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.uiTabControlMenu1.Controls.Add(this.tabPage1);
            this.uiTabControlMenu1.Controls.Add(this.tabPage2);
            this.uiTabControlMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControlMenu1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControlMenu1.Location = new System.Drawing.Point(34, 284);
            this.uiTabControlMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiTabControlMenu1.Multiline = true;
            this.uiTabControlMenu1.Name = "uiTabControlMenu1";
            this.uiTabControlMenu1.SelectedIndex = 0;
            this.uiTabControlMenu1.Size = new System.Drawing.Size(806, 85);
            this.uiTabControlMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControlMenu1.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiTabControlMenu1.TabIndex = 7;
            this.uiTabControlMenu1.TabSelectedColor = System.Drawing.Color.DarkBlue;
            this.uiTabControlMenu1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TextBoxSpeedZ);
            this.tabPage1.Controls.Add(this.uiLabel5);
            this.tabPage1.Controls.Add(this.uiLabel4);
            this.tabPage1.Controls.Add(this.ButtonStopZ);
            this.tabPage1.Controls.Add(this.ButtonReversionZ);
            this.tabPage1.Controls.Add(this.ImageButtonDistanceReduceZ);
            this.tabPage1.Controls.Add(this.ImageButtonDistancePlusZ);
            this.tabPage1.Controls.Add(this.ButtonSevOnZ);
            this.tabPage1.Controls.Add(this.ComboBoxDistanceZ);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage1.Location = new System.Drawing.Point(201, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(605, 85);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Z轴";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TextBoxSpeedZ
            // 
            this.TextBoxSpeedZ.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSpeedZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxSpeedZ.Location = new System.Drawing.Point(107, 46);
            this.TextBoxSpeedZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxSpeedZ.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxSpeedZ.Name = "TextBoxSpeedZ";
            this.TextBoxSpeedZ.ShowText = false;
            this.TextBoxSpeedZ.Size = new System.Drawing.Size(123, 31);
            this.TextBoxSpeedZ.TabIndex = 19;
            this.TextBoxSpeedZ.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBoxSpeedZ.Watermark = "";
            this.TextBoxSpeedZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(13, 49);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(93, 23);
            this.uiLabel5.TabIndex = 16;
            this.uiLabel5.Text = "运动速度：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(13, 12);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(93, 23);
            this.uiLabel4.TabIndex = 11;
            this.uiLabel4.Text = "运动距离：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ButtonStopZ
            // 
            this.ButtonStopZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStopZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStopZ.Location = new System.Drawing.Point(493, 45);
            this.ButtonStopZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonStopZ.Name = "ButtonStopZ";
            this.ButtonStopZ.Size = new System.Drawing.Size(100, 35);
            this.ButtonStopZ.TabIndex = 14;
            this.ButtonStopZ.Text = "停止";
            this.ButtonStopZ.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStopZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ButtonStopZ.Click += new System.EventHandler(this.ButtonStopZ_Click);
            // 
            // ButtonReversionZ
            // 
            this.ButtonReversionZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonReversionZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonReversionZ.Location = new System.Drawing.Point(493, 6);
            this.ButtonReversionZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonReversionZ.Name = "ButtonReversionZ";
            this.ButtonReversionZ.Size = new System.Drawing.Size(100, 35);
            this.ButtonReversionZ.TabIndex = 13;
            this.ButtonReversionZ.Text = "归原";
            this.ButtonReversionZ.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonReversionZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ButtonReversionZ.Click += new System.EventHandler(this.ButtonReversionZ_Click);
            // 
            // ImageButtonDistanceReduceZ
            // 
            this.ImageButtonDistanceReduceZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageButtonDistanceReduceZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageButtonDistanceReduceZ.Image = ((System.Drawing.Image)(resources.GetObject("ImageButtonDistanceReduceZ.Image")));
            this.ImageButtonDistanceReduceZ.Location = new System.Drawing.Point(299, 6);
            this.ImageButtonDistanceReduceZ.Name = "ImageButtonDistanceReduceZ";
            this.ImageButtonDistanceReduceZ.Size = new System.Drawing.Size(34, 34);
            this.ImageButtonDistanceReduceZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageButtonDistanceReduceZ.TabIndex = 12;
            this.ImageButtonDistanceReduceZ.TabStop = false;
            this.ImageButtonDistanceReduceZ.Text = null;
            this.ImageButtonDistanceReduceZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ImageButtonDistanceReduceZ.Click += new System.EventHandler(this.ImageButtonDistanceReduceZ_Click);
            // 
            // ImageButtonDistancePlusZ
            // 
            this.ImageButtonDistancePlusZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageButtonDistancePlusZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageButtonDistancePlusZ.Image = ((System.Drawing.Image)(resources.GetObject("ImageButtonDistancePlusZ.Image")));
            this.ImageButtonDistancePlusZ.Location = new System.Drawing.Point(257, 6);
            this.ImageButtonDistancePlusZ.Name = "ImageButtonDistancePlusZ";
            this.ImageButtonDistancePlusZ.Size = new System.Drawing.Size(34, 34);
            this.ImageButtonDistancePlusZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageButtonDistancePlusZ.TabIndex = 11;
            this.ImageButtonDistancePlusZ.TabStop = false;
            this.ImageButtonDistancePlusZ.Text = null;
            this.ImageButtonDistancePlusZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ImageButtonDistancePlusZ.Click += new System.EventHandler(this.ImageButtonDistancePlusZ_Click);
            // 
            // ButtonSevOnZ
            // 
            this.ButtonSevOnZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSevOnZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSevOnZ.Location = new System.Drawing.Point(387, 6);
            this.ButtonSevOnZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonSevOnZ.Name = "ButtonSevOnZ";
            this.ButtonSevOnZ.Size = new System.Drawing.Size(100, 35);
            this.ButtonSevOnZ.TabIndex = 8;
            this.ButtonSevOnZ.Text = "开使能";
            this.ButtonSevOnZ.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonSevOnZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ButtonSevOnZ.Click += new System.EventHandler(this.ButtonSevOnZ_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(201, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(605, 85);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "R轴";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiTabControlMenu2
            // 
            this.uiTabControlMenu2.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.uiTabControlMenu2.Controls.Add(this.tabPage5);
            this.uiTabControlMenu2.Controls.Add(this.tabPage6);
            this.uiTabControlMenu2.Controls.Add(this.tabPage3);
            this.uiTabControlMenu2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControlMenu2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControlMenu2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControlMenu2.ItemSize = new System.Drawing.Size(160, 40);
            this.uiTabControlMenu2.Location = new System.Drawing.Point(0, 35);
            this.uiTabControlMenu2.Multiline = true;
            this.uiTabControlMenu2.Name = "uiTabControlMenu2";
            this.uiTabControlMenu2.SelectedIndex = 0;
            this.uiTabControlMenu2.Size = new System.Drawing.Size(1052, 525);
            this.uiTabControlMenu2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControlMenu2.TabIndex = 9;
            this.uiTabControlMenu2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.uiTabControlMenu1);
            this.tabPage5.Controls.Add(this.uiGroupBox1);
            this.tabPage5.Controls.Add(this.CheckBoxGroupPos);
            this.tabPage5.Location = new System.Drawing.Point(161, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(891, 525);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "电机";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.uiGroupBox3);
            this.tabPage6.Controls.Add(this.uiGroupBox2);
            this.tabPage6.Location = new System.Drawing.Point(161, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(891, 525);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "气缸&IO";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.TableLayoutPanelOutput);
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(390, 19);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(340, 479);
            this.uiGroupBox3.TabIndex = 9;
            this.uiGroupBox3.Text = "Output";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TableLayoutPanelOutput
            // 
            this.TableLayoutPanelOutput.ColumnCount = 2;
            this.TableLayoutPanelOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanelOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanelOutput.Location = new System.Drawing.Point(51, 45);
            this.TableLayoutPanelOutput.Name = "TableLayoutPanelOutput";
            this.TableLayoutPanelOutput.RowCount = 2;
            this.TableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelOutput.Size = new System.Drawing.Size(200, 100);
            this.TableLayoutPanelOutput.TabIndex = 0;
            this.TableLayoutPanelOutput.TagString = null;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.TableLayoutPanelInput);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(26, 19);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(340, 479);
            this.uiGroupBox2.TabIndex = 8;
            this.uiGroupBox2.Text = "Input";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TableLayoutPanelInput
            // 
            this.TableLayoutPanelInput.ColumnCount = 2;
            this.TableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanelInput.Location = new System.Drawing.Point(51, 45);
            this.TableLayoutPanelInput.Name = "TableLayoutPanelInput";
            this.TableLayoutPanelInput.RowCount = 2;
            this.TableLayoutPanelInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelInput.Size = new System.Drawing.Size(200, 100);
            this.TableLayoutPanelInput.TabIndex = 0;
            this.TableLayoutPanelInput.TagString = null;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uiGroupBox4);
            this.tabPage3.Controls.Add(this.uiGroupBox5);
            this.tabPage3.Location = new System.Drawing.Point(161, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(891, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "流道";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.TableLayoutPanelRunnerOutput);
            this.uiGroupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(438, 0);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(311, 525);
            this.uiGroupBox4.TabIndex = 11;
            this.uiGroupBox4.Text = "Output";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TableLayoutPanelRunnerOutput
            // 
            this.TableLayoutPanelRunnerOutput.ColumnCount = 2;
            this.TableLayoutPanelRunnerOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanelRunnerOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanelRunnerOutput.Location = new System.Drawing.Point(30, 35);
            this.TableLayoutPanelRunnerOutput.Name = "TableLayoutPanelRunnerOutput";
            this.TableLayoutPanelRunnerOutput.RowCount = 2;
            this.TableLayoutPanelRunnerOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerOutput.Size = new System.Drawing.Size(108, 445);
            this.TableLayoutPanelRunnerOutput.TabIndex = 0;
            this.TableLayoutPanelRunnerOutput.TagString = null;
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.TableLayoutPanelRunnerInput2);
            this.uiGroupBox5.Controls.Add(this.TableLayoutPanelRunnerInput1);
            this.uiGroupBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox5.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox5.Size = new System.Drawing.Size(430, 520);
            this.uiGroupBox5.TabIndex = 10;
            this.uiGroupBox5.Text = "Input";
            this.uiGroupBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TableLayoutPanelRunnerInput2
            // 
            this.TableLayoutPanelRunnerInput2.ColumnCount = 2;
            this.TableLayoutPanelRunnerInput2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanelRunnerInput2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanelRunnerInput2.Location = new System.Drawing.Point(234, 35);
            this.TableLayoutPanelRunnerInput2.Name = "TableLayoutPanelRunnerInput2";
            this.TableLayoutPanelRunnerInput2.RowCount = 2;
            this.TableLayoutPanelRunnerInput2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerInput2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerInput2.Size = new System.Drawing.Size(108, 445);
            this.TableLayoutPanelRunnerInput2.TabIndex = 1;
            this.TableLayoutPanelRunnerInput2.TagString = null;
            // 
            // TableLayoutPanelRunnerInput1
            // 
            this.TableLayoutPanelRunnerInput1.ColumnCount = 2;
            this.TableLayoutPanelRunnerInput1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPanelRunnerInput1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPanelRunnerInput1.Location = new System.Drawing.Point(22, 35);
            this.TableLayoutPanelRunnerInput1.Name = "TableLayoutPanelRunnerInput1";
            this.TableLayoutPanelRunnerInput1.RowCount = 2;
            this.TableLayoutPanelRunnerInput1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerInput1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelRunnerInput1.Size = new System.Drawing.Size(108, 445);
            this.TableLayoutPanelRunnerInput1.TabIndex = 0;
            this.TableLayoutPanelRunnerInput1.TagString = null;
            // 
            // TimerFlash
            // 
            this.TimerFlash.Tick += new System.EventHandler(this.TimerFlash_Tick);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(34, 45);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(90, 23);
            this.uiLabel6.TabIndex = 11;
            this.uiLabel6.Text = "当前位置：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmMotion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1052, 560);
            this.Controls.Add(this.uiTabControlMenu2);
            this.Name = "FrmMotion";
            this.Text = "FrmMotion";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiTabControlMenu1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageButtonDistanceReduceZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageButtonDistancePlusZ)).EndInit();
            this.uiTabControlMenu2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UICheckBoxGroup CheckBoxGroupPos;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TextBoxCurLocationR;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TextBoxCurLocationZ;
        private Sunny.UI.UIButton ButtonSave;
        private Sunny.UI.UIComboBox ComboBoxDistanceZ;
        private Sunny.UI.UIComboBox ComboBoxPos;
        private Sunny.UI.UITabControlMenu uiTabControlMenu1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIButton ButtonSevOnZ;
        private Sunny.UI.UIImageButton ImageButtonDistancePlusZ;
        private Sunny.UI.UIButton ButtonReversionZ;
        private Sunny.UI.UIImageButton ImageButtonDistanceReduceZ;
        private Sunny.UI.UIButton ButtonStopZ;
        private Sunny.UI.UITabControlMenu uiTabControlMenu2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private Sunny.UI.UILabel uiLabel3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelOutput;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelInput;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelRunnerOutput;
        private Sunny.UI.UIGroupBox uiGroupBox5;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelRunnerInput1;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelRunnerInput2;
        private Sunny.UI.UIButton ButtonMove;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox TextBoxSpeedZ;
        private System.Windows.Forms.Timer TimerFlash;
        private Sunny.UI.UILabel uiLabel6;
    }
}