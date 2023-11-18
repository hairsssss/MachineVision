public class JSONHelper {
    public class Student {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string StudentId { get; set; }
    }

    public static List<Student> students = new List<Student>();

    //文本存放地址
    public static string currentPath = Directory.GetCurrentDirectory();
    public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
    public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);
    public static string _studentsInfoFilePath = solutionPath.ToString() + "\\studentsInfo.json";

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

    //将学生信息转为JSON格式，并将JSON写入指定文件中
    private static void SaveStudentsToJSON() {
        string studentsJson = JsonConvert.SerializeObject(students);
        File.WriteAllText(_studentsInfoFilePath, studentsJson);
    }

    //获取JSON文件中的数据
    public static List<Student> LoadStudentsFromJson() {
        if (File.Exists(_studentsInfoFilePath)) {
            string jsonContent = File.ReadAllText(_studentsInfoFilePath);

            //将 JSON 格式的字符串 jsonContent 反序列化为 List<Student> 对象。
            List<Student> loadedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonContent);

            // 提取学生ID并添加到usedIds中
            foreach (Student student in students) {
                usedIds.Add(student.StudentId);
            }

            return loadedStudents ?? new List<Student>(); // 返回整个学生列表，若为空则返回空列表
        }
        return new List<Student>();
    }
}