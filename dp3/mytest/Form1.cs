//测试
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace mytest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            string xml = this.textBox_xml.Text;
            string xpath = this.textBox_xpath.Text;

            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xml);

            // 名字空间
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
            string strPrefix = "marc";
            string strUrl = @"http://dp2003.com/UNIMARC";
            nsmgr.AddNamespace(strPrefix, strUrl);

            string xpath1 = "//marc:record/marc:datafield[@tag='998']/marc:subfield[@code='a']";
            XmlNodeList list= dom.SelectNodes(xpath1, nsmgr);

            foreach (XmlNode node in list)
            {
                string value = node.InnerText;

                string location = this.GetLocation(node);
            }


        }

        public string GetLocation(XmlNode node)
        {
            string location = "";

            while (node.ParentNode != null 
                && node.ParentNode.NodeType!=XmlNodeType.Document)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
