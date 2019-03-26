using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
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
        private readonly Mock<ICommentaarRepository> _commentaarRepo;
        private readonly Mock<ILoggingRepository> _loggingRepo;
        private Gebruiker _gebruiker;
        private readonly Graad _graad;

        public LesmateriaalControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _gebruiker = _dummyContext.gebruiker1;
            _graadRepo = new Mock<IGraadRepository>();
            _gebruikerRepo = new Mock<IGebruikerRepository>();
            _commentaarRepo = new Mock<ICommentaarRepository>();
            _loggingRepo = new Mock<ILoggingRepository>();
            _lesmateriaalController = new LesmateriaalController(_graadRepo.Object, _commentaarRepo.Object, _loggingRepo.Object, _gebruikerRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };

        }

        #region Index
        [Fact]
        public void Index_GeefViewModelTerug() {

            _graadRepo.Setup(g => g.GetAll()).Returns(_dummyContext.Graden);
            _gebruikerRepo.Setup(gr => gr.GetByUserName("LidMaxime")).Returns(_dummyContext.lid1);

            _gebruiker = _dummyContext.lid1;

            IActionResult actionResult = _lesmateriaalController.Index(_gebruiker, "LidMaxime");
            var lesmateriaalVvm = (actionResult as ViewResult)?.Model as LesmateriaalViewModel;

            Assert.Equal("LidMaxime", lesmateriaalVvm?.HuidigLid.Username);

        }
        
        [Fact]
        public void index_geefviewmodelterug()
        {
        }
        //[Fact]
        //public void Index_TrowsNotFound() {
        //    _graadRepo.Setup(g => g.GetAll()).Returns((Graad)null);
        //    IActionResult action = _lesmateriaalController.Index(_gebruiker);
        //    Assert.IsType<NotFoundResult>(action);
        //}
        #endregion

        #region LesmateriaalView

        #endregion


        #region LesmateriaalViewHead

        #endregion


        #region NieuweCommentaren
        [Fact]
        public void NieweCommentaren_NaarViewModel() {
            _commentaarRepo.Setup(c => c.GetNew()).Returns(_dummyContext.Commentaren);

            IActionResult actionResult = _lesmateriaalController.NieuweCommentaren();
            CommentaarViewModel cvm = (actionResult as ViewResult)?.Model as CommentaarViewModel;

            Assert.Equal("Commentaar 1", cvm?.Commentaren[0].Inhoud);
        }
        #endregion

    }
}

