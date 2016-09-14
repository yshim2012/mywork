using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Web;
namespace Utility
{
    /// <summary>
    /// 得到配置文件中Message信息的单态类
    /// </summary>
    public sealed class MessagePool
    {
        static MessagePool instance = null;
        static readonly object padlock = new object();

        private IDictionary<string, string> messagePool;

        private MessagePool()
        {
            string configfile = ConfigurationManager.AppSettings["ConfigFilesPath"] + "Message.config";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(configfile);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
            nsmgr.AddNamespace("messageConfig", "http://www.l-and-t.com/messageConfig");
            XmlNodeList messageNodes = xmldoc.SelectNodes("//messageConfig:message", nsmgr);
            messagePool = new Dictionary<string, string>();
            string key, value;
            foreach (XmlNode messageNode in messageNodes)
            {
                key = messageNode.Attributes["id"].Value;
                value = messageNode.Attributes["value"].Value;
                messagePool.Add(key, value);
            }
        }

        /// <summary>
        /// 根据message的id值得到message的value
        /// </summary>
        /// <param name="key">message的id值</param>
        /// <returns>message的value</returns>
        public string GetMessage(string key)
        {
            if (messagePool.ContainsKey(key))
                return messagePool[key];
            else
                return string.Empty;
        }

        /// <summary>
        /// 根据message的id值得到message的value
        /// </summary>
        /// <param name="key">message的id值</param>
        /// <param name="messageParams">message的替换参数值</param>
        /// <returns>message的value</returns>
        public string GetMessage(string key, string[] messageParams)
        {
            if (messagePool.ContainsKey(key))
                return string.Format(messagePool[key], messageParams);
            else
                return string.Empty;
        }

        /// <summary>
        /// 得到Message对象的全局访问点方法
        /// </summary>
        public static MessagePool Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MessagePool();
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
                instance = new MessagePool();
            }
        }
    }

}
