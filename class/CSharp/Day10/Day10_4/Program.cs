using System;

namespace Day10_4 {
    internal class Program {
        static void Main(string[] args) {

            //属性 和字段的关系
            //1.属性是类的成员函数
            //2.属性其实外界访问私有字段的入口
            //3.属性本质就是方法  一个属性可以分别有一个set 和get 方法组成。（或者称为访问器）\
            //4.属性的名字用大驼峰命名  一般和对应的私有字段名字保持一致
            //5.属性的扩展 ---增加字段的业务判断逻辑。
            People zhangsan = new People();
            //给属性赋值  调用内部set方法
            zhangsan.Age = 10;
            //使用属性  调用内部get方法
            Console.WriteLine(zhangsan.Age);
            zhangsan.Id = 100;
            // Console.WriteLine(zhangsan.Id);

            //zhangsan.ID2 = 200;
            Console.WriteLine(zhangsan.ID2);


            zhangsan.ID3 = 1000;
            Console.WriteLine(zhangsan.ID3);
            zhangsan.ID3 = 80;
            Console.WriteLine(zhangsan.ID3);

            zhangsan.StrNumber = "123";
            Console.WriteLine(zhangsan.StrNumber);
            zhangsan.StrNumber1 = "nnn";
            Console.WriteLine(zhangsan.StrNumber1);
            // zhangsan.StrNumber2 = "123";
            Console.WriteLine(zhangsan.StrNumber2);
            Console.ReadKey();
        }
    }

    internal class People {

        private int _age;
        //成员函数 属性    
        public int Age {
            //get方法  设置字段的可读性
            get { return _age; }

            //set方法 设置字段的可写性
            set { _age = value; }
        }


        private int _id;

        //只写属性
        public int Id { set { _id = value; } }

        //只读属性
        private int _id2 = 200;
        public int ID2 { get { return _id2; } }



        //
        private int _ID3;
        public int ID3 {

            set {

                if (value < 100) {

                    _ID3 = 100;
                } else {

                    _ID3 = value;

                }

            }

            get { return _ID3; }


        }

        //可读可写属性 
        public string StrNumber { get; set; }
        //给属性设置默认值
        public string StrNumber1 { get; set; } = "你好";
        //给属性设置默认值  
        public string StrNumber2 { get; } = "你好123";
        private void PeopleMothod() {

            _age = 18;
        }





    }
}
