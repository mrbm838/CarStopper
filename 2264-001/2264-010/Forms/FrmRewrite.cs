using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BYD2181;
using DAL;
using DataModel;
using Google.Protobuf.Collections;
using ReadAndWriteConfigSystem;
using Sunny.UI;

namespace OP010
{
    public partial class FrmRewrite : UIPage
    {

        LogClass myLog;


        List<string> listStation1;
        List<string> listStation2;
        List<string> listStation3;
        List<OP150_160_Data> listData;
        List<OP170Data> listData2;
        List<GaoDiData> listData3;

        public FrmRewrite(LogClass log)
        {
            InitializeComponent();
            listStation1 = new List<string>();
            listStation2 = new List<string>();
            listStation3 = new List<string>();
            listData = new List<OP150_160_Data>();
            listData2 = new List<OP170Data>();
            listData3 = new List<GaoDiData>();
            myLog = log;
        }


        /// <summary>
        /// 获取配置文件中未成功写入数据库的数据并显示在表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Get_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
                listStation2 = ConfigHelperSystem.GetAllKey("写数据库失败SN及数据");
                for (int i = 0; i < listStation2.Count; i++)
                {
                    OP170Data oP170 = new OP170Data()
                    {
                        SN = (listStation2[i].Split('_'))[1].ToString(),
                        Time = ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "Time"),
                        P1 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P1")),
                        P2 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P2")),
                        P3 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P3")),
                        P4 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P4")),
                        P5 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P5")),
                        P6 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P6")),
                        P7 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P7")),
                        P8 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P8")),
                        P9 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P9")),
                        P10 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P10")),
                        P11 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P11")),
                        P12 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P12")),
                        P13 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P13")),
                        P14 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P14")),
                        P15 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P15")),
                        P16 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P16")),
                        P17 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P17")),
                        P18 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P18")),
                        P19 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P19")),
                        P20 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P20")),
                        P21 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P21")),
                        P22 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P22")),
                        P23 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P23")),
                        P24 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P24")),
                        P25 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P25")),
                        P26 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P26")),
                        P27 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P27")),
                        P28 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P28")),
                        P29 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P29")),
                        P30 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P30")),
                        P31 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P31")),
                        P32 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P32")),
                        P33 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P33")),
                        P34 = Convert.ToDouble(ConfigHelperSystem.GetAppConfig("写数据库失败SN及数据", listStation2[i], "P34")),
                    };
                    listData2.Add(oP170);
                }
                listStation2.Clear();
                UpdateDatagridview(dataGridView2, listData2);
            });

        }


        /// <summary>
        /// 将配置文件里的数据再次写入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WriteAll_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                List<int> listOk = new List<int>();
                for (int i = 0; i < listData.Count; i++)
                {
                    int k = new OP150Service().InsertData(listData[i]);
                    if (k > 0)
                    {
                        LogClass.AddMsg(0, $"{listData[i].SN}： 手动写入数据库成功！");
                        listOk.Add(i);
                        ConfigHelperSystem.DeleteConfig("写数据库失败SN及数据", "SN_" + listData[i].SN);
                    }
                }
                if (listOk.Count == listData.Count)
                {
                    listData.Clear();
                }
                else
                {
                    foreach (int item in listOk)
                    {
                        listData.RemoveAt(item);
                    }
                    //listData.RemoveRange(0, listOk.Count);

                }
                UpdateDatagridview(dataGridView1, listData);
            }));
            Task.Run(new Action(() =>
            {
                List<int> listOk2 = new List<int>();
                for (int i = 0; i < listData2.Count; i++)
                {
                    int k = new OP170DataService().InsertData(listData2[i]);
                    if (k > 0)
                    {
                        LogClass.AddMsg(0, $"{listData2[i].SN}： 手动写入数据库成功！");
                        listOk2.Add(i);
                        ConfigHelperSystem.DeleteConfig("写数据库失败SN及数据", "SN_" + listData2[i].SN);
                    }
                }
                if (listOk2.Count == listData2.Count)
                {
                    listData2.Clear();
                }
                else
                {
                    foreach (int item in listOk2)
                    {
                        listData2.RemoveAt(item);
                    }
                    //listData2.RemoveRange(0, listOk2.Count);

                }
                UpdateDatagridview(dataGridView2, listData2);
            }));
            Task.Run(new Action(() =>
            {
                List<int> listOk3 = new List<int>();
                for (int i = 0; i < listData3.Count; i++)
                {
                    int k = new GaoDiService().InsertData(listData3[i]);
                    if (k > 0)
                    {
                        LogClass.AddMsg(0, $"{listData3[i].SN}： 手动写入数据库成功！");
                        listOk3.Add(i);
                        ConfigHelperSystem.DeleteConfig("写数据库失败SN及数据", "SN_" + listData3[i].SN);
                    }
                }
                if (listOk3.Count == listData3.Count)
                {
                    listData3.Clear();
                }
                else
                {
                    foreach (int item in listOk3)
                    {
                        listData3.RemoveAt(item);
                    }
                    //listData2.RemoveRange(0, listOk2.Count);

                }
                UpdateDatagridview(dataGridView3, listData3);
            }));
        }


        #region 插入表格数据

        /// <summary>
        /// 向表格中写入数据
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="obj">数据集合</param>
        public void UpdateDatagridview(DataGridView gridView, List<OP150_160_Data> obj)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (obj == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item in obj[i].GetType().GetProperties())
                    {
                        string s = item.Name.ToString();
                        if (s.Contains("ID"))
                        {
                            continue;
                        }
                        if (dt.Columns.Contains(s))
                        {

                        }
                        else
                        {
                            dt.Columns.Add(s);
                        }
                        //通过反射来获取属性的值
                        object value = item.GetValue(obj[i], null);
                        dr[s] = value;
                    }
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                if (gridView.InvokeRequired)
                {
                    gridView.BeginInvoke(new Action(() =>
                    {
                        gridView.ColumnHeadersVisible = true;
                        //滚动条形式
                        gridView.ScrollBars = ScrollBars.Horizontal;
                        //自适应列宽
                        gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        gridView.DataSource = ds.Tables[0];
                    }));
                }
                else
                {
                    gridView.ColumnHeadersVisible = true;
                    //滚动条形式
                    gridView.ScrollBars = ScrollBars.Horizontal;
                    //自适应列宽
                    gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gridView.DataSource = ds.Tables[0];
                }

            }

        }

        /// <summary>
        /// 向表格中写入数据
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="obj">数据集合</param>
        public void UpdateDatagridview(DataGridView gridView, List<OP170Data> obj)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (obj == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item in obj[i].GetType().GetProperties())
                    {
                        string s = item.Name.ToString();
                        if (s.Contains("ID"))
                        {
                            continue;
                        }
                        if (dt.Columns.Contains(s))
                        {

                        }
                        else
                        {
                            dt.Columns.Add(s);
                        }
                        //通过反射来获取属性的值
                        object value = item.GetValue(obj[i], null);
                        dr[s] = value;
                    }
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                if (gridView.InvokeRequired)
                {
                    gridView.BeginInvoke(new Action(() =>
                    {
                        gridView.ColumnHeadersVisible = true;
                        //滚动条形式
                        gridView.ScrollBars = ScrollBars.Horizontal;
                        //自适应列宽
                        gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        gridView.DataSource = ds.Tables[0];
                    }));
                }
                else
                {
                    gridView.ColumnHeadersVisible = true;
                    //滚动条形式
                    gridView.ScrollBars = ScrollBars.Horizontal;
                    //自适应列宽
                    gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gridView.DataSource = ds.Tables[0];
                }

            }

        }




        /// <summary>
        /// 向表格中写入数据
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="obj">数据集合</param>
        public void UpdateDatagridview(DataGridView gridView, List<GaoDiData> obj)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (obj == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item in obj[i].GetType().GetProperties())
                    {
                        string s = item.Name.ToString();
                        if (s.Contains("ID"))
                        {
                            continue;
                        }
                        if (dt.Columns.Contains(s))
                        {

                        }
                        else
                        {
                            dt.Columns.Add(s);
                        }
                        //通过反射来获取属性的值
                        object value = item.GetValue(obj[i], null);
                        dr[s] = value;
                    }
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
                if (gridView.InvokeRequired)
                {
                    gridView.BeginInvoke(new Action(() =>
                    {
                        gridView.ColumnHeadersVisible = true;
                        //滚动条形式
                        gridView.ScrollBars = ScrollBars.Horizontal;
                        //自适应列宽
                        gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        gridView.DataSource = ds.Tables[0];
                    }));
                }
                else
                {
                    gridView.ColumnHeadersVisible = true;
                    //滚动条形式
                    gridView.ScrollBars = ScrollBars.Horizontal;
                    //自适应列宽
                    gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gridView.DataSource = ds.Tables[0];
                }

            }

        }

        #endregion

    }
}
