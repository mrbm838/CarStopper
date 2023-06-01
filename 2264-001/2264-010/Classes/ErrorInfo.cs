using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP010
{
    public class ErrorInfo
    {
        /// <summary>
        /// 报警代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 报警信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 解决方法
        /// </summary>
        public string Solution { get; set; }
    }
}
