using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Day22_1
{
    public class Student {

         public static List<Student> studentsList =new List<Student>();
         public delegate void MyDelegate(string a);
        //  public event Func<string, string> func;
         public static event MyDelegate myDelegate;

          private int _age;
          private string _sex;
          public string Name { get; set; }
          public string Sex { get { return _sex; } set {

                if (value != "男" && value != "女")
                {

                    myDelegate("性别不合法");

                }
                else { 
                
                        _sex = value;
                }
            
            } }
          public int Age {
            get { return _age; }
            set {

                if (value > 18||value<6)
                {

                    Console.WriteLine("年龄不合法");

                }
                else { 
                
                    _age =value;
                
                }
            } }

        public int ID { get; set; }
    }

}
