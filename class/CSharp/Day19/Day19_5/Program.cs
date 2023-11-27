using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day19_5 {
    internal class Program {
        static void Main(string[] args) {
            // 1.net5.0推出了async / await async / await特性是与Task紧密相关的
            //2.async 是“异步”的简写，sync 是“同步”的简写
            //3.await 是 async wait 的简写。await 用于等待一个异步方法执行完成
            //  //如何通过使用async/await  完成异步编程\
            //1. async 必须修饰方法  被修饰的方法 表示是一个异步方法
            //2.async 和await必须连用  如果不使用await 那么这个方法还是同步方法
            //3.async 描述的方法 的返回值类型必须是void 或者是task 或者task<T>
            //4.await 描述的也是方法 但是必须是使用线程（task）的方法
            //5.Async方法在执行的时候，开始是以同步的方式执行，直到遇到await关键字，
            //从await关键字开始，C#会另起一个线程执行await后面的代码。
            DownloadHandle();

            Console.WriteLine("hahahaha");
            Console.ReadKey();

        }

        public async static void DownloadHandle() {
            Console.WriteLine("下载开始！->主线程ID：" + Thread.CurrentThread.ManagedThreadId);
            await Download();
            //有些代码是不能直接写在分线程中的  比如winform 页面渲染代码
            Console.WriteLine("下载完成！->主线程ID：" + Thread.CurrentThread.ManagedThreadId);


            //1.有些代码是不能直接写在分线程中的  比如winform 页面渲染代码  必须在主线程
            //2.又希望分线程代码和主线程代码同步
            //3.主线程又不能阻塞


        }



        public static Task Download() {

            return Task.Run(() => {

                Console.WriteLine("0%");
                Console.WriteLine("10%");
                Console.WriteLine("30%");
                Console.WriteLine("50%");
                Console.WriteLine("60%");
                Console.WriteLine("80%");
                Console.WriteLine("99%");
                Console.WriteLine("100%");


            });


        }
    }
}
