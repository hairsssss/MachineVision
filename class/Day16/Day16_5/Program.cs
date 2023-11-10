using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_5 {
    internal class Program {
        static void Main(string[] args) {

            /*
             
             运算符重载
1.含义

  是对已有的运算符重新定义新的运算规则，以适应不同的数据类型

            特点：
              1.运算符重载的声明方式：operator 关键字
              2.必须用public修饰且必须是类的静态的方法
              3.重载运算符的方法 不用主动调用 只要使用重载的运算符就相当调用了方法
              4.运算符只能采用值参数，不能采用ref或out参数
              5.重载运算符的返回值不一定必须是自己，但一定不能是void
             */

            int a = 1;
            int b = 2;
            Console.WriteLine(a + b);
            string a1 = "1";
            string b1 = "2";
            Console.WriteLine(a1 + b1);


            People p = new People();
            p.Name = "zhangsan";
            p.ID = 1;
            People p1 = new People();
            p1.Name = "lisi";
            p1.ID = 2;
            People p3 = p1 + p;

            Console.WriteLine(p3.ID);
            Console.WriteLine(p3.Name);
            //隐式重载
            p1 += p;
            Console.WriteLine(p1.ID);


            p++;
            Console.WriteLine(p.ID);
            Console.WriteLine(p == p1);
            Console.ReadKey();
        }
    }

    public class People {

        public int ID { get; set; }
        public string Name { get; set; }
        //重载 +号运算符
        public static People operator +(People stu1, People stu2) {
            return new People() { ID = stu1.ID + stu2.ID, Name = stu1.Name + stu2.Name };
        }


        public static bool operator ==(People stu1, People stu2) {
            if (stu1.ID == stu2.ID && stu2.Name == stu1.Name) {
                return true;
            } else {

                return false;
            }
        }
        public static bool operator !=(People stu1, People stu2) {
            if (stu1.ID == stu2.ID && stu2.Name == stu1.Name) {
                return false;
            } else {

                return true;
            }
        }



        public static People operator ++(People stu1) {
            stu1.ID++;
            return stu1;
        }
    }

}
