using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Sessie
    {
        #region Regions
        private DateTime _tijdstip;
        #endregion

        #region Properties
        public DateTime Tijdstip {
            get => _tijdstip;
            set {
                if (value.Equals(null))
                    throw new ArgumentException("Datum kan niet leeg zijn");
                _tijdstip = value;
            }
        }
        #endregion

        #region Collections
        public ICollection<SessieLesgroep> SessieLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => SessieLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        protected Sessie() {
            SessieLesgroepen = new HashSet<SessieLesgroep>();
        }

        public Sessie(DateTime tijdstip) : this() {
            Tijdstip = tijdstip;
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            SessieLesgroepen.Add(new SessieLesgroep(this, l));
        }
        #endregion
    }
}
