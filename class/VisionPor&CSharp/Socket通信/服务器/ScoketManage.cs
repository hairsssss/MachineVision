using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace 服务器
{
    internal class ScoketManage
    {
        delegate void myDelegate(object a);
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        static   Socket socketConnect;
        public static void ServerStartListen(string IP, int Port)
        {


            //1.创建用于监听的套接字
            Socket serverListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2.绑定IP和Port
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            //3.使用Bind()进行绑定
            serverListenSocket.Bind(iPEndPoint);
            //4.开启监听
            //设置监听队列，
            ////在一定时间点内，接收最大的客户端, 卫生间有五个位置，同一时间最多来五个，第六个排队
            serverListenSocket.Listen(10);
            /*
             * tip：
             * Accept会阻碍主线程的运行，一直在等待客户端的请求，
             * 客户端如果不接入，它就会一直在这里等着，主线程卡死
             * 所以开启一个新线程接收客户单请求
             */
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    //负责监听的Socket来接受客户端的连接，创建跟客户端通信的Socket
                    //Accept会阻碍主线程的运行，一直在等待客户端的请求,开启一个新线程接收客户单请求
                    Socket socketConnect = serverListenSocket.Accept();
                    //  dicList.Add(socketConnect.RemoteEndPoint.ToString(), socketConnect);
                    //  listBoxCoustomerList.Items.Add(socketConnect.RemoteEndPoint.ToString());
                    //  textboMsg.AppendText(socketConnect.RemoteEndPoint.ToString() + " 上线啦\r\n");
                    //Thread th = new Thread(Receive);
                    //th.IsBackground = true;
                    //th.Start(socketConnect);
                    break;
                    
                }
                while (true)
                {
                    //5.接收数据
                    byte[] recieve = new byte[1024 * 1024 * 2];
                    //实际接受到的有效字节数
                    int len = socketConnect.Receive(recieve);

                    if (len == 0)
                        break;
                }
            });
             thread.Start();
        }

        public static void  aaa(Socket socketConnect) 
        {

            // Thread th2 = new Thread(() =>
            //{
            while (true)
            {
                //5.接收数据
                byte[] recieve = new byte[1024 * 1024 * 2];
                //实际接受到的有效字节数
                int len = socketConnect.Receive(recieve);

                if (len == 0)
                    break;

            }
              //});
            //   th2.Start();
         
        }
        /// <summary>
        /// 向RichText添加信息
        /// </summary>
        /// <param name="str"></param>
        public static void AddReciveText(string str, Control control)
        {
            control.BeginInvoke(new Action<String>(s =>
            {
                control.Text = str;
            }), str);
        }
    }
}

//Thread thread = new Thread((object ob) => {
//    Socket socketAccept = ob as Socket;    //创建一个与客户端对接的套接字
//    while (true)
//    {
//        //GNFlag如果为1就进行中断连接，使用在标志为是为了保证能够顺利关闭服务器端
//        /*
//         * 当客户端关闭一次后，如果没有这个标志位会使得服务器端一直卡在中断的位置
//         * 如果服务器端一直卡在中断的位置就不能顺利关闭服务器端
//         */

//        //4.阻塞到有client连接
//        Socket socket = socketAccept.Accept();
//        //字典中添加客户端
//        dicSocket.Add(socket.RemoteEndPoint.ToString(), socket);
//        //AddReciveText(DateTime.Now.ToString("yy-MM-dd hh:mm:ss  ") + textBox_Addr.Text + "连接成功");
//        //AddReciveText("\r\n");
//        //开启第二个线程接收客户端数据
//        Thread th2 = new Thread((object ob1) =>
//        {
//            Socket socket1 = ob1 as Socket;  //创建用于通信的套接字

//            while (true)
//            {
//                //5.接收数据
//                byte[] recieve = new byte[1024 * 1024 * 2];
//                //实际接受到的有效字节数
//                int len = socket.Receive(recieve);

//                if (len == 0)
//                    break;
//                return Encoding.ASCII.GetString(recieve, 0, len);

//            }
//        });  //线程绑定Receive函数
//        th2.IsBackground = true;    //运行线程在后台执行
//        th2.Start(socket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
//    }
//});
//thread.IsBackground = true;    //运行线程在后台执行
//thread.Start(ServerSocket);    //Start里面的参数是Listen函数所需要的参数，这里传送的是用于通信的Socket对象
