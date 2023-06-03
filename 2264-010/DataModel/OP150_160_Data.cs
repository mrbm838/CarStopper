using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class OP150_160_Data
    {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 产品SN
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 扭力1
        /// </summary>
        public double Torque1 { get; set; }
        /// <summary>
        /// 扭力2
        /// </summary>
        public double Torque2 { get; set; }
        /// <summary>
        /// 牛力
        /// </summary>
        public double Torque3 { get; set; }
        /// <summary>
        /// 扭力4
        /// </summary>
        public double Torque4 { get; set; }
        /// <summary>
        /// 扭力5
        /// </summary>
        public double Torque5 { get; set; }
        /// <summary>
        /// 扭力5
        /// </summary>
        public double Torque6 { get; set; }
        /// <summary>
        /// 角度1
        /// </summary>
        public double Angle1 { get; set; }
        /// <summary>
        /// 角度2
        /// </summary>
        public double Angle2 { get; set; }
        /// <summary>
        /// 角度3
        /// </summary>
        public double Angle3 { get; set; }
        /// <summary>
        /// 角度4
        /// </summary>
        public double Angle4 { get; set; }
        /// <summary>
        /// 角度5
        /// </summary>
        public double Angle5 { get; set; }
        /// <summary>
        /// 角度6
        /// </summary>
        public double Angle6 { get; set; }
    }
}
