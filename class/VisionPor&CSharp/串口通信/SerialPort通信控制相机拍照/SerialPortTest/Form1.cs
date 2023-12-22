using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//串口的命名空间
using System.IO.Ports;

using Cognex.VisionPro;


namespace SerialPortTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CogAcqFifoTool fifoTool;
        private void Form1_Load(object sender, EventArgs e)
        {
            fifoTool = CogSerializer.LoadObjectFromFile(Directory.GetCurrentDirectory() + "\\VPP\\CogAcqTool.vpp") as CogAcqFifoTool;
            serialPort1.Open();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        { 
            // 获取缓存区的字节数
            int size = serialPort1.BytesToRead;
            //动态创建字节数组 ，大小就是接收到的size
            byte[] buffer = new byte[size];
            //读取数据到buffer数组  第二个参数 是从0开始读取， 第三个参数是读取的长度 
            serialPort1.Read(buffer, 0, buffer.Length); 
            //把字节数组转成字符串
            string msg = Encoding.ASCII.GetString(buffer);
            //判断 接收T1 信号 相机拍照
            if (msg.Contains("T1"))
            {
                fifoTool.Run();
             ///   this.BeginInvoke 
                cogRecordDisplay1.Image = fifoTool.OutputImage;
                cogRecordDisplay1.Fit();
                //
                // 执行视觉检测代码
                //
                //发送给PLC  OK信号
                serialPort1.WriteLine("OK");
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭相机
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber f in frameGrabbers)
            {
                f.Disconnect(false);
            }
            if (serialPort1 != null && serialPort1.IsOpen)
                serialPort1.Close();
        }

    }
}
