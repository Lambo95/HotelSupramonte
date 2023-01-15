using HotelSupramonte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Controllers
{
    public class SevizioController : Controller
    {
        // GET: Sevizio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sevizio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sevizio/Create
        public ActionResult CreateSevizio()
        {
            ViewBag.ListaClienti = Clienti.ClientiList();
            return View();
        }

        // POST: Sevizio/Create
        [HttpPost]
        public ActionResult CreateServizio(FormCollection collection, Servizio s)
        {
            try
            {
                // TODO: Add insert logic here
                Servizio.NuovoServizio(s);
                return RedirectToAction("PrenotazioniView", "Prenotazioni");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sevizio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sevizio/Edit/5
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

        // GET: Sevizio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sevizio/Delete/5
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
