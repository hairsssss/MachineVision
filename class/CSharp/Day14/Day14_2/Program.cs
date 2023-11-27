using System;

namespace Day14_2 {
    internal class Program {
        static void Main(string[] args) {

            //            泛型和Object类型的区别

            //值类型转换成引用类型。这个转换称为装箱。相反的过程称为拆箱

            int number = 10;
            // 装箱  
            object obj = number;
            // 拆箱  
            number = (int)obj;

            /*
             Object 类型

> 优点：
> 1. object类型可以用来引用任何类型的实例；
> 2. object类型可以存储任何类型的值；
> 3. 可以定义object类型的参数；
> 4. 可以把object作为返回类型。

> 缺点：
> 1. 会因为程序员没有记住使用的类型而出错，造成类型不兼容；
> 2. 值类型和引用类型的互化即装箱拆箱使系统性能下降
             */
        }


        public object Mothod() {


            return null;

        }


        // 泛型和装箱拆箱 对比
        public void abTest(object a, object b) {

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
        }
        public void abTest<T>(T a, T b) {

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
        }

    }



}
