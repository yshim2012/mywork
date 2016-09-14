using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Launcher.UCWebService;

namespace Launcher
{
    public class ReportService
    {
        private string serverUrl;

        public ReportService(string serverUrl)
        {
            this.serverUrl = serverUrl;
        }

        private Service1 service()
        {
            Service1 handler = new Service1();
            if (!string.IsNullOrEmpty(serverUrl))
                handler.Url = serverUrl;

            return handler;
        }

        //得到版本
        public string GetServiceVersion()
        {
            return service().GetVersion();
        }

        //得到文件名
        public string[] GetFileNames()
        {
           string[] fns = service().GetAllFiles();
            return fns;
        }

        //下载文件
        public byte[] dowloadFile(string filename)
        {
            return service().DowLoadFile(filename);
        }
    }
}
