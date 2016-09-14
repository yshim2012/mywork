using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJMC.Utility
{
    public class MyLogger
    {
        public static void Info(string mess)
        {
            try
            {
                OpTxtFile txt = new OpTxtFile();
                if (!txt.IsFileExist(System.IO.Directory.GetCurrentDirectory() + "\\Log", DateTime.Now.ToString("yyyyMMdd") + ".log"))
                    txt.DeleteALLFile(System.IO.Directory.GetCurrentDirectory() + "\\Log");

                string InfoMess = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + mess;
                txt.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\Log", DateTime.Now.ToString("yyyyMMdd") + ".log", InfoMess);
            }
            catch (Exception)
            { }
        }
        public static void InfoBack(string mess)
        {
            try
            {
                OpTxtFile txt = new OpTxtFile();
                if (!txt.IsFileExist(System.IO.Directory.GetCurrentDirectory() + "\\Log", DateTime.Now.ToString("yyyyMMdd") + ".log"))
                    txt.DeleteFile(System.IO.Directory.GetCurrentDirectory() + "\\Log" + DateTime.Now.AddDays(-2).ToString("yyyyMMdd") + ".log");

                string InfoMess = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + mess;
                txt.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\Log", DateTime.Now.ToString("yyyyMMdd") + ".log", InfoMess);
            }
            catch (Exception)
            { }
        }

        public static void CreatAndPrintPdfLog(string Mess)
        {
            try
            {
                OpTxtFile txt = new OpTxtFile();
                if (!txt.IsFileExist(System.IO.Directory.GetCurrentDirectory() + "\\PDFLog", DateTime.Now.ToString("yyyyMMdd") + ".log"))
                    txt.DeleteFile(System.IO.Directory.GetCurrentDirectory() + "\\PDFLog" + DateTime.Now.AddDays(-2).ToString("yyyyMMdd") + ".log");

                string InfoMess = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + Mess;
                txt.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\PDFLog", DateTime.Now.ToString("yyyyMMdd") + ".log", InfoMess);
            }
            catch (Exception)
            { }
        }
    }
}
