using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWork;

namespace work_11_08 {
    internal class Program {
        static void Main(string[] args) {
            #region 1.返回stirng类型  有两个参数  分别类型为 字符串静态数组  list字符串数组
            //让两个数组中的元素进行 +操作
            //定义委托来实现方法的调用
            //StrListAddDelegate strListAddDelegate = new StrListAddDelegate(HomeWork.ListAdd);
            StrListAddDelegate strListAddDelegate = HomeWork.ListAdd;

            string[] strArray = { "今天", "是" };
            List<string> strList = new List<string> { "2023年", "11月", "08号。" };

            string result = strListAddDelegate(strArray, strList);
            Console.WriteLine(result);
            #endregion


            #region 2.返回类型为泛型  有两个参数  分别类型为 泛型静态数组  泛型list数组
            //让两个数组中的元素进行进行交换
            //定义委托来实现方法的调用

            SwapDelegate<int> swapDelegate = Swap;

            int[] intArray = { 1, 2, 3 };
            List<int> intList = new List<int> { 4, 5, 6 };

            Console.WriteLine("原始数组: " + string.Join(", ", intArray));
            Console.WriteLine("原始数组: " + string.Join(", ", intList));

            Tuple<int[], int[]> swapped = swapDelegate(intArray, intList);

            int[] swappedArray = swapped.Item1;
            int[] swappedList = swapped.Item2;

            Console.WriteLine("交换后: " + string.Join(", ", swappedArray));
            Console.WriteLine("交换后: " + string.Join(", ", swappedList));
            #endregion


            #region 3.返回类型  有3个参数  分别类型为 字符串静态数组  list字符串数组  可变参数
            //让3个参数的元素进行 +操作
            //定义委托来实现方法的调用
            ConcatDelegate delegate1 = ConcatenateElements;

            string[] array = { "你", "说" };
            List<string> list = new List<string> { "干", "啥", "啊" };
            string result3 = delegate1(array, list, "?");

            Console.WriteLine(result3);

            #endregion

            #region 4.返回值类型为People 有两个参数 都为People    
            //返回值的结果为 两个的属性的和
            PeopleDelegate del = CombinePeople;

            People p1 = new People { Age = 30, Height = 170 };
            People p2 = new People { Age = 20, Height = 160 };
            People peopleResult = del(p1, p2);

            Console.WriteLine($"Age: {peopleResult.Age}, Height: {peopleResult.Height}");  // 输出: "Age: 50, Height: 330"
            #endregion
        }

    }
}
internal class HomeWork {
    #region 1.返回stirng类型  有两个参数  分别类型为 字符串静态数组  list字符串数组
    //让两个数组中的元素进行 +操作
    //定义委托来实现方法的调用
    public delegate string StrListAddDelegate(string[] strArray, List<string> strList);
    public static string ListAdd(string[] strArray, List<string> strList) {
        string result = "";
        foreach (string str in strArray) {
            result += str;
        }
        foreach (string str in strList) {
            result += str;
        }
        return result;
    }

    #endregion

    #region 2.返回类型为泛型  有两个参数  分别类型为 泛型静态数组  泛型list数组
    //让两个数组中的元素进行进行交换
    //定义委托来实现方法的调用

    public delegate Tuple<T[], T[]> SwapDelegate<T>(T[] array1, List<T> list1);
    public static Tuple<T[], T[]> Swap<T>(T[] array1, List<T> list1) {
        T[] result = new T[array1.Length];

        for (int i = 0; i < array1.Length; i++) {
            result[i] = array1[i];
            array1[i] = list1[i];
            list1[i] = result[i];
        }
        T[] listAsArray = list1.ToArray(); // 将 List 转换为数组
        return new Tuple<T[], T[]>(array1, listAsArray);
    }

    #endregion

    #region 3.返回类型  有3个参数  分别类型为 字符串静态数组  list字符串数组  可变参数
    //让3个参数的元素进行 +操作
    //定义委托来实现方法的调用
    public delegate string ConcatDelegate(string[] array, List<string> list, params string[] args);
    public static string ConcatenateElements(string[] array, List<string> list, params string[] args) {
        string result = "";

        foreach (string item in array) {
            result += item;
        }

        foreach (string item in list) {
            result += item;
        }

        foreach (string item in args) {
            result += item;
        }

        return result.Trim();
    }

    #endregion

    #region 4.返回值类型为People 有两个参数 都为People 返回值的结果为 两个的属性的和 定义委托来实现方法的调用
    public delegate People PeopleDelegate(People p1, People p2);
    public class People {
        public int Age { get; set; }
        public int Height { get; set; }
    }
    public static People CombinePeople(People p1, People p2) {
        return new People {
            Age = p1.Age + p2.Age,
            Height = p1.Height + p2.Height
        };
    }

    #endregion

    #region 5.自己查找两个枚举值的例子 和一个结构体例子
    public enum Seasons {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4
    }

    public enum Colors {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public struct Rectangle {
        public double Length { get; set; }
        public double Width { get; set; }

        public double GetArea() {
            return Length * Width;
        }
    }
    #endregion

}

