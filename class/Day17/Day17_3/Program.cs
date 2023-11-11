using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17_3 {
    internal class Program {
        static void Main(string[] args) {
            //  通过使用AppDomain.CurrentDomain.UnhandledException 订阅事件  处理未及时相应的异常


            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler;
        }
        //当某个异常未被捕获时调用
        public static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e) {

            //  未被捕获异常的对象

            Exception exception = (Exception)e.ExceptionObject;

            Console.WriteLine(exception.Message);

            Console.WriteLine("某个异常未被捕获");

        }
    }
}
