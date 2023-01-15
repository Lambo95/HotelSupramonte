using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelSupramonte.Models
{
    public class CheckOut
    {
        Prenotazioni prenotazioni { get; set; }
        public decimal PrezzoTotale { get; set; }
        public static CheckOut GoCheckOut () {

            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("select IdPrenotazione, Anticipo, IdTipoPrenotazione, IdCamera, Cognome, Nome from Prenotazioni inner join Clienti on Prenotazioni.IdPrenotazione = Clienti.IdCliente", c);
            
            CheckOut ch = new CheckOut();
            try
            {
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        ch.prenotazioni.IdPrenotazione = Convert.ToInt32(r["IdPrenotazione"].ToString());
                        ch.prenotazioni.Anticipo = Convert.ToDecimal(r["Anticipo"]);
                        ch.prenotazioni.IdTipoPrenotazione = Convert.ToInt32(r["IdPrenotazione"].ToString());
                        ch.prenotazioni.IdCamera = Convert.ToInt32(r["IdPrenotazione"].ToString());
                        ch.prenotazioni.Nome = r["Nome"].ToString();
                        ch.prenotazioni.Cognome = r["Cognome"].ToString();
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
            return ch;

        }


    }
}