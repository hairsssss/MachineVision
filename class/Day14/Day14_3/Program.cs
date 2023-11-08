using System;

namespace Day14_3 {
    internal class Program {
        static void Main(string[] args) {

            //泛型中的数据约束可以指定泛型类型的范围  (泛型约束)

            /*
 泛型约束总共有五种。
约束 	说明
T：结构  类型参数必须是值类型
T：类 	类型参数必须是引用类型；这一点也适用于任何类、接口、委托或数组类型。
T：new() 	类型参数必须具有无参数的公共构造函数。 当与其他约束一起使用时，new() 约束必须最后指定。
T：<基类名> 	类型参数必须是指定的基类或派生自指定的基类。
T：<接口名称> 	类型参数必须是指定的接口或实现指定的接口。 可以指定多个接口约束。 约束接口也可以是泛型的。
             */


            //People<int,string,MyClass,string,MyClass1> people = new People<int,string,MyClass,string,MyClass1>();
            //people.value = 1;

            // People<float> people2 = new People<float>();
            // people2.value = 2;
            //People<string> people1 = new People<string>();
            //people1.value = "123";

            MyClass1 myClass1 = new MyClass1();
            Console.WriteLine(myClass1.TestMotho<string>());
            Console.ReadKey();

        }



    }
    public class People<T, K, V, W, D, X, G> where T : struct        //约束 T 必须是值类型  
                              where K : class         //约束 K 必须是引用类型
                              where V : IMyInterface    //约束 V 必须实现 IFace 接口  
                              where W : K             //约束 W 必须是 K 类型，或者是 K 类型的子类 
                              where D : MyClass       //约束 D 必须是 MyClass 类型，或者是 MyClass类型的子类 
                              where X : class, new()   //约束 X 必须是引用类型，并且有一个无参数的构造函数，当有多个约束时，new()必须写在最后
                              where G : class, IMyInterface, new() {

        public T value { get; set; }

    }


    public interface IMyInterface {

        void IMyInterfaceMothod();


    }

    public class MyClass : IMyInterface {

        public void IMyInterfaceMothod() {


        }
    }

    public class MyClass1 : MyClass {



        public string MyClass1Mothod(string a) {


            if (a == "123") {

                return a;
            } else {
                return null;
            }

        }

        public int MyClass1Mothod(int a) {


            if (a == 123) {

                return a;
            } else {
                return 0;
            }

        }


        public T TestMotho<T>() {

            T a = default(T);
            return a;
        }
    }

    //5.泛型默认值问题 需要用   default()方法
}
