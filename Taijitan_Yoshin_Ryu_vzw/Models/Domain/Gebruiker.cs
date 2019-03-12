using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Gebruiker
    {
        #region Properties
        public string Username { get; set; } //Unieke waarde
        public string Email { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public char Geslacht { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string GeboorteLand { get; set; }
        public string GeboorteStad { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public string TelefoonNummer { get; set; } //Niet verplicht
        public string GsmNummer { get; set; }
        public string RijksregisterNummer { get; set; }
        public DateTime InschrijvingsDatum { get; set; }
        public string EmailOuders { get; set; } //Niet verplicht
        public bool InfoClubAangelegenheden { get; set; }
        public bool InfoFederaleAangelegenheden { get; set; }
        #endregion

        #region Constructors
        public Gebruiker() {
        }

        public Gebruiker(string username, string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
            string geboorteLand, string geboorteStad, string straat, string huisNummer, string gemeente,
            string postcode, string telefoonNummer, string gsmNummer, string rijksregisterNummer, DateTime inschrijvingsDatum,
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden)
        {
            Username = username;
            Email = email;
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = geslacht;
            GeboorteDatum = geboorteDatum;
            GeboorteLand = geboorteLand;
            GeboorteStad = geboorteStad;
            Straat = straat;
            HuisNummer = huisNummer;
            Gemeente = gemeente;
            Postcode = postcode;
            TelefoonNummer = telefoonNummer; //Niet verplicht
            GsmNummer = gsmNummer;
            RijksregisterNummer = rijksregisterNummer;
            InschrijvingsDatum = inschrijvingsDatum;
            EmailOuders = emailOuders; //Niet verplicht
            InfoClubAangelegenheden = infoClubAangelegenheden;
            InfoFederaleAangelegenheden = infoFederaleAangelegenheden;
        }
        #endregion
    }
}