public class JSONHelper {
    public class Student {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string StudentId { get; set; }
    }

    public static List<Student> students = new List<Student>();

    //�ı���ŵ�ַ
    public static string currentPath = Directory.GetCurrentDirectory();
    public static DirectoryInfo parentPath = Directory.GetParent(currentPath);
    public static DirectoryInfo solutionPath = Directory.GetParent(parentPath.FullName);
    public static string _studentsInfoFilePath = solutionPath.ToString() + "\\studentsInfo.json";

    //�½�JSON�ļ�
    public static void createSmsJson() {
        if (!File.Exists(_studentsInfoFilePath)) {
            File.Create(_studentsInfoFilePath).Close();
        } else {
            // ��ȡ�ļ��е�ѧ����Ϣ
            string[] lines = File.ReadAllLines(_studentsInfoFilePath);
            foreach (string line in lines) {
                string[] studentInfo = line.Split(' ');
                if (studentInfo.Length == 5) {
                    Student newStudent = new Student();
                    newStudent.Name = studentInfo[0];
                    newStudent.Gender = studentInfo[1];

                    // ʹ�� int.TryParse ������ȫ�ؽ�������
                    if (int.TryParse(studentInfo[2], out int age)) {
                        newStudent.Age = age;
                    } else {
                        // �������ʧ�ܵ���������Լ�¼��־��������ʾ��
                        // ��������������Ĭ��ֵ���߲�ȡ������ʩ
                        newStudent.Age = 0; // Ĭ��ֵΪ 0������Ը�����Ҫ�޸�
                    }

                    if (int.TryParse(studentInfo[3], out int height)) {
                        newStudent.Height = height;
                    } else {
                        // �������ʧ�ܵ���������Լ�¼��־��������ʾ��
                        // ��������������Ĭ��ֵ���߲�ȡ������ʩ
                        newStudent.Height = 0; // Ĭ��ֵΪ 0������Ը�����Ҫ�޸�
                    }

                    newStudent.StudentId = studentInfo[4];

                    AddStudent(newStudent);
                }


            }
        }
    }

    //��ѧ����ϢתΪJSON��ʽ������JSONд��ָ���ļ���
    private static void SaveStudentsToJSON() {
        string studentsJson = JsonConvert.SerializeObject(students);
        File.WriteAllText(_studentsInfoFilePath, studentsJson);
    }

    //��ȡJSON�ļ��е�����
    public static List<Student> LoadStudentsFromJson() {
        if (File.Exists(_studentsInfoFilePath)) {
            string jsonContent = File.ReadAllText(_studentsInfoFilePath);

            //�� JSON ��ʽ���ַ��� jsonContent �����л�Ϊ List<Student> ����
            List<Student> loadedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonContent);

            // ��ȡѧ��ID����ӵ�usedIds��
            foreach (Student student in students) {
                usedIds.Add(student.StudentId);
            }

            return loadedStudents ?? new List<Student>(); // ��������ѧ���б���Ϊ���򷵻ؿ��б�
        }
        return new List<Student>();
    }
}