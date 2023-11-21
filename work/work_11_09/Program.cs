using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_11_09 {
    internal class Program {
        static string JoinArrayAndList(string[] array, List<string> list) {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array) {
                sb.Append(s + ",");
            }
            foreach (string s in list) {
                sb.Append(s + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        #region Func 版本
        public class People {
            public string _name;
            public int _age;
            public string Name { get; set; }
            public int Age { get; set; }
            public People(string name, int age) {
                Name = name;
                Age = age;
            }
            public static People peopleStatic(People people, People people1) {
                return new People(
                    people.Name + people1.Name,
                    people.Age + people1.Age
                );
            }
        }
        #endregion

        #region Action版本
        static void PrintPeople(People people, People people1) {
            Console.WriteLine($"相加之后的Name是 {people.Name + people1.Name}, 相加之后的Age是 {people.Age + people1.Age}-----peopleAction");
        }
        #endregion


        #region 2.有一个抽奖功能 每天都会有一个随机号码 ，用户随机输入一个数字 如果用户输入的数字 和抽奖号码一致 利用事件 通知用户领奖 反之通知用户未中奖
        delegate void LotteryEventHandler();
        class Lottery {
            //定义一个静态字段，表示每天的随机号码，范围是1到100
            private static int luckyNumber = new Random().Next(1, 101);

            //定义两个事件对象，表示中奖和未中奖的事件
            public event LotteryEventHandler WinEvent;
            public event LotteryEventHandler LoseEvent;

            //定义一个方法，判断用户输入的数字是否和随机号码一致，如果是，触发中奖事件，否则，触发未中奖事件
            public void CheckNumber(int number) {
                if (number == luckyNumber) {
                    //触发中奖事件
                    WinEvent();
                } else {
                    //触发未中奖事件
                    LoseEvent();
                }
            }
        }
        //定义一个事件处理程序，表示中奖时要执行的操作，输出中奖信息
        static void Win() {
            Console.WriteLine("恭喜你，中奖了！请联系管理员领奖。");
        }

        //定义一个事件处理程序，表示未中奖时要执行的操作，输出未中奖信息
        static void Lose() {
            Console.WriteLine("很遗憾，未中奖，请再接再厉。");
        }
        #endregion
        #region 3.百度4个和事件相关的例子   
        #region 1
        //定义一个委托，表示事件处理程序的签名
        public delegate void TickHandler(object sender, EventArgs e);

        //定义一个计时器类，每隔一秒触发一个事件
        public class Timer {
            //定义一个类型为TickHandler的事件
            public event TickHandler Tick;

            //定义一个方法，启动计时器
            public void Start() {
                //创建一个System.Timers.Timer对象
                System.Timers.Timer timer = new System.Timers.Timer();
                //设置间隔为一秒
                timer.Interval = 1000;
                //订阅计时器的Elapsed事件
                timer.Elapsed += OnTick;
                //启动计时器
                timer.Start();
            }

            //定义一个方法，处理计时器的Elapsed事件
            private void OnTick(object sender, System.Timers.ElapsedEventArgs e) {
                //如果Tick事件不为空，就调用委托
                Tick?.Invoke(this, EventArgs.Empty);
            }
        }

        //定义一个订阅者类，处理计时器的Tick事件
        public class Subscriber {
            //定义一个方法，处理计时器的Tick事件
            public void HandleTick(object sender, EventArgs e) {
                //在控制台输出一条信息
                Console.WriteLine("计时器在{0}时刻触发了", DateTime.Now);
            }
        }
        #endregion

        #region 2
        //定义一个委托，表示事件处理程序的签名，有一个参数，类型为DateTime，表示闹钟的时间
        public delegate void AlarmHandler(DateTime time);

        //定义一个闹钟类，可以设置一个时间，当时间到达时，触发一个事件
        public class Alarm {
            //定义一个类型为AlarmHandler的事件
            public event AlarmHandler AlarmEvent;

            //定义一个字段，表示闹钟的时间
            private DateTime alarmTime;

            //定义一个属性，表示闹钟的时间，可以通过get和set访问
            public DateTime AlarmTime {
                get { return alarmTime; }
                set { alarmTime = value; }
            }

            //定义一个方法，启动闹钟
            public void Start() {
                //创建一个System.Timers.Timer对象
                System.Timers.Timer timer = new System.Timers.Timer();
                //设置间隔为一秒
                timer.Interval = 1000;
                //订阅计时器的Elapsed事件
                timer.Elapsed += OnTick;
                //启动计时器
                timer.Start();
            }

            //定义一个方法，处理计时器的Elapsed事件
            private void OnTick(object sender, System.Timers.ElapsedEventArgs e) {
                //获取当前的时间
                DateTime now = DateTime.Now;
                //如果当前的时间和闹钟的时间相等，就调用事件对象的委托，触发事件，并传递闹钟的时间
                if (now.Hour == alarmTime.Hour && now.Minute == alarmTime.Minute && now.Second == alarmTime.Second) {
                    AlarmEvent(alarmTime);
                }
            }
        }

        //定义一个订阅者类，处理闹钟的事件
        public class Subscriber1 {
            //定义一个方法，处理闹钟的事件
            public void HandleAlarm(DateTime time) {
                //在控制台打印一条信息，表示闹钟响了
                Console.WriteLine("闹钟在{0}时刻响了，起床吧！", time);
            }
        }


        #endregion

        #region 3
        //定义一个委托，表示事件处理程序的签名，没有参数，没有返回值
        public delegate void ClickHandler();

        //定义一个按钮类，可以模拟用户的点击操作，当用户点击按钮时，触发一个事件
        public class Button {
            //定义一个类型为ClickHandler的事件
            public event ClickHandler ClickEvent;

            //定义一个方法，模拟用户的点击操作
            public void Click() {
                //在控制台打印一条信息，表示用户点击了按钮
                Console.WriteLine("用户点击了按钮");
                //调用事件对象的委托，触发事件
                ClickEvent();
            }
        }

        //定义一个订阅者类，处理按钮的事件
        public class Subscriber2 {
            //定义一个方法，处理按钮的事件
            public void HandleClick() {
                //在控制台打印一条信息，表示按钮被点击了
                Console.WriteLine("按钮被点击了");
            }
        }

        #endregion

        #region 4
        public class MyClass {
            public delegate void ValueChangedDelegate();
            // 声明一个私有变量来存储值
            private int value;

            // 声明一个事件，它的类型是ValueChangedDelegate
            public event ValueChangedDelegate ValueChanged;

            // 提供一个公共方法来设置值，并在值改变时触发事件
            public void SetValue(int newValue) {
                if (value != newValue) {
                    value = newValue;
                    // 如果ValueChanged事件已经被订阅，那么调用它
                    if (ValueChanged != null) {
                        ValueChanged();
                    }
                }
            }
        }
        #endregion

        #endregion
        public class MyClass1 {
            public int Value { get; set; }

            // 重载 == 运算符
            public static bool operator ==(MyClass1 a, MyClass1 b) {
                return a.Value == b.Value;
            }

            // 重载 != 运算符
            public static bool operator !=(MyClass1 a, MyClass1 b) {
                return a.Value != b.Value;
            }
        }

        static void Main(string[] args) {
            #region 1.把昨天的例子 修改成Action 和Func版本      修改成 普通匿名函数版本  和 lambda版本

            #region Func 版本
            Func<People, People, People> peopleFunc = new Func<People, People, People>(People.peopleStatic);
            People peopleResult = peopleFunc(new People("李四", 19), new People("张三", 90));
            Console.WriteLine(peopleResult.Name);
            Console.WriteLine(peopleResult.Age);

            //使用普通匿名函数版本
            Func<People, People, People> peopleFunc1 = delegate (People people, People people1) {
                return new People(
                   people.Name + people1.Name,
                   people.Age + people1.Age
               );
            };
            People peopleResult1 = peopleFunc1(new People("李四", 19), new People("张三", 90));
            Console.WriteLine(peopleResult1.Name);

            //使用lambda版本
            Func<People, People, People> peopleFunc2 = (People people, People people1) => {
                return new People(
                    people.Name + people1.Name,
                    people.Age + people1.Age
                 );
            };
            People peopleResult2 = peopleFunc1(new People("李四", 19), new People("张三", 90));
            Console.WriteLine(peopleResult2.Name);
            #endregion

            #region Action版本
            Action<People, People> peopleAction = new Action<People, People>(PrintPeople);
            peopleAction(new People("李四", 19), new People("张三", 90));

            //普通匿名函数版本
            Action<People, People> peopleAction1 = delegate (People people, People people1) {
                Console.WriteLine($"相加之后的Name是 {people.Name + people1.Name}, 相加之后的Age是 {people.Age + people1.Age}-----peopleAction1");

            };
            peopleAction1(new People("李四", 19), new People("张三", 90));

            //使用lambda版本
            Action<People, People> peopleAction2 = (People people, People people1) => {
                Console.WriteLine($"相加之后的Name是 {people.Name + people1.Name}, 相加之后的Age是 {people.Age + people1.Age}-----peopleAction2");

            };
            peopleAction2(new People("李四", 19), new People("张三", 90));
            #endregion

            #region Func版本
            Func<string[], List<string>, string> joinFunc = new Func<string[], List<string>, string>(JoinArrayAndList);
            string[] strList = new string[] { "a", "b", "c" };
            List<string> strList1 = new List<string>() { "d", "e", "f" };
            string result = joinFunc(strList, strList1);
            Console.WriteLine(result);

            // 使用普通匿名函数版本
            Func<string[], List<string>, string> joinFunc1 = delegate (string[] array, List<string> list) {
                StringBuilder sb = new StringBuilder();
                foreach (string s in array) {
                    sb.Append(s + ",");
                }
                foreach (string s in list) {
                    sb.Append(s + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            };
            Console.WriteLine(joinFunc1(strList, strList1));

            //使用lambda版本
            Func<string[], List<string>, string> joinFunc2 = (array, list) => {
                StringBuilder sb = new StringBuilder();
                foreach (string s in array) {
                    sb.Append(s + ",");
                }
                foreach (string s in list) {
                    sb.Append(s + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            };
            Console.WriteLine(joinFunc2(strList, strList1));
            #endregion




            #endregion


            #region 2.有一个抽奖功能 每天都会有一个随机号码 ，用户随机输入一个数字 如果用户输入的数字 和抽奖号码一致 利用事件 通知用户领奖 反之通知用户未中奖
            Lottery lottery = new Lottery();
            //订阅抽奖对象的事件，将事件处理程序添加到事件的委托中
            lottery.WinEvent += Win;
            lottery.LoseEvent += Lose;

            while (true) {
                Console.Write("请输入一个1到100之间的数字：");
                int number = int.Parse(Console.ReadLine());
                //调用抽奖对象的方法，判断用户输入的数字是否中奖
                lottery.CheckNumber(number);

                Console.Write("是否继续抽奖？按Y继续，按其他键退出。");

                string input = Console.ReadLine();
                if (input != "Y") {
                    Console.WriteLine("用户退出程序！！");
                    break;
                }
            }
            #endregion


            #region 3.百度4个和事件相关的例子   

            #region 1
            //定义一个主程序类，创建一个计时器和一个订阅者对象

            //创建一个计时器对象
            Timer timer = new Timer();
            //创建一个订阅者对象
            Subscriber subscriber = new Subscriber();
            //订阅计时器的事件，将事件处理程序添加到委托中
            timer.Tick += subscriber.HandleTick;
            //启动计时器
            timer.Start();
            //等待用户按任意键退出
            Console.ReadKey();
            #endregion

            #region 2
            //定义一个主程序类，创建一个闹钟和一个订阅者对象
            //创建一个闹钟对象
            Alarm alarm = new Alarm();
            //创建一个订阅者对象
            Subscriber1 subscriber1 = new Subscriber1();
            //订阅闹钟的事件，将事件处理程序添加到委托中
            alarm.AlarmEvent += subscriber1.HandleAlarm;
            //设置闹钟的时间为当前时间的10秒后
            alarm.AlarmTime = DateTime.Now.AddSeconds(10);
            //启动闹钟
            alarm.Start();
            //等待用户按任意键退出
            Console.ReadKey();
            #endregion

            #region 3

            //定义一个主程序类，创建一个按钮和一个订阅者对象
            //创建一个按钮对象
            Button button = new Button();
            //创建一个订阅者对象
            Subscriber2 subscriber2 = new Subscriber2();
            //订阅按钮的事件，将事件处理程序添加到委托中
            button.ClickEvent += subscriber2.HandleClick;
            //模拟用户的点击操作
            button.Click();
            #endregion

            #region 4
            // 创建一个MyClass对象
            MyClass myObject = new MyClass();

            // 订阅ValueChanged事件
            myObject.ValueChanged += () => Console.WriteLine("Value has changed!");

            // 改变值，这将触发事件
            myObject.SetValue(10);
            #endregion


            #endregion


            #region 4.补充运算符重载            

            MyClass1 obj1 = new MyClass1 { Value = 5 };
            MyClass1 obj2 = new MyClass1 { Value = 10 };

            bool isEqual = obj1 == obj2; // 使用重载的 == 运算符
            bool isNotEqual = obj1 != obj2; // 使用重载的 != 运算符

            Console.WriteLine($"obj1 == obj2: {isEqual}"); // 输出：obj1 == obj2: False
            Console.WriteLine($"obj1 != obj2: {isNotEqual}"); // 输出：obj1 != obj2: True
            #endregion


        }
    }
}
