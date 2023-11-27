using System;

namespace Day8_2 {
    internal class Program {
        static void Main(string[] args) {
            //数据类型为int的一维数组
            int[] intArray = new int[5] { 1, 2, 3, 4, 5 };

            //交错数组
            //数据类型为一维数组的一维数组
            int[][] intsArray = new int[2][] { new int[5] { 1, 2, 3, 4, 5 }, new int[4] { 1, 2, 3, 4 } };
            string[] stringArray1 = { "1", "2" };
            string[] stringArray2 = { "3", "2" };
            string[][] stringsArray = new string[2][] { stringArray1, stringArray2 };


            int[] intArray3 = intsArray[0];
            Console.WriteLine(intArray3[2]);
            Console.WriteLine(intsArray[0][2]);

            intsArray[1][1] = 6;

            //for (int i = 0; i < intsArray.Length; i++)
            //{
            //    for (int j = 0; j < intsArray[i].Length; j++)
            //    {
            //        Console.WriteLine(intsArray[i][j]);
            //    }
            //}

            foreach (int[] item in intsArray) {
                foreach (int item1 in item) {
                    Console.WriteLine(item1);
                }
            }

            //
            int[,][] intssArray = new int[2, 2][] { { new int[2] { 1, 33 }, new int[3] { 1, 2, 4 } }, { new int[2] { 7, 9 }, new int[3] { 6, 4, 3 } } };

            Console.WriteLine(intssArray[0, 1][2]);



            Console.ReadKey();

        }
    }
}
