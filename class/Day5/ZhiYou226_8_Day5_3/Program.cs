using MyNameSpace1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary226_8_Day5_3;
namespace ZhiYou226_8_Day5_3
{
    //访问修饰符  是C#中常用的关键字
    //作用：所有类型和类型成员都具有可访问性级别
    /*
     分类
public : 同一程序集的其他任何代码或引用该程序集的其他程序集都可以访问该类型或成员。
internal : 同一程序集中的任何代码都可以访问该类型或成员，但其他程序集不可以访问。
private :  同一类和结构的代码可以访问该类型和成员。
protected : 同一类和派生(继承特性)类中的代码可以访问该类型和成员。
protected internal :  同一程序集中的任何代码或其他程序集中的任何派生类都可以访问该类型或成员。
private protected：该类型或成员可以通过从 class 派生的类型访问，这些类型在其包含程序集中进行声明


    C#的默认修饰符

    类、结构的默认修饰符是internal。
    类中所有的成员默认修饰符是private。
    接口默认修饰符是internal。
    接口的成员默认修饰符是public。
    枚举类型成员默认修饰符是public。
    委托的默认修饰符是internal。
      */
    internal class Program
    {
      
        //入口函数   Program成员
        static void Main(string[] args)
        {
            // internal
            // 同一程序集同一文件访问
            Class1 class1 = new Class1();
            //同一程序集不同文件访问
            NewClass newClss = new NewClass();
            //同一程序集不同文件不同命名空间
            MyNameSpace1.NewClass1 newClass1 = new MyNameSpace1.NewClass1();
            //同一程序集文件不同命名空间
            MyNameSpace2.NewClass2 newClass2 = new MyNameSpace2.NewClass2();
            //不同程序集文件 不能访问 
            // ClassLibrary226_8_Day5_3.Class1 = new ClassLibrary226_8_Day5_3.Class1();

            //public
            // 同一程序集同一文件同命名空间访问
            Class2 class2 = new Class2();
            //同一程序集不同文件同命名空间访问
            NewClass1 newClss2 = new NewClass1();
            //同一程序集不同文件不同命名空间
            MyNameSpace1.NewClass2 newClass21 = new MyNameSpace1.NewClass2();
            //同一程序集同一文件不同命名空间
            MyNameSpace2.Class1 class11 = new MyNameSpace2.Class1();
            //不同程序集文件  可以访问
            ClassLibrary226_8_Day5_3.Class2 class21 = new ClassLibrary226_8_Day5_3.Class2();
            //private
            //同一程序集同一文件访问
            //    Class3 class3 = new Class3();
            //同一程序集不同文件同命名空间访问

           

            //
            Class1 class12 = new Class1();
            Console.WriteLine(class12._bge);
            Console.WriteLine(class12._cge);
            //private 描述的类的成员 无法直接在类外部任何地方访问
           // Console.WriteLine(class12._age);


            People people = new People();
           // Console.WriteLine(people._age);
        }
        //被描述为private 不能直接定义在命名空间中做为其成员  但是可以做为另一类的成员
        //private class Class3
        //{



        //}

        //


    }
    internal class Class1
    {

        public int _bge;
        internal int _cge;
        private int _age;

        private void Mothod() {
            _age = 10;
        }
    }

    public class Class2
    {
      
    }



    public class People
    {

        protected int _age;

        private void TestMothod()
        {
            _age = 100;
        }
    }

    public class Man : People {

        private void TestMothod1() {

            _age = 200;

    
        }






}
namespace MyNameSpace2 {

    internal class NewClass2
    {




    }

    public class Class1
    {


    }


}