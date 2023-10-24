using System;

namespace 位运算符 {
    internal class Program {
        static void Main(string[] args) {
            int a = 10;
            int b = -110;
            Console.WriteLine(~a);  // 按位去翻运算符，我们也理解为按位否运算符，他会将每一位上面的0置为1，1置为0 原码 反码 补码
            Console.WriteLine(~b);

            int c = 4;
            Console.WriteLine(c << 1);
            Console.ReadKey();
        }
    }
}
