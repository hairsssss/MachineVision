using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day18_1 {
    internal class Program {

        //解决线程抢占问题 使用线程锁
        //不能被释放   不能被修改   对象类型

        static readonly object locker = new object();  //线程锁对象
        static bool done;
        static void Main(string[] args) {

            //// 线程阻塞 阻塞主线程 t.Join()
            //Thread t = new Thread(() => { for (int i = 0; i < 1000; i++) Console.Write("y"); });
            //t.Start();
            //// t.Join();//线程阻塞
            //Console.WriteLine("Thread t has ended!");

            //Thread t1 = new Thread(() => { for (int i = 0; i < 1000; i++) Console.Write("x"); });
            //t1.Start();

            //Thread t2 = new Thread(() => 
            //{ 
            //  //  t1.Join();
            //    for (int i = 0; i < 1000; i++) Console.Write("z"); }
            //);
            //t2.Start();


            //Console.WriteLine("111111");
            //开启分线程执行go方法
            new Thread(Go).Start();
            //在主线程执行go方法
            Go();
            Console.ReadKey();
        }


        static void Go() {

            //lock 关键字 做为线程资源互斥锁 通过locker 为标识
            //是否有线程正在对其进行操作 如果有锁关闭，
            //当操作完毕后   锁打开
            //其他线程可以进入访问
            //
            lock (locker) {
                if (!done) {
                    for (int i = 0; i < 1000; i++) {
                        Console.WriteLine("1");
                    }
                    done = true;
                }

            }

        }
    }
}
