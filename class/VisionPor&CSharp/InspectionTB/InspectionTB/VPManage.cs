using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ToolBlock;
using InspectionTB;
namespace Cognex.VisionPro.VPManage
{
    //封装VP管理类
    internal class VPManage
    {
        /// <summary>
        /// 加载acqVpp
        /// </summary>
        /// <param name="blockVppNamePath"></param>
        /// <param name="eventHandler"></param>
        /// <returns></returns>
        public static CogAcqFifoTool LoadAcqVPP(string AcqVPPNamePath)
        {
            string _path = Directory.GetCurrentDirectory() + "\\VPP";
            
            if (!Directory.Exists(_path))
            {
                //创建文件夹路径
                Directory.CreateDirectory(_path);
                return null;
            }

            //反序列化 AcqFifoTool对象
            CogAcqFifoTool fifoTool = CogSerializer.LoadObjectFromFile(_path+ AcqVPPNamePath) as CogAcqFifoTool;
            return fifoTool;
        }
        /// <summary>
        /// LoadBlockVPP
        /// </summary>
        /// <param name="blockVppNamePath"></param>
        /// <returns></returns>
        public static CogToolBlock LoadBlockVPP(string blockVppNamePath)
        {
            string _path = Directory.GetCurrentDirectory() + "\\VPP";
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
                return null;
            }
            //反序列化 block对象
            CogToolBlock tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(_path + blockVppNamePath);
            return tb;
        }

        /// <summary>
        /// 运行acq 获得图像 且赋值给record
        /// </summary>
        /// <param name="cogAcqFifoTool"></param>
        /// <param name="cogRecordDisplay"></param>
        /// <returns></returns>
        public static bool AcqRunAndRecordShowImage(CogAcqFifoTool cogAcqFifoTool, CogRecordDisplay cogRecordDisplay)
        {
            if (cogAcqFifoTool != null && cogAcqFifoTool.Operator.FrameGrabber != null)
            {
                //拍照
                cogAcqFifoTool.Run();
                //acq图像 赋值给record图像
                cogRecordDisplay.Image = cogAcqFifoTool.OutputImage;
                //
                cogRecordDisplay.Fit();
                return true;
            }
            else { 
                return false;

            }
        }

        /// <summary>
        /// 创建灰度图工具 转换图像 
        /// </summary>
        /// <param name="cogImage"></param>
        /// <returns></returns>
        public static CogImage8Grey CreateCogImageConvertTool(ICogImage cogImage) {

            //单独声明一个CogImageConvertTool工具对象
            CogImageConvertTool convertTool = new CogImageConvertTool();
            //提供输入图像
            convertTool.InputImage = cogImage;
            //设置运行模式   RGB转8位灰度图
            convertTool.RunParams.RunMode = CogImageConvertRunModeConstants.Intensity;
            //运行工具
            convertTool.Run();






            //获取输出的灰度图像
            CogImage8Grey greyImage = convertTool.OutputImage as CogImage8Grey;
            return greyImage;



        }
        /// <summary>
        /// 运行block且查找到某个工具
        /// </summary>
        /// <param name="cogToolBlock">block对象</param>
        /// <param name="cogImage">检测的图片</param>
        /// <param name="subToolName">子工具的名字</param>
        /// <returns></returns>
        public static ICogTool BlockRunAndFindSubTool(CogToolBlock cogToolBlock,ICogImage cogImage,string subToolName) {
            //设置tool block的输入图片
            cogToolBlock.Inputs["InputImage"].Value = cogImage;
            //运行CogToolBlock工具
            cogToolBlock.Run();
            //判断TB工具是否运行成功
            if (cogToolBlock.RunStatus.Result == CogToolResultConstants.Accept)
            {
                //查找block中某个工具（比如blob工具 所有工具类都继承于ICogTool）
                ICogTool ICogTool = cogToolBlock.Tools[subToolName];

                return ICogTool;

            }
            return null;
        }

