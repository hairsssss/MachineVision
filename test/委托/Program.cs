using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托 {
    internal class Program {
        public delegate double Cal(double x, double y);
        static double Add(double x, double y) {
            return x + y;
        }
        static double Dec(double x, double y) {
            return x - y;
        }
        static double Mul(double x, double y) {
            return x * y;
        }

        static void Test(Cal fun) {
            Console.WriteLine("请输入第一个");
            double num = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入第二个");
            double num1 = Convert.ToDouble(Console.ReadLine());
            double result = fun(num, num1);
            Console.WriteLine($"结果是{result}");
        }

        static void Main(string[] args) {
            Cal cal = Add;
            Console.WriteLine(cal(1, 2));
            Test(Mul);
        }
    }
}
