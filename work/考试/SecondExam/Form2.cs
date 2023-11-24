using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondExam {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private List<Button> GetAllButtons(Control container) {
            List<Button> buttonList = new List<Button>();

            var buttonList1 = container.Controls.OfType<Button>().ToList();
            buttonList.AddRange(buttonList1);

            return buttonList;
        }

        private List<Button> AllButtons;
        private void PageLoad(object sender, EventArgs e) {

            AllButtons = GetAllButtons(this);
            foreach (var btn in AllButtons) {
                if (btn.Text != "清空") {
                    btn.Click += btn_Click;
                }
            }

        }
        private string TextStr { get; set; }
        private char OP { get; set; }
        private int num1 { get; set; } = 0;
        private int num2 { get; set; } = 0;

        private void btn_Click(object sender, EventArgs e) {
            List<string> list1 = new List<string>();
            list1.Add("+");
            list1.Add("-");
            list1.Add("*");
            list1.Add("/");
            Button btnItem = (Button)sender;
            TextStr += btnItem.Text;
            textBox1.Text = TextStr;
            foreach (var item in list1) {
                //输入符号
                if (btnItem.Text == item) {
                    string[] list = TextStr.Split(item[0]);

                    //第一个数字
                    num1 = int.Parse(list[0]);

                    //运算符
                    OP = item[0];
                    break;
                } else if (btnItem.Text == "=") {
                    // 去掉末尾的等号
                    TextStr = TextStr.TrimEnd('=');
                    string[] list = TextStr.Split(OP);

                    // 第二个数字
                    num2 = int.Parse(list[1]);
                    textBox1.Text = CalculateResult();
                    break;
                }
            }
        }
        private string CalculateResult() {
            int numResult = 0;
            switch (OP) {
                case '+':
                    numResult = num1 + num2;
                    break;
                case '-':
                    numResult = num1 - num2;
                    break;
                case '*':
                    numResult = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0) {
                        MessageBox.Show("除数不能为零");
                        return "0";
                    }
                    numResult = num1 / num2;
                    break;
            }
            return numResult.ToString();
        }

        private void CleanTextBox(object sender, EventArgs e) {
            TextStr = "";
            textBox1.Text = "";
        }
    }
}

