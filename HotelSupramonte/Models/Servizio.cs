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
    public class Servizio
    {
        [Key]
        public int IdServizio { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int IdCliente { get; set; }

        public static void NuovoServizio(Servizio s)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "AggiungiServizio";

            command.Parameters.AddWithValue("Descrizione", s.Descrizione);
            command.Parameters.AddWithValue("Prezzo", s.Prezzo);
            command.Parameters.AddWithValue("IdCliente", s.IdCliente);
            command.Connection = c;
            command.ExecuteNonQuery();

            c.Close();

        }

        public static decimal GetPrezzoServizio(int id)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("IdServizio", id);
            command.CommandText = "Select Prezzo From Servizio where IdServizio = @IdServizio";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();
            Servizio t = new Servizio();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    t.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                }
            }

            decimal prezzoServizio = t.Prezzo;

            c.Close();
            return prezzoServizio;
        }

        public static List<SelectListItem> ServizioLista()
        {

            List<SelectListItem> lServizio = new List<SelectListItem>();
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("select * from Servizio", c);

            try
            {
                if (r.HasRows)
                {
                    while (r.Read())
                    {

                        SelectListItem s = new SelectListItem
                        {
                            Value = r["IdServizio"].ToString(),
                            Text = r["Descrizione"].ToString() + " " + r["Prezzo"].ToString(),
                        };
                        lServizio.Add(s);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                c.Close();
            }
            return lServizio;

        }


    }
}