using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Models.Domain
{
    public class SessieTest
    {
        #region Properties
        private readonly DateTime _huidigeDatum;
        private readonly Lesgever _lesgever;
        #endregion

        #region Constructors
        public SessieTest()
        {
            _huidigeDatum = DateTime.Today;
            _lesgever = new Lesgever() { Username = "Lesgever123"};
        }
        #endregion

        //EindDatumEnTijd
        [Fact]
        public void SessieMaken_EindDatumEnTijdVoorBeginDatumEnTijd_ThrowsException()
        {
            DateTime eindDatumEnTijd = _huidigeDatum.AddHours(-2);
            Assert.Throws<ArgumentException>(() => new Sessie(_huidigeDatum, eindDatumEnTijd, _lesgever));
        }
    }
}
