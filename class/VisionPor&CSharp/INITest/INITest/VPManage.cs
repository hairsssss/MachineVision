using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ToolBlock;
using System.Runtime.InteropServices;

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
            catch
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
            catch
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

        //封装保存图像方法
        public static void SaveBitMapImageFormRecordDisplay(CogRecordDisplay display,string fileDirPath)
        {
            // 获取当前程序的运行路径
            string path = Directory.GetCurrentDirectory() + "\\"+fileDirPath;
            //没有有文件夹 需要创建
            if (!Directory.Exists(path))
            {
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


        /// <summary>
        /// 通过FrameGrabbers连接相机
        /// </summary>
        /// <param name="frameGrabber">相机对象</param>
        /// <param name="mAcqFifo">相机连接配置对象</param>
        /// <param name="exposureNumber">曝光率</param>
        /// <param name="handler">采图完成后事件</param>
        private static void FrameGrabbersInitialCamer(out ICogFrameGrabber frameGrabber,out ICogAcqFifo mAcqFifo,double exposureNumber, CogCompleteEventHandler handler)
        {
            frameGrabber = null;
            mAcqFifo = null;
            //创建CogFrameGrabbers对象，获取所有的硬件      目的： 类似集合  保存所有硬件相机对象
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();

            //根据CogFrameGrabbers元素个数  判断是否存在相机对象 
            if (frameGrabbers.Count > 1)
            {
                //遍历集合，获取相机
                foreach (ICogFrameGrabber frame in frameGrabbers)
                {

                    //用于保存相机对象
                    frameGrabber = frame;
                    //创建采集接口对象     CreateAcqFifo 方法:
                    //                     参数1：视频格式  Generic GigEVision (Mono) 灰度格式  从vp像源界面中 自行查看
                    //                     参数2: 像素格式  CogAcqFifoPixelFormatConstants.Format8Grey  灰度像素格式
                    //                     参数3 ：摄像头端口  默认0   后续如果有多个相机时  端口不要一样
                    //                     参数4：如果该值为真，则在创建fifo后将准备启动fifo。
                    mAcqFifo = frameGrabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                    //设置曝光时间
                    mAcqFifo.OwnedExposureParams.Exposure = exposureNumber;
                    //添加采图完成事件
                    mAcqFifo.Complete += handler;
                }

            }
         
            
           

        }


        /// <summary>
        /// FrameGrabbers 拍照方式
        /// </summary>
        /// <param name="mAcqFifo"></param>
        private static void FrameGrabbersStartAcquire(ICogAcqFifo mAcqFifo)
        {
            if (mAcqFifo != null)
            {
                mAcqFifo.StartAcquire();//采集图像
            }
        }

        private ICogImage LoadFrameGrabbersImage(ICogAcqFifo mAcqFifo)
        {

            //获取拍照图像 并且显示在RecordDisplay窗口中
            //    cogRecordDisplay1.Image = mAcqFifo.CompleteAcquireEx(new CogAcqInfo());
            int numReadyVal;
            int numPendingVal;
            bool busyVal;

            //转换成灰度图像
            //初始化灰度图对象
            CogImage8Grey greyImage = new CogImage8Grey();
            //初始化图像信息对象
            CogAcqInfo info = new CogAcqInfo();
            //获取fifo状态  用于检测拍照是否成功
            mAcqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
            if (numReadyVal > 0)
            {
                //获取图像
                greyImage = mAcqFifo.CompleteAcquireEx(info) as CogImage8Grey;
                return greyImage;
            }

            return null;
        }
        /// <summary>
        /// cogRecordDisplayx显示图像
        /// </summary>
        /// <param name="cogRecordDisplay">cogRecordDisplay对象</param>
        /// <param name="cogImage">图形对象</param>
        public static void RecordDisplayShow(CogRecordDisplay cogRecordDisplay,ICogImage cogImage)
        {
                  //图像 显示 cogRecordDisplay
                  cogRecordDisplay.Image = cogImage;
                    //图像按比例缩放 
                  cogRecordDisplay.Fit();
        }

    }


}
namespace FileOperateCSV {


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

namespace Ini
{
    public class IniAPI
    {
        #region INI文件操作

