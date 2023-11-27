using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_3 {

    internal class Program {
        //定义委托 无返回值无参数的委托类型(包含静态和非静态)
        delegate void PeopleDelegate();
        //无返回值有一个参数类型为int的委托类型
        delegate void PeopleDelegate1(int a);
        delegate void PeopleDelegate11(string a);
        delegate void PeopleDelegate111(float a);

        delegate void PeopleDelegate1111<T>(T a);
        //有返回值类型为string无参数的委托类型
        delegate string PeopleDelegate2();
        delegate int PeopleDelegate3(int a, string b);
        delegate T PeopleDelegate33<T, V>(T a, V b);


        delegate int PeopleDelegate4(int a, string b, params int[] intArray);



        public static string ProgramMothod2(string a, int b) {

            return a + b;
        }

        public static float ProgramMothod3(float a, string b) {
            return a;
        }
        public static string ProgramMothod() {

            return "anc";
        }
        public static void ProgramMothod1(int a) {

            Console.WriteLine(a);
        }
        public static void ProgramMothod11(string a) {

            Console.WriteLine(a);
        }
        public static void ProgramMothod111(float a) {

            Console.WriteLine(a);
        }
        public static void aaa() {
            Console.WriteLine("aaa");
        }

        public static void bbb() {
            Console.WriteLine("bbb");
        }

        static void Main(string[] args) {



            //定义委托对象  peopleDelegate    初始化PeopleDelegate的对象 并且把 aaa方法委托给peopleDelegate
            PeopleDelegate peopleDelegate = new PeopleDelegate(aaa);
            aaa();
            peopleDelegate();

            PeopleDelegate peopleDelegate1 = new PeopleDelegate(bbb);
            peopleDelegate1();


            PeopleDelegate2 peopleDelegate2 = new PeopleDelegate2(ProgramMothod);

            peopleDelegate2();

            PeopleDelegate1 peopleDelegate11 = new PeopleDelegate1(ProgramMothod1);

            PeopleDelegate11 peopleDelegate111 = new PeopleDelegate11(ProgramMothod11);

            PeopleDelegate111 peopleDelegate1111 = new PeopleDelegate111(ProgramMothod111);



            PeopleDelegate1111<int> peopleDelegate11111 = new PeopleDelegate1111<int>(ProgramMothod1);
            PeopleDelegate1111<string> peopleDelegate11112 = new PeopleDelegate1111<string>(ProgramMothod11);
            PeopleDelegate1111<float> peopleDelegate11113 = new PeopleDelegate1111<float>(ProgramMothod111);

            PeopleDelegate33<string, int> peopleDelegate33 = new PeopleDelegate33<string, int>(ProgramMothod2);

            PeopleDelegate33<float, string> peopleDelegate331 = new PeopleDelegate33<float, string>(ProgramMothod3);
            Console.ReadKey();

        }

    }





}
