using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day18_3 {
    internal class Program {
        static void Main(string[] args) {

            int a;
            //一个程序就是一个进程
            //一个进程包含多个线程（至少要包含一个）这一个叫主线程
            //主线程 任务繁重时 可以开启分线程 为其分担 保证程序的正常运行
            //进程中的资源可以被多个线程共享
            //为了解决资源共享的资源安全问题  可以使用互斥锁 防止多个线程同时读写某一块内存区域。

            a = 1;
            Console.WriteLine(a);
            int b = 2;
            Console.WriteLine(b);
            //此处是分线程

            // 有4种创建线程的方式:
            //   1.Thread 自己创建的独立的线程, 优先级高,需要使用者自己管理
            //创建分线程执行哪个方法
            ThreadStart childref = new ThreadStart(TestMothod);
            //创建分线程实例对象
            Thread childThread = new Thread(childref);
            //执行分线程
            childThread.Start();


            //简写  开辟了第二个分线程
            Thread childThread1 = new Thread(() => {
                //while (true)
                //{
                //    Console.WriteLine("执行繁重的任务");
                //}
            });
            childThread1.Start();

            Console.WriteLine("2");
            Console.WriteLine("3");

            //主线程休眠
            Thread.Sleep(3000);
            Console.WriteLine("4");
            //手动销毁线程
            childThread.Abort();


            Thread t2 = new Thread(new ParameterizedThreadStart(TestMothod1));
            //
            t2.Start(10);
            Thread t3 = new Thread(t3a => { Console.WriteLine(t3a); });
            t3.Start("abc");



            Console.ReadKey();

        }

        public static void TestMothod() {
            //线程休眠  当把方法写在哪个线程中就休眠哪个线程
            //3000毫秒 =3秒
            // Thread.Sleep(3000);
            //此处是分线程
            //for (; ; )
            //{
            //    Console.WriteLine(1);
            //}

        }

        public static void TestMothod1(object a) {

            Console.WriteLine(a);
        }
        ////线程销毁
        //1.线程方法执行完结,线程自动销毁
        //2.如果是无限循环需要手动销毁
    }
}
