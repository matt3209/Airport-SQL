using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

/*
 * The Error class is used to check the input of the user in UserInterface.
 * It checks the type of character against the requirements of the input.
 * This is an extension of the Database class.
 *
 */

namespace Lab3
{
    class Error
    {
        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
        public Boolean ErrorFour(string typed)
        {
            Boolean letter = Regex.IsMatch(typed, @"^[a-zA-Z]+$");

            if (letter == false)
            {

                return true;
            }

            if (typed.Length != 4)
            {
                return true;
            }

            return false;

        }

        public Boolean ErrorID(string typed)
        {
            if (typed.Length != 6)
            {
                return true;
            }

            string front = typed.Substring(0, 3);
            string back = typed.Substring(3, 3);
            Boolean letters = Regex.IsMatch(front, @"^[a-zA-Z]+$");
            Boolean ints = Regex.IsMatch(back, @"^[0-9]+$");

            if (letters == false || ints == false)
            {

                return true;
            }

            return false;


        }

        public Boolean ErrorInt(string typed)
        {
            Boolean ints = Regex.IsMatch(typed, @"^[0-9]+$");

            if (ints == false)
            {

                return true;
            }

            return false;

        }

        public Boolean SameId(string newId)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connectDB);
                connect.Open();
                MySqlCommand cmd = new MySqlCommand("Select @id FROM Airport WHERE id=@id", connect);

                cmd.Parameters.AddWithValue("@id", newId);

                MySqlDataReader reader = cmd.ExecuteReader();

                StringBuilder str = new StringBuilder();
                reader.Read();

                string oldId = reader.GetValue(0).ToString();

                connect.Close();

                if (newId == oldId)
                {
                    return true;
                }

                return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                return false;
            }
        }


    }
}
