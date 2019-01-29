namespace MQTTServer
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
            this.but_startserver = new System.Windows.Forms.Button();
            this.but_stopserver = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rtb_servermsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // but_startserver
            // 
            this.but_startserver.Location = new System.Drawing.Point(341, 39);
            this.but_startserver.Name = "but_startserver";
            this.but_startserver.Size = new System.Drawing.Size(75, 23);
            this.but_startserver.TabIndex = 0;
            this.but_startserver.Text = "开户服务器";
            this.but_startserver.UseVisualStyleBackColor = true;
            this.but_startserver.Click += new System.EventHandler(this.but_startserver_Click);
            // 
            // but_stopserver
            // 
            this.but_stopserver.Location = new System.Drawing.Point(341, 68);
            this.but_stopserver.Name = "but_stopserver";
            this.but_stopserver.Size = new System.Drawing.Size(75, 23);
            this.but_stopserver.TabIndex = 1;
            this.but_stopserver.Text = "停止服务器";
            this.but_stopserver.UseVisualStyleBackColor = true;
            this.but_stopserver.Click += new System.EventHandler(this.but_stopserver_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(341, 212);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // rtb_servermsg
            // 
            this.rtb_servermsg.Location = new System.Drawing.Point(24, 29);
            this.rtb_servermsg.Name = "rtb_servermsg";
            this.rtb_servermsg.Size = new System.Drawing.Size(311, 196);
            this.rtb_servermsg.TabIndex = 4;
            this.rtb_servermsg.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 511);
            this.Controls.Add(this.rtb_servermsg);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.but_stopserver);
            this.Controls.Add(this.but_startserver);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_startserver;
        private System.Windows.Forms.Button but_stopserver;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox rtb_servermsg;
    }
}

