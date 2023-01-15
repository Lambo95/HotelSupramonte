using HotelSupramonte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSupramonte.Controllers
{
    [Authorize]
    public class PrenotazioneController : Controller
    {
        // GET: Prenotazione
        public ActionResult PrenotazioniView()
        {
            return View(Prenotazioni.PrenotazioniLista());
        }

        // GET: Prenotazione/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        // GET: Prenotazione/Create
        public ActionResult CreatePrenotazione()
        {
            ViewBag.ListaClienti = Clienti.ClientiList();

            //ViewBag.ListaCamere = Camera.CamereList();

            ViewBag.ListaTipoCamere = TipoCamera.CamereList();

            ViewBag.ListaServizi = Servizio.ServizioLista();

            ViewBag.ListaTipoPrenotazioni = TipoPrenotazioni.TipoPrenotazioniList();

            return View();
        }
        [AllowAnonymous]
        // POST: Prenotazione/Create
        [HttpPost]
        public ActionResult CreatePrenotazione(FormCollection collection, Prenotazioni p)
        {
            try
            {
                // TODO: Add insert logic here
                Prenotazioni.NuovaPrenotazione(p);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prenotazione/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaTipoCamere = TipoCamera.CamereList();

            ViewBag.ListaTipoPrenotazioni = TipoPrenotazioni.TipoPrenotazioniList();
            return View();
        }

        // POST: Prenotazione/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Prenotazioni.ModificaPrenotazione(id);
                return RedirectToAction("PrenotazioniView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prenotazione/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prenotazione/Delete/5
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

        public ActionResult CheckOut(int id)
        {
            ViewBag.PrezzoPrenotazione = Prenotazioni.GetPrezzoPrenotazione(id);
            return View();
        }
    }
}
