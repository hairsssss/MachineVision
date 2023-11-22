//新建SQLHelper文件
using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace LibraryManagementSystem {
    public class SQLHelper {
        public static string connstr = "data source=localhost;database=libraryManagementSystem;user id=admin;password=admin@123;pooling=true;charset=utf8;";
    }
}


public class DataBase {
    //添加引用 找到MySQL的本地文件并添加Mysql.Data.dll
}