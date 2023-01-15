using HotelSupramonte.Models;
using HotelSupramonte.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelSupramonte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginView(Gest g)
        {
           bool IsAuth = Gest.IsAuth(g.Username, g.Password);
            if (IsAuth == true)
            {
                FormsAuthentication.SetAuthCookie(g.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                return View();
            }
        }
    }
}