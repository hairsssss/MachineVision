using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_11_17 {
    public partial class Carousel : Form {
        public Carousel() {
            InitializeComponent();
        }

        //页面初始化
        private void pageLoad(object sender, EventArgs e) {
            CenterFormOnScreen();
            int j;
            for (int i = 0; i < 10; i++) {
                j = i + 1;
                imgUrls.Add(@"..\..\Resources\壁纸 (" + j + ").jpg");
            }
            pictureBox1.Image = Image.FromFile(imgUrls[0]);

        }
        //设置窗口位置居中屏幕
        private void CenterFormOnScreen() {
            // 获取主屏幕的大小
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // 计算窗口的位置
            int formWidth = this.Width;
            int formHeight = this.Height;

            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2;
            // 设置窗口位置
            this.Location = new Point(x, y);
        }


        List<string> imgUrls = new List<string>();
        int index = 0;
        private bool isNextClicked = true; // 添加一个变量来跟踪是否点击了下一张


        private void LoadImage(string path) {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        //下一张
        private void nextImg(object sender, EventArgs e) {
            isNextClicked = true;
            if (index == imgUrls.Count - 1) {
                index = 0;
            } else {
                index++;
            }
            this.label1.Text = $"第 {index + 1} 张";
            LoadImage(imgUrls[index]);

            timer1.Stop();
            timer1.Interval = 3000;
            timer1.Start();
        }

        //上一张
        private void previousImg(object sender, EventArgs e) {
            isNextClicked = false;
            if (index == 0) {
                index = imgUrls.Count - 1;
            } else {
                index--;
            }
            this.label1.Text = $"第 {index + 1} 张";
            LoadImage(imgUrls[index]);

            timer1.Stop();
            timer1.Interval = 3000;
            timer1.Start();
        }

        //定时器
        private void timerImg(object sender, EventArgs e) {
            timer1.Interval = 1000;
            if (isNextClicked) {
                if (index == imgUrls.Count - 1) {
                    index = 0;
                } else {
                    index++;
                }
            } else {
                if (index == 0) {
                    index = imgUrls.Count - 1;
                } else {
                    index--;
                }
            }
            this.label1.Text = $"第 {index + 1} 张";
            pictureBox1.Image = Image.FromFile(imgUrls[index]);
        }
    }
}