        /*
         * 针对INI文件的API操作方法，其中的节点（Section)、键（KEY）都不区分大小写
         * 如果指定的INI文件不存在，会自动创建该文件。
         * 
         * CharSet定义的时候使用了什么类型，在使用相关方法时必须要使用相应的类型
         *      例如 GetPrivateProfileSectionNames声明为CharSet.Auto,那么就应该使用 Marshal.PtrToStringAuto来读取相关内容
         *      如果使用的是CharSet.Ansi，就应该使用Marshal.PtrToStringAnsi来读取内容
         *      
         */

        #region API声明

        /// <summary>
        /// 获取所有节点名称(Section)
        /// </summary>
        /// <param name="lpszReturnBuffer">存放节点名称的内存地址,每个节点之间用\0分隔</param>
        /// <param name="nSize">内存大小(characters)</param>
        /// <param name="lpFileName">Ini文件</param>
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        /// <summary>
        /// 获取某个指定节点(Section)中所有KEY和Value
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpReturnedString">返回值的内存地址,每个之间用\0分隔</param>
        /// <param name="nSize">内存大小(characters)</param>
        /// <param name="lpFileName">Ini文件</param>
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件中指定的Key的值
        /// </summary>
        /// <param name="lpAppName">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔</param>
        /// <param name="lpKeyName">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔</param>
        /// <param name="lpDefault">读取失败时的默认值</param>
        /// <param name="lpReturnedString">读取的内容缓冲区，读取之后，多余的地方使用\0填充</param>
        /// <param name="nSize">内容缓冲区的长度</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>实际读取到的长度</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);

        //另一种声明方式,使用 StringBuilder 作为缓冲区类型的缺点是不能接受\0字符，会将\0及其后的字符截断,
        //所以对于lpAppName或lpKeyName为null的情况就不适用
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        //再一种声明，使用string作为缓冲区的类型同char[]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 将指定的键值对写到指定的节点，如果已经存在则替换。
        /// </summary>
        /// <param name="lpAppName">节点，如果不存在此节点，则创建此节点</param>
        /// <param name="lpString">Item键值对，多个用\0分隔,形如key1=value1\0key2=value2
        /// <para>如果为string.Empty，则删除指定节点下的所有内容，保留节点</para>
        /// <para>如果为null，则删除指定节点下的所有内容，并且删除该节点</para>
        /// </param>
        /// <param name="lpFileName">INI文件</param>
        /// <returns>是否成功写入</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]     //可以没有此行
        private static extern bool WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

        /// <summary>
        /// 将指定的键和值写到指定的节点，如果已经存在则替换
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpKeyName">键名称。如果为null，则删除指定的节点及其所有的项目</param>
        /// <param name="lpString">值内容。如果为null，则删除指定节点中指定的键。</param>
        /// <param name="lpFileName">INI文件</param>
        /// <returns>操作是否成功</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        #endregion

        #region 封装

        /// <summary>
        /// 读取INI文件中指定INI文件中的所有节点名称(Section)
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <returns>所有节点,没有内容返回string[0]</returns>
        public static string[] INIGetAllSectionNames(string iniFile)
        {
            uint MAX_BUFFER = 32767;    //默认为32767

            string[] sections = new string[0];      //返回值

            //申请内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = IniAPI.GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, iniFile);
            if (bytesReturned != 0)
            {
                //读取指定内存的内容
                string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned).ToString();

                //每个节点之间用\0分隔,末尾有一个\0
                sections = local.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //释放内存
            Marshal.FreeCoTaskMem(pReturnedString);

            return sections;
        }

        /// <summary>
        /// 获取INI文件中指定节点(Section)中的所有条目(key=value形式)
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <param name="section">节点名称</param>
        /// <returns>指定节点中的所有项目,没有内容返回string[0]</returns>
        public static string[] INIGetAllItems(string iniFile, string section)
        {
            //返回值形式为 key=value,例如 Color=Red
            uint MAX_BUFFER = 32767;    //默认为32767

            string[] items = new string[0];      //返回值

            //分配内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));

            uint bytesReturned = IniAPI.GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, iniFile);

            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {

                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Marshal.FreeCoTaskMem(pReturnedString);     //释放内存

            return items;
        }

