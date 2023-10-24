using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiYou_226_8_Day5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // whlie循环 一般做未知次数的循环
            //for 循环 一般做已知次数的循环

            //int a =0;
            //while (a<1)
            //{

            //    Console.WriteLine(1);

            //}

            //for(定义一个初始变量;循环的条件;初始变量再每次循环结束的自身变化)
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(2);
            //}


            //for (; ; ) { }
            // while (true) { }
            //  for (int i = 0;i < 10;){}
            //  for (int i = 0; ;){}



            //for嵌套
            //原理 先看外部条件是否成立 如果不成立 整个for结束
            //如果成立  才能对内部for进行判断和执行  直到外部循环不成立时 整个for结束

            //1233333333332333333333233333333323333333333
            //i=0   j=0   k=0   l=0   k=1 k=2 ..k=9    j=1  k=0 k=1 ....k=9   j=2 k=0....   j=9 k=0...
            //i=1    j=0   k=0 k=1 k=2 ..k=9    j=1  k=0 k=1 ....k=9   j=2 k=0....   j=9 k=0...
            //i=2     j=0   k=0 k=1 k=2 ..k=9    j=1  k=0 k=1 ....k=9   j=2 k=0....   j=9 k=0...
            //....
            //i=9     j=0   k=0 k=1 k=2 ..k=9    j=1  k=0 k=1 ....k=9   j=2 k=0....   j=9 k=0..
            //for (int i = 0;i < 10; i++)
            //{
            //    Console.WriteLine(1);
            //    for (int j = 0; j < 10; j++)
            //    {

            //        Console.WriteLine(2);
            //        for (int k = 0; k < 10; k++) 
            //        {
            //            Console.WriteLine(3);
            //            for (int l = 0; l < 10; l++)
            //            {
            //                while (l<10)
            //                {
            //                    Console.WriteLine(5);

            //                }
            //                Console.WriteLine(4);


            //            }                  
            //        }
            //    }
            //}


            //   continue  break  是在循环体中使用的关键字  swicth 中 也可以受用break
            //  continue 终止（跳出）当次循环 进入下次循环     break  终止（跳出）整个循环  执行循环之后的其他内容


            //while (true)
            //{



            //    Console.WriteLine(1);
            //    continue;
            //    Console.WriteLine(2);



            //}

            //while (true)
            //{
            //    Console.WriteLine(1);
            //    break;
            //     Console.WriteLine(2);

            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    continue;
            //    Console.WriteLine(1);
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    break;
            //    Console.WriteLine(1);
            //}


            // do...while 不管条件成立与否，至少会循环执行一次
            //whlie   首先判断条件成立 执行循环

            int score = 50;
            //do
            //{
            //    Console.WriteLine("学习中");
            //    Console.WriteLine("考试");
            //    score += 2;
            //} while (score<60);


            //for (; ; ) 
            //{

            //    Console.WriteLine("学习中");
            //    Console.WriteLine("考试");
            //    score += 2;
            //    if (score >=60)
            //    {
            //        break;
            //    }
            //}
            //while (true)
            //{

            //    Console.WriteLine("学习中");
            //    Console.WriteLine("考试");
            //    score += 2;
            //    if (score >= 60)
            //    {
            //        break;
            //    }

            //}

            //goto语句  跳转语句  模拟循环逻辑
            //goto语句跳转标签
            int money = 100;
            SCORC_TEST:
            Console.WriteLine("学习中");
            Console.WriteLine("考试");
            score += 2;
            GOSHIOPPING:
            Console.WriteLine("我去购物");
            money -= 50;
            if (score < 60)
            {
               goto SCORC_TEST;
            }

            if (money >= 50) { 
               goto GOSHIOPPING;
            
            }

            //switch 条件判断语句   

            int a =1;
            switch (a)
            {    
                case 1: {

                        Console.WriteLine(1);
                    }
                    break;
                case 2:
                    {

                        Console.WriteLine(2);
                    }
                    break;
                case 3:
                    {

                        Console.WriteLine(3);
                    }
                    break;

            }
            //true  false为条件
            if (a<10&&a>0) {

                Console.WriteLine(a);
            }
            Console.ReadKey();

        }
    }
}
