using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WinFormsApp2
{
    public partial class Form2 : UIForm
    {
        public Form2()
        {
            InitializeComponent();
            LoadRunnerInputSignal();
            LoadRunnerOutputSignal();

            LoadCheckBox();
        }

        private void LoadCheckBox()
        {
            uiCheckBoxGroup1.Items.AddRange(new[] { "1,", "22" });
        }

        private void LoadRunnerInputSignal()
        {
            int rowHeight = 20;
            int labelWidth = 190;
            int layoutWidth = 240;
            TableLayoutPanelInput.RowCount = 15;
            TableLayoutPanelInput.Height = TableLayoutPanelInput.RowCount * rowHeight;
            TableLayoutPanelInput.Width = layoutWidth;
            var array = new Control[30];
            for (int i = 0; i < 30; i += 2)
            {
                array[i] = new UILedBulb();
                array[i + 1] = new UILabel
                {
                    Text = "Y0100 托盘6顶升气缸上",
                    TextAlign = ContentAlignment.BottomCenter,
                    Size = new Size(labelWidth, rowHeight)
                };
            }

            TableLayoutPanelInput.Controls.AddRange(array);

            foreach (RowStyle v in TableLayoutPanelInput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = rowHeight;
            }
        }

        private void LoadRunnerOutputSignal()
        {
            int rowHeight = 30;
            int labelWidth = 190;
            int layoutWidth = 240;
            TableLayoutPanelOutput.RowCount = 15;
            TableLayoutPanelOutput.Height = TableLayoutPanelOutput.RowCount * rowHeight;
            TableLayoutPanelOutput.Width = layoutWidth;
            var array = new Control[30];
            for (int i = 0; i < 30; i += 2)
            {
                array[i] = new UILedBulb();
                array[i + 1] = new UILabel
                {
                    Text = "Y0100 托盘6顶升气缸上",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(labelWidth, rowHeight),

                };
                array[i + 1].Click += uiLabel1_Click;
            }

            TableLayoutPanelOutput.Controls.AddRange(array);

            foreach (RowStyle v in TableLayoutPanelOutput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = rowHeight;
            }
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {
            var v = (UILabel)sender;
        }

        private void TableLayoutPanelOutput_DoubleClick(object sender, EventArgs e)
        {

            if (TableLayoutPanelOutput.RowCount == 0) { return; }

            TableLayoutPanelOutput.Select();

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiTextBox1.Text = uiComboBox1.SelectedIndex + Environment.NewLine;
            uiTextBox1.Text += uiComboBox1.Text + Environment.NewLine;
            uiTextBox1.Text += uiComboBox1.SelectedItem;
        }
    }
}
