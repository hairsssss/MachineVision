using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day20_1 {
    internal static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        // C#特性 作用描述：某些方法或者类 类似注释效果
        [STAThread]
        //是 C# 中的一个属性（Attribute），用于指定应用程序的主线程模型。在 Windows Forms 应用程序中，通常需要使用单线程单元（STA，Single-Threaded Apartment）模型来确保正确的线程同步。
        //具体来说，[STAThread] 属性用于标记 Main 方法或者程序的入口点，以确保应用程序使用单线程单元模型。这对于涉及 COM(Component Object Model) 组件或者涉及 UI 操作的 Windows Forms 应用程序是很重要的。

        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application 用来处理程序启动关闭管理等功能类

            //Run 用来启动窗体应用
            Application.Run(new Form1());
        }
    }
    //partial 只能继承一个基类
    public partial class People {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class People {
        public int Age { get; set; }
    }
}
