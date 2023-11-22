using System;
using System.Collections;
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
using LibraryManagementSystem.Tools;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static LibraryManagementSystem.Tools.DataBase;

namespace LibraryManagementSystem {
    public partial class LoginRegister : Form {
        private readonly SQLHelper sqlHelper;
        public LoginRegister() {
            InitializeComponent();
            sqlHelper = new SQLHelper();

        }
        //目前登录的用户信息
        private class UserInfo {
            public static string UserName { get; set; }
            public static string Password { get; set; }
            public static string UserRole { get; set; }
        }

        #region 登录注册
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

            string query = $"SELECT * FROM account_password WHERE username = '{UserName}' AND password = '{Password}'";
            UserDataResult result = UserExists(query);

            // 处理查询结果
            if (result.UserExists) {
                MessageBox.Show($"用户 {UserName} 登录成功。", "Success");
                UserInfo.UserName = result.UserData.UserName;
                UserInfo.Password = result.UserData.Password;
                UserInfo.UserRole = result.UserData.UserRole;

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

        // 注册
        private void registerClick(object sender, EventArgs e) {
            UserName = userNameIpt.Text;
            Password = passwardIpt.Text;

            string query = $"SELECT COUNT(*) FROM account_password WHERE username = '{UserName}'";
            bool IsResult = IsUserExists(query);
            //判断用户名是否重复
            if (!IsResult) {
                if (Password.Length < 6 || Password.Length > 18) {
                    MessageBox.Show("密码长度过长或过短，请重新输入：", "密码格式错误");
                } else {

                    ChooseIdentityForm chooseDialog = new ChooseIdentityForm();
                    DialogResult result = chooseDialog.ShowDialog();
                    if (result == DialogResult.OK) {
                        UserInfo.UserRole = ChooseIdentityForm.Identity;
                        UserRole = UserInfo.UserRole;

                        if (!string.IsNullOrEmpty(UserRole)) {
                            string insertQuery = $"INSERT INTO account_password (username, password, userRole) VALUES ('{UserName}', '{Password}', {(UserRole == "学生" ? "'0'" : "'1'")})";
                            bool InsertResult = InsertData(insertQuery);

                            if (InsertResult) {
                                MessageBox.Show($"账号 {UserName} 注册成功", "Success");
                            }


                        } else {
                            MessageBox.Show($"请选择您要注册的身份！", "提示");
                        }
                    }

                }
            } else {
                MessageBox.Show($"用户名 {UserName} 已被注册", "账号重复");
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


        //窗体初始化
        private async void PageLoad(object sender, EventArgs e) {
            UserInfo.UserName = string.Empty;
            UserInfo.Password = string.Empty;
            UserInfo.UserRole = string.Empty;

            await Task.Delay(1);
            userNameIpt.Focus();
            CenterFormOnScreen();
        }
    }
}
