using System;

namespace work_10._25 {
    internal class Program {



        static void Main(string[] args) {
            //1
            /*Student[] students = new Student[4];
            students[0] = new Student() {
                Name = "张三",
                Gender = "男",
                Age = 18,
                Score = 99,
            };

            students[1] = new Student() {
                Name = "李四",
                Gender = "女",
                Age = 17,
                Score = 98,
            };

            students[2] = new Student() {
                Name = "王五",
                Gender = "男",
                Age = 16,
                Score = 97,
            };

            students[3] = new Student() {
                Name = "赵六",
                Gender = "女",
                Age = 15,
                Score = 96,
            };

            for (int i = 0; i < students.Length; i++) {
                Console.WriteLine($"{students[i].Age}岁的{students[i].Gender}生{students[i].Name}这次考了{students[i].Score}分");

            }*/

            //2
            /*Console.WriteLine("请输入第一个数字");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入（+ - * /）其中任一运算符");
            char op = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("请输入第二个数字");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;

            switch (op) {
                case '+':
                    result = Calculator.Add(num1, num2);
                    break;
                case '-':
                    result = Calculator.Reduce(num1, num2);
                    break;
                case '*':
                    result = Calculator.Multiplication(num1, num2);
                    break;
                case '/':
                    result = Calculator.Division(num1, num2);
                    break;
                default:
                    Console.WriteLine("无效运算符");
                    break;
            }

            Console.WriteLine(result);*/

            //3创建一个名为 Hero 的类，包含属性 Name 和 Health（血量），默认值为 100，并设计两个方法 ：
            //- Attack 攻击，接收一个 Hero 类型参数，用于造成指定英雄 1-500 随机伤害
            //- Injured 受伤害，接收一个整数 h，减少英雄自身血量。当伤害结算后，如果血量小于 0，则输出 "啊，我死了"，否则输出 "我还能挺一回合！"
            /*Hero Hero1 = new Hero() { Name = "小强", Health = 99 };
            Hero Hero2 = new Hero() { Name = "小明", Health = 999 };
            Random Rd = new Random();
            for (; ; ) {
                string str1 = Hero1.Attack(Hero2, Rd);
                if (str1 == "啊，嘎了") {
                    Console.WriteLine("没了");
                    break;
                } else {
                    Console.WriteLine("还活着");
                }
            }*/

            Function1 fun = new Function1();
            fun.stringTraversal();
            fun.factorial();
            fun.factor();
            fun.StringReverse();
            fun.findMaxNum();
            fun.stepSize();
            fun.printObj();
            fun.sumOfOddNumbers();
            fun.printOddNum();

            Console.ReadKey();
        }
        public class Function1 {
            //1
            public class Student {
                public string Name;
                public string Gender;
                public int Age;
                public double Score;
            }

            //2
            public class Calculator {
                public static double Add(double num, double num1) {
                    return num + num1;
                }
                public static double Reduce(double num, double num1) {
                    return num - num1;
                }
                public static double Multiplication(double num, double num1) {
                    return num * num1;
                }
                public static double Division(double num, double num1) {
                    if (num1 != 0) return num / num1;
                    else throw new DivideByZeroException("除数不能为0");
                }
            }

            //3
            public class Hero {
                public string Name { get; set; }
                public double Health { get; set; } = 100;


                public string Attack(Hero Hero1, Random Rd) {
                    double Result = Rd.Next(1, 501);
                    Console.WriteLine(Result);
                    return Hero1.Injured(Result);
                }

                public string Injured(double damage) {
                    //Health -= damage;
                    //if (Health <= 0) Console.WriteLine("啊，嘎了");
                    //else Console.WriteLine("我还能挺一回合");
                    Health -= damage;
                    if (Health <= 0) return "啊，嘎了";
                    else return "我还能挺一回合";
                }
            }

