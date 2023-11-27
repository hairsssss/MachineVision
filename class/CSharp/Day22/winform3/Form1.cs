using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace winform3
{

    /*
     ListBox是WinForm中的 列表 控件，它提供了一个项目列表(一组数据项)，
    用户可以选择一个或者多个条目，当列表项目过多时，ListBox会自动添加滚动条，、
    使用户可以滚动查阅所有选项。ListBox可以预先设定列表内容，
    也可以绑定其他控件或数据库，自动更新条目，把数据逐一显示出来
     
     */
    public partial class Form1 : Form
    {

        private bool isBool = false;
        public Form1()
        {
            InitializeComponent();
           // this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            //添加数据到listBox中
            this.listBox1.Items.Add("zhangsan");
            this.listBox1.Items.Add("lisi");
            this.listBox1.Items.Add("wangwu");
            this.listBox1.Items.Add("zhaoliu");
            this.listBox1.Items.Add("aaaa");

            
            //在指定位置的 插入元素
            this.listBox1.Items.Insert(1,"wangwu123");

            // 删除指定的元素
             this.listBox1.Items.Remove("lisi");
            //清空列表
            //   this.listBox1.Items.Clear();
            //设置或者获取 当前选择的项  通过设置索引值
            this.listBox1 .SelectedIndex = 1;

            //获取一个选择项
            // this.listBox1.SelectedItem;
            //获取多个选择项 
          //  this.listBox1.SelectedItems
            /*
    listBox1.Items.Add("要增加的条目文本");   
     //将在列表后面添加
listBox1.Items.Insert(i, "要增加的条目文本");  
     //将在索引为i的条目后面插入一条新条目
listBox1.Items.Remove("在此放入你要移除条目的文本内容");  
     //删除是用的是文本内容，而不是索引
listBox1.Items.Clear();                               
    //清空列表所有条目
listBox1.ClearSelected();                         
    //取消所有选中项，即变为未选中状态
   listBox1.SelectedItem 获取选择项
   listBox1.SelectedItems 获取选择项集合
   listBox2.Items.Contains(checkPeople) 是否包含
             */
            //细化多个转移  和方法的封装

            //手动绑定事件
            button1.Click += btnRightMove_Click;
            button2.Click += btnLeftMove_Click;




        }

        //右移数据事件
        private void btnRightMove_Click(object sender, EventArgs e)
        {
            
         //获取listbox1的所有选中的项
            if (this.listBox1.SelectedItems.Count > 0)
            {
                //选中的一项 （单个移入）
                string checkPeople = this.listBox1.SelectedItem.ToString();

                //判断是否添加到listbox2
                if (!this.listBox2.Items.Contains(checkPeople))
                {
                    //添加人员到listbox2中
                    this.listBox2.Items.Add(checkPeople);
                    //移除listbox1中
                    this.listBox1.Items.Remove(checkPeople);
                }
                else
                {
                    MessageBox.Show("该人员已经转移过，无法重复转移！");
                }

            }
            else
            {
                MessageBox.Show("未选中采购人员，无法转移销售部门！");
            }
        }
        private void btnLeftMove_Click(object sender, EventArgs e)
        {
            //获取listbox2的所有选中的项
            if (this.listBox2.SelectedItems.Count > 0)
            {
                string checkPeople = this.listBox2.SelectedItem.ToString();
                //判断是否添加到listbox1
                if (!this.listBox1.Items.Contains(checkPeople))
                {
                    //添加人员到listbox1中
                    this.listBox1.Items.Add(checkPeople);
                    //移除listbox1中
                    this.listBox2.Items.Remove(checkPeople);
                }
                else
                {
                    MessageBox.Show("该人员已经转移过，无法重复转移！");
                }

            }
            else
            {
                MessageBox.Show("未选中销售人员，无法转移到采购部门！");
            }
        }

       //手动绑定和取消事件
        private void button3_Click(object sender, EventArgs e)
        {

            if (!isBool)
            {
                button4.Click += Button4_Click;

            }
            else 
            {
                button4.Click -= Button4_Click;
            }
            isBool = !isBool;
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(listBox1.SelectedItem.ToString());

            foreach (var item in listBox1.SelectedItems)
            {
                MessageBox.Show(item.ToString());
            }
          
          //  listBox1.SelectedItem
        }

       
    }
}
