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
namespace 客户端
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public  Socket ClientSocket;  //声明负责通信的socket
        //连接服务器端
        private void button_Connect_Click(object sender, EventArgs e)
        {
            //1.创建用于监听的套接字
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2.绑定IP和Port
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            //3.向服务器发出连接请求
            ClientSocket.Connect(iPEndPoint);       
            //开启分线程接收服务器消息
            Thread thread = new Thread(() =>
            {
                    while (true)
                    {
                            //4.接收数据
                            byte[] receive = new byte[1024];
                            int len = ClientSocket.Receive(receive);  //调用Receive()接收字节数据
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
       
        // 向服务器端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
                byte[] send = new byte[1024];
                send = Encoding.ASCII.GetBytes(richTextBox_Send.Text);  //将文本内容转换成字节发送
                ClientSocket.Send(send);    //调用Send()函数发送数据
   
        }
      
    }
}
