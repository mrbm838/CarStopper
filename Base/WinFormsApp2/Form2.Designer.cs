namespace WinFormsApp2
{
    partial class Form2
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
            this.TableLayoutPanelInput = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.TableLayoutPanelOutput = new Sunny.UI.UITableLayoutPanel();
            SuspendLayout();
            // 
            // TableLayoutPanelInput
            // 
            this.TableLayoutPanelInput.ColumnCount = 2;
            this.TableLayoutPanelInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            this.TableLayoutPanelInput.Location = new Point(40, 54);
            this.TableLayoutPanelInput.Name = "TableLayoutPanelInput";
            this.TableLayoutPanelInput.RowCount = 2;
            this.TableLayoutPanelInput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.TableLayoutPanelInput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.TableLayoutPanelInput.Size = new Size(200, 100);
            this.TableLayoutPanelInput.TabIndex = 0;
            this.TableLayoutPanelInput.TagString = null;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 2;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.Location = new Point(0, 0);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 2;
            this.uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.Size = new Size(200, 100);
            this.uiTableLayoutPanel2.TabIndex = 0;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // TableLayoutPanelOutput
            // 
            this.TableLayoutPanelOutput.ColumnCount = 2;
            this.TableLayoutPanelOutput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.TableLayoutPanelOutput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            this.TableLayoutPanelOutput.Location = new Point(412, 54);
            this.TableLayoutPanelOutput.Name = "TableLayoutPanelOutput";
            this.TableLayoutPanelOutput.RowCount = 2;
            this.TableLayoutPanelOutput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.TableLayoutPanelOutput.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.TableLayoutPanelOutput.Size = new Size(200, 100);
            this.TableLayoutPanelOutput.TabIndex = 1;
            this.TableLayoutPanelOutput.TagString = null;
            // 
            // Form2
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(740, 550);
            this.Controls.Add(this.TableLayoutPanelOutput);
            this.Controls.Add(this.TableLayoutPanelInput);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel TableLayoutPanelInput;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITableLayoutPanel TableLayoutPanelOutput;
    }
}