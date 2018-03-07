using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Banka.Models
{
    public class OnlineBankingContext : DbContext
    {
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Uplatnica> Uplatnice { get; set; }

        public OnlineBankingContext()
        {

        }
    }
}