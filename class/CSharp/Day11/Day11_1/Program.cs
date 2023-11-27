using System;

namespace Day11_1 {
    internal class Program {

        static double totalPrice;
        static void Main(string[] args) {
            /*
 //字段版本和属性版本
1.一个景区根据游人的年龄收取不同价格的门票，请编写游人类，根据年龄段决定能够购买门票价格并输出


2.购买水果商品   编写大于3个不同水果类 用户可以输入 购买 什么商品和数量   然后 计算水果总价格
3.写一个回合制游戏      编写 英雄类  和敌人类 英雄和敌人 互动对打    （英雄和敌人都有初始血量 英雄攻击是随机数字    敌人攻击时固定数字，血量率先为0的 死亡  如果英雄 死亡   可以重生一次 如果敌人死亡  可以无限复活 最后看能击杀怪物的个数）
4.自己找三个字段和属性的例子
             */

            People zhangsan = new People();
            zhangsan._age = 50;
            People lisi = new People();
            lisi._age = 30;
            People wangwu = new People();
            wangwu._age = 10;

            ScenicSpot.ScenicSpotMothdd(zhangsan);
            ScenicSpot.ScenicSpotMothdd(lisi);
            ScenicSpot.ScenicSpotMothdd(wangwu);
            Console.WriteLine("剩余金额为{0}", People._money);




            People1 zhangsan1 = new People1();
            zhangsan1.Age = 50;
            People1 lisi1 = new People1();
            lisi1.Age = 30;
            People1 wangwu1 = new People1();
            wangwu1.Age = 10;

            ScenicSpot1.ScenicSpotMothdd(zhangsan1);
            ScenicSpot1.ScenicSpotMothdd(lisi1);
            ScenicSpot1.ScenicSpotMothdd(wangwu1);
            Console.WriteLine("剩余金额为{0}", People1.Money);



            //2.

            Console.WriteLine("请选择购买1.苹果 2.香蕉 3.梨");

            string strNumber = Console.ReadLine();
            if (strNumber == "1") {

                Console.WriteLine("请选择苹果数量:");
                string strCount = Console.ReadLine();
                totalPrice += Apple.ApplePrice * int.Parse(strCount);

                Console.WriteLine("是否要购买其他（x/y）:");

            }


            Console.WriteLine(totalPrice);
            Console.ReadKey();
        }
    }

    internal class People {


        public int _age;
        public static double _money = 300;

    }
    internal class ScenicSpot {
        public static int _ticketPrice;
        public static void ScenicSpotMothdd(People p) {

            if (p._age >= 60) {

                Console.WriteLine("免票");
                _ticketPrice = 0;
                People._money -= _ticketPrice;


            } else if (p._age >= 18 && p._age < 60) {

                Console.WriteLine("全价票");
                _ticketPrice = 120;
                People._money -= _ticketPrice;
            } else {

                Console.WriteLine("半价票");
                _ticketPrice = 60;
                People._money -= _ticketPrice;
            }



        }

    }


    internal class People1 {


        private int _age;
        public int Age { get { return _age; } set { _age = value; } }
        private static double _money = 300;
        public static double Money { get { return _money; } set { _money = value; } }

    }
    internal class ScenicSpot1 {
        private static int _ticketPrice;

        public static void ScenicSpotMothdd(People1 p) {

            if (p.Age >= 60) {

                Console.WriteLine("免票");
                _ticketPrice = 0;
                People1.Money -= _ticketPrice;


            } else if (p.Age >= 18 && p.Age < 60) {

                Console.WriteLine("全价票");
                _ticketPrice = 120;
                People1.Money -= _ticketPrice;
            } else {

                Console.WriteLine("半价票");
                _ticketPrice = 60;
                People1.Money -= _ticketPrice;
            }

        }






    }
    public class Apple {

        public static double ApplePrice { get; set; } = 10;

        public static int AppleCount { get; set; } = 10;

    }

    public class Banana {

        public static double BananaPrice { get; set; }
        public static int BananaCount { get; set; } = 20;
    }
    public class Pear {

        public static double PearPrice { get; set; }
        public static int PearCount { get; set; } = 30;
    }
}
