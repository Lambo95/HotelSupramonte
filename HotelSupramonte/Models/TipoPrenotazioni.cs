using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Models
{
    public class TipoPrenotazioni
    {
        public int IdTipoPrenotazioni { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }

        public static List<SelectListItem> TipoPrenotazioniList()
        {
            List<SelectListItem> CSelectList = new List<SelectListItem>();
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("Select * from TipoPrenotazioni", c);

            if (r.HasRows)
            {

                while (r.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Value = r["IdTipoPrenotazione"].ToString(),
                        Text = r["Descrizione"].ToString() + " " + r["Prezzo"].ToString(),
                    };

                    CSelectList.Add(s);
                }
            }
            c.Close();
            return CSelectList;
            ;
        }

        public static decimal GetPrezzoTipoPrenotazione(int id)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("IdTipoPrenotazione", id);
            command.CommandText = "Select Prezzo From TipoPrenotazioni where IdTipoPrenotazione = @IdTipoPrenotazione";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();
            TipoPrenotazioni t = new TipoPrenotazioni();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    t.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                }
            }

            decimal prezzoTipoPrenotazioni = t.Prezzo;

            c.Close();
            return prezzoTipoPrenotazioni;
        }
    }
    
}