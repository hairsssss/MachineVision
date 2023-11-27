using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
//4.程序入口文件  Program.cs
//程序执行的开始
// //class  类  Program
// Main 入口函数
//入口文件 --> 入口类 -->入口函数
//入口函数 作用：程序执行后自动执行   其他函数一般都要调用后才能执行 
namespace ZhiYou_226_8_Day1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {  

            //在控制台中输出内容且换行输出
            Console.WriteLine(1);
            Console.WriteLine(2);
            Console.WriteLine(3);
            Console.WriteLine(ClassLibrary1.Class1.testStr);
            //暂停程序 按任意按键程序继续执行
            aaa();
            Console.ReadKey();
        }

    static    void aaa() {


            Console.WriteLine(2555);

        }
    }
}


// 5.解决方案和项目
//(1).解决方案和项目都是VS提供的用于管理应用程序的容器
//(2).一个解决方案可以包含一个或多个项目.
//(3).这些项目可以利用解决方案 连接在一起 统一编译统一更新
//(4). sln和.csproj文件
//.sln：解决方案文件，里面包含着整个解决方案的信息，可以双击运行。
//.csproj:项目文件，里面包含着这个项目的信息，可以双击运行。

//7.程序集:
//1.当程序经过debug或者release 编译程序后得到的 项目文件 
//2.格式一般为·dll或者是·exe
//3.一个项目在编译后就是一个程序集