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
    public class AllenamentisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Allenamentis
        public ActionResult Index()
        {
            return View(db.Allenamentis.ToList());
        }

        // GET: Allenamentis/Details/5
        public ActionResult Details(int? id)
        {
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (allenamenti == null)
            {
                return HttpNotFound();
            }
            return View(allenamenti);
        }

        // GET: Allenamentis/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Uid = Request.QueryString["user"];
            ViewBag.Sid = id;
            ViewBag.Esercizio_Id = new SelectList(db.Esercizis, "Esercizio_Id", "Descrizione");
            return View();
        }

        // POST: Allenamentis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Scheda_Id,GruppoMuscolare,Esercizio_Id,Serie,Ripetizioni,Peso,Riposo,Descrizione,Numero")] Allenamenti allenamenti, int id)
        {
            var numerogiorni = allenamenti.Numero;
            if (ModelState.IsValid)
            {
                for (var i = 1; i< numerogiorni + 1; i++)
                {
                allenamenti.Numero = @i;
                allenamenti.Scheda_Id = id;
                db.Allenamentis.Add(allenamenti);
                db.SaveChanges();

                }
                return RedirectToAction("Details", "Schedes", new { id = id });
            }

            return View(allenamenti);
        }

        public ActionResult ListEseEdit(int? id)
        {
            ViewBag.Ese = id;
            ViewBag.Uid = Request.QueryString["user"];
            int scheda = Convert.ToInt32(Request.QueryString["idScheda"]);
            string[] nomeScheda = db.Schedes.Where(s => s.Id == scheda).Select(s => s.Descrizione).ToArray();
            ViewBag.NomeScheda = nomeScheda[0];
            var allenamenti = db.Allenamentis.Where(a => a.Scheda_Id == scheda && a.Esercizio_Id == id).OrderBy(a=>a.Numero);
            return View(allenamenti);
        }

        // GET: Allenamentis/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Uid = Request.QueryString["user"];
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (allenamenti == null)
            {
                return HttpNotFound();
            }
            return View(allenamenti);
        }

        // POST: Allenamentis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditAllenamentoViewModel allenamenti, int? id)
        {
            int scheda = Convert.ToInt32(Request.QueryString["SchedaId"]);
            int numero = Convert.ToInt32(Request.QueryString["numero"]);
            int esercizio = Convert.ToInt32(Request.QueryString["ese"]);
            var allenamento = db.Allenamentis.Where(s => s.Scheda_Id == scheda && s.Numero >= numero && s.Esercizio_Id == esercizio);
            if (ModelState.IsValid)
            {
                allenamento.ToList().ForEach(c => c.Serie = allenamenti.Serie);
                allenamento.ToList().ForEach(c => c.Ripetizioni = allenamenti.Ripetizioni);
                allenamento.ToList().ForEach(c => c.Descrizione = allenamenti.Descrizione);
                db.SaveChanges();
                return RedirectToAction("ListEseEdit", "Allenamentis", new { id = esercizio ,idScheda = scheda,user = Request.QueryString["user"]});
            }
            return View(allenamenti);
        }

        public ActionResult Edit1(int? id)
        {
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (allenamenti == null)
            {
                return HttpNotFound();
            }
            return View(allenamenti);
        }


        public ActionResult EditUt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            if (allenamenti == null)
            {
                return HttpNotFound();
            }
            return View(allenamenti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUt([Bind(Include = "Id,Scheda_Id,GruppoMuscolare,Esercizio_Id,Serie,SerieUt,Ripetizioni,RipetizioniUt,Peso,PesoUt,Riposo,RiposoUt,Descrizione,Numero,Data")] Allenamenti allenamenti, int? id)
        {
            if (ModelState.IsValid)
            {
                int ese = Convert.ToInt16(Request.QueryString["ese"]);
                allenamenti.Numero = ese;
                //Imposto la data dell'allenamento se non è già stata impostata
                if (allenamenti.Data.Year < 1900)
                {
                    allenamenti.Data = DateTime.Now;
                }
                db.Entry(allenamenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DetailsUt", "Schedes", new { id = Request.QueryString["scheda"], ese = ese });
            }
            return View(allenamenti);
        }

        // GET: Allenamentis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            if (allenamenti == null)
            {
                return HttpNotFound();
            }
            return View(allenamenti);
        }

        // POST: Allenamentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allenamenti allenamenti = db.Allenamentis.Find(id);
            db.Allenamentis.Remove(allenamenti);
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
