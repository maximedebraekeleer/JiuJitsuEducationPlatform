using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Gast : Gebruiker
    {
        public int AantalAanwezigheden { get; set; }
        public Gast() :base()
        {

        }
        public Gast(string username, string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
            string geboorteLand, string geboorteStad, string straat, string huisNummer, string gemeente,
            string postcode, string telefoonNummer, string gsmNummer, string rijksregisterNummer, DateTime inschrijvingsDatum,
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden)
            : base(username, email, naam, voornaam, geslacht, geboorteDatum,
                geboorteLand, geboorteStad, straat, huisNummer, gemeente,
                postcode, telefoonNummer, gsmNummer, rijksregisterNummer, inschrijvingsDatum,
                emailOuders, infoClubAangelegenheden, infoFederaleAangelegenheden)
        {
            
        }
    }
}
