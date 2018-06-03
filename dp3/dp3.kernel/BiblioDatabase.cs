using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace dp3.kernel
{



    public class BiblioDatabase : BaseDatabase
    {

        public BiblioDatabase(XmlNode node) : base(node)
        {
            // 定义检索点配置
            this.KeyConfigList.Add(new KeyConfig(
                "isbn",
                "ISBN",
                @"//marc:record/marc:datafield[@tag='010']/marc:subfield[@code='a' or @code='z']"));

            this.KeyConfigList.Add(new KeyConfig(
                "title",
                "题名",
                @"//marc:record/marc:datafield[@tag='200' or @tag='225' or @tag='500' or @tag='501' or @tag='503' or @tag='510' or @tag='512' or @tag='513' or @tag='514' or @tag='515' or @tag='516' or @tag='517' or @tag='518' or @tag='520' or @tag='530' or @tag='531' or @tag='532' or @tag='540' or @tag='541' or @tag='545']/marc:subfield[@code='a'] | //marc:record/marc:datafield[@tag='200']/marc:subfield[@code='c'] | //marc:record/marc:datafield[@tag='200' or @tag='225']/marc:subfield[@code='d']"));
        }



        // 创建检索点
        public override List<KeyItem> BuildKeys(string xml, string recId)
        {

            XmlDocument domData = new XmlDocument();
                domData.LoadXml(xml);

            // 名字空间
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(domData.NameTable);
            string strPrefix = "marc";
            string strUrl = @"http://dp2003.com/UNIMARC";
            nsmgr.AddNamespace(strPrefix, strUrl);

            List<KeyItem> keyList = new List<KeyItem>();
            foreach (KeyConfig keyConfig in this.KeyConfigList)
            {
                // 针对一个条目创建检索点
                 this.CreateKey(domData,
                     nsmgr,
                     keyConfig,
                     recId,
                     keyList);
            }

            return keyList;
            
        }

        public void CreateKey(XmlDocument dom,
            XmlNamespaceManager nsmgr,
            KeyConfig keyConfig,
            string recId,
            List<KeyItem> keyList)
        {

            XmlNodeList list = dom.SelectNodes(keyConfig.XPath, nsmgr);

            foreach (XmlNode node in list)
            {
                string keystring = node.InnerText;
                string location = this.GetLocation(node);

                KeyItem keyItem = new KeyItem()
                {
                    keystring = keystring,
                    recId = recId,
                    from = keyConfig.From,
                    location = location
                };

                keyList.Add(keyItem);
            }




        }

        public string GetLocation(XmlNode node)
        {
            string location = "";

            while (node.ParentNode != null
                && node.ParentNode.NodeType != XmlNodeType.Document)
            {
                XmlNodeList list = node.ParentNode.ChildNodes;
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNode one = list[i];
                    if (one == node)
                    {
                        if (location != "")
                            location = "/" + location;

                        location = i.ToString() + location;
                        break;
                    }
                }
                node = node.ParentNode;
            }

            return location;
        }

        // 创建检索点
        public  void BuildKeysByNavigator(string xml,string recId)
        {
            int nRet = 0;
            string error = "";

            XmlDocument domData = new XmlDocument();
            domData.LoadXml(xml);
            XPathNavigator nav =  domData.CreateNavigator();

            // 名字空间
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(domData.NameTable);
            string strPrefix = "marc";
            string strUrl = @"http://dp2003.com/UNIMARC";
            nsmgr.AddNamespace(strPrefix, strUrl);

            List<KeyItem> keyList = new List<KeyItem>();
            foreach (KeyConfig keyConfig in this.KeyConfigList)
            {
                // 针对一个条目创建检索点
                List<string> keystringList = this.CreateKey(nav,
                     nsmgr,
                     keyConfig.XPath);

                foreach (string keystring in keystringList)
                {
                    KeyItem keyItem = new KeyItem()
                    {
                        keystring = keystring,
                        recId = recId,
                        from = keyConfig.From,
                        location=""
                    };

                }

            }
        }


        public List<string> CreateKey(XPathNavigator nav,
            XmlNamespaceManager nsmgr,
            string strXPath)
        {
            List<string> aKey = new List<string>();

            XPathExpression expr = nav.Compile(strXPath);
            expr.SetContext(nsmgr);

            string keystring = "";
            if (expr.ReturnType == XPathResultType.Number)
            {
                keystring = nav.Evaluate(expr).ToString();//Convert.ToString((int)(nav.Evaluate(expr)));
                aKey.Add(keystring);
            }
            else if (expr.ReturnType == XPathResultType.Boolean)
            {
                keystring = Convert.ToString((bool)(nav.Evaluate(expr)));
                aKey.Add(keystring);
            }
            else if (expr.ReturnType == XPathResultType.String)
            {
                keystring = (string)(nav.Evaluate(expr));
                aKey.Add(keystring);
            }
            else if (expr.ReturnType == XPathResultType.NodeSet)
            {
                XPathNodeIterator iterator = null;
                iterator = nav.Select(expr);

                if (iterator != null)
                {
                    while (iterator.MoveNext())
                    {
                        XPathNavigator navigator = iterator.Current;
                        keystring = navigator.Value;
                        if (keystring == "")
                            continue;

                        aKey.Add(keystring);
                    }
                }
            }
            else
            {
                throw new Exception("XPathExpression的ReturnType为'" + expr.ReturnType.ToString() + "'无效");
            }

            return aKey;
        }

        public override void CreateExtension(string xm)
        { }





    }
}
