using System;

namespace Day10_3 {
    internal class Program {
        static void Main(string[] args) {


            People zhangsan = new People();
            zhangsan._id = 1;
            Console.WriteLine(People._CONST_NUMBER);

            Console.WriteLine(zhangsan._readonlyNumber);
            Console.WriteLine(People._readonlyNumber1);
            Console.ReadKey();
            //  Console.WriteLine(zhangsan._CONST_NUMBER); 
        }
    }

    internal class People {


        //可读可写  既能使用 也能修改
        public int _id = 10;
        //只读    只能使用 不能修改   
        public const int _CONST_NUMBER = 300;
        public readonly int _readonlyNumber = 400;
        public static readonly int _readonlyNumber1 = 500;
        //常量不能使用static描述
        // static const int _CONST_NUMBER1 = 300;

        public void PeopleMothod() {

            _id = 30;
            Console.WriteLine(_id);

            //只读局部常量
            const double PI = 3.1415926;
            Console.WriteLine(PI);
            //使用只读全部变量
            Console.WriteLine(_CONST_NUMBER);

            //
            Console.WriteLine(_readonlyNumber);

        }
    }
}
