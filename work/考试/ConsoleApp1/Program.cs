using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {
            #region  1.写一个回合制游戏      编写 英雄类  和敌人类 英雄和敌人 互动对打    （英雄和敌人都有初始血量 英雄攻击是随机数字    敌人攻击时固定数字，血量率先为0的 死亡  如果英雄 死亡   可以重生一次 如果敌人死亡  可以无限复活 最后看能击杀怪物的个数）     
            Random random = new Random();
            Hero hero = new Hero(100);
            Monster monster = new Monster(100);
            while (hero.HealthyConut >= 0) {
                if (hero.HP <= 0) {
                    hero.HP = 100;
                }
                hero.Attack(monster, random.Next(10, 100));
                monster.Attack(hero, 10);
            }
            #endregion

            #region 2.返回stirng类型 有两个参数  分别类型为 字符串静态数组  list字符串数组 让两个数组中的元素进行 +操作 定义委托来实现方法的调用
            string[] strList = new string[] { "a", "b", "c" };
            List<string> strList1 = new List<string>() { "d", "e", "f" };

            Func<string[], List<string>, string> joinStr = (array, list) => {
                StringBuilder str = new StringBuilder();
                foreach (string item in array) {
                    str.Append(item);
                }
                foreach (string item in list) {
                    str.Append(item);
                }
                return str.ToString();
            };
            Console.WriteLine(joinStr(strList, strList1));
            #endregion
        }


        #region  1.写一个回合制游戏      编写 英雄类  和敌人类 英雄和敌人 互动对打    （英雄和敌人都有初始血量 英雄攻击是随机数字    敌人攻击时固定数字，血量率先为0的 死亡  如果英雄 死亡   可以重生一次 如果敌人死亡  可以无限复活 最后看能击杀怪物的个数）     
        public class Hero {
            public int Killscount { get; set; } = 0;
            public int HealthyConut { get; set; } = 1;
            public int HP { get; set; }
            public Hero(int hp) {
                HP = hp;
            }
            public void Attack(Monster monster, int harm) {
                monster.HP -= harm;
                if (monster.HP <= 0) {
                    Killscount += 1;
                    Console.WriteLine($"英雄第{Killscount}次击杀怪物！");
                }
            }
        }
        public class Monster {
            public int HP { get; set; }
            public Monster(int hp) {
                HP = hp;
            }
            public void Attack(Hero hero, int harm) {
                hero.HP -= harm;
                if (hero.HP <= 0) {
                    hero.HealthyConut -= 1;
                }
            }
        }
        #endregion
    }
}
