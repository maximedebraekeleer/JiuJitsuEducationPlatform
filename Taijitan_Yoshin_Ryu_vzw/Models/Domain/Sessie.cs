using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Sessie {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public DateTime BeginDatumEnTijd { get; set; }
        public DateTime EindDatumEnTijd { get; set; }
        public Lesgever Lesgever { get; set; }
        #endregion

        #region Collections
        public ICollection<Aanwezigheid> Aanwezigheden { get; set; }
        #endregion

        #region Constructors
        protected Sessie() {
            Aanwezigheden = new List<Aanwezigheid>();
        }

        public Sessie(DateTime beginDatumEnTijd, DateTime eindDatumEnTijd, Lesgever lesgever) : this() {
            BeginDatumEnTijd = beginDatumEnTijd;
            EindDatumEnTijd = eindDatumEnTijd;
            Lesgever = lesgever;
        }
        #endregion

        #region Methods
        public void voegAanwezigheidToe(Lid lid) {
            Aanwezigheden.Add(new Aanwezigheid(lid, this));
        }
        #endregion
    }
}
