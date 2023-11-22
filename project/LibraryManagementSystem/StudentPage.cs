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
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem {
    public partial class StudentPage : Form {
        public StudentPage(string username) {
            InitializeComponent();
            UserName = username;

        }
        private void PageLoad(object sender, EventArgs e) {
            LoadDataToDataGridView();
            CenterFormOnScreen();

        }

        private static string UserName { get; set; }

        #region 归还选中书籍
        private void returnBookBtnClick(object sender, EventArgs e) {
            if (booksView1.SelectedRows.Count > 0) {
                foreach (DataGridViewRow selectedRow in booksView1.SelectedRows) {
                    string Id = selectedRow.Cells["ID"].Value.ToString();
                    string book = selectedRow.Cells["book"].Value.ToString();
                    string is_return = selectedRow.Cells["is_return"].Value.ToString();

                    // 如果没有归还则弹提示框
                    if (is_return == "否") {
                        // 显示消息框，提示归还信息
                        DialogResult result = MessageBox.Show($"确认归还书籍《{book}》吗？", "确认归还", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK) {
                            DataBase.ReturnBook(Id, book);
                        }
                    } else {
                        MessageBox.Show($"书籍《{book}》不需要归还", "提示");
                    }
                }
                // 刷新界面
                LoadDataToDataGridView();
            } else {
                MessageBox.Show("请先选中要归还的书籍", "提示");
            }
        }
        #endregion

        #region 更新列表
        private void LoadDataToDataGridView() {


            string query = $"SELECT ID, book,borrowing_time, estimated_return_time, return_time,count, CASE WHEN is_return = 1 THEN '是' ELSE '否' END AS is_return FROM borrowed_book_list WHERE borrower = '{UserName}'";

            booksView1.DataSource = DataBase.Getlist(query);

            // 更改列标题
            booksView1.Columns["book"].HeaderText = "书名";
            booksView1.Columns["borrowing_time"].HeaderText = "借阅时间";
            booksView1.Columns["estimated_return_time"].HeaderText = "预计归还时间";
            booksView1.Columns["return_time"].HeaderText = "归还时间";
            booksView1.Columns["is_return"].HeaderText = "是否归还";
            booksView1.Columns["count"].HeaderText = "数量";

            // 禁用用户添加新行
            booksView1.AllowUserToAddRows = false;

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
