using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.kernel
{
    // 记录
    public class Record
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string recId { get; set; }

        public byte[] data { get; set; }

        public string timespan { get; set; }

        // 扩展字段
        public List<ExtField> extFieds { get; set; }
    }

    // 扩展字段
    public class ExtField
    {
        public string from { get; set; }
        public string value { get; set; }
        public string location { get; set; }
    }
}
