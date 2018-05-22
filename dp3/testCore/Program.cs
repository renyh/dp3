using System;
using System.Collections.Generic;
using testCore.database;

namespace testCore
{
    class Program
    {
        // 主函数
        static void Main(string[] args)
        {
            // MongoDB连接字符串
            string connectionString = "mongodb://localhost:27017";
            BiblioDatabase.Current.Open(connectionString, "");

            Console.WriteLine("请输入命令，help查看命令");

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    return;
                }
                if (cmd == "init")
                {
                    BiblioDatabase.Current.InitData();
                    Console.WriteLine("初始化数据完成");
                }
                else if (cmd == "dropdbs")
                {
                    dbs.dropDbs();
                }
                else if (cmd == "find")
                {
                    string s = BiblioDatabase.Current.GetAllString();
                    Console.WriteLine("result:" + s);
                }
                else if (cmd == "dropcoll")
                {
                    BiblioDatabase.Current.Drop();
                    Console.WriteLine("dropcoll完成");
                }
                else if (cmd == "elem")
                {
                    string s = BiblioDatabase.Current.FindByElem();
                    Console.WriteLine("result:" + s);
                }
                else if (cmd == "upload")
                {
                    GridFS.UploadFile();
                    Console.WriteLine("完成");
                }
                else if (cmd == "download")
                {
                    GridFS.DownloadFile();
                    Console.WriteLine("完成");
                }
                else if (cmd == "help")
                {
                    string s = "exit:退出"
                        + "\r\n" + "init:初始数据"
                        + "\r\n" + "find:获取全部数据"
                        + "\r\n" + "elem:测试emelMatch的例子"
                        + "\r\n" + "dropcoll:删除数据库"
                        + "\r\n" + "upload:上传文件"
                        + "\r\n" + "download:下载文件"
                        + "\r\n" + "dropdbs:清除无用的数据库"
                        ;
                    Console.WriteLine(s);

                }
                else
                {
                    Console.WriteLine("不支持的命令" + cmd);
                }
            }

        }





    }
}
