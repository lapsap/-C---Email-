using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class connectDB
    {

       private static MySql.Data.MySqlClient.MySqlConnection conn;
        private static void ConnectDatabase()
        {
            string cn = "server=localhost; user id=root; password=''; database=test";
            conn = new MySql.Data.MySqlClient.MySqlConnection(cn);
            conn.Open();
        }

        public static void post(string input)
        {
            ConnectDatabase();

               // string mySelectQuery = "INSERT INTO lapsap (name,comment) VALUES ('chris','this is a comment')";
                MySqlCommand filmsCommand = new MySqlCommand(input, conn);

                filmsCommand.ExecuteNonQuery();
                filmsCommand.Connection.Close();

                conn.Close();
        }

        public static void get()
        {
            string mySelectQuery = "SELECT * FROM Patient";
            MySqlCommand filmsCommand = new MySqlCommand(mySelectQuery, conn);

            MySqlDataReader reader = filmsCommand.ExecuteReader();

            while (reader.Read())
            {
                int Numero = reader.GetInt16("Num");
                string name = reader.GetString("Nom");
            }

            filmsCommand.Connection.Close();
        }



    }
}
