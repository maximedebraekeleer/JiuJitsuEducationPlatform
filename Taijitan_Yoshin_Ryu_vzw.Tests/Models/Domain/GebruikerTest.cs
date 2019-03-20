using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Models.Domain
{
    public class GebruikerTest
    {
        #region Attributen
        private Gebruiker _gebruiker;
        public DateTime HuidigeDatum = DateTime.Today;
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
            DateTime geboorteDatum = HuidigeDatum.AddYears(2);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumOuderDan99Jaar1_ThrowsException()
        {
            DateTime geboorteDatum = HuidigeDatum.AddYears(-100);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumOuderDan99Jaar2_ThrowsException()
        {
            DateTime geboorteDatum = HuidigeDatum.AddYears(-200);
            Assert.Throws<ArgumentException>(() => new Gebruiker { GeboorteDatum = geboorteDatum });
        }

        [Fact]
        public void GebruikerMaken_GeboorteDatumCorrect_GeboorteDatumToegevoegd()
        {
            DateTime geboorteDatum = new DateTime(1997, 3, 19);
            _gebruiker = new Gebruiker { GeboorteDatum = geboorteDatum };
            Assert.Equal(_gebruiker.GeboorteDatum, geboorteDatum);
        }

        //
    }
}
