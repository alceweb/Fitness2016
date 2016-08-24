using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessMVC.Models;

namespace FitnessMVC.Controllers
{
    public class EsercizisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Esercizis
        public ActionResult Index()
        {
            return View(db.Esercizis.ToList());
        }

        // GET: Esercizis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esercizi esercizi = db.Esercizis.Find(id);
            if (esercizi == null)
            {
                return HttpNotFound();
            }
            return View(esercizi);
        }

        // GET: Esercizis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Esercizis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Esercizio_Id,Descrizione")] Esercizi esercizi)
        {
            if (ModelState.IsValid)
            {
                db.Esercizis.Add(esercizi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(esercizi);
        }

        // GET: Esercizis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esercizi esercizi = db.Esercizis.Find(id);
            if (esercizi == null)
            {
                return HttpNotFound();
            }
            return View(esercizi);
        }

        // POST: Esercizis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Esercizio_Id,Descrizione")] Esercizi esercizi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(esercizi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(esercizi);
        }

        // GET: Esercizis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esercizi esercizi = db.Esercizis.Find(id);
            if (esercizi == null)
            {
                return HttpNotFound();
            }
            return View(esercizi);
        }

        // POST: Esercizis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Esercizi esercizi = db.Esercizis.Find(id);
            db.Esercizis.Remove(esercizi);
            db.SaveChanges();
            return RedirectToAction("Index");
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
