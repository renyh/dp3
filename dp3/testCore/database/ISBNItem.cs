using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.database
{
    // 国际标准书号 International Standard Book Number  
    // 可重复
    // UNIMARC: 010
    // USMARC：020
    public class ISBNItem
    {
        // 国际标准书号 International Standard Book Number 
        // UNIMARC: 010$a
        // USMARC：020$a
        // 有则必备，不可重复
        public string isbn { get; set; }

        // 文献获得方式和/或价格 Terms of availability
        // UNIMARC: 010$d
        // USMARC：020$c
        // 有则必备，不可重复
        public string terms { get; set; }

        // 限定，一般为出版信息
        // UNIMARC：010$b
        // USMARC:没有此字段？
        // 有则必备，不可重复
        public string limit { get; set; }

        // 错误或无效的ISBN Canceled/invalid ISBN (R)
        // UNIMARC: 010$z
        // USMARC：010$z
        // 可重复
        public List<string> invalidISBN { get; set; }


        // 将信息组成字符串输出
        public string Dump()
        {
            StringBuilder s = new StringBuilder();
            return s.ToString();
        }
    }
}
