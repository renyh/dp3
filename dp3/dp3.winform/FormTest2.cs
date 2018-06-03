using dp3.kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dp3.winform
{
    public partial class FormTest2 : Form
    {


        public FormTest2()
        {
            InitializeComponent();
        }

        private void button_init_Click(object sender, EventArgs e)
        {
            // 先把配置文件放在应用程序里，后面再放到另外的数据目录里。
            string dir = Application.StartupPath;
            string configFile = dir + "\\" + "dbconfig.xml";

            string error = "";
            int nRet = DbWrapper.Instance.Init(configFile, out error);
            if (nRet == -1)
            {
                MessageBox.Show(this, error);
            }
            
        }


        private void button_add_Click(object sender, EventArgs e)
        {
            string dbName = this.textBox_db.Text.Trim();
            if (string.IsNullOrEmpty(dbName) == true)
            {
                MessageBox.Show(this, "尚未输入库名");
            }

            string xml = this.textBox_xml.Text.Trim();
            if (string.IsNullOrEmpty(xml) == true)
            {
                MessageBox.Show(this, "尚未输入xml");
            }

            string error = "";
            string outputRecId = "";
            int nRet = DbWrapper.Instance.WriteRes(dbName,
                "",  //recId
                xml,
                "add",  //操作类型
                out outputRecId, //返回的新增记录id
                out error);
            if (nRet == 0)
            {
                this.textBox_path.Text = outputRecId;
                MessageBox.Show("保存成功");
            }
            else if (nRet==-1)
            {
                MessageBox.Show("出错：" + error);
            }
        }



        private void button_load_Click(object sender, EventArgs e)
        {

        }

        private void button_del_Click(object sender, EventArgs e)
        {

        }

       

        private void FormTest2_Load(object sender, EventArgs e)
        {

        }
    }
}
