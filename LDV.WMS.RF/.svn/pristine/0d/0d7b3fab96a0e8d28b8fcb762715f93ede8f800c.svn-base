using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using IBatisNet.Common;
using IBatisNet.DataMapper;
using LDV.WMS.RF.DataMapper;
namespace LDV.WMS.RF.Business
{
    /// <summary>
    /// 取数据库时间类
    /// 为了统一系统时间，系统时间一律以数据库时间为准，
    /// 不要以应用服务器时间
    /// </summary>
    public static class DBDateTimeGenerator
    {
        private static readonly string queryDBDateTime =
            "select systimestamp as cdate from dual";

        /// <summary>
        /// 得到数据库服务器时间，数据库连接内部打开
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDBDateTime()
        {
            ISqlMapper sqlMapper = Sql_Mapper.Instance();
            using (IDalSession session = sqlMapper.OpenConnection())
            {
                DataSet dataSet = sqlMapper.ExecuteSqlWithQueryDataSet(queryDBDateTime, "DBDateTime");
                return (DateTime)dataSet.Tables["DBDateTime"].Rows[0]["cdate"];
            }
        }

        /// <summary>
        /// 得到数据库服务器时间，数据库连接外部打开
        /// </summary>
        /// <param name="sqlMapper">ISqlMapper对象</param>
        /// <returns></returns>
        public static DateTime GetDBDateTime(ISqlMapper sqlMapper)
        {
            DataSet dataSet = sqlMapper.ExecuteSqlWithQueryDataSet(queryDBDateTime, "DBDateTime");
            return (DateTime)dataSet.Tables["DBDateTime"].Rows[0]["cdate"];
        }

        /// <summary>
        /// 将日期转换为"03-12月-10 12.00.00.000000 上午"格式, 忽略秒。以便和TIMESTAMP类型的数据匹配
        /// </summary>
        /// <param name="dt">要转换的数据类型</param>
        /// <returns>返回，TIMESTAMP类型数据的字符串</returns>
        public static string ChangDateTime(DateTime dt)
        {
            string strdate = string.Empty;
            int y = dt.Year - 2000;
            strdate = dt.Day.ToString() + "-" + dt.Month.ToString() + "月-" + y.ToString() + " ";
            if (dt.Hour >= 12 || dt.Hour == 0)
            {
                if (dt.Hour == 0)
                {
                    strdate += "12." + dt.Minute.ToString() + ".0 上午";
                }
                else if (dt.Hour == 12)
                {
                    strdate += "12." + dt.Minute.ToString() + ".0 下午";
                }
                else
                {
                    int h = dt.Hour - 12;
                    strdate += h.ToString() + "." + dt.Minute.ToString() + ".0 下午";
                }
            }
            else
            {
                strdate += dt.Hour.ToString() + "." + dt.Minute.ToString() + ".0 上午";
            }

            return strdate;
        }

    }
}
