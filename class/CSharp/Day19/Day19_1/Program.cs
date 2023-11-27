using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day19_1 {
    internal class Program {
        static void Main(string[] args) {
            //1.Task和Thread一样，位于System.Threading命名空间下
            //Thread位于System.Threading
            //Task位于System.Threading.Tasks
            //2.Task是升级版的ThreadPool 
            //3.ThreadPool不支持线程控制，线程延续 ，线程取消  而Task支持

            //创建Task
            //第一种创建方式，直接实例化：必须手动去Start   可以绑定有参数的委托对象
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("1");
            //});
            //task.Start();

            ////第二种创建方式，工厂创建，直接执行  且绑定的都是无参无返回值的委托对象
            //var task2 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("2");
            //});
            ////方式3
            //Task.Run(() =>
            //{
            //    Console.WriteLine("3");
            //});


            //三、Task的任务控制：Task比threadPool优点就是任务控制，
            //很好的控制task的执行顺序，让多个task有序的执行

            /*
Task.Wait	task1.Wait();就是等待任务执行（task1）完成，
            task1的状态变为Completed。
Task.WaitAll	待所有的任务都执行完成：
Task.WaitAny	等待任何一个任务完成就继续向下执行
        
             */
            Task task4 = Task.Run(() => {

                Console.WriteLine("4");
                Console.WriteLine("9");

            });
            Task task5 = Task.Run(() => {
                task4.Wait();
                Console.WriteLine("5");

            });
            Task task6 = Task.Run(() => {
                task4.Wait();
                Console.WriteLine("6");

            });
            //for (int i = 0; i < 1000; i++) {

            //     Console.WriteLine("10");
            // }
            //让主线程等待task4任务执行完毕后执行后续内容
            task4.Wait();
            //主线程内容
            Console.WriteLine("7");
            Console.WriteLine("8");
            Console.ReadKey();
        }


    }






}
