using System;

namespace Day3_2 {
    internal class Program {
        static void Main(string[] args) {

            //控制台输出           代码--->控制台
            Console.WriteLine("换行");  // 可空字符串 (类似后面加了<\br>)
            Console.Write("不换行");  // 不可空字符串
            Console.Write("不换行");
            Console.Write("\n");
            Console.WriteLine("换行");  // 可空 (类似后面加了<\br>)


            //获取控制台输入内容   控制台--->代码
            //读取屏幕字符并返回
            //暂停当前程序，等待用户输入后按回车继续执行程序
            string readLineStr = Console.ReadLine();     // 读取的是多字符
            Console.WriteLine($"我打印的是{readLineStr}");


            int readInt = Console.Read();        // 读取的是第一个字符所对应的ASCll码
            char readChar = (char)readInt;
            Console.WriteLine($"我打印的ASCll码是{readInt}");
            Console.WriteLine($"我打印的是{readChar}");
        }
    }
}
