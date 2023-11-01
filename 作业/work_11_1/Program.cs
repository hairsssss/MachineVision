using System;

namespace work_11_1 {
    internal class Program {
        static void Main(string[] args) {
            #region 1、计算器
            /*Console.Write("请输入第一个数字：");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("请输入（+ - * /）其中任一运算符：");
            char op = Convert.ToChar(Console.ReadLine());

            Console.Write("请输入第二个数字：");
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

            Console.WriteLine($"{num1}{op}{num2}={result}");*/
            #endregion

            #region 2、辅助计算
            /*Console.Write("请输入1或2用来选择一年级或二年级：");
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int grade) && (grade == 1 || grade == 2)) {
                    AuxiliaryCalculation student = new AuxiliaryCalculation(grade);
                    break;
                } else {
                    Console.Write("格式错误，请重新输入年级：");
                }
            }

            while (AuxiliaryCalculation._Conut < 3) {
                AuxiliaryCalculation.Multiplication();
                while (true) {
                    Console.Write("请输入你的答案：");
                    if (int.TryParse(Console.ReadLine(), out int answer)) {
                        if (answer == AuxiliaryCalculation._Result) {
                            Console.WriteLine("Very good!");
                            AuxiliaryCalculation._Conut += 1;
                            break;
                        } else {
                            Console.WriteLine("No,Please try again.");
                        }
                    } else {
                        Console.Write("格式错误，请重新输入：");
                    }
                }
            }
            if (AuxiliaryCalculation._Conut == 3) {
                Console.WriteLine("恭喜你三题全部答对！");
            }*/
            #endregion

            #region 4、重载计算
            int resultInt = CalculatorOverload.Add(5, 10);
            Console.WriteLine($"{resultInt}----int");

            double resultDouble = CalculatorOverload.Add(5.1, 10.8);
            Console.WriteLine($"{resultDouble}----double");
            #endregion
        }

        // 1、计算器
        internal static class Calculator {
            internal static double Add(double x, double y) {
                return x + y;

            }
            internal static double Reduce(double num, double num1) {
                return num - num1;
            }
            internal static double Multiplication(double num, double num1) {
                return num * num1;
            }
            internal static double Division(double num, double num1) {
                if (num1 != 0) return num / num1;
                else throw new DivideByZeroException("除数不能为0");
            }
        }


        //2、辅助计算
        internal class AuxiliaryCalculation {
            public static int _Grade { get; set; }
            public static double _Result { get; set; }
            public static double _Num1 { get; set; }
            public static double _Num2 { get; set; }
            public static double _Conut { get; set; }
            public AuxiliaryCalculation(int grade) {
                _Grade = grade;
            }

            internal static double Multiplication() {
                Random random = new Random();

                if (_Grade == 1) {
                    _Num1 = random.Next(0, 10);
                    _Num2 = random.Next(0, 10);
                } else {

                    _Num1 = random.Next(10, 100);
                    _Num2 = random.Next(10, 100);
                }

                _Result = _Num1 * _Num2;
                Console.WriteLine($"{_Num1}*{_Num2}=?");
                return _Result;
            }
        }

        //3、构造函数
        public class PrivateFunction {
            private static PrivateFunction instance;

            // 私有构造函数，防止外部直接实例化
            private PrivateFunction() {
            }

            public static PrivateFunction GetInstance() {
                if (instance == null) {
                    instance = new PrivateFunction();
                }
                return instance;
            }
        }

        public class InstanceFunction {
            public string Name { get; set; }
            public int Age { get; set; }
            // 实例构造函数
            public InstanceFunction(string name, int age) {
                Name = name;
                Age = age;
            }
        }

        public class StaticFunction {
            public static int Add(int a, int b) {
                return a + b;
            }
            // 静态构造函数
            static StaticFunction() {
                Console.WriteLine("MyMath class is initialized.");
            }
        }

        // 4、重载计算器
        internal static class CalculatorOverload {
            internal static double Add(double x, double y) {
                return x + y;

            }
            internal static double Reduce(double num, double num1) {
                return num - num1;
            }
            internal static double Multiplication(double num, double num1) {
                return num * num1;
            }
            internal static double Division(double num, double num1) {
                if (num1 != 0) return num / num1;
                else throw new DivideByZeroException("除数不能为0");
            }


            // 重载
            internal static int Add(int x, int y) {
                return x + y;

            }
            internal static int Reduce(int num, int num1) {
                return num - num1;
            }
            internal static int Multiplication(int num, int num1) {
                return num * num1;
            }
            internal static int Division(int num, int num1) {
                if (num1 != 0) return num / num1;
                else throw new DivideByZeroException("除数不能为0");
            }
        }
    }
}
