using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Banka.Models
{
    public class Racun
    {
        public int RacunId { get; set; }

        [Required(ErrorMessage ="Obavezno polje")]
        public string NosilacRacuna { get; set; }

        [Required(ErrorMessage ="Obavezno polje")]
        [RegularExpression(@"\d{5}-\d{5}-\d{5}", ErrorMessage = "Broj mora biti u formatu xxxxx-xxxxx-xxxxx")]
        public string BrojRacuna { get; set; }
        
        public bool Aktivan { get; set; }
        public bool Online { get; set; }
        
     
    }

    
}