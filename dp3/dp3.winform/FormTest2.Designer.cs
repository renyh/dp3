namespace dp3.winform
{
    partial class FormTest2
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
            this.button_init = new System.Windows.Forms.Button();
            this.textBox_xml = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.textBox_db = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_init
            // 
            this.button_init.Location = new System.Drawing.Point(12, 12);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(154, 32);
            this.button_init.TabIndex = 0;
            this.button_init.Text = "数据库初始化";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // textBox_xml
            // 
            this.textBox_xml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_xml.Location = new System.Drawing.Point(12, 81);
            this.textBox_xml.Multiline = true;
            this.textBox_xml.Name = "textBox_xml";
            this.textBox_xml.Size = new System.Drawing.Size(755, 283);
            this.textBox_xml.TabIndex = 3;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(388, 50);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(63, 25);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(92, 50);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(290, 25);
            this.textBox_path.TabIndex = 5;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(457, 48);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(63, 25);
            this.button_load.TabIndex = 6;
            this.button_load.Text = "load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(526, 48);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(53, 25);
            this.button_del.TabIndex = 7;
            this.button_del.Text = "del";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // textBox_db
            // 
            this.textBox_db.Location = new System.Drawing.Point(12, 50);
            this.textBox_db.Name = "textBox_db";
            this.textBox_db.Size = new System.Drawing.Size(74, 25);
            this.textBox_db.TabIndex = 8;
            this.textBox_db.Text = "entity";
            // 
            // FormTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 525);
            this.Controls.Add(this.textBox_db);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_xml);
            this.Controls.Add(this.button_init);
            this.Name = "FormTest2";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormTest2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.TextBox textBox_xml;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.TextBox textBox_db;
    }
}