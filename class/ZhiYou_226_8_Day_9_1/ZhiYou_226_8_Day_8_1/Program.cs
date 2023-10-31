using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiYou_226_8_Day_8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Array intArray = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < intArray.Length; i++)
            {
               intArray.SetValue(i+1, i);
            
            }
            //foreach (var item in intArray)
            //{
            //    Console.WriteLine(item.GetType());
            //}
            Console.WriteLine(Array.IndexOf(intArray, 1));


          //  Console.WriteLine(Array1.IndexOf(intArray, 2));
            Console.ReadKey();

        }



    }

    internal class Array1 {

        public static int IndexOf(int[]array, int value) {


            Console.WriteLine(value.GetType());
            for (int i = 0; i < array.Length; i++) 
            {

               Console.WriteLine(array.GetValue(i).GetType());

                if (array[i] == value) 
                {
                    return i;
                  //  break;
                }

            }

            return -1;

        }


        public static int IndexOf(string[] array,string value)
        {


            Console.WriteLine(value.GetType());
            for (int i = 0; i < array.Length; i++)
            {

                Console.WriteLine(array.GetValue(i).GetType());

                if (array[i] == value)
                {
                    return i;
                    //  break;
                }

            }

            return -1;

        }


    }
}
