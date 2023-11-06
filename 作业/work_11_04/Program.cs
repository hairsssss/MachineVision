using System;

namespace work_11_04 {
    internal class Program {
        static void Main(string[] args) {
            Audi audiRs6 = new Audi("奥迪Rs6", 760000, "Avant");
            audiRs6.Drive();
            audiRs6.VariableSpeed();

            Benz mercedes = new Benz("迈巴赫", 3200000, "S680");
            mercedes.Drive();
            mercedes.VariableSpeed();



            ChinesePeople chinesePeople = new ChinesePeople();
            chinesePeople.speak();
            chinesePeople.eat();
            chinesePeople.sleep();

            AmericanPeople americanPeople = new AmericanPeople();
            americanPeople.speak();
            americanPeople.eat();
            americanPeople.sleep();



            Cuboid cuboid = new Cuboid(10, 20, 30);
            Console.WriteLine(cuboid.getVolume());
            Console.WriteLine(cuboid.getSurfaceArea());



            Cone cone = new Cone(10, 20);
            double volume = cone.CalculateVolume();
            double surfaceArea = cone.CalculateSurfaceArea();



            Person1 chinese = new Chinese1();
            Person1 american = new American1();
            Console.WriteLine(chinese.Speak());
            Console.WriteLine(american.Speak());

            Brid brid = new Brid("有", 2);
            Console.WriteLine(brid.Wing);
            brid.Fly();
        }
        #region 一、体现父类子类间的继承关系。父类：鸟，子类：麻雀、鸵鸟、鹰。、子类继承父类的一些特点，如都是鸟的话就都会有翅膀、两条腿等，但它们各自又有各自的特点，如麻雀的年龄、体重；鸵鸟的身高、奔跑速度；鹰的捕食、飞翔高度等。
        //1
        public class Brid {
            public string Wing { get; set; }
            public int Leg { get; set; }
            public Brid(string wing, int leg) {
                Wing = wing;
                Leg = leg;
            }
            public void Fly() {
                Console.WriteLine(Wing);
            }
        }
        //public class Brid {
        //    public string _wing;
        //    public int _leg;
        //    public string Wing { get { return _wing; } set { _wing = value; } }
        //    public int Leg { get { return _leg; } set { _leg = value; } }
        //    public Brid(string wing, int leg) {
        //        _wing = wing;
        //        _leg = leg;
        //    }
        //}
        public class Aparrow : Brid {
            public int Age { get; set; }
            public double Weight { get; set; }
            public Aparrow(string wing, int leg, int age, double weight) : base(wing, leg) {
                Age = age;
                Weight = weight;
            }
        }

        public class Ostrich : Brid {
            public int _height { get; set; }
            public int _speed { get; set; }
            public Ostrich(string wing, int leg, int height, int speed) : base(wing, leg) {
                _height = height;
                _speed = speed;
            }
        }

        public class Eagle : Brid {
            public int _prey { get; set; }
            public int _flight { get; set; }
            public Eagle(string wing, int leg, int prey, int flight) : base(wing, leg) {
                _prey = prey;
                _flight = flight;
            }
        }
        #endregion

        #region 二、实现一个名为Person的类和它的子类Employee，Employee有两个子类Faculty和Staff。具体要求如下：
        //（1）Person类中的属性有：姓名name（String类型）、地址address（String类型）、电话号码telephone（String类型）和电子邮件地址email（String类型）。
        //（2）Employee类中的属性有：办公室office（String类型）、工资wage（double类型）和受雇日期hiredate（String类型）。
        //（3）Faculty类中的属性有：学位degree（String类型）、级别level（String类型）。
        //（4）Staff类中的属性有：职务称号duty（String类型）。

        public class Person {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public Person(string name, string address, string telephone, string email) {
                Name = name;
                Address = address;
                Telephone = telephone;
                Email = email;
            }
        }

        public class Employee : Person {
            public string Office { get; set; }
            public double Wage { get; set; }
            public string HireDate { get; set; }
            public Employee(string office, double wage, string hireDate, string name, string address, string telephone, string email) : base(name, address, telephone, email) {
                Office = office;
                Wage = wage;
                HireDate = hireDate;
            }

            public class Faculty : Employee {
                public string Degree { get; set; }
                public double Level { get; set; }
                public Faculty(string degree, double level, string office, double wage, string hireDate, string name, string address, string telephone, string email) : base(office, wage, hireDate, name, address, telephone, email) {
                    Degree = degree;
                    Level = level;
                }
            }

            public class Staff : Employee {
                public string Duty { get; set; }
                public Staff(string duty, string office, double wage, string hireDate, string name, string address, string telephone, string email) : base(office, wage, hireDate, name, address, telephone, email) {
                    Duty = duty;
                }
            }
        }
        #endregion

