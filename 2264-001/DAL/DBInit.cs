using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SqlSugar;
using BYD2181;
using DataModel;

namespace DAL
{
    public class DBInit
    {
        public static  SqlSugarClient db = null;
        /// <summary>
        /// 链接字符串
        /// </summary>
        public static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <returns>初始化结果</returns>
        /// 初始化数据库，不存在就创建数据库和表
        public static bool InitDB()
        {
            bool b_Connected = false;
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });
            try
            {
                b_Connected = true;
                db.Open();
                db.DbMaintenance.CreateDatabase();
                db.CodeFirst.InitTables(typeof(Account));
                db.CodeFirst.InitTables(typeof(OP150_160_Data));
                db.CodeFirst.InitTables(typeof(OP170Data));
                db.CodeFirst.InitTables(typeof(SNClass));
                db.CodeFirst.InitTables(typeof(GaoDiData));
            }
            catch (Exception)
            {
                b_Connected = false;
            }
            return b_Connected;
        }
    }
}
