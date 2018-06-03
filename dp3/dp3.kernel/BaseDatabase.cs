using dp3.xml;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace dp3.kernel
{
    public class BaseDatabase
    {

        #region 成员变量
        // 库句
        private string Name = "";

        // id规则，将来可以是3种情况:guid,num,库/序号，前期先使用guid,注意不是mongodb库那个id
        // 到时定义rule值的几个常量字符串
        private string IdRule = "";

        // 当id是增量序号时，需要维护一个序号种子。
        private int Seed = 0;

        // 一个数据库有三类表record,object,一些keys表
        protected IMongoDatabase Database { get; set; }
        protected IMongoCollection<Record> RecordCollection { get; set; }

        // 检索点配置
        public List<KeyCfgItem> KeyCfgList = new List<KeyCfgItem>();
        // 扩展字段配置
        public List<KeyCfgItem> ExtFieldList = new List<KeyCfgItem>();
        #endregion

        #region 构造函数

        // <db name="bible" idrule='guid' seed='1' />
        public BaseDatabase(XmlNode node)
        {
            this.Name = DomUtil.GetElementAttr(node, "", "name");
            this.IdRule = DomUtil.GetElementAttr(node, "", "idrule");

            string seedStr = DomUtil.GetElementAttr(node, "", "seed");
            if (string.IsNullOrEmpty(seedStr) == false)
                this.Seed = Convert.ToInt32(seedStr);

            // 根据连接字符串，打开mongodb库
            this.Database = DbWrapper.Instance.MClient.GetDatabase(this.Name);
            this.RecordCollection = this.Database.GetCollection<Record>("record");

            //todo
            // 创建索引       
        }

        #endregion

        #region 时间戳
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

        #endregion

        #region 写资料

        public long WriteRecord(string recId,
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
                return this.Delete(recId);
            }



            return 0;
        }

        public int AddRecord(string xml,
            out string outputRecId,
            out string error)
        {
            error = "";
            outputRecId = "";

            // 写记录体，先直接把文体转成二进制，后面要改进
            byte[] bXml = System.Text.Encoding.UTF8.GetBytes(xml);

            Record record = new Record();
            record.recId = Guid.NewGuid().ToString();
            record.data = bXml;
            record.timespan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss" + this.GetTimestampSeed());


            this.RecordCollection.InsertOne(record);

            outputRecId = record.recId;

            // 写扩展字段
            this.CreateExtension(xml);

            // 写keys文件
            List<KeyItem> keyList= this.BuildKeys(xml, record.recId);



            this.WriteKeys(keyList);

            return 0;
        }

        // todo
        public void WriteBinary()
        {

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        public virtual long Delete(String recId)
        {
            var filter = Builders<Record>.Filter.Eq("recId", recId);
            DeleteResult ret = this.RecordCollection.DeleteOne(filter);
            return ret.DeletedCount;
        }


        #endregion

        public void WriteKeys(List<KeyItem> keyList)
        {
            foreach (KeyItem keyItem in keyList)
            {
                string collName = "keys_" + keyItem.from;
                IMongoCollection<KeyItem> coll= this.Database.GetCollection<KeyItem>(collName);

                coll.InsertOne(keyItem);
            }
        }


        





 



        public virtual void CreateExtension(string xm)
        {


        }

        public virtual List<KeyItem>  BuildKeys(string xm, string recId)
        {
            return new List<KeyItem>();
        }


        public virtual void WriteKey(string recId,
            string from,
            List<string> akey)
        {
            
        }

        #region 检索

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

        // 检索
        public int Search(string word,
            int maxCount,
            string from,
            string match,
            out List<string> idList,
            out string error)
        {
            idList = new List<string>();
            error = "";
            string tableName = "keys_" + from.Trim(); // 这里再去一下空格，前面因为传进来的from多了一个空，怎么也查不出来数据 20180602
            IMongoCollection<KeyItem> collection = this.Database.GetCollection<KeyItem>(tableName);// "keys_title");

            //mongodb client写法 db.keys_title.find({keystring:{$regex:"庵传"}})  
            string value = "驼庵";
            // 下面两种写法都可以
            //var filter = Builders<KeyItem>.Filter.Regex(f => f.keystring, new BsonRegularExpression(new Regex(value)));
            var filter = Builders<KeyItem>.Filter.Regex(f => f.keystring, "/"+value+"/");
            var result = collection.Find(filter).ToList() ;
            foreach (KeyItem item in result)
            {
                idList.Add(item.ToJson());  // id要去重 todo
            }

            // 这两种方法有空也试试
            //var filterRegex = Builders<KeyItem>.Filter.Regex("keystring", new BsonRegularExpression("驼庵"));
            //var filter = new BsonDocument {{ parameterName, new BsonDocument { { "$regex", value }, { "$options", "i" } } } }
            
            return 0;
        }

        #endregion



    }


}
