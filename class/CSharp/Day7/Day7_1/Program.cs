using System;

namespace Day7_1 {
    internal class Program {
        static void Main(string[] args) {


            //1.表示不引用任何对象的空引用,没有创建内存空间,存放的是空引用指针；
            //2.Null类型是System.Nullable < T > 这个struct的类型
            //3.值类型不能直接赋值null 引用类型可以直接赋值null
            // int a = null ;
            //值类型赋值null类型方式1
            System.Nullable<int> a = null;
            ///   float f =null;
            System.Nullable<float> f = null;
            ////值类型赋值null类型方式2
            int? a1 = null;

            Console.WriteLine(f);
            string b = "123";
            b = null;
            // System.Nullable<>
            // b = null;
            // b = "456";
            if (b == "123" || b == null) {

                Console.WriteLine(1);

            }
            if (a == 10 || a == null) {

                Console.WriteLine(2);
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
            // a = 1;
            Program program = new Program();
            program = null;



            /*
null和字符串空值和字符串空格的区别
1.null是没有创建内存空间,
2.字符串空值  为"" 或者string.Empty  实际上都会分配空间；
3.字符串空格 "    "  会分配空间 空格也是ACSII  对应的符号
             
             */
            string strTest2 = null;
            string strTest3 = "";
            string strTest31 = string.Empty;
            string strTest4 = " ";
            Console.WriteLine("请输入账号:");
            string strTest = Console.ReadLine();

            if (strTest == null || strTest == string.Empty || strTest.Trim() == "") {


                Console.WriteLine("账号格式错误");

            } else {


                string newStr = strTest.Trim();
                Console.WriteLine(newStr);

            }


            //双问号 ??（合并运算符）

            //作用：
            //可空类型给不可空类型 赋值时 使用
            // 用于判断一个变量在为 null 的时候返回一个指定的值

            int? tempIntA = null;
            tempIntA = 200;

            int tempIntB;
            //如果tempIntA 为null 时   tempIntB取值100  反之 取tempIntA 
            tempIntB = tempIntA ?? 100;
            Console.WriteLine(tempIntB);


            string tempStr = null;
            tempStr = "456";
            string tempStr2;
            tempStr2 = tempStr ?? "123";
            Console.WriteLine(tempStr2);


            tempStr2 = tempStr == null ? "123" : tempStr;
            Console.WriteLine(tempStr2);
            Console.ReadKey();
        }



        public static void Sum(int? a, int? b) {

            Console.WriteLine(a + b);
        }
    }
}
