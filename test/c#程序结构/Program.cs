using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 引用的命名空间
namespace c_程序结构  // 程序的命名空间或者项目名称
{
    internal class Program // 类
    {
        static void Main(string[] args) // static 静态类关键字  void 无返回值  Main 函数名称，程序的起点
        {
            // 输出按键信息
            /* ConsoleKeyInfo keyInfo = Console.ReadKey();
             Console.WriteLine("\nKey pressed: " + keyInfo.Key); // 按键的枚举值
             Console.WriteLine("Character representing the key: " + keyInfo.KeyChar); // 键位的字符表示
             Console.WriteLine("Special modifier keys: " + keyInfo.Modifiers);

             Console.WriteLine(111);
             Console.ReadKey(); // 用户按下任意键之后在进行后续操作
             Console.WriteLine(122);
             //文件后缀 Sin     解决方案文件
             //         csproj  命名空间  
             //         cs      类文件*/
            /*  string strNumber = "123";
              int intNumber4 = int.Parse(strNumber);
              Console.WriteLine(intNumber4);
              long longNumber4 = long.Parse(strNumber);
              Console.WriteLine(longNumber4);
              byte byteNumber = byte.Parse(strNumber);
              Console.WriteLine(byteNumber);
              uint uintNumber = uint.Parse(strNumber);
              Console.WriteLine(uintNumber);
              float floatNumber4 = float.Parse(strNumber);
              Console.WriteLine(floatNumber4);
              // 注意bool类型转换
              string stringNumber5 = "true";
              bool boolNumber = bool.Parse(stringNumber5);
              Console.WriteLine(boolNumber);*/
            int[] arrayList = new int[] { 1, 2 };
            int sum = arrayList[0] + arrayList[1];
            Console.WriteLine(sum);
            Console.WriteLine(arrayList[0] + arrayList[1]); 
            Console.ReadKey(); // 用户按下任意键之后在进行后续操作
        }
    }
}
