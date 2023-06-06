using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OP001
{
    public delegate void DelShow(object sender, EventArgs e);
    public delegate void DelHideForm();
    public delegate string DelGetTrueAddress(string type, int i, int adress);
    public delegate void DelFlashCode(string code);
    public delegate void DelTextBox();
    public delegate void DelStart();
    public delegate void DelChart(List<DataPoint> points);
    public delegate void DelDatagridView(object obj);
    public delegate void DelClearDgv();
    public delegate void DelDgv(List<double> list, Dictionary<string, bool> pairs);
    public delegate void DelLabel(Dictionary<string, bool> pairs);
}
