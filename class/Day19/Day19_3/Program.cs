using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day19_3 {
    internal class Program {
        static void Main(string[] args) {

            //Task.ContinueWith	第一个Task完成后自动启动下一个Task，实现Task的延续

            Task<int> task1 = new Task<int>(() => {

                Thread.Sleep(2000);
                Console.WriteLine("200");


                return 1111;

            });

            task1.Start();
            Console.WriteLine("-------" + task1.Id);
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine("0000");
            //}
            //线程延续 可以在不阻塞主线程的前提下 得到结果
            task1.ContinueWith(tas => {

                //获取task4 完成后的返回值结果
                Console.WriteLine(tas.Result);



            });

            //task1.Result 默认会阻塞主线程 只有等待分线程结果后才能执行主线程后续内容
            //   Console.WriteLine(task1.Result);
            Console.WriteLine("100");
            //
            Task<string> task2 = new Task<string>(() => {
                return "abc";
            });
            task2.Start();
            Console.WriteLine("+++++" + task2.Id);
            task2.ContinueWith<string>(tas => {

                //Console.WriteLine(tas.Result);
                //string tempA = "bbb";
                //Console.WriteLine(tas.Result+tempA);

                Task.Run(() => {

                    Console.WriteLine("fffff");
                });
                Console.WriteLine("aaaaaaaa");
                return tas.Result;
            });

            Console.ReadKey();
        }
    }
}
