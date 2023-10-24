using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第一个控制台应用程序
{
    internal class Program
    {
        /// <summary>
        /// 第一个变量
        /// </summary>
        static int i;
        static void Main(string[] args)
        {
            i = 0;
            Console.WriteLine("Hello world"); // 控制台输出 自动换行
            Console.WriteLine("王德发"); // 控制台输出 自动换行
            Console.ReadKey(); // 等待用户输入，常用于对程序界面的停留
        }
    }
}
