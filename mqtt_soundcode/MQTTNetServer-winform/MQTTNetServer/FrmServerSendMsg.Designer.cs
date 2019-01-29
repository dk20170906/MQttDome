namespace MQTTNetServer
{
    partial class FrmServerSendMsg
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
            this.but_sendmsg = new System.Windows.Forms.Button();
            this.but_cancelmsg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_msgtopic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_msgsend = new System.Windows.Forms.RichTextBox();
            this.lab_errormsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_sendmsg
            // 
            this.but_sendmsg.Location = new System.Drawing.Point(191, 202);
            this.but_sendmsg.Name = "but_sendmsg";
            this.but_sendmsg.Size = new System.Drawing.Size(75, 23);
            this.but_sendmsg.TabIndex = 0;
            this.but_sendmsg.Text = "send";
            this.but_sendmsg.UseVisualStyleBackColor = true;
            this.but_sendmsg.Click += new System.EventHandler(this.but_sendmsg_Click);
            // 
            // but_cancelmsg
            // 
            this.but_cancelmsg.Location = new System.Drawing.Point(296, 201);
            this.but_cancelmsg.Name = "but_cancelmsg";
            this.but_cancelmsg.Size = new System.Drawing.Size(75, 23);
            this.but_cancelmsg.TabIndex = 1;
            this.but_cancelmsg.Text = "cancel";
            this.but_cancelmsg.UseVisualStyleBackColor = true;
            this.but_cancelmsg.Click += new System.EventHandler(this.but_cancelmsg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主题：";
            // 
            // txtb_msgtopic
            // 
            this.txtb_msgtopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtb_msgtopic.Location = new System.Drawing.Point(98, 23);
            this.txtb_msgtopic.Name = "txtb_msgtopic";
            this.txtb_msgtopic.Size = new System.Drawing.Size(283, 21);
            this.txtb_msgtopic.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "消息主体：";
            // 
            // rtb_msgsend
            // 
            this.rtb_msgsend.Location = new System.Drawing.Point(98, 66);
            this.rtb_msgsend.Name = "rtb_msgsend";
            this.rtb_msgsend.Size = new System.Drawing.Size(283, 96);
            this.rtb_msgsend.TabIndex = 5;
            this.rtb_msgsend.Text = "";
            // 
            // lab_errormsg
            // 
            this.lab_errormsg.AutoSize = true;
            this.lab_errormsg.Location = new System.Drawing.Point(103, 47);
            this.lab_errormsg.Name = "lab_errormsg";
            this.lab_errormsg.Size = new System.Drawing.Size(11, 12);
            this.lab_errormsg.TabIndex = 6;
            this.lab_errormsg.Text = "-";
            // 
            // FrmServerSendMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 261);
            this.Controls.Add(this.lab_errormsg);
            this.Controls.Add(this.rtb_msgsend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_msgtopic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_cancelmsg);
            this.Controls.Add(this.but_sendmsg);
            this.Name = "FrmServerSendMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器发送消息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_sendmsg;
        private System.Windows.Forms.Button but_cancelmsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_msgtopic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_msgsend;
        private System.Windows.Forms.Label lab_errormsg;
    }
}