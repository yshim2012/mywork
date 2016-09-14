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
        /// ��̬������ȡ��PrintTemplateManager��һ��ʵ��
        /// </summary>
        /// <returns>PrintTemplateManager�����ʵ��</returns>
        public static PrintTemplateManager GetInstance()
        {
            if (templateManager == null)
            {
                templateManager = new PrintTemplateManager();
            }
            return templateManager;
        }

        /// <summary>
        /// ���ݴ�ӡ���������ҵ���Ӧ��ģ���ļ�����
        /// </summary>
        /// <param name="templateName">��ӡ��������</param>
        /// <returns>ģ���ļ�����</returns>
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
