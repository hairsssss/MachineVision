/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondExam {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }



        #region 3.界面版 老鼠来了   猫叫了 人醒了  利用事件完成

        #endregion

        private void MouseBtn_click(object sender, EventArgs e) {
            timer1.Start();
        }

        //老鼠制造噪音次数
        internal int VoiceCount { get; set; }
        //随机猫咪第几次醒来
        internal int CatWakeCount { get; set; }

        private void MouseVoice(object sender, EventArgs e) {
            MouseMakeVoice();

            if (CatWakeCount == VoiceCount) {
                timer1.Stop();
                CatWake();
            }
        }

        private void MouseMakeVoice() {
            VoiceCount += 1;
            textBox1.Text = $"老鼠出来偷东西了,第{VoiceCount}次发出响声。";
        }

        private async void CatWake() {
            textBox1.Text = $"老鼠出来偷东西了,第{VoiceCount}次发出响声，猫咪在第{CatWakeCount}次醒了过来。";
            await Task.Delay(2000);
            PeopleWake();
        }
        private void PeopleWake() {
            textBox1.Text = $"猫咪抓老鼠声音太大，主人被吵醒了。";
        }

        private void PageLoad(object sender, EventArgs e) {
            Random random = new Random();
            CatWakeCount = random.Next(1, 5);
        }
    }
}
*/
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondExam {
    public partial class Form1 : Form {
        // 定义老鼠叫声的委托
        public delegate void MouseSoundEventHandler();

        // 定义猫抓老鼠的委托
        public delegate void CatCatchMouseEventHandler();

        // 定义人醒来的委托
        public delegate void PersonWakeUpEventHandler();

        // 定义老鼠叫声事件
        public event MouseSoundEventHandler MouseSoundEvent;

        // 定义猫抓老鼠事件
        public event CatCatchMouseEventHandler CatCatchMouseEvent;

        // 定义人醒来事件
        public event PersonWakeUpEventHandler PersonWakeUpEvent;

        public Form1() {
            InitializeComponent();
        }

        internal int VoiceCount { get; set; }
        internal int CatWakeCount { get; set; }

        private void MouseBtn_click(object sender, EventArgs e) {
            // 启动计时器
            timer1.Start();
        }

        private void MouseVoice(object sender, EventArgs e) {
            MouseMakeVoice();

            if (CatWakeCount == VoiceCount) {
                timer1.Stop();
                CatWake();
            }
        }

        private void MouseMakeVoice() {
            VoiceCount += 1;
            textBox1.Text = $"老鼠出来偷东西了，第{VoiceCount}次发出响声。";
            // 触发老鼠叫声事件
            MouseSoundEvent?.Invoke();
        }

        private async void CatWake() {
            textBox1.Text = $"老鼠出来偷东西了，第{VoiceCount}次发出响声，猫咪在第{CatWakeCount}次醒了过来。";
            await Task.Delay(2000);
            PeopleWake();
        }

        private void PeopleWake() {
            textBox1.Text = $"猫咪抓老鼠声音太大，主人被吵醒了。";
            // 触发人醒来事件
            PersonWakeUpEvent?.Invoke();
        }

        private void PageLoad(object sender, EventArgs e) {
            Random random = new Random();
            CatWakeCount = random.Next(1, 5);
        }
    }
}
