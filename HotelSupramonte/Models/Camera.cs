using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HotelSupramonte.Models
{
    public class Camera
    {
        [Key]
        public int IdCamera { get; set; }
        public string Descrizione { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCamera { get; set; }
        TipoCamera TipoCamera { get; set; }

        public static List<SelectListItem> CamereList()
        {
            List<SelectListItem> CSelectList = new List<SelectListItem>();
            SqlConnection c = Shared.GetConnectionDb();
            c.Open();
            SqlDataReader r = Shared.GetReaderAfterSQL("Select Descrizione, Tipologia, Prezzo  From Camera inner join TipoCamera on Camera.IdCamera = TipoCamera.IdTipoCamera", c);

            if (r.HasRows)
            {

                while (r.Read())
                {
                    SelectListItem s = new SelectListItem
                    {
                        Value = r["IdCamera"].ToString(),
                        Text = r["Descrizione"].ToString() + " " + r["Tipologia"].ToString() + " " + r["Prezzo"].ToString(),
                    };

                    CSelectList.Add(s);
                }
            }
            c.Close();
            return CSelectList;
            ;
        }
    }
}