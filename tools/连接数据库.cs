//�½�SQLHelper�ļ�
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
                // �����ﴦ���쳣
                Console.WriteLine("����" + ex.Message);
            } finally {
                msc.Close();
            }

            return dataTable;
        }
    }
}


public class DataBase {
    //������� �ҵ�MySQL�ı����ļ������Mysql.Data.dll
}