using System;

namespace Day11_2 {
    internal class Program {
        static void Main(string[] args) {

            People zhangsan = new People();
            zhangsan.Name = "张三";
            zhangsan.Eat();
            People lisi = new People();
            lisi.Name = "李四";
            lisi.Eat();


            People.PeopleStaicMothod();

            People.PeopleStaicMothod1(zhangsan);
            People.PeopleStaicMothod1(lisi);


            //构造函数  
            //1.本质就是方法
            //2.作用 类创建对象时 使用的特殊方法
            //3.类默认存在构造函数   
            //4.构造函数的名字 一定要和类名相同
            //5.构造函数分为实例构造函数、私有构造函数和静态构造函数 
            //6.构造函数没有返回类型,它可以带参数,也可以不带参数
            //7.构造函数自己定义时，会覆盖系统默认的    自己定义构造函数 原因：系统默认的功能无法满足需求
            //8.实例构造一般使用public
            //9.私有构造函数使用private  不希望其他类 创建自身的对象时  （没有实例成员时）
            //10.静态构造函数  默认系统会自带   在类创建时 用来初始化 所有的 静态成员   
            //11.静态构造函数既没有访问修饰符，也没有参数
            //12..无参数的实例构造函数可以与静态构造函数共存。尽管参数列表相同，但一个属于类，
            //一个属于实例，所以不会冲突
            Person person1 = new Person(10, "zhangsan");
            //person1.Id = 10;
            //person1.Name = "zhangsan";
            Console.WriteLine(person1.Id);
            Console.WriteLine(person1.Name);

            Person person2 = new Person(20, "lisi");
            Console.WriteLine(person2.Id);
            Console.WriteLine(person2.Name);

            Person person3 = new Person();
            person3.Id = 30;
            person3.Name = "wangwu";

            Console.WriteLine(person3.readonlyNumber);
            Console.WriteLine(person3.readonlyNumber1);


            Person2.ID = 1000;
            Person2.Person2Mothod();
            Console.ReadKey();
        }
    }

    internal class People {
        //字段
        private int _age;
        //属性
        public int Age { get { return _age; } }
        public string Name { get; set; }
        //方法   
        public void Eat() {

            Console.WriteLine($"{Name}吃饱了");
        }

        public static void PeopleStaicMothod() {

            Console.WriteLine("人会死亡");

        }
        public static void PeopleStaicMothod1(People p) {
            Console.WriteLine($"{p.Name}会死亡");
        }
    }


    internal class Person {
        public int Id { get; set; }
        public string Name { get; set; }

        public readonly int readonlyNumber = 100;
        public readonly int readonlyNumber1;
        //实例构造函数
        public Person() {
            readonlyNumber1 = 200;
            Console.WriteLine("Person构造函数");
        }

        public Person(int id, string name) {
            Name = name;
            Id = id;
        }
    }


    internal class Person2 {
        //私有构造函数
        private Person2() {
        }
        public static int ID { get; set; }
        public static void Person2Mothod() {

            Console.WriteLine("Person2Mothod");
        }


        //静态构造函数
        static Person2() {

            Console.WriteLine("静态构造函数调用");

        }

    }
}
