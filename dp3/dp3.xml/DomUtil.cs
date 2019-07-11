using System;
using System.Xml;

namespace dp3.xml
{
    public class DomUtil
    {
        // 获取元素的属性值
        public static string GetElementAttr(XmlNode nodeRoot,
            string strXpath,
            string strAttrName)
        {
            XmlNode node = nodeRoot;

            // 2018/5/27，改进支持xpath为空，那么直接取传入节点的属性性
            if (string.IsNullOrEmpty(strXpath) == false)
            {
                node=nodeRoot.SelectSingleNode(strXpath);
                if (node == null)
                    return null;
            }
            XmlAttribute attr = node.Attributes[strAttrName];
            if (attr == null)
                return null;
            return attr.Value.Trim();
        }

        // 编写者: 谢涛
        public static string GetElementText(XmlNode nodeRoot,
            string strXpath)
        {
            XmlNode node = nodeRoot;

            // 2018/5/27，改进支持xpath为空，那么直接取传入节点的属性性
            if (string.IsNullOrEmpty(strXpath) == false)
            {
                node = nodeRoot.SelectSingleNode(strXpath);
                if (node == null)
                    return null;
            }

            XmlNode nodeText;
            nodeText = node.SelectSingleNode("text()");

            if (nodeText == null)
                return "";
            else
                return nodeText.Value;
        }
    }
}
