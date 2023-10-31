using System;

namespace work_10_27 {
    public class ArrayManipulation {
        // 设置数组中的值
        public static void SetValue(int[] array, int index, int value) {
            if (index >= 0 && index < array.Length) {
                array[index] = value;
            }
        }

        // 获取数组中的值
        public static int GetValue(int[] array, int index) {
            if (index >= 0 && index < array.Length) {
                return array[index];
            }
            return -1; // 或者你可以选择其他错误处理方式
        }

        // 查找元素的索引
        public static int IndexOf(int[] array, int value) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == value) {
                    return i;
                }
            }
            return -1; // 如果未找到，返回-1
        }

        // 反转数组
        public static void Reverse(int[] array) {
            int left = 0;
            int right = array.Length - 1;
            while (left < right) {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
    }
    internal class Program {
        static void Main(string[] args) {
            /* int[] numArr = { 1, 2, 3, 4, 5, 6, 7, 8 };
             // GetValue：获取一维数组中指定位置的值
             int firstElement = (int)numArr.GetValue(0);
             Console.WriteLine(firstElement); // 1
             ArrayManipulation.SetValue(numArr, 200, 0);

             //SetValue：给一维数组中指定位置的元素设置值。
             numArr.SetValue(100, 0);
             ArrayManipulation.GetValue(numArr, 1);

             //IndexOf：搜索指定的对象，返回整个一维数组中第一次出现的索引。
             Console.WriteLine(Array.IndexOf(numArr, 3)); // 2
             ArrayManipulation.IndexOf(numArr, 4);

             //Reverse：逆转整个一维数组中元素的顺序。
             Array.Reverse(numArr);
             ArrayManipulation.Reverse(numArr);
             Console.WriteLine(numArr[0]);


             //交错数组
             // 创建三个交错数组
             int[][] jaggedArray = new int[3][];

             // 初始化第一个子数组
             jaggedArray[0] = new int[] { 1, 2, 3 };

             // 初始化第二个子数组
             jaggedArray[1] = new int[] { 4, 5, 6, 7 };

             // 初始化第三个子数组
             jaggedArray[2] = new int[] { 8, 9 };

             // 打印交错数组中的元素
             for (int i = 0; i < jaggedArray.Length; i++) {
                 for (int j = 0; j < jaggedArray[i].Length; j++) {
                     Console.Write(jaggedArray[i][j] + " ");
                 }
                 Console.WriteLine();
             }

             // 创建三个交错数组，每个数组都是字符串数组
             string[][] jaggedStrArray = new string[3][];

             // 初始化第一个字符串数组
             jaggedStrArray[0] = new string[] { "apple", "banana", "cherry" };

             // 初始化第二个字符串数组
             jaggedStrArray[1] = new string[] { "dog", "cat", "rabbit", "elephant" };

             // 初始化第三个字符串数组
             jaggedStrArray[2] = new string[] { "car", "bus" };

             // 打印交错数组中的元素
             for (int i = 0; i < jaggedStrArray.Length; i++) {
                 for (int j = 0; j < jaggedStrArray[i].Length; j++) {
                     Console.Write(jaggedStrArray[i][j] + " ");
                 }
                 Console.WriteLine();
             }

             // 创建三个交错数组，每个数组都是字符串数组
             string[][] jaggedStrArray1 = new string[3][] { new string[] { "apple", "banana", "cherry" }, new string[] { "dog", "cat", "rabbit", "elephant" }, new string[] { "car", "bus" } };

             // 打印交错数组中的元素
             for (int i = 0; i < jaggedStrArray.Length; i++) {
                 for (int j = 0; j < jaggedStrArray[i].Length; j++) {
                     Console.Write(jaggedStrArray[i][j] + " ");
                 }
                 Console.WriteLine();
             }

             int sum5 = SumIntegers(1, 2, 3, 4, 5);
             Console.WriteLine("Sum of integers: " + sum5);

             double average = AverageDoubles(2.5, 3.0, 4.5, 5.0);
             Console.WriteLine("Average of doubles: " + average);

             ConcatenateStrings("Hello", " ", "world", "!");

             DisplayObjects("Hello", 42, 3.14, true);




             //字符串方法
             //Concat()：将多个字符串拼接成一个新的字符串。
             string str1 = "Hello";
             string str2 = "World";
             string result = string.Concat(str1, ", ", str2);

             //ToUpper()和ToLower()：字符串大小写转换
             string str3 = "AbCdEf";
             string upper = str3.ToUpper(); // 转为大写
             string lower = str3.ToLower(); // 转为小写

             //Trim()：去除字符串两端的空白字符
             string str4 = "   Hello   ";
             string trimmed = str4.Trim(); // 去除两端的空白字符

             //Substring()：从字符串中提取指定索引的字符
             string str5 = "Hello, World!";
             string subStr = str5.Substring(7, 5); // 提取从索引7开始的5个字符，结果是 "World"

             //IndexOf()和LastIndexOf()：查找字符或子字符串在字符串中的位置。
             string str6 = "Hello, World!";
             int indexOfComma = str6.IndexOf(','); // 查找逗号的位置，结果是 5
             int lastIndexOfL = str6.LastIndexOf('l'); // 查找最后一个小写字母 "l" 的位置，结果是 10

             //判断一个字符串是否以特定的前缀开头
             string input7 = Console.ReadLine();
             Console.WriteLine(input7.StartsWith(","));*/
            Console.Write("请输入学生总数：");
            int studentCount = int.Parse(Console.ReadLine());

            string[][] studentInfo = new string[studentCount][];

            for (int i = 0; i < studentCount; i++) {
                Console.WriteLine($"添加第 {i + 1} 个学生信息：");

                Console.Write("学生姓名: ");
                string name = Console.ReadLine();

                Console.Write("年龄 (18-20): ");
                int age = int.Parse(Console.ReadLine());

                while (age < 18 || age > 20) {
                    Console.Write("年龄不在范围内，请重新输入 (18-20): ");
                    age = int.Parse(Console.ReadLine());
                }

                Console.Write("分数 (0-100): ");
                int score = int.Parse(Console.ReadLine());

                while (score < 0 || score > 100) {
                    Console.Write("分数不在范围内，请重新输入 (0-100): ");
                    score = int.Parse(Console.ReadLine());
                }

                Console.Write("性别 (0-女, 1-男): ");
                int gender = int.Parse(Console.ReadLine());

                while (gender != 0 && gender != 1) {
                    Console.Write("性别不在范围内，请重新输入 (0-女, 1-男): ");
                    gender = int.Parse(Console.ReadLine());
                }

                studentInfo[i] = new string[] { name, age.ToString(), score.ToString(), gender.ToString() };
            }

            DisplayStudentInfo(studentInfo);

            while (true) {
                Console.Write("提示退出程序或修改学生信息 (Y/N): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y") {
                    int studentNumber = -1;
                    while (studentNumber < 1 || studentNumber > studentCount) {
                        Console.Write("要修改第几个学生信息（1,2,3,4,...）？请输入对应的编号：");
                        studentNumber = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine($"修改第 {studentNumber} 个学生信息：");

                    Console.Write("学生姓名: ");
                    string name = Console.ReadLine();

                    Console.Write("年龄 (18-20): ");
                    int age = int.Parse(Console.ReadLine());

                    while (age < 18 || age > 20) {
                        Console.Write("年龄不在范围内，请重新输入 (18-20): ");
                        age = int.Parse(Console.ReadLine());
                    }

                    Console.Write("分数 (0-100): ");
                    int score = int.Parse(Console.ReadLine());

                    while (score < 0 || score > 100) {
                        Console.Write("分数不在范围内，请重新输入 (0-100): ");
                        score = int.Parse(Console.ReadLine());
                    }

                    Console.Write("性别 (0-女, 1-男): ");
                    int gender = int.Parse(Console.ReadLine());

                    while (gender != 0 && gender != 1) {
                        Console.Write("性别不在范围内，请重新输入 (0-女, 1-男): ");
                        gender = int.Parse(Console.ReadLine());
                    }

                    studentInfo[studentNumber - 1] = new string[] { name, age.ToString(), score.ToString(), gender.ToString() };
                    DisplayStudentInfo(studentInfo);
                } else if (choice == "n") {
                    break;
                }
            }
        }

        static int SumIntegers(params int[] numbers) {
            int sum = 0;
            foreach (int num in numbers) {
                sum += num;
            }
            return sum;
        }

        static double AverageDoubles(params double[] numbers) {
            if (numbers.Length == 0)
                return 0.0;

            double sum = 0;
            foreach (double num in numbers) {
                sum += num;
            }
            return sum / numbers.Length;
        }

        static void ConcatenateStrings(params string[] strings) {
            string result = string.Concat(strings);
            Console.WriteLine(result);
        }

        static void DisplayObjects(params object[] objects) {
            foreach (object obj in objects) {
                Console.WriteLine(obj.ToString());
            }
        }

        static void DisplayStudentInfo(string[][] studentInfo) {
            Console.WriteLine("学生信息：");
            for (int i = 0; i < studentInfo.Length; i++) {
                Console.WriteLine($"学生{i + 1}: 姓名 - {studentInfo[i][0]}, 年龄 - {studentInfo[i][1]}, 分数 - {studentInfo[i][2]}, 性别 - {(studentInfo[i][3] == "0" ? "女" : "男")}");
            }
        }
    }
}
