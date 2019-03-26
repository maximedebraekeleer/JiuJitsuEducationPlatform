using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Models.Domain
{
    public class LidTest
    {
        #region Fields
        private const string _username = "Daan123";
        private const string _email = "daanvanvooren@gmail.com";
        private const string _naam = "Van Vooren";
        private const string _voornaam = "Daan";
        private const char _geslacht = 'm';
        private readonly DateTime _geboorteDatum = new DateTime(1997, 01, 10);
        private const string _geboorteLand = "België";
        private const string _geboorteStad = "Gent";
        private const string _straat = "Rijschootstraat";
        private const string _huisNummer = "101B";
        private const string _gemeente = "Ertvelde";
        private const string _postcode = "9940";
        private const string _telefoonNummer = ""; //Niet verplicht
        private const string _gsmNummer = "0470011701";
        private const string _rijksregisterNummer = "97011033155";
        private readonly DateTime _inschrijvingsDatum = new DateTime(2000, 01, 10);
        private const string _emailOuders = ""; //Niet verplicht
        private const bool _infoClubAangelegenheden = true;
        private const bool _infoFederaleAangelegenheden = false;

        private readonly Graad _graad;
        private readonly Formule _formule;
        #endregion

        #region Constructors
        public LidTest()
        {
            _graad = new Graad(1, "Graad 1", "#ffffff");
            _formule = new Formule("Formule 1") { Id = 1 };
        }
        #endregion


        [Fact]
        public void LidMaken_DataValideren_MaaktLid()
        {
            var lid = new Lid(_username, _email, _naam, _voornaam, _geslacht, _geboorteDatum, _geboorteLand,
                _geboorteStad, _straat, _huisNummer, _gemeente, _postcode, _telefoonNummer, _gsmNummer, _rijksregisterNummer,
                _inschrijvingsDatum, _emailOuders, _infoClubAangelegenheden, _infoFederaleAangelegenheden, _formule, _graad);

            Assert.Equal(_username, lid.Username);
            Assert.Equal(_email, lid.Email);
            Assert.Equal(_naam, lid.Naam);
            Assert.Equal(_voornaam, lid.Voornaam);
            Assert.Equal(_geslacht, lid.Geslacht);
            Assert.Equal(_geboorteDatum, lid.GeboorteDatum);
            Assert.Equal(_geboorteLand, lid.GeboorteLand);
            Assert.Equal(_geboorteStad, lid.GeboorteStad);
            Assert.Equal(_straat, lid.Straat);
            Assert.Equal(_huisNummer, lid.HuisNummer);
            Assert.Equal(_telefoonNummer, lid.TelefoonNummer);
            Assert.Equal(_gsmNummer, lid.GsmNummer);
            Assert.Equal(_rijksregisterNummer, lid.RijksregisterNummer);
            Assert.Equal(_emailOuders, lid.EmailOuders);
            Assert.Equal(_infoClubAangelegenheden, lid.InfoClubAangelegenheden);
            Assert.Equal(_infoFederaleAangelegenheden, lid.InfoFederaleAangelegenheden);
            Assert.Equal(_formule, lid.Formule);
            Assert.Equal(_graad, lid.Graad);
        }

        [Fact]
        public void LidMaken_GeenFormule_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Lid(_username, _email, _naam, _voornaam, _geslacht, _geboorteDatum, _geboorteLand,
                _geboorteStad, _straat, _huisNummer, _gemeente, _postcode, _telefoonNummer, _gsmNummer, _rijksregisterNummer,
                _inschrijvingsDatum, _emailOuders, _infoClubAangelegenheden, _infoFederaleAangelegenheden, null, _graad));
        }

        [Fact]
        public void LidMaken_GeenGraad_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Lid(_username, _email, _naam, _voornaam, _geslacht, _geboorteDatum, _geboorteLand,
                _geboorteStad, _straat, _huisNummer, _gemeente, _postcode, _telefoonNummer, _gsmNummer, _rijksregisterNummer,
                _inschrijvingsDatum, _emailOuders, _infoClubAangelegenheden, _infoFederaleAangelegenheden, _formule, null));
        }
    }
}
