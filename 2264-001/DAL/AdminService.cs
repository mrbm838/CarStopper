using BYD2181;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminService
    {
        /// <summary>
        /// 根据所输入的账户和密码登录
        /// </summary>
        /// <param name="objAccount">账户信息</param>
        /// <returns>正确的账户信息，否则为空</returns>
        /// <exception cref="Exception">连接异常</exception>
        public Account AdminLogin(Account objAccount)
        {
            try
            {
                bool result = DBInit.db.Queryable<Account>().Where(it => it.User == objAccount.User && it.Pwd == objAccount.Pwd).ToList().Any();
                if (result)
                {
                    return objAccount;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw new Exception("应用程序和数据库的连接出现问题！");
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="objAccount">账户信息</param>
        /// <param name="newPwd">新密码</param>
        /// <exception cref="Exception"></exception>
        public int ModifyPwd(Account objAccount, string newPwd)
        {
            int i = 0;
            try
            {
                i = DBInit.db.Updateable<Account>().SetColumns(it => it.Pwd == newPwd).Where(it => it.User == objAccount.User).ExecuteCommand();
            }
            catch (Exception e)
            {

                throw new Exception("应用程序和数据库的连接出现问题！");
            }
            return i;
        }


        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="user">用户名</param>
        /// <returns>结果</returns>
        /// <exception cref="Exception"></exception>
        public bool QueryUser(string user)
        {
            bool b_result = false;
            try
            {
                b_result = DBInit.db.Queryable<Account>().Where(it => it.User == user).Any();
            }
            catch (Exception e)
            {
                throw new Exception("应用程序和数据库的连接出现问题！");
            }
            return b_result;
        }

    }
}
