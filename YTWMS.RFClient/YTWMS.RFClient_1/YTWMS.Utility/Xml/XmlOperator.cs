using System;
using System.Xml;

namespace Utility
{
    /// <summary>
    /// Xml�ļ�������
    /// </summary>
    public sealed class XmlOperator
    {
        private XmlDocument xmldoc;//����XmlDocument����
        private string xmlfile;//xml�ļ�

        /// <summary>
        /// Xml�ļ�
        /// </summary>
        public string XmlFile
        {
            set { xmlfile = value; }
            get { return xmlfile; }
        }

        /// <summary>
        /// ���캯������ʼ��XmlDocument����
        /// </summary>
        public XmlOperator()
        {
            xmldoc = new XmlDocument();
        }

        /// <summary>
        /// ��Xml�ļ�
        /// </summary>
        /// <param name="xmlfile">Xml�ļ�·��</param>
        public void Open(string xmlfile)
        {
            xmldoc.Load(xmlfile);
            this.xmlfile = xmlfile;
        }

        /// <summary>
        /// ��Xml�ļ�����Ҫ�ȸ�XmlFile��ֵ
        /// </summary>
        public void Open()
        {
            xmldoc.Load(xmlfile);
        }

        /// <summary>
        /// ����Xml�ļ�
        /// </summary>
        /// <param name="xmlfile">Xml�ļ����ƣ���·��</param>
        public void Save(string xmlfile)
        {
            xmldoc.Save(xmlfile);
        }

        /// <summary>
        /// ����Xml�ļ�
        /// </summary>
        public void Save()
        {
            xmldoc.Save(this.xmlfile);
        }

