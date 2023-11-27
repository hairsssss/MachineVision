using System;

namespace Day7_2 {
    internal class Program {
        static void Main(string[] args) {
            //不可变数组 （一维数组）
            //含义:
            //不可变数组是一个存储相同类型元素的固定大小的顺序集合  是一种数据类型
            //特点:
            //            数组属于引用类型
            //            数组只能包含类型相同的元素
            //数组通过下标（索引值）标记元素   从左到右 从0 依次递增1

            /*
            格式：
定义数组：
datatype[] arrayName;
             */
            /*
初始化数组中的元素的方式
数据类型[] 数组名 = {值 1, 值 2, …}
数据类型[] 数组名 = new 数据类型[长度]{值 1，值 2,…}
数据类型[] 数组名 = new 数据类型[长度可忽略]{值 1，值 2,…}
数据类型[] 数组名 = new 数据类型[长度];
 */
            //int  整数类型
            int a = 1;
            //int[] 数组类型  在初始化时，可以扩充数组长度
            int[] intArray = { 1, 2, 3, 4, 5, 6 };
            //在初始化时，确定数组长度  数据内容长度必要和数组长度保持一致
            float[] floatArray = new float[4] { 10.0f, 20.0f, 30.0f, 40.0f };
            //在初始化时，不确定数组长度 数据内容的个数决定了 数组最终长度
            string[] stringArray = new string[] { "1", "2", "3" };
            //在初始化时，确定数组长度  数组内容可以在后续赋值
            bool[] boolArray = new bool[4];
            //在索引值为0的位置存放元素
            boolArray[0] = true;
            boolArray[1] = false;
            boolArray[2] = false;
            boolArray[3] = false;

            //使用数组元素
            string str1 = stringArray[0];
            string str2 = stringArray[1];
            Console.WriteLine(str1 + str2);

            //修改数组元素
            floatArray[2] = 50.0f;
            //数组越界 （c#异常）
            //System.IndexOutOfRangeException:“索引超出了数组界限。”
            // floatArray[4] = 60.0f;


            //数组遍历  for循环 
            //
            Console.WriteLine(boolArray[0]);
            Console.WriteLine(boolArray[1]);
            Console.WriteLine(boolArray[2]);
            Console.WriteLine(boolArray[3]);
            for (int i = 0; i <= stringArray.Length - 1; i++) {
                Console.WriteLine(stringArray[i]);
            }


            //foreach 循环结构
            //foreach（代表数组元素  in  数组）{遍历的逻辑代码}

            //var 代表推断类型 类似JS中的任意类型 
            foreach (var item in boolArray) {
                Console.WriteLine(item);
            }

        //一旦var类型确定 后续无法去修改
        //var a1 ="123";
        //a1 = 2;
        //a1 = "33";


        //        例子：在控制台中录入学生成绩

        //要求：成绩范围0–100
        //“请输入学生总数：”
        //“请输入学生成绩：”
        //"输入的成绩有误 : "
        NUMBER:
            Console.WriteLine("请输入学生总数:");
            string strNumber = Console.ReadLine();
            int tempResultNumber;
            bool isTrue = int.TryParse(strNumber, out tempResultNumber);
            if (isTrue == false) {
                Console.WriteLine("输入数字有误重新输入:");
                goto NUMBER;
            } else {

                int[] intArray1 = new int[tempResultNumber];
                for (int i = 0; i < tempResultNumber; i++) {
                NUMBER1:
                    Console.WriteLine("请输入学生成绩");
                    string strNumber1 = Console.ReadLine();
                    int tempResultNumber1;
                    bool isTrue1 = int.TryParse(strNumber, out tempResultNumber1);
                    if (isTrue1 == false) {
                        Console.WriteLine("成绩格式有误,重新输入");
                        goto NUMBER1;
                    } else {
                        if (tempResultNumber1 < 0 || tempResultNumber1 > 100) {
                            Console.WriteLine("成绩范围有误,重新输入");
                            goto NUMBER1;
                        } else {
                            intArray1[i] = tempResultNumber1;
                        }
                    }
                }

            }


            Console.ReadKey();
        }
    }
}
