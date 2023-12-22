using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ImageFile;

namespace TBRan事件
{
    public partial class FrmMain : Form
    {

      //映射block工具
      private  CogToolBlock tb;
      //保存本地读取图像
      private  ICogImage cogImage;
        public FrmMain()
        {
            InitializeComponent();
        }
        //窗体加载执行方法
        private void FrmMain_Load(object sender, EventArgs e)
        {   
            //获取tb对象
            tb =  VPManger.LoadBlockVPP("\\齿轮检测TB.vpp",Tb_Ran);
        }
        //加载本地齿轮原图
        private void btnLoadImage_Click(object sender, EventArgs e)
        {

            //查找本地图片路径集合
            string [] files =    VPManger.LoadImages(Directory.GetCurrentDirectory() + @"\cilunyuantu");
            ////遍历路径集合  
            foreach (string file in files) {
                //把路径集合添加到listBox控件中
                listBox1.Items.Add(file);
            }
        }
        //lisxbox选择不同的选项时触发事件
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            //获取listBox1选中项名称 （文件路径）
            string fileName = listBox1.SelectedItem.ToString();
            CogImage8Grey greyImage =  VPManger.CreateBitMapToImage8Grey(fileName);
            //赋值给私有字段  用于其他函数使用
            cogImage = greyImage;
            //运行block计算检测结果 且显示结果图像到 RecordDisPlay 
            VPManger.BlockRunAndRecordShowBlockImage(tb, "InputImage", cogRecordDisplay1, greyImage);
 
        }
        /// <summary>
        /// toolblock运行完成时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Ran(object sender, EventArgs e)
        {
            //转换成toolblock
            CogToolBlock ctb = sender as CogToolBlock;
            //获取输出的结果
            double max = (double)ctb.Outputs["Max"].Value;
            double min = (double)ctb.Outputs["Min"].Value;
            double mean = (double)ctb.Outputs["Mean"].Value;
            //显示结果  转换double类型为string 且 精确到小数点后两位
            lblMax.Text = max.ToString("0.00");
            lblMin.Text = min.ToString("0.00");
            lblMean.Text = mean.ToString("0.00");

            //保存检测结果到csv表格文件中 
            //注意每个结果 用 逗号分割开   在表格中每个结果就会独占一格
            string result = mean > 180 ? "OK" : "NG";
            string sb2 = $"{max},{min},{mean},{result}";
            FileOperate.WriteCSV(sb2);
        }

        private void btnSaveRawImage_Click(object sender, EventArgs e)
        {
           VPManger.SaveRawImage(cogImage);
        }

        private void btnSaveDealImage_Click(object sender, EventArgs e)
        {
          VPManger.SaveDealImage(cogRecordDisplay1);
        }

  
    }
}
