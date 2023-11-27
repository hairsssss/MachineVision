using System;

namespace Day12_5 {
    internal class Program {
        static void Main(string[] args) {
            People people = new People(10);

            Console.WriteLine(people.Id);

            People people1 = new People(20);
            Console.WriteLine(people1.Id);

            //People.PeopleMothod1(people);
            //Console.WriteLine(people.Id);
            Console.ReadKey();

        }
        public void aaa() {
            this.aaa();
        }



    }

    public class People {

        private int _id;
        public int Id { get; set; }

        public People() {


        }

        public People(int id) {
            //this
            // 代表当前类的对象
            //this关键字只能在实例构造函数、实例方法或实例访问器中使用

            /*
             base
    base关键字用于从派生类中访问基类的成员；
    派生类对象调用基类构造函数；
    调用基类上已被重写的方法
    不能从静态方法中使用base关键字，base关键字只能在实例构造函数、实例方法或实例访问器中使用
             
             */
            this.Id = id;
            this.PeopleMothod();
        }
        public void PeopleMothod() {

            this.Id = 100;
            this._id = 1000;
            Console.WriteLine("PeopleMothod");

        }
        //静态成员方法中不能使用this关键字
        public static void PeopleMothod1(People p) {
            p.Id = 200;
            Console.WriteLine("PeopleMothod");

        }

    }
}
