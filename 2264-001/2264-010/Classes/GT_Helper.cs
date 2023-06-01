using cowain.FlowWork;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadAndWriteConfigSystem;

namespace OP010
{
    public class GT_Helper
    {
        public List<double> listMin;
        public List<double> listMax;

        public int NGCount = 0;

        public GT_Helper()
        {
            listMin = new List<double>();
            listMax = new List<double>();
            InitRange();
        }

        /// <summary>
        /// 初始化点位的范围
        /// </summary>
        public void InitRange()
        {
            Dictionary<string, string> dicMax = ConfigHelperSystem.GetAllKeyAndValue("LimitMax");
            Dictionary<string, string> dicMin = ConfigHelperSystem.GetAllKeyAndValue("LimitMin");
            string[] valuesMax = dicMax.Values.ToArray();
            string[] valuesMin = dicMin.Values.ToArray();
            for (int i = 0; i < valuesMax.Length; i++)
            {
                listMax.Add(Convert.ToDouble(valuesMax[i]));
            }
            for (int i = 0; i < valuesMin.Length; i++)
            {
                listMin.Add(Convert.ToDouble(valuesMin[i]));
            }

        }

        /// <summary>
        /// 获取点位集合
        /// </summary>
        /// <param name="str">经过ASCII解析后的数据字符</param>
        /// <returns>点位集合</returns>
        public List<double> GetPointsValue(string str)
        {
            List<double> pointList = new List<double>();
            string[] pointStr = str.Trim().Split(',');
            if (pointStr[0] != "ER")//无错
            {
                for (int i = 1; i < pointStr.Length; i++)
                {
                    pointList.Add(Convert.ToDouble(pointStr[i]) / 1000);
                }
            }
            else
            {
                pointList = null;
            }

            return pointList;
        }

        /// <summary>
        /// 获取值和结果（是否超限）
        /// </summary>
        /// <param name="str">数据字符串</param>
        /// <returns>点结果和状态</returns>
        /// 上下限需手动在放大器上设置
        public Dictionary<double, bool> GetPointsAndStatus(string str)
        {
            Dictionary<double, bool> point = new Dictionary<double, bool>();
            double value = 0;
            string[] pointStr = str.Trim().Split(',');
            if (pointStr[0] != "ER")
            {
                for (int i = 1; i < pointStr.Length - 1; i += 2)
                {
                    value = Convert.ToDouble(pointStr[i + 1]);
                    if (pointStr[i] == "04")//OK
                    {
                        point.Add(value, true);
                    }
                    else //超限
                    {
                        point.Add(value, false);
                    }
                }
            }
            return point;
        }


        /// <summary>
        /// 判断点位结果
        /// </summary>
        /// <param name="list">总的点位集合</param>
        /// <returns>点位，结果</returns>
        public Dictionary<string, bool> JudgeResult(List<double> list)
        {
            NGCount = 0;
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= listMin[i] && list[i] <= listMax[i])
                {
                    result.Add(i.ToString(), true);
                }
                else
                {
                    result.Add(i.ToString(), false);
                    NGCount++;
                }
            }
            return result;
        }

        /// <summary>
        /// 创建数据对象
        /// </summary>
        /// <param name="sn">SN条码</param>
        /// <param name="list">点信息集合</param>
        /// <returns></returns>
        public OP170Data SetData(string sn, List<double> list)
        {
            OP170Data data = new OP170Data()
            {
                SN = sn,
                Time = DateTime.Now.ToString(),
                P1 = list[0],
                P2 = list[1],
                P3 = list[2],
                P4 = list[3],
                P5 = list[4],
                P6 = list[5],
                P7 = list[6],
                P8 = list[7],
                P9 = list[8],
                P10 = list[9],
                P11 = list[10],
                P12 = list[11],
                P13 = list[12],
                P14 = list[13],
                P15 = list[14],
                P16 = list[15],
                P17 = list[16],
                P18 = list[17],
                P19 = list[18],
                P20 = list[19],
                P21 = list[20],
                P22 = list[21],
                P23 = list[22],
                P24 = list[23],
                P25 = list[24],
                P26 = list[25],
                P27 = list[26],
                P28 = list[27],
                P29 = list[28],
                P30 = list[29],
                P31 = list[30],
                P32 = list[31],
                P33 = list[32],
                P34 = list[33]
            };
            return data;
        }
    }
}
