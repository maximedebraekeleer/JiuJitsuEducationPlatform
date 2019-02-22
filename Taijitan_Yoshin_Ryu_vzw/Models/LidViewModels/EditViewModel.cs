using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.LidViewModels {
    public class EditViewModel {

        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public int HuisNummer { get; set; }
        public int PostCode { get; set; }
        public int TelefoonNummer { get; set; }
        public string Email { get; set; }

        public EditViewModel() {

        }

        public EditViewModel(Lid lid) {
            Naam = lid.Naam;
            Voornaam = lid.Voornaam;
            GeboorteDatum = lid.GeboorteDatum;
            Straat = lid.Straat;
            Gemeente = lid.Gemeente;
            HuisNummer = lid.HuisNummer;
            PostCode = lid.Postcode;
            TelefoonNummer = lid.TelefoonNummer;
            Email = lid.Email;

        }
    }
}
