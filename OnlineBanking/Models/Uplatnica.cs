using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Banka.Models
{
    public class Uplatnica
    {
        public int UplatnicaId { get; set; }
        public int RacunId { get; set; }
        public Racun Racun { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public double IznosUplate { get; set; }

        [Required(ErrorMessage ="Obavezno polje")]
        [RegularExpression(@"\d{2}-\d{2}-\d{4}", ErrorMessage = "Datum mora biti u formatu dd-mm-yyyy")]
        public string DatumPrometa { get; set; }

        [Required(ErrorMessage ="Obavezno polje")]
        public string SvrhaUplate { get; set; }

        [Required(ErrorMessage ="Obavezno polje")]
        public string Uplatilac { get; set; }
        public bool Hitno { get; set; }

       
    }
}