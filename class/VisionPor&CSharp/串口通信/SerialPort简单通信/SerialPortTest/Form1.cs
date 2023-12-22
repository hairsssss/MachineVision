using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//串口的命名空间
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            //打开串口
            serialPort1.Open();
        }
        //串口接受到数据时执行事件
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            //接收缓冲区数据的字节数
            int size = serialPort1.BytesToRead;
            //动态创建数组接收数据
            byte[] buffer = new byte[size];
            //读取数据
            serialPort1.Read(buffer, 0, buffer.Length);
            //字节数组转化字符串
            string msg = Encoding.Default.GetString(buffer);
            //开启异步操作
            richTextBox1.BeginInvoke(new Action<string>(str => {
                richTextBox1.Text = str;

            }), msg);
        }

        //发送串口数据
        private void button1_Click(object sender, EventArgs e) {
            //发送给PLC  OK信号
            serialPort1.WriteLine(textBox1.Text);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            //关闭串口
            if (serialPort1 != null && serialPort1.IsOpen)
                serialPort1.Close();
        }

    }
}
