using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Sessie
    {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public DateTime Datum { get; set; }
        public string BeginUur { get; set; }
        public string EindUur { get; set; }

        #endregion

        #region Collections
        public ICollection<SessieLesgroep> SessieLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => SessieLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        protected Sessie() {
            SessieLesgroepen = new HashSet<SessieLesgroep>();
        }

        public Sessie(DateTime datum, string beginUur, string eindUur) : this() {
            Datum = datum.Date;
            BeginUur = beginUur;
            EindUur = eindUur;
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            SessieLesgroepen.Add(new SessieLesgroep(this, l));
        }
        #endregion
    }
}
