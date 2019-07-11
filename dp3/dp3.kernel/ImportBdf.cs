using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace dp3.kernel
{
    public class ImportBdf
    {
        /* 文件头部结构
<?xml version="1.0" encoding="utf-8"?>
<dprms:collection xmlns:dprms="http://dp2003.com/dprms">
<dprms:record>
 <dprms:biblio path="net.pipe://localhost/dp2library/xe?中文图书/10" timestamp="c95606aac8ecd2080000000000000000">
     <unimarc:record xmlns:dprms="http://dp2003.com/dprms" xmlns:unimarc="http://dp2003.com/UNIMARC">
         <unimarc:leader>00827nam0 2200229   45  </unimarc:leader>
         <unimarc:controlfield tag="001">0192000006</unimarc:controlfield>
  ...
  * */

        // 导入bdf文件
        public static int DoImport(string strSourceFileName,
            out string strError)
        {
            strError = "";
            bool bRet = false;

            int count = 0;
            try
            {

                // 用 FileStream 方式打开，主要是为了能在中途观察进度
                using (FileStream file = File.Open(strSourceFileName,
                    FileMode.Open,
                    FileAccess.Read))
                using (XmlTextReader reader = new XmlTextReader(file))
                {
                    // 到根元素
                    while (true)
                    {
                        bRet = reader.Read();
                        if (bRet == false)
                        {
                            strError = "没有根元素";
                            goto ERROR1;
                        }
                        if (reader.NodeType == XmlNodeType.Element)
                            break;
                    }

                    for (; ; )
                    {
                        // todo 中断

                        // 到下一个 record 元素，record包含biblio和下级记录
                        while (true)
                        {
                            bRet = reader.Read();
                            if (bRet == false)
                                break;
                            if (reader.NodeType == XmlNodeType.Element)
                                break;
                        }

                        if (bRet == false)
                            break;	// 结束

                        // 处理一个recrod
                        DoRecord(reader);

                        // 记录条数
                        count++;
                    }
                }

            }
            catch (Exception ex)
            {
                strError = "导入过程出现异常" + ex.Message;
                goto ERROR1;
            }

            // 返回导入条数
            return count;

            ERROR1:
            return -1;
        }

        /* 结构
<dprms:record>
    <dprms:biblio path="net.pipe://localhost/dp2library/xe?中文图书/10" timestamp="c95606aac8ecd2080000000000000000">
 ...
    </dprms:biblio>
    <dprms:orderCollection>
            <dprms:order path="中文图书订购/1" timestamp="5bfd16621a18d3080000000000000003">
            ...
 * */
        // 处理一个 dprms:record 元素
        static void DoRecord(XmlTextReader reader)
        {
            bool bSkip = true;// 跳过下级记录

            // 对下级元素进行循环处理
            while (true)
            {
                bool bRet = reader.Read();
                if (bRet == false)
                    return;

                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    Debug.Assert(reader.LocalName == "record", "结果节点应该是record");
                    return;
                }

                if (reader.NodeType == XmlNodeType.Element)
                {
                    // biblio 元素
                    // 应当是同级元素中的第一个。因为后面写入册记录等需要知道书目记录的实际写入路径
                    if (reader.LocalName == "biblio")
                    {
                        //return:
                        //true    书目记录已经处理。需要继续处理后面的下级记录
                        //false   书目记录不需要处理，应跳过后面的下级记录
                        bSkip = !DoBiblio(reader);
                    }
                    else if (reader.LocalName == "orderCollection"
                        || reader.LocalName == "itemCollection"
                        || reader.LocalName == "issueCollection"
                        || reader.LocalName == "commentCollection")
                    {
                        if (bSkip)
                        {
                            reader.ReadOuterXml();
                        }
                        else
                        {
                            //DoItemCollection(reader, info); // 搜集 item xmls
                        }
                    }
                    else
                    {
                        throw new Exception("无法识别的 dprms:record 下级元素名 '" + reader.Name + "'");
                    }
                }
            }
        }

        /*
<dprms:biblio path="net.pipe://localhost/dp2library/xe?中文图书/10" timestamp="c95606aac8ecd2080000000000000000">
    <unimarc:record xmlns:dprms="http://dp2003.com/dprms" xmlns:unimarc="http://dp2003.com/UNIMARC">
        <unimarc:leader>00827nam0 2200229   45  </unimarc:leader>
        <unimarc:controlfield tag="001">0192000006</unimarc:controlfield>
 * */
        // return:
        //      true    书目记录已经处理。需要继续处理后面的下级记录
        //      false   书目记录不需要处理，应跳过后面的下级记录
        static bool DoBiblio(XmlTextReader reader)
        {
            XmlDocument dom = new XmlDocument();
            XmlElement root = dom.ReadNode(reader) as XmlElement;

            string SourceBiblioRecPath = root.GetAttribute("path");
            string strPath = GetShortPath(SourceBiblioRecPath);

            string strTimestamp = root.GetAttribute("timestamp");
            string biblioXml = root.InnerXml;

            // 创建或者覆盖书目记录
            string strError = "";
            string strOutputPath = "";

            long lRet = DbWrapper.Instance.WriteRes("biblio",
                "",
                biblioXml,
                "add",
                out strOutputPath,
                out strError);
            if (lRet == -1)
            {
                strError = "保存书目记录 '" + strPath + "' 时出错: " + strError;
            }

            string strBiblioRecPath = strOutputPath;
            return true;
        }



        // 
        // parammeters:
        //      strPath 路径。例如"中文图书/3"
        /// <summary>
        /// 从路径中取出库名部分
        /// </summary>
        /// <param name="strPath">路径。例如"中文图书/3"</param>
        /// <returns>返回库名部分</returns>
        public static string GetDbName(string strPath)
        {
            int nRet = strPath.LastIndexOf("/");
            if (nRet == -1)
                return strPath;

            return strPath.Substring(0, nRet).Trim();
        }

        static string GetShortPath(string strPath)
        {
            if (string.IsNullOrEmpty(strPath))
                return "";
            int nRet = strPath.IndexOf("?");
            if (nRet == -1)
                return strPath;
            return strPath.Substring(nRet + 1);
        }



    }
}
