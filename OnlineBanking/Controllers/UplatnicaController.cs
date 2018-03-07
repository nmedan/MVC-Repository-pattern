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
    public class UplatnicaController : Controller
    {
        // GET: Uplatnica
        IUplatnicaRepo uplatnicaRepo = new UplatnicaRepo();
        IRacunRepo racunRepo = new RacunRepo();
        public ActionResult Index(int id)
        {
            double suma = 0;
            var racun = racunRepo.GetById(id);
            ViewBag.BrojRacuna = racun.BrojRacuna;
            ViewBag.NosilacRacuna = racun.NosilacRacuna;
            ViewBag.RacunId = racun.RacunId;
            ViewBag.StatusRacuna = racun.Aktivan.ToString();
            var upl = uplatnicaRepo.GetAll(id);
            foreach (var up in upl)
            {
                suma += up.IznosUplate;
            }
            ViewBag.Uplatnice = upl;
            ViewBag.Suma = suma;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Uplatnica uplatnica, int id)
        {
            double suma = 0;
            var racun = racunRepo.GetById(id);
            ViewBag.BrojRacuna = racun.BrojRacuna;
            ViewBag.NosilacRacuna = racun.NosilacRacuna;
            ViewBag.RacunId = racun.RacunId;
            ViewBag.StatusRacuna = racun.Aktivan.ToString();
            var upl = uplatnicaRepo.GetAll(id);
            foreach (var up in upl)
            {
                suma += up.IznosUplate;
            }
            ViewBag.Uplatnice = upl;
            ViewBag.Suma = suma;
            if (ModelState.IsValid)
            {
                uplatnicaRepo.Create(uplatnica, id);

                return RedirectToAction("Index", new { id = uplatnica.RacunId });
            }

            return View(uplatnica);
        }

        public ActionResult Edit(int id)
        {
           
            var uplatnica = uplatnicaRepo.GetById(id);
            var racun = racunRepo.GetById(uplatnica.RacunId);
            var racuni = racunRepo.GetAll();
            ViewBag.BrojRacuna = racun.BrojRacuna;
            ViewBag.NosilacRacuna = racun.NosilacRacuna;
            ViewBag.Racuni = new SelectList(racuni, "RacunId", "BrojRacuna");
            return View(uplatnica);
            
        }

        [HttpPost]
        public ActionResult Edit(Uplatnica uplatnica)
        {
            var racuni = racunRepo.GetAll();
            var racun = racunRepo.GetById(uplatnica.RacunId);
            ViewBag.Racuni = new SelectList(racuni, "RacunId", "BrojRacuna", uplatnica.RacunId);
            ViewBag.BrojRacuna = racun.BrojRacuna;
            ViewBag.NosilacRacuna = racun.NosilacRacuna;
            if (ModelState.IsValid)
            {
                uplatnicaRepo.Edit(uplatnica);
                return RedirectToAction("Index", new { id = uplatnica.RacunId });
            }
          
          
            return View(uplatnica);
        }

        public ActionResult Delete(int id)
        {
            var uplatnica = uplatnicaRepo.GetById(id);
            var racun = racunRepo.GetById(uplatnica.RacunId);
            uplatnicaRepo.Delete(id);
            return RedirectToAction("Index", new { id = racun.RacunId });
        }

    

    }
}