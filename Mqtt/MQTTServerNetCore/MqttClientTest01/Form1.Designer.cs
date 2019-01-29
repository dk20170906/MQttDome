namespace MqttClientTest01
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_serverip = new System.Windows.Forms.TextBox();
            this.txtb_serverport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_linkserver = new System.Windows.Forms.Button();
            this.txtb_msgtopic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_pubmsg = new System.Windows.Forms.RichTextBox();
            this.but_clientsend = new System.Windows.Forms.Button();
            this.rtb_submsgclient = new System.Windows.Forms.RichTextBox();
            this.but_submsg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtb_subtopic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_userpwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_linktimer = new System.Windows.Forms.Label();
            this.lab_linkstatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP:";
            // 
            // txtb_serverip
            // 
            this.txtb_serverip.Location = new System.Drawing.Point(112, 5);
            this.txtb_serverip.Name = "txtb_serverip";
            this.txtb_serverip.Size = new System.Drawing.Size(97, 21);
            this.txtb_serverip.TabIndex = 1;
            this.txtb_serverip.Text = "192.168.3.125";
            // 
            // txtb_serverport
            // 
            this.txtb_serverport.Location = new System.Drawing.Point(300, 5);
            this.txtb_serverport.Name = "txtb_serverport";
            this.txtb_serverport.Size = new System.Drawing.Size(83, 21);
            this.txtb_serverport.TabIndex = 3;
            this.txtb_serverport.Text = "1884";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "服务器端口:";
            // 
            // but_linkserver
            // 
            this.but_linkserver.Location = new System.Drawing.Point(536, 33);
            this.but_linkserver.Name = "but_linkserver";
            this.but_linkserver.Size = new System.Drawing.Size(75, 23);
            this.but_linkserver.TabIndex = 4;
            this.but_linkserver.Text = "链接";
            this.but_linkserver.UseVisualStyleBackColor = true;
            this.but_linkserver.Click += new System.EventHandler(this.but_linkserver_Click);
            // 
            // txtb_msgtopic
            // 
            this.txtb_msgtopic.Location = new System.Drawing.Point(71, 12);
            this.txtb_msgtopic.Name = "txtb_msgtopic";
            this.txtb_msgtopic.Size = new System.Drawing.Size(201, 21);
            this.txtb_msgtopic.TabIndex = 6;
            this.txtb_msgtopic.Text = "TestTopicUserPassword";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "消息主题：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "消息主体:";
            // 
            // rtb_pubmsg
            // 
            this.rtb_pubmsg.Location = new System.Drawing.Point(76, 51);
            this.rtb_pubmsg.Name = "rtb_pubmsg";
            this.rtb_pubmsg.Size = new System.Drawing.Size(196, 182);
            this.rtb_pubmsg.TabIndex = 8;
            this.rtb_pubmsg.Text = "testTopic001";
            // 
            // but_clientsend
            // 
            this.but_clientsend.Location = new System.Drawing.Point(134, 249);
            this.but_clientsend.Name = "but_clientsend";
            this.but_clientsend.Size = new System.Drawing.Size(75, 23);
            this.but_clientsend.TabIndex = 9;
            this.but_clientsend.Text = "send";
            this.but_clientsend.UseVisualStyleBackColor = true;
            this.but_clientsend.Click += new System.EventHandler(this.but_clientsend_Click);
            // 
            // rtb_submsgclient
            // 
            this.rtb_submsgclient.Location = new System.Drawing.Point(16, 64);
            this.rtb_submsgclient.Name = "rtb_submsgclient";
            this.rtb_submsgclient.Size = new System.Drawing.Size(251, 208);
            this.rtb_submsgclient.TabIndex = 13;
            this.rtb_submsgclient.Text = "";
            // 
            // but_submsg
            // 
            this.but_submsg.Location = new System.Drawing.Point(76, 35);
            this.but_submsg.Name = "but_submsg";
            this.but_submsg.Size = new System.Drawing.Size(75, 23);
            this.but_submsg.TabIndex = 14;
            this.but_submsg.Text = "订阅";
            this.but_submsg.UseVisualStyleBackColor = true;
            this.but_submsg.Click += new System.EventHandler(this.but_submsg_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtb_msgtopic);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rtb_pubmsg);
            this.panel1.Controls.Add(this.but_clientsend);
            this.panel1.Location = new System.Drawing.Point(35, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 292);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtb_subtopic);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.but_submsg);
            this.panel2.Controls.Add(this.rtb_submsgclient);
            this.panel2.Location = new System.Drawing.Point(343, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 292);
            this.panel2.TabIndex = 16;
            // 
            // txtb_subtopic
            // 
            this.txtb_subtopic.Location = new System.Drawing.Point(76, 6);
            this.txtb_subtopic.Name = "txtb_subtopic";
            this.txtb_subtopic.Size = new System.Drawing.Size(201, 21);
            this.txtb_subtopic.TabIndex = 16;
            this.txtb_subtopic.Text = "TestTopicUserPassword";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "订阅主题:";
            // 
            // tb_userpwd
            // 
            this.tb_userpwd.Location = new System.Drawing.Point(269, 29);
            this.tb_userpwd.Name = "tb_userpwd";
            this.tb_userpwd.Size = new System.Drawing.Size(114, 21);
            this.tb_userpwd.TabIndex = 20;
            this.tb_userpwd.Text = "123456";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "密码:";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(112, 30);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(97, 21);
            this.tb_username.TabIndex = 18;
            this.tb_username.Text = "user";
            this.tb_username.TextChanged += new System.EventHandler(this.tb_username_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "用户名:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "链接时间：";
            // 
            // lab_linktimer
            // 
            this.lab_linktimer.AutoSize = true;
            this.lab_linktimer.Location = new System.Drawing.Point(457, 9);
            this.lab_linktimer.Name = "lab_linktimer";
            this.lab_linktimer.Size = new System.Drawing.Size(11, 12);
            this.lab_linktimer.TabIndex = 22;
            this.lab_linktimer.Text = "-";
            // 
            // lab_linkstatus
            // 
            this.lab_linkstatus.AutoSize = true;
            this.lab_linkstatus.Location = new System.Drawing.Point(457, 33);
            this.lab_linkstatus.Name = "lab_linkstatus";
            this.lab_linkstatus.Size = new System.Drawing.Size(11, 12);
            this.lab_linkstatus.TabIndex = 24;
            this.lab_linkstatus.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "链接状态：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 364);
            this.Controls.Add(this.lab_linkstatus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lab_linktimer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_userpwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.but_linkserver);
            this.Controls.Add(this.txtb_serverport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_serverip);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mqttnet服务客户端";

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_serverip;
        private System.Windows.Forms.TextBox txtb_serverport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_linkserver;
        private System.Windows.Forms.TextBox txtb_msgtopic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_pubmsg;
        private System.Windows.Forms.Button but_clientsend;
        private System.Windows.Forms.RichTextBox rtb_submsgclient;
        private System.Windows.Forms.Button but_submsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_userpwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_linktimer;
        private System.Windows.Forms.Label lab_linkstatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtb_subtopic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

