using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using work_11_15;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static work_11_15.LoginRegister;

namespace LibraryManagementSystem {
    public partial class StudentPage : Form {
        public StudentPage(string username) {
            InitializeComponent();
            UserName = username;
            // 初始化数据库连接
            connection = new MySqlConnection(SQLHelper.connstr);

        }

        private static string UserName { get; set; }

        //归还选中书籍
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
                            DateTime return_time = DateTime.Now;

                            using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                                connection.Open();

                                // 更新 borrowed_book_list 表中的记录
                                string updateQuery = $"UPDATE borrowed_book_list SET is_return = 1, return_time = '{return_time}', count = count - 1 WHERE ID = '{Id}' AND is_return = 0";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection)) {
                                    updateCommand.ExecuteNonQuery();
                                }

                                // 获取 book_id，用于更新 book_list 表中的数量
                                string getBookIdQuery = $"SELECT book_id FROM borrowed_book_list WHERE ID = '{Id}'";
                                string book_id = string.Empty;

                                using (MySqlCommand getBookIdCommand = new MySqlCommand(getBookIdQuery, connection)) {
                                    object bookIdResult = getBookIdCommand.ExecuteScalar();
                                    if (bookIdResult != null) {
                                        book_id = bookIdResult.ToString();
                                    }
                                }

                                // 更新 book_list 表中对应书籍的数量
                                if (!string.IsNullOrEmpty(book_id)) {
                                    string updateBookListQuery = $"UPDATE book_list SET count = count + 1 WHERE ID = '{book_id}'";

                                    using (MySqlCommand updateBookListCommand = new MySqlCommand(updateBookListQuery, connection)) {
                                        updateBookListCommand.ExecuteNonQuery();
                                    }
                                }

                                MessageBox.Show($"书籍《{book}》归还成功，实际归还时间：{return_time.ToShortDateString()}", "归还成功");
                            }
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



        private MySqlConnection connection;

        //更新列表
        private void LoadDataToDataGridView() {
            try {
                connection.Open();

                string query = $"SELECT ID, book,borrowing_time, estimated_return_time, return_time,count, CASE WHEN is_return = 1 THEN '是' ELSE '否' END AS is_return FROM borrowed_book_list WHERE borrower = '{UserName}'";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 将 DataTable 绑定到 DataGridView
                booksView1.DataSource = dataTable;

                // 更改列标题
                booksView1.Columns["book"].HeaderText = "书名";
                booksView1.Columns["borrowing_time"].HeaderText = "借阅时间";
                booksView1.Columns["estimated_return_time"].HeaderText = "预计归还时间";
                booksView1.Columns["return_time"].HeaderText = "归还时间";
                booksView1.Columns["is_return"].HeaderText = "是否归还";
                booksView1.Columns["count"].HeaderText = "数量";

                // 禁用用户添加新行
                booksView1.AllowUserToAddRows = false;
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
            } finally {
                connection.Close();
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

            int x = (screenWidth - formWidth) / 2 + 40;
            int y = (screenHeight - formHeight) / 2 + 40;

            // 设置窗口位置
            this.Location = new Point(x, y);
        }

        private void PageLoad(object sender, EventArgs e) {
            LoadDataToDataGridView();
            CenterFormOnScreen();

        }


    }
}
