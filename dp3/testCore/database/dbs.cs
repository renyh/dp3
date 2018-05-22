using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.database
{
    public class dbs
    {
        public static void dropDbs()
        {
            string conn = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(conn);

            var dbList = client.ListDatabases().ToList();

            List<string> deleteNames = new List<string>();
            Console.WriteLine("The list of databases are :");
            foreach (var item in dbList)
            {
                string dbName = item.GetValue("name").ToString();

                if (dbName.IndexOf("wx_") != -1 || dbName.IndexOf("mserver_") != -1)
                    continue;

                //Console.WriteLine(dbName);
                deleteNames.Add(dbName);
            }

            foreach(string s in deleteNames)
            {
                client.DropDatabase(s);
            }

        }
    }
}
