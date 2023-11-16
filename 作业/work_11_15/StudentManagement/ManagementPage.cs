using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // 引入 Newtonsoft.Json 命名空间
using static StudentManagement.ManagementPage;

namespace StudentManagement {
    public partial class ManagementPage : Form {
        public ManagementPage() {
            InitializeComponent();
        }

        public class Student {
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int Height { get; set; }
            public string StudentId { get; set; }
        }

        public class StudentManagementSystem {
            public static List<Student> students = new List<Student>();

            //文本存放地址
            public static string currentPath = Directory.GetCurrentDirectory();
            public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
            public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);
            public static string _studentsInfoFilePath = solutionPath.ToString() + "\\studentsInfo.json";

            public List<Student> GetAllStudents() {
                return students;
            }

            public int StudentsCount() {
                return students.Count;
            }

            //新增学生
            public static void AddStudent(Student student) {
                students = LoadStudentsFromJson();
                students.Add(student);
                SaveStudentsToJSON();
            }

            //删除学生
            public static bool RemoveStudent(string studentId) {
                // 加载已有的学生信息
                students = LoadStudentsFromJson();

                // 查找学生
                Student studentToRemove = students.FirstOrDefault(s => s.StudentId == studentId);

                if (studentToRemove != null) {
                    students.Remove(studentToRemove);
                    SaveStudentsToJSON();
                    return true;
                }

                return false;
            }

            //按学生名查找
            public List<Student> QueryStudentsByName(string name) {
                return students.Where(s => s.Name == name).ToList();
            }

            //通过性别查找
            public List<Student> QueryStudentsByGender(string gender) {
                return students.Where(s => s.Gender == gender).ToList();
            }

            //通过年龄查找
            public List<Student> QueryStudentsByAge(int age) {
                return students.Where(s => s.Age == age).ToList();
            }

            //身高排序
            public static void SortStudentsByHeight() {
                students = students.OrderBy(s => s.Height).ToList();
                SaveStudentsToJSON();
            }

            //年龄排序
            public static void SortStudentsByAge() {
                students = students.OrderBy(s => s.Age).ToList();
                SaveStudentsToJSON();
            }

            //默认排序
            public static void DefaultSort() {
                students = students.OrderBy(s => s.StudentId).ToList();
                SaveStudentsToJSON();
            }

            //将学生信息转为JSON格式
            private static void SaveStudentsToJSON() {
                string studentsJson = JsonConvert.SerializeObject(students);
                File.WriteAllText(_studentsInfoFilePath, studentsJson);
            }

            //新建JSON文件
            public static void createSmsJson() {
                if (!File.Exists(_studentsInfoFilePath)) {
                    File.Create(_studentsInfoFilePath).Close();
                } else {
                    // 读取文件中的学生信息
                    string[] lines = File.ReadAllLines(_studentsInfoFilePath);
                    foreach (string line in lines) {
                        string[] studentInfo = line.Split(' ');
                        if (studentInfo.Length == 5) {
                            Student newStudent = new Student();
                            newStudent.Name = studentInfo[0];
                            newStudent.Gender = studentInfo[1];

                            // 使用 int.TryParse 来更安全地解析整数
                            if (int.TryParse(studentInfo[2], out int age)) {
                                newStudent.Age = age;
                            } else {
                                // 处理解析失败的情况，可以记录日志、给出提示等
                                // 在这里，你可以设置默认值或者采取其他措施
                                newStudent.Age = 0; // 默认值为 0，你可以根据需要修改
                            }

                            if (int.TryParse(studentInfo[3], out int height)) {
                                newStudent.Height = height;
                            } else {
                                // 处理解析失败的情况，可以记录日志、给出提示等
                                // 在这里，你可以设置默认值或者采取其他措施
                                newStudent.Height = 0; // 默认值为 0，你可以根据需要修改
                            }

                            newStudent.StudentId = studentInfo[4];

                            AddStudent(newStudent);
                        }


                    }
                }
            }

            // 用于存储已经使用的学生ID
            private static HashSet<string> usedIds = new HashSet<string>();

