using System;
using System.Xml;

namespace JJMC.Utility.OperateXML
{
    /// <summary>
    /// 操作XML文件的类
    /// </summary>
    public class RoleButton
    {
        private string XMLName;
        /// <summary>
        /// 析构函数
        /// </summary>
        /// <param name="XMLFullName">XML文件全中路径名</param>
        public RoleButton(string XMLFullName)
        {
            this.XMLName = XMLFullName;
        }

        #region 查询XML文件
        /// <summary>
        /// 得到XML文档
        /// </summary>
        /// <returns>XML文档对象</returns>
        private XmlDocument GetXMLDocumnt()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(this.XMLName.Trim());
                return xmlDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 得到角色在ButtonConfig中对该页面配制的Button Id
        /// </summary>
        /// <param name="PageName">页面名称</param>
        /// <param name="RoleCode">角色代码</param>
        /// <returns>Button id</returns>
        public string[] GetButtonIDs(string PageName, string RoleCode)
        {
            try
            {
                XmlDocument xmlDoc = GetXMLDocumnt();
                foreach (XmlNode rootNode in xmlDoc.ChildNodes)
                {
                    if (rootNode.Name == "buttons")
                    {
                        foreach (XmlNode PageNode in rootNode.ChildNodes)
                        {
                            if (PageNode.Name=="page" && PageNode.Attributes["name"].Value == PageName)
                            {
                                foreach (XmlNode RoleNode in PageNode.ChildNodes)
                                {
                                    if (RoleNode.Name=="role" && RoleNode.Attributes["code"].Value == RoleCode)
                                    {
                                        string[] btnIds = new string[RoleNode.ChildNodes.Count];
                                        int i=0;
                                        foreach (XmlNode buttonNode in RoleNode.ChildNodes)
                                        {
                                            if (buttonNode.Name == "button")
                                            {
                                                btnIds[i] = buttonNode.Attributes["id"].Value;
                                                i++;
                                            }
                                        }
                                        return btnIds;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
