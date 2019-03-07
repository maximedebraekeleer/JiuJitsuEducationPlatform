using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Sessie
    {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public DateTime BeginDatumEnTijd { get; set; }
        public DateTime EindDatumEnTijd { get; set; }
        #endregion

        #region Constructors
        public Sessie(DateTime beginDatumEnTijd, DateTime eindDatumEnTijd) {
            BeginDatumEnTijd = beginDatumEnTijd;
            EindDatumEnTijd = eindDatumEnTijd;
        }
        #endregion
    }
}
