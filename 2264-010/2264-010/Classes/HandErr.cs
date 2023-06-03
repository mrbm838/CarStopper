using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP010
{
    public class HandErr
    {
        public ErrorInfo GetError(string errorCode)
        {
            ErrorInfo err = null;
            if (StaticParam.errorInfos.Count <= 0)
            {
                return null;
            }
            for (int i = 0; i < StaticParam.errorInfos.Count; i++)
            {
                if (StaticParam.errorInfos[i].ErrorCode == errorCode)
                {
                    err = StaticParam.errorInfos[i];
                }
            }
            return err;
        }
    }
}