            //4.遍历字符串的字符
            public void stringTraversal() {
                string str7 = "好好好，行行行，这么整是吧";
                for (int i = 0; i < str7.Length; i++) {
                    //const string element = Convert.ToString(str7[i]);
                    Console.WriteLine(str7[i]);
                }
            }
            //5.创建一个for循环，计算一个数的阶乘
            public void factorial() {
                Console.Write("请输入一个数字，我将为你计算它的阶乘：");
                string str2 = Console.ReadLine();
                if (int.TryParse(str2, out int val)) {
                    int result2 = 1;
                    for (int i = 1; i < val; i++) {
                        result2 *= i;
                    }
                    Console.WriteLine($"{val}的阶乘为{result2}");
                } else {
                    Console.WriteLine("格式错误！");
                }
            }
            //6.使用for循环找到一个整数的所有因子。
            public void factor() {
                Console.Write("请输入一个数字，我将为你找到它所有因子：");
                string str3 = Console.ReadLine();
                if (int.TryParse(str3, out int val)) {
                    for (int i = 1; i <= val; i++) {
                        if (val % i == 0) {
                            Console.WriteLine($"{val}的因子为{i}");
                        }
                    }
                } else {
                    Console.WriteLine("格式错误！");
                }
            }


            //7.创建一个for循环，反转一个字符串。
            public void StringReverse() {
                Console.Write("请输入任意字符，我将为翻转它：");
                string inputStr4 = Console.ReadLine();
                string concatStr = "";
                for (int i = inputStr4.Length - 1; i >= 0; i--) {
                    concatStr = concatStr + inputStr4[i];
                }
                Console.WriteLine(concatStr);
            }

            //8.使用for循环找到一个数组中的最大值。
            public void findMaxNum() {
                int[] numbers5 = { 13, 45, 11, 566, 1232, 2 };
                int max = 0;
                for (int i = 0; i < numbers5.Length; i++) {
                    if (max < numbers5[i]) {
                        max = numbers5[i];
                    }
                }
                Console.WriteLine(max);
            }

            //9.带有步长的 for 循环
            public void stepSize() {
                for (int i = 0; i < 10; i += 2) {
                    Console.WriteLine(i);
                }
            }


