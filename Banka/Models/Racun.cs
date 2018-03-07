using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banka.Models
{
    public class Racun
    {
        public int RacunId;
        public string NosilacRacuna;
        public string BrojRacuna;
        public bool Online;
        public bool Aktivan;

        public Racun()
        {

        }
        public Racun(int RacunId, string NosilacRacuna, string BrojRacuna, bool Online, bool Aktivan)
        {
            this.RacunId = RacunId;
            this.NosilacRacuna = NosilacRacuna;
            this.BrojRacuna = BrojRacuna;
            this.Online = Online;
            this.Aktivan = Aktivan;
        }
    }

    
}