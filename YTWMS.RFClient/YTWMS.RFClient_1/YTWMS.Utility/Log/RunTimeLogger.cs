using System;
using System.Reflection;
using log4net;
using log4net.DBCustom;

namespace Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class RunTimeLogger
    {
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// д����ʱ����־
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
