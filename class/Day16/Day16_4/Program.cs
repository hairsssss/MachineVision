using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_4 {

    public delegate void MyDelegate();
    public delegate int MyDelegate1(int a, int b);
    public delegate T MyDelegate2<T>(T a, T b);
    internal class Program {
        static void Main(string[] args) {

            //  普通匿名函数
            //1.针对委托的使用
            //2.可以快捷的使委托实例化。
            //3.不建议再使用匿名函数，C#3.0后使用lambda表达式替代匿名函数

            MyDelegate myDelegate = delegate () { Console.WriteLine("11111"); };
            MyDelegate myDelegate1 = delegate () { Console.WriteLine("22222"); };

            MyDelegate1 myDelegate11 = delegate (int a, int b) { return a + b; };
            MyDelegate2<string> myDelegate2 = delegate (string a, string b) { return a + b; };

            myDelegate();
            myDelegate1();
            Console.WriteLine(myDelegate11(1, 2));
            Console.WriteLine(myDelegate2("1", "2"));


            //            lambda表达式
            //1.普通匿名函数的升级版本  （箭头函数）
            //2.比普通匿名函数更为简洁,数据类型可以不用写
            MyDelegate myDelegate3 = () => { Console.WriteLine("33333"); };
            MyDelegate1 myDelegate12 = (int a, int b) => { return a + b; };
            MyDelegate1 myDelegate13 = (a, b) => { return a + b; };
            MyDelegate2<string> myDelegate21 = (a, b) => { return a + b; };

            Action action = () => { Console.WriteLine("444444"); };
            //一个参数 可以省略（）
            Action<int> action1 = a => { Console.WriteLine("55555"); };

            Action<int, string> action2 = (a, b) => { Console.WriteLine("66666"); };

            Func<int> func = () => { return 1; };
            Func<int, string> func1 = (a) => { return "123"; };

        }



    }


}
