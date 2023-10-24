using System;
using System.Threading;
namespace work_10._19 {

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

    internal class Program {
        static void Main(string[] args) {
            // 输入字符转为unicode
            /* string str = Console.ReadLine();
             byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
             StringBuilder sr = new StringBuilder();
             foreach (byte b1 in bytes) {
                 sr.Append(b1.ToString("X"));
             }
             Console.WriteLine(sr.ToString());*/

            // + - * /

            #region 值类型运算
            int intNum = 1;
            uint uintNum = 6;
            byte byteNum = 1;
            sbyte sbyteNum = 1;
            char charNum = '单';
            double doubleNum = 1;
            decimal decimalNum = 9.9m;
            float floatNum = 5.5f;
            long longNum = 12;
            ulong ulongNum = 1;
            short shortNum = 999;
            ushort ushortNum = 999;
            bool boolNum = true;

            Console.WriteLine(intNum + byteNum);
            Console.WriteLine(intNum + doubleNum);
            Console.WriteLine(intNum + floatNum);
            Console.WriteLine(intNum + longNum);
            Console.WriteLine(intNum + uintNum);
            Console.WriteLine(intNum + sbyteNum);
            Console.WriteLine(intNum + charNum);
            Console.WriteLine(intNum + decimalNum);
            Console.WriteLine(intNum + shortNum);
            //Console.WriteLine(intNum + boolNum);  // int和bool类型无法运算
            Console.WriteLine(intNum + shortNum);

            Console.WriteLine(intNum - byteNum);
            Console.WriteLine(intNum - doubleNum);
            Console.WriteLine(intNum - floatNum);
            Console.WriteLine(intNum - longNum);
            Console.WriteLine(intNum - uintNum);
            Console.WriteLine(intNum - sbyteNum);
            Console.WriteLine(intNum - charNum);
            Console.WriteLine(intNum - decimalNum);
            Console.WriteLine(intNum - shortNum);

            Console.WriteLine(intNum * byteNum);
            Console.WriteLine(intNum * doubleNum);
            Console.WriteLine(intNum * floatNum);
            Console.WriteLine(intNum * longNum);
            Console.WriteLine(intNum * uintNum);
            Console.WriteLine(intNum * sbyteNum);
            Console.WriteLine(intNum * charNum);
            Console.WriteLine(intNum * decimalNum);
            Console.WriteLine(intNum * shortNum);

            Console.WriteLine(intNum / byteNum);
            Console.WriteLine(intNum / doubleNum);
            Console.WriteLine(intNum / floatNum);
            Console.WriteLine(intNum / longNum);
            Console.WriteLine(intNum / uintNum);
            Console.WriteLine(intNum / sbyteNum);
            Console.WriteLine(intNum / charNum);
            Console.WriteLine(intNum / decimalNum);
            Console.WriteLine(intNum / shortNum);
            //Console.WriteLine(intNum + ulongNum);   不可执行 出现具有二义性错误   二义性错误：在C#中，当编译器无法确定应该使用哪个重载版本的方法或运算符时，就会出现二义性错误。这通常发生在你尝试对两种不同类型的操作数执行操作，而编译器找到了多个可能的匹配的方法或运算符。 longNumber 是long 类型，  uLongNumber  是  ulong  类型。当你尝试将它们相加时，编译器无法确定应该将它们都转换为  long  还是都转换为  ulong  。因此，编译器报告了二义性错误。
            #endregion

            #region +-*/运算符练习

            Console.WriteLine("请输入第一个数字");
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
            Console.ReadKey();
            #endregion


            #region  TryParse
            string str1 = "120", str2 = "120.10", str3 = "s120";
            int convertedInt1, convertedInt2, convertedInt3;

            //True
            Console.WriteLine("Conversion: {0}, converted value: {1}", int.TryParse(str1, out convertedInt1), convertedInt1);

            //False
            Console.WriteLine("Conversion: {0}, converted value: {1}", int.TryParse(str2, out convertedInt2), convertedInt2);

            //False
            Console.WriteLine("Conversion: {0}, converted value: {1}", int.TryParse(str3, out convertedInt3), convertedInt3);

            string str4 = "120.30";
            string str5 = "120.40";
            double convertedDouble;
            float convertedFloat;

            //True
            Console.WriteLine("Conversion: {0}, converted value: {1}", double.TryParse(str4, out convertedDouble), convertedDouble);

            //True
            Console.WriteLine("Conversion: {0}, converted value: {1}", float.TryParse(str5, out convertedFloat), convertedFloat);
            #endregion

            #region   随机点名
            // 定义多维数组，一共五组 数组中为各组的成员
            string[][] nameArr = new string[5][];
            nameArr[0] = new string[] { "刘凯", "贺义杰", "张钊宾", "姬丙权", "来晨龙", "彭哲", "王齐林", "王浩", "刘林昌", "陈柯先" };
            nameArr[1] = new string[] { "黄畅", "王嫁吉", "曹克强", "武文起", "杨凯旋", "刘天一", "王浩杰", "韩云鹤", "朱琪申" };
            nameArr[2] = new string[] { "张淙琦", "熊明", "董博达", "童劲阳", "秦豪杰", "王红杰" };
            nameArr[3] = new string[] { "宋国豪", "王乾", "崔金波", "陈家栋", "周萌浩", "谷浩杰", "刘帅", "原家琪" };
            nameArr[4] = new string[] { "王嘉琪", "冯金丽", "周丽文", "杨震", "徐泽松", "吉兆雨", "张海鹏", "程龙" };

            Console.WriteLine("请按任意键开始抽取组别。");
            Console.ReadKey();

            int countdown = 5;

            //抽取组别
            Random random = new Random();
            int groupRd = random.Next(0, 5);

            Console.WriteLine("倒计时开始");
            for (int i = countdown; i >= 1; i--) {
                Console.WriteLine(i);
                Thread.Sleep(1000); // 暂停 1 秒
            }
            Console.WriteLine($"倒计时结束，幸运组为第{groupRd + 1}组。");

            //抽取组别中的成员
            Console.WriteLine("请按任意键开始抽取获奖人员。");
            Console.ReadKey();
            int groupLength = nameArr[groupRd].Length;
            int groupRd1 = random.Next(0, groupLength);

            for (int i = countdown; i >= 1; i--) {
                Console.WriteLine(i);
                Thread.Sleep(1000); // 暂停 1 秒
            }

            Console.WriteLine(groupRd1);
            Console.WriteLine($"倒计时结束，获奖人员是第{groupRd + 1}组的{nameArr[groupRd][groupRd1]}。");

            #endregion
        }
    }
}
