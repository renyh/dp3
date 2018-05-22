using System;
using System.Collections.Generic;
using System.Text;

namespace testCore.database
{
    // 题名与责任者说明
    // 不重复
    // UNIMARC: 200
    // USMARC：245 
    public class TitleItem
    {
        // 正题名 Title
        // UNIMARC: 200$a
        // USMARC：245$a
        // 必备，200$a可重复，245$a不可重复
        // UNIMARC可重复的时候，是单个子字段重复，还是与其它子字段要成对重复？
        public List<string> title { get; set; }


        // 其它责任者的正题名，该用个什么单词作为字段名呢？
        // UNIMARC: 200$c
        // USMARC：怎么对应？
        // 可重复
        public List<string> 其它责任者的正题名 { get; set; }

        // 并列正题名，该用个什么单词作为字段名呢？
        // UNIMARC: 200$d
        // USMARC：怎么对应？
        // 可重复
        public List<string> 并列正题名 { get; set; }


        // 其它题名信息，Remainder of title
        // UNIMARC: 200$e
        // USMARC：245$b? 编目老师说不一同对应
        // 200$e可重复，245$b不可重复
        public List<string> remainderTitle { get; set; }

        // 一般资料标识，该用个什么单词作为字段名呢？
        // UNIMARC: 200$b
        // USMARC：没有此字段？
        // 可重复
        public List<string> 一般资料标识 { get; set; }

        // 主要责任者说明，Statement of responsibility, etc.
        // UNIMARC: 200$f
        // USMARC：245$c？
        // 200$f可重复,245$c不可重复
        // 是单个重复，还是与其它子字段成对配套重复
        public List<string> responsibility { get; set; }


        // 其它责任者说明，Remainder of responsibility
        // UNIMARC: 200$g
        // USMARC：没有此字段？
        // 可重复
        public List<string> remainderResponsibility{ get; set; }

        // 分辑（册）、章节号，Number of part/section of a work
        // UNIMARC: 200$h
        // USMARC：245$n
        // 可重复
        public List<string>  volumeNo{ get; set; }

        // 分辑（册）、章节名称，Name of part/section of a work
        // UNIMARC: 200$i
        // USMARC：245$p
        // 可重复
        public List<string> volumeName { get; set; }
    }
}
