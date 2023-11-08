using System;
using System.Collections;
using System.Collections.Generic;

namespace Day14_4 {
    internal class Program {
        static void Main(string[] args) {

            //ArrayList  可变数组 

            /*
             ArrayList的优点：
    ArrayList大小是按照其中存储的数据来动态扩充与收缩的
    ArrayList 在声明对象时并不需要指定它的长度
    ArrayList可以很方便地进行数据的添加插入删除
   ArrayList 可以存储任意类型
          ArrayList的缺点：
    ArrayList在存储数据时使用object类型进行存储的
    ArrayList不是类型安全的，使用时很可能出现类型不匹配的错误
    就算都插入了同一类型的数据，使用时我们也需要将它们转化为对应的原类型来处理
    ArrayList 存储在装箱和拆箱操作，导致其性能低下   
           */
            //using System.Collections;
            ArrayList arrayList = new ArrayList();
            //装箱为object类型
            int index1 = arrayList.Add(1);
            int index2 = arrayList.Add("123");
            arrayList.Add(new object());
            arrayList.Add(new Program());
            arrayList.Add(null);

            arrayList.AddRange(arrayList);


            Array array = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < 5; i++) {
                array.SetValue(i, i);
            }
            arrayList.AddRange(array);
            arrayList.Add(array);





            arrayList.Insert(2, new object());
            arrayList.InsertRange(2, array);

            arrayList.Remove(2);  //按元素
            arrayList.RemoveAt(2);//按位
            arrayList.RemoveRange(2, 2);//按范围


            arrayList.Clear();
            Console.WriteLine(arrayList.Count);

            //其他方法自己查看文档练习



            //List

            //List 与其他数组的比较：
            // List与静态数组（Array类）比较类似，都用于存放一组类型相同的数据。
            // List与动态数组（ArrayList）比较类似 元素长度不固定。
            //using System.Collections.Generic;

            //泛型集合
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.AddRange(list);


            //
            // list.IndexOf(1);
            //list.Insert();

            Console.ReadKey();
        }

    }
}