using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Components;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static work_11_15.LoginRegister;

namespace LibraryManagementSystem {
    public partial class StudentPage : Form {
        public StudentPage() {
            InitializeComponent();

            // 初始化数据库连接
            connection = new MySqlConnection(SQLHelper.connstr);
        }

        //归还选中数据
        private void returnBookBtnClick(object sender, EventArgs e) {
            if (booksView1.SelectedRows.Count > 0) {

                foreach (DataGridViewRow selectedRow in booksView1.SelectedRows) {
                    string Id = selectedRow.Cells["ID"].Value.ToString();
                    string book = selectedRow.Cells["book"].Value.ToString();
                    string is_return = selectedRow.Cells["is_return"].Value.ToString();

                    //如果没有归还则弹提示框
                    if (is_return == "否") {

                        // 显示消息框，提示归还信息
                        DialogResult result = MessageBox.Show($"确认归还书籍《{book}》吗？", "确认归还", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK) {
                            DateTime return_time = DateTime.Now;

                            using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                                connection.Open();

                                // 更新数据库中的记录
                                string updateQuery = $"UPDATE borrowed_book_list SET is_return = 1, return_time = '{return_time}' WHERE ID = '{Id}' AND is_return = 0";

                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection)) {
                                    updateCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show($"书籍《{book}》归还成功，实际归还时间：{return_time.ToShortDateString()}", "归还成功");
                            }

                        } else {
                            // 用户取消操作
                        }
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

                string query = $"SELECT ID, book,borrowing_time, estimated_return_time, return_time, CASE WHEN is_return = 1 THEN '是' ELSE '否' END AS is_return FROM borrowed_book_list WHERE borrower = '{UserInfo.UserName}'";

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
