using BYD2181;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SNClassService
    {
		/// <summary>
		/// 通过SN查询数据
		/// </summary>
		/// <param name="sn">SN条码</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public SNClass QuerySN(string sn)
		{
			try
			{
				bool result = DBInit.db.Queryable<SNClass>().Where(it => it.SN == sn).ToList().Any();
				if (result)
				{
					SNClass sNClass = new SNClass();
					sNClass = DBInit.db.Queryable<SNClass>().Where(it => it.SN == sn).ToList()[0];
					return sNClass;
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
        /// 根据SN、列名更新数据
        /// </summary>
        /// <param name="sn">SN</param>
        /// <param name="columnName">列名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(string sn,string columnName,object value)
		{
			int i;

            try
			{
				i = DBInit.db.Updateable<SNClass>().AS("SNClass").SetColumns(columnName, value).Where($"SN={sn}").ExecuteCommand();

			}
			catch (Exception)
			{

				throw;
			}
			return i;
		}


		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name="objSNClass"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
        public int InsertSN(SNClass objSNClass)
        {
			int i;
			try
			{
				i = DBInit.db.Insertable(objSNClass).ExecuteCommand();
			}
			catch (Exception e)
			{

				throw new Exception("应用程序与数据库连接出现问题！");
			}
			return i;
        }

		/// <summary>
		/// 根据sn删除对应的数据
		/// </summary>
		/// <param name="objSNClass"></param>
		/// <returns></returns>
		public int DelectSN(string sn)
		{
			int i;
			try
			{
				i = DBInit.db.Deleteable<SNClass>().Where(it => it.SN == sn).ExecuteCommand();
			}
			catch (Exception e)
			{

				throw new Exception("应用程序和数据库的连接存在问题！");
			}
			return i;
		}
    }
}
