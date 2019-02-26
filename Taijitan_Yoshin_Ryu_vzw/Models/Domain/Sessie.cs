using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models
{
    public class Sessie
    {
        #region Properties
        public DateTime Tijdstip { get; private set; }
        #endregion

        #region Collections
        public ICollection<Lesgroep> Lesgroepen { get; private set; }
        #endregion

        #region Constructors
        private Sessie() {
            Lesgroepen = new List<Lesgroep>();
        }

        public Sessie(DateTime tijdstip) : this() {
            Tijdstip = tijdstip;
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep lesgroep) {
            Lesgroepen.Add(lesgroep);
        }
        #endregion
    }
}