            //10.打印对象
            public void printObj() {
                var obj = new { userName = "jack", age = 20 };
                var properties = obj.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++) {
                    Console.WriteLine($"{properties[i]}:{properties[i].GetValue(obj)}");
                }
            }
            //11.打印等腰三角形
            public void printTriangle() {
                int rows11 = 5;
                int spaces11 = rows11 - 1;
                int stars11 = 1;

                for (int i = 0; i < rows11; i++) {
                    for (int j = 0; j < spaces11; j++) {
                        Console.Write(" ");
                    }

                    for (int k = 0; k < stars11; k++) {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                    spaces11--;
                    stars11 += 2;
                }
            }

            //12.打印奇数
            public void printOddNum() {
                for (int i = 1; i < 20; i += 2) {
                    Console.WriteLine(i);
                }
            }

            //13.打印 1 到 100 中的奇数之和：
            public void sumOfOddNumbers() {
                int sum14 = 0;
                for (int i = 1; i <= 100; i += 2) {
                    sum14 += i;
                }
                Console.WriteLine(sum14);
            }

            //14.打印 1 到 100 中的偶数之和：
            public void sumOfEvenNumbers() {
                int sum = 0;
                for (int i = 2; i <= 100; i += 2) {
                    sum += i;
                }
                Console.WriteLine(sum);
            }
            //15.打印一个递增的字母序列，每个字母重复两次：
            public void repeatPrinting() {
                for (char c = 'A'; c <= 'Z'; c++) {
                    Console.WriteLine($"{c}{c}");
                }
            }
            //16.延迟动画
            public void animation() {
                for (int i = 0; i < 20; i++) {
                    Console.Clear();
                    Console.WriteLine(new string('-', i) + ">");
                    System.Threading.Thread.Sleep(100);
                }
            }
            //17.编写一个for循环，接受用户输入的数字，直到用户输入的数字等于某个特定值，然后使用if语句终止循环。
            public void specificNumber() {
                int targetValue17 = 42; // 设置特定的目标值
                int userInput17;

                for (; ; ) {
                    Console.Write("请输入一个数字: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out userInput17)) {
                        if (userInput17 == targetValue17) {
                            Console.WriteLine("恭喜，您输入的数字等于特定值 " + targetValue17 + "，循环终止。");
                            break; // 如果用户输入的数字等于特定值，退出循循环
                        } else {
                            Console.WriteLine("您输入的数字不等于特定值 " + targetValue17);
                        }
                    } else {
                        Console.WriteLine("无效的输入，请输入一个有效的整数。");
                    }
                }
            }
            //18.使用 break 结束循环
            public void breakFor() {
                for (int i = 1; i <= 10; i++) {
                    if (i == 5) {
                        Console.WriteLine("遇到 i 等于 5，循环终止。");
                        break;
                    }
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }
            //19.使用 continue 跳过特定迭代
            public void continueFor() {
                for (int i = 1; i <= 5; i++) {
                    if (i % 2 == 0) {
                        Console.WriteLine("i 是偶数，跳过这次循环。");
                        continue;
                    }
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }
            //20.使用 break 找到目标值后终止循环
            public void targetBreak() {

            }
            //21.使用 continue 跳过特定条件的迭代
            public void continueBreak() {
                for (int i = 1; i <= 5; i++) {
                    if (i % 2 == 0) {
                        Console.WriteLine("i 是偶数，跳过这次循环。");
                        continue;
                    }
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }
            //22.使用 break 处理嵌套循环：
            public void breakNested() {
                for (int i = 1; i <= 3; i++) {
                    for (int j = 1; j <= 3; j++) {
                        Console.WriteLine("i=" + i + ", j=" + j);
                        if (i + j == 4) {
                            Console.WriteLine("i + j 等于 4，终止内层循环。");
                            break;
                        }
                    }
                }
            }
            //23.使用 break 找到第一个质数后终止循环
            public void primeNumbers() {
                for (int number = 2; number <= 20; number++) {
                    bool isPrime = true;
                    for (int i = 2; i < number; i++) {
                        if (number % i == 0) {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime) {
                        Console.WriteLine(number + " 是质数，循循环终止。");
                        break;
                    }
                    Console.WriteLine(number + " 不是质数。");
                }
            }
            //24.使用 continue 在某个条件下跳过循环迭代
            public void continueSpecific() {
                for (int i = 1; i <= 10; i++) {
                    if (i % 3 == 0) {
                        Console.WriteLine("i 是 3 的倍数，跳过这次迭代。");
                        continue;
                    }
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }
            //25.使用 break 终止循环，如果找到目标元素
            public void specificTarget() {
                string[] fruits = { "apple", "banana", "cherry", "date", "fig" };
                string targetFruit = "cherry";

                for (int i = 0; i < fruits.Length; i++) {
                    if (fruits[i] == targetFruit) {
                        Console.WriteLine("找到目标水果，循环终止。");
                        break;
                    }
                    Console.WriteLine("当前水果：" + fruits[i]);
                }
            }
            //26.使用 continue 跳过特定条件的循环迭代
            public void continuespecific1() {
                for (int i = 1; i <= 10; i++) {
                    if (i % 5 == 0) {
                        Console.WriteLine("i 是 5 的倍数，跳过这次迭代。");
                        continue;
                    }
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }
            //27.使用 break 处理嵌套循环，找到满足条件的元素后终止内层循环
            public void findSatisfy() {
                for (int i = 1; i <= 3; i++) {
                    for (int j = 1; j <= 3; j++) {
                        Console.WriteLine("i=" + i + ", j=" + j);
                        if (i + j == 4) {
                            Console.WriteLine("i + j 等于 4，终止内层循环。");
                            break;
                        }
                    }
                }
            }
            //28.使用 break 找到第一个负数后终止循环
            public void negativeNumber() {
                int[] numbers = { 10, -5, 20, -15, 30, 25 };
                for (int i = 0; i < numbers.Length; i++) {
                    if (numbers[i] < 0) {
                        Console.WriteLine("找到第一个负数，循环终止。");
                        break;
                    }
                    Console.WriteLine("当前值：" + numbers[i]);
                }
            }
            //29.使用 continue 跳过特定条件的循环迭代，但在跳过之前输出一条消息
            public void continuePrint() {
                for (int i = 1; i <= 10; i++) {
                    if (i % 4 == 0) {
                        Console.WriteLine("i 是 4 的倍数，但不会执行 continue。");
                    } else {
                        Console.WriteLine("当前 i 的值：" + i);
                    }
                }
            }
            //30.使用 break 找到目标值后终止循环，但在终止之前输出循环次数
            public void continuePrint1() {
                int targetValue = 7;
                for (int i = 1; i <= 10; i++) {
                    Console.WriteLine("当前循环次数：" + i);
                    if (i == targetValue) {
                        Console.WriteLine("找到目标值 " + targetValue + "，循环终止。");
                        break;
                    }
                }
            }
        }
    }
}
