using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.DBCustom;

namespace LDV.WMS.LED
{
    public class RunTimeLogger
    {
        private static ILog log = LogManager.GetLogger("RunTimeLogger");

        /// <summary>
        /// 写运行时间日志
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
