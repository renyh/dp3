using System;
using System.Collections.Generic;
using System.Text;

namespace dp3.standard
{
    /*
     <root>
      <datasource servertype="mognodb" servername="mongodb://localhost:27017"  userid="" password=""  />
      <keysize>255</keysize>
      <biblio idrule='guid' seed='1'/>
      <entity idrule='guid' seed='1'/>
    </root>
     */

    public class DbWrapper
    {
        // 数据库连接字符串，根据datasoure解析，目前只支持mongodb
        private string Connection = "";
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

            // 打开数据库
            

            return 0;
        }


        // 写一条册记录
        public int WriteEntity(string xml,
            out string error)
        {
            error = "";
            if (this.EntityDb == null)
            {
                error = "未定义册库";
                return -1;
            }

            return this.EntityDb.WriteRecord(xml, out error);

        }

    }
}
