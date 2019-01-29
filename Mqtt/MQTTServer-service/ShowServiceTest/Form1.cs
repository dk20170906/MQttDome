using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ShowServiceTest
{
    public partial class Form1 : Form
    {
        private Socket socketClient = null;


        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        private Thread threadclient = null;
        private Socket socketclient = null;

        private ServiceController ServiceController = null;

        public Form1()
        {
            InitializeComponent();

            btnConnection_Click();

            new Thread(new ThreadStart(GetServiceStatus)).Start();
        }

        private  void GetServiceStatus()
        {
            ServiceController[] serviceControllers = ServiceController.GetServices();
            if (serviceControllers.Length > 0)
            {
                serviceControllers.ToList().ForEach(u =>
                {
                    if (u.DisplayName == "MqttNetServiceAddUserAndPassword")
                    {
                        if (ServiceController == null)
                        {
                            ServiceController = u;
                        }
                        if (u.Status == ServiceControllerStatus.Running)
                        {
                            this.Invoke(new Action(() => { lab_serverstatus.Text = "服务运行中............"; }));
                        }
                        else
                        {
                            this.Invoke(new Action(() => { lab_serverstatus.Text = "服务已停止............"; }));
                        }
                    }
                });
            }
        }

        private void btnConnection_Click()
        {
            //  this.btnConnection.Enabled = false;
            //定义一个套接字监听  
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取文本框中的IP地址  
            IPAddress address = IPAddress.Parse("127.0.0.1");

            //将获取的IP地址和端口号绑定在网络节点上  
            IPEndPoint point = new IPEndPoint(address, 8098);

            try
            {
                //客户端套接字连接到网络节点上，用的是Connect  
                socketclient.Connect(point);
                //this.btnSendMessage.Enabled = true;
                //this.btnSendMessage.Visible = true;
                //this.txtMessage.Visible = true;
            }
            catch (Exception)
            {
                Debug.WriteLine("连接失败\r\n");

                // this.txtDebugInfo.AppendText("连接失败\r\n");
                return;
            }

            threadclient = new Thread(recv);
            threadclient.IsBackground = true;
            threadclient.Start();
        }

        // 接收服务端发来信息的方法    
        void recv()
        {
            int x = 0;
            //持续监听服务端发来的消息 
            while (true)
            {
                try
                {
                    //定义一个1M的内存缓冲区，用于临时性存储接收到的消息  
                    byte[] arrRecvmsg = new byte[1024 * 1024];

                    //将客户端套接字接收到的数据存入内存缓冲区，并获取长度  
                    int length = socketclient.Receive(arrRecvmsg);

                    //将套接字获取到的字符数组转换为人可以看懂的字符串  
                    string strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);
                    if (x == 1)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lab_serverstatus.Text= "服务运行中:服务器:" + GetCurrentTime() + "\r\n" + strRevMsg + "\r\n\n";
                        }));
                        Debug.WriteLine("服务器:" + GetCurrentTime() + "\r\n" + strRevMsg + "\r\n\n");

                        if (strRevMsg.StartsWith("连接服务"))
                        {
                            this.Invoke(new Action(() =>
                            {
                                rtb_msglog.AppendText(strRevMsg + "\r\n");
                                lab_serverstatus.Text = "服务运行中:服务器:" + GetCurrentTime() + "\r\n" + strRevMsg + "\r\n\n";
                            }));
                        }
                        else
                        {
                          List<SetServiceM> dicmsgstr = JsonConvert.DeserializeObject<List<SetServiceM>>(strRevMsg).DefaultIfEmpty().ToList();
                            string ClientsCount = string.Empty, clientlink = string.Empty, clientoutline = string.Empty, msglog = string.Empty;
                            dicmsgstr.ForEach(u =>
                            {
                                if (u.KeyMsg== "ClientsCount")
                                {
                                    ClientsCount = u.ValueMsg;
                                }
                                if (u.KeyMsg== "clientlink")
                                {
                                    clientlink = u.ValueMsg;
                                }
                                if (u.KeyMsg== "clientoutline")
                                {
                                    clientoutline = u.ValueMsg;
                                }
                            });
                            this.Invoke(new Action(() =>
                                {
                                    lab_clientcount.Text = ClientsCount;
                                    if (clientlink.Length > 0)
                                    {
                                        List<SetServiceM> dic = JsonConvert.DeserializeObject<List<SetServiceM>>(clientlink);
                                        if (dic.Count > 0)
                                        {
                                            dic.ToList().ForEach(u =>
                                            {
                                                rtb_clientlog.AppendText(u.KeyMsg + ": " + u.ValueMsg);
                                            });
                                        }
                                    }
                                    if (clientoutline.Length > 0)
                                    {
                                        List<SetServiceM> dic = JsonConvert.DeserializeObject<List<SetServiceM>>(clientoutline);

                                        if (dic.Count > 0)
                                        {
                                            dic.ToList().ForEach(u =>
                                            {
                                                rtb_clientlog.AppendText(u.KeyMsg + ": " + u.ValueMsg);
                                            });
                                        }
                                    }
                                  //  rtb_msglog.AppendText(msglog);

                                }));
                        }


                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                           // this.rtb_msglog.AppendText(strRevMsg + "\r\n\n");
                        }));
       
                        Debug.WriteLine(strRevMsg + "\r\n\n");
                        x = 1;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("远程服务器已经中断连接" + "\r\n\n");
                    Debug.WriteLine("远程服务器已经中断连接" + "\r\n");
                    break;
                }
            }
        }

        //获取当前系统时间  
        DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        //发送字符信息到服务端的方法  
        void ClientSendMsg(string sendMsg)
        {
            //将输入的内容字符串转换为机器可以识别的字节数组     
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //调用客户端套接字发送字节数组     
            socketclient.Send(arrClientSendMsg);
            //将发送的信息追加到聊天内容文本框中     
            Debug.WriteLine("hello...." + ": " + GetCurrentTime() + "\r\n" + sendMsg + "\r\n\n");
            this.Invoke(new Action(() => { this.rtb_clientlog.AppendText("hello...." + ": " + GetCurrentTime() + "\r\n" + sendMsg + "\r\n\n"); }));
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //调用ClientSendMsg方法 将文本框中输入的信息发送给服务端     
            ClientSendMsg(this.rtb_clientlog.Text.Trim());
            this.rtb_clientlog.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                rtb_clientlog.Text = "";
            }
            else
            {
                rtb_msglog.Text = "";
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (ServiceController != null)
        //    {
        //        if (button1.Text.StartsWith("停止"))
        //        {
        //            button1.Text = "启动服务";
        //            if (ServiceController.Status == ServiceControllerStatus.Running)
        //            {
        //                MessageBox.Show("确定要停止该服务吗？");
        //                ServiceController.Stop();
        //            }

        //        }
        //        else
        //        {
        //            button1.Text = "停止服务";
        //            if (ServiceController.Status == ServiceControllerStatus.Stopped)
        //            {
        //                ServiceController.Start();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("请确认是否已安装此服务！");
        //    }
        //    GetServiceStatus();

        //}
    }
}


