using dp3.xml;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace dp3.standard
{
    public class BaseDatabase
    {
        // 库句
        private string Name = "";

        // id规则，将来可以是3种情况:guid,num,库/序号，前期先使用guid,注意不是mongodb库那个id
        // 到时定义rule值的几个常量字符串
        private string IdRule = "";

        // 当id是增量序号时，需要维护一个序号种子。
        private int Seed = 0;

        // mongodb client
        protected MongoClient MClient { get; set; }
        // 一个数据库有三类表record,object,一些keys表
        protected IMongoCollection<Record> RecordCollection { get; set; }
        protected IMongoDatabase Database { get; set; }

        public int m_nTimestampSeed = 0;
        // 时间戳种子
        public string GetTimestampSeed()
        {
            // 当超过1000时，复原0
            if (this.m_nTimestampSeed == 1000)
                this.m_nTimestampSeed = 0;

            this.m_nTimestampSeed++;
            return this.m_nTimestampSeed.ToString().PadLeft(4, '0');
        }

        /*
        // 为数据库中的记录创建时间戳
        public string CreateTimestampForDb()
        {
            long lTicks = System.DateTime.UtcNow.Ticks;
            byte[] baTime = BitConverter.GetBytes(lTicks);

            byte[] baSeed = BitConverter.GetBytes(this.GetTimestampSeed());
            Array.Reverse(baSeed);

            byte[] baTimestamp = new byte[baTime.Length + baSeed.Length];
            Array.Copy(baTime,
                0,
                baTimestamp,
                0,
                baTime.Length);
            Array.Copy(baSeed,
                0,
                baTimestamp,
                baTime.Length,
                baSeed.Length);

            return ByteArray.GetHexTimeStampString(baTimestamp);
        }

        // 得到byte[]类型的时间戳
        public static byte[] GetTimeStampByteArray(string strHexTimeStamp)
        {
            if (string.IsNullOrEmpty(strHexTimeStamp) == true)
                return null;

            byte[] result = new byte[strHexTimeStamp.Length / 2];

            for (int i = 0; i < strHexTimeStamp.Length / 2; i++)
            {
                string strHex = strHexTimeStamp.Substring(i * 2, 2);
                result[i] = Convert.ToByte(strHex, 16);
            }

            return result;
        }
        */


        // <db name="bible" idrule='guid' seed='1' />
        public BaseDatabase(XmlNode node)
        {
            this.Name = DomUtil.GetElementAttr(node, "", "name");
            this.IdRule = DomUtil.GetElementAttr(node, "", "idrule");

            string seedStr = DomUtil.GetElementAttr(node, "", "seed");
            if (string.IsNullOrEmpty(seedStr) == false)
                this.Seed = Convert.ToInt32(seedStr);

            // 根据连接字符串，打开mongodb库
            this.MClient = new MongoClient(DbWrapper.Instance.Connection);
            this.Database = this.MClient.GetDatabase(this.Name);
            this.RecordCollection = this.Database.GetCollection<Record>("record");

            //todo
            // 创建索引       
        }

        public int WriteRecord(string recId,
            string xml,
            string opeType,    //操作类型，定义相应常量
            out string outputRecId,
            out string error)
        {
            error = "";
            outputRecId = "";

            if (opeType == "add")
            {
                return this.AddRecord(xml,
                    out outputRecId,
                    out error);
            }
            else if (opeType == "del")
            {
                return this.DelRecord(recId, out error);
            }



            return 0;
        }


        public int AddRecord(string xml,
            out string outputRecId,
            out string error)
        {
            error = "";
            outputRecId = "";

            // 写记录体，先直接把文体转成二进制
            byte[] bXml = System.Text.Encoding.UTF8.GetBytes(xml);

            Record record = new Record();
            record.recId = Guid.NewGuid().ToString();
            record.data = bXml;
            record.timespan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + this.GetTimestampSeed());


            this.RecordCollection.InsertOne(record);

            outputRecId = record.recId;

            // 写扩展字段
            this.CreateExtension();

            // 写keys文件
            this.CreateKeys();

            return 0;
        }


        public int DelRecord(string recId, out string error)
        {
            error = "";

            var filter = Builders<Record>.Filter.Eq("recId", recId);
            this.RecordCollection.DeleteOne(filter);

            return 0;
        }

        public List<Record> GetAll()
        {
            List<Record> list = this.RecordCollection.Find(new BsonDocument()).ToListAsync().Result;

            return list;
        }
        public Record GetByRecId(string recId)
        {
            if (string.IsNullOrEmpty(recId) == true)
                return null;

            var filter = Builders<Record>.Filter.Eq("recId", recId);

            List<Record> list = this.RecordCollection.Find(filter).ToList();
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        public virtual long Delete(String recId)
        {
            var filter = Builders<Record>.Filter.Eq("recId", recId);
            DeleteResult ret= this.RecordCollection.DeleteOne(filter);
            return ret.DeletedCount;
        }

        // todo
        public void WriteBinary()
        {

        }



        public virtual void CreateExtension()
        {


        }

        public virtual void CreateKeys()
        {

        }
    }


}
