using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Day22_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //panel 容器标签  为了管理子控件  使控件的布局更有序
            //修改 panel1中button的背景色
            //1.
            button1.BackColor = Color.Red;
            button2.BackColor = Color.Red;
            button3.BackColor = Color.Red;
            ///   this.panel1
            ///   
            //当前窗体中 包含的子控件个数
            Console.WriteLine(this.Controls.Count);

            foreach (Control item in this.Controls)
            {
                item.BackColor = Color.Red;
            }


            foreach (Control item in this.panel1.Controls)
            {
                item.Text = "123";
            }

            //单独修改某个按钮文字颜色

            Control control = this.panel1.Controls[0];
            //类型转换
            Button button = control as Button;
            button.ForeColor = Color.Blue;
            Control control1 = this.panel1.Controls[3];
            Button button11 = control1 as Button;
            button11.ForeColor = Color.Blue;


            //panel3 
            foreach (Control item in this.panel3.Controls)
            {
                item.BackColor = Color.Blue;
            }

            //通过tag属性标识不同控件类型
            //foreach (Control item in this.panel3.Controls)
            //{
            //    if (item.Tag.ToString() == "1")
            //    {
            //        item.Text = "4444444444444";
            //    }
            //    else if (item.Tag.ToString() == "2")
            //    {

            //        item.Text = "5555555555";

            //    }
            //    else if (item.Tag.ToString() == "3") {

            //        item.Text = "666666666";
            //    }
            //}

            //通过is 判断类型
            foreach (Control item in this.panel3.Controls)
            {
                if (item is Button)
                {
                    item.Text = "000000000000000000000000";

                }
                else if (item is Label) {

                    item.Text = "11111111111";

                }
                else if (item is TextBox) {

                    item.Text = "222222222222222222222222222111";
                }
            }


            //panle 动态添加子控件
        }
        public void PanleAddEn() {


            //动态创建按钮
            Button buttonTemp = new Button();
            buttonTemp.Location = new Point(38, 25);
            buttonTemp.Name = "buttonTemp";
            buttonTemp.Size = new Size(75, 71);
            buttonTemp.TabIndex = 0;
            buttonTemp.Text = "button1";

            //指定button添加到哪个父元素中
            this.panel2.Controls.Add(buttonTemp);

        }
        public void PanleRemoveEn()
        {
          Control [] tempContorlArray =  panel2.Controls.Find("buttonTemp", true);


            foreach (var item in tempContorlArray)
            {
                this.panel2.Controls.Remove(item);
            }

        }

        //创建和删除
        bool isTrue = true;
        private void button5_Click(object sender, EventArgs e)
        {
            if (isTrue == true)
            {
                PanleAddEn();
            }
            else 
            {

                PanleRemoveEn();
            }
            isTrue = !isTrue;
        }
    }
}
