using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Lesgroep {

        #region Fields
        private string _groepsnaam;
        #endregion

        #region Properties
        public string Groepsnaam {
            get => _groepsnaam;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Groepsnaam kan niet leeg zijn of meer dan 45 caracters bevatten");
                _groepsnaam = value;
            }
        }
        #endregion

        #region Collections
        public ICollection<LidLesgroep> LidLesgroepen { get; private set; }
        public IEnumerable<Lid> Leden => LidLesgroepen.Select(l => l.Lid);
        #endregion

        #region Constructors
        protected Lesgroep() {
            LidLesgroepen = new HashSet<LidLesgroep>();
        }

        public Lesgroep(string groepsnaam) : this() {
            Groepsnaam = groepsnaam;
        }
        #endregion

        #region Methods
        public void AddLid(Lid l) {
            LidLesgroepen.Add(new LidLesgroep(l, this));
        }
        #endregion
    }
}
