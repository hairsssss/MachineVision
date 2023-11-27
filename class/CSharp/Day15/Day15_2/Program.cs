using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_2 {
    internal class Program {
        static void Main(string[] args) {
            //枚举是描述一组整数值的结构  使数字更具有具体意义
            //枚举是值类型  
            //枚举类型使用 enum 关键字声明的
            //枚举是一组整型常量 默认是从 0开始  也可以自己定义范围
            //枚举本身可以有修饰符，但枚举的成员始终是公共的，
            //不能有访问修饰符，枚举本身的修饰符仅能使用public和internal
            //枚举都是隐式密封的，不允许作为基类派生子类


            //
            int a = 1;
            MyEnum myEnum = MyEnum.chi;
            myEnum = MyEnum.he;
            switch (myEnum) {
                case MyEnum.chi: {

                        Console.WriteLine("chi");

                    }
                    break;
                case MyEnum.he: {

                        Console.WriteLine("he");
                    }
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }

    public enum MyEnum {
        chi = 1,
        he = 2,
        shui = 3,
        wan = 4,
        xuexi = 5

    }

    public enum MyEnum1 {

        //默认从0
        chi1,
        he1,
        shui1,
        wan1,
        xuexi1

    }
    public enum MyEnum2 {
        chi2 = 10,
        he2 = 100,
        shui2,
        wan2 = 333,
        xuexi2

    }
    public class People {
        public enum MyEnum2 {
            chi2 = 10,
            he2 = 100,
            shui2,
            wan2 = 333,
            xuexi2

        }



        public void Test() {

            MyEnum2 myEnum = MyEnum2.chi2;
            myEnum = MyEnum2.he2;
            switch (myEnum) {
                case MyEnum2.chi2: {

                        Console.WriteLine("chi");

                    }
                    break;
                case MyEnum2.he2: {

                        Console.WriteLine("he");
                    }
                    break;
                default:
                    break;
            }


        }
    }
}
