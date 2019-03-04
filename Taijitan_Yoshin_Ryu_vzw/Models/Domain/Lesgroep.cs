using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
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
        public ICollection<GebruikerLesgroep> GebruikerLesgroepen { get; private set; }
        public IEnumerable<Gebruiker> Gebruikers => GebruikerLesgroepen.Select(l => l.Gebruiker);

        public ICollection<SessieLesgroep> SessieLesgroepen { get; private set; }
        public IEnumerable<Sessie> Sessies => SessieLesgroepen.Select(s => s.Sessie);
        #endregion

        #region Constructors
        protected Lesgroep() {
            GebruikerLesgroepen = new HashSet<GebruikerLesgroep>();
            SessieLesgroepen = new HashSet<SessieLesgroep>();
        }

        public Lesgroep(string groepsnaam) : this() {
            Groepsnaam = groepsnaam;
        }
        #endregion

        #region Methods
        public void AddGebruiker(Gebruiker l) {
            GebruikerLesgroepen.Add(new GebruikerLesgroep(l, this));
        }
        #endregion
    }
}
