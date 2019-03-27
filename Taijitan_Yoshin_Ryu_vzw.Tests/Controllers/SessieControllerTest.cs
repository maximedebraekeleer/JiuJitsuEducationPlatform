using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using Taijitan_Yoshin_Ryu_vzw.Controllers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels;
using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Controllers
{
    public class SessieControlerTest
    {

        private readonly SessieController _sessieController;
        private readonly Mock<IFormuleRepository> _formules;
        private readonly Mock<ITrainingsmomentRepository> _trainingsmomenten;
        private readonly Mock<IGebruikerRepository> _gebruikers;
        private readonly Mock<IAanwezigheidRepository> _aanwezigheden;
        private readonly Mock<ISessieRepository> _sessies;
        private readonly Mock<IGraadRepository> _graden;
        private readonly DummyApplicationDbContext _dummContext;
        private Sessie HuidigeSessie;

        public SessieControlerTest()
        {
            _dummContext = new DummyApplicationDbContext();
            _sessies = new Mock<ISessieRepository>();
            HuidigeSessie = _dummContext.HuidigeSessie;
            _aanwezigheden = new Mock<IAanwezigheidRepository>();
            _formules = new Mock<IFormuleRepository>();
            _gebruikers = new Mock<IGebruikerRepository>();
            _trainingsmomenten = new Mock<ITrainingsmomentRepository>();
            _graden = new Mock<IGraadRepository>();
            _sessieController = new SessieController(_formules.Object, _trainingsmomenten.Object, _gebruikers.Object, _aanwezigheden.Object, _sessies.Object, _graden.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }



        #region Index
        [Fact]
        public void Index_GeefDeJuisteView()
        {
            _gebruikers.Setup(g => g.GetByUserName("LesgeverHans")).Returns(_dummContext.lesgever1);
            Gebruiker gebruiker = _dummContext.gebruiker1;
            Sessie sessie = _dummContext.HuidigeSessie;
            var actionResult = _sessieController.Index(gebruiker, sessie) as RedirectToActionResult;
            //SessieViewModel sessieVM = (actionResult as ViewResult)?.Model as SessieViewModel;
            Assert.Equal("Lesgever", actionResult?.ActionName);

        }
        #endregion

        #region RegistreerAanwezigheid
        [Fact]
        public void RegistratieAanwezigheid_Test()
        {
            _gebruikers.Setup(g => g.GetByUserName("LidMaxime")).Returns(_dummContext.lid1);
            Sessie sessie = _dummContext.HuidigeSessie;
            var actionResult = _sessieController.RegistreerAanwezigheid(sessie, "Lid3") as RedirectToActionResult;
            Assert.Equal("Index", actionResult?.ActionName);
        }
        [Fact]
        public void RegistreerAanwezigheid_SessieNull()
        {
            RedirectToActionResult action = _sessieController.RegistreerAanwezigheid(null, "LidMaxime") as RedirectToActionResult;
            Assert.Equal("Gebruiker", action?.ControllerName);
            Assert.Equal("Lesgever", action?.ActionName);
        }
        [Fact]
        public void RegistreerAanwezigheid_AanwezigheidNietNull()
        {
            _gebruikers.Setup(g => g.GetByUserName("LidMaxime")).Returns(_dummContext.lid1);
            _aanwezigheden.Setup(a => a.GetbyLid((Lid)_dummContext.lid1)).Returns(_dummContext.Aanwezigheden);
            RedirectToActionResult action = _sessieController.RegistreerAanwezigheid(HuidigeSessie, "LidMaxime") as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
            _aanwezigheden.Verify(m => m.Remove(It.IsAny<Aanwezigheid>()), Times.Once());
            _aanwezigheden.Verify(m => m.SaveChanges(), Times.Once());

        }
        [Fact]
        public void RegistreerAanwezigheid_AanwezigheidNull()
        {
            _gebruikers.Setup(g => g.GetByUserName("LidMichael")).Returns(_dummContext.lid4);
            RedirectToActionResult action = _sessieController.RegistreerAanwezigheid(HuidigeSessie, "LidMichael") as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
            _sessies.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Fact]
        public void RegistreerAanwezigheid_UsernameNull()
        {
            RedirectToActionResult action = _sessieController.RegistreerAanwezigheid(HuidigeSessie, null) as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
            _sessies.Verify(m => m.SaveChanges(), Times.Never());
        }
        [Fact]
        public void RegistreerAanwezigheid_UsernameLeeg()
        {
            RedirectToActionResult action = _sessieController.RegistreerAanwezigheid(HuidigeSessie, "") as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
            _sessies.Verify(m => m.SaveChanges(), Times.Never());
        }
        #endregion

        #region RegistreerAanwezigNietInLijst
        [Fact]
        public void RegistreerAanwezigNietInLijst_validLid_RedirectsToActionIndex()
        {
            _formules.Setup(f => f.getAll()).Returns(_dummContext.Formules);
            GastViewModel gvm = new GastViewModel()
            {
                Username = "Gaaaaaaaast",
                Email = "Gast@gmail.com",
                Naam = "Tom",
                Voornaam = "Simons",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(1999, 10, 22),
                GeboorteLand = "België",
                GeboorteStad = "Gent",
                Straat = "Stationstraat",
                HuisNummer = "45",
                Gemeente = "Aalst",
                Postcode = "9300",
                TelefoonNummer = "+3291112211",
                GsmNummer = "0470055701",
                RijksregisterNummer = "96032732925",
                EmailOuders = "OudersGast@hotmail.be"
            };
            RedirectToActionResult action = _sessieController.RegistreerAanwezigNietInLijst(HuidigeSessie) as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
        }
        [Fact]
        public void RegistreerAanwezigNietInLijst_geenHuidigeSessie()
        {
            RedirectToActionResult action = _sessieController.Cancel(null) as RedirectToActionResult;
            Assert.Equal("Gebruiker", action?.ControllerName);
            Assert.Equal("Lesgever", action?.ActionName);
        }
        #endregion

        #region RegistreerAanwezigGast
        [Fact]
        public void RegistreerAanwezigGast_niewLidInViewModel()
        {
            IActionResult action = _sessieController.RegistreerAanwezigGast(HuidigeSessie);
            GastViewModel gvm = (action as ViewResult)?.Model as GastViewModel;
            Assert.Null(gvm?.Username);

        }
        #endregion

        #region POST RegistreerAanwezigGast
        [Fact]
        public void RegistreerAanwezigGast_validLid_RedirectsToActionIndex()
        {
            _formules.Setup(f => f.getAll()).Returns(_dummContext.Formules);
            _graden.Setup(g => g.GetGraadWithId(1)).Returns(_dummContext.kyu6);
            GastViewModel gvm = new GastViewModel()
            {
                Username = "Gaaaaaaaast",
                Email = "Gast@gmail.com",
                Naam = "Tom",
                Voornaam = "Simons",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(1999, 10, 22),
                GeboorteLand = "België",
                GeboorteStad = "Gent",
                Straat = "Stationstraat",
                HuisNummer = "45",
                Gemeente = "Aalst",
                Postcode = "9300",
                TelefoonNummer = "+3291112211",
                GsmNummer = "0470055701",
                RijksregisterNummer = "96032732925",
                EmailOuders = "OudersGast@hotmail.be"
            };
            RedirectToActionResult action = _sessieController.RegistreerAanwezigGast(HuidigeSessie, gvm) as RedirectToActionResult;
            Assert.Equal("Index", action?.ActionName);
        }
        [Fact]
        public void RegistreerAanwezigGast_validLid_CreatesAndPersistsLid()
        {
            _formules.Setup(f => f.getAll()).Returns(_dummContext.Formules);
            _graden.Setup(g => g.GetGraadWithId(1)).Returns(_dummContext.kyu6);
            GastViewModel gvm = new GastViewModel()
            {
                Username = "Gaaaaaaaast",
                Email = "Gast@gmail.com",
                Naam = "Tom",
                Voornaam = "Simons",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(1999, 10, 22),
                GeboorteLand = "België",
                GeboorteStad = "Gent",
                Straat = "Stationstraat",
                HuisNummer = "45",
                Gemeente = "Aalst",
                Postcode = "9300",
                TelefoonNummer = "+3291112211",
                GsmNummer = "0470055701",
                RijksregisterNummer = "96032732925",
                EmailOuders = "OudersGast@hotmail.be"
            };
            _sessieController.RegistreerAanwezigGast(HuidigeSessie, gvm);
            _gebruikers.Verify(m => m.Add(It.IsAny<Gebruiker>()), Times.Once());
            _gebruikers.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void RegistreeerAanwezigGast_InvalidLid_notCreatedNotPersisted()
        {
            _formules.Setup(f => f.getAll()).Returns(_dummContext.Formules);
            GastViewModel gvm = new GastViewModel()
            {
                Username = "Gaaaaaaaast",
                Email = "Gast@gmail.com",
                Naam = "Tom",
                Voornaam = "Simons",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(DateTime.Now.AddYears(2).Year, 10, 22),
                GeboorteLand = "België",
                GeboorteStad = "Gent",
                Straat = "Stationstraat",
                HuisNummer = "45",
                Gemeente = "Aalst",
                Postcode = "9300",
                TelefoonNummer = "+3291112211",
                GsmNummer = "0470055701",
                RijksregisterNummer = "96032732925",
                EmailOuders = "OudersGast@hotmail.be"
            };
            _gebruikers.Verify(m => m.Add(It.IsAny<Gebruiker>()), Times.Never());
            _gebruikers.Verify(m => m.SaveChanges(), Times.Never());
        }

        [Fact]
        public void RegistreerAanwezigGast_ModelStateErrors_PassesViewModelAndViewData()
        {
            _formules.Setup(f => f.getAll()).Returns(_dummContext.Formules);
            _graden.Setup(g => g.GetGraadWithId(1)).Returns(_dummContext.kyu6);
            GastViewModel gvm = new GastViewModel()
            {
                Username = "Gast",
                Email = "Gast@gmail.com",
                Naam = "Tom",
                Voornaam = "Simons",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(1999, 10, 22),
                GeboorteLand = "België",
                GeboorteStad = "Gent",
                Straat = "Stationstraat",
                HuisNummer = "45",
                Gemeente = "Aalst",
                Postcode = "9300",
                TelefoonNummer = "+3291112211",
                GsmNummer = "0470055701",
                RijksregisterNummer = "96032732925",
                EmailOuders = "OudersGast@hotmail.be"
            };
            //_sessieController.ModelState.AddModelError("", "Error message");
            ViewResult result = _sessieController.RegistreerAanwezigGast(HuidigeSessie, gvm) as ViewResult;
            Assert.Equal("RegistreerAanwezigGast", result?.ViewName);
            Assert.Equal(gvm, result?.Model);
        }
        #endregion

        #region Cancel
        [Fact]
        public void Cancel_sessie_null()
        {
            RedirectToActionResult action = _sessieController.Cancel(null) as RedirectToActionResult;
            Assert.Equal("Gebruiker", action?.ControllerName);
            Assert.Equal("Lesgever", action?.ActionName);
            _sessies.Verify(m => m.Remove(It.IsAny<Sessie>()), Times.Never());
            _sessies.Verify(m => m.SaveChanges(), Times.Never());
        }
        [Fact]
        public void Cancel_sessie_annuleert_Sessie()
        {
            RedirectToActionResult action = _sessieController.Cancel(HuidigeSessie) as RedirectToActionResult;
            Assert.Equal("Gebruiker", action?.ControllerName);
            Assert.Equal("Lesgever", action?.ActionName);
            _sessies.Setup(m => m.Remove(It.IsAny<Sessie>()));
            _sessies.Verify(m => m.Remove(It.IsAny<Sessie>()), Times.Once());
            _sessies.Verify(m => m.SaveChanges(), Times.Once());
        }
        #endregion

        #region POST AanwezigenToevoegen
        [Fact]
        public void AanwezigenToevoegen_sessieNull() {                   
        }
        [Fact]
        public void AanwezigenToevoegen_AanwezighedenNull() {
        }
        [Fact]
        public void AanwezigenToevoegen_AanwezighedenLeeg() {
        }

        #endregion

        #region SessieAanwezigen
        [Fact]
        public void SessieAanwezigen_sessieNull() {
            RedirectToActionResult action = _sessieController.SessieAanwezigen(null) as RedirectToActionResult;
            Assert.Equal("Gebruiker", action?.ControllerName);
            Assert.Equal("Lesgever", action?.ActionName);
        }
        [Fact]
        public void SessieAanwezigen_returnsViewModel() {
        }

        #endregion

    }
}
