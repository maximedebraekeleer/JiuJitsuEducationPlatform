using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class GebruikerLesgroep {
        #region Properties
        public string Gebruiker_Email { get; set; }
        public string Lesgroep_Groepsnaam { get; set; }
        #endregion

        #region Navigational Properties
        public Gebruiker Gebruiker { get; set; }
        public Lesgroep Lesgroep { get; set; }
        #endregion

        #region Constructors
        protected GebruikerLesgroep() {

        }

        public GebruikerLesgroep(Gebruiker gebruiker, Lesgroep lesgroep) : this() {
            Gebruiker = gebruiker;
            Gebruiker_Email = gebruiker.Email;

            Lesgroep = lesgroep;
            Lesgroep_Groepsnaam = Lesgroep.Groepsnaam;
        }
        #endregion
    }
}
