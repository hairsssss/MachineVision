using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_11_17 {
    public partial class SwitchUser : Form {
        public SwitchUser() {
            InitializeComponent();
        }

        List<string> userList = new List<string>();
        private void pageLoad(object sender, EventArgs e) {
            CenterFormOnScreen();

            userList.Add("张三");
            userList.Add("李四");
            userList.Add("王五");
            userList.Add("赵六");
            userList.Add("钱七");
            userList.Add("周八");

            foreach (string item in userList) {
                this.listBox1.Items.Add(item);
            }
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

        //向右转移
        private void shiftRight(object sender, EventArgs e) {

            if (this.listBox1.SelectedItems.Count == 0) {
                MessageBox.Show("请选择你要转移的用户");
                return;
            }
            for (int i = this.listBox1.SelectedItems.Count - 1; i >= 0; i--) {
                var item = this.listBox1.SelectedItems[i];
                this.listBox1.Items.Remove(item);
                this.listBox2.Items.Add(item);
            }

        }

        //向左转移
        private void shiftLeft(object sender, EventArgs e) {
            if (this.listBox2.SelectedItems.Count == 0) {
                MessageBox.Show("请选择你要转移的用户");
                return;
            }
            for (int i = this.listBox2.SelectedItems.Count - 1; i >= 0; i--) {
                var item = this.listBox2.SelectedItems[i];
                this.listBox2.Items.Remove(item);
                this.listBox1.Items.Add(item);
            }

        }

        //是否开启多选
        bool isMultipleChoiceBtn;
        private void multipleChoiceClick(object sender, EventArgs e) {
            isMultipleChoiceBtn = !isMultipleChoiceBtn;
            if (isMultipleChoiceBtn) {
                this.listBox1.SelectionMode = SelectionMode.MultiSimple;
                this.listBox2.SelectionMode = SelectionMode.MultiSimple;
                this.multipleChoiceBtn.Text = "是否多选（是）";
            } else {
                this.listBox1.SelectionMode = SelectionMode.One;
                this.listBox2.SelectionMode = SelectionMode.One;
                this.multipleChoiceBtn.Text = "是否多选（否）";
            }
        }
    }
}