            //获取JSON文件中的数据
            public static List<Student> LoadStudentsFromJson() {
                if (File.Exists(_studentsInfoFilePath)) {
                    string jsonContent = File.ReadAllText(_studentsInfoFilePath);
                    List<Student> loadedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonContent);

                    // 提取学生ID并添加到usedIds中
                    foreach (Student student in students) {
                        usedIds.Add(student.StudentId);
                    }

                    return loadedStudents ?? new List<Student>(); // 返回整个学生列表，若为空则返回空列表
                }
                return new List<Student>();
            }

            //生成唯一ID
            public static string GenerateStudentId() {
                string baseId = "20231116"; // 基础ID，可以根据需要修改
                int counter = 1;

                while (counter <= 9999) {
                    string studentId = $"{baseId}{counter:D4}";

                    // 检查是否已经使用过
                    if (!usedIds.Contains(studentId)) {
                        usedIds.Add(studentId);
                        return studentId;
                    }

                    counter++;
                }

                throw new InvalidOperationException("无法生成唯一的学生ID。");
            }

        }

        //选择性别
        public static string Gender { get; set; }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                Gender = radioButton.Text;
            }
        }

        //控制用户只能输入数字
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            // 允许数字、退格键和删除键
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127) {
                e.Handled = true; // 阻止输入
            }
        }

        //更新列表
        private void GetList() {
            StudentManagementSystem.createSmsJson();
            // 加载学生信息并绑定到 DataGridView
            StudentManagementSystem.students = StudentManagementSystem.LoadStudentsFromJson();
            dataGridView1.DataSource = StudentManagementSystem.students;

        }

        //新增操作
        private void AddStudentClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(NameIpt.Text)) {
                MessageBox.Show($"姓名不能为空", "注意");
                return;
            }
            if (string.IsNullOrEmpty(Gender)) {
                MessageBox.Show($"性别不能为空", "注意");
                return;
            }
            if (string.IsNullOrEmpty(AgeIpt.Text)) {
                MessageBox.Show($"年龄不能为空", "注意");
                return;
            }
            if (string.IsNullOrEmpty(HeightIpt.Text)) {
                MessageBox.Show($"身高不能为空", "注意");
                return;
            }

            string studentId = StudentManagementSystem.GenerateStudentId();
            if (string.IsNullOrEmpty(studentId)) {
                MessageBox.Show($"ID不能为空", "注意");
                return;
            }
            int.TryParse(AgeIpt.Text, out int age);
            int.TryParse(HeightIpt.Text, out int height);
            StudentManagementSystem.AddStudent(new Student { Name = NameIpt.Text, Gender = Gender, Age = age, Height = height, StudentId = studentId });
            MessageBox.Show($"添加成功");
            GetList();

        }

        //删除操作
        private void RemoveStudentClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(RemoveIpt.Text)) {
                MessageBox.Show($"请输入要删除的学生ID", "注意");
                return;
            }

            string removeId = RemoveIpt.Text;
            DialogResult result = MessageBox.Show($"确定删除学生ID为 {removeId} 的学生吗？", "确认删除", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) {
                bool removed = StudentManagementSystem.RemoveStudent(removeId);

                if (removed) {
                    MessageBox.Show($"成功删除学生ID为 {removeId} 的学生", "成功");
                    GetList();
                } else {
                    MessageBox.Show($"未找到学生ID为 {removeId} 的学生", "注意");
                }
            }
            //else {
            // 用户点击了取消按钮，不执行删除操作
            //MessageBox.Show("已取消删除操作", "取消");
            //}
        }

        //年龄排序
        private void SortByAge(object sender, EventArgs e) {
            StudentManagementSystem.SortStudentsByAge();
            GetList();
        }

        //身高排序
        private void SortByHeight(object sender, EventArgs e) {
            StudentManagementSystem.SortStudentsByHeight();
            GetList();
        }

        //默认排序
        private void DefaultSortClick(object sender, EventArgs e) {
            StudentManagementSystem.DefaultSort();
            GetList();
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

        //页面初始化
        public void smsPageLoad(object sender, EventArgs e) {
            GetList();
            CenterFormOnScreen();
        }
    }
}