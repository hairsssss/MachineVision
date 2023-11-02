using System;

namespace Day12_1 {
    internal class Program {
        static void Main(string[] args) {


            People people = new People();
            people.Age = 10;
            people._name = "name";
            people.PeopleMothod();
            people._name3 = "name";


            people.ToString();
            // people._name4 = "name";
            People._name1 = "name";
            Man man = new Man();
            man.Age = 20;
            man._name = "name1";
            man.PeopleMothod();
            man._name3 = "name";

            Woman woman = new Woman();
            woman.Age = 20;
            Boy boy = new Boy();
            boy.ManMothod();
            boy.Age = 20;
            smallBoy smallBoy = new smallBoy();
            smallBoy.Age = 20;

            smallBoy.ToString();




            // 
            Man man1 = new Man();
            Console.ReadKey();
        }
    }
    /*
       1.一个类继承另一个类  其中被继承的类（父类 超类 基类）  继承的类（子类 派生类）
       2.继承的格式  A类(子类) : B类(父类)  
       3.继承关系建立后  子类拥有父类的成员  反之父类不继承子类成员。 父类私有成员 子类无法使用  
       4.C#中类与类之间是单继承关系(子类只能同时继承一个父类)   利用接口实现多继承（后续讲） 
       5.一个父类可以同时被多个子类继承    子类可以间接继承父类  
       6.object是所有类的父类   如果一个类 没有明确继承关系   默认继承于object类
       7.创建子类对象时，系统默认先调用父类构造方法，然后再调用子类构造方法
       8.当父类有有参构造方法时.必须提供一个无参构造函数 供子类调用
       9.子类在调用其有参或者无参构造函数时，默认调用父类的 无参构造函数
       如果想要调用父类有参构造函数  使用在子类构造函数后添加:base(参数名)
     */


    internal class People {
        public string _name;

        private string _name2;

        internal string _name3;
        protected string _name4;
        public int Age { get; set; }

        public void PeopleMothod() {

            Console.WriteLine("123");
            _name2 = "name";
        }

        public static string _name1;


        public People() {

            Console.WriteLine("People的构造函数");
        }

    }

    internal class Man : People {

        public void ManMothod() {

            // _name2 = "111";
            _name4 = "name";

        }
    }

    internal class Woman : People {

    }

    internal class Boy : Man {



    }

    internal class smallBoy : Boy {


    }
}
