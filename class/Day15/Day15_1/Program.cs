using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_1 {
    internal class Program {
        static void Main(string[] args) {

            //C# 结构体（Struct）
            //1.结构体是值类型数据结构。
            //2.引用类型派生自 System.Object ，而值类型均隐式派生自 System.ValueType
            //3.struct 关键字用于创建结构体
            //4.结构可带有方法、字段、属性、运算符，委托和事件。
            //5.结构可实现一个或多个接口  但是不能继承其他类
            //6.结构不支持被其他类继承。
            //7.结构成员不能指定为virtual 或 protected、
            //8.结构可以使用 New 创建对象 也可以不使用 ，如果结构中有属性 必须使用new 创建对象
            // 数值类型


            /*
             类和结构总结：

         1. 类和结构实际上都是创建对象的模板， 每个对象都包含数据，并提供了处理和访问数据的方法
           2. 类是引用类型 对象存于堆中 可以通过GC管理内存   结构是值类型 对象存于栈中  、
           3  结构不能被继承  也不能继承其他类  但是能继承接口
           4. 结构和类 都能使用new 创建对象   但是结构也可以不使用
           5. 结构作为方法参数 默认是值传递   类类型默认是引用传递
             
             */

            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);

            Console.WriteLine(1 is ValueType); // true
                                               // 布尔类型
            Console.WriteLine(true is ValueType); // true


            Console.WriteLine(new Program() is ValueType);
            Console.WriteLine(new Program() is object);

            //创建结构体的对象
            MyStruct myStruct = new MyStruct();

            myStruct.Age = 1;
            //   myStruct1.Age = 20;

            MyStruct1 myStruct1;
            myStruct1._age1 = 1;


            Book book = new Book();
            book.Price = 10;
            Book.Book1 book1;
            book1.Book1ID = 1;
            book.BooklD = book1.Book1ID;
            Console.ReadKey();
        }
    }
    public struct MyStruct1 {

        public int _age1;
        public int Age1 { get; set; }

    }
    public struct MyStruct : IComparable {

        private int _age;
        public int Age { get; set; }
        public void Test() { }
        public MyStruct(int age, int a) {

            _age = age;
            Age = a;

        }

        //实现接口的方法
        public int CompareTo(object obj) {

            return 0;

        }
        //~MyStruct() {   //错误


        //}

    }

    public class Book {
        public int Price { get; set; }
        public void BookMothod() { }

        public int BooklD { get; set; }

        public struct Book1 {
            public int Book1ID;
        }
        public struct Book2 {
            public int Book2ID;
        }
    }

}
