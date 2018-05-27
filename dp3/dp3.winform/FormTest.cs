using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dp3.winform
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // MongoDB连接字符串
            string connectionString = "mongodb://localhost:27017";
            BiblioDatabase1.Current.Open(connectionString, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["Type"] = "GET";
                client.Headers["Accept"] = "application/json";
                client.Encoding = Encoding.UTF8;
                client.DownloadStringCompleted += (senderobj, es) =>
                {
                    var obj = es.Result;
                };
                byte[] ba=  client.DownloadData("http://localhost:61326/api/records/1");

                string text=System.Text.Encoding.Default.GetString(ba);

                MessageBox.Show(this,"["+ text+"]");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s=SClass.Test();
            MessageBox.Show(s);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            BiblioDatabase1.Current.InitData();
            MessageBox.Show(this,"初始化数据完成");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = BiblioDatabase1.Current.GetAllString();
            this.textBox1.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BiblioDatabase1.Current.Drop();
            MessageBox.Show(this, "dropcoll完成");
        }


    }
}
