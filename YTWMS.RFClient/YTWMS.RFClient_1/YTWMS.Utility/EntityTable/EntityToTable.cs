using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace JJMC.Utility
{
    /// <summary>
    /// 将实体转换成Table
    /// </summary>
    public class EntityToTable
    {
        public static DataTable CreateEmptyTable(Type type)
        {
            DataTable dt = new DataTable();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string t = pi.PropertyType.ToString();
                switch (t)
                {
                    case "System.Nullable`1[System.Double]":
                        {
                            DataColumn dc = new DataColumn(pi.Name, Type.GetType("System.Double"));
                            dt.Columns.Add(dc);
                        }
                        break;
                    case "System.Nullable`1[System.DateTime]":
                        {
                            DataColumn dc = new DataColumn(pi.Name, Type.GetType("System.DateTime"));
                            dt.Columns.Add(dc);
                        }
                        break;
                    default:
                        {
                            DataColumn dc = new DataColumn(pi.Name, pi.PropertyType);
                            dt.Columns.Add(dc);
                        }
                        break;
                }                
            }

            return dt;
        }
    }
}
