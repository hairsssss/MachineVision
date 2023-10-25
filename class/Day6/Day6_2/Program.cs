using System;

namespace Day6_2 {
    internal class Program {
        static void Main(string[] args) {

            ProgramMothod();
            //1.没有找到无参的方法
            //2.找了一个有一个int类型的 必写参数
            //调用方法时 传入的参数  叫实际参数（实参）
            ProgramMothod1(10);
            ProgramMothod1(5);
            ProgramMothod2("abc");
            ProgramMothod3(20, 30);
            ProgramMothod4(40, "123");
            ProgramMothod5(100);

            int retrunNumber = ProgramMothod6(300);
            int tempNumber = 200;
            Console.WriteLine(retrunNumber + tempNumber);
        }


        // 从有无参数分类

        //无参数方法
        //输出10次的整数1
        public static void ProgramMothod() {

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(1);
            }
        }

        //有参方法
        //输出10次任意的整数
        public static void ProgramMothod1(int a) {


            for (int i = 0; i < 10; i++) {
                Console.WriteLine(a);
            }
        }

        public static void ProgramMothod2(string a) {


            for (int i = 0; i < 10; i++) {
                Console.WriteLine(a);
            }
        }
        public static void ProgramMothod3(int a, int b) {


            for (int i = 0; i < 10; i++) {
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }
        public static void ProgramMothod4(int a, string b) {


            for (int i = 0; i < 10; i++) {
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }

        // 从有无返回值分类
        // void 无返回值  代表方法的结果无出口
        public static void ProgramMothod5(int a) {

            Console.WriteLine(a - 1);
        }
        //有返回值   必须使用return 来把逻辑的结果传出去  
        //return 跳出函数作用
        public static int ProgramMothod6(int a) {
            Console.WriteLine(a - 1);
            return a - 1;
        }

        public static int ProgramMothod7(int a) {
            if (a - 1 < 100) {
                return 100;

            } else {
                Console.WriteLine(a - 1);
            }
            return 0;
        }
    }
}
