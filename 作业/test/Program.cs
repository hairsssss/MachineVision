using System;

namespace KaoShi_1 {
    internal class Program {
        static void Main(string[] args) {
            /*选择题
            //1,ABCD     错
            //2,B        
            //3,B        
            //4,A        错
            //5,AC       错
            //6,B        
            //7,B
            //8,C        错
            //9,C
            //10,D
            //11,A       错
            //12,B
            //13,D
            //14,D
            //15,ABCD    错
            */

            /*问答题   
            //1,有值类型,引用类型和其他类型              1
            //值类型包括：整数类型，浮点类型，bool,枚举，结构
            //引用类型包括：string，数组，集合
            //其他类型：object

            //2,区别：值类型可以使用全部运算符，而引用类型不行           0.5

            //3,区别：重写必须访问权限，有无返回值，静态非静态，名称，有无参数都相同才能重写。
            //而重载需要名称相同，参数不同，其余不受影响。                1

            //4,面向对象，安全，基于windows平台开发              0

            //5,ref的用处是可以把参数传出去给入口函数调用       0.5
            //out的用处是可以传递多个参数

            //6,null和""都是代表控制，string.Empty是代表空格，不是空值。 0 

            //7,const可以规定变量为常量，可以在方法和类里都能使用，而readonly只能在类里使用  1

            //8,public  ,private  ,internal  ,protected,  protected internal,  private protected 2

            //9,抽象类必须被普通类继承，基类必须是虚函数           0.5

            //10,属性是类的成员，定义：访问权限 返回值类型 名称 {get;set}             3

            //11,this是替实例对像占位，base可以使子类调用父类的有参构造函数           1

            //12,string是不可变字符串而StringBuilder是可变字符串，string相对StringBuilder来说更方便，占用内存更少。  1

            //13,值传递只能传入参数但没有返回值原参数不会发生改变，引用传递传入参数，参数有返回值原参数发生改变            1

            //14,  0 
            
            //15,CLR可以将不同的语言转译成相同的语言给计算机在返回，使语言可以混编     1

            11+11.5+5
            */
            int[,,] intnumber = new int[2, 2, 4];
            for (int i = 0; i < intnumber.GetLength(0); i++) {
                for (int j = 0; j < intnumber.GetLength(1); j++) {
                    for (int k = 0; k < intnumber.GetLength(2); k++) {
                    AA:
                        Console.WriteLine("请输入元素");
                        string aa = Console.ReadLine();
                        bool isTure = int.TryParse(aa, out int bb);
                        if (isTure == false) {
                            Console.WriteLine("输入非法，重新输入");
                            goto AA;
                        } else {
                            intnumber[i, j, k] = bb;
                        }

                    }
                }
            }
            int SS = 0;
            foreach (int number in intnumber) {
                SS += number;
            }
            Console.WriteLine($"平均值为{SS /}");
            Console.ReadKey();

        }
    }
}
