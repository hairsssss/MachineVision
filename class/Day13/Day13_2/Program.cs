using System;

namespace Day13_2 {
    internal class Program {
        static void Main(string[] args) {

            MyClass myClass = new MyClass();
            myClass.Age = 10;
            MyClass myClass2 = new MyClass(10);
            myClass.MothodTest();

        }
    }
    public sealed class MyClass : SuperMyClass, IMyClass {
        private int _age;
        public int Age { get { return _age; } set { _age = value; } }
        public MyClass() {

            Console.WriteLine("123");
        }

        public MyClass(int age) {

            _age = age;
        }
        private int _bag;
        public int Bge { get { return _bag; } set { _bag = value; } }



        // protected int _test;

        //public virtual void TestMothod1() {

        //    Console.WriteLine("111");
        //}

        // public abstract void Test();


    }

    public class SuperMyClass {

        public void MothodTest() {
            Console.WriteLine("MothodTes");

        }
    }

    public interface IMyClass {

        int Bge { get; set; }
    }
    /*
     密封类 
     1.密封类可以用来限制继承性
     2.声明密封类时需要使用sealed关键字
     3.密封类和普通类一样 都可以定义属性和方法
     4.密封类不能作为基类被继承，但它可以继承别的类或接口
     5.密封类可以实例化对象  系统中String 就是密封类
     6.在密封类中不能声明受保护成员或虚成员
     */
}
