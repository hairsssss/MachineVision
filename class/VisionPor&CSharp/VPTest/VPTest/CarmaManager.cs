using System;
using System.Collections.Generic;
//导入IO框架 读取本地文件
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//导入vp基础框架
using Cognex.VisionPro;
namespace VPTest {
    internal class CarmaManager {
        public static CogAcqFifoTool AcqFifoTool { get; set; }
        //加载相机
        public static bool LoadVpp() {

            try {
                // //Directory.GetCurrentDirectory() 获取项目debug路径
                //acqPath 获取相机文件路径
                string acqPath = Directory.GetCurrentDirectory() + "\\VPP\\acq.vpp";
                //康耐视vp工具序列化工具
                //CogSerializer
                if (String.IsNullOrEmpty(acqPath)) {
                    return false;

                } else {
                    CogAcqFifoTool acqTool = (CogAcqFifoTool)CogSerializer.LoadObjectFromFile(acqPath);
                    //acq相机连接工具不等于空 || FrameGrabber 相机硬件集合     

                    //MessageBox.Show((acqTool.Operator).ToString());
                    //MessageBox.Show((acqTool.Operator.FrameGrabber == null).ToString());

                    if (acqTool == null || acqTool.Operator.FrameGrabber == null) {
                        return false;
                    }
                    //保存acq对象 用于外部使用
                    AcqFifoTool = acqTool;
                    return true;
                }

            } catch (Exception) {

                return false;
            }


        }
        public static bool SaveVpp(CogAcqFifoTool fifo) {
            //Directory.GetCurrentDirectory() 获取项目debug路径
            string path = Directory.GetCurrentDirectory() + "\\VPP\\acq.vpp";
            try {
                CogSerializer.SaveObjectToFile(fifo, path);
                return true;
            } catch (Exception ex) {
                return false;
            }

        }

        //关闭相机
        public static void CloseCamera() {
            if (AcqFifoTool != null && AcqFifoTool.Operator.FrameGrabber != null) {

                //断开相机连接
                AcqFifoTool.Operator.FrameGrabber.Disconnect(true);

            }
        }
    }
}
