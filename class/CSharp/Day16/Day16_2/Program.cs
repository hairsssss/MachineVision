using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_2 {
    public delegate void MyDelegate();
    internal class Program {
        static void Main(string[] args) {

            /*
    委托的多播
1.委托对象可使用 "+=" 运算符进行合并。
2."-=" 运算符可用于从合并的委托中移除组件委托
3.只有相同类型的委托可被合并
             */

            MyDelegate myDelegate = new MyDelegate(ProgramMothod);
            myDelegate += ProgramMothod1;
            myDelegate();
            myDelegate += ProgramMothod2;
            myDelegate();
            Console.WriteLine("----------");
            myDelegate -= ProgramMothod1;
            myDelegate();



            Action action = new Action(ProgramMothod);
            action += ProgramMothod1;
            action += ProgramMothod2;
            action();
            action -= ProgramMothod2;
            action();



            People people = new People();
            people.PeopleMothod();

            People people1 = new People(action);
            people1.Action1();

            people1.PeopleMothod2(action, null, null, null);
            Console.ReadKey();
        }

        public static void ProgramMothod() {

            Console.WriteLine("ProgramMothod");
        }
        public static void ProgramMothod1() {

            Console.WriteLine("ProgramMothod1");
        }
        public static void ProgramMothod2() {

            Console.WriteLine("ProgramMothod2");
        }
    }


    public class People {

        private Action action;


        private Action _action1;

        public Action Action1 { get { return _action1; } set { _action1 = value; } }

        public People() {



        }
        public People(Action action1) {

            _action1 = action1;

        }

        public void PeopleMothod() {

            this.action = new Action(PeopleMothod1);
            action();

        }


        private void PeopleMothod1() {

            Console.WriteLine("111");

        }

        public void PeopleMothod2(Action action, Func<int> func1, Action<string> action1, Func<bool, string> func, params Action<int>[] actionsArray) {
            action();
            func1();
            action1("123");
            func(true);

        }
    }
}
