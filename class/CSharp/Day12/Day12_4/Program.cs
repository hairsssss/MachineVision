using System;

namespace Day12_4 {
    internal class Program {
        static void Main(string[] args) {

            //重写：
            //1.在子类和父类中，子类中的方法名称和父类方法名称相同，参数相同  
            //2.使用关键字 virtual，将父类的方法标记为虚方法（父类允许子类覆盖方法的标签）
            //用 override  关键字，虚方法可以被子类重写
            //3.重写是合法的覆盖
            //4.重写和覆盖为了扩展父类的功能
            //5.重写必须和父类中的方法一样（参数 方法名 访问权限 返回值类型）



            //重写和重载和覆盖

            //1.重写是合法的覆盖
            //2.重载可以在本类和子类中实现    重写只能在继承关系中实现
            //3.重载和重写方法名字要相同  ,重载的参数的类型和个数和顺序要不一样  重载的访问权限和返回值类型和静态非静态无关，
            //重写必须和父类中的方法一样（参数 方法名 访问权限 返回值类型）
            //4.重写和重载都是多态的体现
            Man man = new Man();
            man.PeopleMothod(1, 1);
            man.PeopleMothod1();


            Person person = new Person();
            person.ToString();


            Person2 person2 = new Person2(1, 2);

            Console.ReadKey();
        }
    }

    public class People {

        public virtual void PeopleMothod(int a, int b) {

            Console.WriteLine("11111");
        }

        public void PeopleMothod1() {

            Console.WriteLine("3333");

        }

        public virtual void PeopleMothod2() {

            Console.WriteLine("44444444");
        }


    }
    public class Man : People {

        public override void PeopleMothod(int a, int b) {

            Console.WriteLine("22222");
        }


        public void PeopleMothod1() {

            Console.WriteLine("4444");

        }


        public override void PeopleMothod2() {
            base.PeopleMothod2();
            Console.WriteLine("44444444");

        }

    }

    public class Person : Object {

        public override string ToString() {
            Console.WriteLine("重写父类的toString方法");
            return GetType().ToString();
        }

    }


    public class Person2 {

        private int _a;
        private int _b;

        public Person2() {

            Console.WriteLine("1");
        }
        //构造函数的重载
        public Person2(int a, int b) {

            if (a < 10) {

                _a = 10;
            } else {

                _a = a;
            }

            _b = b;
        }
    }
}
