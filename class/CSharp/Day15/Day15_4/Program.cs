using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_4 {

    delegate int MyDelegate(int a, int b);
    delegate T MyDelegate1<T>(T a, T b);
    internal class Program {
        //私有的委托类型
        private delegate void ProgramDelegate();
        static void Main(string[] args) {


            ProgramDelegate programDelegate = new ProgramDelegate(People.PeopleMothod);
            People people = new People();
            ProgramDelegate programDelegate1 = new ProgramDelegate(People.PeopleMothod1);


            programDelegate();
            programDelegate1();


            MyDelegate myDelegate = new MyDelegate(people.PeopleMothod2);
            Console.WriteLine(myDelegate(10, 20));


            ProgramDelegate programDelegate2 = new ProgramDelegate(people.PeopleMothod11);
            programDelegate2();

            Console.ReadKey();

        }
    }


    public class People {
        public static void PeopleMothod() {

            Console.WriteLine("PeopleMothod");
        }
        public static void PeopleMothod1() {
            Console.WriteLine("PeopleMothod1");
        }


        public int PeopleMothod2(int a, int b) {

            return a + b;
        }
        public void PeopleMothod11() {
            MyDelegate1<string> myDelegate1 = new MyDelegate1<string>(this.PeopleMothod3);
            Console.WriteLine(myDelegate1("abc", "ggg"));

        }

        public string PeopleMothod3(string a, string b) {

            return a + b;
        }
    }
}
