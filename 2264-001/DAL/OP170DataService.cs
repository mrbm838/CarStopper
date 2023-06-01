using BYD2181;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OP170DataService
    {
        /// <summary>
		/// 通过SN查询数据
		/// </summary>
		/// <param name="sn">SN条码</param>
		/// <returns></returns>
        public OP170Data QueryData(string sn)
        {
            try
            {
                bool result = DBInit.db.Queryable<OP170Data>().Where(it => it.SN == sn).ToList().Any();
                if (result)
                {
                    OP170Data datas = DBInit.db.Queryable<OP170Data>().Where(it => it.SN == sn).ToList()[0];
                    return datas;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw new Exception("应用程序和数据库的连接出现问题！");
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="datas">数据</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int InsertData(OP170Data datas)
        {
            int i;
            try
            {
                i = DBInit.db.Insertable(datas).ExecuteCommand();
            }
            catch (Exception)
            {

                throw new Exception("应用程序和数据库的连接出现问题！");
            }
            return i;
        }

        /// <summary>
        /// 根据sn删除对应的数据
        /// </summary>
        /// <param name="sn">SN条码</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int DelectData(string sn)
        {
            int i;
            try
            {
                i = DBInit.db.Deleteable<OP170Data>().Where(it => it.SN == sn).ExecuteCommand();
            }
            catch (Exception)
            {

                throw new Exception("应用程序和数据库的连接出现问题！");
            }
            return i;
        }


        /// <summary>
        /// 根据SN、列名更新数据
        /// </summary>
        /// <param name="sn">SN</param>
        /// <param name="columnName">列名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(string sn, string columnName, object value)
        {
            int i;

            try
            {
                i = DBInit.db.Updateable<OP170Data>().AS("OP170Data").SetColumns(columnName, value).Where($"SN={sn}").ExecuteCommand();

            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }
    }
}
