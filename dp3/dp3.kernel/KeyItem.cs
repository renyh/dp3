using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.kernel
{
    public class KeyItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string keystring { get; set; }
        public string from { get; set; }
        public string recId { get; set; }
        public string location { get; set; }

        public string Drop()
        {
            return "keystring:'" + keystring + "'"
                + "\r\n" + "from:'" + from + "'"
                + "\r\n" + "recId:'" + recId + "'"
                + "\r\n" + "location:'" + location + "'";
        }
    }
}
