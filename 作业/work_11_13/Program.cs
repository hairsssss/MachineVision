using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace work_11_13 {
    internal class Program {
        static void Main(string[] args) {
            #region 1.编写一个 C# 程序，使用 Thread 类创建两个线程，分别打印出奇数和偶数，从 1 到 100。
            /*    Thread oddThread = new Thread(() => {
                    for (int i = 1; i < 100; i += 2) {
                        Console.WriteLine(i);
                    }
                });

                Thread evenThread = new Thread(() => {
                    for (int i = 0; i < 100; i += 2) {
                        Console.WriteLine(i);
                    }
                });

                oddThread.Start();
                evenThread.Start();

                oddThread.Join();
                evenThread.Join();

                Console.WriteLine("子线程结束，主线程运行。");*/
            #endregion


            #region 2.编写一个 C# 程序，使用 Task 类创建一个异步任务，计算一个整数数组的平均值，并在控制台输出结果。
            /*  Random random = new Random();
              int[] numbers = new int[100];

              for (int i = 0; i < 100; i++) {
                  numbers[i] = random.Next(-999, 999);
              }

              Task<double> task = Task.Run(() => {
                  double sum = 0;
                  foreach (int num in numbers) {
                      sum += num;
                  }
                  return sum / numbers.Length;
              });

              double average = task.Result;
              Console.WriteLine("平均值为 {0}", average);*/
            #endregion


            #region 3.编写一个 C# 程序，使用 ManualResetEvent 类实现线程的同步，使得主线程等待两个子线程完成工作后再继续执行。
            /*Thread thread1 = new Thread(() => {
                Console.WriteLine("线程 1 正在进行一些工作。");
                Thread.Sleep(3000);
                Console.WriteLine("线程 1 已完成其工作。");

                // 通知主线程，该线程已完成工作
                thread1Event.Set();
            });
            Thread thread2 = new Thread(() => {
                Console.WriteLine("线程 2 正在进行一些工作。");
                Thread.Sleep(2000);
                Console.WriteLine("线程 2 已完成其工作。");

                // 通知主线程，该线程已完成工作
                thread2Event.Set();
            });

            thread1.Start();
            thread2.Start();

            WaitHandle.WaitAll(new WaitHandle[] { thread1Event, thread2Event });

            Console.WriteLine("两个子线程都已完成工作。");*/
            #endregion

            #region 4.编写一个 C# 程序，使用 ThreadLocal<T> 类创建一个线程本地变量，存储每个线程的名称，并在每个线程中打印出该变量的值。
            Thread thread41 = new Thread(() => {
                // 设置线程本地变量的值为线程1的名称
                threadLocalVariable.Value = "thread41";
                PrintThreadLocalValue();
            });

            Thread thread42 = new Thread(() => {
                // 设置线程本地变量的值为线程2的名称
                threadLocalVariable.Value = "thread42";
                PrintThreadLocalValue();
            });

            thread41.Start();
            thread42.Start();

            thread41.Join();
            thread42.Join();

            Console.WriteLine("分线程结束，运行主线程！！");
            #endregion


            #region 5.编写一个 C# 程序，使用 Parallel 类实现一个并行的 for 循环，计算一个整数范围内的所有素数，并将结果存储在一个集合中。
            /* int startRange = 2;
             int endRange = 100;

             List<int> primeNumbers = CalculatePrimeNumbersParallel(startRange, endRange);

             Console.WriteLine("素数：");
             foreach (int prime in primeNumbers) {
                 Console.Write(prime + " ");
             }*/
            #endregion
        }

        #region 1.编写一个 C# 程序，使用 Thread 类创建两个线程，分别打印出奇数和偶数，从 1 到 100。
        ////打印偶数
        //static void PrintEven() {
        //    for (int i = 0; i < 100; i += 2) {
        //        Console.WriteLine(i);
        //    }
        //}

        ////打印奇数
        //static void PrintOdd() {
        //    for (int i = 1; i < 100; i += 2) {
        //        Console.WriteLine(i);
        //    }
        //}
        #endregion


        #region 3.编写一个 C# 程序，使用 ManualResetEvent 类实现线程的同步，使得主线程等待两个子线程完成工作后再继续执行。
        static ManualResetEvent thread1Event = new ManualResetEvent(false);
        static ManualResetEvent thread2Event = new ManualResetEvent(false);
        #endregion


        #region 4.编写一个 C# 程序，使用 ThreadLocal<T> 类创建一个线程本地变量，存储每个线程的名称，并在每个线程中打印出该变量的值。
        static ThreadLocal<string> threadLocalVariable = new ThreadLocal<string>();
        static void PrintThreadLocalValue() {
            // 获取线程本地变量的值并打印
            Console.WriteLine($"目前线程为: {threadLocalVariable.Value}");
        }
        #endregion


        #region 5.编写一个 C# 程序，使用 Parallel 类实现一个并行的 for 循环，计算一个整数范围内的所有素数，并将结果存储在一个集合中。
        static List<int> CalculatePrimeNumbersParallel(int start, int end) {
            List<int> primeNumbers = new List<int>();

            // 使用 Parallel.For 并行计算素数
            Parallel.For(start, end + 1, i => {
                if (IsPrime(i)) {
                    lock (primeNumbers) {
                        primeNumbers.Add(i);
                    }
                }
            });

            return primeNumbers;
        }

        static bool IsPrime(int number) {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++) {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
    #endregion
}
