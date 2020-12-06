using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Hospital_Management__System.Connection
{
    class SqlServerConnection
    {
        public static string stringConnection =("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=LoginDatabase;Integrated Security=True");

        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();
            
            
            try
            {
                connection.ConnectionString = stringConnection;
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);

                connection.Close();
                connection = null;
               
                return dt;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occured" + ex.Message, "SQL Server Connection Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dt = null;
            }

            return dt;

        }
    }
}
