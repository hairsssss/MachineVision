using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfromComBox4
{
    public partial class Form1 : Form
    {
        bool isTrue = true;
        public Form1()
        {
            InitializeComponent();

            this.comboBox1.Text = "请选择";
            //下拉框设置元素
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            comboBox1.Items.Add("6");
            comboBox1.Items.Insert(1, "wangwu");



       
          //  //          //将在索引为i的条目后面插入一条新条目
          //  comboBox1.Items.Remove("在此放入你要移除条目的文本内容");
            //          //删除是用的是文本内容，而不是索引
            //          comboBox1..Items.Clear();
         
                     //取消所有选中项，即变为未选中状态
            //   comboBox1.SelectedItem 获取选择项
            
                //获取选择项集合
          //  comboBox1.Items.Contains(checkPeople) 是否包含

            //总结：comboBox1.Items和 listBox1.Items  都是集合 而且都是相同类型 所以方法和属性通用


            //默认选择项
              comboBox1.SelectedIndex = 2;  

            //this.comboBox1.SelectedItem.ToString();//当前选择的Item的显示值
        }
        //给下拉框绑定内容选择后的事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (comboBox1.SelectedIndex != -1 && isTrue ==true) 
            {
                isTrue = false;
                return;
            }
            //获取当前的选中项
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }
    }
}
