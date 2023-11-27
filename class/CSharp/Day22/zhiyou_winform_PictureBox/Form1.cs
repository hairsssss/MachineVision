using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 https://img0.baidu.com/it/u=2642223955,2176778396&fm=253&fmt=auto&app=138&f=JPEG?w=889&h=500
 https://pic.616pic.com/photoone/00/03/96/618ce5441d6a75161.jpg
https://img0.baidu.com/it/u=3059223957,798715771&fm=253&fmt=auto&app=138&f=JPEG?w=667&h=500

"C:\Users\renre\Desktop\4.jpg"
https://pic.616pic.com/photoone/00/00/56/618ce8b3797b76152.jpg
 */
namespace zhiyou_winform_PictureBox
{    
    //常用属性
    //sizeMode 设置图像和控件的比例
    //imageLocation  通过设置图片路径或者web路径 来显式图片
    public partial class Form1 : Form
    { 
        //创建 保存图片的list数组
        private List<string> picUrlList = new List<string>();
        //记录 当前图片的位置（索引值）
        private int count =0;
        public Form1()
        {
            InitializeComponent();
            //绝对路径
            //picUrlList.Add(@"C:\Users\renre\Desktop\CSharp\winform1\zhiyou_winform_PictureBox\Resources\1.jpg");
            //picUrlList.Add(@"C:\Users\renre\Desktop\CSharp\winform1\zhiyou_winform_PictureBox\Resources\2.jpg");
            //picUrlList.Add(@"C:\Users\renre\Desktop\CSharp\winform1\zhiyou_winform_PictureBox\Resources\3.jpg");
            //picUrlList.Add(@"C:\Users\renre\Desktop\CSharp\winform1\zhiyou_winform_PictureBox\Resources\4.jpg");

            //相对路径
            //保存图片的本地路径
            picUrlList.Add(@"..\..\resources\1.jpg");
            picUrlList.Add(@"..\..\resources\2.jpg");
            picUrlList.Add(@"..\..\resources\3.jpg");
            picUrlList.Add(@"..\..\resources\4.jpg");
        }


        //下一张
        private void button1_Click(object sender, EventArgs e)
        {

            //查看项目的debug目录
            //C:\Users\renre\Desktop\CSharp\winform1\zhiyou_winform_PictureBox\bin\Debug
            string path = Application.StartupPath; 
            Console.WriteLine(path);


            if (picUrlList.Count == count) 
            {
                count = 0;
              

                //添加图片方式1
             //  pictureBox1.ImageLocation = picUrlList[count];
                 //添加图片方式2
             // pictureBox1.Image = Image.FromFile(picUrlList[count]);
            }
            else
            {
                //图片拉伸
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //方式1
               //  pictureBox1.ImageLocation = picUrlList[count]; 
                //方式2
               // pictureBox1.Image = Image.FromFile(picUrlList[count]);
            }
            pictureBox1.Image = Image.FromFile(picUrlList[count]);
            count++;

        }

        //上一张
        private void button2_Click(object sender, EventArgs e)
        {
            if (count<0)
            {
                count = picUrlList.Count-1;

            
            }
            pictureBox1.Image = Image.FromFile(picUrlList[count]);
            count--;
        }
        //定时器 打开时 根据间隔时间 自动执行的事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picUrlList.Count -1 ==  count)
            {
               

                pictureBox1.ImageLocation = picUrlList[count];
                count = 0;
                // pictureBox1.Image = Image.FromFile(picUrlList[count]);
            }
            else
            {

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //方式1
                //  pictureBox1.ImageLocation = picUrlList[count]; 
                //方式2
                pictureBox1.Image = Image.FromFile(picUrlList[count]);

            }
            count++;
        }
    }
}
