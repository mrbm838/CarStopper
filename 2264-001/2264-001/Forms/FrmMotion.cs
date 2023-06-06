using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.Imaging;
using CCWin.SkinClass;
using MotionBase;
using Sunny.UI;

namespace OP001.Forms
{
    //速度保存
    //登录
    //IO分组

    public partial class FrmMotion : UIForm
    {
        private Control[] arrayControlInput;
        private Control[] arrayControlOutput;
        private Control[] arrayControlRunnerInput;
        private Control[] arrayControlRunnerOutput;

        public FrmMotion()
        {
            InitializeComponent();

            LoadMotorPos();

            LoadInputSignal();
            LoadOutputSignal();
            LoadRunnerInputSignal();
            LoadRunnerOutputSignal();
            //属性设置RowCount
            
        }

        private void LoadMotorPos()
        {
            ComboBoxPos.Clear();
            var enums = Enum.GetNames(typeof(EnumPosition));
            for (int i = 0; i < enums.Length; i++)
            {
                ComboBoxPos.Items.Add($"{enums[i]}({StaticParam.Points[i].Z}, {StaticParam.Points[i].R})");
            }
        }

        private void LoadInputSignal()
        {
            //TableLayoutPanelInput.RowCount = 5;
            //var array = new Control[10];
            //for (int i = 0; i < 10; i += 2)
            //{
            //    array[i] = new UILedBulb();
            //    array[i + 1] = new UILabel
            //    {
            //        Text = "safdjsllfk",
            //        TextAlign = ContentAlignment.BottomCenter
            //    };
            //}

            //TableLayoutPanelInput.Controls.AddRange(array);

            //foreach (RowStyle v in TableLayoutPanelInput.RowStyles)
            //{
            //    v.SizeType = SizeType.Absolute;
            //    v.Height = 30;
            //}

            int rowHeight = 30;
            int labelWidth = 190;
            int layoutWidth = 240;
            TableLayoutPanelInput.RowCount = StaticParam.InputArray.Length;
            TableLayoutPanelInput.Height = TableLayoutPanelInput.RowCount * rowHeight;
            TableLayoutPanelInput.Width = layoutWidth;

            arrayControlInput = new Control[StaticParam.InputArray.Length * 2];

            for (int i = 0; i < StaticParam.InputArray.Length; i++)
            {
                DrvIO.tyIO_Parameter parameter = new DrvIO.tyIO_Parameter();
                StaticParam.InputArray[i].GetParameter(ref parameter);
                arrayControlInput[i] = new UILedBulb
                {
                    Color = Color.DarkGray
                };
                arrayControlInput[i + 1] = new UILabel
                {
                    Text = parameter.strID + " " + parameter.strCName.Trim(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(labelWidth, rowHeight)
                };
            }

            TableLayoutPanelInput.Controls.AddRange(arrayControlInput);

            foreach (RowStyle v in TableLayoutPanelInput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = rowHeight;
            }
        }

        private void LoadOutputSignal()
        {
            //TableLayoutPanelOutput.RowCount = 5;
            //var array = new Control[10];
            //for (int i = 0; i < 10; i += 2)
            //{
            //    array[i] = new UILedBulb();
            //    array[i + 1] = new UILabel
            //    {
            //        Text = "safdjsllfk",
            //        TextAlign = ContentAlignment.BottomCenter
            //    };
            //}

            //TableLayoutPanelOutput.Controls.AddRange(array);

            //foreach (RowStyle v in TableLayoutPanelOutput.RowStyles)
            //{
            //    v.SizeType = SizeType.Absolute;
            //    v.Height = 30;
            //}

            int rowHeight = 30;
            int labelWidth = 190;
            int layoutWidth = 240;
            TableLayoutPanelOutput.RowCount = StaticParam.OutputArray.Length;
            TableLayoutPanelOutput.Height = TableLayoutPanelOutput.RowCount * rowHeight;
            TableLayoutPanelOutput.Width = layoutWidth;

            arrayControlOutput = new Control[StaticParam.OutputArray.Length * 2];

            for (int i = 0; i < StaticParam.OutputArray.Length; i++)
            {
                DrvIO.tyIO_Parameter parameter = new DrvIO.tyIO_Parameter();
                StaticParam.OutputArray[i].GetParameter(ref parameter);
                arrayControlOutput[i] = new UILedBulb
                {
                    Color = Color.DarkGray
                };
                arrayControlOutput[i + 1] = new UILabel
                {
                    Text = parameter.strID + " " + parameter.strCName.Trim(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(labelWidth, rowHeight)
                };
            }

            TableLayoutPanelOutput.Controls.AddRange(arrayControlOutput);

            foreach (RowStyle v in TableLayoutPanelOutput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = rowHeight;
            }
        }

        private void LoadRunnerInputSignal()
        {
            int rowHeight = 20;
            int labelWidth = 190;
            int layoutWidth = 240;
            TableLayoutPanelRunnerInput1.RowCount = StaticParam.R_InputArray.Length;
            TableLayoutPanelRunnerInput1.Height = TableLayoutPanelRunnerInput1.RowCount * rowHeight;
            TableLayoutPanelRunnerInput1.Width = layoutWidth;

            arrayControlRunnerInput = new Control[StaticParam.R_InputArray.Length * 2];

            for (int i = 0; i < StaticParam.R_InputArray.Length; i++)
            {
                DrvIO.tyIO_Parameter parameter = new DrvIO.tyIO_Parameter();
                StaticParam.R_InputArray[i].GetParameter(ref parameter);
                arrayControlRunnerInput[i] = new UILedBulb
                {
                    Color = Color.DarkGray
                };
                arrayControlRunnerInput[i + 1] = new UILabel
                {
                    Text = parameter.strID + " " + parameter.strCName.Trim(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(labelWidth, rowHeight)
                };
            }

            TableLayoutPanelRunnerInput1.Controls.AddRange(arrayControlRunnerInput);

            foreach (RowStyle v in TableLayoutPanelRunnerInput1.RowStyles)
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
            TableLayoutPanelRunnerOutput.RowCount = StaticParam.R_OutputArray.Length;
            TableLayoutPanelRunnerOutput.Height = TableLayoutPanelRunnerOutput.RowCount * rowHeight;
            TableLayoutPanelRunnerOutput.Width = layoutWidth;

            var arrayRunnerOutput = new Control[StaticParam.R_OutputArray.Length * 2];
            for (int i = 0; i < StaticParam.R_OutputArray.Length; i++)
            {
                DrvIO.tyIO_Parameter param = new DrvIO.tyIO_Parameter(); 
                StaticParam.R_OutputArray[i].GetParameter(ref param);
                arrayRunnerOutput[i] = new UILedBulb
                {
                    Color = Color.DarkGray
                };
                arrayRunnerOutput[i + 1] = new UILabel
                {
                    Text = param.strID + " " + param.strCName.Trim(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(labelWidth, rowHeight)
                };
                arrayRunnerOutput[i + 1].Click += (sender, e) =>
                {
                    var label = sender as UILabel;
                    foreach (DrvIO io in StaticParam.R_OutputArray)
                    {
                        //DrvIO.tyIO_Parameter parameter = new DrvIO.tyIO_Parameter();
                        //StaticParam.R_OutputArray[i].GetParameter(ref parameter);
                        if (label.Text == param.strID + " " + param.strCName.Trim())
                        {
                            io.SetIO(!io.GetValue());
                            break;
                        }
                    }
                };
            }

            TableLayoutPanelRunnerOutput.Controls.AddRange(arrayRunnerOutput);

            foreach (RowStyle v in TableLayoutPanelRunnerOutput.RowStyles)
            {
                v.SizeType = SizeType.Absolute;
                v.Height = rowHeight;
            }
        }

        private void TimerFlash_Tick(object sender, EventArgs e)
        {
            TextBoxCurLocationZ.Text = StaticParam.AxisZ.GetPosition().ToString();
            TextBoxCurLocationR.Text = StaticParam.AxisR.GetPosition().ToString();
            for (int i = 0; i < StaticParam.R_InputArray.Length; i++)
            {
                arrayControlRunnerInput[i].BackColor = StaticParam.R_InputArray[i].GetValue() ? Color.Lime : Color.DarkGray;
            }
            for (int i = 0; i < StaticParam.R_OutputArray.Length; i++)
            {
                arrayControlRunnerOutput[i].BackColor = StaticParam.R_OutputArray[i].GetValue() ? Color.Lime : Color.DarkGray;
            }
        }

        private void ButtonSevOnZ_Click(object sender, EventArgs e)
        {
            if (StaticParam.AxisZ.isSevOn())
            {
                if (StaticParam.AxisZ.SetSevON(false))
                {
                    ButtonSevOnZ.Text = "开使能";
                    ButtonSevOnZ.FillColor = Color.FromArgb(80, 160, 255);
                }
            }
            else
            {
                if (StaticParam.AxisZ.SetSevON(true))
                {
                    ButtonSevOnZ.Text = "关使能";
                    ButtonSevOnZ.FillColor = Color.Green;
                }
            }
        }

        private void ButtonReversionZ_Click(object sender, EventArgs e)
        {
            StaticParam.AxisZ.DoHome();
        }

        private void ButtonStopZ_Click(object sender, EventArgs e)
        {
            StaticParam.AxisZ.Stop();
        }

        private void ImageButtonDistancePlusZ_Click(object sender, EventArgs e)
        {
            if (StaticParam.AxisZ.isSevOn())
            {
                StaticParam.AxisZ.RevMove(Convert.ToDouble(ComboBoxDistanceZ.SelectedItem), Convert.ToDouble(TextBoxSpeedZ.Text));
            }
        }

        private void ImageButtonDistanceReduceZ_Click(object sender, EventArgs e)
        {
            if (StaticParam.AxisZ.isSevOn())
            {
                StaticParam.AxisZ.RevMove(-Convert.ToDouble(ComboBoxDistanceZ.SelectedItem), Convert.ToDouble(TextBoxSpeedZ.Text));
            }
        }
    }
}
