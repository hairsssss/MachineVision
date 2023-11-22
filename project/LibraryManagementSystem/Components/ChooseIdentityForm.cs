using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Components {
    public partial class ChooseIdentityForm : Form {
        public ChooseIdentityForm() {
            InitializeComponent();
        }

        //选择身份
        public static string Identity { get; set; } = "学生";
        protected void ChooseIdentity(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                Identity = radioButton.Text;
            }
        }

        private void SubmitBtnClick(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
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
        private void PageLoad(object sender, EventArgs e) {
            CenterFormOnScreen();
        }
    }
}
