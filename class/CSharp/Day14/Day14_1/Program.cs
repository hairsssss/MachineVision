using System;

namespace Day14_1 {
    internal class Program {
        static void Main(string[] args) {

            //MyClass myClass = new MyClass();
            //myClass.Eat("你好");
            //myClass.Eat(1);
            //myClass.Value = "123";
            //myClass.Value1 = 100;
            //myClass.Value2 = 1000.0d;

            //MyClass1<string> myClass1 = new MyClass1<string>();
            //myClass1.Value = "123";
            //myClass1.Value1 = 10;
            //myClass1.Value2 = 10.0D;


            //Student student = new Student() { Age = 18 };
            //Student student1 = new Student() { Age = 20 };

            //Console.WriteLine(student.CompareTo(student1));




            People p = new People();
            p.Age = 18;

            Man man = new Man();
            man.Age = 20;
            man.Smoke = "123";

            Man man1 = new People() as Man;
            //  man1.Age = 30;
            //   man1.Smoke = "333";


            People p1 = new Man();



            Man man2 = p1 as Man;

            Console.WriteLine(man2.Age);
            Console.WriteLine(man2.Smoke);


            man2.ManMothod(1);
            man2.ManMothod<int>(1);

            Console.ReadKey();

        }


    }

    public interface IMyInterface {

        void Eat(string Test);


    }
    public interface IMyInterface<T> {

        void Eat(T Test);


    }
    public class MyClass : MyClass1<string>, IMyInterface, IMyInterface<int> {

        public void Eat(string Test) {

            Console.WriteLine(Test);

        }
        public void Eat(int Test) {

            Console.WriteLine(Test);
        }
    }


    public class MyClass1<T> : MyClass2<int, double> {


        public T Value { get; set; }

    }

    public class MyClass2<T, A> {


        public T Value1 { get; set; }
        public A Value2 { get; set; }
    }


    public class MyClass3<T> {


        public void MyClass3Mothod() {


        }
        public void MyClass3Mothod(T a) {


        }
        public void MyClass3Mothod(T a, T b) {

            Console.WriteLine();
        }

        //public int  MyClass3Mothod(T a, T b, T c)
        //{
        //    return a + b + c;
        //}




    }
    public class Student : IComparable {

        public int Age { get; set; }

        public int CompareTo(object obj) {

            //  this.Age

            Student student = (Student)obj;
            if (this.Age == student.Age) {


                return 1;
            } else if (this.Age > student.Age) {

                return 2;
            } else {

                return 3;
            }
        }

    }

    public class Student1 : IComparable<Student1> {

        public int Age { get; set; }
        public int CompareTo(Student1 other) {

            if (this.Age == other.Age) {


                return 1;
            } else if (this.Age > other.Age) {

                return 2;
            } else {

                return 3;
            }

        }


        //  this.Age

        //Student student = (Student)obj;
        //if (this.Age == student.Age)
        //{


        //    return 1;
        //}
        //else if (this.Age > student.Age)
        //{

        //    return 2;
        //}
        //else
        //{

        //    return 3;
        //}


    }

    public class People {

        public int Age { get; set; }

    }

    public class Man : People {

        public string Smoke { get; set; }


        public void ManMothod(object obj) {

            Console.WriteLine(obj);

        }

        public void ManMothod<T>(T obj) {


            Console.WriteLine(obj);
        }

    }
}
