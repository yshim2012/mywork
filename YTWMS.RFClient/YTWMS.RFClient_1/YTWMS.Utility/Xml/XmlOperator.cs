using System;
using System.Xml;

namespace Utility
{
    /// <summary>
    /// Xml文件操作类
    /// </summary>
    public sealed class XmlOperator
    {
        private XmlDocument xmldoc;//定义XmlDocument对象
        private string xmlfile;//xml文件

        /// <summary>
        /// Xml文件
        /// </summary>
        public string XmlFile
        {
            set { xmlfile = value; }
            get { return xmlfile; }
        }

        /// <summary>
        /// 构造函数，初始化XmlDocument对象
        /// </summary>
        public XmlOperator()
        {
            xmldoc = new XmlDocument();
        }

        /// <summary>
        /// 打开Xml文件
        /// </summary>
        /// <param name="xmlfile">Xml文件路径</param>
        public void Open(string xmlfile)
        {
            xmldoc.Load(xmlfile);
            this.xmlfile = xmlfile;
        }

        /// <summary>
        /// 打开Xml文件，需要先给XmlFile赋值
        /// </summary>
        public void Open()
        {
            xmldoc.Load(xmlfile);
        }

        /// <summary>
        /// 保存Xml文件
        /// </summary>
        /// <param name="xmlfile">Xml文件名称，含路径</param>
        public void Save(string xmlfile)
        {
            xmldoc.Save(xmlfile);
        }

        /// <summary>
        /// 保存Xml文件
        /// </summary>
        public void Save()
        {
            xmldoc.Save(this.xmlfile);
        }

