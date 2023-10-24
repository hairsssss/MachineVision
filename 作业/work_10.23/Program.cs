namespace work_10._23 {
    internal class Program {
        static void Main(string[] args) {
            //1、使用for循环输出1到10的数字。
            /*for (int i = 0; i < 10; i++) {
                Console.WriteLine(i + 1);
            }*/

            //2、创建一个for循环，计算一个数的阶乘。
            /* Console.Write("请输入一个数字，我将为你计算它的阶乘：");
             string str2 = Console.ReadLine();
             if (int.TryParse(str2, out int val)) {
                 int result2 = 1;
                 for (int i = 1; i < val; i++) {
                     result2 *= i;
                 }
                 Console.WriteLine($"{val}的阶乘为{result2}");
             } else {
                 Console.WriteLine("格式错误！");
             }*/

            //3、使用for循环找到一个整数的所有因子。
            /*Console.Write("请输入一个数字，我将为你找到它所有因子：");
            string str3 = Console.ReadLine();
            if (int.TryParse(str3, out int val)) {
                for (int i = 1; i <= val; i++) {
                    if (val % i == 0) {
                        Console.WriteLine($"{val}的因子为{i}");
                    }
                }
            } else {
                Console.WriteLine("格式错误！");
            }*/

            //4、创建一个for循环，反转一个字符串。
            /*Console.Write("请输入任意字符，我将为翻转它：");
            string inputStr4 = Console.ReadLine();
            string concatStr = "";
            for (int i = inputStr4.Length - 1; i >= 0; i--) {
                concatStr = concatStr + inputStr4[i];
            }
            Console.WriteLine(concatStr);*/

            //5、使用for循环找到一个数组中的最大值。
            /* int[] numbers5 = { 13, 45, 11, 566, 1232, 2 };
             int max = 0;
             for (int i = 0; i < numbers5.Length; i++) {
                 if (max < numbers5[i]) {
                     max = numbers5[i];
                 }
             }
             Console.WriteLine(max);*/

            //6.带有步长的 for 循环：
            /*for (int i = 0; i < 10; i += 2) {
                Console.WriteLine(i);
            }*/

            //7.遍历字符串的字符
            /*string str7 = "好好好，行行行，这么整是吧";
            for (int i = 0; i < str7.Length; i++) {
                //const string element = Convert.ToString(str7[i]);
                Console.WriteLine(str7[i]);
            }*/

            //8.打印数字 10 到 1
            /*for (int i = 10; i > 0; i--) {
                Console.WriteLine(i);
            }*/

            //9.打印奇数：
            /* for (int i = 1; i < 20; i += 2) {
                 Console.WriteLine(i);
             }*/

            //10.打印偶数：
            /*for (int i = 0; i < 20; i += 2) {
                Console.WriteLine(i);
            }*/

            //11.打印等腰三角形
            /*  int rows11 = 5;
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
              }*/

            //12.打印对象
            /* var obj = new { userName = "jack", age = 20 };
             var properties = obj.GetType().GetProperties();
             for (int i = 0; i < properties.Length; i++) {
                 Console.WriteLine($"{properties[i]}:{properties[i].GetValue(obj)}");
             }*/

            //13.打印 1 到 100 中的奇数之和：
            /*int sum14 = 0;
            for (int i = 1; i <= 100; i += 2) {
                sum14 += i;
            }
            Console.WriteLine(sum14);*/

            //14.打印 1 到 100 中的偶数之和：
            /* int sum = 0;
             for (int i = 2; i <= 100; i += 2) {
                 sum += i;
             }
             Console.WriteLine(sum);*/

            //15.打印一个递增的字母序列，每个字母重复两次：
            /* for (char c = 'A'; c <= 'Z'; c++) {
                 Console.WriteLine($"{c}{c}");
             }*/

            //16.
            /* for (int i = 0; i < 20; i++) {
                 Console.Clear();
                 Console.WriteLine(new string('-', i) + ">");
                 System.Threading.Thread.Sleep(100);
             }*/


            //17.编写一个for循环，接受用户输入的数字，直到用户输入的数字等于某个特定值，然后使用if语句终止循环。
            /*int targetValue17 = 42; // 设置特定的目标值
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
            }*/

            //18.使用 break 结束循环
            /* for (int i = 1; i <= 10; i++) {
                 if (i == 5) {
                     Console.WriteLine("遇到 i 等于 5，循环终止。");
                     break;
                 }
                 Console.WriteLine("当前 i 的值：" + i);
             }*/

            //19.使用 continue 跳过特定迭代
            /* for (int i = 1; i <= 5; i++) {
                 if (i % 2 == 0) {
                     Console.WriteLine("i 是偶数，跳过这次循环。");
                     continue;
                 }
                 Console.WriteLine("当前 i 的值：" + i);
             }*/

            //20.使用 break 找到目标值后终止循环
            /*int[] numbers = { 10, 20, 30, 40, 50, 60 };
            int targetValue = 40;
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] == targetValue) {
                    Console.WriteLine("找到目标值 " + targetValue + "，循环终止。");
                    break;
                }
                Console.WriteLine("当前值：" + numbers[i]);
            }*/

            //21.使用 continue 跳过特定条件的迭代
            /*for (int i = 1; i <= 5; i++) {
                if (i % 2 == 0) {
                    Console.WriteLine("i 是偶数，跳过这次循环。");
                    continue;
                }
                Console.WriteLine("当前 i 的值：" + i);
            }*/

            //22.使用 break 处理嵌套循环：
            /*for (int i = 1; i <= 3; i++) {
                for (int j = 1; j <= 3; j++) {
                    Console.WriteLine("i=" + i + ", j=" + j);
                    if (i + j == 4) {
                        Console.WriteLine("i + j 等于 4，终止内层循环。");
                        break;
                    }
                }
            }*/

            //23.使用 break 找到第一个质数后终止循环
            /* for (int number = 2; number <= 20; number++) {
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
             }*/

            //24.使用 continue 在某个条件下跳过循环迭代
            /*for (int i = 1; i <= 10; i++) {
                if (i % 3 == 0) {
                    Console.WriteLine("i 是 3 的倍数，跳过这次迭代。");
                    continue;
                }
                Console.WriteLine("当前 i 的值：" + i);
            }*/

            //25.使用 break 终止循环，如果找到目标元素
            /*string[] fruits = { "apple", "banana", "cherry", "date", "fig" };
            string targetFruit = "cherry";

            for (int i = 0; i < fruits.Length; i++) {
                if (fruits[i] == targetFruit) {
                    Console.WriteLine("找到目标水果，循环终止。");
                    break;
                }
                Console.WriteLine("当前水果：" + fruits[i]);
            }*/

            //26.使用 continue 跳过特定条件的循环迭代
            /*for (int i = 1; i <= 10; i++) {
                if (i % 5 == 0) {
                    Console.WriteLine("i 是 5 的倍数，跳过这次迭代。");
                    continue;
                }
                Console.WriteLine("当前 i 的值：" + i);
            }*/

            //27.使用 break 处理嵌套循环，找到满足条件的元素后终止内层循环
            /*for (int i = 1; i <= 3; i++) {
                for (int j = 1; j <= 3; j++) {
                    Console.WriteLine("i=" + i + ", j=" + j);
                    if (i + j == 4) {
                        Console.WriteLine("i + j 等于 4，终止内层循环。");
                        break;
                    }
                }
            }*/

            //28.使用 break 找到第一个负数后终止循环
            /*int[] numbers = { 10, -5, 20, -15, 30, 25 };
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] < 0) {
                    Console.WriteLine("找到第一个负数，循环终止。");
                    break;
                }
                Console.WriteLine("当前值：" + numbers[i]);
            }*/

            //29.使用 continue 跳过特定条件的循环迭代，但在跳过之前输出一条消息
            /*for (int i = 1; i <= 10; i++) {
                if (i % 4 == 0) {
                    Console.WriteLine("i 是 4 的倍数，但不会执行 continue。");
                } else {
                    Console.WriteLine("当前 i 的值：" + i);
                }
            }*/

            //30.使用 break 找到目标值后终止循环，但在终止之前输出循环次数
            /*int targetValue = 7;
            for (int i = 1; i <= 10; i++) {
                Console.WriteLine("当前循环次数：" + i);
                if (i == targetValue) {
                    Console.WriteLine("找到目标值 " + targetValue + "，循环终止。");
                    break;
                }
            }*/

            //31.使用 for 循环从 10 递减到 1
            /*for (int i = 10; i >= 1; i--) {
                Console.WriteLine(i);
            }*/

            //32.使用 for 循环从 1 循环到 10，但在迭代 5 时使用 break 终止循环
            /*for (int i = 1; i <= 10; i++) {
                if (i == 5) {
                    break;
                }
                Console.WriteLine(i);
            }*/

            //33.使用 for 循环从 1 循环到 10，但在迭代 5 时使用 continue 跳过
            /*for (int i = 1; i <= 10; i++) {
                if (i == 5) {
                    continue;
                }
                Console.WriteLine(i);
            }*/

            //34.使用 for 循环实现无限循环，需要通过 break 终止
            /*for (; ; ) {
                Console.WriteLine("这是一个无限循环，按 'q' 退出。");
                string input = Console.ReadLine();
                if (input == "q") {
                    break;
                }
            }*/

            //35.使用 for 循环从 1 循环到 5，嵌套另一个 for 循环从 1 循环到 3，并在内部循环中使用 continue 跳过特定条件
            /* for (int i = 1; i <= 5; i++) {
                 for (int j = 1; j <= 3; j++) {
                     if (j == 2) {
                         continue;
                     }
                     Console.WriteLine("i=" + i + ", j=" + j);
                 }
             }*/

            //36.使用 for 循环从 1 循环到 10，但在迭代 7 时使用 break 终止循环
            /*for (int i = 1; i <= 10; i++) {
                if (i == 7) {
                    break;
                }
                Console.WriteLine(i);
            }*/

            //37.使用 for 循环从 1 循环到 10，但在迭代 4 时使用 continue 跳过
            /*for (int i = 1; i <= 10; i++) {
                if (i == 4) {
                    continue;
                }
                Console.WriteLine(i);
            }*/

            //38.使用 for 循环从 10 递减到 1，但在迭代 8 时使用 break 终止循环
            /*for (int i = 10; i >= 1; i--) {
                if (i == 8) {
                    break;
                }
                Console.WriteLine(i);
            }*/

            //39.使用 for 循环实现无限循环，需要通过 break 终止，但只有在输入满足条件时才终止
            /*for (; ; ) {
                Console.WriteLine("这是一个无限循环，输入 'exit' 退出。");
                string input = Console.ReadLine();
                if (input == "exit") {
                    break;
                }
            }*/

            //40.使用 for 循环、break 和 continue 来查找并处理数组中的特定元素
            /*int[] numbers40 = { 10, 15, 20, 25, 30, 35 };
            int targetValue40 = 25;
            bool found = false;

            for (int i = 0; i < numbers40.Length; i++) {
                if (numbers40[i] == targetValue40) {
                    Console.WriteLine("找到目标值 " + targetValue40 + " 在索引 " + i + "，循环终止。");
                    found = true;
                    break;
                }

                Console.WriteLine("当前值：" + numbers40[i]);
            }

            if (!found) {
                Console.WriteLine("目标值 " + targetValue40 + " 未找到。");
            }*/

            //41.根据一周的天数输出对应的星期几
            /* int day41 = 3;
             switch (day41) {
                 case 1:
                     Console.WriteLine("星期一");
                     break;
                 case 2:
                     Console.WriteLine("星期二");
                     break;
                 case 3:
                     Console.WriteLine("星期三");
                     break;
                 // ...
                 default:
                     Console.WriteLine("未知");
                     break;
             }*/

            //42.根据用户输入的颜色选择不同的操作
            /* string color = "red";
             switch (color) {
                 case "red":
                     Console.WriteLine("选择了红色");
                     break;
                 case "blue":
                     Console.WriteLine("选择了蓝色");
                     break;
                 default:
                     Console.WriteLine("未知颜色");
                     break;
             }*/

            //43.根据用户输入的月份输出该月的天数
            /*Console.Write("请输入月份：");
            int month = int.Parse(Console.ReadLine());
            switch (month) {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("31天");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30天");
                    break;
                case 2:
                    Console.WriteLine("28或29天");
                    break;
                default:
                    Console.WriteLine("无效的月份");
                    break;
            }*/

            //44.根据学生的分数输出对应的等级
            /*int score44 = 85;
            char grade;
            switch (score44 / 10) {
                case 10:
                case 9:
                    grade = 'A';
                    break;
                case 8:
                    grade = 'B';
                    break;
                case 7:
                    grade = 'C';
                    break;
                case 6:
                    grade = 'D';
                    break;
                default:
                    grade = 'F';
                    break;
            }
            Console.WriteLine("得分 " + score44 + " 对应的等级是 " + grade);*/

            //45.根据用户输入的命令执行相应的操作
            /*string command = "quit";
            switch (command) {
                case "start":
                    Console.WriteLine("启动应用程序");
                    break;
                case "stop":
                    Console.WriteLine("停止应用程序");
                    break;
                case "quit":
                    Console.WriteLine("退出应用程序");
                    break;
                default:
                    Console.WriteLine("未知命令");
                    break;
            }*/

            //46.根据用户的身份验证状态执行不同的操作
            /* bool isAuthenticated = false;
             switch (isAuthenticated) {
                 case true:
                     Console.WriteLine("用户已认证，可以访问");
                     break;
                 case false:
                     Console.WriteLine("用户未认证，无法访问");
                     break;
             }*/

            //47.根据用户输入的季节输出相关信息
            /*string season = "summer";
            switch (season) {
                case "spring":
                    Console.WriteLine("春天：温暖的季节");
                    break;
                case "summer":
                    Console.WriteLine("夏天：炎热的季节");
                    break;
                case "autumn":
                    Console.WriteLine("秋天：落叶的季节");
                    break;
                case "winter":
                    Console.WriteLine("冬天：寒冷的季节");
                    break;
                default:
                    Console.WriteLine("未知季节");
                    break;
            }*/

            //48.根据用户输入的操作符执行不同的数学操作
            /* char operatorSymbol = '+';
             int operand1 = 5;
             int operand2 = 3;
             int result48 = 0;
             switch (operatorSymbol) {
                 case '+':
                     result48 = operand1 + operand2;
                     break;
                 case '-':
                     result48 = operand1 - operand2;
                     break;
                 case '*':
                     result48 = operand1 * operand2;
                     break;
                 case '/':
                     result48 = operand1 / operand2;
                     break;
                 default:
                     Console.WriteLine("无效操作符");
                     break;
             }
             Console.WriteLine("结果：" + result48);*/

            //49.根据用户输入的选项执行不同的功能
            /*int option = 2;
            switch (option) {
                case 1:
                    Console.WriteLine("执行选项1的功能");
                    break;
                case 2:
                    Console.WriteLine("执行选项2的功能");
                    break;
                case 3:
                    Console.WriteLine("执行选项3的功能");
                    break;
                default:
                    Console.WriteLine("未知选项");
                    break;
            }*/

            //50.根据用户输入的汽车品牌输出相关信息
            /*string carBrand = "比亚迪";
            switch (carBrand) {
                case "比亚迪":
                    Console.WriteLine("比亚迪是一家中国汽车制造商。");
                    break;
                case "吉利":
                    Console.WriteLine("吉利汽车以其多样性而闻名。");
                    break;
                default:
                    Console.WriteLine("不熟悉该汽车品牌。");
                    break;
            }*/


        }

    }
}
