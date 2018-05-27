using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace dp3.standard
{
    public class BiblioDatabase : BaseDatabase
    {

        public BiblioDatabase(XmlNode node) : base(node)
        { }


        public override void CreateExtension()
        { }
    }
}
