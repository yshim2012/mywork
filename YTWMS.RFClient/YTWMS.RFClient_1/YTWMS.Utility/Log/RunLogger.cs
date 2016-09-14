using System;

namespace JJMC.Utility
{
    public static class RunLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("RunLogger");

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if(log.IsInfoEnabled) log.Info(message);
        }

        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="msg"></param>
		public static void Debug(string msg)
		{
			if (log.IsDebugEnabled) log.Debug(msg);
		}

        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Error(string msg,Exception e)
		{
			if (log.IsErrorEnabled) log.Error(msg,e);
		}

        /// <summary>
        /// Warn日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Warn(string msg,Exception e)
		{
			if (log.IsWarnEnabled) log.Warn(msg,e);
		}

        /// <summary>
        /// Fatal日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Fatal(string msg,Exception e)
		{
			if (log.IsFatalEnabled) log.Fatal(msg,e);
		}
    }
}
