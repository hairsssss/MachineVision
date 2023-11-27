using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17_1 {
    internal class Program {
        public static event Action MouseSoundEvent;
        public static event Action CatCatchMouseEvent;
        public static event Action PersonWakeUpEvent; static void MakeMouseSound() {
            Console.WriteLine("老鼠叫了一声！");
            // 触发老鼠叫的事件
            MouseSoundEvent?.Invoke();
        }

        static void OnMouseSound() {
            Console.WriteLine("猫听到老鼠叫声，开始抓老鼠！");

            // 模拟猫叫三次
            for (int i = 0; i < 3; i++) {
                MakeCatSound();
            }
        }

        static void MakeCatSound() {
            Console.WriteLine("猫叫了一声！");
            // 触发猫叫的事件
            CatCatchMouseEvent?.Invoke();
        }

        static void OnCatCatchMouse() {
            Console.WriteLine("人听到猫抓老鼠的声音，醒了过来！");
            // 触发人醒来的事件
            PersonWakeUpEvent?.Invoke();
        }
        static void Main(string[] args) {
            // 订阅事件
            MouseSoundEvent += OnMouseSound;
            CatCatchMouseEvent += OnCatCatchMouse;

            // 模拟老鼠叫，触发事件
            MakeMouseSound();
        }
    }
}
