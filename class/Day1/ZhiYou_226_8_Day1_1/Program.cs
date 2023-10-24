using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

//项目的文件列表
//1.程序集信息文件（了解）
//如何查看程序集信息 
//（1）AssemblyInfo 查看
//（2）程序集信息查看
//（3）程序编译通过的程序集文件查看
//2.引用
//当前项目中可以使用 的系统默认模块，
//自己写的模块或者第三方提供的模块
//3.App.config配置文件（了解）
//项目的框架 等配置信息 ,项目需要使用的特点数据信息
//获取配置文件信息
//（1）在引用中导入Configuration
//（2）引入Configuration模块
//(3)使用ConfigurationManager管理程序配置的功能类 


namespace ZhiYou_226_8_Day1_1
{

   
    internal class Program
    {
        static void Main(string[] args)
        {

            //ConfigurationManager 用于管理程序配置的功能类
            string NameStr =   ConfigurationManager.AppSettings["Name"].ToString();
            Console.WriteLine(NameStr);
            string NameStr1 = ConfigurationManager.AppSettings["MyConfigString"].ToString();
            Console.WriteLine(NameStr1);
            //调用静态字段
            Console.WriteLine(AppSettingConfig.resultValue1); 
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 静态类AppSettingConfig
    /// </summary>
    internal static class AppSettingConfig
    {
        //静态字段
        public static string resultValue1 = ConfigurationManager.AppSettings["Name123"].ToString();

    }
}