        #region ����
        /// <summary>
        /// ���ҵ�һxml�ڵ�
        /// </summary>
        /// <param name="xpath">xpath</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode GetSingleNodeWithXpath(string xpath)
        {
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// ����xml�ڵ㼯��
        /// </summary>
        /// <param name="xpath">xpath</param>
        /// <returns>xml�ڵ㼯��</returns>
        public XmlNodeList GetNodesWithXpath(string xpath)
        {
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// ���ҵ�һxml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode GetSingleNode(string NodeName)
        {
            string xpath = "//" + NodeName;
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// ���ҵ�һxml�ڵ�
        /// </summary>
        /// <param name="ParentNodeName">���ڵ�����</param>
        /// <param name="ChildeNodeName">�ӽڵ�����</param>
        /// <returns>���ڵ�</returns>
        public XmlNode GetSingleNode(string ParentNodeName, string ChildeNodeName)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName;
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// ���ҵ�һxml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeName">��������</param>
        /// <param name="AttributeValue">����ֵ</param>
        /// <returns>�ڵ�</returns>
        public XmlNode GetSingleNode(string NodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + NodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// ���ҵ�һxml�ڵ�
        /// </summary>
        /// <param name="ParentNodeName">���ڵ�����</param>
        /// <param name="ChildeNodeName">�ӽڵ�����</param>
        /// <param name="AttributeName">�ӽڵ���������</param>
        /// <param name="AttributeValue">�ӽڵ�����ֵ</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode GetSingleNode(string ParentNodeName, string ChildeNodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// ����xml�ڵ㼯��
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <returns>xml�ڵ㼯��</returns>
        public XmlNodeList GetNodes(string NodeName)
        {
            string xpath = "//" + NodeName;
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// ����xml�ڵ㼯��
        /// </summary>
        /// <param name="ParentNodeName">���ڵ�����</param>
        /// <param name="ChildeNodeName">�ӽڵ�����</param>
        /// <returns>xml�ڵ㼯��</returns>
        public XmlNodeList GetNodes(string ParentNodeName, string ChildeNodeName)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName;
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// ����xml�ڵ㼯��
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeName">��������</param>
        /// <param name="AttributeValue">����ֵ</param>
        /// <returns>xml�ڵ㼯��</returns>
        public XmlNodeList GetNodes(string NodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + NodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// ����xml�ڵ㼯��
        /// </summary>
        /// <param name="ParentNodeName">���ڵ�����</param>
        /// <param name="ChildeNodeName">�ӽڵ�����</param>
        /// <param name="AttributeName">�ӽڵ���������</param>
        /// <param name="AttributeValue">�ӽڵ�����ֵ</param>
        /// <returns>xml�ڵ㼯��</returns>
        public XmlNodeList GetNodes(string ParentNodeName, string ChildeNodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }
        #endregion

        #region ȡ����ֵ,InnerText
        /// <summary>
        /// �õ�xml�ڵ�����ֵ
        /// </summary>
        /// <param name="node">xml�ڵ�</param>
        /// <param name="AttributeName">��������</param>
        /// <returns>����ֵ</returns>
        public string GetNodeAttributeValue(XmlNode node, string AttributeName)
        {
            return node.Attributes[AttributeName].Value;
        }

        /// <summary>
        /// �õ�xml�ڵ�InnerTextֵ
        /// </summary>
        /// <param name="node">xml�ڵ�</param>
        /// <returns>InterTextֵ0</returns>
        public string GetNodeInnerText(XmlNode node)
        {
            return node.InnerText;
        }
        #endregion

        #region ����
        /// <summary>
        /// �½�xml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <returns></returns>
        public XmlNode CreateNewNode(string NodeName)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");
            return node;
        }
        /// <summary>
        /// �½�xml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeNames">�������Ƽ���</param>
        /// <param name="AttributeValues">����ֵ����</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode CreateNewNode(string NodeName, string[] AttributeNames, string[] AttributeValues)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");

            XmlElement xe = (XmlElement)node;
            for (int i = 0; i < AttributeNames.Length; i++)
            {
                xe.SetAttribute(AttributeNames[i], AttributeValues[i]);
            }
            return (XmlNode)xe;
        }

        /// <summary>
        /// �½�xml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="InnerText">�ڵ㴮��ֵ</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode CreateNewNode(string NodeName, string InnerText)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");
            node.InnerText = InnerText;
            return node;
        }

        /// <summary>
        /// �½�xml�ڵ�
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeNames">�������Ƽ���</param>
        /// <param name="AttributeValues">����ֵ����</param>
        /// <param name="InnerText">�ڵ㴮��ֵ</param>
        /// <returns>xml�ڵ�</returns>
        public XmlNode CreateNewNode(string NodeName, string[] AttributeNames, string[] AttributeValues, string InnerText)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");

            XmlElement xe = (XmlElement)node;
            for (int i = 0; i < AttributeNames.Length; i++)
            {
                xe.SetAttribute(AttributeNames[i], AttributeValues[i]);
            }
            node = (XmlNode)xe;
            node.InnerText = InnerText;
            return node;
        }
        #endregion

        #region ����
        /// <summary>
        /// ����һ���ڵ�
        /// </summary>
        /// <param name="addedNode">�����xml�ڵ�</param>
        /// <param name="ParentNodeName">���ڵ�����</param>
        public void AddNode(XmlNode addedNode, string ParentNodeName)
        {
            XmlNode ParentNode = GetSingleNode(ParentNodeName);
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }

        /// <summary>
        /// ����һ���ڵ�
        /// </summary>
        /// <param name="addedNode">�����xml�ڵ�</param>
        /// <param name="ParentNodeName">���ڵ�����</param>
        /// <param name="AttributeName">���ڵ���������</param>
        /// <param name="AttributeValue">���ڵ�����ֵ</param>
        public void AddNode(XmlNode addedNode, string ParentNodeName, string AttributeName, string AttributeValue)
        {
            XmlNode ParentNode = GetSingleNode(ParentNodeName, AttributeName, AttributeValue);
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }

        /// <summary>
        /// ����һ���ڵ�
        /// </summary>
        /// <param name="addedNode">�����xml�ڵ�</param>
        /// <param name="parentNode">���ڵ�</param>
        public void AddNode(XmlNode addedNode, XmlNode parentNode)
        {
            XmlNode ParentNode = parentNode;
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }
        #endregion

        #region ɾ��
        /// <summary>
        /// �Ƴ�һ���ڵ������
        /// </summary>
        /// <param name="NodeName">�ڵ�����</param>
        /// <param name="AttributeName">�Ƴ��Ľڵ�����</param>
        public void RemoveNodeAttribute(string NodeName, string AttributeName)
        {
            XmlNode node = GetSingleNode(NodeName);
            if (node != null)
            {
                XmlElement xe = (XmlElement)node;
                xe.RemoveAttribute(AttributeName);
            }
        }

        /// <summary>
        /// �Ƴ�һ���ڵ�
        /// </summary>
        /// <param name="NodeName">�Ƴ��Ľڵ�����</param>
        public void RemoveNode(string NodeName)
        {
            XmlNode node = GetSingleNode(NodeName);
            if (node != null)
            {
                XmlNode parentNode = node.ParentNode;
                parentNode.RemoveChild(node);
            }
        }

        /// <summary>
        /// �Ƴ��ڵ㼯��
        /// </summary>
        /// <param name="NodeName">�Ƴ��Ľڵ㼯������</param>
        public void RemoveNodes(string NodeName)
        {
            XmlNodeList nodes = GetNodes(NodeName);
            if (nodes != null && nodes.Count != 0)
            {
                XmlNode parentNode = nodes[0].ParentNode;
                for (int i = 0; i < nodes.Count; i++)
                {
                    parentNode.RemoveChild(nodes[i]);
                }
            }
        }

        /// <summary>
        /// �Ƴ��ڵ�
        /// </summary>
        /// <param name="NodeName">�Ƴ��Ľڵ�����</param>
        /// <param name="AttributeName">�Ƴ��Ľڵ�����</param>
        /// <param name="AttributeValue">�Ƴ��Ľڵ�ֵ</param>
        public void RemoveNode(string NodeName, string AttributeName, string AttributeValue)
        {
            XmlNode node = GetSingleNode(NodeName, AttributeName, AttributeValue);
            if (node != null)
            {
                XmlNode parentNode = node.ParentNode;
                parentNode.RemoveChild(node);
            }
        }

        /// <summary>
        /// �Ƴ��ڵ㼯��
        /// </summary>
        /// <param name="NodeName">�Ƴ��Ľڵ㼯������</param>
        /// <param name="AttributeName">�Ƴ��Ľڵ㼯������</param>
        /// <param name="AttributeValue">�Ƴ��Ľڵ㼯��ֵ</param>
        public void RemoveNodes(string NodeName, string AttributeName, string AttributeValue)
        {
            XmlNodeList nodes = GetNodes(NodeName, AttributeName, AttributeValue);
            if (nodes != null && nodes.Count != 0)
            {
                XmlNode parentNode = nodes[0].ParentNode;
                for (int i = 0; i < nodes.Count; i++)
                {
                    parentNode.RemoveChild(nodes[i]);
                }
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// ���µĽڵ�����
        /// </summary>
        /// <param name="NodeName">���µĽڵ�����</param>
        /// <param name="AttributeName">���µĽڵ�����</param>
        /// <param name="AttributeValue">���µĽڵ�����ԭ��ֵ</param>
        /// <param name="NewAttributeValue">���µĽڵ�������ֵ</param>
        public void UpdateNodeAttributeValue(string NodeName, string AttributeName, string AttributeValue, string NewAttributeValue)
        {
            XmlNode node = GetSingleNode(NodeName, AttributeName, AttributeValue);
            if (node != null)
            {
                node.Attributes[AttributeName].Value = NewAttributeValue;
            }
        }

        /// <summary>
        /// ���µĽڵ�InnerText
        /// </summary>
        /// <param name="NodeName">���µĽڵ�����</param>
        /// <param name="InnerText">���µĽڵ�InnerText</param>
        public void UpdateNodeInnerText(string NodeName, string InnerText)
        {
            XmlNode node = GetSingleNode(NodeName);
            if (node != null)
            {
                node.InnerText = InnerText;
            }
        }

        /// <summary>
        /// ���µĽڵ��InnerText
        /// </summary>
        /// <param name="NodeName">���µĽڵ�����</param>
        /// <param name="AttributeName">���µĽڵ���������</param>
        /// <param name="AttributeValue">���µĽڵ������ֵ</param>
        /// <param name="InnerText">���µĽڵ��InnerText��ֵ</param>
        public void UpdateNodeInnerText(string NodeName, string AttributeName, string AttributeValue, string InnerText)
        {
            XmlNode node = GetSingleNode(NodeName, AttributeName, AttributeValue);
            if (node != null)
            {
                node.InnerText = InnerText;
            }
        }
        #endregion

        #region ����ע��
        /// <summary>
        /// ����ע��
        /// </summary>
        /// <param name="data">xmlע�͵�����</param>
        /// <returns>xmlע��</returns>
        public XmlComment CreateComment(string data)
        {
            XmlComment comment = xmldoc.CreateComment(data);
            return comment;
        }
        #endregion

        #region ���ע��
        /// <summary>
        /// �ڽڵ�ǰ���ע��
        /// </summary>
        /// <param name="comment">xmlע��</param>
        /// <param name="node">xml�ڵ�</param>
        public void AddCommentBefore(XmlComment comment, XmlNode node)
        {
            node.ParentNode.InsertBefore(comment, node);
        }

        /// <summary>
        /// �ڽڵ�ǰ���ע��
        /// </summary>
        /// <param name="commentdata">xmlע�͵�����</param>
        /// <param name="node">xml�ڵ�</param>
        public void AddCommentBefore(string commentdata, XmlNode node)
        {
            XmlComment comment = CreateComment(commentdata);
            node.ParentNode.InsertBefore(comment, node);
        }

        /// <summary>
        /// �ڽڵ�����ע��
        /// </summary>
        /// <param name="comment">xmlע��</param>
        /// <param name="node">xml�ڵ�</param>
        public void AddCommentAfter(XmlComment comment, XmlNode node)
        {
            node.ParentNode.InsertAfter(comment, node);
        }

        /// <summary>
        /// �ڽڵ�����ע��
        /// </summary>
        /// <param name="commentdata">xmlע�͵�����</param>
        /// <param name="node">xml�ڵ�</param>
        public void AddCommentAfter(string commentdata, XmlNode node)
        {
            XmlComment comment = CreateComment(commentdata);
            node.ParentNode.InsertAfter(comment, node);
        }
        #endregion
    }
}
