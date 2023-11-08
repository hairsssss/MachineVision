using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace work_11_07 {
    internal class Program {
        static void Main(string[] args) {
            #region 一 1.随机100个数字 然后使用ArrayList存储 （1）把最大的数字 输出（2）把元素从大到小排序 （3）算出所有数字的平均数
            Random random = new Random();
            ArrayList arrayList = new ArrayList();
            for (int i = 1; i <= 100; i++) {
                arrayList.Add(random.Next(0, 888));
            }
            //最大值
            int maxNumber = arrayList.Cast<int>().Max();
            //最小值
            int minNumber = arrayList.Cast<int>().Min();
            //排序 小--->大
            arrayList.Sort();
            Console.WriteLine($"{maxNumber}------{minNumber}-----{arrayList[0]}------{arrayList[arrayList.Count - 1]}");

            //倒序数组  大--->小
            arrayList.Reverse();

            //平均数
            int result = 0;
            foreach (int item in arrayList) {
                result += item;
            }
            int average = result / arrayList.Count;
            Console.WriteLine($"平均数：{average}");


            #endregion




            #region 二.登录注册功能  ArrayList 或者list<>    字典 版本 1.要求  注册 账号和密码 存储在对应的集合中 账号不能一样   密码 长度至少6位 2.登录成功后 提示登录成功 否则提示失败
            ArrayList userNameList = new ArrayList();
            ArrayList passwordList = new ArrayList();

            string filePath = "userInfo.txt";

            if (!File.Exists(filePath)) {
                File.Create(filePath).Close();
            } else {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines) {
                    string[] parts = line.Split(',');
                    Console.WriteLine(parts[0]);
                    userNameList.Add(parts[0]);
                    passwordList.Add(parts[1]);
                }
            }

            Console.Write("1. 注册  ");
            Console.Write("2. 登录  ");
            Console.Write("3. 退出  ");
            Console.Write("请选择一个选项：");
            while (true) {

                string option = Console.ReadLine();

                if (option == "1") {
                    Console.Write("请输入账号：");
                    string username = Console.ReadLine();

                    if (userNameList.Contains(username)) {
                        Console.Write("该账号已存在！");
                        continue;
                    }

                    string password;
                    while (true) {
                        Console.Write("请输入密码：");
                        password = Console.ReadLine();

                        if (password.Length >= 6) {
                            break;
                        } else {
                            Console.WriteLine("密码长度至少为6位，请重新输入！");
                        }
                    }

                    userNameList.Add(username);
                    passwordList.Add(password);

                    // 将账号和密码保存到文件中
                    File.AppendAllText(filePath, username + "," + password + "\n");

                    Console.WriteLine("注册成功！");
                    break;
                } else if (option == "2") {
                    if (userNameList.Count == 0) {
                        Console.WriteLine("没有账号，请先注册！");
                        continue;
                    }
                    while (true) {
                        Console.Write("请输入账号：");
                        string username = Console.ReadLine();

                        Console.Write("请输入密码：");
                        string password = Console.ReadLine();

                        int index = userNameList.IndexOf(username);
                        if (index != -1 && passwordList[index] as string == password) {
                            Console.WriteLine("登录成功！");
                            break;
                        } else {
                            Console.WriteLine("账号或密码错误，请重新输入！");
                        }
                    }
                    Console.WriteLine("按任意键退出！");
                    break;
                } else if (option == "3") {
                    break;
                } else {
                    Console.Write("请重新选择：");
                }
            }
            #endregion




            #region 三.以前的作业中所有不可变数组例子 修改成    ArrayList 或者list<>   字典 版本
            // 1.存储一组数字并找出最大值：
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5 };
            ArrayList arrayList1 = new ArrayList();
            for (int i = 0; i < numberList.Count; i++) {
                arrayList1.Add(numberList[i]);
            }
            int maxNumber3 = arrayList1.Cast<int>().Max();
            int minNumber3 = arrayList1.Cast<int>().Min();
            Console.WriteLine("最大值是：" + maxNumber3 + "最小值是：" + minNumber3);

            int maxNumber1 = numberList.Max();
            int minNumber1 = numberList.Min();
            Console.WriteLine("最大值是：" + maxNumber1 + "最小值是：" + minNumber1);

            Dictionary<int, string> numbers = new Dictionary<int, string> {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"}
            };
            int maxNumber2 = numbers.Keys.Max();
            int minNumber2 = numbers.Keys.Min();
            Console.WriteLine("最大值是：" + maxNumber2 + "最小值是：" + minNumber2);


            //2.检查一个字符串是否是回文：
            string input = "qweew1q";
            List<char> characters = input.ToList();
            characters.Reverse();
            string reversed = new string(characters.ToArray());
            bool isPalindrome = input == reversed;
            Console.WriteLine("字符串是否为回文：" + isPalindrome);

            ArrayList characters1 = new ArrayList(input.ToCharArray());
            characters.Reverse();
            string reversed1 = new string((char[])characters1.ToArray(typeof(char)));
            bool isPalindrome1 = input == reversed;
            Console.WriteLine("字符串是否为回文：" + isPalindrome);


            //3.统计文本中每个单词的出现次数：
            string text = "apple banana apple strawberry banana lemon";
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            string[] words = text.Split(' ');
            foreach (string word in words) {
                if (wordCounts.ContainsKey(word)) {
                    wordCounts[word]++;
                } else {
                    wordCounts[word] = 1;
                }
            }
            foreach (KeyValuePair<string, int> pair in wordCounts) {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }


            //4.实现一个简单的电话簿：
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook["Alice"] = "123-456-7890";
            phoneBook["Bob"] = "098-765-4321";
            foreach (string name in phoneBook.Keys) {
                Console.WriteLine(name + "的电话号码是：" + phoneBook[name]);
            }


            //5.实现一个简单的购物车：
            Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
            shoppingCart["apple"] = 5;
            shoppingCart["banana"] = 3;
            shoppingCart["lemon"] = 2;
            foreach (KeyValuePair<string, int> pair in shoppingCart) {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }


            //6.
            // 创建一个新的整数列表
            List<int> numbers6 = new List<int>();

            // 添加一些元素
            numbers6.Add(1);
            numbers6.Add(2);
            numbers6.Add(3);
            numbers6.Add(4);
            numbers6.Add(5);

            // 使用foreach循环打印出所有的元素
            foreach (int number in numbers6) {
                Console.WriteLine(number);
            }

            #endregion



        }
        #region 二.登录注册功能  ArrayList 或者list<>    字典 版本 1.要求  注册 账号和密码 存储在对应的集合中 账号不能一样   密码 长度至少6位 2.登录成功后 提示登录成功 否则提示失败

        #endregion
    }
}
