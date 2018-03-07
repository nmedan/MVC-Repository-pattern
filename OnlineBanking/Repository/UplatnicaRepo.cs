using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banka.Repository.Interfaces;
using Banka.Models;
using System.Data.Entity;
namespace Banka.Repository
{
    public class UplatnicaRepo : IUplatnicaRepo
    {

        OnlineBankingContext db = new OnlineBankingContext();
        public IEnumerable<Uplatnica> GetAll(int id)
        {

            var uplatnice = db.Uplatnice.Where(x => x.Racun.RacunId == id);
            return uplatnice;         
        }

        public void Create(Uplatnica uplatnica, int id)
        {
            uplatnica.RacunId = id;
            db.Uplatnice.Add(uplatnica);
            db.SaveChanges();
        }
        public void Edit(Uplatnica uplatnica)
        {
           
            db.Entry(uplatnica).State = EntityState.Modified;
            db.SaveChanges();
            db.Entry(uplatnica).Reference(x => x.Racun).Load();
        }
        public void Delete(int id)
        {
            var uplatnica = db.Uplatnice.Find(id);
            db.Uplatnice.Remove(uplatnica);
            db.SaveChanges();
        }

        
        public Uplatnica GetById(int id)
        {
            var uplatnica = db.Uplatnice.Find(id);
            return uplatnica;

        }
    }
    }
