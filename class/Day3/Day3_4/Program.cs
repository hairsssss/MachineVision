using System;

namespace Day3_4 {
    internal class Program {
        static void Main(string[] args) {
            //算术运算符  
            // +  -  *  /  %数字类型大类型和小类型结合 结果默认为大类型结果
            string strNumber = "123";
            string strNumber1 = "123";
            int intNumber = 123;
            Console.WriteLine(intNumber + strNumber1);

            Program program = new Program();
            Program program1 = new Program();
            //Console.WriteLine(program + program1);
            //不允许非数字类型和字符串类型直接使用 +  需要使用运算符重载

            //二义性错误？？？？？？？？？？？？？？
            long longNumber = 111;
            ulong uLongNumber = 111;
            //Console.WriteLine(longNumber + uLongNumber);

            //非数字类型不能直接使用 - 
            //单字符使用 - 时会隐式转换为数字类型
            int intNumber2 = 200;
            int intNumber3 = 20;
            string strNumber2 = "123";
            char charNumber1 = '1';
            float floatNumber1 = 1.1f;
            long longNumber1 = 12;
            Console.WriteLine(intNumber2 - intNumber3);
            Console.WriteLine(charNumber1 - intNumber3);
            Console.WriteLine(floatNumber1 - intNumber3);
            Console.WriteLine(longNumber1 * intNumber3);
            Console.WriteLine((longNumber1 * intNumber3).GetType());
            //Console.WriteLine(strNumber2 - intNumber3);

            // ++ -- 变量自身自增或自减1
            int intNumber4 = 100;
            intNumber4++;
            ++intNumber4;
            int intNumber5 = intNumber4++;
            Console.WriteLine(intNumber5);
            Console.WriteLine(++intNumber4);
        }
    }
}
/*
 
  将所有数据类型进行一次 + - * / 运算  课件
  笔记
  unicode码 人名
  自找使用TryParse()知识点完成的作业  结合现有知识写例子
  随机抽人 先抽组  倒数3秒后抽人
 */