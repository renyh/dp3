namespace dp3.winform
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_findFile = new System.Windows.Forms.Button();
            this.textBox_source_fileName = new System.Windows.Forms.TextBox();
            this.textBox_xml = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_init = new System.Windows.Forms.Button();
            this.button_buildKeys = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.comboBox_from = new System.Windows.Forms.ComboBox();
            this.textBox_word = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_ext = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_findFile
            // 
            this.button_findFile.Location = new System.Drawing.Point(197, 36);
            this.button_findFile.Name = "button_findFile";
            this.button_findFile.Size = new System.Drawing.Size(136, 33);
            this.button_findFile.TabIndex = 13;
            this.button_findFile.Text = "导入bdf文件";
            this.button_findFile.UseVisualStyleBackColor = true;
            this.button_findFile.Click += new System.EventHandler(this.button_findFile_Click);
            // 
            // textBox_source_fileName
            // 
            this.textBox_source_fileName.Location = new System.Drawing.Point(14, 14);
            this.textBox_source_fileName.Name = "textBox_source_fileName";
            this.textBox_source_fileName.Size = new System.Drawing.Size(413, 25);
            this.textBox_source_fileName.TabIndex = 12;
            // 
            // textBox_xml
            // 
            this.textBox_xml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_xml.Location = new System.Drawing.Point(14, 55);
            this.textBox_xml.Multiline = true;
            this.textBox_xml.Name = "textBox_xml";
            this.textBox_xml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_xml.Size = new System.Drawing.Size(512, 510);
            this.textBox_xml.TabIndex = 15;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(433, 7);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(55, 35);
            this.button_load.TabIndex = 16;
            this.button_load.Text = "加载";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_del
            // 
            this.button_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_del.Location = new System.Drawing.Point(75, 580);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(55, 33);
            this.button_del.TabIndex = 17;
            this.button_del.Text = "删除";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_init
            // 
            this.button_init.Location = new System.Drawing.Point(24, 36);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(154, 32);
            this.button_init.TabIndex = 18;
            this.button_init.Text = "初始化数据库";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // button_buildKeys
            // 
            this.button_buildKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_buildKeys.Location = new System.Drawing.Point(136, 580);
            this.button_buildKeys.Name = "button_buildKeys";
            this.button_buildKeys.Size = new System.Drawing.Size(113, 33);
            this.button_buildKeys.TabIndex = 19;
            this.button_buildKeys.Text = "观察检索点";
            this.button_buildKeys.UseVisualStyleBackColor = true;
            this.button_buildKeys.Click += new System.EventHandler(this.button_buildKeys_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_save.Location = new System.Drawing.Point(14, 580);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(55, 33);
            this.button_save.TabIndex = 20;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_from
            // 
            this.comboBox_from.FormattingEnabled = true;
            this.comboBox_from.Location = new System.Drawing.Point(15, 133);
            this.comboBox_from.Name = "comboBox_from";
            this.comboBox_from.Size = new System.Drawing.Size(178, 23);
            this.comboBox_from.TabIndex = 21;
            this.comboBox_from.SelectedIndexChanged += new System.EventHandler(this.comboBox_from_SelectedIndexChanged);
            // 
            // textBox_word
            // 
            this.textBox_word.Location = new System.Drawing.Point(199, 131);
            this.textBox_word.Name = "textBox_word";
            this.textBox_word.Size = new System.Drawing.Size(335, 25);
            this.textBox_word.TabIndex = 22;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(540, 129);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(71, 27);
            this.button_search.TabIndex = 23;
            this.button_search.Text = "search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_init);
            this.groupBox1.Controls.Add(this.button_findFile);
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 91);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统管理";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(15, 175);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(611, 390);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "id";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_from);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_word);
            this.splitContainer1.Panel1.Controls.Add(this.button_search);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_ext);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_source_fileName);
            this.splitContainer1.Panel2.Controls.Add(this.button_save);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_xml);
            this.splitContainer1.Panel2.Controls.Add(this.button_buildKeys);
            this.splitContainer1.Panel2.Controls.Add(this.button_load);
            this.splitContainer1.Panel2.Controls.Add(this.button_del);
            this.splitContainer1.Size = new System.Drawing.Size(1205, 629);
            this.splitContainer1.SplitterDistance = 644;
            this.splitContainer1.TabIndex = 26;
            // 
            // button_ext
            // 
            this.button_ext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ext.Location = new System.Drawing.Point(255, 580);
            this.button_ext.Name = "button_ext";
            this.button_ext.Size = new System.Drawing.Size(113, 33);
            this.button_ext.TabIndex = 21;
            this.button_ext.Text = "观察扩展字段";
            this.button_ext.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 629);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_findFile;
        private System.Windows.Forms.TextBox textBox_source_fileName;
        private System.Windows.Forms.TextBox textBox_xml;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Button button_buildKeys;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ComboBox comboBox_from;
        private System.Windows.Forms.TextBox textBox_word;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button_ext;
    }
}