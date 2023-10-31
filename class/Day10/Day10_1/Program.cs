using System;

namespace Day10_1 {
    internal class Program {
        //在一个类中定义另一个类
        internal class ProgramSub {


        }
        static void Main(string[] args) {

            //面向对象编程 
            //程序很好的“模块化设计“，清晰的“分层组合”，方便的“业务扩展”
            //类与对象
            //是面向对象编程的具体实现方式


            //类的定义 
            //1.访问权限  默认访问权限为internal
            //2.static  abstarct ..... 对与类的特殊使用的关键字
            //3.关键字 class
            //4.类名   大驼峰命名
            //5.{}  类的作用域    包含 类的成员 (成员变量 和成员函数)
            //6. 一般类在命名空间中定义   也可以在一个类中定义另一个类
            People people = new People();
            people.PeopleMothod();

            people.PeopleMothod1();

            people.PeopleMothod3();
            people.PeopleMothod2();

            Console.ReadKey();

        }
    }

    //在命名空间中定义的类 
    internal class People {


        //成员变量 （字段）
        //（1）字段是类型的成员，也称为成员变量 在类中字段也可以叫全局变量 在整个类中可以使用
        //（2）字段是定义在类中方法之外的 局部变量是定义在方法内部的
        // (3) 字段的格式: 访问修饰符(默认访问修饰符 private ) 数据类型  字段名
        // (4) 字段是有默认值的  值类型默认值为 0  引用类型默认值为null  局部变量没有默认值
        //(5) 字段的类型为值类型和字符串类型 使用时是深拷贝（会克隆）  其他的引用类型 默认是浅拷贝（不克隆 给原值）
        //(6) 字段的访问修饰符  学过的修饰符字段都能使用
        //(7) 在一个类中 不能重复定义字段  但是允许定义相同名字的字段和局部变量   使用规则：就近原则
        //(8) 字段的命名规则  _+小驼峰  保持和系统框架中的字段名字一致
        //(9) 字段包含 静态字段和非静态字段（实例字段）
        //（10） const描述的字段 不能使用staitc  原因 const描述的字段 本质就是包含静态的含义
        //(11)  readonly描述的字段  可以使用staitc  可以在定义字段时赋值或者在其构造函数中赋值
        //(12) 一般使用字段时 都使用private的   为了内部的字段不暴漏给其他类
        //但是使用private后 字段的灵活消失  ，使用类的成员-属性 来解决 字段灵活性的问题
        //实例字段 随着new对象的创建而创建
        //静态字段 在类加载的时候创建 且创建一次


        //全局变量  字段
        int b;

        string str;
        string str1;
        float f = 1.1f;
        int[] intArray = new int[3] { 1, 2, 3 };
        int[] intArray1 = new int[3];

        private int inta;
        public int intb;
        internal int intc;
        protected int intd;
        protected internal int inte;
        private protected int intf;

        private int _age;


        private static int _bge;

        public void PeopleMothod() {
            //局部变量
            int a;
            //  Console.WriteLine(a);

            Console.WriteLine(b);
            Console.WriteLine(str);
            Console.WriteLine(f);
            Console.WriteLine(intArray);

            b = 200;
            char[] charArray = new char[3] { 'a', 'b', 'c', };
            str = new string(charArray);
            Console.WriteLine(str);
            Console.WriteLine(str1);
            str1 = str;
            Console.WriteLine(str);
            Console.WriteLine(str1);
            char[] charArray1 = new char[3] { 'c', 'b', 'a', };
            str1 = new string(charArray1);
            Console.WriteLine(str);
            Console.WriteLine(str1);

            //字段的赋值
            // b = 2;
            //浅拷贝
            //     intArray1 = intArray;
            //数组深拷贝
            intArray.CopyTo(intArray1, 0);
            intArray1[0] = 10;


            foreach (var item in intArray1) {
                Console.WriteLine(item);
            }

            foreach (var item in intArray) {
                Console.WriteLine(item);
            }




        }



        public void PeopleMothod1() {
            //a不存在  找不到PeopleMothod的 a的定义 

            // a = 10;
            //字段的赋值


            Console.WriteLine(b);
            Console.WriteLine(str);
            Console.WriteLine(f);
            Console.WriteLine(intArray);


            foreach (var item in intArray) {
                Console.WriteLine(item);
            }
        }


        public void PeopleMothod2() {

            Console.WriteLine(inta);

        }


        public void PeopleMothod3() {

            int inta;
            inta = 100;
            Console.WriteLine(inta);

        }
    }
}
