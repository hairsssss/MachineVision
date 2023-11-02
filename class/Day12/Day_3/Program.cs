using System;

namespace Day12_3 {
    internal class Program {
        static void Main(string[] args) {

            //什么是多态？
            //即一个接口，多个功能 同一种操作作用于不同的对象，可以有不同的解释，产生不同的执行结果

            //重载  
            //1.在一个类中或者子类中函数名相同,参数类型或者顺序不同的方法构成重载,与返回类型 和访问权限无关


            People people = new People();
            people.PeopleMothod();

            Man man = new Man();
            man.PeopleMothod();
        }
    }

    public class People {


        public void PeopleMothod() {

            Console.WriteLine("PeopleMothod1");

        }

        public void PeopleMothod(string a) {
            Console.WriteLine("PeopleMothod2");
        }


        public void PeopleMothod(int b) {

            Console.WriteLine("PeopleMothod3");
        }

        public void PeopleMothod(string a, int b) {

            Console.WriteLine("PeopleMothod4");
        }


        public void PeopleMothod(int b, string a) {

            Console.WriteLine("PeopleMothod5");
        }

        public static void PeopleMothod(int a, int b) {


        }

        private void PeopleMothod(int a, bool b) {

        }

        public int PeopleMothod(bool b) {

            return 1;
        }
    }

    internal class Man : People {


        public void PeopleMothod(int a, int b, int c) {


        }



    }

}
