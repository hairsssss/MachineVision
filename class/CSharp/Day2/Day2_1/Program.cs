using System;
// namespace 命名空间 Day2_1名称
// 命名空间和类的关系
// 1.命名空间包含类
// 2.同一个命名空间中不能定义相同名字的类
// 3.定义多个相同名字的类，可以定义不同命名空间来保存
// 4.命名空间能定义多个相同名字，但是只代表一个
namespace Day2_1 {
    internal class Program {
        static void Main(string[] args) {
            MyClass Class = new MyClass();
            Console.WriteLine(Class.num);

            MyNameSpace.MyClass Class1 = new MyNameSpace.MyClass();
            Console.WriteLine(Class1.num);

            Class1 Class2 = new Class1();
            Console.WriteLine(Class2.num);

            MyClass1 Class3 = new MyClass1();
            Console.WriteLine(Class3.num);


        }
    }
    internal class MyClass {
        public int num = 99;
    }
}
namespace MyNameSpace {
    internal class MyClass {
        public int num = 100;
    }
}
namespace Day2_1 {
    internal class MyClass1 {
        public int num = 101;
    }
}
namespace System1 {
    internal class MyClass11 {

    }
}
namespace System1.I0 {
    internal class MyClass11 {
        private int _a;
        public int A { get { return _a; } set { _a = value; } }
        //类
        //含义:类也是C#组织代码的方式 通常来管理具体数据的方式
        /*分类：系统类 和自定义类
         * 关键字：class
         * 特点 : 类要放在命名空间中
         * 包含:字段 属性  方法 构造函数 析构函数 事件 等..*/
    }
}