
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.VPManage;
using Cognex.VisionPro.ToolBlock;
namespace InspectionTB
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }  
        //私有变量 
        CogAcqFifoTool cogAcqFifoTool;
        CogToolBlock cogToolBlock;

        //页面加载时事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //映射acq和block工具
            cogAcqFifoTool= VPManage.LoadAcqVPP("\\CogAcqTool.vpp");
            cogToolBlock= VPManage.LoadBlockVPP("\\TBBlob.vpp");
        }
        //页面关闭时事件
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   vision.CloseCam();//关闭相机
            VPManage.CloseCam();
        }
    
        //拍照并显示
        private void btnTrigger_Click(object sender, EventArgs e)
        {
                    
            //运行acq 且 record显示图像
            VPManage.AcqRunAndRecordShowImage(cogAcqFifoTool,cogRecordDisplay1);


            

            }
        //检测按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            //创建CogImageConvertTool 彩色图像转换成灰度图
            CogImage8Grey cogImage8Grey = VPManage.CreateCogImageConvertTool(cogRecordDisplay1.Image);
            //运行block 且找到 子工具blob   
            CogBlobTool blobTool = VPManage.BlockRunAndFindSubTool(cogToolBlock, cogImage8Grey, "CogBlobTool1") as CogBlobTool;
            //把blob结果显示在label上
            lblCount.Text = blobTool.Results.GetBlobs().Count.ToString();

            //lblCount.Text = cogToolBlock.Outputs["Count"].Value.ToString();
            //显示检测结果图像到cogRecordDisplay
            //SubRecords[0] 根据索引值查找对应输出窗口图像
            //SubRecords["CogBlobTool1.InputImage"] 根据窗口名字查找对应输出窗口图像
            //cogRecordDisplay1.Record = cogToolBlock.CreateLastRunRecord().SubRecords[0];
            cogRecordDisplay1.Record = cogToolBlock.CreateLastRunRecord().SubRecords["CogBlobTool1.InputImage"];
            cogRecordDisplay1.Fit();
        } 
        //配置acq参数页面打开事件
        private void tsbCam_Click(object sender, EventArgs e)
        {
            //配置acq参数页面
            FrmCam frmCam = new FrmCam(cogAcqFifoTool);
            frmCam.ShowDialog();
        }
        //配置block页面
        private void blockButton_Click(object sender, EventArgs e)
        {
            TBFrm tBFrm = new TBFrm();
        }
    }

       
    }

