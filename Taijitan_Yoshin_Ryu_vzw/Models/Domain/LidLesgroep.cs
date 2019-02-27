using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class LidLesgroep {
        #region Properties
        public string Lid_Id { get; set; }
        public string Lesgroep_Groepsnaam { get; set; }
        #endregion

        #region Navigational Properties
        public Lid Lid { get; set; }
        public Lesgroep Lesgroep { get; set; }
        #endregion

        #region Constructors
        protected LidLesgroep() {

        }

        public LidLesgroep(Lid lid, Lesgroep lesgroep) : this() {
            Lid = lid;
            Lid_Id = Lid.Id;

            Lesgroep = lesgroep;
            Lesgroep_Groepsnaam = Lesgroep.Groepsnaam;
        }
        #endregion
    }
}
