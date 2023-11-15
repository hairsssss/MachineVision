using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day19_4 {
    internal class Program {
        static void Main(string[] args) {
            //1.初始化线程取消类
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            //2.获取线程取消标记
            CancellationToken token = tokenSource.Token;

            Task.Run(() => {
                for (int i = 0; i < 1000; i++) {
                    Thread.Sleep(500);

                    Console.WriteLine("1");

                    if (token.IsCancellationRequested) {

                        Console.WriteLine("线程被取消了");
                        return;
                    }
                }

            }, token);
            //取消之前的令牌状态  false
            Console.WriteLine(tokenSource.Token.IsCancellationRequested);
            //取消线程方法
            tokenSource.Cancel();
            //取消之后的令牌状态  true
            Console.WriteLine(tokenSource.Token.IsCancellationRequested);
            //在取消线程后 执行的委托方法
            token.Register(() => {

                Console.WriteLine("111111111111111111111111111111111");
            });
            Console.ReadKey();
        }
    }
}
