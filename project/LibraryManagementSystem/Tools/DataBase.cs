using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem.Tools {
    internal class DataBase {
        private readonly SQLHelper sqlHelper;

        public DataBase() {
            sqlHelper = new SQLHelper();
        }
        private static MySqlConnection connection;

        #region 插入数据
        /// <summary>
        /// 向数据库中插入数据
        /// </summary>
        /// <param name="insertQuery">SQL插入语句</param>
        /// <returns></returns>
        public static bool InsertData(string insertQuery) {
            try {
                // 连接数据库
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection)) {
                        insertCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"插入数据时发生异常: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } finally {
                if (connection != null && connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
        }

        #endregion

        #region 登录查询
        /// <summary>
        /// 返回参数，包含是否可以登录以及当前登录的用户信息
        /// </summary>
        internal class UserDataResult {
            public bool UserExists { get; set; }
            public UserData UserData { get; set; }
        }

        // 定义你需要存储的用户数据的属性
        internal class UserData {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string UserRole { get; set; }
        }

        /// <summary>
        /// 登录查询
        /// </summary>
        /// <param name="query">查询语句</param>
        /// <returns></returns>
        // 登录查询
        public static UserDataResult UserExists(string query) {
            try {
                // 实现查询数据的逻辑
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    // 执行传递进来的查询语句
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            UserDataResult result = new UserDataResult();
                            result.UserExists = reader.HasRows;

                            if (result.UserExists && reader.Read()) {
                                // 将查询到的数据填充到 UserData 对象中
                                result.UserData = new UserData {
                                    UserName = reader["username"].ToString(),
                                    Password = reader["password"].ToString(),
                                    UserRole = reader["userRole"].ToString(),
                                };
                            }

                            return result;
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
                return null;
            } finally {
                if (connection != null && connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
        }
        #endregion

        #region 判断用户名是否重复
        /// <summary>
        /// 判断用户名是否重复
        /// </summary>
        /// <param name="query">查询语句</param>
        /// <returns></returns>
        public static bool IsUserExists(string query) {
            try {
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
                return false;
            } finally {
                if (connection != null && connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
        }
        #endregion

        #region 列表查询

        /// <summary>
        /// 根据查询语句获取指定数据
        /// </summary>
        /// <param name="query">查询语句</param>
        /// <returns></returns>
        public static DataTable Getlist(string query) {
            DataTable dataTable = new DataTable();
            try {
                // 连接数据库
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    // 执行查询语句
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                            // 填充 DataTable
                            adapter.Fill(dataTable);
                        }
                    }
                }

                return dataTable;
            } catch (Exception ex) {
                MessageBox.Show($"发生错误：{ex.Message}", "错误");
                return null;
            } finally {
                if (connection != null && connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
        }
        #endregion

        #region 新增书籍
        /// <summary>
        /// 新增书籍
        /// </summary>
        /// <param name="book">书名</param>
        /// <param name="author">作者</param>
        /// <param name="publishingHouse">出版社</param>
        /// <param name="count">数量</param>
        /// <returns></returns>

        public static bool AddBook(string book, string author, string publishingHouse, int count) {
            try {
                using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                    connection.Open();

                    string selectQuery = "SELECT ID, count FROM book_list WHERE book = @book AND author = @author AND publishing_house = @publishingHouse";

                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection)) {
                        selectCommand.Parameters.AddWithValue("@book", book);
                        selectCommand.Parameters.AddWithValue("@author", author);
                        selectCommand.Parameters.AddWithValue("@publishingHouse", publishingHouse);

                        using (MySqlDataReader reader = selectCommand.ExecuteReader()) {
                            if (reader.Read()) {
                                int existingId = reader.GetInt32("ID");
                                int existingCount = reader.GetInt32("count");
                                int newCount = existingCount + count;
                                reader.Close();

                                string updateQuery = "UPDATE book_list SET count = @newCount WHERE ID = @existingId";

                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection)) {
                                    updateCommand.Parameters.AddWithValue("@newCount", newCount);
                                    updateCommand.Parameters.AddWithValue("@existingId", existingId);

                                    updateCommand.ExecuteNonQuery();
                                }


                            } else {
                                reader.Close();
                                string insertQuery = "INSERT INTO book_list (book, author, publishing_house, count) VALUES (@book, @author, @publishingHouse, @count)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection)) {
                                    insertCommand.Parameters.AddWithValue("@book", book);
                                    insertCommand.Parameters.AddWithValue("@author", author);
                                    insertCommand.Parameters.AddWithValue("@publishingHouse", publishingHouse);
                                    insertCommand.Parameters.AddWithValue("@count", count);

                                    insertCommand.ExecuteNonQuery();
                                }

                            }
                        }
                    }
                }
                return true;
            } catch (Exception ex) {
                MessageBox.Show($"操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } finally {
                if (connection != null && connection.State == ConnectionState.Open) {
                    connection.Close();
                }
            }
        }
        #endregion

        #region 归还选中书籍
        /// <summary>
        /// 归还书籍
        /// </summary>
        /// <param name="Id">选中的ID</param>
        /// <param name="book">书名</param>
        public static void ReturnBook(string Id, string book) {
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

        #endregion
    }
}
