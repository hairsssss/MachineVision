using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_5 {

    public delegate void MyDelegate();
    public delegate void MyDelegate1(int a, int b);
    public delegate int MyDelegate2(int a, int b);

    public delegate void MyDelegate3(int a, int b, MyDelegate myDelegate);
    internal class Program {
        static void Main(string[] args) {
            People people = new People();
            MyDelegate myDelegate = new MyDelegate(ProgramMothod);
            people.PeopleMothod(1, people, myDelegate);
            MyDelegate1 myDelegate1 = new MyDelegate1(ProgramMothod1);
            people.PeopleMothod1(myDelegate1, 10, 20);


            MyDelegate2 myDelegate2 = new MyDelegate2(ProgramMothod2);
            Console.WriteLine(people.PeopleMothod2(myDelegate2, 30, 50));
            Console.ReadKey();

        }

        public static void ProgramMothod() {


            Console.WriteLine("ProgramMothod");
        }
        public static void ProgramMothod1(int a, int b) {
            Console.WriteLine(a + b);
        }

        public static int ProgramMothod2(int a, int b) {
            return a + b;
        }
    }

    public class People {

        private int _age;
        public void PeopleMothod(int a, People p, MyDelegate myDelegate) {

            Console.WriteLine(a);
            Console.WriteLine(p._age);
            myDelegate();

        }

        public void PeopleMothod1(MyDelegate1 myDelegate1, int a, int b) {


            myDelegate1(a, b);

        }


        public int PeopleMothod2(MyDelegate2 myDelegate2, int a, int b) {

            return myDelegate2(a, b);

        }


        public void PeopleMothod3(MyDelegate3 myDelegate3, int a, int b, MyDelegate myDelegate) {

            myDelegate3(a, b, myDelegate);

        }


    }
}
