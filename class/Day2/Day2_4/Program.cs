using System.Text;

namespace Day2_4 {

    /* 
     * C#数据类型分为两大类：值类型和引用类型
     * 值类型：整数类型 浮点型 字符型 布尔类型 struct(结构) enum(枚举)
    */
    internal class Program {
        static void Main(string[] args) {
            byte a = 1;
            sbyte b = 1;
            short c = 1;
            ushort d = 1;
            int e = 1;
            uint f = 1;
            long g = 1;
            ulong h = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(h);

            //浮点型 float double decimal
            float i = 1.1f;
            float j = 1.1F;

            double k = 1.1;
            double l = 1.18888888888888888888888888888888888888;

            //精度要求比较高的，使用decimal 一般使用double float
            decimal m = 1.1M;
            decimal n = 1.1m;

            //单字符类型 表示方式使用 '' 
            //英文对应ACSLL编码
            char o = 'l';
            int o1 = 1;
            int o2 = 1;
            //中文对应unicode编码
            char p = '哟';
            char p1 = '\u5F22';
            Console.WriteLine(p1 + o);
            Console.WriteLine(p1);

            //布尔类型 true和false 对应 1 0
            bool bool1 = true;
            bool bool2 = false;

            //引用类型
            //字符串 单字符串的集合
            string string1 = "1212121q\neqeq";
            string string2 = @"n1212121qeqeqn1212121qeqn121212
1qeqeqn1212121qen1212121qeqeqn1212121qeqeq尼qeq尼eq尼"; // 多行字符串
            Console.WriteLine(string1);

            //转义字符的使用
            char q = '\n';
            string r = "今天\n不好";
            string s = @"今天\n不好";  // 添加@引号中的转义字符失效 变为单字符
            bool t = r == s; // false
            string u = "D:\\A_material\\前端\\面试";

            string v = "\\\\\\\\"; // 
            string v1 = "\\\\\\\\n"; // 
            Console.WriteLine(s);
            //日期类型 
            DateTime dateTimeValue = DateTime.Now;
            Console.WriteLine(dateTimeValue);


            string str = "杨震";
            //string str = "我爱China!";
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
            StringBuilder sr = new StringBuilder();
            foreach (byte b1 in bytes) {
                sr.Append(b1.ToString("X"));
            }
            Console.WriteLine(sr.ToString());
            Console.ReadKey();
        }
    }
}