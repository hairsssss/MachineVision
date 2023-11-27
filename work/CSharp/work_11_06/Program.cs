using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace work_11_06 {
    internal class Program {
        static void Main(string[] args) {
            #region 1.当你同时和两个人谈话，分别是中国人和美国人，如果想和这两人交流，那么必须对中国人说汉语，对美国人说英语 使用接口完成
            PensonSpeak chinese = new ChinesePerson();
            chinese.Speak();

            PensonSpeak american = new AmericanPerson();
            american.Speak();

            #endregion


            #region 2.当你去中国四大银行办理业务时   所有银行业务，有存钱，取钱，还有账号余额属性  使用接口完成
            IBankService icbc = new ICBC();
            icbc.Deposit(1000);
            icbc.Withdraw(500);


            #endregion

            #region 3.自己百度3个关于接口的功能 和3个泛型类 功能
            var dict = new GenericDictionary<string, int>();

            var intList = new GenericList<int>();
            intList.Add(1);
            intList.Add(2);

            var item = intList.Find(0);
            Console.WriteLine(item); // 输出 1


            int[] intArray = { 3, 1, 2 };

            GenericAlgorithm<int> intSorter = new GenericAlgorithm<int>();
            intSorter.Sort(intArray); // 排序int数组

            string[] stringArray = { "b", "a", "c" };

            GenericAlgorithm<string> stringSorter = new GenericAlgorithm<string>();
            stringSorter.Sort(stringArray); // 排序string数组
            #endregion

            #region 4.利⽤（类与对象和接口）做学⽣管理系统 添加学⽣ 移除学⽣【根据学号移除】 查询学⽣【根据姓名查询学⽣、根据性别查询学⽣、根据年龄查询学⽣】 按身⾼排序学⽣ 按年龄排序学⽣
            StudentManagementSystem sms = new StudentManagementSystem();
            string filePath = "students.txt";

            // 如果文件不存在，则创建一个新的文件
            if (!File.Exists(filePath)) {
                File.Create(filePath).Close();
            }

            // 读取文件中的学生信息
            string[] lines = File.ReadAllLines("students.txt");
            foreach (string line in lines) {
                string[] studentInfo = line.Split(' ');
                sms.AddStudent(new Student { Name = studentInfo[0], Gender = studentInfo[1], Age = int.Parse(studentInfo[2]), Height = int.Parse(studentInfo[3]), StudentId = studentInfo[4] });
            }

            // 如果有学生信息，则展示，否则提示暂无学生信息
            if (sms.StudentsCount() > 0) {
                var students = sms.GetAllStudents();
                foreach (var student in students) {
                    Console.WriteLine($"姓名：{student.Name}，性别：{student.Gender}，年龄：{student.Age}，身高：{student.Height}，学号：{student.StudentId}");
                }
            } else {
                Console.WriteLine("系统中暂无学生信息！");
            }
            while (true) {
                Console.WriteLine("请选择操作：1 添加学生 2 删除学生 3 查询学生 4 排序学生");
                string op = Console.ReadLine();

                switch (op) {
                    case "1":
                        Console.WriteLine("请输入学生信息（姓名 性别 年龄 身高 学号）使用空格隔开：");
                        string[] studentInfo = Console.ReadLine().Split(' ');
                        sms.AddStudent(new Student { Name = studentInfo[0], Gender = studentInfo[1], Age = int.Parse(studentInfo[2]), Height = int.Parse(studentInfo[3]), StudentId = studentInfo[4] });
                        break;
                    case "2":
                        if (sms.StudentsCount() == 0) {
                            Console.WriteLine("当前没有学生，无法执行删除操作！");
                            break;
                        }
                        Console.WriteLine("请输入要删除的学生学号：");
                        string studentId = Console.ReadLine();
                        sms.RemoveStudent(studentId);
                        break;
                    case "3":
                        Console.WriteLine("请输入要查询的学生姓名：");
                        string name = Console.ReadLine();
                        var students = sms.QueryStudentsByName(name);
                        foreach (var student in students) {
                            Console.WriteLine($"姓名：{student.Name}，性别：{student.Gender}，年龄：{student.Age}，身高：{student.Height}，学号：{student.StudentId}");
                        }
                        break;
                    case "4":
                        if (sms.StudentsCount() == 0) {
                            Console.WriteLine("当前没有学生，无法执行排序操作！");
                            break;
                        }
                        Console.WriteLine("请选择排序方式：1 年龄 2 身高");
                        string sortType = Console.ReadLine();
                        List<Student> sortedStudents = sortType == "1" ? sms.SortStudentsByAge() : sms.SortStudentsByHeight();
                        foreach (var student in sortedStudents) {
                            Console.WriteLine($"姓名：{student.Name}，性别：{student.Gender}，年龄：{student.Age}，身高：{student.Height}，学号：{student.StudentId}");
                        }
                        break;
                    default:
                        Console.WriteLine("无效的操作，请重新输入！");
                        break;
                }

                Console.WriteLine("是否退出程序？（y/n）");
                string exit = Console.ReadLine();
                if (exit.ToLower() == "y") {
                    break;
                }
            }
            var allStudents = sms.GetAllStudents();
            List<string> outputLines = new List<string>();
            foreach (var student in allStudents) {
                outputLines.Add($"{student.Name} {student.Gender} {student.Age} {student.Height} {student.StudentId}");
            }
            File.WriteAllLines("students.txt", outputLines);
            #endregion




            Console.ReadKey();
        }

        #region 1.当你同时和两个人谈话，分别是中国人和美国人，如果想和这两人交流，那么必须对中国人说汉语，对美国人说英语 使用接口完成
        public interface PensonSpeak {
            void Speak();
        }

        public class ChinesePerson : PensonSpeak {
            public void Speak() {
                Console.WriteLine("你好，我是中国人。");
            }
        }

        public class AmericanPerson : PensonSpeak {
            public void Speak() {
                Console.WriteLine("Hello, I am American.");
            }
        }

        #endregion

        #region 2.当你去中国四大银行办理业务时   所有银行业务，有存钱，取钱，还有账号余额属性  使用接口完成
        public interface IBankService {
            decimal Balance { get; }

            void Deposit(decimal amount);

            void Withdraw(decimal amount);
        }

        public class ICBC : IBankService {
            private decimal balance;

            public decimal Balance => balance;

            public void Deposit(decimal amount) {
                balance += amount;
                Console.WriteLine($"工商银行存入 {amount} 元，当前余额：{balance} 元。");
            }

            public void Withdraw(decimal amount) {
                if (balance >= amount) {
                    balance -= amount;
                    Console.WriteLine($"工商银行取出 {amount} 元，当前余额：{balance} 元。");
                } else {
                    Console.WriteLine("工商银行余额不足，取款失败。");
                }
            }
        }

        public class CCB : IBankService {
            private decimal balance;

            public decimal Balance => balance;

            public void Deposit(decimal amount) {
                balance += amount;
                Console.WriteLine($"工商银行存入 {amount} 元，当前余额：{balance} 元。");
            }

            public void Withdraw(decimal amount) {
                if (balance >= amount) {
                    balance -= amount;
                    Console.WriteLine($"工商银行取出 {amount} 元，当前余额：{balance} 元。");
                } else {
                    Console.WriteLine("工商银行余额不足，取款失败。");
                }
            }
        }
        public class BOC : IBankService {
            private decimal balance;

            public decimal Balance => balance;

            public void Deposit(decimal amount) {
                balance += amount;
                Console.WriteLine($"工商银行存入 {amount} 元，当前余额：{balance} 元。");
            }

            public void Withdraw(decimal amount) {
                if (balance >= amount) {
                    balance -= amount;
                    Console.WriteLine($"工商银行取出 {amount} 元，当前余额：{balance} 元。");
                } else {
                    Console.WriteLine("工商银行余额不足，取款失败。");
                }
            }
        }
        public class ABC : IBankService {
            private decimal balance;

            public decimal Balance => balance;

            public void Deposit(decimal amount) {
                balance += amount;
                Console.WriteLine($"工商银行存入 {amount} 元，当前余额：{balance} 元。");
            }

            public void Withdraw(decimal amount) {
                if (balance >= amount) {
                    balance -= amount;
                    Console.WriteLine($"工商银行取出 {amount} 元，当前余额：{balance} 元。");
                } else {
                    Console.WriteLine("工商银行余额不足，取款失败。");
                }
            }
        }



        #endregion

        #region 3.自己百度3个关于接口的功能 和3个泛型类 功能
        public interface IShape {
            void Draw();
        }

        public class Circle : IShape {
            public void Draw() {
                Console.WriteLine("圆");
            }
        }

        public class Rectangle : IShape {
            public void Draw() {
                Console.WriteLine("矩形");
            }
        }


        public class GenericList<T> {
            private T[] _items = new T[10];
            private int _count;

            public void Add(T item) {
                if (_count >= _items.Length)
                    Resize();

                _items[_count++] = item;
            }

            private void Resize() {
                T[] newArray = new T[_items.Length * 2];
                Array.Copy(_items, 0, newArray, 0, _items.Length);
                _items = newArray;
            }

            public T Find(int index) {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                return _items[index];
            }
        }



        public class GenericDictionary<TKey, TValue> {
            private TKey[] keys;
            private TValue[] values;
        }


        public class GenericAlgorithm<T> {
            public void Sort(T[] array) {
                // 实现通用排序算法
                for (int i = 0; i < array.Length - 1; i++) {
                    for (int j = i + 1; j < array.Length; j++) {
                        if (Comparer<T>.Default.Compare(array[i], array[j]) > 0) {
                            T temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }

        #endregion

        #region 4.利⽤（类与对象和接口）做学⽣管理系统 添加学⽣ 移除学⽣【根据学号移除】 查询学⽣【根据姓名查询学⽣、根据性别查询学⽣、根据年龄查询学⽣】 按身⾼排序学⽣ 按年龄排序学⽣
        public class Student {
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int Height { get; set; }
            public string StudentId { get; set; }
        }

        public class StudentManagementSystem {
            private List<Student> students = new List<Student>();

            public List<Student> GetAllStudents() {
                return students;
            }

            public int StudentsCount() {
                return students.Count;
            }
            public void AddStudent(Student student) {
                students.Add(student);
            }

            public void RemoveStudent(string studentId) {
                students.RemoveAll(s => s.StudentId == studentId);
            }

            public List<Student> QueryStudentsByName(string name) {
                return students.Where(s => s.Name == name).ToList();
            }

            public List<Student> QueryStudentsByGender(string gender) {
                return students.Where(s => s.Gender == gender).ToList();
            }

            public List<Student> QueryStudentsByAge(int age) {
                return students.Where(s => s.Age == age).ToList();
            }

            public List<Student> SortStudentsByHeight() {
                return students.OrderBy(s => s.Height).ToList();
            }

            public List<Student> SortStudentsByAge() {
                return students.OrderBy(s => s.Age).ToList();
            }
        }

        #endregion

    }
}
