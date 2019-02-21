using System;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Lid {

        #region Fields
        private string _naam;
        private string _voornaam;
        private string _straat;
        private int _huisNummer;
        private DateTime _geboorteDatum;
        private int _postcode;
        private int _telefoonNummer;
        private string _gemeente;
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
            private set {
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

        public int Huisnummer {
            get => _huisNummer;
            set {
                if (value.Equals(null) || value == 0)
                    throw new ArgumentException("Huisnummer mag niet leeg zijn");
                _huisNummer = value;
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

        public string Gemeente {
            get => _gemeente;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Gemeente kan niet leeg zijn of meer dan 45 caracters bevatten");
                _gemeente = value;
            }
        }

        public string Email { get; set; }

        #endregion

        #region Constructor

        public Lid(string naam, string voornaam, string straat, int huisNummer, DateTime geboorteDatum, int postcode, int telefoonNummer) {
            _naam = naam;
            _voornaam = voornaam;
            _straat = straat;
            _huisNummer = huisNummer;
            _geboorteDatum = geboorteDatum;
            _postcode = postcode;
            _telefoonNummer = telefoonNummer;
        }

        #endregion

        #region Methods


        #endregion
    }
}
