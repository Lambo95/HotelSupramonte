using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelSupramonte.Models
{
    public class Gest
    {
        [Key]
        public int IdGest { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ruolo { get; set; }

        public static bool IsAuth(string username, string password)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Gest WHERE Username=@Username And Password=@Password";
            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Password", password);
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();

            if (r.HasRows)
            {
                c.Close();
                return true;
            }
            else
            {
                c.Close();
                return false;
            }
            

        }
    }
}