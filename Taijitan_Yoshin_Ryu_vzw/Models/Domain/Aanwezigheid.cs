using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Aanwezigheid {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public Lid Lid { get; set; }
        public Sessie Sessie { get; set; } //Relatie
        #endregion

        #region Constructors
        protected Aanwezigheid() {

        }

        public Aanwezigheid(Lid lid, Sessie sessie) {
            Lid = lid;
            Sessie = sessie;
        }
        #endregion

        #region methodes


        #endregion
    }
}
