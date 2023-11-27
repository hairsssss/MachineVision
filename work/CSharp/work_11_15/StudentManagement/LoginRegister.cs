using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace work_11_15 {
    public partial class LoginRegister : Form {

        public LoginRegister() {
            InitializeComponent();
        }

        //存储账号密码
        public class UserInfo {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        //账号
        private static string UserName { get; set; }
        //密码
        private static string Passward { get; set; }


        // 使用 Directory 类的 GetCurrentDirectory 方法获取当前工作目录
        public static string currentPath = Directory.GetCurrentDirectory();
        // 使用 Directory 类的 GetParent 方法获取当前工作目录的父目录
        public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
        // 使用 Directory 类的 GetParent 方法获取父目录的父目录，即解决方案路径
        public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);

        //文本存放地址
        public static string _filePath = solutionPath.ToString() + "\\userInfo.txt";
        public static List<UserInfo> UserList = new List<UserInfo> { };

        //创建存储用户名密码的txt文档
        public static void CreatFile() {
            //判断该文件是否存在如果存在，执行else内的代码，不存在就创建该文件
            if (!File.Exists(_filePath)) {
                File.Create(_filePath).Close();
            } else {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines) {
                    string[] parts = line.Split(',');
                    //将文件中存储的账号密码添加到 数组中
                    UserList.Add(new UserInfo { UserName = parts[0], Password = parts[1] });
                }
            }
        }


        //登录
        private void loginClick(object sender, EventArgs e) {
            UserName = userNameIpt.Text;
            Passward = passwardIpt.Text;
            UserInfo isHasUser = UserList.Find(item => item.UserName == UserName);
            if (isHasUser != null) {

                if (!string.IsNullOrEmpty(Passward)) {
                    MessageBox.Show($"用户 {UserName} 登录成功。", "Success");

                    //登录成功跳转学生信息界面
                    ManagementPage managementPage = new ManagementPage();
                    this.Hide();
                    managementPage.Show();
                } else {
                    MessageBox.Show("账号或密码不能为空", "请输入");
                }

            } else {
                MessageBox.Show("该账户名未注册", "未注册");
            }

        }

        //注册
        private void registerClick(object sender, EventArgs e) {
            UserName = userNameIpt.Text;
            Passward = passwardIpt.Text;
            if (!UserExists(UserName)) {
                if (Passward.Length < 6 || Passward.Length > 18) {
                    MessageBox.Show("密码长度过长或过短，请重新输入：", "密码格式错误");
                } else {
                    UserList.Add(new UserInfo { UserName = UserName, Password = Passward });
                    MessageBox.Show($"账号 {UserName}  注册成功", "Success");
                    using (StreamWriter writer = new StreamWriter(_filePath, true)) {
                        writer.WriteLine($"{UserName},{Passward}");
                        //MessageBox.Show($"用户名密码已写入{_filePath}中", "Success");
                    }
                }
            } else {
                MessageBox.Show($"用户名 {UserName} 已被注册", "账号重复");
            }
        }

        //判断用户名是否重复
        private static bool UserExists(string username) {
            return UserList.Exists(item => item.UserName == username);
        }

        //窗体初始化
        private void formLoad(object sender, EventArgs e) {
            CreatFile();
        }
    }
}
