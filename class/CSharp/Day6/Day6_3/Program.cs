using System;

namespace Day6_3 {
    internal class Program {
        static void Main(string[] args) {

            ProgramMothod(10, 20);
            int tempA = 100;
            int tempB = 200;
            ProgramMothod(tempA, tempB);

            Console.WriteLine(tempA);
            Console.WriteLine(tempB);

            int tempC = 300;
            int tempD = 400;
            ProgramMothod1(ref tempC, ref tempD);
            Console.WriteLine(tempC);
            Console.WriteLine(tempD);

            int tempB1;
            int tempC2;
            int tempA1;
            ProgramMothod3(out tempA1, out tempB1, out tempC2);
            Console.WriteLine(tempA1);
            Console.WriteLine(tempB1);
            Console.WriteLine(tempC2);

            // int.TryParse(Console.ReadLine(), out tempA1);
            Console.ReadKey();
        }

        //  参数传递 形式：
        public static void ProgramMothod(int a, int b) {

            //交换a和b的值  如果交换之后 不影响外部tempA和tempB的值  就是值参数传递   
            int c;
            c = a;
            a = b;
            b = c;
        }

        //  引用参数 如果交换之后 影响外部tempA和tempB的值  引用参数传递
        public static void ProgramMothod1(ref int a, ref int b) {

            //交换a和b的值  如果交换之后 不影响外部tempA和tempB的值  就是值参数传递   
            int c;
            c = a;
            a = b;
            b = c;
        }
        //输出参数
        //特点：
        //1.是对于方法返回值的补充。return 语句可用于函数中返回一个值 输出参数可以返回多个值
        //2.关键字 out    out输出参数在方法中 必须被使用，且和retrun保持一致
        //3. 其他方面与引用参数相似

        public static void ProgramMothod3(out int a, out int b, out int c) {
            b = 20;
            c = 30;
            a = 1000;
            //

        }


    }
}
