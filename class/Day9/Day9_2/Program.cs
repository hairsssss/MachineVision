using System;
using System.Text;

namespace Day9_2 {
    internal class Program {
        static void Main(string[] args) {
            //不可变字符串  内存是不可变化的  
            string str = "123";
            str = "666";
            string str1 = "456";
            Console.WriteLine(str + str1);

            //方式1 字面量创建字符串
            string str3 = "abc";
            string str4 = @"abc";
            //方式2  通过单字符数组创建字符串
            char[] charArray = new char[5] { 'a', 'b', 'c', 'd', 'f' };
            string str5 = new string(charArray);
            Console.WriteLine(str5);

            //方式3  格式化字符串
            string str6 = string.Format("123");
            Console.WriteLine(str6);

            //不可变字符串本质也是不可变的单字符的集合  

            string str7 = "abcdgbhj123";
            //遍历字符串
            foreach (char item in str7) {
                Console.WriteLine(item);
            }

            for (int i = 0; i < str7.Length; i++) {

                Console.WriteLine(str7[i]);
            }

            char[] charsArray = new char[2] { '1', '2' };
            charsArray[0] = 'a';

            // Console.WriteLine(str7[0]);
            // str7[0] = 'm';

            //

            int indexCharNumber = str7.IndexOf('a');
            Console.WriteLine(indexCharNumber);


            bool isTrue = str7.StartsWith("aab");


            string str8 = "ABC";
            string tolowerStr = str8.ToLower();
            Console.WriteLine(tolowerStr);
            Console.WriteLine(isTrue);

            string str9 = " ad min  ";

            string trimStr = str9.Trim();
            Console.WriteLine(trimStr);
            Console.WriteLine(str9.Length);
            Console.WriteLine(trimStr.Length);
            string removeStr = str9.Remove(0, 4);
            Console.WriteLine(removeStr);

            string subStr = str9.Substring(2);
            Console.WriteLine(subStr);
            string subStr1 = str9.Substring(0, 4);
            Console.WriteLine(subStr1);
            string insertStr = str9.Insert(4, "zzz");
            Console.WriteLine(insertStr);

            string concatStr = string.Concat("abc", "ddd");
            Console.WriteLine(concatStr);

            bool isTrue1 = str9.Contains("abc");
            Console.WriteLine(isTrue1);

            string.IsNullOrEmpty(trimStr);
            ///   string.is

            if (str9 == null || str9 == "") {

                Console.WriteLine("字符串不合法");

            }
            if (string.IsNullOrEmpty(str9) || string.IsNullOrWhiteSpace(str9)) {

                Console.WriteLine("字符串不合法");


            }
            string str10 = "abc,def";
            //char[] charArray1 = str10.ToCharArray();

            char[] charArray2 = new char[str10.Length];

            for (int i = 0; i < str10.Length; i++) {
                charArray2[i] = str10[i];
            }


            string[] stringArray = str10.Split(',');

            foreach (var item in stringArray) {
                Console.WriteLine(item);
            }

            string str11 = @"https://mbd.baidu.com";

            string[] stringArray1 = str11.Split('.');
            foreach (var item in stringArray1) {
                Console.WriteLine(item);
            }
            Console.WriteLine(stringArray1[1]);



            //StringBuilder类的使用     
            //不可变字符串穿拼接

            string str12 = "123";
            string str13 = "456";
            string str14 = "";
            Console.WriteLine(str12 + str13 + str14);
            //初始化可变字符串对象 
            StringBuilder stringBuilder = new StringBuilder();
            //  "" +"123"
            stringBuilder.Append(str12);
            stringBuilder.Append(str13);
            stringBuilder.Append(str14);
            Console.WriteLine(stringBuilder);
            stringBuilder.Insert(0, str12);
            Console.WriteLine(stringBuilder);

            stringBuilder.Remove(0, 4);
            Console.WriteLine(stringBuilder);
            stringBuilder.Clear();
            Console.WriteLine(stringBuilder);





            //格式化字符串
            int a = 10;
            int b = 2;
            Console.WriteLine("当前输出" + a + "的值为:" + a);
            Console.WriteLine("当前输出的值为a");

            //用{ }来表示，在{ }内填写占位符 {}配合相应的数字 


            Console.WriteLine("当前输出的值为{0}", a);
            Console.WriteLine("当前a值为{0},b的值为{1}", a, b);
            Console.WriteLine("当前a值为{0},b的值为{0}", a, b);

            Console.WriteLine("当前a值为{1},b的值为{0}{2}", a, b, a);
            //格式化字符串
            string newStr = string.Format("当前输出的值为{0}", a);
            Console.WriteLine(newStr);


            //  
            int j = 12345;
            string formatStr = string.Format("{0}", j);
            Console.WriteLine(formatStr);
            string formatStr1 = string.Format("{0:C}", j);
            Console.WriteLine(formatStr1);   //货币

            Console.WriteLine("{0:D}", j);   //十进制数
            Console.WriteLine("{0:E}", j);    //科学技术法
            Console.WriteLine("{0:F}", j);   // 浮点数表示法
            Console.WriteLine("{0:G}", j);   //G或g General 常用格式
            Console.WriteLine("{0:N}", j);   //N或n 用逗号分割千位的数字
            Console.WriteLine("{0:C5}", j); // ￥123,456.00



            Console.WriteLine(DateTime.Now);
            Console.WriteLine("{0:D}", DateTime.Now);   //输出到天

            //模板字符串 $"{变量1},{变量2}"
            Console.WriteLine($"当前输出的值为{a}");

            Console.WriteLine($"当前输出的值为{a},当前输出的值为{b}");
            Console.WriteLine($"当前输出的值为{a + b},当前输出的值为{b - a}");
            Console.WriteLine($"当前输出的值为{a > b},当前输出的值为{b == a}");
            Console.WriteLine($"当前输出的值为{(a > b ? a : b)}");
            Console.WriteLine($"当前输出的值为{Sum(10, 20)}");

            //  Console.WriteLine($"当前输出的值为{Sum1(10, 20)}");

            Console.ReadKey();
        }

        public static int Sum(int a, int b) {
            return a + b;
        }
        public static void Sum1(int a, int b) {
            Console.WriteLine(a + b);
        }
    }
}
