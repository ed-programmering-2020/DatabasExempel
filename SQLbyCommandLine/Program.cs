using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SQLbyCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
 
            MySqlConnection connection;  // objekt i library MySql.Data.MySqlClient

            //alla connection data i en enda sträng
            string connectionString =
            "SERVER=localhost;DATABASE=programmering2;UID=elev;PASSWORD=jordgubb;" ;
 
            connection = new MySqlConnection(connectionString);
            connection.Open();
 
            MySqlDataReader dataReader = null;
            string sqlsats = "Select kund_ID,FirmaNamn from kunder";
 
            //Skapa SQL-kommando
            MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
             
            //Skapa data reader och utför kommando
            dataReader = cmd.ExecuteReader();
 
            //loopar över raderna.
            // true så länge det finns minst en rad kvar att läsa.
            while (dataReader.Read())
            {
                Console.Write(dataReader.GetString("kund_ID") + ", ");
                Console.WriteLine(dataReader["FirmaNamn"].ToString() );
            }
 
            Console.ReadKey();
            connection.Close();
        }
    }
}