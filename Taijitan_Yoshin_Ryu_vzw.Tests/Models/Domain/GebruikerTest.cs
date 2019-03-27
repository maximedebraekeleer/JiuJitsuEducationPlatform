using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Models.Domain
{
    public class GebruikerTest
    {
        #region Fields
        private Gebruiker _gebruiker;
        public readonly DateTime _huidigeDatum;
        #endregion

        #region Constructors
        public GebruikerTest()
        {
            _huidigeDatum = DateTime.Today;
        }
        #endregion

        //Username
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("123456")]
        [InlineData("daan")]
        public void GebruikerMaken_UsernameOngeldig_ThrowsException(string username)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Username = username });
        }

        [Fact]
        public void GebruikerMaken_UsernameCorrect_UsernameToegevoegd()
        {
            string username = "Daan1997";
            _gebruiker = new Gebruiker { Username = username };
            Assert.Equal(_gebruiker.Username, username);
        }

        //Email
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("daan/gmail.com")]
        [InlineData("@gmail.com")]
        public void GebruikerMaken_EmailOngeldig_ThrowsException(string email)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Email = email });
        }

        [Fact]
        public void GebruikerMaken_EmailCorrect_EmailToegevoegd()
        {
            string email = "daan@gmail.com";
            _gebruiker = new Gebruiker { Email = email };
            Assert.Equal(_gebruiker.Email, email);
        }

        //Naam
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("Van Vooren 123")]
        [InlineData("Pee1ters")]
        public void GebruikerMaken_NaamOngeldig_ThrowsException(string naam)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Naam = naam });
        }

        [Fact]
        public void GebruikerMaken_NaamCorrect_NaamToegevoegd()
        {
            string naam = "Van Vooren";
            _gebruiker = new Gebruiker { Naam = naam };
            Assert.Equal(_gebruiker.Naam, naam);
        }

        //Voornaam
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("1Daan")]
        [InlineData("123")]
        public void GebruikerMaken_VoornaamOngeldig_ThrowsException(string voornaam)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Voornaam = voornaam });
        }

        [Fact]
        public void GebruikerMaken_VoornaamCorrect_VoornaamToegevoegd()
        {
            string voornaam = "Daan";
            _gebruiker = new Gebruiker { Voornaam = voornaam };
            Assert.Equal(_gebruiker.Voornaam, voornaam);
        }

        //Geslacht
        [Theory]
        [InlineData(null)]
        [InlineData(' ')]
        [InlineData('a')]
        [InlineData('b')]
        public void GebruikerMaken_GeslachtOngeldig_ThrowsException(char geslacht)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Geslacht = geslacht });
        }

        [Theory]
        [InlineData('m')]
        [InlineData('v')]
        public void GebruikerMaken_GeslachtCorrect_GeslachtToegevoegd(char geslacht)
        {
            _gebruiker = new Gebruiker { Geslacht = geslacht };
            Assert.Equal(_gebruiker.Geslacht, geslacht);
        }

        //Geboortedatum
        [Fact]
        public void GebruikerMaken_GeboorteDatumNaVandaag_ThrowsException()
        {
            DateTime geboorteDatum = _huidigeDatum.AddYears(2);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumJongerDan6Jaar_ThrowsException()
        {
            DateTime geboorteDatum = _huidigeDatum.AddYears(-5);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumOuderDan99Jaar1_ThrowsException()
        {
            DateTime geboorteDatum = _huidigeDatum.AddYears(-100);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumOuderDan99Jaar2_ThrowsException()
        {
            DateTime geboorteDatum = _huidigeDatum.AddYears(-200);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumCorrect_GeboorteDatumToegevoegd()
        {
            DateTime geboorteDatum = new DateTime(1997, 3, 19);
            _gebruiker = new Gebruiker { GeboorteDatum = geboorteDatum };
            Assert.Equal(_gebruiker.GeboorteDatum, geboorteDatum);
        }

        //GeboorteLand
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("België32")]
        [InlineData("123")]
        public void GebruikerMaken_GeboorteLandOngeldig_ThrowsException(string geboorteLand)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteLand = geboorteLand });
        }

        [Fact]
        public void GebruikerMaken_GeboorteLandCorrect_GeboorteLandToegevoegd()
        {
            string geboorteland = "België";
            _gebruiker = new Gebruiker { GeboorteLand = geboorteland };
            Assert.Equal(_gebruiker.GeboorteLand, geboorteland);
        }

        //GeboorteStad
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("Gent9000")]
        [InlineData("123")]
        public void GebruikerMaken_GeboorteStadOngeldig_ThrowsException(string geboorteStad)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteStad = geboorteStad });
        }

        [Fact]
        public void GebruikerMaken_GeboorteStadCorrect_GeboorteStadToegevoegd()
        {
            string geboorteStad = "Gent";
            _gebruiker = new Gebruiker { GeboorteStad = geboorteStad };
            Assert.Equal(_gebruiker.GeboorteStad, geboorteStad);
        }

        //GeboorteStad
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("Rijschootstraat 12")]
        [InlineData("Rijschootstraat1")]
        public void GebruikerMaken_StraatOngeldig_ThrowsException(string straat)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Straat = straat });
        }

        [Fact]
        public void GebruikerMaken_StraatCorrect_StraatToegevoegd()
        {
            string straat = "Rijschootstraat";
            _gebruiker = new Gebruiker { Straat = straat };
            Assert.Equal(_gebruiker.Straat, straat);
        }

        //HuisNummer
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("B12")]
        [InlineData("TwaalfB")]
        public void GebruikerMaken_HuisNummerOngeldig_ThrowsException(string huisnummer)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { HuisNummer = huisnummer });
        }

        [Theory]
        [InlineData("12")]
        [InlineData("12B")]
        public void GebruikerMaken_HuisNummerCorrect_HuisNummerToegevoegd(string huisNummer)
        {
            _gebruiker = new Gebruiker { HuisNummer = huisNummer };
            Assert.Equal(_gebruiker.HuisNummer, huisNummer);
        }

        //Gemeente
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("Ertvelde9940")]
        [InlineData("9940")]
        public void GebruikerMaken_GemeenteOngeldig_ThrowsException(string gemeente)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Gemeente = gemeente });
        }

        [Fact]
        public void GebruikerMaken_GemeenteCorrect_GemeenteToegevoegd()
        {
            string gemeente = "Ertvelde";
            _gebruiker = new Gebruiker { Gemeente = gemeente };
            Assert.Equal(_gebruiker.Gemeente, gemeente);
        }

        //Postcode
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("9000BE")]
        [InlineData("900")]
        [InlineData("B5000")]
        public void GebruikerMaken_PostcodeOngeldig_ThrowsException(string postcode)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { Postcode = postcode });
        }

        [Fact]
        public void GebruikerMaken_PostcodeCorrect_PostcodeToegevoegd()
        {
            string postcode = "9000";
            _gebruiker = new Gebruiker { Postcode = postcode };
            Assert.Equal(_gebruiker.Postcode, postcode);
        }

        //TelefoonNummer
        [Theory]
        [InlineData("+32911122110")]
        [InlineData("+329111221")]
        [InlineData("0911122110")]
        [InlineData("09111221")]
        public void GebruikerMaken_TelefoonNummerOngeldig_ThrowsException(string telefoonNummer)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { TelefoonNummer = telefoonNummer });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("+3291112211")]
        [InlineData("091112211")]
        public void GebruikerMaken_TelefoonNummerCorrect_TelefoonNummerToegevoegd(string telefoonNummer)
        {
            _gebruiker = new Gebruiker { TelefoonNummer = telefoonNummer };
            Assert.Equal(_gebruiker.TelefoonNummer, telefoonNummer);
        }

        //GsmNummer
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("abc")]
        [InlineData("04b70055700")]
        [InlineData("+3247005570")]
        [InlineData("+3247005570i")]
        public void GebruikerMaken_GsmNummerOngeldig_ThrowsException(string gsmNummer)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { GsmNummer = gsmNummer });
        }

        [Theory]
        [InlineData("0470055701")]
        [InlineData("+32470055701")]
        public void GebruikerMaken_GsmNummerCorrect_GsmNummerToegevoegd(string gsmNummer)
        {
            _gebruiker = new Gebruiker { GsmNummer = gsmNummer };
            Assert.Equal(_gebruiker.GsmNummer, gsmNummer);
        }

        //RijksregisterNummer
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("abc")]
        [InlineData("123456789")]
        [InlineData("87011033155")]
        [InlineData("97011033156")]
        public void GebruikerMaken_RijksregisterNummerOngeldig_ThrowsException(string rijksregisterNummer)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { RijksregisterNummer = rijksregisterNummer });
        }

        [Theory]
        [InlineData("97011033155")]
        [InlineData("96032732925")]
        public void GebruikerMaken_RijksregisterNummerCorrect_RijksregisterNummerToegevoegd(string rijksregisterNummer)
        {
            _gebruiker = new Gebruiker { RijksregisterNummer = rijksregisterNummer };
            Assert.Equal(_gebruiker.RijksregisterNummer, rijksregisterNummer);
        }

        //InschrijvingsDatum
        [Fact]
        public void GebruikerMaken_InschrijvingsDatumNaVandaag_ThrowsException()
        {
            DateTime inschrijvingsDatum = _huidigeDatum.AddYears(1);
            Assert.Throws<ArgumentException>(() => new Gebruiker { InschrijvingsDatum = inschrijvingsDatum });
        }

        [Fact]
        public void GebruikerMaken_InschrijvingsDatumCorrect1_InschrijvingsDatumToegevoegd()
        {
            DateTime inschrijvingsDatum = new DateTime(1997, 3, 19);
            _gebruiker = new Gebruiker { InschrijvingsDatum = inschrijvingsDatum };
            Assert.Equal(_gebruiker.InschrijvingsDatum, inschrijvingsDatum);
        }

        [Fact]
        public void GebruikerMaken_InschrijvingsDatumCorrect2_InschrijvingsDatumToegevoegd()
        {
            DateTime inschrijvingsDatum = _huidigeDatum;
            _gebruiker = new Gebruiker { InschrijvingsDatum = inschrijvingsDatum };
            Assert.Equal(_gebruiker.InschrijvingsDatum, inschrijvingsDatum);
        }

        //EmailOuders
        [Theory]
        [InlineData("daan/gmail.com")]
        [InlineData("@gmail.com")]
        public void GebruikerMaken_EmailOudersOngeldig_ThrowsException(string emailOuders)
        {
            Assert.Throws<ArgumentException>(() => new Gebruiker { EmailOuders = emailOuders });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("daan@gmail.com")]
        public void GebruikerMaken_EmailOudersCorrect_EmailOudersToegevoegd(string emailOuders)
        {
            _gebruiker = new Gebruiker { EmailOuders = emailOuders };
            Assert.Equal(_gebruiker.EmailOuders, emailOuders);
        }
    }
}
