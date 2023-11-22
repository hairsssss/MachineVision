using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Tools;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem {
    public partial class ManagePage : Form {
        public ManagePage() {
            InitializeComponent();
        }
        private MySqlConnection connection;
        private void PageLoad(object sender, EventArgs e) {
            CenterFormOnScreen();

            // 初始化数据库连接
            connection = new MySqlConnection(SQLHelper.connstr);

            LoadDataToDataGridView();
            GetlistToDataView();
        }

        #region 获取所有书籍列表
        private void LoadDataToDataGridView() {

            string query = "SELECT * FROM book_list";

            booksView2.DataSource = DataBase.Getlist(query);

            // 更改列标题
            booksView2.Columns["book"].HeaderText = "书名";
            booksView2.Columns["author"].HeaderText = "作者";
            booksView2.Columns["publishing_house"].HeaderText = "出版社";
            booksView2.Columns["count"].HeaderText = "数量";

            // 禁用用户添加新行
            booksView2.AllowUserToAddRows = false;

        }
        #endregion

        #region 获取所有借阅记录
        private void GetlistToDataView() {

            string query = "SELECT ID,borrower, book, borrowing_time, estimated_return_time, return_time, CASE WHEN is_return = 1 THEN '是' ELSE '否' END AS is_return FROM borrowed_book_list";
            booksView3.DataSource = DataBase.Getlist(query);

            // 更改列标题
            booksView3.Columns["borrower"].HeaderText = "借阅人";
            booksView3.Columns["book"].HeaderText = "书名";
            booksView3.Columns["borrowing_time"].HeaderText = "借阅时间";
            booksView3.Columns["estimated_return_time"].HeaderText = "预计归还时间";
            booksView3.Columns["return_time"].HeaderText = "归还时间";
            booksView3.Columns["is_return"].HeaderText = "是否归还";

            // 禁用用户添加新行
            booksView3.AllowUserToAddRows = false;

        }
        #endregion

        #region 新增书籍
        private void SubmitBtnClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(bookIpt.Text)) {
                MessageBox.Show("书名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(authorIpt.Text)) {
                MessageBox.Show("作者不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(publishingHouseIpt.Text)) {
                MessageBox.Show("出版社不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(countIpt.Text)) {
                MessageBox.Show("最少添加1本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // 将数据插入数据库
            InsertData(bookIpt.Text, authorIpt.Text, publishingHouseIpt.Text, Convert.ToInt32(countIpt.Text));
        }

        private void InsertData(string book, string author, string publishingHouse, int count) {
            if (DataBase.AddBook(book, author, publishingHouse, count)) {
                MessageBox.Show("提交成功！", "success");
            }
        }

        #endregion

        #region 只能输入数字
        private void CountIptKeyPress(object sender, KeyPressEventArgs e) {
            // 允许数字、删除键、和退格键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
        #endregion

        #region 设置窗口位置居中屏幕
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
        #endregion

        #region 退出登录
        private void SignOutBtnClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show($"确定要退出登录吗？", "确认归还", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) {
                LoginRegister LoginPage = new LoginRegister();
                LoginPage.Show();
                this.Hide();
            }
        }
        #endregion
    }
}
