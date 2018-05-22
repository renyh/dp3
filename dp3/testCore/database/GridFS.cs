using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace testCore.database
{
    class GridFS
    {


        // 给ＭongoDB的GridFS中写入文件
        public static ObjectId UploadFile()
        {
            string conn = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(conn);
            var database = client.GetDatabase("TestDB");
            var fs = new GridFSBucket(database);

            

            using (var s = File.OpenRead(@"C:\0-d\\myimg.png"))
            {
                var t = Task.Run<ObjectId>(() => {
                    return  fs.UploadFromStreamAsync("test.txt", s);
                });
                return t.Result;
            }
        }

        // 从ＭongoDB的GridFS中读取文件
        public static void DownloadFile()
        {
            string conn = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(conn);
            var database = client.GetDatabase("TestDB");
            var fs = new GridFSBucket(database);

            var t = fs.DownloadAsBytesByNameAsync("test.txt");
            Task.WaitAll(t);
            var bytes = t.Result;
        }

    }
}
