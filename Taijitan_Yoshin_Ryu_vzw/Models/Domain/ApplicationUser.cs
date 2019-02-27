using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class ApplicationUser : IdentityUser {
        #region Properties
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
        public ICollection<ApplicationUserLesgroep> ApplicationUserLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => ApplicationUserLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        public ApplicationUser() {
            ApplicationUserLesgroepen = new HashSet<ApplicationUserLesgroep>();
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            ApplicationUserLesgroepen.Add(new ApplicationUserLesgroep(this, l));
        }
        #endregion
    }
}