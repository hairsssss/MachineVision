using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Day22_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Student.myDelegate += this.StudentErrorInfo;

        }
        //保存数据的方法
        private void button2_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Name = textBox1.Text;
            int tempNumber;
            int.TryParse(textBox2.Text, out tempNumber);
            student.Age = tempNumber;
            Console.WriteLine(student.Age);
            student.Sex = textBox3.Text;
            int.TryParse(textBox4.Text, out tempNumber);
            student.ID = tempNumber;
            if (student.Age != 0 && student.Sex != null)
            {
                Student.studentsList.Add(student);
            }





            Console.WriteLine(Student.studentsList.Count);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (Student.studentsList.Count == 0) 
            //{

            //    Console.WriteLine("没有信息 无法继续删除");
            //}
            //else
            //{

            //    Student.studentsList.RemoveAt(Student.studentsList.Count-1);

            //}

            DialogResult dialogResult = MessageBox.Show("确定要删除学生信息？", "标题", MessageBoxButtons.OKCancel);
            //点击了确定按钮
            if (dialogResult == DialogResult.OK)
            {
                //全局查找 返回 为符合要求数据的 集合
                var selectList = from studnt1 in Student.studentsList where studnt1.Name == "zhangsan" select studnt1;

                foreach (Student item in selectList)
                {
                    Student.studentsList.Remove(item);
                }
            }
        }


        private void StudentErrorInfo(string tempStr) {

            label5.Text = tempStr;


        }


        private void ArrayFind(){
            //查找的是符合student.Age > 15 条件   并且只找到第一个匹配项
             Student findSt =   Student.studentsList.Find((student) => { return student.Age > 15; });
            //全局查找 返回 为符合要求数据的 集合
            List<Student> findList =    Student.studentsList.FindAll((student) => { return student.Age > 15; });
            //查找的是符合student.Age > 15 条件   并且只找到第一个匹配项的索引值
            int findIndex =     Student.studentsList.FindIndex((student) => { return student.Age > 15; });
            //全局查找 返回 为符合要求数据的 集合
            var selectList = from studnt1 in Student.studentsList where studnt1.Name == "zhangsan" select studnt1;

        }
    }
}
