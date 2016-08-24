using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessMVC.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace FitnessMVC.Controllers
{
    public class SchedesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Schedes
        public ActionResult Index(string id)
        {
            ViewBag.Nomeu = db.Users.Where(u => u.Id == id);
            ViewBag.Uid = id;
            var schedeut = db.Schedes.Where(u => u.User_Id == id);
            ViewBag.SchedeCount = Convert.ToInt16(schedeut.Count());
            return View(schedeut);
        }

        public async Task<ActionResult> Index1()
        {
            var user = await UserManager.FindByIdAsync("560c1ae0-25ed-4ffe-a7b3-2438d1300977");
            var utente = db.Users;
            ViewBag.Utente = utente;
            return View(db.Schedes.ToList());
        }

        // GET: Schedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schede schede = db.Schedes.Find(id);
            if (schede == null)
            {
                return HttpNotFound();
            }
            var allenamenti = db.Allenamentis.Include(e => e.Esercizio_Id).Where(s => s.Scheda_Id == id)
                .GroupBy(row => new { row.Esercizio})
                .Select( group => new AllList1ViewModel { Esercizio_Id = group.Key.Esercizio.Esercizio_Id, MaxNumero = group.Max(s=>s.Numero), TotMovimenti = (group.Sum(s=>s.Serie)+group.Sum(s=>s.Ripetizioni))}).ToList();
            var allenamentiC = db.Allenamentis.Where(s=>s.Scheda_Id == id).OrderBy(n=>n.Numero);
            ViewBag.AllenamentiCount = allenamentiC.Count();
            ViewBag.Allenamenti = allenamenti;

            return View(schede);
        }


        public ActionResult ListUt(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schede schede = db.Schedes.Find(id);
            if (schede == null)
            {
                return HttpNotFound();
            }
            var allenamenti = db.Allenamentis.Include(e => e.Esercizio).Where(s => s.Scheda_Id == id)
                .GroupBy(row => new { row.Numero})
                .Select(group => new AllPercViewModel { Numero = group.Key.Numero, SommaSerieUt = group.Sum(s => s.SerieUt), SommaSerie = group.Sum(s=>s.Serie) }).ToList();
            ViewBag.Allenamenti = allenamenti;
            return View(schede);
        }

        public ActionResult DetailsUt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schede schede = db.Schedes.Find(id);
            if (schede == null)
            {
                return HttpNotFound();
            }
            int ese = Convert.ToInt16(Request.QueryString["ese"]);
            var allenamenti = db.Allenamentis.Where(s => s.Scheda_Id == id && s.Numero == ese).Include(s=>s.Esercizio);
            ViewBag.Allenamenti = allenamenti;
            ViewBag.NumeroAllenamento = ese;
            var allenamentig = db.Allenamentis.Where(s => s.Scheda_Id == id && s.Numero == ese)
                .GroupBy(row => new { row.Numero })
                .Select(group => new AllPercViewModel { Numero = group.Key.Numero, SommaSerieUt = group.Sum(s => s.SerieUt), SommaSerie = group.Sum(s => s.Serie) }).ToList();
            ViewBag.Allenamentig = allenamentig;

            return View(schede);
        }
        // GET: Schedes/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = Request.QueryString["user"];
            return View();
        }

        // POST: Schedes/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,User_Id,Descrizione")] Schede schede)
        {
            if (ModelState.IsValid)
            {
                schede.User_Id = Request.QueryString["user"];
                db.Schedes.Add(schede);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = Request.QueryString["user"] });
            }

            return View(schede);
        }

        // GET: Schedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schede schede = db.Schedes.Find(id);
            if (schede == null)
            {
                return HttpNotFound();
            }
            return View(schede);
        }

        // POST: Schedes/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,User_Id,Descrizione")] Schede schede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schede).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = schede.Id });
            }
            return View(schede);
        }

        // GET: Schedes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schede schede = db.Schedes.Find(id);
            if (schede == null)
            {
                return HttpNotFound();
            }
            return View(schede);
        }

        // POST: Schedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schede schede = db.Schedes.Find(id);
            db.Schedes.Remove(schede);
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
