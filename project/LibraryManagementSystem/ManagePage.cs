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
using static work_11_15.LoginRegister;

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

        //获取所有书籍列表
        private void LoadDataToDataGridView() {
            try {
                connection.Open();

                string query = "SELECT * FROM book_list";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 将 DataTable 绑定到 DataGridView
                booksView2.DataSource = dataTable;

                // 更改列标题
                booksView2.Columns["book"].HeaderText = "书名";
                booksView2.Columns["author"].HeaderText = "作者";
                booksView2.Columns["publishing_house"].HeaderText = "出版社";
                booksView2.Columns["count"].HeaderText = "数量";

                // 禁用用户添加新行
                booksView2.AllowUserToAddRows = false;
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
            } finally {
                connection.Close();
            }
        }

        //获取所有借阅记录
        private void GetlistToDataView() {
            try {
                connection.Open();

                string query = "SELECT ID,borrower, book, borrowing_time, estimated_return_time, return_time, CASE WHEN is_return = 1 THEN '是' ELSE '否' END AS is_return FROM borrowed_book_list";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 将 DataTable 绑定到 DataGridView
                booksView3.DataSource = dataTable;

                // 更改列标题
                booksView3.Columns["borrower"].HeaderText = "借阅人";
                booksView3.Columns["book"].HeaderText = "书名";
                booksView3.Columns["borrowing_time"].HeaderText = "借阅时间";
                booksView3.Columns["estimated_return_time"].HeaderText = "预计归还时间";
                booksView3.Columns["return_time"].HeaderText = "归还时间";
                booksView3.Columns["is_return"].HeaderText = "是否归还";

                // 禁用用户添加新行
                booksView3.AllowUserToAddRows = false;
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } finally {
                connection.Close();
            }
        }


        //提交
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
            try {
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    // 使用参数化查询以防止 SQL 注入
                    string selectQuery = "SELECT ID, count FROM book_list WHERE book = @book AND author = @author AND publishing_house = @publishingHouse";

                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection)) {
                        selectCommand.Parameters.AddWithValue("@book", book);
                        selectCommand.Parameters.AddWithValue("@author", author);
                        selectCommand.Parameters.AddWithValue("@publishingHouse", publishingHouse);

                        using (MySqlDataReader reader = selectCommand.ExecuteReader()) {
                            if (reader.Read()) {
                                // 如果记录存在，则更新数量
                                int existingId = reader.GetInt32("ID");
                                int existingCount = reader.GetInt32("count");
                                int newCount = existingCount + count;

                                // 关闭DataReader
                                reader.Close();

                                string updateQuery = "UPDATE book_list SET count = @newCount WHERE ID = @existingId";

                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection)) {
                                    updateCommand.Parameters.AddWithValue("@newCount", newCount);
                                    updateCommand.Parameters.AddWithValue("@existingId", existingId);

                                    updateCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("提交成功！", "success");

                            } else {
                                // 如果记录不存在，则插入新记录
                                // 关闭DataReader
                                reader.Close();
                                string insertQuery = "INSERT INTO book_list (book, author, publishing_house, count) VALUES (@book, @author, @publishingHouse, @count)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection)) {
                                    insertCommand.Parameters.AddWithValue("@book", book);
                                    insertCommand.Parameters.AddWithValue("@author", author);
                                    insertCommand.Parameters.AddWithValue("@publishingHouse", publishingHouse);
                                    insertCommand.Parameters.AddWithValue("@count", count);

                                    insertCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("提交成功！", "success");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //只能输入数字
        private void CountIptKeyPress(object sender, KeyPressEventArgs e) {
            // 允许数字、删除键、和退格键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
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
    }
}
