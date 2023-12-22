using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;

namespace FrameGrabber连接相机 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //窗口关闭事件
        private void PageClosing(object sender, FormClosingEventArgs e) {
            CloseCam();
        }


        //拍照
        private void TakePhotoBtn_click(object sender, EventArgs e) {
            if (acqFifo != null) {
                acqFifo.StartAcquire();//采集图像
            }
        }



        //曝光设置
        private void ExposureBtn_click(object sender, EventArgs e) {
            double exposure = 20;
            try {
                //获取曝光
                exposure = Convert.ToDouble(exposureIpt.Text.Trim());
            } catch {
                MessageBox.Show("输入的格式不正确！");
                return;
            }
            acqFifo.OwnedExposureParams.Exposure = exposure;
        }


        //相机初始化
        private ICogFrameGrabber frameGrabber = null;  // 控制ICogFrameGrabber接口意向 用于保存相机对象
        private ICogAcqFifo acqFifo = null; // 采集接口对象 用于配置相机参数以及采集图像
        public void InitCam() {
            try {
                //创建CogFrameGrabbers对象，获取所有的硬件  用于存放所有的硬件相机对象
                CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();

                //根据CogFrameGrabbers元素个数 判断是否存在相机对象
                if (frameGrabbers.Count < 1) {
                    MessageBox.Show("没有找到相机！");
                    return;
                }

                //遍历集合
                foreach (ICogFrameGrabber item in frameGrabbers) {
                    frameGrabber = item;
                    //创建采集接口对象
                    //CreateAcqFifo：
                    //参数1：视频格式 Generic GigEVision (Mono) 灰度格式   从vp像源界面中自行查看
                    //参数2：像素格式 CogAcqFifoPixelFormatConstants.Format8Grey  像素格式
                    //参数3：摄像头端口 默认0 后续如果有多个相机是 端口不能一样
                    //参数4：如果该值为真，则在创建fifo后将准备启动fifo
                    acqFifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);

                    //设置曝光时间
                    acqFifo.OwnedExposureParams.Exposure = 20;

                    // 添加采图完成事件
                    acqFifo.Complete += AcqFifo_Complete;
                }

            } catch (Exception) {

            }
        }

        //图像采集完成事件
        private void AcqFifo_Complete(object sender, CogCompleteEventArgs e) {
            //获取拍照图像 并且显示在RecordDisplay窗口中
            //    cogRecordDisplay1.Image = mAcqFifo.CompleteAcquireEx(new CogAcqInfo());

            int numReadyVal;
            int numPendingVal;
            bool busyVal;
            try {
                //初始化灰度图像
                CogImage8Grey greyImage = new CogImage8Grey();

                //初始化图像信息对象
                CogAcqInfo acqInfo = new CogAcqInfo();

                //获取fifo状态  用于检测拍照是否成功
                acqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
                if (numReadyVal > 0) {
                    //获取图像
                    greyImage = acqFifo.CompleteAcquireEx(acqInfo) as CogImage8Grey;

                    //图像 显示 cogRecordDisplay  mAcqFifo.CompleteAcquireEx(new CogAcqInfo())
                    cogRecordDisplay1.Image = greyImage;

                    //图像按比例缩放 
                    cogRecordDisplay1.Fit();
                }

            } catch (Exception) {

                throw;
            }
        }

        //保存图像
        private void SaveImageBtn_click(object sender, EventArgs e) {
            SaveBitMapImage(cogRecordDisplay1);
        }

        //读取图像
        private void ReadImage_click(object sender, EventArgs e) {
            //展示图像到  cogRecordDisplay 窗体中
            cogRecordDisplay1.Image = ReadBitMapImage();
        }

        //封装保存图像方法
        private void SaveBitMapImage(CogRecordDisplay display) {
            // 获取当前程序的运行路径
            string path = Directory.GetCurrentDirectory() + "\\图片Bitmap";
            //没有有文件夹 需要创建
            if (!Directory.Exists(path)) {
                //创建文件夹
                Directory.CreateDirectory(path);
            }
            //定义 图像的名称
            //yyyyMMddHHmmssfff年份、月份、日、小时、分钟、秒、毫秒依次连写
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

            // 创建Bitmap 类   
            //参数1:图像类型
            //参数2:矩形图形 可选
            //参数3:位图的最大尺寸  可选
            //通过CogRecordDisplay 保存图像            //using Cognex.VisionPro.Display;
            Bitmap bitmap = display.CreateContentBitmap(CogDisplayContentBitmapConstants.Image) as Bitmap;
            //保存图形 
            //参数1 ：图像路径
            //参数2: 图像类型 （using System.Drawing.Imaging;）
            bitmap.Save(path + "\\" + fileName, ImageFormat.Jpeg);
        }

        //封装读取图像方法
        public ICogImage ReadBitMapImage() {

            string filePath = Directory.GetCurrentDirectory() + "\\图片Bitmap";

            if (!File.Exists(filePath)) {
                return null;
            }

            //获取文件夹中所有资源路径
            string[] files = Directory.GetFiles(filePath);
            if (files == null) {
                return null;

            }

            //要读的图片的路径
            string path = files[0];

            // 通过过Bitmap 来读取图像
            Bitmap bimage = new Bitmap(path);

            //转换成灰度图
            ICogImage image = new CogImage8Grey(bimage);

            return image;
        }

        //关闭相机
        private void CloseCam() {
            //创建CogFrameGrabbers对象，获取所有的硬件
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            //关闭所有相机
            foreach (ICogFrameGrabber item in frameGrabbers)
                item.Disconnect(false);
        }





        //窗口初始化
        private void PageLoad(object sender, EventArgs e) {
            InitCam();
        }


    }
}
