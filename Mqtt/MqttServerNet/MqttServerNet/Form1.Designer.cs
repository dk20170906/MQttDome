namespace MqttServerNet
{
    partial class Form1
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
            this.but_serverstart = new System.Windows.Forms.Button();
            this.rtb_showmsg = new System.Windows.Forms.RichTextBox();
            this.but_mqttstop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_serverstart
            // 
            this.but_serverstart.Location = new System.Drawing.Point(400, 70);
            this.but_serverstart.Name = "but_serverstart";
            this.but_serverstart.Size = new System.Drawing.Size(75, 23);
            this.but_serverstart.TabIndex = 0;
            this.but_serverstart.Text = "启动服务器";
            this.but_serverstart.UseVisualStyleBackColor = true;
            this.but_serverstart.Click += new System.EventHandler(this.but_serverstart_Click);
            // 
            // rtb_showmsg
            // 
            this.rtb_showmsg.Location = new System.Drawing.Point(75, 44);
            this.rtb_showmsg.Name = "rtb_showmsg";
            this.rtb_showmsg.Size = new System.Drawing.Size(232, 229);
            this.rtb_showmsg.TabIndex = 1;
            this.rtb_showmsg.Text = "";
            // 
            // but_mqttstop
            // 
            this.but_mqttstop.Location = new System.Drawing.Point(400, 154);
            this.but_mqttstop.Name = "but_mqttstop";
            this.but_mqttstop.Size = new System.Drawing.Size(75, 23);
            this.but_mqttstop.TabIndex = 2;
            this.but_mqttstop.Text = "停止服务器";
            this.but_mqttstop.UseVisualStyleBackColor = true;
            this.but_mqttstop.Click += new System.EventHandler(this.but_mqttstop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 356);
            this.Controls.Add(this.but_mqttstop);
            this.Controls.Add(this.rtb_showmsg);
            this.Controls.Add(this.but_serverstart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_serverstart;
        private System.Windows.Forms.RichTextBox rtb_showmsg;
        private System.Windows.Forms.Button but_mqttstop;
    }
}