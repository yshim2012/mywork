using System;
using System.Reflection;
using log4net;
using log4net.DBCustom;

namespace Utility
{
    /// <summary>
    /// 用户操作数据库日志
    /// </summary>
    public static class OperationLogger
    {
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 写数据库日志
        /// </summary>
        /// <param name="logMessage"></param>
        public static void WriteLogMessage(LogMessage logMessage)
        {
            log.Info(logMessage);
        }
    }
}
