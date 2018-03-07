using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banka.Repository.Interfaces;
using Banka.Repository;
using Banka.Models;
namespace Banka.Controllers
{
    public class RacunController : Controller
    {
        // GET: Racun
        public IRacunRepo racunRepo = new RacunRepo();
        public IUplatnicaRepo uplatnicaRepo = new UplatnicaRepo();
        public ActionResult Index()
        {
            var racuni = racunRepo.GetAll();
            ViewBag.Racuni = racuni;
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "RacunId, NosilacRacuna, BrojRacuna, Aktivan, Online")]Racun racun)
        {
          
            var racuni = racunRepo.GetAll();
            ViewBag.Racuni = racuni;

            if (ModelState.IsValid)
            {
                racunRepo.Create(racun);
                return RedirectToAction("Index");
            }


            return View(racun);
            
        }

        public ActionResult Edit(int id)
        {
            var racun = racunRepo.GetById(id);
            ViewBag.NosilacRacuna = racun.NosilacRacuna;
            ViewBag.BrojRacuna = racun.BrojRacuna;
            return View(racun);
        }

        [HttpPost]
        public ActionResult Edit(Racun racun)
        {
            if (ModelState.IsValid)
            {
                racunRepo.Edit(racun);
                return RedirectToAction("Index");
            }
            return View(racun);
        }

        public ActionResult Delete(int id)
        {
            racunRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var racun = racunRepo.GetById(id);
            racunRepo.ChangeStatus(racun);
            return RedirectToAction("Index");
        }

    }
}