using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ToolBlock;

namespace Test2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        //硬件对象-相机
        ICogFrameGrabber mFrameGrabber = null;
        //相机连接对象
        ICogAcqFifo mAcq = null;
        //采图对象
        ICogImage mImage = null;
        //Block工具
        CogToolBlock tb = null;


        #region 窗体和按钮事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitialCamera();
            //调用block.vpp文件
            LoadToolBlock();
        }
        /// <summary>
        /// 拍照btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrigger_Click(object sender, EventArgs e)
        {
            //采图
            mAcq.StartAcquire();
        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCamera();
        }
        /// <summary>
        /// 保存图片Btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (mImage != null)
            {  

                //保存原图
               //  SaveOriginImage(mImage);

                ///
                SaveDealImage(cogRecordDisplay1);
            }

        }
        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            mImage = ReadImage();
            //显示在 cogRecordDisplay窗口中
            cogRecordDisplay1.Image = mImage;

            cogRecordDisplay1.Fit();
            
        }
        //检测图片
        private void btnInspect_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                //输入图片
                tb.Inputs["OutputImage"].Value = ReadImage();
                //运行工具
                tb.Run();


                //显示图形

                //SubRecords集合  包含 blcok工具 显示图像窗口的集合
                cogRecordDisplay1.Record = tb.CreateLastRunRecord().SubRecords[0];
                cogRecordDisplay1.Fit();
            }
        }
        //打开block 工具配置页面
        private void btnFrmTB_Click(object sender, EventArgs e)
        {
            FrmTB frmTB = new FrmTB(tb);
            frmTB.ShowDialog();
        }

        #endregion



        #region 连接相机并采图
        /// <summary>
        /// 初始化相机
        /// </summary>
        public void InitialCamera()
        {
            //获取所有已连接的设备
            CogFrameGrabbers framerGrabbers = new CogFrameGrabbers();
            if (framerGrabbers.Count < 1)
            {
                MessageBox.Show("没有搜寻到相机");
            }
            foreach (ICogFrameGrabber frameGrabber in framerGrabbers)
            {
                mFrameGrabber = frameGrabber;
                //创建采集接口
                mAcq = mFrameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                mAcq.OwnedExposureParams.Exposure = 50;
                mAcq.Complete += MAcq_Complete;

            }
        }
        /// <summary>
        /// 采图完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAcq_Complete(object sender, CogCompleteEventArgs e)
        {
            //pending 待决的，待定的，待处理的；即将发生的，迫近的
            int numReadyVal, numPendingVal;
            bool busyVal;
            try
            {
                CogImage8Grey image = new CogImage8Grey();
                CogAcqInfo info = new CogAcqInfo();
                mAcq.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);

                if (numReadyVal > 0)
                {
                    image = mAcq.CompleteAcquireEx(info) as CogImage8Grey;
                    mImage = image;
                    cogRecordDisplay1.Image = image;
                    cogRecordDisplay1.Fit();


                    //保存拍摄图像到本地
                    SaveOriginImage(mImage);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="exp"></param>
        public void SetExposure(int exp)
        {
            mAcq.OwnedExposureParams.Exposure = exp;

        }
        private void CloseCamera()
        {
            //获取所有已连接的设备
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber item in frameGrabbers)
            {
                item.Disconnect(false);
            }

        }
        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExposure_Click(object sender, EventArgs e)
        {

            int exp = Convert.ToInt32(txtExposure.Text);
            SetExposure(exp);
        }
        #endregion

        #region 读写图片
        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="image">传入的图片</param>
        public void SaveOriginImage(ICogImage image)
        {
            string path = Directory.GetCurrentDirectory() + "\\Image";
            //Directory.Delete(path);
            if (!Directory.Exists(path))
            {
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
        /// <summary>
        /// 保存处理后的图片
        /// </summary>
        /// <param name="display">传入CogRecordDisplay控件变量</param>
        public void SaveDealImage(CogRecordDisplay display)
        {
            string path = Directory.GetCurrentDirectory() + "\\DealImage";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-sss")}_ResultImage.jpg";
            //创建Bitmap图像
            Bitmap bmp = display.CreateContentBitmap(CogDisplayContentBitmapConstants.Image) as Bitmap;
            bmp.Save(path + "\\" + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
        /// <summary>
        /// 读取图片
        /// </summary>
        /// <returns></returns>
        public ICogImage ReadImage()
        {

            string path = @"C:\Users\renre\Desktop\C#226_8_VSIONPRO\02\baoxiansi\img\color_fuses_00.png";

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


        #endregion

        //1.在vp中先做好检测流程  
        //2.打包block工具
        //3.把block工具放在winfom项目中  供后续检测使用
        //3.在winform 完成 拍照 保存 加载 图像    设置拍照参数（曝光率等） 等 其他功能
        //4.加载本地block vpp文件 
        //5.加载检测图像
        //6.检测功能
        //7.保存检测后的图像
        //8.如果block工具检测出现问题  需要重新调整参数（1.打开vp 调整  然后覆盖原vpp文件 2.在vs中添加blcok设置页面 调整  然后保存调整后的vpp文件）
        /// <summary>
        /// 加载ToolBlock
        /// </summary>
        public void LoadToolBlock()
        {    

            //加载保险丝检测的vpp文件
            string path = Directory.GetCurrentDirectory() + "\\Vpp\\TB1.vpp";
           
            //反序列化vpp文件   - 得到block对象
            tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(path);
            //CogToolBlock 命名空间为using Cognex.VisionPro.ToolBlock;
        }
        //显示浮动窗体  用于实时查看图像
        private void button1_Click(object sender, EventArgs e)
        {
            cogRecordDisplay1.StartLiveDisplay(mAcq,false);
        }
    }
}
