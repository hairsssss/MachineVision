using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace 服务器
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private  Socket serverListenSocket;  //声明绑定了客户端的套接字  （可用接收和发送消息）
        private Socket socketConnect;//声明用于监听的套接字
        //连接客户端
        private void button_Accpet_Click(object sender, EventArgs e)
        { 
                //1.创建用于监听的套接字
                serverListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.绑定IP和Port
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                //3.使用Bind()进行绑定
                serverListenSocket.Bind(iPEndPoint);
                //4.开启监听
                //设置监听队列，
                ////在一定时间点内，接收最大的客户端
                serverListenSocket.Listen(10);

                //等待客户端消息
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        //负责监听的Socket来接受客户端的连接，创建跟客户端通信的Socket
                        //Accept会阻碍主线程的运行，一直在等待客户端的请求,开启一个新线程接收客户单请求
                        socketConnect = serverListenSocket.Accept();
                        break;
                    }
                        while (true)
                        {
                            //5.接收数据
                            byte[] receive = new byte[1024];
                            //实际接受到的有效字节数
                            int len = socketConnect.Receive(receive);
                            if (len == 0)
                            {
                                break;
                            }
                            //6. 接收信息后在主线程刷新UI
                            string str = Encoding.ASCII.GetString(receive, 0, len);
                            this.BeginInvoke(new Action<String>(s =>
                            {
                                richTextBox_Receive.AppendText(s + "\r\n");
                            }), str);
                        }
                });
                thread.Start();
        }
        // 向客户端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
                //1.准备发送字节数组
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);   
               //将字符串转成字节格式发送
                socketConnect.Send(send);  //调用Send()向客户端发送数据
               
        }
       
    }

}
