using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day19_2 {
    internal class Program {
        static void Main(string[] args) {




            Test();



            Console.ReadKey();
        }

        public static void Test1() {

            Task task1 = Task.Run(() => { Console.WriteLine("1"); });
            Task task2 = Task.Run(() => {

                task1.Wait();
                //  Task.WaitAll(task1);
                Console.WriteLine("2");

            });
            Task task3 = Task.Run(() => {

                Task.WaitAll(task1, task2);
                Console.WriteLine("3");

            });

            //主线程中等待某些分线程执行
            Task.WaitAll(task1, task2, task3);

            //  Task.WaitAny 等待任何一个任务完成就继续向下执行
            Console.WriteLine("4");

        }
        public static void Test() {

            int a;
            CancellationToken cancellationToken = new CancellationToken();
            Task task1 = Task.Run(() => {

                Console.WriteLine("1");
            });
            Task task2 = Task.Run(() => {


                Console.WriteLine("2");

            });

            Task task3 = Task.Run(() => {


                Console.WriteLine("3");

            });

            //主线程等待任意线程执行完毕后继续执行后续内容
            Task.WaitAny(task1, task2, task3);
            Console.WriteLine("4");

        }
    }


}
