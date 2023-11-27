using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_1 {

    public delegate void MyDelegate();
    public delegate void MyDelegate1(int a);
    public delegate void MyDelegate2(int a, int b);

    public delegate int MyDelegate3();
    public delegate int MyDelegate4(int a);
    public delegate int MyDelegate5(int a, int b);
    internal class Program {
        static void Main(string[] args) {

            MyDelegate myDelegate = new MyDelegate(ProgramMothod);
            myDelegate();
            MyDelegate1 myDelegate1 = new MyDelegate1(ProgramMothod1);
            myDelegate1(1);
            MyDelegate2 myDelegate2 = new MyDelegate2(ProgramMothod2);
            myDelegate2(1, 2);

            MyDelegate3 myDelegate3 = new MyDelegate3(ProgramMothod3);
            Console.WriteLine(myDelegate3());
            MyDelegate4 myDelegate4 = new MyDelegate4(ProgramMothod4);
            Console.WriteLine(myDelegate4(1));
            MyDelegate5 myDelegate5 = new MyDelegate5(ProgramMothod5);
            Console.WriteLine(myDelegate5(1, 1));
            //使用 Action和Func委托

            //Action
            // Action委托表示一个void返回类型的方法
            Action action = new Action(myDelegate);
            action();

            Action<int> action1 = new Action<int>(ProgramMothod1);
            action1(1);

            Action<int, int> action2 = new Action<int, int>(ProgramMothod2);
            action2(1, 2);


            //Func
            //Func委托表示一个带返回类型的方法

            //返回类型放在<> 最后一个。

            Func<int> func = new Func<int>(ProgramMothod3);
            Console.WriteLine(func());

            Func<int, int> func1 = new Func<int, int>(ProgramMothod4);

            Console.WriteLine(func1(1));

            Func<int, int, int> func2 = new Func<int, int, int>(ProgramMothod5);
            Console.WriteLine(func2(1, 2));
        }


        public static void ProgramMothod() {

            Console.WriteLine("ProgramMothod");
        }

        public static void ProgramMothod1(int a) {

            Console.WriteLine("ProgramMothod1");
        }
        public static void ProgramMothod2(int a, int b) {

            Console.WriteLine("ProgramMothod2");
        }

        public static int ProgramMothod3() {

            Console.WriteLine("ProgramMothod3");
            return 1;
        }


        public static int ProgramMothod4(int a) {

            Console.WriteLine("ProgramMothod5");
            return 1;
        }
        public static int ProgramMothod5(int a, int b) {

            Console.WriteLine("ProgramMothod5");
            return 1;
        }
    }
}
