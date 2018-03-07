using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banka.Models
{
    public class Uplatnica
    {
        public int UplatnicaId;
        public Racun Racun;
        public double IznosUplate;
        public string DatumPrometa;
        public string Uplatilac;
        public bool Hitno;

        public Uplatnica()
        {

        }
        public Uplatnica(int UplatnicaId, Racun Racun, double IznosUplate, string DatumPrometa, string Uplatilac,
            bool Hitno)
        {
            this.UplatnicaId = UplatnicaId;
            this.Racun = Racun;
            this.IznosUplate = IznosUplate;
            this.DatumPrometa = DatumPrometa;
            this.Uplatilac = Uplatilac;
            this.Hitno = Hitno;
        }
    }
}