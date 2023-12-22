using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;

namespace 使用Block工具 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        //相机对象
        ICogFrameGrabber cogFrameGrabber = null;

        //相机连接对象
        ICogAcqFifo fifo = null;

        //采图对象
        ICogImage cogImage = null;

        // ToolBlock工具
        CogToolBlock toolBlock = null;


        #region 窗体&&按钮事件
        private void PageLoad(object sender, EventArgs e) {
            InitialCamera();
            //调用block.vpp文件
            LoadToolBlock();
        }

        //关闭窗体
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            CloseCamera();
        }

        // 点击拍照
        private void takePhotoBtn_Click(object sender, EventArgs e) {
            fifo.StartAcquire();
        }

        // 设置曝光
        private void exposureBtn_Click(object sender, EventArgs e) {
            int exp = Convert.ToInt32(exposureIpt.Text);
            fifo.OwnedExposureParams.Exposure = exp;
        }

        //检测
        private void detectionBtn_Click(object sender, EventArgs e) {
            if (toolBlock != null) {
                toolBlock.Inputs["OutputImage"].Value = ReadImage();
                toolBlock.Run();

                //SubRecords集合  包含 blcok工具 显示图像窗口的集合
                cogRecordDisplay1.Record = toolBlock.CreateLastRunRecord().SubRecords[0];
                cogRecordDisplay1.Fit();
            }
        }

        //保存图片
        private void saveImageBtn_Click(object sender, EventArgs e) {
            if (cogImage != null) {
                string path = Directory.GetCurrentDirectory() + "\\DealImage";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-sss")}_ResultImage.jpg";
                //创建Bitmap图像
                Bitmap bmp = cogRecordDisplay1.CreateContentBitmap(CogDisplayContentBitmapConstants.Image) as Bitmap;

                bmp.Save(path + "\\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        //读取图片
        private void readImageBtn_Click(object sender, EventArgs e) {
            cogRecordDisplay1.Image = ReadImage();

            //图像按比例缩放 
            cogRecordDisplay1.Fit();
        }

        // 打开ToolBlock
        private void openBlockBtn_Click(object sender, EventArgs e) {
            ToolBlock formTb = new ToolBlock(toolBlock);
            formTb.ShowDialog();
        }

        //浮动显示
        private void floatBtn_Click(object sender, EventArgs e) {
            cogRecordDisplay1.StartLiveDisplay(fifo, false);
        }

        // 读取图片
        public ICogImage ReadImage() {

            string path = @"D:\A_material\MachineVision\work\VisiosPro\work_12_12\保险丝分类统计\img\color_fuses_03.png";

            //通过Bitmap类读取图片
            Bitmap bmp = new Bitmap(path);
            //转换成彩色图像CogImage24PlanarColor
            ICogImage image = new CogImage24PlanarColor(bmp);
            return image;

            //通过CogImageFileTool工具读取图片
            //  CogImageFileTool imageFile = new CogImageFileTool();
            //imageFile.Operator.Open(path, CogImageFileModeConstants.Read);
            //imageFile.Run();
            //return imageFile.OutputImage;
        }

        //加载ToolBlock
        public void LoadToolBlock() {
            //加载保险丝检测的vpp文件
            string path = Directory.GetCurrentDirectory() + "\\Vpp\\ToolBlock.vpp";

            //反序列化vpp文件   - 得到block对象
            toolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(path);
            //CogToolBlock 命名空间为using Cognex.VisionPro.ToolBlock;
        }
        #endregion

        #region 相机连接&&关闭&&采图完成
        /// <summary>
        /// 初始化相机
        /// </summary>
        public void InitialCamera() {
            //获取所有已连接的设备
            CogFrameGrabbers framerGrabbers = new CogFrameGrabbers();
            if (framerGrabbers.Count < 1) {
                MessageBox.Show("没有搜寻到相机");
            }
            foreach (ICogFrameGrabber frameGrabber in framerGrabbers) {
                cogFrameGrabber = frameGrabber;
                //创建采集接口
                fifo = cogFrameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                fifo.OwnedExposureParams.Exposure = 50;
                fifo.Complete += MAcq_Complete;

            }
        }


        private void CloseCamera() {
            //获取所有已连接的设备
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber item in frameGrabbers) {
                item.Disconnect(false);
            }

        }

        /// <summary>
        /// 采图完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAcq_Complete(object sender, CogCompleteEventArgs e) {
            //pending 待决的，待定的，待处理的；即将发生的，迫近的
            int numReadyVal, numPendingVal;
            bool busyVal;
            try {
                CogImage8Grey image = new CogImage8Grey();
                CogAcqInfo info = new CogAcqInfo();
                fifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);

                if (numReadyVal > 0) {
                    image = fifo.CompleteAcquireEx(info) as CogImage8Grey;
                    cogImage = image;
                    cogRecordDisplay1.Image = image;
                    cogRecordDisplay1.Fit();

                    //保存拍摄图像到本地
                    SaveOriginImage(cogImage);

                }
            } catch (Exception) {

                throw;
            }
        }
        #endregion

        #region 保存原图
        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="image">传入的图片</param>
        public void SaveOriginImage(ICogImage image) {
            string path = Directory.GetCurrentDirectory() + "\\Image";
            //Directory.Delete(path);
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            string fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.bmp";
            //把ICogImage类型的图像 转成bitmap格式
            //Bitmap bmp = image.ToBitmap();
            //bmp.Save($"{path}\\{fileName}", System.Drawing.Imaging.ImageFormat.Bmp);

            //通过CogImageFileTool工具保存图片  using Cognex.VisionPro.ImageFile;
            CogImageFileTool fileTool = new CogImageFileTool();
            fileTool.InputImage = image;
            fileTool.Operator.Open($"{path}\\{fileName}", CogImageFileModeConstants.Write);
            fileTool.Run();


        }
        #endregion

    }
}
