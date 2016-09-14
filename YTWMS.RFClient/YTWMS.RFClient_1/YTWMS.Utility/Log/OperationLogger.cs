using System;
using System.Reflection;
using log4net;
using log4net.DBCustom;

namespace Utility
{
    /// <summary>
    /// �û��������ݿ���־
    /// </summary>
    public static class OperationLogger
    {
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// д���ݿ���־
        /// </summary>
        /// <param name="logMessage"></param>
        public static void WriteLogMessage(LogMessage logMessage)
        {
            log.Info(logMessage);
        }
    }
}
