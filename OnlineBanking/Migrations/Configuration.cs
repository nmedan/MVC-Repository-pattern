namespace OnlineBanking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Banka.Models.OnlineBankingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Banka.Models.OnlineBankingContext context)
        {
            context.Racuni.Add(new Banka.Models.Racun() { RacunId = 1, BrojRacuna = "21222-23222-23212", NosilacRacuna = "Nemanja Medan", Aktivan = true, Online = false });
            context.Racuni.Add(new Banka.Models.Racun() { RacunId = 2, BrojRacuna = "21245-23122-22112", NosilacRacuna = "Marko Markovic", Aktivan = true, Online = false });
            context.Racuni.Add(new Banka.Models.Racun() { RacunId = 3, BrojRacuna = "21232-23212-43212", NosilacRacuna = "Petar Petrovic", Aktivan = true, Online = true });
            context.Uplatnice.Add(new Banka.Models.Uplatnica() { UplatnicaId = 1, DatumPrometa = "23-12-2010", IznosUplate = 200, Hitno = false, SvrhaUplate = "Prijava ispita", RacunId = 1, Uplatilac = "Marko Jovanovic" });
            context.Uplatnice.Add(new Banka.Models.Uplatnica() { UplatnicaId = 2, DatumPrometa = "23-12-2011", IznosUplate = -100, Hitno = false, SvrhaUplate = "Prijava ispita", RacunId = 2, Uplatilac = "Sasa Ilic" });
            context.Uplatnice.Add(new Banka.Models.Uplatnica() { UplatnicaId = 3, DatumPrometa = "23-12-2012", IznosUplate = 50, Hitno = true, SvrhaUplate = "Upis godine", RacunId = 3, Uplatilac = "Milan Milovanovic" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
