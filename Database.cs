using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

/*
 *Adds to the databse, deletes from the database, updates to the database, display database. The database uses SQL.
 */

namespace Lab3
{
    public class Database : IDatabase
    {
        List<Flight> Flights = new List<Flight>();
        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;



        public void Add(string origin, string destination, string identifier, string passengers)
        {

            MySqlConnection connect = new MySqlConnection(connectDB);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Airport VALUES(@id, @origin, @destination, @passengers)", connect);

            cmd.Parameters.Add(new MySqlParameter("id", identifier));
            cmd.Parameters.Add(new MySqlParameter("origin", origin));
            cmd.Parameters.Add(new MySqlParameter("destination", destination));
            cmd.Parameters.Add(new MySqlParameter("passengers", passengers));

            cmd.ExecuteNonQuery();

            connect.Close();
        }

        public void Update(string origin, string destination, string identifier, string passengers)
        {

            MySqlConnection connect = new MySqlConnection(connectDB);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE Airport SET origin=@origin, destination=@destination, passengers=@passengers WHERE id=@id", connect);

            cmd.Parameters.AddWithValue("@id", identifier);
            cmd.Parameters.AddWithValue("@origin", origin);
            cmd.Parameters.AddWithValue("@destination", destination);
            cmd.Parameters.AddWithValue("@passengers", passengers);

            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void Destroy(string identifier)
        {

            MySqlConnection connect = new MySqlConnection(connectDB);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Airport WHERE id=@id", connect);

            cmd.Parameters.AddWithValue("@id", identifier);

            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public string Display()
        {

            MySqlConnection connect = new MySqlConnection(connectDB);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * from Airport", connect);

            MySqlDataReader reader = cmd.ExecuteReader();
            int count = reader.FieldCount;
            StringBuilder str = new StringBuilder();
            while(reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    str.Append(reader.GetValue(i) + " ");
                }
                str.Append("\n");
            }
            return str.ToString();
          
        }
    }
}