using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.Models;
using CarSales.Filters;
using System.IO;

namespace CarSales.Controllers
{
    [Localization]
    public class AutomobiliController : Controller
    {
        private AutomobilContext db = new AutomobilContext();

        public FileContentResult CitajSliku(int id)
        {
            Automobil automobil = db.Automobili.Find(id);

            if (automobil == null)
            {
                return null;
            }

            return File(automobil.FajlSlike, automobil.TipFajla);
        }

        // GET: Automobili
        public ActionResult Index()
        {
            return View(db.Automobili.ToList());
        }

        // GET: Automobili/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.Automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // GET: Automobili/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automobili/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutomobilId,Korisnik,Marka,Model,Godiste,ZapreminaMotora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt,FajlSlike,TipFajla")] Automobil automobil, HttpPostedFileBase poslatiFajl)
        {
            if (ModelState.IsValid)
            {
                if (poslatiFajl != null)
                {
                    automobil.TipFajla = poslatiFajl.ContentType;
                    automobil.FajlSlike = new byte[poslatiFajl.ContentLength];
                    Stream fs = poslatiFajl.InputStream;
                    fs.Read(automobil.FajlSlike, 0, poslatiFajl.ContentLength);
                }
  
                db.Automobili.Add(automobil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(automobil);
        }

        // GET: Automobili/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.Automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobili/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutomobilId,Korisnik,Marka,Model,Godiste,ZapreminaMotora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt,FajlSlike,TipFajla")] Automobil automobil, HttpPostedFileBase poslatiFajl, int promena)
        {
            if (ModelState.IsValid)
            {
                Automobil autAtachovano = db.Automobili.Find(automobil.AutomobilId);
                if (promena == 1 && poslatiFajl != null)
                {
                    autAtachovano.TipFajla = poslatiFajl.ContentType;
                    autAtachovano.FajlSlike = new byte[poslatiFajl.ContentLength];
                    Stream fs = poslatiFajl.InputStream;
                    fs.Read(autAtachovano.FajlSlike, 0, poslatiFajl.ContentLength);
                }

                autAtachovano.Marka = automobil.Marka;
                autAtachovano.Model = automobil.Model;
                autAtachovano.Godiste = automobil.Godiste;
                autAtachovano.ZapreminaMotora = automobil.ZapreminaMotora;
                autAtachovano.Snaga = automobil.Snaga;
                autAtachovano.Gorivo = automobil.Gorivo;
                autAtachovano.Karoserija = automobil.Karoserija;
                autAtachovano.Opis = automobil.Opis;
                autAtachovano.Cena = automobil.Cena;
                autAtachovano.Kontakt = automobil.Kontakt;

                //db.Entry(automobil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automobil);
        }

        // GET: Automobili/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.Automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobili/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automobil automobil = db.Automobili.Find(id);
            db.Automobili.Remove(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SetCulture(string culture, string sourceUrl)
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return Redirect(sourceUrl);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
