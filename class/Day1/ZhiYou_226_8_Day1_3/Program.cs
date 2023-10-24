using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCSharp;
using ClassLibraryVB;
namespace ZhiYou_226_8_Day1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //C#
            ClassLibraryCSharp.Class1 class1 = new  ClassLibraryCSharp.Class1();
            Console.WriteLine(class1.Add(1, 2));

            //vb
            ClassLibraryVB.Class1 class2 = new ClassLibraryVB.Class1();
            Console.WriteLine(class2.Add(3, 4));
            Console.ReadKey();
        }
    }
}
