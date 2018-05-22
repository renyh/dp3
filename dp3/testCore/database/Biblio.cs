using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace testCore.database
{
    // 书目记录
    public class BiblioItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        // ISBN 国际标准书号
        public List<ISBNItem> isbnList { get; set; }

        // 题名与责任者
        public List<TitleItem> titleList { get; set; }


        //序号，测试用
        public string no { get; set; }

    }



}
