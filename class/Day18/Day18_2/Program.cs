using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day18_2 {
    internal class Program {
        static void Main(string[] args) {

            //2.ThreadPool 线程池
            // 线程和线程池都是进行多线程操作的
            //线程池是用来保存线程的一个容器
            //线程池里的线程会被反复利用
            //当线程池里的线程不够用的时候会新实例化一个线程
            // public delegate void WaitCallback(object state);
            //创建线程 把任务放到创建的线程中
            Thread t1 = new Thread((states) => { Console.WriteLine(states); });
            //执行线程
            t1.Start(10);


            //  QueueUserWorkItem 接收一个参数，参数类型是WaitCallback 它是一个无返回值委托，委托函数接收一个
            WaitCallback callBack = new WaitCallback(state => { Console.WriteLine(state); });
            //把任务添加到线程队列中 并且执行任务
            ThreadPool.QueueUserWorkItem(callBack);


            WaitCallback waitCallback = arg => Console.WriteLine("dosomething1");


            //  QueueUserWorkItem 接收一个参数，参数类型是WaitCallback 它是一个无返回值委托，委托函数接收一个
            WaitCallback callBack1 = new WaitCallback(state => { Console.WriteLine(state); });
            //把任务添加到线程队列中 并且执行任务
            ThreadPool.QueueUserWorkItem(callBack, "30");

            //            方式二：
            //QueueUserWorkItem 接收两个参数，第一个参数是WaitCallback 委托类型，第二个参数是object对象，用于传递给委托函数
            WaitCallback waitCallback1 = arg => Console.WriteLine(arg);
            ThreadPool.QueueUserWorkItem(waitCallback1, "30");
            Console.ReadKey();






            //  public delegate void WaitCallback(object state);
            ManualResetEvent mreset = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(state => {
                //休眠1秒
                Thread.Sleep(1000);
                Console.WriteLine(state);
                // 执行mreset.Set()后执行 mreset.WaitOne()的后续代码
                mreset.Set();
            }, new object());

            //阻塞主线程 等待分线程完成后 
            mreset.WaitOne();
            Console.WriteLine("123");
        }
    }
}
