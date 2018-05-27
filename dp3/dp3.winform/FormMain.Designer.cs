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
            this.button_import = new System.Windows.Forms.Button();
            this.button_findFile = new System.Windows.Forms.Button();
            this.textBox_source_fileName = new System.Windows.Forms.TextBox();
            this.textBox_xml = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_init = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(8, 84);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(79, 33);
            this.button_import.TabIndex = 14;
            this.button_import.Text = "import";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // button_findFile
            // 
            this.button_findFile.Location = new System.Drawing.Point(499, 47);
            this.button_findFile.Name = "button_findFile";
            this.button_findFile.Size = new System.Drawing.Size(75, 33);
            this.button_findFile.TabIndex = 13;
            this.button_findFile.Text = "...";
            this.button_findFile.UseVisualStyleBackColor = true;
            this.button_findFile.Click += new System.EventHandler(this.button_findFile_Click);
            // 
            // textBox_source_fileName
            // 
            this.textBox_source_fileName.Location = new System.Drawing.Point(8, 53);
            this.textBox_source_fileName.Name = "textBox_source_fileName";
            this.textBox_source_fileName.Size = new System.Drawing.Size(485, 25);
            this.textBox_source_fileName.TabIndex = 12;
            // 
            // textBox_xml
            // 
            this.textBox_xml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_xml.Location = new System.Drawing.Point(8, 124);
            this.textBox_xml.Multiline = true;
            this.textBox_xml.Name = "textBox_xml";
            this.textBox_xml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_xml.Size = new System.Drawing.Size(685, 312);
            this.textBox_xml.TabIndex = 15;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(105, 84);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(79, 33);
            this.button_load.TabIndex = 16;
            this.button_load.Text = "load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(205, 84);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(79, 33);
            this.button_del.TabIndex = 17;
            this.button_del.Text = "delete";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_init
            // 
            this.button_init.Location = new System.Drawing.Point(8, 12);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(154, 32);
            this.button_init.TabIndex = 18;
            this.button_init.Text = "数据库初始化";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 448);
            this.Controls.Add(this.button_init);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.textBox_xml);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.button_findFile);
            this.Controls.Add(this.textBox_source_fileName);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.Button button_findFile;
        private System.Windows.Forms.TextBox textBox_source_fileName;
        private System.Windows.Forms.TextBox textBox_xml;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_init;
    }
}