using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Lesgever : Gebruiker
    {
        public Lesgever(string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
    string geboorteLand, string geboorteStad, string straat, int huisNummer, string gemeente,
    int postcode, int telefoonNummer, int gsmNummer, int rijksregisterNummer, DateTime inschrijvingsDatum,
    string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden)
        {
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
    }
}
