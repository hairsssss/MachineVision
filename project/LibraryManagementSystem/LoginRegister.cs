using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem;
using LibraryManagementSystem.Components;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace work_11_15 {
    public partial class LoginRegister : Form {
        private readonly SQLHelper sqlHelper;
        public LoginRegister() {
            InitializeComponent();
            sqlHelper = new SQLHelper();
        }

        //目前登录的用户信息
        public class UserInfo {
            //private class UserInfo {
            //public static string UserName { get; set; } = "小红";
            //public static string Password { get; set; } = "999999";
            //public static string UserRole { get; set; } = "0";
            public static string UserName { get; set; }
            public static string Password { get; set; }
            public static string UserRole { get; set; }
        }

        //账号
        private static string UserName { get; set; }
        //密码
        private static string Password { get; set; }
        //身份
        private static string UserRole { get; set; }

        // 登录
        private void loginClick(object sender, EventArgs e) {
            UserName = userNameIpt.Text;
            Password = passwardIpt.Text;

            // 连接数据库
            using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                connection.Open();

                // 查询数据库中是否存在该用户
                string query = $"SELECT * FROM account_password WHERE username = '{UserName}' AND password = '{Password}'";
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        if (reader.HasRows && reader.Read()) {
                            //MessageBox.Show($"用户 {UserName} 登录成功。", "Success");
                            UserInfo.UserName = UserName;
                            UserInfo.Password = Password;
                            UserInfo.UserRole = reader["userRole"].ToString();

                            //根据身份不同跳转不同界面
                            if (UserInfo.UserRole == "0") {
                                // 学生
                                BooksPage booksPage = new BooksPage(UserName);
                                this.Hide();
                                booksPage.Show();

                            } else if (UserInfo.UserRole == "1") {
                                //管理员
                                ManagePage managePage = new ManagePage();
                                this.Hide();
                                managePage.Show();
                            }
                        } else {
                            MessageBox.Show("账号或密码不正确", "登录失败");
                        }
                    }
                }
            }
        }

        // 注册
        private void registerClick(object sender, EventArgs e) {
            UserName = userNameIpt.Text;
            Password = passwardIpt.Text;
            if (!UserExists(UserName)) {
                if (Password.Length < 6 || Password.Length > 18) {
                    MessageBox.Show("密码长度过长或过短，请重新输入：", "密码格式错误");
                } else {

                    ChooseIdentityForm chooseDialog = new ChooseIdentityForm();
                    DialogResult result = chooseDialog.ShowDialog();
                    if (result == DialogResult.OK) {
                        UserInfo.UserRole = ChooseIdentityForm.Identity;
                        UserRole = UserInfo.UserRole;

                        if (!string.IsNullOrEmpty(UserRole)) {
                            // 连接数据库
                            using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                                connection.Open();

                                // 插入用户信息到数据库
                                string insertQuery = $"INSERT INTO account_password (username, password, userRole) VALUES ('{UserName}', '{Password}', {(UserRole == "学生" ? "'0'" : "'1'")})";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection)) {
                                    insertCommand.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show($"账号 {UserName} 注册成功", "Success");
                        } else {
                            MessageBox.Show($"请选择您要注册的身份！", "提示");
                        }
                    }

                }
            } else {
                MessageBox.Show($"用户名 {UserName} 已被注册", "账号重复");
            }
        }

        //判断用户名是否重复
        private bool UserExists(string username) {
            using (MySqlConnection connection = new MySqlConnection(SQLHelper.connstr)) {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM account_password WHERE username = '{username}'";
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
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

        //窗体初始化
        private async void formLoad(object sender, EventArgs e) {
            await Task.Delay(1);
            userNameIpt.Focus();
            CenterFormOnScreen();
        }
    }
}
