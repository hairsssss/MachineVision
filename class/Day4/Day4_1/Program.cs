using System;

namespace Day4_1 {
    internal class Program {
        static void Main(string[] args) {
            //关系运算符 < <= > >=  == != 
            int a = 1;
            int b = 2;
            bool isTrue = a < b;
            Console.WriteLine(isTrue);
            bool isTrue1 = a <= b;
            Console.WriteLine(isTrue1);
            bool isTrue2 = a > b;
            Console.WriteLine(isTrue2);
            bool isTrue3 = a >= b;
            Console.WriteLine(isTrue3);
            bool isTrue4 = a == b;
            Console.WriteLine(isTrue4);
            bool isTrue5 = a != b;
            Console.WriteLine(isTrue5);


            float float1 = 1;
            int int1 = 1;
            Console.WriteLine(float1 == int1);


            //字符串不能使用 < <= > >=
            string str1 = "456";
            string str2 = "123";
            Console.WriteLine(str1 != str2);

            People man = new People();
            People woman = new People();
            People woman1 = man;
            Console.WriteLine(man == woman);
            //类之间不允许使用 < <= > >=    如需使用必须重载运算符
            //Console.WriteLine(man <= woman);

            //逻辑运算符  && || !  与 或 取反

            bool isTrue6 = true;
            bool isTrue7 = false;
            Console.WriteLine(isTrue6 ? "好好好" : "不中");
            Console.WriteLine(isTrue6 && isTrue7 ? "好好好" : "不中");
        }
    }
    public class People { }
}
