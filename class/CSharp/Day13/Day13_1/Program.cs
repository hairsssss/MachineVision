using System;

namespace Day13_1 {
    internal class Program {
        static void Main(string[] args) {


            //接口
            //1.含义：​ 接口定义了所有类继承接口时应遵循的语法合同  与抽象类中的抽象成员相似
            //2.接口使用 interface 关键字声明，它与类的声明类似。
            //3.接口声明默认是 public 的​  名字一般使用大写I开头
            //4.接口中只能包含方法、属性、索引器和事件的声明（定义） 不能动议字段
            //5.不允许声明成员上的修饰符，即使是pubilc都不行，因为接口成员总是公有的
            //6.也不能声明为虚拟和静态的。如果需要修饰符，最好让实现类来声明。
            //7.接口中定义的成员 需要类继承 来进行实现   如果类是隐式继承   继承接口时 直接在：后写 接口名
            // 是显式继承 在父类的后面 以逗号分割 写接口名
            //8.类必须实现继承接口的成员
            //9.一个类 可以继承多个接口  （接口就是c#实现多继承的方式）
            //10.接口也可以继承接口
            //11.抽象类可以继承接口 但是还要普通类继承抽象类     静态类不能继承接口


            //接口和抽象类区别
            //相同点: 不能实例对象    都可以被继承   都可以给继承类提供成员模板

            // 不同点：接口只能有实例成员定义 抽象类 也可以包含普通成员的实现 也可以包含抽象成员
            // 接口可以实现多继承 抽象类只能单继承



            MyClass111 myClass111 = new MyClass111(30);

            MyClass111 myClass112 = new MyClass111(20);

            int number = myClass111.CompareTo(myClass112);
            Console.WriteLine(number);
            Console.ReadKey();
        }
    }
    public abstract class MyClass {
        public void aaa() {

            Console.WriteLine("12313");
        }

        public abstract void bbb();

        //   public static int Bag { get; set; }
    }






    public interface IInterfaceTest : IInterfaceTest2 {

        //属性
        int Age { get; set; }

        int Bag { get; set; }
        //方法
        void Eat();
    }
    public interface IInterfaceTest1 {

        //属性
        int Age1 { get; set; }

        int Bag1 { get; set; }
        //方法
        void Eat1();
    }
    public interface IInterfaceTest2 {

        //属性
        int Age2 { get; set; }

        int Bag2 { get; set; }
        //方法
        void Eat2();
    }
    public class People {

        public string Name { get; set; }
    }


    public class Man : People, IInterfaceTest, IInterfaceTest1 {

        //属性
        public int Age { get; set; }

        public int Bag { get; set; }
        //方法
        public void Eat() {


        }


        //属性
        public int Age1 { get; set; }

        public int Bag1 { get; set; }
        //方法
        public void Eat1() {



        }


        //属性
        public int Age2 { get; set; }

        public int Bag2 { get; set; }
        //方法
        public void Eat2() {


        }

    }



    public abstract class ABClass : IInterfaceTest1 {


        public abstract int Age111 { get; set; }
        //属性
        public int Age1 { get; set; }

        public int Bag1 { get; set; }
        //方法
        public void Eat1() {



        }

    }


    public class ABClassSub : ABClass {
        public override int Age111 { get; set; }



    }

    public class MyClass111 : IComparable {

        private int _age;
        public MyClass111(int age) {

            _age = age;
        }
        public int CompareTo(object obj) {

            //  this._age 

            //   MyClass111 tempMyClass = (MyClass111)obj;
            MyClass111 tempMyClass = obj as MyClass111;

            if (this._age == tempMyClass._age) {
                return 1;
            } else if (this._age < tempMyClass._age) {

                return 2;
            } else {

                return 3;

            }

        }
    }
}