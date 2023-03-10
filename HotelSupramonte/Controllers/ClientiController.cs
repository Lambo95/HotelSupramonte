using HotelSupramonte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clienti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clienti/Create
        public ActionResult CreateClienti()
        {
            return View();
        }

        // POST: Clienti/Create
        [HttpPost]
        public ActionResult CreateClienti(FormCollection collection, Clienti c)
        {
            try
            {
                // TODO: Add insert logic here
                Clienti.NuovoCliente(c);
                return RedirectToAction("CreatePrenotazione", "Prenotazione");
            }
            catch
            {
                return View("");
            }
        }

        // GET: Clienti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clienti/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clienti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clienti/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
