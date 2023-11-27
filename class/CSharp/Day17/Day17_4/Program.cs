using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17_4 {
    internal class Program {
        static void Main(string[] args) {

            /*
            C#中的IO（Input/Output）操作包括读取和写入文件、
            读取和写入流、以及操作目录和文件夹等。
            这些操作都可以通过System.IO命名空间中的类实现。    
             */
            //            文件操作
            //File类
            //File类提供了对文件的创建、读取、写入、复制、移动、重命名和删除等操作。
            string a = @"D:\myFile.txt";
            FileCreate(a);
            FileWrite(a);
            FileRead(a);
            Console.ReadKey();
        }

        public static bool FileCreate(string filePath) {

            if (!File.Exists(filePath)) {

                FileStream fileStream = File.Create(filePath);
                fileStream.Close();
                return true;
            } else {

                Console.WriteLine("文件已经存在");
            }
            return false;

        }

        //File写入文件
        public static void FileWrite(string filePath) {

            if (File.Exists(filePath)) {
                //string content = "读取读取读取读取读取读取";
                //File.WriteAllText(filePath, content);

                string[] contentArr = { "dddd", "eeeeee" };
                File.WriteAllLines(filePath, contentArr);
            } else {


                Console.WriteLine("文件不存在 无法写入");
            }
        }


        public static void FileRead(string filePath) {

            if (File.Exists(filePath)) {
                //string content = File.ReadAllText(filePath);
                //Console.WriteLine(content);


                string[] content = File.ReadAllLines(filePath, Encoding.UTF8);
                Console.WriteLine(content.Length);
            } else {

                Console.WriteLine("文件不存在 无法读取");
            }
        }

    }

    // File读取文件


}
