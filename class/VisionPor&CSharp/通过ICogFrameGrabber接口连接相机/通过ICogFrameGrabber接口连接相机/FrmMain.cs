using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
namespace 通过ICogFrameGrabber接口连接相机 {


    public partial class FrmMain : Form {

        private double ExposureVal { get; set; }

        public FrmMain() {
            InitializeComponent();


        }
        //窗体加载事件
        private void FrmMain_Load(object sender, EventArgs e) {
            InitialCam();
        }
        //窗体关闭时事件
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            CloseCam();
        }
        //拍照btn事件
        private void btnTrigger_Click(object sender, EventArgs e) {
            if (mAcqFifo != null) {
                mAcqFifo.StartAcquire();//采集图像
            }
        }
        //曝光设置btn事件
        private void btnSetExposure_Click(object sender, EventArgs e) {
            double exposure = 20;
            try {
                //获取曝光
                exposure = Convert.ToDouble(txtExposure.Text.Trim());
            } catch {
                MessageBox.Show("输入的格式不正确！");
                return;
            }
            SetExposure(exposure);
        }
        private ICogFrameGrabber frameGrabber = null;//控制FrameGrabber接口 对象   目的:用于保存相机对象
        private ICogAcqFifo mAcqFifo = null; //采集接口对象   目的：用于配置相机参数 以及采集图像

        /// <summary>
        /// 初始化相机
        /// </summary>
        private void InitialCam() {
            try {
                //创建CogFrameGrabbers对象，获取所有的硬件      目的： 类似集合  保存所有硬件相机对象
                CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();

                //根据CogFrameGrabbers元素个数  判断是否存在相机对象 
                if (frameGrabbers.Count < 1) {
                    MessageBox.Show("没有搜寻到相机！");
                    return;
                }
                //遍历集合，获取相机
                foreach (ICogFrameGrabber frame in frameGrabbers) {

                    //用于保存相机对象
                    frameGrabber = frame;
                    //创建采集接口对象     CreateAcqFifo 方法:
                    //                     参数1：视频格式  Generic GigEVision (Mono) 灰度格式  从vp像源界面中 自行查看
                    //                     参数2: 像素格式  CogAcqFifoPixelFormatConstants.Format8Grey  灰度像素格式
                    //                     参数3 ：摄像头端口  默认0   后续如果有多个相机时  端口不要一样
                    //                     参数4：如果该值为真，则在创建fifo后将准备启动fifo。
                    mAcqFifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                    //设置曝光时间
                    mAcqFifo.OwnedExposureParams.Exposure = 20;




                    //添加采图完成事件
                    mAcqFifo.Complete += MAcqFifo_Complete;
                }
            } catch (Exception) {


            }

        }
        //采图完成事件（当点击拍照按钮时 执行mAcqFifo.StartAcquire()）
        private void MAcqFifo_Complete(object sender, CogCompleteEventArgs e) {



            //获取拍照图像 并且显示在RecordDisplay窗口中
            //    cogRecordDisplay1.Image = mAcqFifo.CompleteAcquireEx(new CogAcqInfo());



            int numReadyVal;
            int numPendingVal;
            bool busyVal;
            try {
                //转换成灰度图像
                //初始化灰度图对象
                CogImage8Grey greyImage = new CogImage8Grey();
                //初始化图像信息对象
                CogAcqInfo info = new CogAcqInfo();
                //获取fifo状态  用于检测拍照是否成功
                mAcqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
                if (numReadyVal > 0) {
                    //获取图像
                    greyImage = mAcqFifo.CompleteAcquireEx(info) as CogImage8Grey;

                    //图像 显示 cogRecordDisplay  mAcqFifo.CompleteAcquireEx(new CogAcqInfo())
                    cogRecordDisplay1.Image = greyImage;
                    //图像按比例缩放 
                    cogRecordDisplay1.Fit();
                }
            } catch (Exception) {

                throw;
            }
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间</param>
        private void SetExposure(double exposure) {
            mAcqFifo.OwnedExposureParams.Exposure = exposure;
        }
        /// <summary>
        /// 关闭相机
        /// </summary>
        private void CloseCam() {
            //创建CogFrameGrabbers对象，获取所有的硬件
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            //关闭所有相机
            foreach (ICogFrameGrabber f in frameGrabbers)
                f.Disconnect(false);
        }

        //保存图像按钮方法
        private void button1_Click(object sender, EventArgs e) {

            SaveBitMapImage(cogRecordDisplay1);
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
        //读取图像按钮方法
        private void button2_Click(object sender, EventArgs e) {

            //展示图像到  cogRecordDisplay 窗体中
            cogRecordDisplay1.Image = ReadBitMapImage();
        }


        private void AAA(int a, [Optional] int b) {

            Console.WriteLine(a + b);
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
    }
}
