using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace work10_30 {
    internal class Program {
        static void Main(string[] args) {
            //第一题 可变字符串
            // 1
            StringBuilder StringBuilderStr1 = new StringBuilder("Hello, ");
            StringBuilder StringBuilderStr2 = new StringBuilder("world!");
            StringBuilderStr1.Append(StringBuilderStr2);
            Console.WriteLine(StringBuilderStr1.ToString()); // Hello, world!

            // 2
            StringBuilder StringBuilderStr3 = new StringBuilder("刀不锋利马太瘦");
            // 在指定位置插入字符串
            StringBuilderStr3.Insert(7, "，你拿什么跟我斗。");
            Console.WriteLine(StringBuilderStr3.ToString()); // 刀不锋利马太瘦，你拿什么跟我斗。

            // 第二题 字符串API
            //1、Concat()：将多个字符串拼接成一个新的字符串。
            string str1 = "Hello";
            string str11 = "World";
            string result1 = string.Concat(str1, ", ", str11);
            Console.WriteLine(result1);


            Console.WriteLine($"{str1 + "，" + str11}-----");

            //2、ToUpper()和ToLower()：字符串大小写转换
            string str2 = "Hello,World!";
            string upper = str2.ToUpper(); // 转为大写
            string lower = str2.ToLower(); // 转为小写
            Console.WriteLine(upper);  // HELLO, WORLD!
            Console.WriteLine(lower);  // hello, world!

            string upperCaseStr = ToUpper(str2);
            string lowerCaseStr = ToLower(str2);
            Console.WriteLine($"{upperCaseStr}------ToUpper"); // 输出: HELLO, WORLD!
            Console.WriteLine($"{lowerCaseStr}------ToLower"); // 输出: hello, world!

            //3、Trim()：去除字符串两端的空白字符
            string str3 = "   Hello   ";
            string trimmed3 = str3.Trim();
            StringBuilder trim3 = new StringBuilder();


            //4、Substring()：从字符串中提取指定索引的字符
            string str4 = "Hello, World!";
            string subStr4 = str4.Substring(7, 5); // 截取从索引7开始的5个字符，结果是 "World"
            Console.WriteLine(subStr4); // World

            string subString4 = Substring(str4, 7, 5);
            Console.WriteLine($"{subString4}------Substring");

            //5、StartsWith()和EndWith()：检查字符串是否以特定前缀开头或后缀结尾
            string str5 = "Hello, World!";
            bool startsWithHello = str5.StartsWith("Hello"); // 检查是否以 "Hello" 开头
            bool endsWithWorld = str5.EndsWith("World!"); // 检查是否以 "World!" 结尾
            Console.WriteLine(startsWithHello);   // true
            Console.WriteLine(endsWithWorld);     // true

            //6、Replace()：替换字符串中的字符或子字符串
            string str6 = "Hello, World!";
            string replaced = str6.Replace("Hello", "Hi"); // 替换 "Hello" 为 "Hi"
            Console.WriteLine(replaced);  // Hi，World!

            //7、Split()：根据指定字符将字符串拆分为子字符串数组。
            string str7 = "张三,李四,王五,赵六";
            string[] result7 = str7.Split(',');
            Console.WriteLine(result7);


            string[] result77 = Split(str7, ',');
            foreach (string item in result77) {
                Console.WriteLine(item);
            }


            //8、IndexOf()和LastIndexOf()：查找字符或子字符串在字符串中的位置。
            string str8 = "Hello, World!";
            int indexOf8 = str8.IndexOf(',');
            int lastIndexOf8 = str8.LastIndexOf('l');
            Console.WriteLine(indexOf8);     // 5
            Console.WriteLine(lastIndexOf8); // 10

            //9、StartsWith：判断一个字符串是否以特定的前缀开头
            //Console.Write("请输入：");
            //string input9 = Console.ReadLine();
            //Console.WriteLine(input9.StartsWith(","));

            //10、Insert：返回一个新的字符串，将一个字符串插入到另一个字符串中指定索引的位置
            string str10 = "Hello, World!";
            string insertStr10 = str10.Insert(5, "好好好");
            Console.WriteLine(insertStr10);

            //11.Remove 返回一个新的字符串，将字符串中指定位置的字符串移除.
            string result = str10.Remove(7, 5);
            Console.WriteLine(result); // 输出: Hello, !

            //第三题 
            //1.去重
            string testStr = "adashausdkajsida";
            string result2 = new string(testStr.Distinct().ToArray());
            Console.WriteLine($"{result2}-----");

            //2.字符串字母出现次数
            var charCounts = testStr.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in charCounts) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //3.字符串反转
            char[] charArray = testStr.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);
            Console.WriteLine(testStr);
            Console.WriteLine(reversedStr);



        }

        // 转换为大写
        static string ToUpper(string str) {
            char[] charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length; i++) {
                if (char.IsLower(charArray[i])) {
                    if (charArray[i] >= 'a' && charArray[i] <= 'z') {
                        charArray[i] = (char)(charArray[i] - 32);
                    }
                }
            }
            return new string(charArray);
        }

        // 转换为小写
        static string ToLower(string str) {
            char[] charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length; i++) {
                if (char.IsUpper(charArray[i])) {
                    if (charArray[i] >= 'A' && charArray[i] <= 'Z') {
                        charArray[i] = (char)(charArray[i] + 32);
                    }
                }
            }
            return new string(charArray);
        }

        //Substring
        static string Substring(string str, int startIndex, int length) {
            if (str == null) {
                throw new ArgumentNullException(nameof(str));
            }

            if (startIndex < 0 || startIndex >= str.Length) {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "超出范围");
            }

            if (length < 0 || startIndex + length > str.Length) {
                throw new ArgumentOutOfRangeException(nameof(length), "超出范围");
            }

            char[] resultChars = new char[length];

            for (int i = 0; i < length; i++) {
                resultChars[i] = str[startIndex + i];
            }

            return new string(resultChars);
        }

        //split
        static string[] Split(string input, char delimiter) {
            if (input == null) {
                throw new ArgumentNullException(nameof(input));
            }

            List<string> substrings = new List<string>();
            int startIndex = 0;

            for (int i = 0; i < input.Length; i++) {
                if (input[i] == delimiter) {
                    substrings.Add(input.Substring(startIndex, i - startIndex));
                    startIndex = i + 1;
                }
            }

            substrings.Add(input.Substring(startIndex));

            return substrings.ToArray();
        }

    }
}
