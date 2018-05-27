using dp3.standard;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            string recId = this.textBox_source_fileName.Text.Trim();

            string info = "";
            string error = "";
            int nRet = DbWrapper.Instance.GetRes("biblio", recId, out info, out error);
            if (nRet == -1)
            {
                MessageBox.Show(this, error);
                return;
            }

            this.textBox_xml.Text = info;
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            string recId = this.textBox_source_fileName.Text.Trim();

            if (string.IsNullOrEmpty(recId) == true)
            {
                MessageBox.Show(this, "尚未输入id");
                return;
            }

            string error = "";
            long lRet = DbWrapper.Instance.DeleteRes("biblio", recId, out error);
            if (lRet == -1)
            {
                MessageBox.Show(this, "出错：" + error);
                return;
            }

            MessageBox.Show(this, "ok");
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            string fileName = this.textBox_source_fileName.Text;
            string strError = "";
            int nRet = ImportBdf.DoImport(fileName,
                out strError);
            if (nRet == -1)
            {
                MessageBox.Show(this, "出错:" + strError);
                return;
            }

            MessageBox.Show(this, "导入成功" + nRet + "条");
        }

        private void button_findFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "请指定要打开的书目转储文件名";
            dlg.FileName = this.textBox_source_fileName.Text;
            // dlg.InitialDirectory = 
            dlg.Filter = "书目转储文件 (*.bdf)|*.bdf|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            this.textBox_source_fileName.Text = dlg.FileName;



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
            else
            {
                MessageBox.Show(this, "初始化完成");
            }


        }


    }
}
