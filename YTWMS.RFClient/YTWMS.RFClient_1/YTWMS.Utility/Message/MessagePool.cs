using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Web;
namespace Utility
{
    /// <summary>
    /// �õ������ļ���Message��Ϣ�ĵ�̬��
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
        /// ����message��idֵ�õ�message��value
        /// </summary>
        /// <param name="key">message��idֵ</param>
        /// <returns>message��value</returns>
        public string GetMessage(string key)
        {
            if (messagePool.ContainsKey(key))
                return messagePool[key];
            else
                return string.Empty;
        }

        /// <summary>
        /// ����message��idֵ�õ�message��value
        /// </summary>
        /// <param name="key">message��idֵ</param>
        /// <param name="messageParams">message���滻����ֵ</param>
        /// <returns>message��value</returns>
        public string GetMessage(string key, string[] messageParams)
        {
            if (messagePool.ContainsKey(key))
                return string.Format(messagePool[key], messageParams);
            else
                return string.Empty;
        }

        /// <summary>
        /// �õ�Message�����ȫ�ַ��ʵ㷽��
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
        /// ���¼��������ļ�
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
