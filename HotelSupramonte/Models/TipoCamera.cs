using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Models
{
    public class TipoCamera
    {
        public int IdTipoCamera { get; set; }
        public string Tipologia { get; set; }
        public decimal Prezzo { get; set; }


        public static List<SelectListItem> CamereList()
        {
            List<SelectListItem> CSelectList = new List<SelectListItem>();
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("Select * From TipoCamera", c);

            if (r.HasRows)
            {

                while (r.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Value = r["IdTipoCamera"].ToString(),
                        Text =  r["Tipologia"].ToString() + " " + r["Prezzo"].ToString(),
                    };

                    CSelectList.Add(s);
                }
            }
            c.Close();
            return CSelectList;
        }

        public static TipoCamera GetTipoCamera()
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select Tipologia, Prezzo From TipoCamera inner join Camera where TipoCamera.IdTipoCamera = Camera.IdCamera";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();

            TipoCamera t = new TipoCamera();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    t.Tipologia = r["Tipologia"].ToString();
                    t.Prezzo = Convert.ToDecimal(r["Anticipo"]);

                }
            }
            c.Close();
            return t;
        }

        public static decimal GetPrezzoCamera(int id)
        {
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("IdTipoCamera", id);
            command.CommandText = "Select Prezzo From TipoCamera where IdTipoCamera = @IdTipoCamera";
            command.Connection = c;

            SqlDataReader r = command.ExecuteReader();
            TipoCamera t = new TipoCamera();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    t.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                }
            }
            decimal prezzoCamera = t.Prezzo;

            c.Close();
            return prezzoCamera;
        }
    }
}