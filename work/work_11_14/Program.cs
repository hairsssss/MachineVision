using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace work_11_14 {
    internal class Program {
        static async Task Main(string[] args) {
            #region 1.编写一个 C# 程序，使用 Task 类创建两个线程，分别打印出奇数和偶数，从 1 到 100。
            /* //奇数
             Task oddTask = Task.Run(() => {
                 for (int i = 1; i < 100; i += 2) {
                     Console.WriteLine(i);
                 }
             });

             //偶数
             Task evenTask = Task.Run(() => {
                 oddTask.Wait();
                 for (int i = 0; i < 100; i += 2) {
                     Console.WriteLine(i);
                 }
             });
             Task.WaitAll(oddTask, evenTask);
             Console.WriteLine("奇数偶数打印完成");*/
            #endregion


            #region 2.编写一个 C# 程序，使用 Task 类和async await完成，计算一个整数数组的平均值，并在控制台输出结果。
            await Average();

            #endregion


            #region 3.编写一个 C# 程序，使用 async await 实现线程的同步，使得主线程等待两个子线程完成工作后再继续执行。
            /* Console.WriteLine("主线程开始");
             await Task.WhenAll(DoWorkAsync("子线程1"), DoWorkAsync("子线程2"));
             Console.WriteLine("主线程结束");*/
            #endregion

            #region 4.编写一个 C# 程序，使用 AsyncLocal<T> 类创建一个线程本地变量，存储每个线程的名称，并在每个线程中打印出该变量的值。
            // 启动两个异步任务，并在每个任务中设置异步本地变量的值
            var task1 = Task.Run(async () => {
                asyncLocalVariable.Value = "线程1";
                await PrintAsyncLocalValue();
            });

            var task2 = Task.Run(async () => {
                asyncLocalVariable.Value = "线程2";
                task1.Wait();
                await PrintAsyncLocalValue();
            });

            // 等待两个任务完成
            await Task.WhenAll(task1, task2);
            Console.WriteLine("任务完成");
            #endregion


            #region 5.用C#  async和await 写传入数组double数组计算数组的总乘数和总和
            double[] numbers = { 1.0, 2.0, 3.0, 4.0, 5.0 };

            var result = TotalMultiplierAsync(numbers);
            var result1 = TotalAsync(numbers);
            await Task.WhenAll(result, result1);

            Console.WriteLine($"数组的总乘积为: {result.Result}");
            Console.WriteLine($"数组的总和为: {result1.Result}");

            Console.WriteLine("计算完成");
            #endregion
        }

        #region 2.编写一个 C# 程序，使用 Task 类和async await完成，计算一个整数数组的平均值，并在控制台输出结果。
        public async static Task Average() {
            Random random = new Random();
            int[] numbers = new int[100];

            for (int i = 0; i < 100; i++) {
                numbers[i] = random.Next(-999, 999);
            }

            await Task.Delay(2000);

            double average = await AsynvAverage(numbers);
            Console.WriteLine($"数组的平均值为: {average}");
        }
        public static async Task<double> AsynvAverage(int[] numbers) {
            return await Task.Run(() => {
                if (numbers == null || numbers.Length == 0) {
                    throw new ArgumentException("数组不能为空且包含至少一个元素");
                }

                int sum = 0;
                foreach (int number in numbers) {
                    sum += number;
                }

                return (double)sum / numbers.Length;
            });
        }
        #endregion


        #region 3.编写一个 C# 程序，使用 async await 实现线程的同步，使得主线程等待两个子线程完成工作后再继续执行。
        static async Task DoWorkAsync(string threadName) {
            Console.WriteLine($"{threadName} 开始执行");
            await Task.Delay(2000);
            Console.WriteLine($"{threadName} 执行完毕");
        }

        #endregion


        #region 4.编写一个 C# 程序，使用 AsyncLocal<T> 类创建一个线程本地变量，存储每个线程的名称，并在每个线程中打印出该变量的值。
        static AsyncLocal<string> asyncLocalVariable = new AsyncLocal<string>();
        static async Task PrintAsyncLocalValue() {
            await Task.Delay(2000);
            Console.WriteLine($"目前线程为: {asyncLocalVariable.Value}");
        }

        #endregion

        #region 5.用C#  async和await 写传入数组double数组计算数组的总乘数和总和
        static async Task<double> TotalMultiplierAsync(double[] numbers) {
            return await Task.Run(() => {
                if (numbers == null || numbers.Length == 0) {
                    throw new ArgumentException("数组不能为空且包含至少一个元素");
                }

                double result = 1.0;

                foreach (double number in numbers) {
                    result *= number;
                }

                return result;
            });
        }

        static async Task<double> TotalAsync(double[] numbers) {
            return await Task.Run(() => {
                if (numbers == null || numbers.Length == 0) {
                    throw new ArgumentException("数组不能为空且包含至少一个元素");
                }

                double result = 1.0;

                foreach (double number in numbers) {
                    result += number;
                }

                return result;
            });
        }
        #endregion
    }
}
