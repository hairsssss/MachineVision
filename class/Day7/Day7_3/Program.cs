using System;

namespace Day7_3 {
    internal class Program {
        static void Main(string[] args) {

            //多维数组
            // 含义：数组嵌套数组形式 一般常用二维数组
            //二维数组格式：string[,] strArray = new string[数组个数, 数组元素个数]

            int[] intArray = new int[2] { 2, 4 };
            int[,] intArray1 = new int[2, 3] { { 3, 4, 5 }, { 7, 8, 9 } };
            string[,] intArray3 = new string[4, 4];

            //读取二维数组中元素
            Console.WriteLine(intArray1[0, 2]);
            Console.WriteLine(intArray1[1, 1]);
            //遍历二维数组中元素
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {
                    Console.WriteLine(intArray1[i, j]);
                }

            }

            //item代表二维数组中的元素
            foreach (var item in intArray1) {
                Console.WriteLine(item);
            }




            //
            int[,,] intArray2 = new int[2, 3, 2] { { { 1, 2 }, { 1, 3 }, { 3, 4 } }, { { 4, 3 }, { 4, 5 }, { 6, 7 } } };
            for (int i = 0; i < intArray2.GetLength(0); i++) {

                for (int j = 0; j < intArray2.GetLength(1); j++) {
                    for (int k = 0; k < intArray2.GetLength(2); k++) {
                        Console.WriteLine(intArray2[i, j, k]);
                    }
                }
            }

            foreach (var item in intArray2) {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
