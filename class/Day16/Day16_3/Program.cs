using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Day16_3 {


    internal class Program {
        static void Main(string[] args) {





            Heater heater = new Heater();
            //事件对象绑定方法
            heater.BoilEvent += Heater1;
            heater.BoilEvent += Heater2;

            //绑定普通的匿名函数
            heater.BoilEvent += delegate (int x) { Console.WriteLine("当前水温为{0}可以洗澡了", x); };


            //绑定lambda匿名函数
            heater.BoilEvent += x => { Console.WriteLine("当前水温为{0}可以沐浴了", x); };
            Heater.BoilEvent1 += Heater1;
            Heater.BoilEvent1 += Heater1;


            heater.BoilEvent2 += Heater2;

            heater.BoilWater();
            Console.ReadKey();
        }


        public static void Heater1(int x) {

            Console.WriteLine("当前水温为{0}可以泡茶了", x);
        }

        public static void Heater2(int x) {
            Console.WriteLine("当前水温为{0}可以泡咖啡了", x);
        }
    }

    //负责烧水的类
    public class Heater {


        private int temperature;//水温
        public delegate void BoilHandle(int x);//声明关于事件的委托
        //实例事件对象
        public event BoilHandle BoilEvent;//声明水要烧开的事件
        //静态事件对象
        public static event BoilHandle BoilEvent1;//声明水要烧开的事件
        //
        public event Action<int> BoilEvent2;
        //烧水方法 
        public void BoilWater() {

            //模拟烧水的过程
            for (int i = 0; i <= 100; i++) {
                temperature = i;
                if (temperature > 95) {


                    Console.WriteLine("水烧开了");
                    //Program.Heater1(temperature);
                    //Program.Heater2(temperature);
                    BoilEvent(temperature);
                    BoilEvent1(temperature);
                    BoilEvent2(temperature);

                }
            }
        }
    }
}
