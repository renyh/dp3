using dp3.xml;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace dp3.kernel
{
    public class DbWrapper
    {
        #region 常量
        public const string C_db_biblio = "biblio";
        public const string C_db_item = "item";
        #endregion

        #region 单一实例

        static DbWrapper _instance;
        private DbWrapper()
        {
        }
        private static object _lock = new object();
        public static DbWrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)  //线程安全的
                    {
                        _instance = new DbWrapper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        // 数据库连接字符串，根据datasoure解析，目前只支持mongodb
        public string Connection = "";
        // mongodb client
        public MongoClient MClient { get; set; }

        // 检索点最大长度，超过此长度要截取，前期先不考虑
        private int keysize;

        private BiblioDatabase BiblioDb = null;
        private EntityDatabase EntityDb = null;

        // 初始化
        public int Init(string configFile,
            out string error)
        {
            error = "";

            // 解析xml
            XmlDocument dom = new XmlDocument();
            try
            {
                dom.Load(configFile);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
            XmlNode root = dom.DocumentElement;
            /*
             <root>
              <datasource servertype="mognodb" servername="mongodb://localhost:27017"  userid="" password=""  />
              <keysize>255</keysize>
              <db name="bible" idrule='guid' seed='1' />
              <db name="entity" idrule='guid' seed='1'/>
            </root>
             */
            this.Connection = DomUtil.GetElementAttr(root, "datasource", "servername");
            this.MClient = new MongoClient(this.Connection);

            string keysizeStr = DomUtil.GetElementText(root, "keysize");
            this.keysize = Convert.ToInt32(keysize);

            XmlNodeList dbList = root.SelectNodes("db");
            foreach (XmlNode node in dbList)
            {
                string name = DomUtil.GetElementAttr(node, "", "name");
                if (name == "biblio")
                {
                    this.BiblioDb = new BiblioDatabase(node);
                }
                else if (name == "entity")
                {
                    this.EntityDb = new EntityDatabase(node);
                }
                else
                {
                    // 不支持的数据库类型
                }
            }

            return 0;
        }

        public void DropDatabase(string dbName)
        {
            this.MClient.DropDatabase(dbName);
        }

        // dbname是固定值
        public long WriteRes(string dbName,
            string recId,
            string xml,
            string opeType,    //操作类型，定义相应常量
            out string outputRecId,
            out string error)
        {
            error = "";
            outputRecId = "";

            if (dbName == "entity")
            {
                if (this.EntityDb == null)
                {
                    error = "未定义册库";
                    return -1;
                }
                return this.EntityDb.WriteRecord(recId,
                    xml,
                    opeType,
                    out outputRecId,
                    out error);
            }
            else if (dbName == "biblio")
            {
                if (this.BiblioDb == null)
                {
                    error = "未定义书目库";
                    return -1;
                }
                return this.BiblioDb.WriteRecord(recId,
                    xml,
                    opeType,
                    out outputRecId,
                    out error);
            }
            else
            {
                error = "不支持的数据库名称";
                return -1;
            }
        }

        public BaseDatabase GetDb(string dbName)
        {
            if (dbName == "biblio")
            {
                return this.BiblioDb;
            }
            else if (dbName == "entity")
            {
                return this.EntityDb;
            }
            return null;
        }

        public int GetRes(string dbName, 
            string recId,
            out string info,
            out string error)
        {
            info = "";
            error = "";

            BaseDatabase db = this.GetDb(dbName);
            if (db == null)
            {
                error = "未找到["+dbName+"]对应的数据库";
                return -1;
            }

            List<Record> list = new List<Record>();
            if (string.IsNullOrEmpty(recId) == false)
            {
                Record rec = db.GetByRecId(recId);
                if (rec != null)
                    list.Add(rec);
            }
            else
            {
                list = db.GetAll();
            }

            StringBuilder sb = new StringBuilder();
            foreach (Record rec in list)
            {
                sb.AppendLine(rec.recId);
                sb.AppendLine(rec.timespan);
                string s = Encoding.UTF8.GetString(rec.data);
                sb.AppendLine(s);
                sb.AppendLine("===========");

                    
            }

            info = sb.ToString();


            return 0;  //todo
        }


        // 获取检索途径
        public List<string> GetFroms(string dbName)
        {
            List<string> list = new List<string>();

            BaseDatabase db = this.GetDb(dbName);

            foreach (KeyCfgItem item in db.KeyCfgList)
            {
                
                list.Add(item.Caption + " " + item.From);

            }
            return list;
        }


        // 删除记录
        public long DeleteRes(string dbName,
            string recId,
            out string error)
                {
                    error = "";

                    BaseDatabase db = this.GetDb(dbName);
                    if (db == null)
                    {
                        error = "未找到[" + dbName + "]对应的数据库";
                        return -1;
                    }

                    long lRet = db.Delete(recId);

                    return lRet;


                }




        // 生成检索点
        public List<KeyItem> BuildKeys(string dbName,
            string xml,
            string recId)
        {
            BaseDatabase db = this.GetDb(dbName);

            return db.BuildKeys(xml,recId);
        }

        // 检索
        public int Search(string dbName,
            string word, 
            int maxCount,
            string from,
            string match,
            out List<string> idList,
            out string error)
        {
            error = "";
            idList = new List<string>();
            BaseDatabase db = this.GetDb(dbName);

            return db.Search(word,
                maxCount,
                from,
                match,
                out idList,
                out error);
        }
    }
}
