using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagementSystem.Components;
using LibraryManagementSystem.Tools;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem {
    public partial class BooksPage : Form {
        private readonly SQLHelper sqlHelper;
        public BooksPage(string username) {
            InitializeComponent();
            sqlHelper = new SQLHelper();
            UserName = username;
        }

        private void PageLoad(object sender, EventArgs e) {

            LoadDataToDataGridView();
            CenterFormOnScreen();
        }

        private string UserName { get; set; }


        #region 列表查询
        private void LoadDataToDataGridView() {
            string query = "SELECT * FROM book_list";
            booksView.DataSource = DataBase.Getlist(query);

            // 更改列标题
            booksView.Columns["book"].HeaderText = "书名";
            booksView.Columns["author"].HeaderText = "作者";
            booksView.Columns["publishing_house"].HeaderText = "出版社";
            booksView.Columns["count"].HeaderText = "数量";

            // 禁用用户添加新行
            booksView.AllowUserToAddRows = false;

        }
        #endregion

        #region 借阅
        private void borrowBtnClick(object sender, EventArgs e) {
            if (booksView.SelectedRows.Count > 0) {
                foreach (DataGridViewRow selectedRow in booksView.SelectedRows) {
                    string id = selectedRow.Cells["ID"].Value.ToString();
                    string book = selectedRow.Cells["book"].Value.ToString();
                    string author = selectedRow.Cells["author"].Value.ToString();
                    string book_id = selectedRow.Cells["ID"].Value.ToString();
                    int count = Convert.ToInt32(selectedRow.Cells["count"].Value); // 假设你的 count 列名为 "count"

                    // 检查书籍库存是否足够
                    if (count <= 0) {
                        MessageBox.Show($"书籍《{book}--{id}》库存不足，无法借阅", "提示");
                        continue; // 继续处理下一本书籍
                    }

                    // 弹出对话框，要求填写借阅信息
                    BorrowDialogForm borrowDialog = new BorrowDialogForm(book, UserName);
                    DialogResult result = borrowDialog.ShowDialog();

                    if (result == DialogResult.OK) {
                        string borrower = BorrowDialogForm.BorrowerName;
                        DateTime estimated_return_time = BorrowDialogForm.EstimatedReturnTime;

                        // 插入用户信息到数据库
                        string insertQuery = $"INSERT INTO borrowed_book_list (borrower, book, book_id, borrowing_time, estimated_return_time, is_return,count) VALUES ('{borrower}', '{book}', '{book_id}', '{DateTime.Now}', '{estimated_return_time}','{0}',1)";
                        bool insertResult = DataBase.InsertData(insertQuery);

                        // 更新书籍库存
                        string updateQuery = $"UPDATE book_list SET count = count - 1 WHERE ID = '{id}'";
                        bool updateResult = DataBase.InsertData(updateQuery);

                        if (insertResult && updateResult) {
                            MessageBox.Show($"书籍《{book}--{id}》借阅成功，预计归还日期：{estimated_return_time.ToShortDateString()}，借阅人：{borrower}", "借阅成功");

                        }

                    }
                }

                LoadDataToDataGridView();

            } else {
                MessageBox.Show("请选择您要借阅的书籍", "提示");
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

        #region 打开书架
        private void bookshelfBtnClick(object sender, EventArgs e) {
            StudentPage studentPage = new StudentPage(UserName);
            studentPage.Show();
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
