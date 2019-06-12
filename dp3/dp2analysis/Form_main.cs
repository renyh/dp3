using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dp2analysis
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void dp2服务器配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Setting dlg = new Form_Setting();
            dlg.ShowDialog(this);
        }
    }
}
