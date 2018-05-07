
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCore.Entity
{
    /// <summary>
    /// 用户数据库
    /// </summary>
    public sealed class BiblioDatabase
    {
        // 饿汉模式
        private static readonly BiblioDatabase _db = new BiblioDatabase();
        public static BiblioDatabase Current
        {
            get
            {
                return _db;
            }
        }

        // 成员变量
        MongoClient _mongoClient = null;
        IMongoDatabase _database = null;
        string _dbName = "";


        IMongoCollection<Biblio> _collection = null;
        public IMongoCollection<Biblio> Collection
        {
            get
            {
                return this._collection;
            }
        }

        // 初始化
        public void Open(string strMongoDbConnStr,
            string strInstancePrefix)
        {
            if (string.IsNullOrEmpty(strMongoDbConnStr) == true)
                throw new ArgumentException("strMongoDbConnStr 参数值不应为空");

            if (string.IsNullOrEmpty(strInstancePrefix) == false)
                strInstancePrefix = strInstancePrefix + "_";
            this._dbName = strInstancePrefix + "biblio";

            this._mongoClient = new MongoClient(strMongoDbConnStr);
            this._database = this._mongoClient.GetDatabase(this._dbName);
            this._collection = this._database.GetCollection<Biblio>("item");

            //todo
            // 创建索引            
        }

        // 根据id查询
        public Biblio GetById(string id)
        {
            if (string.IsNullOrEmpty(id) == true)
                return null;

            var filter = Builders<Biblio>.Filter.Eq("id", id);

            List<Biblio> list = this.Collection.Find(filter).ToList();
            if (list.Count > 0)
            {
                Biblio item = list[0];               
                return item;
            }
            return null;
        }

        // 获取全部
        public List<Biblio> GetAll()
        {
            List<Biblio> list  =this.Collection.Find(new BsonDocument()).ToListAsync().Result;
            return list;
        }

        // 新增
        public async Task Add(Biblio item)
        {
            await this.Collection.InsertOneAsync(item);
        }

        // 更新
        public async Task Update(Biblio item)
        {
            var filter = Builders<Biblio>.Filter.Eq("id", item.id);
            var update = Builders<Biblio>.Update
                .Set("identifiers", item.identifiers)
                ;

            await this.Collection.UpdateOneAsync(filter, update);
        }


        // 删除
        public async Task Delete(String id)
        {
            var filter = Builders<Biblio>.Filter.Eq("id", id);
            await this.Collection.DeleteOneAsync(filter);
        }

    }


}
