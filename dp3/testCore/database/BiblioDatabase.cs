
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace testCore.database
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


        IMongoCollection<BiblioItem> _collection = null;
        public IMongoCollection<BiblioItem> Collection
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
            this._collection = this._database.GetCollection<BiblioItem>("item");

            //todo
            // 创建索引            
        }

        #region 同步方法

        public  void InitData()
        {
            for (int i = 0; i < 3; i++)
            {
                BiblioItem biblio = new BiblioItem();
                biblio.no = i.ToJson();
                biblio.isbnList = new List<ISBNItem>();

                ISBNItem i1 = new ISBNItem();
                i1.isbn = "978-7-5346-5814-3";
                i1.terms = "CYN10.00";
                biblio.isbnList.Add(i1);

                ISBNItem i2 = new ISBNItem();
                i2.isbn = i.ToString();
                i2.terms = "CYN20.00";
                biblio.isbnList.Add(i2);

                this.Add(biblio);
            }

        }

        // 删除数据库
        public void Drop()
        {
            this._database.DropCollection("item");
        }

        // 根据id查询
        public BiblioItem GetById(string id)
        {
            if (string.IsNullOrEmpty(id) == true)
                return null;

            var filter = Builders<BiblioItem>.Filter.Eq("id", id);

            List<BiblioItem> list = this.Collection.Find(filter).ToList();
            if (list.Count > 0)
            {
                BiblioItem item = list[0];
                return item;
            }
            
            return null;
        }

        // 这个函数不适用，返回的下级文档，需要返回上级文档，采用FindByElem()
        public ISBNItem FindIsbn()
        {
            return this.Collection.AsQueryable()  //转换为Queryable
                .SelectMany(s => s.isbnList) // 选择isbnList内嵌数组                                          
                .Where(r => r.isbn == "123" && r.terms == "CYN20.00")  // 满足isbn与价格                                               
                .FirstOrDefault();// 取第一个
        }

        // 下级文档满足两个条件，返回上级文档
        public string FindByElem()
        {
            var collection = this._database.GetCollection<BsonDocument>("item");

            var subFilter = Builders<ISBNItem>.Filter.Eq("isbn", "1") 
                & Builders<ISBNItem>.Filter.Eq("terms", "CYN20.00");

            var filter = Builders<BiblioItem>.Filter.And(Builders<BiblioItem>.Filter.ElemMatch("isbnList", subFilter));

            var result = this.Collection.Find(filter).ToList();
            return result.ToJson();
        }

        // 获取全部
        public List<BiblioItem> GetAll()
        {
            return this.Collection.Find(new BsonDocument()).ToList();
        }

        public string GetAllString()
        {
            List<BiblioItem> biblios = this.Collection.Find(new BsonDocument()).ToList();

            string s = "";
            foreach (BiblioItem b in biblios)
            {
                s+=b.ToJson()+"\r\n";
            }
            return s;
        }

        // 新增
        public void Add(BiblioItem item)
        {
             this.Collection.InsertOne(item);
        }

        // 更新
        public long Update(BiblioItem item)
        {
            var filter = Builders<BiblioItem>.Filter.Eq("id", item.id);
            var update = Builders<BiblioItem>.Update
                .Set("isbnList", item.isbnList)
                ;

             return this.Collection.UpdateOne(filter, update).ModifiedCount;
        }


        // 删除
        public long Delete(String id)
        {
            var filter = Builders<BiblioItem>.Filter.Eq("id", id);
            return this.Collection.DeleteOne(filter).DeletedCount;

            
        }

        #endregion

        #region 异步方法

        // 获取全部
        public async Task GetAllAsync()
        {
            await this.Collection.FindAsync(new BsonDocument());
        }

        // 新增 异步
        public async Task AddAsync(BiblioItem item)
        {
            await this.Collection.InsertOneAsync(item);
        }

        // 更新 异步
        public async Task UpdateAsync(BiblioItem item)
        {
            var filter = Builders<BiblioItem>.Filter.Eq("id", item.id);
            var update = Builders<BiblioItem>.Update
                .Set("isbnList", item.isbnList)
                ;

            await this.Collection.UpdateOneAsync(filter, update);
        }


        // 删除 异步
        public async Task DeleteAsync(String id)
        {
            var filter = Builders<BiblioItem>.Filter.Eq("id", id);
            await this.Collection.DeleteOneAsync(filter);
        }

        #endregion
    }


}
