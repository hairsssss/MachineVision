using System;

namespace Day12_2 {
    internal class Program {
        static void Main(string[] args) {

            People people = new People();

            //   Man man = new Man(10);

            Boy boy = new Boy();

            Boy boy1 = new Boy(10);
            boy.MothodTest();
            Console.ReadKey();

        }
    }

    internal class People {

        public People() {

            Console.WriteLine(" People构造函数");

        }

    }
    internal class Man : People {

        public int ManID { get; set; }
        //必须提供无参构造函数 
        public Man() {

            Console.WriteLine("Man构造函数");
        }
        public Man(int manID123) {
            ManID = manID123;
            Console.WriteLine("Man构造函数有参");
        }

        public void MothodTest() {

            Console.WriteLine("Man中的MothodTest");

        }
    }


    internal class Boy : Man {

        public Boy() { }
        public Boy(int manID) : base(manID) {
            ManID = manID;
        }

        public void MothodTest() {

            //实现父类的功能调用
            base.MothodTest();
            //实现子类的功能扩展
            Console.WriteLine("Boy中的MothodTest");

        }
    }
}

