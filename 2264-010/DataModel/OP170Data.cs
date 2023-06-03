using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class OP170Data
    {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        public string SN { get; set; }
        public double P1 { get; set; }
        public double P2 { get; set; }
        public double P3 { get; set; }
        public double P4 { get; set; }
        public double P5 { get; set; }
        public double P6 { get; set; }
        public double P7 { get; set; }
        public double P8 { get; set; }
        public double P9 { get; set; }
        public double P10 { get; set; }
        public double P11 { get; set; }
        public double P12 { get; set; }
        public double P13 { get; set; }
        public double P14 { get; set; }
        public double P15 { get; set; }
        public double P16 { get; set; }
        public double P17 { get; set; }
        public double P18 { get; set; }
        public double P19 { get; set; }
        public double P20 { get; set; }
        public double P21 { get; set; }
        public double P22 { get; set; }
        public double P23 { get; set; }
        public double P24 { get; set; }
        public double P25 { get; set; }
        public double P26 { get; set; }
        public double P27 { get; set; }
        public double P28 { get; set; }
        public double P29 { get; set; }
        public double P30 { get; set; }
        public double P31 { get; set; }
        public double P32 { get; set; }
        public double P33 { get; set; }
        public double P34 { get; set; }
    }
}
