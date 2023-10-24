using System;
namespace work_10._21 {
    internal class Program {
        static void Main(string[] args) {
            #region if
            //1.编写一个if语句，检查一个数字是否为正数。
            /*Console.Write("请输入一个任意数字：");
            double num = Convert.ToDouble(Console.ReadLine());
            if (num > 0) {
                Console.WriteLine($"{num}是正数");
            } else {
                Console.WriteLine($"{num}不是正数");
            }*/

            //2.创建一个if - else语句，检查一个年份是否为闰年。
            //可以被4整除且不能被100整除或者可以被400整除的为闰年
            /* while (true) {
                 Console.Write("请输入一个任意年份：");
                 string yearStr = Console.ReadLine();
                 if (double.TryParse(yearStr, out double year)) {
                     if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) {
                         Console.WriteLine($"{year}年是闰年");
                         break;
                     } else {
                         Console.WriteLine($"{year}不是闰年");
                         break;
                     }
                 } else {
                     Console.WriteLine("年份格式错误，请重新输入");
                 }
             }*/

            //3.编写一个if语句，检查一个字符串是否为空。
            /*Console.Write("请输入任意字符:");
            while (true) {
                string str3 = Console.ReadLine();
                if (string.IsNullOrEmpty(str3)) {
                    Console.WriteLine($"空字符串{str3}");
                } else {
                    Console.WriteLine($"非空字符串--{str3}--，请重新输入：");
                }
            }*/

            //4.创建一个if - else语句，检查一个数是否为偶数。
            /*string input4;
            bool isNum = false;
            Console.Write("请输入一个数字：");
            while (true) {
                input4 = Console.ReadLine();
                isNum = double.TryParse(input4, out double num4);
                if (isNum) {
                    if (num4 % 2 == 0) {
                        Console.WriteLine($"{num4}是偶数");
                        break;
                    } else {
                        Console.WriteLine($"{num4}不是偶数");
                        break;
                    }
                } else {
                    Console.Write("请输入正确的数字：");
                }
            }*/

            //5.编写一个if语句，检查一个用户输入的数字是否大于、等于或小于10。
            /*Console.Write("请输入一个数字：");
            string str5;
            while (true) {
                str5 = Console.ReadLine();
                if (double.TryParse(str5, out double result5)) {
                    if (result5 >= 10) {
                        Console.WriteLine($"{result5}>=10");
                        break;
                    } else {
                        Console.WriteLine($"{result5}<10");
                        break;
                    }
                } else {
                    Console.Write("请重新输入一个正确的数字");
                }
            }*/

            //6.创建一个if -else if-else语句，根据分数判断学生的等级（A、B、C、D、F）。
            /* Console.Write("请输入你的成绩：");
             string input6;
             while (true) {
                 input6 = Console.ReadLine();
                 if (double.TryParse(input6, out double result)) {
                     if (result >= 90) {
                         Console.WriteLine("A");
                     } else if (result >= 80) {
                         Console.WriteLine("B");
                     } else if (result >= 80) {
                         Console.WriteLine("C");
                     } else if (result >= 80) {
                         Console.WriteLine("D");
                     } else {
                         Console.WriteLine("E");
                     }
                     break;
                 } else {
                     Console.Write("请输入正确的成绩：");
                 }
             }*/

            //7.编写一个if语句，检查一个字符串是否以特定的前缀开头。
            /*Console.Write("请输入：");
            string input7 = Console.ReadLine();
            Console.WriteLine(input7.StartsWith(","));*/

            //8.创建一个if - else语句，检查一个数字是否为质数。
            /*Console.Write("请输入一个数字：");
            string input8;
            while (true) {
                input8 = Console.ReadLine();
                if (double.TryParse(input8, out double result)) {
                    for (double i = 2; i < result; i++) {
                        if (result % i == 0) {
                            Console.WriteLine($"{result}不是质数");
                            break;
                        } else {
                            Console.WriteLine($"{result}是质数");
                            break;
                        }
                    }
                } else {
                    Console.Write("请输入一个正确的数字：");
                }
            }*/

            //9.编写一个if语句，检查一个年龄是否在18到65之间，以判断是否是工作年龄。
            /*Console.Write("请输入你的年龄：");
            string input9;
            while (true) {
                input9 = Console.ReadLine();
                if (double.TryParse(input9, out double result)) {
                    if (result >= 18 && result <= 65) {
                        Console.WriteLine("你还不能退休呢~~~~~~");
                        break;
                    } else {
                        Console.WriteLine("不在工作年龄范围内哦！！！！！！");
                        break;
                    }
                } else {
                    Console.Write("请输入正确的年龄：");
                }
            }*/

            //10.创建一个if - else语句，检查一个字符是否是元音字母。
            /*Console.Write("请输入一个字母：");
            string input10;
            double index10;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            while (true) {
                input10 = Console.ReadLine();
                if (char.TryParse(input10, out char result)) {
                    index10 = Array.IndexOf(vowels, result);
                    if (index10 != -1) {
                        Console.Write($"{result}是元音字母");
                        break;
                    } else {
                        Console.Write($"{result}不是元音字母");
                        break;
                    }
                } else {
                    Console.Write("请重新输入：");
                }
            }*/

            //11.使用while循环输出1到10的数字。
            /*double index11 = 0;
            while (index11 < 10) {
                index11++;
                Console.WriteLine(index11);
            }*/

            //12.创建一个while循环，计算一个数的阶乘。
            /* Console.Write("请输入一个正整数：");
             int num12 = Convert.ToInt32(Console.ReadLine());
             double index12 = 1;
             double result12 = 1;
             while (index12 <= num12) {
                 result12 *= index12;
                 index12++;
             }
             Console.WriteLine(result12);*/

            //13.使用while循环找到一个整数的所有因子。
            /*Console.Write("请输入一个正整数：");
            int num12 = Convert.ToInt32(Console.ReadLine());
            int index13 = 0;
            while (index13 < num12) {
                index13++;
                if (num12 % index13 == 0) {
                    Console.WriteLine(index13);
                }
            }*/

            //14.创建一个while循环，反转一个字符串。
            /*Console.WriteLine("请输入：");
            string str14 = Console.ReadLine();
            string newStr14 = "";
            int index12 = str14.Length;
            while (index12 != 0) {
                index12--;
                newStr14 += str14[index12];
            }
            Console.WriteLine(newStr14);*/

            //15.使用while循环计算一个数的平方根。
            /*Console.Write("请输入一个数：");
            double number15 = Convert.ToDouble(Console.ReadLine());

            double guess = number15 / 2; // 初始猜测值为数的一半
            double epsilon = 0.0001; // 精度要求

            while (Math.Abs(guess * guess - number15) > epsilon) {
                guess = (guess + number15 / guess) / 2; // 使用牛顿迭代法更新猜测值
            }

            Console.WriteLine($"数的平方根为：{guess}");*/

            //16.创建一个while循环，模拟一个简单的猜数字游戏。
            /*Random random = new Random();
            int secretNumber = random.Next(1, 100);  // 生成一个1到100之间的随机数
            int guess;

            Console.WriteLine("欢迎来到猜数字游戏！请猜一个1到100之间的数字。");

            while (true) {
                Console.Write("请输入你的猜测：");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess)) {
                    Console.WriteLine("无效的输入，请输入一个数字。");
                    continue;
                }

                if (guess < secretNumber) {
                    Console.WriteLine("太小了！");
                } else if (guess > secretNumber) {
                    Console.WriteLine("太大了！");
                } else {
                    Console.WriteLine("恭喜你，猜对了！");
                    break;
                }
            }*/

            //17.创建一个do-while循环，提示用户输入他们的年龄，只有当年龄大于等于18时才终止循环。
            /*int age17;
            do {
                Console.Write("请输入你的年龄：");
                age17 = int.Parse(Console.ReadLine());

            } while (age17 != 18);*/

            //18.使用do-while循环计算并打印出1到10的平方数，一直循环到平方数大于100。
            /*int total = 0;
            int index18 = 1;
            do {
                total = index18 * index18;
                index18++;
                Console.WriteLine(total);
            } while (total <= 100);*/

            //19.创建一个do-while循环，接受用户输入的整数，只有当输入的整数为正数时才终止循环。
            /*int input19;
            do {
                Console.Write("请输入一个整数：");
                input19 = int.Parse(Console.ReadLine());
            } while (input19 <= 0);*/

            //20.使用do-while循环模拟一个简单的倒计时程序，从用户输入的秒数开始倒计时，直到倒计时结束。
            /*int input20;
            Console.Write("请输入倒计时时间：");
            input20 = int.Parse(Console.ReadLine());
            do {
                Thread.Sleep(1000); // 暂停 1 秒
                input20 -= 1;
                Console.WriteLine(input20 + 1);
            } while (input20 > 0);
            Console.WriteLine("倒计时结束！");*/

            //21、创建一个do-while循环，要求用户输入一个数字，然后使用if语句检查它是否为正数，只有在输入正数时才终止循环。
            /*string str21;
            int num21;
            Console.Write("请输入一个数字：");
            do {
                str21 = Console.ReadLine();
                if (int.TryParse(str21, out num21)) {
                    if (num21 > 0) {
                        Console.WriteLine($"{num21}为正数，终止循环。");
                        break;
                    } else {
                        Console.Write("请重新输入一个数字：");
                    }
                } else {
                    Console.Write("无效数字，请重新输入：");
                }
            } while (num21 <= 0);*/

            //22、使用do-while循环模拟一个简单的登录系统，要求用户输入用户名和密码，然后使用if语句检查它们是否匹配，只有在匹配时才终止循环。
            /*  string username22;
              string password22;
              do {
                  Console.Write("请输入用户名：");
                  username22 = Console.ReadLine();

                  Console.Write("请输入密码：");
                  password22 = Console.ReadLine();

                  if (username22 == "admin" && password22 == "password") {
                      Console.WriteLine("登录成功！");
                      break;
                  } else {
                      Console.WriteLine("用户名或密码错误，请重新输入。");
                  }
              } while (true);*/

            //23、编写一个do-while循循环，接受用户输入的数字，然后使用if语句检查它是否为偶数，只有在输入偶数时才终止循环。
            /*int number23;
            bool isEven23;

            do {
                Console.Write("请输入一个整数: ");
                string input = Console.ReadLine();
                // 尝试将用户输入的字符串转换为整数
                if (int.TryParse(input, out number23)) {
                    isEven23 = number23 % 2 == 0;
                    if (isEven23) {
                        Console.WriteLine($"输入的数字 {number23} 是偶数，循循环终止。");
                    } else {
                        Console.WriteLine($"输入的数字 {number23} 不是偶数，请继续输入。");
                    }
                } else {
                    Console.WriteLine("无效的输入，请输入一个整数。");
                    isEven23 = false; // 设置isEven为false以保持循环进行
                }
            } while (!isEven23); // 当输入的数字不是偶数时继续循环*/

            //24、创建一个do-while循环，要求用户输入一个字符，然后使用if语句检查它是否为元音字母，只有在输入元音字母时才终止循环。
            /*char inputChar24;
            bool isVowe24 = false;

            do {
                Console.Write("请输入一个字母: ");
                string input = Console.ReadLine();

                if (input.Length == 1) {
                    inputChar24 = char.ToLower(input[0]);

                    if (inputChar24 == 'a' || inputChar24 == 'e' || inputChar24 == 'i' || inputChar24 == 'o' || inputChar24 == 'u') {
                        isVowe24 = true;
                        Console.WriteLine($"您输入的字符 '{inputChar24}' 是元音字母，循环终止。");
                    } else {
                        Console.WriteLine($"您输入的字符 '{inputChar24}' 不是元音字母，请继续输入。");
                    }
                } else {
                    Console.WriteLine("无效的输入，请只输入一个字母。");
                    isVowe24 = false; // 设置isVowel为false以保持循环进行
                }
            } while (!isVowe24); // 当输入的字符不是元音字母时继续循环*/

            //25、使用do-while循环模拟一个简单的猜数字游戏，生成一个随机数，要求用户猜这个数字，然后使用if语句检查猜测是否正确，只有在猜中时才终止循环。
            /*Random random25 = new Random();
            int targetNumber25 = random25.Next(1, 101);

            int guess25;
            bool isCorrect = false;
            int attempts = 0;

            Console.WriteLine("欢迎来到猜数字游戏！");

            do {
                Console.Write("请输入您猜的数字 (1-100): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out guess25)) {
                    attempts++;

                    if (guess25 == targetNumber25) {
                        isCorrect = true;
                        Console.WriteLine($"恭喜！您猜中了数字 {targetNumber25}，用了 {attempts} 次尝试。");
                    } else if (guess25 < targetNumber25) {
                        Console.WriteLine("猜的数字太小，请再试一次。");
                    } else {
                        Console.WriteLine("猜的数字太大，请再试一次。");
                    }
                } else {
                    Console.WriteLine("无效的输入，请输入一个整数 (1-100)。");
                }

            } while (!isCorrect);*/

            //26、创建一个while循环，接受用户输入的数字，然后使用if语句检查它是否为质数，只有在输入质数时才终止循环。
            /*int number26;
            bool isPrime26 = false;

            Console.WriteLine("欢迎来到质数检查程序！");
            while (true) {
                Console.Write("请输入一个整数: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number26)) {
                    if (number26 <= 1) {
                        isPrime26 = false;
                    } else {
                        isPrime26 = true;
                        for (int i = 2; i <= Math.Sqrt(number26); i++) {
                            if (number26 % i == 0) {
                                isPrime26 = false;
                                break;
                            }
                        }
                    }
                    if (isPrime26) {
                        Console.WriteLine($"输入的数字 {number26} 是质数，循环终止。");
                        break; // 质数检查通过，退出循环
                    } else {
                        Console.WriteLine($"输入的数字 {number26} 不是质数，请继续输入。");
                    }
                } else {
                    Console.WriteLine("无效的输入，请输入一个整数。");
                }
            }*/

            //27、使用while循环模拟一个简单的购物清单，要求用户不断添加物品，然后使用if语句检查是否继续购物，只有在用户不想继续时才终止循环。
            /*List<string> shoppingList = new List<string>();
            bool continueShopping = true;

            Console.WriteLine("欢迎使用购物清单程序！");

            while (continueShopping) {
                Console.Write("请输入要添加到购物清单的物品: ");
                string item = Console.ReadLine();
                shoppingList.Add(item);

                Console.Write("是否继续购物？(y/n): ");
                string response = Console.ReadLine().ToLower();

                if (response != "y") {
                    continueShopping = false;
                }
            }

            Console.WriteLine("购物清单内容：");
            foreach (string item in shoppingList) {
                Console.WriteLine(item);
            }*/

            //28、编写一个while循环，接受用户输入的数字，直到用户输入的数字等于某个特定值，然后使用if语句终止循环。
            /*int targetValue = 42;
            int userInput;

            Console.WriteLine("请输入一个整数，直到输入值等于42时循环将终止。");

            while (true) {
                Console.Write("请输入一个整数: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userInput)) {
                    if (userInput == targetValue) {
                        Console.WriteLine("输入的值等于42，循环终止。");
                        break;
                    }
                } else {
                    Console.WriteLine("无效的输入，请输入一个整数。");
                }
            }*/

            //29、创建一个while循环，模拟一个密码重置系统，要求用户不断输入新密码，然后使用if语句检查密码的复杂度，只有在密码足够复杂时才终止循环。
            /*string password29;
            bool isComplex = false;

            Console.WriteLine("欢迎使用密码重置系统！");

            while (!isComplex) {
                Console.Write("请输入新密码: ");
                password29 = Console.ReadLine();

                if (IsPasswordComplex(password29)) {
                    isComplex = true;
                    Console.WriteLine("密码已重置，复杂度足够高。");
                } else {
                    Console.WriteLine("密码复杂度不足，请继续输入。");
                }
            }*/

            //30、使用while循环模拟一个简单的考试系统，要求学生一直回答问题，然后使用if语句检查他们的答案是否正确，只有在答对特定数量的问题时才终止循环。
            int correctAnswers = 0;
            int requiredCorrectAnswers = 3; // 要求答对的问题数量

            Console.WriteLine("欢迎来到考试系统！");

            while (correctAnswers < requiredCorrectAnswers) {
                Console.WriteLine("请回答以下问题：");

                Console.WriteLine("1. 2 + 2 = ?");
                int answer1 = int.Parse(Console.ReadLine());

                if (answer1 == 4) {
                    Console.WriteLine("回答正确！");
                    correctAnswers++;
                } else {
                    Console.WriteLine("回答错误。");
                }

                Console.WriteLine("2. 10 - 5 = ?");
                int answer2 = int.Parse(Console.ReadLine());

                if (answer2 == 5) {
                    Console.WriteLine("回答正确！");
                    correctAnswers++;
                } else {
                    Console.WriteLine("回答错误。");
                }

                Console.WriteLine("3. 3 * 4 = ?");
                int answer3 = int.Parse(Console.ReadLine());

                if (answer3 == 12) {
                    Console.WriteLine("回答正确！");
                    correctAnswers++;
                } else {
                    Console.WriteLine("回答错误。");
                }

                if (correctAnswers < requiredCorrectAnswers) {
                    Console.WriteLine("您需要回答正确更多问题以完成考试。");
                }
            }

            Console.ReadKey();
            #endregion
        }
        static bool IsPasswordComplex(string password) {
            if (password.Length < 8) {
                return false;
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;

            foreach (char character in password) {
                if (char.IsUpper(character)) {
                    hasUppercase = true;
                } else if (char.IsLower(character)) {
                    hasLowercase = true;
                } else if (char.IsDigit(character)) {
                    hasDigit = true;
                }

                if (hasUppercase && hasLowercase && hasDigit) {
                    return true;
                }
            }

            return false;
        }
    }

}
