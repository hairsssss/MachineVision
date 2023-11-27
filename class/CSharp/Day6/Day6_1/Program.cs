using System;
namespace Day6_1 {

    //入口类
    internal class Program {

        //入口函数 程序的入口 

        //类中成员可以包含函数（方法） 根据需求定义和使用函数
        //函数的作用：封装c#逻辑的一种结构
        //Main函数  程序的入口 但是 也是一个特殊的函数  c#中包含很多特殊的函数  或者自定义函数
        //函数分为 定义函数和调用（使用）函数
        //Main函数的定义  Main函数在程序执行的时候 调用
        //优点： 减少代码重复率 方法体现了c#语言的封装性
        static void Main(string[] args) {
            //本类调用自己的public方法
            Program.ConsoleNumberOne();
            //可简写
            ConsoleNumberOne();
            Program.ConsoleNumberTwo();
            Program.ConsoleNumberThree();
            Program.ConsoleNumberFour();


            //同一程序集 不同文件 中 类的方法使用
            Class1.Class1Methods();
            Class1.Class1Methods2();
            //  Class1.Class1Methods1();

            //不同程序集文件 中 类的方法使用
            Class1.Class1Methods();
            ClassLibrary1_6_1.Class1.Class1Methods();


            //在静态方法中调用静态方法
            //(1)在本类的静态方法中  可以省略类名
            ProgramMothod();
            //(2)其他类的静态方法中  不能省略类名
            Class1.Class1Methods3();
            //在静态方法中调用非静态方法
            //(1)在本类的静态方法中  
            // program是 Program类的实例对象
            Program program = new Program();
            program.ProgramMothod1();
            //(2)其他类的静态方法中
            Class1 class1 = new Class1();
            class1.Class1Methods4();



            Console.ReadKey();
        }

        /*
        声明方法基本结构：
        访问权限  静态或者非静态  返回值类型   方法名  （）{}
         */
        //访问权限  public private 常用 
        // static 静态（类）   不写非静态（实例）
        // 返回值类型 方法的结果的出口    void 无返回值类型    有返回值类型（c#中所有的类型 都可以做为有返回值类型）
        // 方法名 要求大驼峰命名方式  尽量能体现方法的作用
        //（） 形式参数（形参）  形参一般就是定义变量
        // {封装的逻辑代码}


        //调用方法基本结构 
        // 静态方法调用   使用类名.方法名()
        //非静态方法调用  使用实例对象.方法名()

        /*
         
           方法的分类：
      从访问权限分类
     从有无参数分类
     从静态和非静态分类
     有无返回值分类
         */
        public static void ConsoleNumberOne() {
            Console.WriteLine(100);
        }
        internal static void ConsoleNumberTwo() {
            Console.WriteLine(1000);
        }
        private static void ConsoleNumberThree() {
            Console.WriteLine(10000);
        }
        protected static void ConsoleNumberFour() {
            Console.WriteLine(10000);
        }




        //从静态和非静态分类


        public static void ProgramMothod() {

            Console.WriteLine("ProgramMothod");

        }


        public void ProgramMothod1() {
            Console.WriteLine("ProgramMothod1");

        }

        //实例方法（非静态方法）
        public void ProgramMothodTest() {

            //调用本类的静态方法 可以省略类名
            Program.ProgramMothod();

            //
            Program program = new Program();
            program.ProgramMothod1();

            //调用本类的非静态方法 可以省略实例对象
            this.ProgramMothod1();

        }
    }
}
