using System;
using System.Xml;

namespace JJMC.Utility.OperateXML
{
    /// <summary>
    /// ����XML�ļ�����
    /// </summary>
    public class RoleButton
    {
        private string XMLName;
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="XMLFullName">XML�ļ�ȫ��·����</param>
        public RoleButton(string XMLFullName)
        {
            this.XMLName = XMLFullName;
        }

        #region ��ѯXML�ļ�
        /// <summary>
        /// �õ�XML�ĵ�
        /// </summary>
        /// <returns>XML�ĵ�����</returns>
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
        /// �õ���ɫ��ButtonConfig�жԸ�ҳ�����Ƶ�Button Id
        /// </summary>
        /// <param name="PageName">ҳ������</param>
        /// <param name="RoleCode">��ɫ����</param>
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
