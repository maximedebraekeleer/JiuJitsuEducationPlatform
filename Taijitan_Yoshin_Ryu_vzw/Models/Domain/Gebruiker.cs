using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Gebruiker {
        #region Properties
        public string Email { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Straat { get; set; }
        public int HuisNummer { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public int TelefoonNummer { get; set; }
        #endregion

        #region Collections
        public ICollection<GebruikerLesgroep> GebruikerLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => GebruikerLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        public Gebruiker() {
            GebruikerLesgroepen = new HashSet<GebruikerLesgroep>();
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            GebruikerLesgroepen.Add(new GebruikerLesgroep(this, l));
        }
        #endregion
    }
}