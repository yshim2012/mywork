using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Utility
{
    /// <summary>
    /// 文本框值校验的配置类
    /// </summary>
    public sealed class TextBoxVerifyConfig
    {
        static TextBoxVerifyConfig instance = null;
        static readonly object padlock = new object();

        private IDictionary<string, IList<TextBoxProperty>> textboxsPool;

        private TextBoxVerifyConfig()
        {
            string configfile = ConfigurationManager.AppSettings["ConfigFilesPath"] + "TextBoxVerify.config";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(configfile);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
            nsmgr.AddNamespace("textboxverifyConfig", "http://www.l-and-t.com/textboxverifyConfig");
            XmlNodeList pageNodes = xmldoc.SelectNodes("//textboxverifyConfig:page", nsmgr);
            textboxsPool = new Dictionary<string, IList<TextBoxProperty>>();
            string key, textboxid, lengthmessageid, requiredmessageid;
            bool required;
            int maxlength;
            IList<TextBoxProperty> textLengthList;
            TextBoxProperty textboxproperty;
            foreach (XmlNode pageNode in pageNodes)
            {
                key = pageNode.Attributes["name"].Value;
                XmlNodeList textBoxNodes = pageNode.ChildNodes;
                textLengthList = new List<TextBoxProperty>();
                for (int i = 0; i < textBoxNodes.Count; i++)
                {
                    textboxid = textBoxNodes[i].Attributes["id"].Value;
                    maxlength = int.Parse(textBoxNodes[i].Attributes["maxlength"].Value);
                    lengthmessageid = textBoxNodes[i].Attributes["lengthmessageid"].Value;
                    required = bool.Parse(textBoxNodes[i].Attributes["required"].Value);
                    requiredmessageid = textBoxNodes[i].Attributes["requiredmessageid"].Value;

                    textboxproperty = new TextBoxProperty(textboxid, required,
                        requiredmessageid, maxlength, lengthmessageid);

                    if (textBoxNodes[i].Attributes["typepattern"] != null)
                        textboxproperty.TypePattern = textBoxNodes[i].Attributes["typepattern"].Value;
                    if (textBoxNodes[i].Attributes["typemessageid"] != null)
                        textboxproperty.TypeMessageId = textBoxNodes[i].Attributes["typemessageid"].Value;

                    textLengthList.Add(textboxproperty);
                }
                textboxsPool.Add(key, textLengthList);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public IList<TextBoxProperty> GetTextBoxList(string pageName)
        {
            if (textboxsPool.ContainsKey(pageName))
                return textboxsPool[pageName];
            else
                return new List<TextBoxProperty>();
        }

        /// <summary>
        /// 得到Message对象的全局访问点方法
        /// </summary>
        public static TextBoxVerifyConfig Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TextBoxVerifyConfig();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// 重新加载配置文件
        /// </summary>
        public static void Reload()
        {
            lock (padlock)
            {
                instance = null;
                instance = new TextBoxVerifyConfig();
            }
        }
    }
}
