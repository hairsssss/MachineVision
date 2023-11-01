using System;

namespace Day11__3 {
    internal class Program {
        static void Main(string[] args) {

            //静态类 
            //1.使用static描述的类 
            //2.不能创建实例对象 也不能定义实例成员  只能定义静态相关成员
            //3.制作工具类时  可以使用
            //4.私有构造函数  限制了外部创建对象   静态类任何地方无法创建对象 没有提供实例构造函数 有静态构造函数
            //5.静态类 无法被继承


            StaticClass.Sum(1, 2);


            //
            People zhangsan = new People();
            zhangsan = null;
            //强制开启回收
            GC.Collect();
            Console.ReadKey();
        }
    }

    public static class StaticClass {

        private static int _age;

        public static int Age { get { return _age; } set { _age = value; } }
        public static void StaticClassMothod() { }


        //求和
        public static void Sum(int a, int b) {

            Console.WriteLine(a + b);
        }



        //静态构造函数
        static StaticClass() {

        }


    }




    internal class People {

        // 析构函数：
        //1.垃圾回收程序最终销毁对象之前调用的方法，该方法称为析构函数
        //2.构造函数是成对出现  一个负责创建对象  一个负责销毁对象
        //3.析构函数通常形式如下: ~类名(){}
        //4.类默认自带析构函数
        //5.析构函数没有返回值，且不带任何参数。
        //构造函数
        public People() {

            Console.WriteLine("对象被创建");
        }
        //析构函数
        ~People() {

            Console.WriteLine("对象被销毁");

        }
    }
}