        /// <summary>
        /// 获取INI文件中指定节点(Section)中的所有条目的Key列表
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <param name="section">节点名称</param>
        /// <returns>如果没有内容,反回string[0]</returns>
        public static string[] INIGetAllItemKeys(string iniFile, string section)
        {
            string[] value = new string[0];
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            char[] chars = new char[SIZE];
            uint bytesReturned = IniAPI.GetPrivateProfileString(section, null, null, chars, SIZE, iniFile);

            if (bytesReturned != 0)
            {
                value = new string(chars).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            chars = null;

            return value;
        }

        /// <summary>
        /// 读取INI文件中指定KEY的字符串型值
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <param name="section">节点名称</param>
        /// <param name="key">键名称</param>
        /// <param name="defaultValue">如果没此KEY所使用的默认值</param>
        /// <returns>读取到的值</returns>
        public static string INIGetStringValue(string iniFile, string section, string key, string defaultValue)
        {
            string value = defaultValue;
            const int SIZE = 1024 * 10;

            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称(key)", "key");
            }

            StringBuilder sb = new StringBuilder(SIZE);
            uint bytesReturned = IniAPI.GetPrivateProfileString(section, key, defaultValue, sb, SIZE, iniFile);

            if (bytesReturned != 0)
            {
                value = sb.ToString();
            }
            sb = null;

            return value;
        }

   
        /// <summary>
        /// 在INI文件中，将指定的键值对写到指定的节点，如果已经存在则替换
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        /// <param name="section">节点，如果不存在此节点，则创建此节点</param>
        /// <param name="items">键值对，多个用\0分隔,形如key1=value1\0key2=value2</param>
        /// <returns></returns>
        public static bool INIWriteItems(string iniFile, string section, string items)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(items))
            {
                throw new ArgumentException("必须指定键值对", "items");
            }

            return IniAPI.WritePrivateProfileSection(section, items, iniFile);
        }

        /// <summary>
        /// 在INI文件中，指定节点写入指定的键及值。如果已经存在，则替换。如果没有则创建。
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>操作是否成功</returns>
        public static bool INIWriteValue(string iniFile, string section, string key, string value)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称", "key");
            }

            if (value == null)
            {
                throw new ArgumentException("值不能为null", "value");
            }

            return IniAPI.WritePrivateProfileString(section, key, value, iniFile);

        }


        public static int GetPrivateProfileInt(string lpAppName, string lpKeyName, int Default, string lpFileName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);

            return Convert.ToInt32(lpReturnedString.ToString());
        }
        public static double GetPrivateProfileDouble(string lpAppName, string lpKeyName, double Default, string lpFielName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFielName);
            //ZazaniaoDll.GetPrivateprofileString(lpAppName,lpKeyName,Convert.ToString(Default),lpReturnedString,1024,lpFielName);
            return Convert.ToDouble(lpReturnedString.ToString());
        }
        public static string GetPrivateProfileString(string lpAppName, string lpKeyName, string Default, string lpFileName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            GetPrivateProfileString(lpAppName, lpKeyName, Default, lpReturnedString, 1024, lpFileName);
            return lpReturnedString.ToString();
        }
        /// <summary>
        /// 在INI文件中，删除指定节点中的指定的键。
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        /// <param name="section">节点</param>
        /// <param name="key">键</param>
        /// <returns>操作是否成功</returns>
        public static bool INIDeleteKey(string iniFile, string section, string key)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称", "key");
            }

            return IniAPI.WritePrivateProfileString(section, key, null, iniFile);
        }

        /// <summary>
        /// 在INI文件中，删除指定的节点。
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        /// <param name="section">节点</param>
        /// <returns>操作是否成功</returns>
        public static bool INIDeleteSection(string iniFile, string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            return IniAPI.WritePrivateProfileString(section, null, null, iniFile);
        }

        /// <summary>
        /// 在INI文件中，删除指定节点中的所有内容。
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        /// <param name="section">节点</param>
        /// <returns>操作是否成功</returns>
        public static bool INIEmptySection(string iniFile, string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }

            return IniAPI.WritePrivateProfileSection(section, string.Empty, iniFile);
        }

        #endregion

        #endregion

    }
}