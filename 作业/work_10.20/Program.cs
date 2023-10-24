using System;

namespace work_10._20 {
    internal class Program {
        static void Main(string[] args) {

            #region 1.个税计算器

            //税前月薪
            double salary;
            //缴纳基数
            double insuranceBase = 5000;
            Console.Write("请输入您的税前工资：");
            while (true) {
                string input = Console.ReadLine();

                if (double.TryParse(input, out salary)) {
                    //应纳税所得额
                    double taxableIncome = salary - insuranceBase * 0.225 - 3500;

                    //应纳税额
                    Console.WriteLine(taxRate(taxableIncome));
                    break;
                } else {
                    Console.Write("无效输入，请重新输入有效的税前工资：");
                }
            }
            #endregion

            #region 2.判断是否到结婚年龄
            Console.Write("输入你的年龄：");
            double age = Convert.ToDouble(Console.ReadLine());
            if (age >= 23) {
                Console.WriteLine("你该结婚了");
            } else {
                Console.WriteLine($"不着急，还能玩{23 - age}年");
            }
            #endregion

            #region 3.判断成绩是否优秀
            Console.Write("请输入小红的语文成绩:");
            double chineseScores = Convert.ToDouble(Console.ReadLine());
            Console.Write("请输入小红的音乐成绩:");
            double musicScores = Convert.ToDouble(Console.ReadLine());
            if ((chineseScores > 90 && musicScores > 80) || (chineseScores == 100 && musicScores > 70)) {
                Console.WriteLine("恭喜小红取得好成绩，奖励100元！！！");
            } else {
                Console.WriteLine("这次成绩不理想，下次继续加油");
            }
            #endregion

            #region 4.根据成绩打评价
            Console.Write("请输入你的考试成绩：");
            double score = Convert.ToDouble(Console.ReadLine());
            if (score <= 100 && score >= 90) {
                Console.WriteLine("优秀优秀优秀");
            } else if (score < 90 && score >= 70) {
                Console.WriteLine("良好良好良好");
            } else if (score < 70 && score >= 60) {
                Console.WriteLine("及格及格及格");
            } else if (score < 60) {
                Console.WriteLine("不及格！！！！！！");
            } else {
                Console.WriteLine("夺少？？？？？？？");
            }
            #endregion

            #region 5.找出三个数字中最大的，不考虑相等
            Console.Write("请输入第一个数字:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("请输入第二个数字:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("请输入第三个数字:");
            double num3 = Convert.ToDouble(Console.ReadLine());

            double max = num1;
            if (num2 > max) {
                max = num2;
            }
            if (num3 > max) {
                max = num3;
            }
            Console.WriteLine($"{num1}、{num2}、{num3}三个数中最大的是{max}");
            #endregion

            #region 6.输入用户名称、密码
            Console.Write("请输入用户名：");
            string userName = Console.ReadLine();
            Console.Write("请输入密码：");
            string password = Console.ReadLine();
            if (userName == "admin") {
                if (password == "123") {
                    Console.WriteLine("登陆成功");
                } else {
                    Console.WriteLine("密码错误");
                }
            } else {
                Console.WriteLine("该用户名不存在");
            }
            #endregion

            #region 7.do...while输入密码为123 如果不对 继续输入
            string password1 = "123";
            string userInput;
            bool isCorrect = false;
            do {
                Console.Write("请输入密码：");
                userInput = Console.ReadLine();
                if (userInput == password1) {
                    isCorrect = true;
                    Console.WriteLine("密码正确");
                } else {
                    Console.WriteLine("密码错误");
                }
            } while (!isCorrect);
            #endregion

            #region 8.输出1-100
            for (int i = 0; i < 100; i++) {
                Console.WriteLine(i + 1);
            }
            #endregion

            #region 9.输出1-100的和
            double result = 0;
            for (double i = 1; i <= 100; i++) {
                result += i;
            }
            Console.WriteLine(result);
            #endregion

            #region 9.输出1-100的偶数
            for (double i = 1; i <= 100; i++) {
                if (i % 2 == 0) {
                    Console.WriteLine(i);
                }
            }
            #endregion

            #region 10.输出矩形
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 10; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            #endregion

            #region 11.输出直角三角形
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            #endregion

            #region 12.九九乘法表
            for (int i = 1; i < 10; i++) {
                for (int j = 1; j <= i; j++) {
                    Console.Write($"{j}*{i}={i * j}   ");
                }
                Console.WriteLine();
            }
            #endregion

            #region 13.水仙花数
            int start = 100; // 起始范围
            int end = 999;   // 结束范围

            Console.WriteLine($"在范围 {start} 到 {end} 内的水仙花数：");

            for (int num = start; num <= end; num++) {
                if (IsNarcissisticNumber(num)) {
                    Console.WriteLine(num);
                }
            }
            #endregion
        }
        //  个税
        static double taxRate(double taxableIncome) {
            double[] incomeArr = { 1500, 4500, 9000, 35000, 55000, 80000 };
            double[] percentageArr = { 0.03, 0.1, 0.20, 0.25, 0.30, 0.35, 0.45 };
            double[] deductionsArr = { 0, 105, 555, 1005, 2755, 5505, 13505 };

            double tax = 0;
            for (int index = 0; index < incomeArr.Length; index++) {

                if (taxableIncome <= incomeArr[index]) {
                    tax = taxableIncome * percentageArr[index] - deductionsArr[index];
                    break;
                } else if (index == incomeArr.Length - 1) {
                    //超出最大范围
                    tax = taxableIncome * percentageArr[index] - deductionsArr[index];
                }
            }
            return tax;
        }

        // 判断一个数是否为水仙花数
        static bool IsNarcissisticNumber(int number) {
            int originalNumber = number;
            int numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);
            int sum = 0;

            while (number > 0) {
                int digit = number % 10;
                sum += (int)Math.Pow(digit, numberOfDigits);
                number /= 10;
            }

            return sum == originalNumber;
        }
    }
}
