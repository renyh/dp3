using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace dp3.kernel
{
    public class EntityDatabase : BaseDatabase
    {
        public EntityDatabase(XmlNode node) : base(node)
        { }

        public override void CreateExtension(string xml)
        { }

    }
}



