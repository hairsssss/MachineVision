//新建SQLHelper文件
using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace LibraryManagementSystem {
    public class SQLHelper {
        public static string connstr = "data source=localhost;database=libraryManagementSystem;user id=admin;password=admin@123;pooling=true;charset=utf8;";
        MySqlConnection msc = new MySqlConnection(connstr);
        public DataTable ExecuteQuery(string query) {
            DataTable dataTable = new DataTable();

            try {
                msc.Open();
                MySqlCommand command = new MySqlCommand(query, msc);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
            } catch (Exception ex) {
                // 在这里处理异常
                Console.WriteLine("错误：" + ex.Message);
            } finally {
                msc.Close();
            }

            return dataTable;
        }
    }
}


public class DataBase {
    //添加引用 找到MySQL的本地文件并添加Mysql.Data.dll
}