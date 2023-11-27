using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day20_1 {
    public partial class Form1 : Form {
        public Form1() {
            //系统自动创建控件功能的方法
            InitializeComponent();


            //手动创建控件    控件 - 窗体可显式的元素的总称
            //控件包含属性和时间   窗体本质也是控件

            this.BackColor = Color.Teal;

            //属性查看
            //方式一：右键--属性     易操作不用写代码，只能完成静态设置
            //方式二：通过空间类和控件对象打点调用  操作繁琐，写代码

            Text = "王德发";
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
        }

        private void Form1_DoubleClick(object sender, EventArgs e) {
            Console.WriteLine(121);
            Text = "ohhhh";
            MessageBox.Show("点击了", "标题", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void Load1(object sender, EventArgs e) {

        }

        private void Click1(object sender, EventArgs e) {

        }
    }

}
