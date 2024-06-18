using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Agregator
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=root; database=dvad");

        public void openconnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
        }
        public void closeconnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
