using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageFile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 串口_Blob {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        //相机对象
        ICogFrameGrabber frameGrabber = null;

        //相机连接对象
        ICogAcqFifo fifo = null;

        //采图对象
        ICogImage image = null;

        //Blob工具
        CogBlobTool blobTool = null;

        //加载vpp文件
        private void LoadVpp() {
            string path = Directory.GetCurrentDirectory() + @"\Vpp\Blob.vpp";

            // 反序列化vpp文件 得到Blob对象
            blobTool = (CogBlobTool)CogSerializer.LoadObjectFromFile(path);
            cogBlobEditV21.Subject = blobTool;
        }

        //相机初始化
        private void InitCam() {
            //获取所有已连接设备
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();

            if (frameGrabbers.Count < 1) {
                MessageBox.Show("未找到相机！");
                return;
            }

            foreach (ICogFrameGrabber frame in frameGrabbers) {
                frameGrabber = frame;
                //创建采集接口
                fifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);

                fifo.OwnedExposureParams.Exposure = 50;
                fifo.Complete += Acq_Comlete;


            }
        }

        //采图完成事件
        private void Acq_Comlete(object sender, CogCompleteEventArgs e) {
            int numReady, numPending;
            bool busyVal;
            try {
                CogImage8Grey greyImage = new CogImage8Grey();
                CogAcqInfo acqInfo = new CogAcqInfo();
                fifo.GetFifoState(out numPending, out numReady, out busyVal);

                if (numReady > 0) {
                    greyImage = fifo.CompleteAcquireEx(acqInfo) as CogImage8Grey;
                    image = greyImage;
                    cogRecordDisplay1.Image = image;
                    cogRecordDisplay1.Fit();

                    SaveOriginImage(image);

                    //设置blob输入图像
                    cogBlobEditV21.Subject.InputImage = image;

                }
            } catch (Exception) {

                throw;
            }
        }

        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="image">传入的图片</param>
        public void SaveOriginImage(ICogImage image) {
            string path = Directory.GetCurrentDirectory() + "\\Image";

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            string fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.bmp";

            //把ICogImage类型的图像 转成bitmap格式
            Bitmap bmp = image.ToBitmap();
            bmp.Save($"{path}\\{fileName}", System.Drawing.Imaging.ImageFormat.Bmp);

        }

        //窗口初始化
        private void PageLoad(object sender, EventArgs e) {
            LoadVpp();
            InitCam();
            //打开串口
            serialPort1.Open();
        }

        private void takePhotoBtn_Click(object sender, EventArgs e) {
            fifo.StartAcquire();
        }


        //串口连接
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            //接收缓冲区数据的字节数
            int size = serialPort1.BytesToRead;
            //动态创建数组接收数据
            byte[] buffer = new byte[size];
            //读取数据
            serialPort1.Read(buffer, 0, buffer.Length);
            //字节数组转化字符串
            string msg = Encoding.Default.GetString(buffer);
            if (msg == "T1") {
                fifo.StartAcquire();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            //关闭串口
            if (serialPort1 != null && serialPort1.IsOpen)
                serialPort1.Close();
        }

        //提交结果信息
        private void submitBtn_click(object sender, EventArgs e) {
            int resultStr = cogBlobEditV21.Subject.Results.GetBlobs().Count;

            //byte[] send = Encoding.UTF8.GetBytes(resultStr.ToString() + "个");
            //serialPort1.Write(send, 0, send.Length);

            string testStr = "9个斑点";

            // 使用 UTF-8 编码将字符串转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(testStr);

            // 将字节数组写入串口
            serialPort1.Write(bytes, 0, bytes.Length);

            // 添加延迟
            System.Threading.Thread.Sleep(100); // 100 毫秒的延迟，根据实际情况调整

        }
    }
}
