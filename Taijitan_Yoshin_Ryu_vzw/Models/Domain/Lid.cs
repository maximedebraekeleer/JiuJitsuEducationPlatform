using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Lid : Gebruiker
    {
        #region Regions
        private Formule _formule;
        private Graad _graad;
        #endregion

        #region Properties
        public Formule Formule
        {
            get => _formule;
            set
            {
                _formule = value ?? throw new ArgumentException("Formule mag niet leeg zijn");
            }
        }
        public Graad Graad
        {
            get => _graad;
            set
            {
                _graad = value ?? throw new ArgumentException("Graad mag niet leeg zijn");
            }
        }
        #endregion

        #region Constructors
        public Lid() : base()
        {

        }

        public Lid(string username, string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
            string geboorteLand, string geboorteStad, string straat, string huisNummer, string gemeente,
            string postcode, string telefoonNummer, string gsmNummer, string rijksregisterNummer, DateTime inschrijvingsDatum,
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden, Formule formule, Graad graad)
            : base(username, email, naam, voornaam, geslacht, geboorteDatum,
                geboorteLand, geboorteStad, straat, huisNummer, gemeente,
                postcode, telefoonNummer, gsmNummer, rijksregisterNummer, inschrijvingsDatum,
                emailOuders, infoClubAangelegenheden, infoFederaleAangelegenheden)
        {
            Formule = formule;
            Graad = graad;
        }

        
        public bool IsExtra(List<Formule> formulesMetLes)
        {
            return !formulesMetLes.Contains(Formule);
        }
        #endregion

        #region Methods
        public bool bevatFormule(int formuleId)
        {
            return Formule.Id == formuleId;
        }
        #endregion
    }
}
