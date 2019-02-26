using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class SessieLesgroep {
        #region Properties
        public DateTime Sessie_Tijdstip { get; set; }
        public string Lesgroep_Groepsnaam { get; set; }
        #endregion

        #region Navigational Properties
        public Sessie Sessie { get; set; }
        public Lesgroep Lesgroep { get; set; }
        #endregion

        #region Constructors
        protected SessieLesgroep() {

        }

        public SessieLesgroep(Sessie sessie, Lesgroep lesgroep) : this() {
            Sessie = sessie;
            Sessie_Tijdstip = Sessie.Tijdstip;

            Lesgroep = lesgroep;
            Lesgroep_Groepsnaam = Lesgroep.Groepsnaam;
        }
        #endregion
    }
}
