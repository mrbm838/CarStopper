using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny;
using Sunny.UI;
using CommonMES;

namespace OP010
{
    public partial class FrmMes : UIPage
    {
        UC_MesJson mesJson;
        UC_MesString mesString;


        public FrmMes()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiComboBox1.SelectedIndex != -1)
            {
                switch (uiComboBox1.SelectedItem.ToString())
                {
                    case "Json":
                        mesJson = new UC_MesJson(StaticParam.mesTypePath,StaticParam.lstMesParam);
                        OpenUControl(mesJson);
                        break;
                    case "字符串":
                        mesString = new UC_MesString();
                        OpenUControl(mesString);
                        break;
                }
            }
        }


        private void OpenUControl(UserControl userControl)
        {
            uiSplitContainer1.Panel2.Controls.Clear();
            userControl.AutoScroll = true;
            userControl.Parent = uiSplitContainer1.Panel2;
            userControl.Dock = DockStyle.Fill;
            userControl.Show();
        }
    }
}
