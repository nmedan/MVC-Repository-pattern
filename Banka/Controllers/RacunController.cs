using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banka.Repository.Interfaces;
using Banka.Repository;
namespace Banka.Controllers
{
    public class RacunController : Controller
    {
        // GET: Racun
        public IRacunRepo racunRepo = new RacunRepo();
        public ActionResult Index()
        {
            var racuni = racunRepo.GetAll();
            return View(racuni);
        }

        [HttpPost]
        public ActionResult Index()
        {
            var racuni = racunRepo.GetAll();
            return View(racuni);
        }
    }
}