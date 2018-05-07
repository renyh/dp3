using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace testCore.Entity
{
    public class Biblio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public List<Identifier> identifiers { get; set; }
    }

    public class Identifier
    {
        public string type { get; set; }
        public string no { get; set; }
        public double price { get; set; }
        public List<string> errorNo { get; set; }
    }

}
