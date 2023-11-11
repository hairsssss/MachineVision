#define TEST
#undef  TEST   //取消
//#define TEST1
//#define TEST2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17_5 {

    internal class Program {
        static void Main(string[] args) {
            //C# 预处理器指令
            //预处理器指令是指编译器在实际编译开始之前对信息进行预处理
            string IP;

#if TEST
            IP = "127.0.0.1";
#else
            IP = "192.168.1.1";
#endif
#if TEST1
       Console.WriteLine("1");
#elif TEST2
     Console.WriteLine("2");
#else
            Console.WriteLine("3");
#endif

            Console.WriteLine("发起请求当前的IP为{0}", IP);


            //#error：使用指定的消息生成编译器错误
            //#warning：使用指定的消息生成编译器警告
            Console.WriteLine("此处代码有错误");


#line 200 "文件名"
            int i;
            int j;
#line default
            char c;
            float f;
            Console.ReadKey();
        }
    }
}
