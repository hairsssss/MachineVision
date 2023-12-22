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
namespace VPTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         

        }
        //窗体加载时 执行的事件
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!CarmaManager.LoadVpp())
            {
                MessageBox.Show("相机加载失败");
            }
        }

        //相机拍照按钮事件
        private void button1_Click(object sender, EventArgs e)
        {

            if (CarmaManager.AcqFifoTool != null) {

                //执行拍照工具 （拍照）
                CarmaManager.AcqFifoTool.Run();
                //获取相机拍摄图片 并且显示在RecordDisplay 工具中
                cogRecordDisplay1.Image = CarmaManager.AcqFifoTool.OutputImage;
            }

        }

        private void FromClosing(object sender, FormClosingEventArgs e)
        {  
            //关闭相机
            CarmaManager.CloseCamera();
        }
        //进入acq设计窗体
        private void button2_Click(object sender, EventArgs e)
        {

            //打开Acq 设置页面
            if (CarmaManager.AcqFifoTool != null) {

                Acqfifo acqfifo = new Acqfifo(CarmaManager.AcqFifoTool);
                acqfifo.Show();
            }
        }
        //打开 cogRecordDisplay实时显示按钮事件
        private void button3_Click(object sender, EventArgs e)
        {
            //打开实时显示
            cogRecordDisplay1.StartLiveDisplay(CarmaManager.AcqFifoTool.Operator, false);
        }
        //关闭 cogRecordDisplay实时显示按钮事件 
        private void button4_Click(object sender, EventArgs e)
        {
            //关闭实时显示
            cogRecordDisplay1.StopLiveDisplay();
        }
    }
}
