//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Moq;
//using Taijitan_Yoshin_Ryu_vzw.Controllers;
//using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
//using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
//using Xunit;

//namespace Taijitan_Yoshin_Ryu_vzw.Tests.Controllers {
//    public class SessieControlerTest {

//        private readonly SessieController _sessieController;
//        private readonly Mock<ISessieRepository> _sessieRepo;
//        private readonly Mock<IAanwezigheidRepository> _aanwezigheidRepo;
//        private readonly Mock<IFormuleRepository> _formuleRepo;
//        private readonly Mock<IGebruikerRepository> _gebruikersRepo;
//        private readonly Mock<ITrainingsmomentRepository> _trainingsdagRepo;
//        private readonly DummyApplicationDbContext _dummContext;

//        public SessieControlerTest() {
//            _dummContext = new DummyApplicationDbContext();
//            _sessieRepo = new Mock<ISessieRepository>();
//            _sessieRepo.Setup(s => s.GetAll()).Returns(_dummContext.Sessies);
//            _aanwezigheidRepo = new Mock<IAanwezigheidRepository>();
//            _aanwezigheidRepo.Setup(a => a.GetAll()).Returns(_dummContext.Aanwezigheden);
//            _formuleRepo = new Mock<IFormuleRepository>();
//            _formuleRepo.Setup(f => f.getAll()).Returns(_dummContext.Formules);
//            _gebruikersRepo = new Mock<IGebruikerRepository>();
//            //_gebruikersRepo.Setup(g => g.GetAll()).Returns(_dummContext.Gebruikers);
//            //_gebruikersRepo.Setup(g => g.GetByUserName("Lid3")).Returns(_dummContext.lid3);
//            _trainingsdagRepo = new Mock<ITrainingsmomentRepository>();
//            _trainingsdagRepo.Setup(t => t.getAll()).Returns(_dummContext.Trainingsmomenten);
//            _sessieController = new SessieController(_formuleRepo.Object, _trainingsdagRepo.Object, _gebruikersRepo.Object, _aanwezigheidRepo.Object, _sessieRepo.Object) {
//                TempData = new Mock<ITempDataDictionary>().Object
//            };
//        }

//        [Fact]
//        public void Index_GeefDeJuisteView() {
//            _gebruikersRepo.Setup(g => g.GetByUserName("LesgeverHans")).Returns(_dummContext.lesgever1);

//            var actionResult = _sessieController.Index() as RedirectToActionResult;
//            //SessieViewModel sessieVM = (actionResult as ViewResult)?.Model as SessieViewModel;
//            Assert.Equal("Lesgever", actionResult?.ActionName);

//        }

//        #region RegistratieAanwezigheid
//        [Fact]
//        public void RegistratieAanwezigheid_Test() {
//            _gebruikersRepo.Setup(g => g.GetByUserName("Lid3")).Returns(_dummContext.lid3);

//            var actionResult = _sessieController.RegistreerAanwezigheid("Lid3") as RedirectToActionResult;

//            Assert.Equal("Index", actionResult?.ActionName);
//        }
//        #endregion
//    }
//}