        #region 查找
        /// <summary>
        /// 查找单一xml节点
        /// </summary>
        /// <param name="xpath">xpath</param>
        /// <returns>xml节点</returns>
        public XmlNode GetSingleNodeWithXpath(string xpath)
        {
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// 查找xml节点集合
        /// </summary>
        /// <param name="xpath">xpath</param>
        /// <returns>xml节点集合</returns>
        public XmlNodeList GetNodesWithXpath(string xpath)
        {
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// 查找单一xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns>xml节点</returns>
        public XmlNode GetSingleNode(string NodeName)
        {
            string xpath = "//" + NodeName;
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// 查找单一xml节点
        /// </summary>
        /// <param name="ParentNodeName">父节点名称</param>
        /// <param name="ChildeNodeName">子节点名称</param>
        /// <returns>父节点</returns>
        public XmlNode GetSingleNode(string ParentNodeName, string ChildeNodeName)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName;
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// 查找单一xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeName">属性名称</param>
        /// <param name="AttributeValue">属性值</param>
        /// <returns>节点</returns>
        public XmlNode GetSingleNode(string NodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + NodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// 查找单一xml节点
        /// </summary>
        /// <param name="ParentNodeName">父节点名称</param>
        /// <param name="ChildeNodeName">子节点名称</param>
        /// <param name="AttributeName">子节点属性名称</param>
        /// <param name="AttributeValue">子节点属性值</param>
        /// <returns>xml节点</returns>
        public XmlNode GetSingleNode(string ParentNodeName, string ChildeNodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNode singleNode = xmldoc.SelectSingleNode(xpath);
            return singleNode;
        }

        /// <summary>
        /// 查找xml节点集合
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns>xml节点集合</returns>
        public XmlNodeList GetNodes(string NodeName)
        {
            string xpath = "//" + NodeName;
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// 查找xml节点集合
        /// </summary>
        /// <param name="ParentNodeName">父节点名称</param>
        /// <param name="ChildeNodeName">子节点名称</param>
        /// <returns>xml节点集合</returns>
        public XmlNodeList GetNodes(string ParentNodeName, string ChildeNodeName)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName;
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// 查找xml节点集合
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeName">属性名称</param>
        /// <param name="AttributeValue">属性值</param>
        /// <returns>xml节点集合</returns>
        public XmlNodeList GetNodes(string NodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + NodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// 查找xml节点集合
        /// </summary>
        /// <param name="ParentNodeName">父节点名称</param>
        /// <param name="ChildeNodeName">子节点名称</param>
        /// <param name="AttributeName">子节点属性名称</param>
        /// <param name="AttributeValue">子节点属性值</param>
        /// <returns>xml节点集合</returns>
        public XmlNodeList GetNodes(string ParentNodeName, string ChildeNodeName, string AttributeName, string AttributeValue)
        {
            string xpath = "//" + ParentNodeName + "/" + ChildeNodeName + "[@" + AttributeName + "='" + AttributeValue + "']";
            XmlNodeList nodelist = xmldoc.SelectNodes(xpath);
            return nodelist;
        }
        #endregion

        #region 取属性值,InnerText
        /// <summary>
        /// 得到xml节点属性值
        /// </summary>
        /// <param name="node">xml节点</param>
        /// <param name="AttributeName">属性名称</param>
        /// <returns>属性值</returns>
        public string GetNodeAttributeValue(XmlNode node, string AttributeName)
        {
            return node.Attributes[AttributeName].Value;
        }

        /// <summary>
        /// 得到xml节点InnerText值
        /// </summary>
        /// <param name="node">xml节点</param>
        /// <returns>InterText值0</returns>
        public string GetNodeInnerText(XmlNode node)
        {
            return node.InnerText;
        }
        #endregion

        #region 创建
        /// <summary>
        /// 新建xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <returns></returns>
        public XmlNode CreateNewNode(string NodeName)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");
            return node;
        }
        /// <summary>
        /// 新建xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeNames">属性名称集合</param>
        /// <param name="AttributeValues">属性值集合</param>
        /// <returns>xml节点</returns>
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
        /// 新建xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="InnerText">节点串联值</param>
        /// <returns>xml节点</returns>
        public XmlNode CreateNewNode(string NodeName, string InnerText)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, NodeName, "");
            node.InnerText = InnerText;
            return node;
        }

        /// <summary>
        /// 新建xml节点
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeNames">属性名称集合</param>
        /// <param name="AttributeValues">属性值集合</param>
        /// <param name="InnerText">节点串联值</param>
        /// <returns>xml节点</returns>
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

        #region 插入
        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="addedNode">插入的xml节点</param>
        /// <param name="ParentNodeName">父节点名称</param>
        public void AddNode(XmlNode addedNode, string ParentNodeName)
        {
            XmlNode ParentNode = GetSingleNode(ParentNodeName);
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }

        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="addedNode">插入的xml节点</param>
        /// <param name="ParentNodeName">父节点名称</param>
        /// <param name="AttributeName">父节点属性名称</param>
        /// <param name="AttributeValue">父节点属性值</param>
        public void AddNode(XmlNode addedNode, string ParentNodeName, string AttributeName, string AttributeValue)
        {
            XmlNode ParentNode = GetSingleNode(ParentNodeName, AttributeName, AttributeValue);
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }

        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="addedNode">插入的xml节点</param>
        /// <param name="parentNode">父节点</param>
        public void AddNode(XmlNode addedNode, XmlNode parentNode)
        {
            XmlNode ParentNode = parentNode;
            if (ParentNode != null)
                ParentNode.AppendChild(addedNode);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 移除一个节点的属性
        /// </summary>
        /// <param name="NodeName">节点名称</param>
        /// <param name="AttributeName">移除的节点属性</param>
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
        /// 移除一个节点
        /// </summary>
        /// <param name="NodeName">移除的节点名称</param>
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
        /// 移除节点集合
        /// </summary>
        /// <param name="NodeName">移除的节点集合名称</param>
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
        /// 移除节点
        /// </summary>
        /// <param name="NodeName">移除的节点名称</param>
        /// <param name="AttributeName">移除的节点属性</param>
        /// <param name="AttributeValue">移除的节点值</param>
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
        /// 移除节点集合
        /// </summary>
        /// <param name="NodeName">移除的节点集合名称</param>
        /// <param name="AttributeName">移除的节点集合属性</param>
        /// <param name="AttributeValue">移除的节点集合值</param>
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

        #region 更新
        /// <summary>
        /// 更新的节点属性
        /// </summary>
        /// <param name="NodeName">更新的节点名称</param>
        /// <param name="AttributeName">更新的节点属性</param>
        /// <param name="AttributeValue">更新的节点属性原来值</param>
        /// <param name="NewAttributeValue">更新的节点属性新值</param>
        public void UpdateNodeAttributeValue(string NodeName, string AttributeName, string AttributeValue, string NewAttributeValue)
        {
            XmlNode node = GetSingleNode(NodeName, AttributeName, AttributeValue);
            if (node != null)
            {
                node.Attributes[AttributeName].Value = NewAttributeValue;
            }
        }

        /// <summary>
        /// 更新的节点InnerText
        /// </summary>
        /// <param name="NodeName">更新的节点名称</param>
        /// <param name="InnerText">更新的节点InnerText</param>
        public void UpdateNodeInnerText(string NodeName, string InnerText)
        {
            XmlNode node = GetSingleNode(NodeName);
            if (node != null)
            {
                node.InnerText = InnerText;
            }
        }

        /// <summary>
        /// 更新的节点的InnerText
        /// </summary>
        /// <param name="NodeName">更新的节点名称</param>
        /// <param name="AttributeName">更新的节点属性名称</param>
        /// <param name="AttributeValue">更新的节点的属性值</param>
        /// <param name="InnerText">更新的节点的InnerText新值</param>
        public void UpdateNodeInnerText(string NodeName, string AttributeName, string AttributeValue, string InnerText)
        {
            XmlNode node = GetSingleNode(NodeName, AttributeName, AttributeValue);
            if (node != null)
            {
                node.InnerText = InnerText;
            }
        }
        #endregion

        #region 创建注释
        /// <summary>
        /// 创建注释
        /// </summary>
        /// <param name="data">xml注释的内容</param>
        /// <returns>xml注释</returns>
        public XmlComment CreateComment(string data)
        {
            XmlComment comment = xmldoc.CreateComment(data);
            return comment;
        }
        #endregion

        #region 添加注释
        /// <summary>
        /// 在节点前添加注释
        /// </summary>
        /// <param name="comment">xml注释</param>
        /// <param name="node">xml节点</param>
        public void AddCommentBefore(XmlComment comment, XmlNode node)
        {
            node.ParentNode.InsertBefore(comment, node);
        }

        /// <summary>
        /// 在节点前添加注释
        /// </summary>
        /// <param name="commentdata">xml注释的内容</param>
        /// <param name="node">xml节点</param>
        public void AddCommentBefore(string commentdata, XmlNode node)
        {
            XmlComment comment = CreateComment(commentdata);
            node.ParentNode.InsertBefore(comment, node);
        }

        /// <summary>
        /// 在节点后添加注释
        /// </summary>
        /// <param name="comment">xml注释</param>
        /// <param name="node">xml节点</param>
        public void AddCommentAfter(XmlComment comment, XmlNode node)
        {
            node.ParentNode.InsertAfter(comment, node);
        }

        /// <summary>
        /// 在节点后添加注释
        /// </summary>
        /// <param name="commentdata">xml注释的内容</param>
        /// <param name="node">xml节点</param>
        public void AddCommentAfter(string commentdata, XmlNode node)
        {
            XmlComment comment = CreateComment(commentdata);
            node.ParentNode.InsertAfter(comment, node);
        }
        #endregion
    }
}
