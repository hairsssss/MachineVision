using System;

namespace work_10._24 {
    internal class Program {
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
        static void Main(string[] args) {
            //1.使用swtich让用户在控制台中分别录入2个数字，1个运算符，根据运算符计算数字.
            /* Console.WriteLine("请输入第一个数字");
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

             Console.WriteLine(result);
             Console.ReadKey();*/

            //任意输入两个数字，两数字之和大于100 加1分 反之减一分 分数小于-10或者大于10输入结束
            //for
            /*int scoreFor = 0;
            for (; ; ) {
                Console.Write("请输入第一个数字：");
                string strInput1 = Console.ReadLine();
                Console.Write("请输入第二个数字：");
                string strInput2 = Console.ReadLine();

                if (int.TryParse(strInput1, out int num1)) {
                    if (int.TryParse(strInput2, out int num2)) {

                        if (num1 + num2 > 100) {
                            scoreFor += 1;
                        } else {
                            scoreFor -= 1;
                        }

                    } else {
                        Console.Write("输入格式错误请重新输入：");
                    }

                } else {
                    Console.Write("输入格式错误请重新输入：");
                }

                if (scoreFor < -10 || scoreFor > 10) {
                    Console.WriteLine(scoreFor);
                    break;
                }
            }*/

            //while
            /* int scoreWhile = 0;
             while (true) {
                 Console.Write("请输入第一个数字：");
                 string strInput1 = Console.ReadLine();
                 Console.Write("请输入第二个数字：");
                 string strInput2 = Console.ReadLine();

                 if (int.TryParse(strInput1, out int num1)) {
                     if (int.TryParse(strInput2, out int num2)) {

                         if (num1 + num2 > 100) {
                             scoreWhile += 1;
                         } else {
                             scoreWhile -= 1;
                         }

                     } else {
                         Console.Write("输入格式错误请重新输入：");
                     }

                 } else {
                     Console.Write("输入格式错误请重新输入：");
                 }

                 if (scoreWhile < -10 || scoreWhile > 10) {
                     Console.WriteLine(scoreWhile);
                     break;
                 }
             }*/

            //do while
            /* int scoreDo = 0;
             bool exit = false;
             do {
                 Console.Write("请输入第一个数字：");
                 string strInputDo1 = Console.ReadLine();

                 Console.Write("请输入第二个数字：");
                 string strInputDo2 = Console.ReadLine();

                 if (int.TryParse(strInputDo1, out int num1)) {
                     if (int.TryParse(strInputDo2, out int num2)) {

                         if (num1 + num2 > 100) {
                             scoreDo += 1;
                         } else {
                             scoreDo -= 1;
                         }

                     } else {
                         Console.Write("输入格式错误请重新输入：");
                     }

                 } else {
                     Console.Write("输入格式错误请重新输入：");
                 }

                 if (scoreDo < -10 || scoreDo > 10) {
                     Console.WriteLine(scoreDo);
                     exit = true;
                 }

                 Console.WriteLine($"scoreDo------{scoreDo}");
                 Console.WriteLine($"exit------{exit}");
             } while (!exit);*/

            //goto  
            /*  int scoreGoto = 0;
          start:

              Console.Write("请输入第一个数字：");
              string strInputGoTo1 = Console.ReadLine();

              Console.Write("请输入第二个数字：");
              string strInputGoTo2 = Console.ReadLine();

              if (int.TryParse(strInputGoTo1, out int num1)) {
                  if (int.TryParse(strInputGoTo2, out int num2)) {

                      if (num1 + num2 > 100) {
                          scoreGoto += 1;
                      } else {
                          scoreGoto -= 1;
                      }

                  } else {
                      Console.Write("输入格式错误请重新输入：");
                      goto start;
                  }

              } else {
                  Console.Write("输入格式错误请重新输入：");
                  goto start;
              }
              if (scoreGoto < -10 || scoreGoto > 10) {
                  Console.WriteLine($"scoreDo------{scoreGoto}");
              } else {
                  goto start;
              }
              Console.ReadKey();*/

            //编写一个do-while循循环，接受用户输入的数字，然后使用if语句检查它是否为偶数，只有在输入偶数时才终止循环。
            /*int number3;
            bool isEven3;

            do {
                Console.Write("请输入一个整数: ");
                string input = Console.ReadLine();
                // 尝试将用户输入的字符串转换为整数
                if (int.TryParse(input, out number3)) {
                    isEven3 = number3 % 2 == 0;
                    if (isEven3) {
                        Console.WriteLine($"输入的数字 {number3} 是偶数，循循环终止。");
                    } else {
                        Console.WriteLine($"输入的数字 {number3} 不是偶数，请继续输入。");
                    }
                } else {
                    Console.WriteLine("无效的输入，请输入一个整数。");
                    isEven3 = false; // 设置isEven为false以保持循环进行
                }
            } while (!isEven3); // 当输入的数字不是偶数时继续循环*/

            //创建一个do-while循环，要求用户输入一个字符，然后使用if语句检查它是否为元音字母，只有在输入元音字母时才终止循环。
            /* char inputChar4;
             bool isVowe4 = false;

             do {
                 Console.Write("请输入一个字母: ");
                 string input = Console.ReadLine();

                 if (input.Length == 1) {
                     inputChar4 = char.ToLower(input[0]);

                     if (inputChar4 == 'a' || inputChar4 == 'e' || inputChar4 == 'i' || inputChar4 == 'o' || inputChar4 == 'u') {
                         isVowe4 = true;
                         Console.WriteLine($"您输入的字符 '{inputChar4}' 是元音字母，循环终止。");
                     } else {
                         Console.WriteLine($"您输入的字符 '{inputChar4}' 不是元音字母，请继续输入。");
                     }
                 } else {
                     Console.WriteLine("无效的输入，请只输入一个字母。");
                     isVowe4 = false; // 设置isVowel为false以保持循环进行
                 }
             } while (!isVowe4); // 当输入的字符不是元音字母时继续循环*/

            //使用do-while循环模拟一个简单的猜数字游戏，生成一个随机数，要求用户猜这个数字，然后使用if语句检查猜测是否正确，只有在猜中时才终止循环。
            /* Random random5 = new Random();
             int targetNumber5 = random5.Next(1, 101);

             bool isCorrect = false;
             int attempts = 0;

             Console.WriteLine("欢迎来到猜数字游戏！");

             do {
                 Console.Write("请输入您猜的数字 (1-100): ");
                 string input = Console.ReadLine();

                 if (int.TryParse(input, out int guess5)) {
                     attempts++;

                     if (guess5 == targetNumber5) {
                         isCorrect = true;
                         Console.WriteLine($"恭喜！您猜中了数字 {targetNumber5}，用了 {attempts} 次尝试。");
                     } else if (guess5 < targetNumber5) {
                         Console.WriteLine("猜的数字太小，请再试一次。");
                     } else {
                         Console.WriteLine("猜的数字太大，请再试一次。");
                     }
                 } else {
                     Console.WriteLine("无效的输入，请输入一个整数 (1-100)。");
                 }

             } while (!isCorrect);*/

            //输出1到10的数字
            /*int i10 = 1;
        start10:
            if (i10 <= 10) {
                Console.WriteLine(i10);
                i10++;
                goto start10;
            }*/

            //如何在发生异常时使用goto跳转到错误处理代码块。
            /*int number = 0;
        input:
            Console.Write("请输入一个整数: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number)) {
                // 输入有效，继续执行
                Console.WriteLine($"输入的数字是: {number}");
            } else {
                // 输入无效，跳转到重新输入
                Console.WriteLine("无效的输入，请重新输入。");
                goto input;
            }*/

            //使用goto语句跳出多层嵌套循环。
            for (int i = 1; i <= 3; i++) {
                for (int j = 1; j <= 3; j++) {
                    Console.WriteLine($"i = {i}, j = {j}");

                    if (i == 2 && j == 2) {
                        Console.WriteLine("跳出循环");
                        goto end;
                    }
                }
            }

        end:
            Console.WriteLine("程序结束");

        }
    }
}
