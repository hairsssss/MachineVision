using System;

namespace Day8_3 {
    internal class Program {
        static void Main(string[] args) {

            //是 C# 中所有数组的基类，它是在 System 命名空间中定义  提供了各种用于数组的属性和方法

            //创建一维数组
            //int[] intArray = { 1, 2,}
            //array 代表Array的对象  也代表一维数组
            Array array = Array.CreateInstance(typeof(int), 3);
            Console.WriteLine(typeof(int));
            //在索引值为0的位置 存储100
            array.SetValue(100, 0);
            array.SetValue(200, 1);
            array.SetValue(300, 2);

            //
            Console.WriteLine(array.GetValue(1));

            Array intsArray = Array.CreateInstance(typeof(int), 2, 2);//创建二维数组
            //设置二维数组的值
            intsArray.SetValue(100, 0, 0);
            intsArray.SetValue(200, 0, 1);
            intsArray.SetValue(300, 1, 0);
            intsArray.SetValue(400, 1, 1);

            //取值
            Console.WriteLine(intsArray.GetValue(0, 0));
            Console.WriteLine(intsArray.GetValue(1, 1));

            /*
            Indexof(Array array, Obejct)    返回第一次出现的下标 如果没有找到 返回-1
            Sort(Array array)    从小到大排序 （仅支持一维数组）   不生成新数组对象  把老数组对象元素排序
            Reverse(Array array)    数组逆置
            Clear(Array array, int index, int length)    将某个范围内的所有元素设为初始值
            Copy      深复制   数组内容到另一个数组
             
             */


            int[] intArray1 = new int[5] { 5, 2, 3, 1, 6 };
            Array array1 = Array.CreateInstance(typeof(string), 4);
            for (int i = 0; i < array1.Length; i++) {
                array1.SetValue(i.ToString(), i);
            }

            //参数1 搜索的数组对象   搜索的元素
            int indexOfNumber = Array.IndexOf(intArray1, 2);
            Console.WriteLine(indexOfNumber);
            int indexOfNumber1 = Array.IndexOf(array1, 1);
            Console.WriteLine(indexOfNumber1);


            Array.Sort(intArray1);
            foreach (int i in intArray1) {

                Console.WriteLine(i);
            }

            Array.Reverse(array1);
            foreach (var item in array1) {
                Console.WriteLine(item);
            }

            Array.Clear(intArray1, 1, 3);
            foreach (var item in intArray1) {
                Console.WriteLine(item);
            }

            //   Array.Copy
            Array array2 = Array.CreateInstance(typeof(int), 4);
            for (int i = 0; i < array2.Length; i++) {
                array2.SetValue(i + 1, i);
            }
            Array array3 = Array.CreateInstance(typeof(int), 4);
            array3 = array2;

            //  Array.Copy(array2, array3,4);

            foreach (var item in array3) {
                Console.WriteLine(item);
            }

            array3.SetValue(1000, 0);
            foreach (var item in array3) {
                Console.WriteLine(item);
            }
            foreach (var item in array2) {
                Console.WriteLine(item);
            }



            Console.ReadKey();
        }
    }
}