        #region 三、编写一个Car类，具有final类型的属性品牌，具有功能drive；定义其子类Aodi和Benchi，具有属性：价格、型号；具有功能：变速；定义主类E，在其main方法中分别创建Aodi和Benchi的对象，并测试对象的特性。
        public class Car {
            // 品牌
            public string Final { get; set; }
            public Car(string final) {
                Final = final;
            }
            public void Drive() {
                Console.WriteLine($"{Final}的汽车驾驶体验感很不错。");
            }
        }

        public class Audi : Car {
            public double Price { get; set; }
            public string Model { get; set; }
            public Audi(string finnal, double price, string model) : base(finnal) {
                Price = price;
                Model = model;
            }
            public void VariableSpeed() {
                Console.Write($"美式大V8，环保去他妈。-----{base.Final}-{Model}-----  ");
                Console.Write("起步价：（￥{0:F2}）！\n", Price);
            }
        }
        public class Benz : Car {
            public double Price { get; set; }
            public string Model { get; set; }
            public Benz(string finnal, double price, string model) : base(finnal) {
                Price = price;
                Model = model;
            }
            public void VariableSpeed() {
                Console.Write($"美式大V8，环保去他妈。-----{base.Final}-{Model}-----  ");
                Console.Write("起步价：（￥{0:F2}）！\n", Price);
            }
        }
        #endregion

        #region  四、定义两个类ChinesePeople和AmericanPeople类，  People类中定义三个方法分别输出一些信息，然后ChinesePeople和AmericanPeople类重写父类的三个方法。
        public class People {
            public virtual void speak() {
                Console.WriteLine("人类会说话。");
            }

            public virtual void eat() {
                Console.WriteLine("人类会吃饭。");
            }

            public virtual void sleep() {
                Console.WriteLine("人类会睡觉。");
            }
        }

        public class ChinesePeople : People {
            public override void speak() {
                Console.WriteLine("中国人会说中文。");
            }

            public override void eat() {
                Console.WriteLine("中国人会吃中餐。");
            }

            public override void sleep() {
                Console.WriteLine("中国人会睡床。");
            }
        }

        public class AmericanPeople : People {
            public override void speak() {
                Console.WriteLine("美国人会说英文。");
            }

            public override void eat() {
                Console.WriteLine("美国人会吃西餐。");
            }

            public override void sleep() {
                Console.WriteLine("美国人会睡沙发。");
            }
        }
        #endregion
        #region  五（1）、设计并实现长方体类，该类的具体的功能如下： 从形状类(Shape)派生； 计算长方体的体积； 计算长方体的表面积； 具有构造函数，可在创建长方体对象时，指定长方体的特征； 长方体的特征包括int 长、int 宽、 int高； 长方体的长宽高均不超过50；
        public class Shape {
            public Shape() {
            }
        }

        public class Cuboid : Shape {
            private int length;
            private int width;
            private int height;
            public Cuboid(int length, int width, int height) {

                if (length > 0 && length <= 50 && width > 0 && width <= 50 && height > 0 && height <= 50) {
                    this.length = length;
                    this.width = width;
                    this.height = height;
                } else {
                    throw new ArgumentException("The length, width and height of the cuboid must be between 1 and 50.");
                }
            }

            // 计算长方体的体积的方法，返回int类型
            public int getVolume() {
                return length * width * height;
            }

            // 计算长方体的表面积的方法，返回int类型
            public int getSurfaceArea() {
                return (length * width + length * height + width * height) * 2;
            }
        }

        #endregion
        #region 五（2）、设计并实现圆锥类，该类的具体的功能如下： 从形状类(Shape)派生；  计算圆锥体的体积； 计算圆锥体的表面积； 具有构造函数，可在创建圆锥体对象时，指定圆锥体的特征； 长方体的特征包括int 半径、int 高； 长方体的半径和高均不超过50；
        public class ShapeNew {
            // Shape class implementation
        }

        public class Cone : ShapeNew {
            private int radius;
            private int height;

            public Cone(int radius, int height) {
                if (radius > 50 || height > 50) {
                    throw new ArgumentException("半径和高的值不能超过50");
                }

                this.radius = radius;
                this.height = height;
            }

            public double CalculateVolume() {
                return Math.PI * Math.Pow(radius, 2) * height / 3;
            }

            public double CalculateSurfaceArea() {
                return Math.PI * radius * (radius + Math.Sqrt(Math.Pow(height, 2) + Math.Pow(radius, 2)));
            }
        }
        #endregion

        #region 六、当你同时和两个人谈话，分别是中国人和美国人，如果想和这两人交流，那么必须对中国人说汉语，对美国人说英语  用抽象类实现
        public abstract class Person1 {
            public abstract string Speak();
        }

        public class Chinese1 : Person1 {
            public override string Speak() {
                return "你好，我是中国人。";
            }
        }

        public class American1 : Person1 {
            public override string Speak() {
                return "Hello, I'm American.";
            }
        }

        #endregion
    }
}
