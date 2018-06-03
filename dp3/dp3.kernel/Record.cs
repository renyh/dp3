using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.kernel
{
    public class Record
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string recId { get; set; }

        public byte[] data { get; set; }

        public string timespan { get; set; }

        public List<Field> extensionFieds { get; set; }
    }

    public class Field
    {
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
    }
}
