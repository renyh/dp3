using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.standard
{




    public class BaseDatabase
    {
        // id规则，将来可以是3种情况:guid,num,库/序号，前期先使用guid,注意不是mongodb库那个id
        private string idrule = "";
        // 当id是增量序号时，需要维护一个序号种子。
        private int seed = 0;

        // 成员变量
        MongoClient MClient { get; set; }
        IMongoDatabase Database { get; set; }

        // 一个数据库有三类表record,object,一些keys表
        IMongoCollection<Record> RecordCollection { get; set; }


        // dbName:物理库名
        public void Init(string connection,string dbName)
        {
            this.MClient = new MongoClient(connection);

            this.Database = this.MClient.GetDatabase(dbName);

            this.RecordCollection = this.Database.GetCollection<Record>("record");
        }

        public int WriteRecord(string xml,out string error)
        {
            error = "";

            // 写记录体
            byte[] b2 = System.Text.Encoding.UTF8.GetBytes(xml);
            


            // 写扩展字段
            this.CreateExtension();

            // 写keys文件
            this.CreateKeys();

            return 0;
        }

        public void WriteBinary()
        {

        }



        public virtual void CreateExtension()
        { }

        public virtual void CreateKeys()
        {

        }
    }

    public class BiblioDatabase:BaseDatabase
    { }

    public class EntityDatabase:BaseDatabase
    { }

    public class Record
    {
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
