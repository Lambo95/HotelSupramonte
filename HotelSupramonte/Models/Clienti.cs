using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Models
{
    public class Clienti
    {
        [Key]
        public int IdCliente { get; set; }
        public string CodFisc { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }

        public static List<SelectListItem> ClientiList()
        {
            List<SelectListItem> CSelectList = new List<SelectListItem>();
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("Select * From Clienti", c);

            if (r.HasRows)
            {

                while (r.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Value = r["IdCliente"].ToString(),
                        Text = r["Cognome"].ToString() + " " + r["Nome"].ToString(),
                    };

                    CSelectList.Add(s);
                }
            }
            c.Close();
            return CSelectList;
            ;
        }

        public static void NuovoCliente(Clienti c)
        {
            SqlConnection con = Shared.GetConnectionDb();
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "NuovoCliente";

            command.Parameters.AddWithValue("CodFisc", c.CodFisc);
            command.Parameters.AddWithValue("Cognome", c.Cognome);
            command.Parameters.AddWithValue("Nome", c.Nome);
            command.Parameters.AddWithValue("Citta", c.Citta);
            command.Parameters.AddWithValue("Provincia", c.Provincia);
            command.Parameters.AddWithValue("Email", c.Email);
            command.Parameters.AddWithValue("Telefono", c.Telefono);
            command.Parameters.AddWithValue("Cellulare", c.Cellulare);


            command.Connection = con;
            command.ExecuteNonQuery();

            con.Close();

        }
    }
}