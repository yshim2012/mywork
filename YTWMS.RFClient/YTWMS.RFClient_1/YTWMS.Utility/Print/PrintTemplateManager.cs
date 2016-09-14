using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;

namespace Utility
{
    public class PrintTemplateManager
    {
        private XmlDocument xmldoc;
        private static PrintTemplateManager templateManager;

        /// <summary>
        /// 
        /// </summary>
        private PrintTemplateManager()
        {
            LoadTemplate();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadTemplate()
        {
            xmldoc = new XmlDocument();
            string configfile = ConfigurationManager.AppSettings["ConfigFilesPath"] + "PrintTemplate.config";
            xmldoc.Load(configfile);
        }

        /// <summary>
        /// 单态方法，取得PrintTemplateManager的一个实例
        /// </summary>
        /// <returns>PrintTemplateManager对象的实例</returns>
        public static PrintTemplateManager GetInstance()
        {
            if (templateManager == null)
            {
                templateManager = new PrintTemplateManager();
            }
            return templateManager;
        }

        /// <summary>
        /// 根据打印服务名称找到对应的模版文件名称
        /// </summary>
        /// <param name="templateName">打印服务名称</param>
        /// <returns>模版文件名称</returns>
        public string GetTemplateFile( string templateName)
        {
            string xpath = "//Template[@Name='" + templateName + "']";
            XmlNode templateNode = xmldoc.SelectSingleNode(xpath);
            return templateNode.Attributes["File"].Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseCode"></param>
        /// <param name="manufacturerCode"></param>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public bool GetPackupSheetSingle( string templateName)
        {
            string xpath = "//Template[@Name='" + templateName + "']";
            XmlNode templateNode = xmldoc.SelectSingleNode(xpath);
            if (templateNode == null)
            {
                return false;
            }
            return true;
        }
    }
}
