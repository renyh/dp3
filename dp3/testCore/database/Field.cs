using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.Entity
{
    // 字段
    public class Field
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string tag { get; set; }  //字段名，例如 010
        public string ind1 { get; set; } // 指示符1
        public string ind2 { get; set; } // 指示符2

        public List<SubField> subFields { get; set; } // 子字段集合      
    }

    // 子字段
    public class SubField
    {
        public string code { get; set; }  //子字段名，例如 $a
        public string content { get; set; } //值
    }
}
