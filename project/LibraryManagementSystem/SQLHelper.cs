using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
