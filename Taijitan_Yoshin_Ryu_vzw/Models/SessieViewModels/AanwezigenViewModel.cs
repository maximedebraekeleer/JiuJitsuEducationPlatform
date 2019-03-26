using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class AanwezigenViewModel
    {
        public List<Aanwezigheid> Aanwezigheden { get; set; }

        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }

        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Display(Name = "Formule")]
        public string Formule { get; set; }

        [Display(Name = "datumFilter")]
        public bool datumFilter { get; set; }
        
        public AanwezigenViewModel(List<Aanwezigheid> aanwezigheden)
        {
            Aanwezigheden = aanwezigheden;
            Datum = DateTime.Today;
            Naam = "";
            datumFilter = true;
        }
    }
}
