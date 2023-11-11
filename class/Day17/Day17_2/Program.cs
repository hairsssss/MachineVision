using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17_2 {
    internal class Program {
        static void Main(string[] args) {
            // int.Parse("111a");
            try {
                // 引起异常的语句
                //  int.Parse("111a");

                int a = 1;
                int b = 0;
                Console.WriteLine(a / b);
            } catch (Exception e) {
                // 错误处理代码
                Console.WriteLine(e.Message);


                //记录异常
                //  throw e;

            } finally {
                Console.WriteLine("123");
            }




            //  多个 catch 语句捕获不同类型的异常，以防 try 块在不同的情况下生成多个异常


            try {

                //using语句可用于确保在使用完资源后释放它，以避免资源泄漏  等同于reader.Dispose() 释放资源
                using (StreamReader reader = new StreamReader("file.txt")) {
                    string content = reader.ReadToEnd();

                }
            } catch (FileNotFoundException ex) {
                Console.WriteLine("文件不存在：" + ex.Message);
                //上传异常给服务器
            } catch (IOException ex) {
                Console.WriteLine("IO错误：" + ex.Message);
                //上传异常给服务器
            } finally {
                Console.WriteLine("处理结束。");
            }



            People people = new People();
            people.Age = 501;
            Console.ReadKey();
        }
    }
    //自定义异常
    public class People {

        private int _age;
        public int Age {
            get { return _age; }
            set {
                if (value > 500) {
                    //  Console.WriteLine("赋值超出500了");
                    throw new Exception("赋值超出500了");
                } else {

                    _age = value;

                }

            }
        }

    }
}
