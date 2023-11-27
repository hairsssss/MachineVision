using System;

namespace Day3_3 {
    internal class Program {
        static void Main(string[] args) {
            //数据类型转换
            //1.隐式类型转换和显性类型转换

            int intNumber = 1;
            //int转long     小区间转大区间（隐式类型转换）
            long longNumber = intNumber;

            //long转int     大区间转小区间（显式类型转换）
            int intNumber1 = (int)longNumber;

            //int转float    小区间转大区间（隐式类型转换）
            float floatNumber1 = intNumber;

            //float转long   
            float floatNumber2 = 1.1f;
            long longNumber1 = (long)floatNumber2;


            //引用类型
            //隐式转换
            //People people = new Man();
            //显示转换
            //Man man = (Man)new People();


            //2.Parse() 适用于string转换成值类型
            //int 代表System.int32结构体 Parse属性结构体中的方法
            //任一值类型都有与之对应的结构体
            string strNumber = "123";
            string strNumber1 = "272语言";
            int intStrNumber = int.Parse(strNumber);
            int.Parse(strNumber);
            System.Int32.Parse(strNumber);
            Console.WriteLine(intStrNumber);
            //获取转换后的类型
            Console.WriteLine(intStrNumber.GetType());


            //解决非数字转换的异常问题 使用 TryParse()
            //转换成返回true 失败返回false 
            int ab;
            bool isSuccess = int.TryParse(strNumber1, out ab); // ab为转换后的结果
            Console.WriteLine(ab);

            //Convert 类型转换 适合各种类型相互转换
            string converStr = "123";
            int converInt = 123;
            bool converBool = true;

            int converInt1 = Convert.ToInt32(converStr); // 字符串转int值类型

            long converLong = Convert.ToInt32(converInt1); // int转long 值类型相互转换

            string converInt2 = Convert.ToString(converBool); // 布尔转字符串


            //toString 任意类型转string
            int num1 = 100;
            bool bool1 = false;
            float float1 = 1.1f;

            Console.WriteLine(num1.ToString());
            Console.WriteLine(bool1.ToString());
            Console.WriteLine(float1.ToString());

        }
    }
    public class People { }
    public class Man : People { }
}
