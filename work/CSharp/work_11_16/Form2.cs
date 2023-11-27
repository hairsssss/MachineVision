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
using Newtonsoft.Json; // 引入 Newtonsoft.Json 命名空间
using static work_11_16.Form2;

namespace work_11_16 {
    public partial class Form2 : Form {
        private static int nextId = 1;
        public Form2() {
            InitializeComponent();
        }
        private void FormLoad(object sender, EventArgs e) {
            CreateJson();

        }
        public class UserInfo {
            public int Id { get; set; } // 添加唯一ID属性
            public string Name { get; set; }
            public string Contry { get; set; }
            public List<string> HobbysList { get; set; }

            // 构造函数中初始化 HobbysList
            public UserInfo() {
                HobbysList = new List<string>();
            }
        }

        private static string contry { get; set; }
        public static List<UserInfo> userInfo = new List<UserInfo>();

        //文本存放地址
        public static string currentPath = Directory.GetCurrentDirectory();
        public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
        public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);
        public static string _userInfoFilePath = solutionPath.ToString() + "\\userInfo.json";

        private void SubmitClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nameIpt.Text)) {
                MessageBox.Show($"姓名不能为空", "注意");
                return;
            }

            //if (string.IsNullOrEmpty(contry)) {
            //    MessageBox.Show($"国家不能为空", "注意");
            //    return;
            //}

            UserInfo currentUser = userInfo.LastOrDefault();
            if (currentUser == null) {
                // 如果用户不存在，创建新用户并分配唯一的ID
                currentUser = new UserInfo { Id = nextId++, Name = nameIpt.Text, Contry = contry, HobbysList = new List<string>() };
                userInfo.Add(currentUser);
            } else {
                userInfo.Add(new UserInfo { Id = nextId++, Name = nameIpt.Text, Contry = contry });
            }

            if (checkedListBox1.CheckedItems.Count == 0) {
                MessageBox.Show($"请选择至少一个爱好", "注意");
                return;
            }

            if (checkedListBox1.CheckedItems.Count > 0) {
                foreach (object checkedItem in checkedListBox1.CheckedItems) {
                    //添加到当前用户的 HobbysList 中
                    userInfo.Last().HobbysList.Add(checkedItem.ToString());
                }
            }

            SaveUserToJSON();
            MessageBox.Show($"提交成功", "Success");
        }

        //选择国家
        private void ChangeContry(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                contry = radioButton.Text;
            }
        }

        private void CreateJson() {
            if (!File.Exists(_userInfoFilePath)) {
                File.Create(_userInfoFilePath).Close();
            } else {
                // 读取文件中的 JSON 数据
                string jsonContent = File.ReadAllText(_userInfoFilePath);

                // 反序列化为 List<UserInfo>
                List<UserInfo> existingUserInfo = JsonConvert.DeserializeObject<List<UserInfo>>(jsonContent) ?? new List<UserInfo>();
                nextId = existingUserInfo[existingUserInfo.Count - 1].Id + 1;

                // 将新的用户信息添加到已有的信息中
                foreach (UserInfo user in existingUserInfo) {
                    // 判断用户是否已经存在，避免重复添加
                    if (!userInfo.Any(u => u.Id == user.Id)) {
                        userInfo.Add(user);
                    }
                }
            }
        }

        //将信息转为JSON格式，并将JSON写入指定文件中
        private static void SaveUserToJSON() {
            if (!File.Exists(_userInfoFilePath)) {
                File.Create(_userInfoFilePath).Close();
            }

            // 序列化为 JSON
            string updatedJson = JsonConvert.SerializeObject(userInfo);

            // 保存到文件
            File.WriteAllText(_userInfoFilePath, updatedJson);
        }
        private void SelectAllItems(object sender, EventArgs e) {
            // 全选/取消全选
            bool checkState = selectAllCheckBox.Checked;

            for (int i = 0; i < checkedListBox1.Items.Count; i++) {
                checkedListBox1.SetItemChecked(i, checkState);
            }
        }



        private void CheckSelect(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Unchecked) {
                selectAllCheckBox.Checked = false;
            } else {
                if (checkedListBox1.CheckedItems.Count + 1 == checkedListBox1.Items.Count) {
                    selectAllCheckBox.Checked = true;
                } else {
                    selectAllCheckBox.Checked = false;
                }
            }
        }

    }
}
