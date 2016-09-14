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
    /// ȡ���ݿ�ʱ����
    /// Ϊ��ͳһϵͳʱ�䣬ϵͳʱ��һ�������ݿ�ʱ��Ϊ׼��
    /// ��Ҫ��Ӧ�÷�����ʱ��
    /// </summary>
    public static class DBDateTimeGenerator
    {
        private static readonly string queryDBDateTime =
            "select systimestamp as cdate from dual";

        /// <summary>
        /// �õ����ݿ������ʱ�䣬���ݿ������ڲ���
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
        /// �õ����ݿ������ʱ�䣬���ݿ������ⲿ��
        /// </summary>
        /// <param name="sqlMapper">ISqlMapper����</param>
        /// <returns></returns>
        public static DateTime GetDBDateTime(ISqlMapper sqlMapper)
        {
            DataSet dataSet = sqlMapper.ExecuteSqlWithQueryDataSet(queryDBDateTime, "DBDateTime");
            return (DateTime)dataSet.Tables["DBDateTime"].Rows[0]["cdate"];
        }

        /// <summary>
        /// ������ת��Ϊ"03-12��-10 12.00.00.000000 ����"��ʽ, �����롣�Ա��TIMESTAMP���͵�����ƥ��
        /// </summary>
        /// <param name="dt">Ҫת������������</param>
        /// <returns>���أ�TIMESTAMP�������ݵ��ַ���</returns>
        public static string ChangDateTime(DateTime dt)
        {
            string strdate = string.Empty;
            int y = dt.Year - 2000;
            strdate = dt.Day.ToString() + "-" + dt.Month.ToString() + "��-" + y.ToString() + " ";
            if (dt.Hour >= 12 || dt.Hour == 0)
            {
                if (dt.Hour == 0)
                {
                    strdate += "12." + dt.Minute.ToString() + ".0 ����";
                }
                else if (dt.Hour == 12)
                {
                    strdate += "12." + dt.Minute.ToString() + ".0 ����";
                }
                else
                {
                    int h = dt.Hour - 12;
                    strdate += h.ToString() + "." + dt.Minute.ToString() + ".0 ����";
                }
            }
            else
            {
                strdate += dt.Hour.ToString() + "." + dt.Minute.ToString() + ".0 ����";
            }

            return strdate;
        }

    }
}
