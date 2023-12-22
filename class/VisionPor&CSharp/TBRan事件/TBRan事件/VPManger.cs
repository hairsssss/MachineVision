using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
namespace TBRan事件
{

    //封装VP管理类
    internal class VPManger
    {
        /// <summary>
        /// 加载本地blockvpp文件
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
                return null;
            }
            //"\\齿轮检测TB.vpp"
            //反序列化 block对象
            CogToolBlock tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(_path+ blockVppNamePath);
            //blokc绑定事件    --block运行（run方法）完成后执行
            tb.Ran += eventHandler;
            return tb;
        }


        /// <summary>
        /// 获取原图文件路径集合
        /// </summary>
        /// <param name="ImagesDirectory">图片所在文件夹路径</param>
        /// <returns>文件夹所有图像完整路径集合</returns>
        public  static string[] LoadImages(string ImagesDirectory)
        {
            //判断路径是否存在
            if (!Directory.Exists(ImagesDirectory))
            { 

                Directory.CreateDirectory(ImagesDirectory);
                return null;
            }
            //获取路径下所有文件的路径名称
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
        public static void BlockRunAndRecordShowBlockImage(CogToolBlock tb ,string tbInputImageParms, CogRecordDisplay rd,ICogImage image)
        {
            //设置输入图片
            tb.Inputs[tbInputImageParms].Value = image;
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
            //判断是否存在文件夹 不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //文件名称路径
            string filename = $"{path}\\{DateTime.Now.ToString("yyyy-MM-dd")}.csv";     
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
