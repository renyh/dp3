using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.kernel
{
    // 检索点配置项
    public class KeyConfig
    {
        public KeyConfig(string from, string caption, string xpath)
        {
            this.XPath = xpath;
            this.From = from;
            this.Caption = caption;
        }

        public string XPath { get; set; }
        public string From { get; set; }
        public string Caption { get; set; }
    }
}
