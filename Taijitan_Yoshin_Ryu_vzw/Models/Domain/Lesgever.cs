using System;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Lesgever : Gebruiker {

        #region Constructors
        public Lesgever() : base() {
        }

        public Lesgever(string username, string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
            string geboorteLand, string geboorteStad, string straat, string huisNummer, string gemeente,
            string postcode, string telefoonNummer, string gsmNummer, string rijksregisterNummer, DateTime inschrijvingsDatum,
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden)
            : base(username, email, naam, voornaam, geslacht, geboorteDatum,
                geboorteLand, geboorteStad, straat, huisNummer, gemeente,
                postcode, telefoonNummer, gsmNummer, rijksregisterNummer, inschrijvingsDatum,
                emailOuders, infoClubAangelegenheden, infoFederaleAangelegenheden) {

        }
        #endregion
    }
}
