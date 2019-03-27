using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Taijitan_Yoshin_Ryu_vzw.Controllers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
using Xunit;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Controllers {
    public class GebruikerControllerTest {
        private readonly GebruikerController _gebruikerController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGebruikerRepository> _gebruikersRepo;
        private readonly Mock<ICommentaarRepository> _commentaarRepo;
        private Gebruiker _gebruiker;

        public GebruikerControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _gebruiker = new Gebruiker();
            _gebruikersRepo = new Mock<IGebruikerRepository>();
            _commentaarRepo = new Mock<ICommentaarRepository>();
            _gebruikerController = new GebruikerController(_gebruikersRepo.Object, _commentaarRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }

        #region Index
        [Fact]
        public void Index_ToonLid() {
            _gebruikersRepo.Setup(gr => gr.GetByUserName("LidMaxime")).Returns(_dummyContext.lid1);
            _gebruiker = _dummyContext.lid1;
            IActionResult actionResult = _gebruikerController.Index(_gebruiker);
            Assert.Equal("LidMaxime", _gebruiker.Username);

        }
        [Fact]
        public void Index_ToonLesgever() {
            _gebruikersRepo.Setup(gr => gr.GetByUserName("LesgeverHans")).Returns(_dummyContext.lesgever1);
            _gebruiker = _dummyContext.lesgever1;
            IActionResult actionResult = _gebruikerController.Index(_gebruiker);
            Assert.Equal("LesgeverHans", _gebruiker.Username);
        }
        [Fact]
        public void Index_ToonLesgeverCommentaar() {
            _gebruikersRepo.Setup(gr => gr.GetByUserName("LesgeverHans")).Returns(_dummyContext.lesgever1);
            _commentaarRepo.Setup(c => c.GetNew()).Returns(_dummyContext.Commentaren);
            IActionResult actionResult = _gebruikerController.Index(_gebruiker);
            //Assert.Equal(2, )

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
