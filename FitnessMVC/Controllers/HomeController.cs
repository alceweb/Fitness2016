using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using FitnessMVC.Models;

namespace FitnessMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult PersonalTrainer()
        {
            var uid = User.Identity.GetUserId();
            var schedeUt = db.Schedes.Where(u => u.User_Id == uid);
            ViewBag.SchedeUt = schedeUt.Count();
            return View(schedeUt);
        }

        [Authorize]
        public ActionResult Statistiche()
        {
            return View();
        }

        public ActionResult Test()
        {
            var allenamenti = db.Allenamentis.ToArray();
            return View(allenamenti);
        }
        [HttpPost]
        public ActionResult Test(string[] args)
        {
            
            Calcolatore calc = new Calcolatore();
            
            double risultato = calc.Potenza(2, 6);
            ViewBag.Risultato = risultato;
            return View();
        }

        class Calcolatore
        {
            public double Potenza(double numero, int esponente)
            {
                double risultato = numero;
                for (int i = 1; i < esponente; i++)
                {
                    risultato *= numero;
                    Console.WriteLine(risultato);
                }
                return risultato;

            }
        }
    }
}