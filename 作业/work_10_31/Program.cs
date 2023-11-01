using System;
using System.Threading;

namespace work_10_31 {
    internal class Program {
        static void Main(string[] args) {
            //1
            //while (true) {
            //    if (int.TryParse(Console.ReadLine(), out int age)) {
            //        int price = Ticketing.FareFun(age);
            //        Console.WriteLine($"该游客今年{age}岁，门票应付{price}元");
            //        break;
            //    } else {
            //        Console.Write("格式错误，请重新输入年龄：");
            //    }
            //}


            //2
            /*List<Fruit> fruitList = new List<Fruit>();
            {
                fruitList.Add(new Fruit("苹果", 1.9));
                fruitList.Add(new Fruit("香蕉", 4.3));
                fruitList.Add(new Fruit("草莓", 2.0));
                fruitList.Add(new Fruit("桃子", 6.0));
            };

            Console.WriteLine("可购买的水果：");
            double totalCost = 0;
            bool continueShopping = true;
            List<shoppingCart> shoppingCart = new List<shoppingCart>();

            while (continueShopping) {
                Console.Clear();
                Console.WriteLine("可购买的水果：");
                foreach (var item in fruitList) {
                    Console.WriteLine($"{item.Name} - 价格: {item.Price:C}");
                }

                Console.Write("请输入要购买的水果名称：");
                string selectedFruitName = Console.ReadLine();

                Fruit selectedFruit = fruitList.Find(fruit => fruit.Name == selectedFruitName);

                if (selectedFruit != null) {
                    Console.Write("请输入购买的数量：");
                    if (int.TryParse(Console.ReadLine(), out int count) && count > 0) {
                        double purchaseCost = selectedFruit.Price * count;
                        totalCost += purchaseCost;

                        Console.WriteLine($"购买价格：{purchaseCost:C}");
                        Console.WriteLine($"总价格：{totalCost:C}");

                        // 记录已购买的水果和数量
                        shoppingCart.Add(new shoppingCart {
                            Name = selectedFruit.Name,
                            Quantity = count
                        });

                        Console.Write("继续购买吗？ (Y/N): ");
                        continueShopping = (Console.ReadLine().Trim().ToLower() == "y");
                    } else {
                        Console.WriteLine("数量无效。");
                    }
                } else {
                    Console.WriteLine("水果不存在或不可购买，按任意键继续购买。");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("已购买的水果：");
            foreach (var item in shoppingCart) {
                Console.WriteLine($"{item.Name} - 数量: {item.Quantity}");
            }

            Console.WriteLine($"总购买价格：{totalCost:C}");
            Console.WriteLine("谢谢惠顾！");*/


            //3
            Random random = new Random();
            Hero hero = new Hero(100);
            Monster monster = new Monster(100);
            while (true) {
                Thread.Sleep(200);
                if (hero.ResurrectionCount >= 0) {
                    if (hero._HP <= 0) {
                        hero._HP = 100;
                    }
                    hero.Attack(monster, random.Next(10, 100));
                    monster.Attack(hero, 10);

                } else {
                    break;
                }
            }





            Console.ReadKey();
        }
        //4
        public class ExampleClass {
            public string _field1;
            public int _field2;
            public double _field3;
        }
        public class ExampleClass1 {
            public string _Property1 { get; set; }
            public int _Property2 { get; set; }
            public double _Property3 { get; set; }
        }

        // 门票
        public class Ticketing {
            internal static int _fare = 88;
            internal static int FareFun(int age) {
                if (age >= 1 && age <= 6 || age >= 60) {
                    _fare = 0;
                    return _fare;
                } else if (age > 6 && age < 18) {
                    _fare /= 2;
                    return _fare;
                } else if (age >= 18 && age < 60) {
                    return _fare;
                } else {
                    return 0;
                }
            }
        }

        //水果
        internal class Fruit {
            public string Name { get; set; }
            public double Price { get; set; }

            public Fruit(string name, double price) {
                Name = name;
                Price = price;
            }

        }
        internal class shoppingCart {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }


        //互殴
        internal class Hero {
            public int _HP { get; set; } = 100;
            public int _KillsNumber { get; set; } = 0;
            public Hero(int hP) {
                _HP = hP;
            }
            public int _ResurrectionCount = 1;
            public int ResurrectionCount {
                set {
                    if (_HP <= 0) {
                        _ResurrectionCount -= 1;
                        _HP = 100;
                    }
                }
                get { return _ResurrectionCount; }
            }




            public void Attack(Monster monster, int harm) {
                monster._HP -= harm;
                if (monster._HP <= 0) {
                    _KillsNumber += 1;
                    Console.WriteLine($"英雄第{_KillsNumber}次击杀怪物！");
                }
                Console.WriteLine($"英雄对怪物造成{harm}的伤害！");
            }

        }
        internal class Monster {
            public int _HP { get; set; } = 100;
            public Monster(int hP) {
                _HP = hP;
            }
            public void Attack(Hero hero1, int harm) {
                hero1._HP -= harm;
                if (hero1._HP <= 0) {
                    hero1.ResurrectionCount -= 1;
                    _HP = 100;
                }
                Console.WriteLine($"怪物对英雄造成{harm}的伤害，英雄还剩余{hero1._HP}的血量,{hero1._ResurrectionCount}------");
                if (hero1._ResurrectionCount < 0) {
                    Console.WriteLine("英雄牺牲了");
                } else {
                    Console.WriteLine("英雄继续战斗");
                }
            }
        }

    }
}