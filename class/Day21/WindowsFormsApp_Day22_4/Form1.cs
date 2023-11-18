using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Day22_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //



        }

        private void aaaa(object sender, EventArgs e)
        {
            MessageBox.Show($"当前选择的性别{radioButton1.Text}");
        }

        private void bbb(object sender, EventArgs e)
        {
            MessageBox.Show($"当前选择的性别{radioButton2.Text}");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           // this.radioButton1.Text = "111";

           // sender 代表当前绑定事件的控件对象
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked == true) {

                Console.WriteLine("11111111");
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked == true)
            {

                Console.WriteLine("222222222");
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            checkBox2.Checked = checkBox1.Checked;
            Console.WriteLine("444444");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("55555");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("666666");
        }
    }
}
