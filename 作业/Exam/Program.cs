using System;

namespace Exam {
    internal class Program {
        static void Main(string[] args) {
            // 选择题
            // A D B D A 
            // B B B D D
            // B B D D   15.ABCD

            // 1.C#中数据类型有哪些？详细说明具体的类型
            // 数据类型分为值类型和引用类型
            // 数据类型有 int 32位无符号整数类型  uint 32位有符号整数类型     float 浮点类型  ufloat 有符号浮点类型       bool 布尔  double
            // 引用类型有 string 字符串类型


            // 2.C#中的值类型和引用类型有什么区别?
            // 值类型存储的是数据，而引用类型存储的是地址。


            // 3.重写和重载的区别 ?
            // 重载是在本类中声明多个同名的函数，但是接受的参数个数、参数类型不同。根据传入的参数类型、个数的不同，选择调用相应的函数。
            // 重写是在派生类中定义一个与基类中同名的函数，用来覆盖其基类的同名函数，当调用派生类的同名函数时，触发的是派生类的函数，忽略基类的同名函数。


            // 4.c#语言的三大特性有哪些？分别都有什么作用？
            // 封装：讲数据和函数集成到一个类中，方便数据的访问和函数的调用。
            // 多态：重写和重载就是多态的体现。
            // 继承：派生类继承基类的数据、函数、构造函数等，派生类也可在基类的基础上对派生类的构造函数、方法等进行进一步的完善和修改，以达到派生类的需求。


            // 5.C#中参数传递 ref 与 out 的分别有什么用处？



            // 6.字符串中string str = null和string str = ""和string str = string.Empty的区别
            // string str = null;         表示str暂时没有值，但是以后可能会有值。
            // string str = "";           表示str是一个空字符串。
            // string str = string.Empty  表示str是一个字符串对象。


            // 7.const和readonly有什么区别？
            //const在定义变量时必须赋值，readonly不需要赋值。


            // 8.简述C#成员访问修饰符有哪些
            // public：可以再任何地方访问。
            // private：只能在当前类中访问。
            // internal：只能在当前程序集中访问。
            // protected：只能在当前类和派生类中访问。


            // 9.抽象类 的特点有那些？
            // 使用abstract关键字定义
            // 其他类可以从派生类继承
            // 具有多态性


            // 10.C#中的属性是什么？如何定义和使用属性
            //  public class Exam {
            //    public int num { get; set; }
            //  }
            // 使用public int num {  get; set; }定义属性，使用Exam.num访问属性。


            // 11.this和base的含义
            // 谁调用谁就是this
            // base是基类


            // 12.string和StringBuilder的区别,两者性能的比较
            // string是不可变字符串stringBuilder是可变字符串。
            // string不能在原来的数据上进行修改，严格意义上来说修改后会生成一个新的字符串。
            // StringBuilder可以在原数据上进行修改。性能上会比string更好。


            // 13.C#中值传递与引用传递的区别是什么
            // 值传递传递的是数据本身，引用传递传递的是数据的地址。


            // 14.int? 和int有什么区别
            // int?可以定义null，int不行。


            // 15.什么是CLR（Common Language Runtime）有什么作用？
            // 中间语言转换，将不同的语言转换为C#



            // 1.创建一个int类型三维数组维度分别为2，2，4，从键盘接收其值；当用户输入非法时，提示重新输入；  直到整个3为数组元素填满，然后 计算数组中的元素平均值
            //int[,,] examArr = new int[2, 2, 4];
            //int totalElements = 2 * 2 * 4;
            //int elementCount = 0;
            //int sum = 0;

            //for (int i = 0; i < 2; i++) {
            //    for (int j = 0; j < 2; j++) {
            //        for (int k = 0; k < 4; k++) {
            //            while (true) {
            //                Console.Write($"请输入[{i},{j},{k}]: ");
            //                if (int.TryParse(Console.ReadLine(), out int value)) {
            //                    examArr[i, j, k] = value;
            //                    elementCount++;
            //                    sum += value;
            //                    break;
            //                } else {
            //                    Console.WriteLine("格式错误，请重新输入：");
            //                }
            //            }
            //        }
            //    }
            //}

            //double result = sum / totalElements;
            //Console.WriteLine($"平均值为{result}");


            // 2.使用抽象类完成：当你去中国四大银行办理业务时 所有银行业务，有存钱，取钱功能，还有账号余额属性

            #region 3.写一个回合制游戏      编写 英雄类  和敌人类 英雄和敌人 互动对打    （英雄和敌人都有初始血量 英雄攻击是随机数字    敌人攻击时固定数字，血量率先为0的 死亡  如果英雄 死亡   可以重生一次 如果敌人死亡  可以无限复活 最后看能击杀怪物的个数）
            Random random = new Random();
            Hero hero = new Hero(100);
            Monster monster = new Monster(100);
            while (hero._healthyConut >= 0) {
                if (hero._HP <= 0) {
                    hero._HP = 100;
                }
                hero.Attack(monster, random.Next(10, 100));
                monster.Attack(hero, 10);

            }
            #endregion

            #region 4.设计一个苹果购买程序 苹果类 具有价格和保质期 属性 超过保质期的苹果价格是原来价格的一半 假如超市现有30个苹果 其中有10个过期的 客户任意买10个苹果 计算苹果总价格。
            Random random1 = new Random();
            int count = random1.Next(1, 11);
            int total = 0;
            int forConut = 10 - count;
            if (forConut > 0) {
                for (int i = 0; i < forConut; i++) {
                    Apple apple = new Apple(100);
                    total += apple.Price;
                }
            }
            for (int i = 0; i < count; i++) {
                Apple apple = new Apple(-10);
                total += apple.Price;
            }
            Console.WriteLine($"苹果总价为{total}");
            #endregion
        }
        #region 3.写一个回合制游戏      编写 英雄类  和敌人类 英雄和敌人 互动对打    （英雄和敌人都有初始血量 英雄攻击是随机数字    敌人攻击时固定数字，血量率先为0的 死亡  如果英雄 死亡   可以重生一次 如果敌人死亡  可以无限复活 最后看能击杀怪物的个数）
        public class Hero {
            public int _HP;
            public int _killscount = 0;
            public int _healthyConut = 1;
            public int HP { get { return _HP; } }
            public Hero(int hp) {
                _HP = hp;
            }
            public void Attack(Monster monster, int harm) {
                monster._HP -= harm;
                if (monster._HP <= 0) {
                    _killscount += 1;
                    Console.WriteLine($"英雄第{_killscount}次击杀怪物！");
                }
            }
        }
        public class Monster {
            public int _HP;
            public int HP { get { return _HP; } }
            public Monster(int hp) {
                _HP = hp;
            }
            public void Attack(Hero hero, int harm) {
                hero._HP -= harm;
                if (hero._HP <= 0) {
                    hero._healthyConut -= 1;
                }
            }
        }
        #endregion


        #region 4.设计一个苹果购买程序 苹果类 具有价格和保质期 属性 超过保质期的苹果价格是原来价格的一半 假如超市现有30个苹果 其中有10个过期的 客户任意买10个苹果 计算苹果总价格。
        public class Apple {
            public int _price = 10;
            public int _freshTime = 100;
            public Apple(int num) {
                _freshTime = num;
            }
            public int Price {
                get { return _price; }
                set {
                    if (_freshTime <= 0) {
                        _price = value / 2;
                    }
                }
            }
        }
        #endregion
    }
}
