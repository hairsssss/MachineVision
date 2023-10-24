using System;

namespace Day3_1 {
    internal class Program {
        //readonly常量定义
        //readOnly 字段常量  设置当前的字段为只读
        //const 必须在声明时初始化   可以作为字段和局部常量
        //readonly  可以在声明时初始化 也可在 构造函数中初始化
        //只能作为字段 不能作为局部常量
        readonly static int ReadOnlyInt = 100;
        readonly int ReadOnlyInt1;
        internal Program(int value) {
            ReadOnlyInt1 = value;
        }
        static void Main(string[] args) {
            Program test = new Program(109);
            Console.WriteLine(test.ReadOnlyInt1);
            //1.含义:用来存储特定类型的数据
            //2.变量的使用方法：定义变量和使用变量（赋值）
            //定义变量格式：数据类型 变量的名字
            int intNumber;
            //使用变量格式 变量名 = 数据类型
            intNumber = 100;

            //3.变量只能保存最新的数据内容
            intNumber = 200;
            //4.不允许在同一作用域定义相同名称的变量
            //int intNumber = 200;
            Console.WriteLine(intNumber);
            //5.简写
            int intNumber1 = 300;
            long longNumber1 = 1L, longNumber2 = 2L;
            //6.局部变量 需要赋值之后才能使用
            int intNumber2;

            //常量
            //1.用来存储不变的数据
            //2.存储特定类型的数据格式
            //3.常量的分类：值类型常量、字符串常量、const、readOnly

            //值类型常量
            int intNumber11 = 10; //十进制
            int intNumber21 = 0X20;  //十六进制
            int intNumber3 = 012; //八进制
            float floatNumber1 = 10.1f;
            long longNumber11 = 100L;
            uint uintNumber1 = 100u;
            char charNumber11 = 'a';//英文
            char charNumber21 = '中'; //中文
            char charNumber31 = '\n'; //转义字符
            char charNumber41 = '\u058F'; //Unicode编码


            //const 常量
            //定义const常量 必须在定义时赋值
            //命名时使用大写（方便区分）
            //使用场景 特殊的数字、符号
            const int CONST_INT_NUMBER = 10;
            const string PERSON = "兔子";
        }
    }
}
