using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public abstract class Gebruiker
    {
        #region Properties
        //Info over Gebruiker
        public string Email { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public char Geslacht { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string GeboorteLand { get; set; }
        public string GeboorteStad { get; set; }
        public string Straat { get; set; }
        public int HuisNummer { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public int TelefoonNummer { get; set; } //Niet verplicht
        public int GsmNummer { get; set; }
        public int RijksregisterNummer { get; set; }
        public DateTime InschrijvingsDatum { get; set; }
        public string EmailOuders { get; set; } //Niet verplicht
        public bool InfoClubAangelegenheden { get; set; }
        public bool InfoFederaleAangelegenheden { get; set; }
        #endregion
    }
}