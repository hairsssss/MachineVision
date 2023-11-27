using System;

namespace Day8_4 {
    internal class Program {
        static void Main(string[] args) {

            /*
            可变参数params （讲完数组再说）
            1.params是ParamArrayAttribute（参数数组属性）的缩写
            2.param解决了C#中不定长参数的传递的问题
            3.params参数必须定义在参数列表最后面。
            4.params必须是一维数组
            5.params只能在一个方法中 定义一个一维数组 
             */

            ProgramMothod(10, 20);
            ProgramMothod2(30, 20);
            int[] intArray1 = new int[3] { 3, 4, 5 };
            ProgramMothod2(50, 60, intArray1);
            ProgramMothod2(10, 20, 30, 40, 50);
            Console.ReadKey();
        }

        public static void ProgramMothod(int a, int b) {

            Console.WriteLine(a + b);
        }
        public static void ProgramMothod1(int a, int b, int c) {
            Console.WriteLine(a + b + c);
        }
        //任意个数的整数相加求和  只用一个方法实现
        public static void ProgramMothod2(int a, int b, params int[] intArray) {

            int tempC = a + b;
            if (intArray != null) {

                foreach (var item in intArray) {
                    tempC += item;
                }

                Console.WriteLine(tempC);
            } else {

                Console.WriteLine(tempC);
            }
        }
    }
}
