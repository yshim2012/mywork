using System;
using System.Collections;

namespace Common
{
    /// <summary>
    /// 动态查询参数集合类
    /// </summary>
    public sealed class SqlParamSet
    {
        private IDictionary paramHashtable;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlParamSet()
        {
            paramHashtable = new Hashtable();
        }

        /// <summary>
        /// 添加查询参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        public void AddParam(string paramName, string paramValue)
        {
            if (paramValue == string.Empty)
                return;
            paramHashtable.Add(paramName, paramValue);
        }

        /// <summary>
        /// 添加查询参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        public void AddParam(string paramName, object paramValue)
        {
            if (paramValue is string && paramValue as string == string.Empty)
                return;
            paramHashtable.Add(paramName, paramValue);
        }

        /// <summary>
        /// 获得查询参数集合
        /// </summary>
        /// <returns></returns>
        public IDictionary GetParams()
        {
            return paramHashtable;
        }

        public void AddParam()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
