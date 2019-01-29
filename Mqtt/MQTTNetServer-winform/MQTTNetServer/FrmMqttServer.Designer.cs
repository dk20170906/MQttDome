namespace MQTTNetServer
{
    partial class FrmMqttServer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.but_subtxtshow = new System.Windows.Forms.Button();
            this.but_sendtxtshow = new System.Windows.Forms.Button();
            this.lab_serverstarttimer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.but_openfrmsendmsg = new System.Windows.Forms.Button();
            this.but_stopserver = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtb_sendmsg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_currentsendclient = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.but_sendclear = new System.Windows.Forms.Button();
            this.rtb_subclientmsg = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.but_subclear = new System.Windows.Forms.Button();
            this.lab_subclientcountunm = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_serverport = new System.Windows.Forms.TextBox();
            this.lab_showport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_startserver
            // 
            this.but_startserver.Location = new System.Drawing.Point(218, 18);
            this.but_startserver.Name = "but_startserver";
            this.but_startserver.Size = new System.Drawing.Size(139, 51);
            this.but_startserver.TabIndex = 0;
            this.but_startserver.Text = "开启MQTT服务器";
            this.but_startserver.UseVisualStyleBackColor = true;
            this.but_startserver.Click += new System.EventHandler(this.but_startserver_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lab_showport);
            this.splitContainer1.Panel1.Controls.Add(this.txtb_serverport);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.but_subtxtshow);
            this.splitContainer1.Panel1.Controls.Add(this.but_sendtxtshow);
            this.splitContainer1.Panel1.Controls.Add(this.lab_serverstarttimer);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.but_openfrmsendmsg);
            this.splitContainer1.Panel1.Controls.Add(this.but_stopserver);
            this.splitContainer1.Panel1.Controls.Add(this.but_startserver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(684, 461);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 5;
            // 
            // but_subtxtshow
            // 
            this.but_subtxtshow.Location = new System.Drawing.Point(218, 81);
            this.but_subtxtshow.Name = "but_subtxtshow";
            this.but_subtxtshow.Size = new System.Drawing.Size(161, 23);
            this.but_subtxtshow.TabIndex = 6;
            this.but_subtxtshow.Text = "显示连接客户端列表";
            this.but_subtxtshow.UseVisualStyleBackColor = true;
            this.but_subtxtshow.Click += new System.EventHandler(this.but_subtxtshow_Click);
            // 
            // but_sendtxtshow
            // 
            this.but_sendtxtshow.Location = new System.Drawing.Point(43, 81);
            this.but_sendtxtshow.Name = "but_sendtxtshow";
            this.but_sendtxtshow.Size = new System.Drawing.Size(161, 23);
            this.but_sendtxtshow.TabIndex = 5;
            this.but_sendtxtshow.Text = "显示发送消息客户端信息";
            this.but_sendtxtshow.Click += new System.EventHandler(this.but_sendtxtshow_Click);
            // 
            // lab_serverstarttimer
            // 
            this.lab_serverstarttimer.AutoSize = true;
            this.lab_serverstarttimer.Location = new System.Drawing.Point(480, 18);
            this.lab_serverstarttimer.Name = "lab_serverstarttimer";
            this.lab_serverstarttimer.Size = new System.Drawing.Size(11, 12);
            this.lab_serverstarttimer.TabIndex = 9;
            this.lab_serverstarttimer.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "服务器启动时间：";
            // 
            // but_openfrmsendmsg
            // 
            this.but_openfrmsendmsg.Location = new System.Drawing.Point(544, 45);
            this.but_openfrmsendmsg.Name = "but_openfrmsendmsg";
            this.but_openfrmsendmsg.Size = new System.Drawing.Size(128, 59);
            this.but_openfrmsendmsg.TabIndex = 7;
            this.but_openfrmsendmsg.Text = "服务器端发送消息";
            this.but_openfrmsendmsg.UseVisualStyleBackColor = true;
            this.but_openfrmsendmsg.Click += new System.EventHandler(this.but_openfrmsendmsg_Click);
            // 
            // but_stopserver
            // 
            this.but_stopserver.Location = new System.Drawing.Point(403, 45);
            this.but_stopserver.Name = "but_stopserver";
            this.but_stopserver.Size = new System.Drawing.Size(135, 59);
            this.but_stopserver.TabIndex = 5;
            this.but_stopserver.Text = "停止MQTT服务器";
            this.but_stopserver.UseVisualStyleBackColor = true;
            this.but_stopserver.Click += new System.EventHandler(this.but_stopserver_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtb_subclientmsg);
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer2.Size = new System.Drawing.Size(684, 338);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_sendmsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 116);
            this.panel2.TabIndex = 2;
            // 
            // rtb_sendmsg
            // 
            this.rtb_sendmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_sendmsg.Location = new System.Drawing.Point(0, 0);
            this.rtb_sendmsg.Name = "rtb_sendmsg";
            this.rtb_sendmsg.Size = new System.Drawing.Size(684, 116);
            this.rtb_sendmsg.TabIndex = 0;
            this.rtb_sendmsg.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_currentsendclient);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.but_sendclear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 40);
            this.panel1.TabIndex = 1;
            // 
            // lab_currentsendclient
            // 
            this.lab_currentsendclient.AutoSize = true;
            this.lab_currentsendclient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lab_currentsendclient.Location = new System.Drawing.Point(201, 13);
            this.lab_currentsendclient.Name = "lab_currentsendclient";
            this.lab_currentsendclient.Size = new System.Drawing.Size(65, 12);
            this.lab_currentsendclient.TabIndex = 4;
            this.lab_currentsendclient.Text = "sendclient";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "当前发送消息的客户端ID:";
            // 
            // but_sendclear
            // 
            this.but_sendclear.Location = new System.Drawing.Point(575, 8);
            this.but_sendclear.Name = "but_sendclear";
            this.but_sendclear.Size = new System.Drawing.Size(75, 23);
            this.but_sendclear.TabIndex = 1;
            this.but_sendclear.Text = "清空";
            this.but_sendclear.UseVisualStyleBackColor = true;
            this.but_sendclear.Click += new System.EventHandler(this.but_sendclear_Click);
            // 
            // rtb_subclientmsg
            // 
            this.rtb_subclientmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_subclientmsg.Location = new System.Drawing.Point(0, 40);
            this.rtb_subclientmsg.Name = "rtb_subclientmsg";
            this.rtb_subclientmsg.Size = new System.Drawing.Size(684, 138);
            this.rtb_subclientmsg.TabIndex = 4;
            this.rtb_subclientmsg.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.but_subclear);
            this.panel3.Controls.Add(this.lab_subclientcountunm);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 40);
            this.panel3.TabIndex = 3;
            // 
            // but_subclear
            // 
            this.but_subclear.Location = new System.Drawing.Point(575, 8);
            this.but_subclear.Name = "but_subclear";
            this.but_subclear.Size = new System.Drawing.Size(75, 23);
            this.but_subclear.TabIndex = 3;
            this.but_subclear.Text = "清空";
            this.but_subclear.UseVisualStyleBackColor = true;
            this.but_subclear.Click += new System.EventHandler(this.but_subclear_Click);
            // 
            // lab_subclientcountunm
            // 
            this.lab_subclientcountunm.AutoSize = true;
            this.lab_subclientcountunm.Location = new System.Drawing.Point(162, 13);
            this.lab_subclientcountunm.Name = "lab_subclientcountunm";
            this.lab_subclientcountunm.Size = new System.Drawing.Size(11, 12);
            this.lab_subclientcountunm.TabIndex = 1;
            this.lab_subclientcountunm.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "连接客户端总数：";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(684, 178);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "端口设置：";
            // 
            // txtb_serverport
            // 
            this.txtb_serverport.Location = new System.Drawing.Point(112, 27);
            this.txtb_serverport.Name = "txtb_serverport";
            this.txtb_serverport.Size = new System.Drawing.Size(100, 21);
            this.txtb_serverport.TabIndex = 11;
            this.txtb_serverport.Text = "1883";
            this.txtb_serverport.Leave += new System.EventHandler(this.txtb_serverport_Leave);
            // 
            // lab_showport
            // 
            this.lab_showport.AutoSize = true;
            this.lab_showport.Location = new System.Drawing.Point(53, 57);
            this.lab_showport.Name = "lab_showport";
            this.lab_showport.Size = new System.Drawing.Size(11, 12);
            this.lab_showport.TabIndex = 12;
            this.lab_showport.Text = "-";
            // 
            // FrmMqttServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMqttServer";
            this.Text = "MQTT服务端";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_startserver;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button but_stopserver;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtb_sendmsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lab_subclientcountunm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button but_openfrmsendmsg;
        private System.Windows.Forms.Button but_sendclear;
        private System.Windows.Forms.Button but_subclear;
        private System.Windows.Forms.RichTextBox rtb_subclientmsg;
        private System.Windows.Forms.Label lab_currentsendclient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_serverstarttimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_subtxtshow;
        private System.Windows.Forms.Button but_sendtxtshow;
        private System.Windows.Forms.TextBox txtb_serverport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_showport;
    }
}

