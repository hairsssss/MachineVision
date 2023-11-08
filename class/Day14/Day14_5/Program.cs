using System;
using System.Collections.Generic;

namespace Day14_5 {
    internal class Program {
        static void Main(string[] args) {


            //C#中的Dictionary字典类
            //必须包含名空间System.Collection.Generic
            //1. Dictionary里面的每一个元素都是一个键值对(由二个元素组成：键和值)  字典是无序  没有索引值的
            //2. key键必须是唯一的,而值不需要唯一的  （key相当索引值  value 代表集合中的元素）
            //3.字典 长度是不固定的 随着元素增减 而改变
            //4. 键和值都可以是任何类型(比如：string, int, 自定义类型，等等) 

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            keyValuePairs.Add(0, "100");
            keyValuePairs.Add(1, "200");
            keyValuePairs.Add(2, "300");


            //取值 通过key 找value
            string tempStr = keyValuePairs[2];
            Console.WriteLine(tempStr);


            for (int i = 0; i < keyValuePairs.Count; i++) {
                Console.WriteLine(keyValuePairs[i]);
            }


            //修改值
            keyValuePairs[0] = "400";

            foreach (KeyValuePair<int, string> item in keyValuePairs) {
                //获得value 和key
                Console.WriteLine(item.Value);
                Console.WriteLine(item.Key);
            }

            //获得其key值的集合

            foreach (int item in keyValuePairs.Keys) {
                Console.WriteLine(keyValuePairs[item]);
            }

            foreach (string item in keyValuePairs.Values) {
                Console.WriteLine(item);
            }


            bool isTrue = keyValuePairs.Remove(0);

            if (keyValuePairs.ContainsKey(0)) {


            } else {

                Console.WriteLine("不存在");

            }
            Console.ReadKey();
        }
    }
}
