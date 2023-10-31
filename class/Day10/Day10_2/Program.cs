using System;

namespace Day10_2 {
    internal class Program {
        static void Main(string[] args) {

            //创建Person类的对象 zhangsan
            //通过new 关键字 开辟内存空间 为了 zhangsan对象的 实例成员
            Person zhangsan = new Person();
            zhangsan._age = 18;
            zhangsan._weight = 100;
            zhangsan._height = 180;
            zhangsan._sex = true;
            Person._type = "高级动物";
            zhangsan.PersonMothod();
            Person lisi = new Person();
            lisi._age = 20;
            lisi._weight = 200;
            lisi._height = 155;
            lisi._sex = false;
            Person._type = "高级动物123";
            lisi.PersonMothod();


            Console.ReadKey();
        }
    }

    internal class People {

        //静态字段
        private static int _id;
        // 非静态字段（实例字段）
        private int _count;
        public static void PeopleStaticMothod() {

            //用类名调用（可以省略）
            People._id = 100;
            //用类的对象调用
            People p = new People();
            p._count = 200;
        }


        public void PeopleStaticMothod1() {

            //用类名调用（可以省略）
            People._id = 100;
            //用类的对象调用
            this._count = 200;
        }

    }


    internal class Person {

        public int _age;
        public double _weight;
        public double _height;
        public bool _sex;

        //静态字段属于类
        public static string _type;

        public void PersonMothod() {

            Console.WriteLine(_age);
            Console.WriteLine(_weight);
            Console.WriteLine(_height);
            Console.WriteLine(_sex);
            Console.WriteLine(_type);
        }


    }
}
