using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banka.Repository.Interfaces;
using Banka.Models;
using System.Data.Entity;
namespace Banka.Repository
{
    public class RacunRepo : IRacunRepo
    {
        OnlineBankingContext db = new OnlineBankingContext();
        public IEnumerable<Racun> GetAll()
        {
            var racuni = db.Racuni;
            return racuni;
        }

        public void Create(Racun r)
        {
            db.Racuni.Add(r);
            db.SaveChanges();
        }

        public void Edit(Racun racun)
        {
            db.Entry(racun).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var racun = db.Racuni.Find(id);
            db.Racuni.Remove(racun);
            db.SaveChanges();
        }

        public void ChangeStatus(Racun racun)
        {
           if (racun.Aktivan)
            {
                racun.Aktivan = false;
            }
           else
            {
                racun.Aktivan = true;
            }
            db.Entry(racun).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Racun GetById(int id)
        {
            var racun = db.Racuni.Find(id);
            return racun;
        }

      
    }
}