        /// <summary>
        /// 保存acqVPP
        /// </summary>
        /// <returns></returns>
        public static bool SaveAcqVpp(CogAcqFifoTool fifoTool, string _fifoPath)
        {
            try
            {   
                CogSerializer.SaveObjectToFile(fifoTool, _fifoPath);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }


        /// <summary>
        /// 保存blockVPP
        /// </summary>
        /// <returns></returns>
        public static bool SaveBlockVpp(CogToolBlock cogToolBlock, string _blockPath)

        {
            try
            {
                CogSerializer.SaveObjectToFile(cogToolBlock, _blockPath);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        /// <summary>
        /// 关闭相机
        /// </summary>
        public static void CloseCam()
        {
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber f in frameGrabbers)
                f.Disconnect(false);

        }

        /// <summary>
        /// 加载本地blockvpp文件且绑定事件
        /// </summary>
        /// <param name="blockVppFilePath">文件路径</param>
        /// <param name="eventHandler">block执行后绑定事件</param>
        /// <returns></returns>
        public static CogToolBlock LoadBlockVPP(string blockVppNamePath, System.EventHandler eventHandler)
        {
            string _path = Directory.GetCurrentDirectory() + "\\VPP";
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            //"\\齿轮检测TB.vpp"
            //反序列化 block对象
            CogToolBlock tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(_path + blockVppNamePath);
            //blokc绑定事件    --block运行（run方法）完成时发生
            tb.Ran += eventHandler;
            return tb;
        }


        /// <summary>
        /// 获取原图文件路径集合
        /// </summary>
        /// <param name="ImagesDirectory">图片所在文件夹路径</param>
        /// <returns>文件夹所有图像完整路径集合</returns>
        public static string[] LoadImages(string ImagesDirectory)
        {
            //判断路径是否存在
            if (!Directory.Exists(ImagesDirectory))
            {
                return null;
            }
            //获取路径下所有文件的名称
            return Directory.GetFiles(ImagesDirectory);

        }
        /// <summary>
        /// 创建bitmap图像并转换成灰度图
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        public static CogImage8Grey CreateBitMapToImage8Grey(string imagePath)
        {

            if (!File.Exists(imagePath))
            {
                return null;
            }
            //创建bitmap格式的图片并读取
            Bitmap bmp = new Bitmap(imagePath);
            //创建灰度图
            CogImage8Grey greyImage = new CogImage8Grey(bmp);
            return greyImage;
            ////
            //cogImage = greyImage;
            ////设置输入图片
            //tb.Inputs["InputImage"].Value = greyImage;
            ////运行
            //tb.Run();
            ////显示图像和图形
            //cogRecordDisplay1.Record = tb.CreateLastRunRecord().SubRecords[0];
            //cogRecordDisplay1.Fit();
        }

        /// <summary>
        /// 彩图
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static CogImage24PlanarColor CreateBitMapToImage24PlanarColor(string imagePath)
        {

            if (!File.Exists(imagePath))
            {
                return null;
            }
            //创建bitmap格式的图片并读取
            Bitmap bmp = new Bitmap(imagePath);
            //创建创建彩图
            CogImage24PlanarColor ColorImage = new CogImage24PlanarColor(bmp);
            return ColorImage;
        }


        /// <summary>
        /// 运行block工具计算检测结果 且显示结果图像到 RecordDisPlay 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="tbInputImageParms"></param>
        /// <param name="rd"></param>
        /// <param name="image"></param>
        public static void BlockRunAndRecordShowBlockImage(CogToolBlock tb, string blockInputImageParms, CogRecordDisplay rd, ICogImage image)
        {
            //设置输入图片
            tb.Inputs[blockInputImageParms].Value = image;
            //运行
            tb.Run();
            //显示图像和图形
            rd.Record = tb.CreateLastRunRecord().SubRecords[0];
            rd.Fit();
        }
        /// <summary>
        /// 保存原图
        /// </summary>
        /// <param name="image">图片</param>
        public static void SaveRawImage(ICogImage image)
        {
            //图像转换成bitmap格式
            Bitmap bmp = image.ToBitmap();
            //文件夹路径   当前的时间 年-月-日    
            string path = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";

            //文件的保存地址     当前的时间 年-月-日-时-分-秒-毫秒
            string fileName = $"{path}\\{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff")}.bmp";
            //判断文件夹是否存在
            if (!Directory.Exists(path))
            {
                //创建文件夹
                Directory.CreateDirectory(path);
            }
            //保存图像，类型是bmp
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
            /*
             通过CogImageFileTool保存原图
              CogImageFileTool fileTool = new CogImageFileTool();
            //设置输入图片
            fileTool.InputImage = image;
            //设置模式是写入图片到对应的地址
            fileTool.Operator.Open(fileName, CogImageFileModeConstants.Write);
            //运行工具
            fileTool.Run();
             
             */
        }


        /// <summary>
        /// 保存处理后图
        /// </summary>
        /// <param name="display"></param>
        public static void SaveDealImage(CogRecordDisplay display)
        {
            //文件夹路径   当前的时间 年-月-日
            string path = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            //文件的保存地址
            string fileName = $"{path}\\dealimage1.jpg";
            //判断文件夹是否存在
            if (!Directory.Exists(path))
            {
                //创建文件夹
                Directory.CreateDirectory(path);
            }
            //通过CogRecordDisplay控件当前显示的图像图形信息创建一个bitmap类型的图片
            Bitmap bmp = display.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image) as Bitmap;
            //保存
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

        }

    }


    //vp文件管理类
    public class FileOperate
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data">数据</param>
        public static void WriteCSV(string data)
        {
            //存储路径
            string path = Directory.GetCurrentDirectory() + "\\Data\\";
            //文件名称
            string filename = $"{path}\\{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
            //判断是否存在文件夹 不存在则创建
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //判断文件是否存在 不存在则创建
            if (!File.Exists(filename))
            {
                //创建文件流 用于创建文件  
                using (FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {  
                    //创建写入流  写入 csv文件 表头内容
                    using (StreamWriter sw1 = new StreamWriter(fs1))
                    {
                        StringBuilder sb1 = new StringBuilder();
                        //声明表头
                        sb1.Append("日期").Append(",").Append("最大值").Append(",").Append("最小值").Append(",").Append("平均值")
                            .Append(",").Append("结果");
                        //将表头写入表格里
                        sw1.WriteLine(sb1);
                    }
                }
            }
            //创建写入流  写入 csv文件 表体内容
            using (StreamWriter sw2 = new StreamWriter(filename, true, Encoding.Default))
            {
                string res = $"{DateTime.Now.ToString("HH:mm:ss:fff")},{data}";
                //将表体内容写入
                sw2.WriteLine(res);
            }
        }
        /// <summary>
        /// 读取文件的内容
        /// </summary>
        /// <returns></returns>
        public static string ReadFile()
        {
            string path = Directory.GetCurrentDirectory() + "\\Data\\";
            string filename = $"{path}\\{DateTime.Now.ToString("yyyy-MM-dd")}.csv";

            using (StreamReader sr = new StreamReader(filename, Encoding.Default))
            {
                string str = string.Empty;
                str = sr.ReadLine();
                return str;
            }
        }
    }
}
