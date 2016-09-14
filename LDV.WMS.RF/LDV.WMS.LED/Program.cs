using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LDV.WMS.LED
{
    class Program
    {

        private static System.Timers.Timer timer = new System.Timers.Timer();
        private static bool Flag = false;
        private static string Interval = ConfigurationManager.AppSettings["Interval"].ToString();//轮询时间
        private static string maxPage = ConfigurationManager.AppSettings["maxPage"].ToString();
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                timer.Interval = GetTimerInterval();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
                Execute();
                timer.Start();
                while (true)
                {
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void Run()
        {
            while (true)
            {
                Execute();
            }
        }
      

        /// <summary>
        /// 执行
        /// </summary>
        private static void Execute()
        {
            if (Flag == false)
            {
                Flag = true;

                MainClass m = new MainClass();

                Console.WriteLine("开始执行：" + System.DateTime.Now.ToString() + " begin");
                RunTimeLogger.Debug("开始执行：" + System.DateTime.Now.ToString() + " begin\r\n");
                if (MainClass.Page.ToString() == maxPage)
                {
                    MainClass.Page = 1;
                }
                m.RunExc();
                MainClass.Page++;
                Console.WriteLine("执行结束：" + System.DateTime.Now.ToString() + " end\n\n");
                RunTimeLogger.Debug("执行结束：" + System.DateTime.Now.ToString() + " begin\r\n");
                Flag = false;
            }
        }

        private static int GetTimerInterval()
        {
            return 1000 * int.Parse(Interval);
        }

        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Execute();
        }
    }
}
