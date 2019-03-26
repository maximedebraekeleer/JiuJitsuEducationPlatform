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
        public bool IsExtra { get; set; }
        #endregion

        #region Constructors
        protected Aanwezigheid() {

        }

        public Aanwezigheid(Lid lid, Sessie sessie, bool isExtra = false) {
            Lid = lid;
            Sessie = sessie;
            IsExtra = isExtra;
        }
        #endregion

        #region methodes
        #endregion
    }
}
