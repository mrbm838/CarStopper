using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace OP010
{
    public class ChartService
    {
        public Chart Chart { get; set; }

        Series[] Series;

        public ChartService(Chart chart)
        {
            Chart = chart;
            InitChart();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitChart()
        {
            Series = new Series[Chart.Series.Count];
            for (int i = 0; i < Chart.Series.Count; i++)
            {
                Series[i] = Chart.Series[i];
                Series[i].Points.Clear();
            }
        }


        /// <summary>
        /// 曲线显示
        /// </summary>
        /// <param name="points"></param>
        /// <param name="name"></param>
        public void UpdateChart(List<DataPoint> points, string name)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Chart.Series[name].Points.Add(points[i]);
            }
        }


        /// <summary>
        /// 保存曲线图片
        /// </summary>
        /// <param name="path"></param>
        public void SaveImage(string path)
        {
            try
            {
                Chart.SaveImage(path, ChartImageFormat.Jpeg);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
