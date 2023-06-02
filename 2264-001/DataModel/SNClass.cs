using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class SNClass
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity =true)]
        /// <summary>
        /// 行号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string DateTime { get; set; }
        /// <summary>
        /// SN条码
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 1号站位是否过站
        /// </summary>
        public bool Station1 { get; set; } = false;
        /// <summary>
        /// 2号站位是否过站
        /// </summary>
        public bool Station2 { get; set; } = false;
        /// <summary>
        /// 3号站位是否过站
        /// </summary>
        public bool Station3 { get; set; } = false;
        /// <summary>
        /// 4号站位是否过站
        /// </summary>
        public bool Station4 { get; set; } = false;
    }
}
