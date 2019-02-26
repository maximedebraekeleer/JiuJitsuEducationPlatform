using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Lid {

        #region Fields
        private string _naam;
        private string _voornaam;
        private DateTime _geboorteDatum;
        private string _straat;
        private int _huisNummer;
        private string _gemeente;
        private int _postcode;
        private int _telefoonNummer;
        private string _email;
        private string _wachtwoord;
        #endregion


        #region Properties
        public string Naam {
            get => _naam;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Naam kan niet leeg zijn of meer dan 45 caracters bevatten");
                _naam = value;
            }
        }

        public string Voornaam {
            get => _voornaam;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Voornaam kan niet leeg zijn of meer dan 45 caracters bevatten");
                _voornaam = value;
            }
        }

        public DateTime GeboorteDatum {
            get => _geboorteDatum;
            set {
                if (value.Equals(null) && value >= DateTime.Today)
                    throw new ArgumentException("Datum kan niet voor vandaag zijn");
                _geboorteDatum = value;
            }
        }

        public string Straat {
            get => _straat;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Street cannot be empty and should not exceed 45 characters");
                _straat = value;
            }
        }

        public int HuisNummer {
            get => _huisNummer;
            set {
                if (value.Equals(null) || value == 0)
                    throw new ArgumentException("Huisnummer mag niet leeg zijn");
                _huisNummer = value;
            }
        }

        public string Gemeente {
            get => _gemeente;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Gemeente kan niet leeg zijn of meer dan 45 caracters bevatten");
                _gemeente = value;
            }
        }

        public int Postcode {
            get => _postcode;
            set {
                if (value.Equals(null) || value == 0)
                    throw new ArgumentException("Postcode mag niet leeg zijn");
                _postcode = value;
            }
        }

        public int TelefoonNummer {
            get => _telefoonNummer;
            set {
                if (value.Equals(null) || value == 0)
                    throw new ArgumentException("Telefoonnummer mag niet leeg zijn");
                _telefoonNummer = value;
            }
        }

        public string Email {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45 || new System.Net.Mail.MailAddress(value).Address != value)
                    throw new ArgumentException("Email kan niet leeg zijn of meer dan 45 caracters bevatten of Email is ongeldig");
                _email = value;
            }
        }

        public string Wachtwoord {
            get => _wachtwoord;
            set 
            {
                //Validatie nog implementeren
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Wachtwoord kan niet leeg zijn of meer dan 45 caracters bevatten");
                _wachtwoord = value;
            }
        }

        public bool IsBeheerder { get; set; }
        public bool IsLesgever { get; set; }
        #endregion

        #region Collections
        public ICollection<LidLesgroep> LidLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => LidLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        public Lid() {
            LidLesgroepen = new HashSet<LidLesgroep>();
        }

        public Lid(string naam, string voornaam, DateTime geboorteDatum, string straat, int huisNummer, string gemeente, int postcode, int telefoonNummer, string email, bool isBeheerder, bool isLesgever) : this() {
            Naam = naam;
            Voornaam = voornaam;
            GeboorteDatum = geboorteDatum;
            Straat = straat;
            HuisNummer = huisNummer;
            Gemeente = gemeente;
            Postcode = postcode;
            TelefoonNummer = telefoonNummer;
            Email = email;
            IsBeheerder = isBeheerder;
            IsLesgever = isLesgever;
            Wachtwoord = "123";
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            LidLesgroepen.Add(new LidLesgroep(this, l));
        }
        #endregion
    }
}
