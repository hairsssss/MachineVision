using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZhiYou_226_8_Day23_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (CheckBox item in this.panel1.Controls)
            {
                item.Click += duoxuanClick; 
            }
        }
        //全选点击事件
        private void xuanquanClick(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            //checkBox1.Checked = checkBox.Checked;
            //checkBox2.Checked = checkBox.Checked;
            //checkBox3.Checked = checkBox.Checked;
            //checkBox4.Checked = checkBox.Checked;

            foreach (CheckBox item in this.panel1.Controls)
            {
                item.Checked = checkBox.Checked;
            }
        }

        private void  duoxuanClick(object sender, EventArgs e) {

            foreach (CheckBox item in this.panel1.Controls) 
            {
                if (item.Checked == false) 
                { 
                    checkBox5.Checked = false;
                    return;
                }
            }
            checkBox5.Checked = true;
        }
    }
}
