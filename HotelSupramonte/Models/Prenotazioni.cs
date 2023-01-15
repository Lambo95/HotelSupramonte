using HotelSupramonte.Controllers;
using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelSupramonte.Models
{
    public class Prenotazioni
    {
        [Key]
        public int IdPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCheckOut { get; set; }
        public decimal Anticipo { get; set; }
        public string Nome { get;  set; }
        public string Cognome { get;  set; }
        public int IdTipoPrenotazione { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
        public int IdServizio { get; set; }
        public int IdTipoCamera { get; set; }


        public static List<Prenotazioni> PrenotazioniLista()
        {
           
                List<Prenotazioni> lPrenotazioni = new List<Prenotazioni>();
                SqlConnection c = Shared.GetConnectionDb();
                c.Open();
                SqlDataReader r = Shared.GetReaderAfterSQL("select IdPrenotazione, DataPrenotazione, DataCheckIn, DataCheckOut, Anticipo, Cognome, Nome from Prenotazioni inner join Clienti on Prenotazioni.IdPrenotazione = Clienti.IdCliente", c);

            try
            {
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        Prenotazioni p = new Prenotazioni();
                        p.IdPrenotazione = Convert.ToInt32(r["IdPrenotazione"].ToString());
                        p.DataPrenotazione = Convert.ToDateTime(r["DataPrenotazione"].ToString());
                        p.DataCheckIn = Convert.ToDateTime(r["DataCheckIn"].ToString());
                        p.DataCheckOut = Convert.ToDateTime(r["DataCheckOut"].ToString());
                        p.Anticipo = Convert.ToDecimal(r["Anticipo"]);
                        p.Nome = r["Nome"].ToString();
                        p.Cognome = r["Cognome"].ToString();
                        lPrenotazioni.Add(p);
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
            return lPrenotazioni;

        }

        public static void NuovaPrenotazione(Prenotazioni p)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.CommandText = "NuovaPrenotazione";
            command.CommandText = "NuovaPrenotazione2";


            command.Parameters.AddWithValue("DataPrenotazione", p.DataPrenotazione = DateTime.Now);
            command.Parameters.AddWithValue("DataCheckIn", p.DataCheckIn);
            command.Parameters.AddWithValue("DataCheckOut", p.DataCheckOut);
            command.Parameters.AddWithValue("Anticipo", p.Anticipo);
            command.Parameters.AddWithValue("IdTipoPrenotazione", p.IdTipoPrenotazione);
            command.Parameters.AddWithValue("IdCliente", p.IdCliente);
            command.Parameters.AddWithValue("IdServizio", p.IdServizio);
            command.Parameters.AddWithValue("IdTipoCamera", p.IdTipoCamera);
            //command.Parameters.AddWithValue("IdCamera", p.IdCamera);

            command.Connection = c;
            command.ExecuteNonQuery();

            c.Close();

        }

        public static Prenotazioni GetPrenotazione(int id)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("IdPrenotazione", id);
            command.CommandText = "Select * From Prenotazioni where IdPrenotazione = @IdPrenotazione";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();

            Prenotazioni p = new Prenotazioni();
            
            if (r.HasRows)
            {
                while (r.Read())
                {
                    p.DataPrenotazione = Convert.ToDateTime(r["DataPrenotazione"].ToString());
                    p.DataCheckIn = Convert.ToDateTime(r["DataCheckIn"].ToString());
                    p.DataCheckOut = Convert.ToDateTime(r["DataCheckOut"].ToString());
                    p.Anticipo = Convert.ToDecimal(r["Anticipo"]);
                    p.IdTipoPrenotazione = Convert.ToInt32(r["IdTipoPrenotazione"].ToString());
                    p.IdCliente = Convert.ToInt32(r["IdCliente"].ToString());
                    p.IdServizio = Convert.ToInt32(r["IdServizio"].ToString());
                    p.IdTipoCamera = Convert.ToInt32(r["IdTipoCamera"].ToString());

                }
            }
            c.Close();
            return p;
        }


        public static void ModificaPrenotazione(int id)
        {

            Prenotazioni p = Prenotazioni.GetPrenotazione(id);

            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ModificaPrenotazione";
            command.Connection = c;

            command.Parameters.AddWithValue("DataPrenotazione", p.DataPrenotazione = DateTime.Now);
            command.Parameters.AddWithValue("DataCheckIn", p.DataCheckIn);
            command.Parameters.AddWithValue("DataCheckOut", p.DataCheckOut);
            command.Parameters.AddWithValue("Anticipo", p.Anticipo);
            command.Parameters.AddWithValue("IdTipoPrenotazione", p.IdTipoPrenotazione);
            command.Parameters.AddWithValue("IdTipoCamera", p.IdTipoCamera);
        }

        public static decimal GetPrezzoPrenotazione(int id)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("IdPrenotazione", id);
            command.CommandText = "Select * From Prenotazioni where IdPrenotazione = @IdPrenotazione";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();
            Prenotazioni p = new Prenotazioni();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    p.DataPrenotazione = Convert.ToDateTime(r["DataPrenotazione"].ToString());
                    p.DataCheckIn = Convert.ToDateTime(r["DataCheckIn"].ToString());
                    p.DataCheckOut = Convert.ToDateTime(r["DataCheckOut"].ToString());
                    if(r["Anticipo"]!= DBNull.Value)
                    {
                    p.Anticipo = Convert.ToDecimal(r["Anticipo"]);
                    }
                    else
                    {
                    p.Anticipo = 0;
                    }
                    p.IdTipoPrenotazione = Convert.ToInt32(r["IdTipoPrenotazione"].ToString());
                    p.IdCliente = Convert.ToInt32(r["IdCliente"].ToString());
                    p.IdServizio = Convert.ToInt32(r["IdServizio"].ToString());
                    p.IdTipoCamera = Convert.ToInt32(r["IdTipoCamera"].ToString());

                }
            }

            int IdTipoPrenotazione = p.IdTipoPrenotazione;
            int IdServizio = p.IdServizio;
            int IdTipoCamera = p.IdTipoCamera;
           
            decimal Anticipo = p.Anticipo;
            decimal PrezzoCamera = TipoCamera.GetPrezzoCamera(IdTipoCamera);
            decimal PrezzoServizio = Servizio.GetPrezzoServizio(IdServizio);
            decimal PrezzoTipoPrenotazione = TipoPrenotazioni.GetPrezzoTipoPrenotazione(IdTipoPrenotazione);

            decimal PrezzoTotale = PrezzoCamera + PrezzoServizio + PrezzoTipoPrenotazione - Anticipo;

            c.Close();

            return PrezzoTotale;
        }
    }
}