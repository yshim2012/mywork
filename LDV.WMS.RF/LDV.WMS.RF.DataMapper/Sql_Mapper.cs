
#region using
using System.IO;
using System.Reflection;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
#endregion

namespace LDV.WMS.RF.DataMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class Sql_Mapper
    {
        private static volatile ISqlMapper _mapper = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected static void Configure(object obj)
        {
            _mapper = null;
        }

        /// <summary>
        /// 
        /// </summary>
        protected static void InitMapper()
        {
            Assembly assembly = Assembly.Load("LDV.WMS.RF.DataMapper");
            Stream stream = assembly.GetManifestResourceStream("LDV.WMS.RF.DataMapper.SqlMap.config");

            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.Configure(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISqlMapper Instance()
        {
            if (_mapper == null)
            {
                lock (typeof(Sql_Mapper))
                {
                    if (_mapper == null) // double-check
                    {
                        InitMapper();
                    }
                }
            }
            return _mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ISqlMapper Get()
        {
            return Instance();
        }
    }
}