using System;

namespace Day13_3 {
    internal class Program {
        static void Main(string[] args) {
            /*
              泛型 :
                允许我们延迟编写类或方法中的数据类型， 直到真正使用时确定类型的一种规范
            //1.可以创建自己的泛型接口、泛型类、泛型方法、泛型集合 ，泛型事件和泛型委托
            //2.在定义泛型时T通常用作变量类型名称。但实际上 T 可以用任何有效名称代替 
            
            //3.泛型无法直接使用运算符 比如 + -  <  > 等 但是能使用Object中的属性和方法
             */


            People people = new People();
            people.Id = 10;

            People<string> people1 = new People<string>();
            people1.Id = "张三";

            People<float> people2 = new People<float>();
            people2.Id = 20.0f;
            People<double> people3 = new People<double>();
            people3.Id = 50.9;

            People<People> people4 = new People<People>();
            people4.Id = people;

            People<People<float>> people5 = new People<People<float>>();

            people5.Id = people2;

            People<int, float> people6 = new People<int, float>();

            people6.Id = 10;
            people6.PeopleSum(10.1F, 20.1F);


            People<string, bool> people7 = new People<string, bool>();

            people7.Id = "1111";
            people7.PeopleSum(true, false);




            People people8 = new People();
            people8.PeopleMothod<string>("123", 10);
            people8.PeopleMothod(10, 20);

        }
    }
    //泛型类
    public class People<T> {

        public T Id { get; set; }


        public void PeopleSum(int a, int b) {

            Console.WriteLine(a + b);

        }

    }
    public class People<T, A> {

        public T Id { get; set; }


        public void PeopleSum(A a, A b) {

            string stra = a.ToString();
            string strb = b.ToString();

            Console.WriteLine(strb + stra);

        }

    }

    public class People<T, A, 你> {

        public 你 Id { get; set; }


        public void PeopleSum(A a, A b) {

            string stra = a.ToString();
            string strb = b.ToString();

            Console.WriteLine(strb + stra);

        }

    }
    public class People {

        public int Id { get; set; }

        public void PeopleMothod<T>(T a, int b) {


        }

        public void PeopleMothod(int a, int b) {


        }
    }
}
