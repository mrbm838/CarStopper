using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BYD2181
{
    [Serializable]
    public class Account
    {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey =true,IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        [SugarColumn(IsNullable =false)]
        public string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(IsNullable =false)]
        public string Pwd { get; set; }
    }
}
