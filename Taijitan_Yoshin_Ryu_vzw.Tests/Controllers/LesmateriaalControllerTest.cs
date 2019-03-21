using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Collections.Generic;
using Taijitan_Yoshin_Ryu_vzw.Controllers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.LesmateriaalViewModels;
using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Controllers {
    public class LesmateriaalControllerTest {
        private readonly LesmateriaalController _lesmateriaalController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGraadRepository> _graadRepo;
        private readonly Mock<IGebruikerRepository> _gebruikerRepo;
        private readonly Gebruiker _gebruiker;
        private readonly Graad _graad;

        public LesmateriaalControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _gebruiker = _dummyContext.gebruiker1;
            _graadRepo = new Mock<IGraadRepository>();
            _gebruikerRepo = new Mock<IGebruikerRepository>();
            _lesmateriaalController = new LesmateriaalController(_graadRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };

        }

        #region Index
        [Fact]
        public void Index_GeefViewModelTerug() {

            _graadRepo.Setup(g => g.GetAll()).Returns(_dummyContext.Graden);
            _gebruikerRepo.Setup(gr => gr.GetByUserName("Lid0003")).Returns(_dummyContext.lid3);

            //IEnumerable<Graad> graden = _graadRepo.GetAll().ToList();

            IActionResult actionResult = _lesmateriaalController.Index(_gebruiker);
            var lesmateriaalVvm = (actionResult as ViewResult)?.Model as LesmateriaalViewModel;

            // Assert.Equal("Lid0003", lesmateriaalVvm?.HuidigLid.Username);

        }

        //[Fact]
        //public void Index_TrowsNotFound() {
        //    _graadRepo.Setup(g => g.GetAll()).Returns((Graad)null);
        //    IActionResult action = _lesmateriaalController.Index(_gebruiker);
        //    Assert.IsType<NotFoundResult>(action);
        //}
        #endregion

    }
}

