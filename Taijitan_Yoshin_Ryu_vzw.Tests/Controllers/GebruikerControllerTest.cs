using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Taijitan_Yoshin_Ryu_vzw.Controllers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Controllers {
    public class GebruikerControllerTest {
        private readonly GebruikerController _gebruikerController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGebruikerRepository> _gebruikersRepo;
        private Gebruiker _gebruiker;

        public GebruikerControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _gebruiker = new Gebruiker();
            _gebruikersRepo = new Mock<IGebruikerRepository>();
            _gebruikerController = new GebruikerController(_gebruikersRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }

        #region Index
        [Fact]
        public void Index_ToonLid() {
            _gebruikersRepo.Setup(gr => gr.GetByUserName("Lid0003")).Returns(_dummyContext.lid3);
            _gebruiker = _dummyContext.gebruiker1;
            IActionResult actionResult = _gebruikerController.Index(_gebruiker);
            

        }
        [Fact]
        public void Index_ToonLesgever() {
            _gebruikersRepo.Setup(gr => gr.GetByUserName("LesgeverHans")).Returns(_dummyContext.lesgever1);
            _gebruiker = _dummyContext.lesgever1;
            IActionResult actionResult = _gebruikerController.Index(_gebruiker);
        }
        [Fact]
        public void Index_ToonError() {
            _gebruiker = null;
            var result = _gebruikerController.Index(_gebruiker);
            Assert.IsType<ViewResult>(result);
        }
        #endregion
    }
}
