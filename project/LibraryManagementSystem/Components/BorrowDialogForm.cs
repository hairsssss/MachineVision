using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LibraryManagementSystem.Components {
    public partial class BorrowDialogForm : Form {
        public BorrowDialogForm(string book, string username) {
            BorrowerName = username;
            Book = book;
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
        }

        //借阅人
        public static string BorrowerName { get; set; }

        //窗口初始化
        private void PageLoad(object sender, EventArgs e) {
            CenterFormOnScreen();
            bookLabel.Text = Book;
        }

        //预计归还时间
        public static DateTime EstimatedReturnTime { get; set; }
        public static string Book { get; set; }

        //提交
        private void submitBtnClick(object sender, EventArgs e) {
            EstimatedReturnTime = dateTimePicker1.Value;
            this.DialogResult = DialogResult.OK;
        }

        //取消
        private void CancelBtnClick(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
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


    }
}
