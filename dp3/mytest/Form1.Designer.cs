namespace mytest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_xml = new System.Windows.Forms.TextBox();
            this.textBox_xpath = new System.Windows.Forms.TextBox();
            this.button_get = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_xml
            // 
            this.textBox_xml.Location = new System.Drawing.Point(12, 12);
            this.textBox_xml.Multiline = true;
            this.textBox_xml.Name = "textBox_xml";
            this.textBox_xml.Size = new System.Drawing.Size(485, 129);
            this.textBox_xml.TabIndex = 0;
            // 
            // textBox_xpath
            // 
            this.textBox_xpath.Location = new System.Drawing.Point(60, 147);
            this.textBox_xpath.Name = "textBox_xpath";
            this.textBox_xpath.Size = new System.Drawing.Size(356, 25);
            this.textBox_xpath.TabIndex = 1;
            // 
            // button_get
            // 
            this.button_get.Location = new System.Drawing.Point(422, 149);
            this.button_get.Name = "button_get";
            this.button_get.Size = new System.Drawing.Size(75, 23);
            this.button_get.TabIndex = 2;
            this.button_get.Text = "get";
            this.button_get.UseVisualStyleBackColor = true;
            this.button_get.Click += new System.EventHandler(this.button_get_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "XPath";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(12, 209);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(482, 101);
            this.textBox_result.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 322);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_get);
            this.Controls.Add(this.textBox_xpath);
            this.Controls.Add(this.textBox_xml);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_xml;
        private System.Windows.Forms.TextBox textBox_xpath;
        private System.Windows.Forms.Button button_get;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_result;
    }
}

