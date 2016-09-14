using System;
using System.Xml;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;

namespace LDV.WMS.LED
{
    public class CC
    {
        private static CC _Singleton = null;
        public static CC Singleton()
        {
            if (_Singleton == null)
            {
                _Singleton = new CC();
            }
            return _Singleton;
        }

        public string execeutePath
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string filePath = Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName;
                return filePath.Substring(0, filePath.LastIndexOf("\\"));
            }
        }

        public string configFile
        {
            get
            {
                return execeutePath + "\\files.config.xml";
            }
        }

        

        public string CurrentVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyName name = assembly.GetName();
                Version version = name.Version;
                return version.ToString();
            }
        }

        public string ServiceUrl
        {
            get
            {
                XmlDocument config = new XmlDocument();
                //config.Load(configFile);
                string serverURL = ConfigurationManager.AppSettings["serverURL"].ToString();
                string URL = "http://{0}/LdvRfWebService.asmx";
               // string IP = config.GetElementsByTagName("serverURL")[0].InnerText;
                return String.Format(URL, serverURL);
            }
            set
            {
              //  XmlDocument config = new XmlDocument();
                //config.Load(configFile);
               // config.GetElementsByTagName("serverURL")[0].InnerText = value;
              //  config.Save(configFile);
            }
        }

        private string interval;
        public string Interval
        {
            get
            {
                XmlDocument config = new XmlDocument();
                config.Load(configFile);
                return config.GetElementsByTagName("Interval")[0].InnerText;
            }
            set
            {
                XmlDocument config = new XmlDocument();
                config.Load(configFile);
                config.GetElementsByTagName("Interval")[0].InnerText = value;
                config.Save(configFile);

                interval = value;
            }
        }

        private ReportService reportService;
        public ReportService service()
        {
            reportService = new ReportService(ServiceUrl);
            return reportService;
        }
    }
}
