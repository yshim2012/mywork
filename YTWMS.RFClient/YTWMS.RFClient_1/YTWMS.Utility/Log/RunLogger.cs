using System;

namespace JJMC.Utility
{
    public static class RunLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("RunLogger");

        /// <summary>
        /// ��Ϣ��־
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            if(log.IsInfoEnabled) log.Info(message);
        }

        /// <summary>
        /// Debug��־
        /// </summary>
        /// <param name="msg"></param>
		public static void Debug(string msg)
		{
			if (log.IsDebugEnabled) log.Debug(msg);
		}

        /// <summary>
        /// Error��־
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Error(string msg,Exception e)
		{
			if (log.IsErrorEnabled) log.Error(msg,e);
		}

        /// <summary>
        /// Warn��־
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Warn(string msg,Exception e)
		{
			if (log.IsWarnEnabled) log.Warn(msg,e);
		}

        /// <summary>
        /// Fatal��־
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
		public static void Fatal(string msg,Exception e)
		{
			if (log.IsFatalEnabled) log.Fatal(msg,e);
		}
    }
}
