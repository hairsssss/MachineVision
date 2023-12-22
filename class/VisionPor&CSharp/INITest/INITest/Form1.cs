using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini;
using System.IO;
using System.Reflection.Emit;

namespace INITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string filePath = Directory.GetCurrentDirectory() + @"\ini文件";
        private void button1_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string iniFilePath = filePath + @"\配置.ini";
            //IniAPI.INIWriteValue(iniFilePath, textBox1.Text,label2.Text,textBox2.Text);
            //IniAPI.INIWriteValue(iniFilePath, textBox1.Text,label3.Text, textBox3.Text);


            IniAPI.INIWriteItems(iniFilePath, textBox1.Text, $"{label2.Text}={textBox2.Text}\0{label3.Text}={textBox3.Text}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string iniFilePath = filePath + @"\配置.ini";
   //textBox2.Text =        IniAPI.INIGetStringValue(iniFilePath, "相机1", "曝光", "1");
   //textBox3.Text=         IniAPI.INIGetStringValue(iniFilePath, "相机1", "亮度", "1");

            string[] keysArray = IniAPI.INIGetAllItemKeys(iniFilePath, "相机1");
            foreach (string item in keysArray)
            {
            string tempStr =    IniAPI.INIGetStringValue(iniFilePath, "相机1", item, "1");
                MessageBox.Show(tempStr);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string iniFilePath = filePath + @"\配置.ini";
            IniAPI.INIWriteValue(iniFilePath, "齿轮标准参数", label4.Text, textBox4.Text);
        }
    }
}
