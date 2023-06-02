using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace OP010.Forms
{
    public partial class FrmMotion : UIForm
    {
        public FrmMotion()
        {
            InitializeComponent();
            LoadInputSignal();
            LoadOutputSignal();
        }

        private void LoadInputSignal()
        {
            TableLayoutPanelInput.RowCount = 5;
            var array = new Control[10];
            for (int i = 0; i < 10; i += 2)
            {
                array[i] = new UILedBulb();
                array[i + 1] = new UILabel
                {
                    Text = "safdjsllfk",
                    TextAlign = ContentAlignment.BottomCenter
                };
            }

            TableLayoutPanelInput.Controls.AddRange(array);

            foreach (RowStyle v in TableLayoutPanelInput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = 30;
            }
        }

        private void LoadOutputSignal()
        {
            TableLayoutPanelInput.RowCount = 5;
            var array = new Control[10];
            for (int i = 0; i < 10; i += 2)
            {
                array[i] = new UILedBulb();
                array[i + 1] = new UILabel
                {
                    Text = "safdjsllfk",
                    TextAlign = ContentAlignment.BottomCenter
                };
            }

            TableLayoutPanelInput.Controls.AddRange(array);

            foreach (RowStyle v in TableLayoutPanelInput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = 30;
            }
        }
    }
}
