using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Components;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem {
    public partial class BooksPage : Form {
        private readonly SQLHelper sqlHelper;
        public BooksPage() {
            InitializeComponent();
            sqlHelper = new SQLHelper();
        }

        private void PageLoad(object sender, EventArgs e) {
            // 初始化数据库连接
            connection = new MySqlConnection(SQLHelper.connstr);

            LoadDataToDataGridView();
            CenterFormOnScreen();
        }

        private MySqlConnection connection;

        private void LoadDataToDataGridView() {
            try {
                connection.Open();

                string query = "SELECT * FROM book_list";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 将 DataTable 绑定到 DataGridView
                booksView.DataSource = dataTable;

                // 更改列标题
                booksView.Columns["book"].HeaderText = "书名";
                booksView.Columns["author"].HeaderText = "作者";
                booksView.Columns["publishing_house"].HeaderText = "出版社";

                // 禁用用户添加新行
                booksView.AllowUserToAddRows = false;
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
            } finally {
                connection.Close();
            }
        }

        //借阅
        //借阅
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
                    BorrowDialogForm borrowDialog = new BorrowDialogForm(book);
                    DialogResult result = borrowDialog.ShowDialog();

                    if (result == DialogResult.OK) {
                        string borrower = BorrowDialogForm.BorrowerName;
                        DateTime estimated_return_time = BorrowDialogForm.EstimatedReturnTime;

                        using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                            connection.Open();

                            // 插入用户信息到数据库
                            string insertQuery = $"INSERT INTO borrowed_book_list (borrower, book, book_id, borrowing_time, estimated_return_time, is_return) VALUES ('{borrower}', '{book}', '{book_id}', '{DateTime.Now}', '{estimated_return_time}','{0}')";

                            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection)) {
                                insertCommand.ExecuteNonQuery();
                            }

                            // 更新书籍库存
                            string updateQuery = $"UPDATE book_list SET count = count - 1 WHERE ID = '{id}'";
                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection)) {
                                updateCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show($"书籍《{book}--{id}》借阅成功，预计归还日期：{estimated_return_time.ToShortDateString()}，借阅人：{borrower}", "借阅成功");
                        }
                    } else {
                        // 用户取消操作
                    }
                }

                LoadDataToDataGridView();

            } else {
                MessageBox.Show("请先选中要借阅的书籍", "提示");
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

        private void bookshelfBtnClick(object sender, EventArgs e) {
            StudentPage studentPage = new StudentPage();
            studentPage.Show();
        }
    }
}
