using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Gebruiker {
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

        //Type Gebruiker
        public bool IsLid { get; set; }
        public bool IsLesgever { get; set; }
        #endregion

        #region Collections
        public ICollection<GebruikerLesgroep> GebruikerLesgroepen { get; private set; }
        public IEnumerable<Lesgroep> Lesgroepen => GebruikerLesgroepen.Select(l => l.Lesgroep);
        #endregion

        #region Constructors
        public Gebruiker() {
            GebruikerLesgroepen = new HashSet<GebruikerLesgroep>();
        }

        public Gebruiker(string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum, 
            string geboorteLand, string geboorteStad, string straat, int huisNummer, string gemeente, 
            int postcode, int telefoonNummer, int gsmNummer, int rijksregisterNummer, DateTime inschrijvingsDatum, 
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden, 
            bool isLid, bool isLesgever) {
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
                IsLid = isLid;
                IsLesgever = isLesgever;
        }
        #endregion

        #region Methods
        public void AddLesgroep(Lesgroep l) {
            GebruikerLesgroepen.Add(new GebruikerLesgroep(this, l));
        }
        #endregion
    }
}