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

        public GebruikerControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _gebruikersRepo = new Mock<IGebruikerRepository>();
            _gebruikerController = new GebruikerController(_gebruikersRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }

        #region Index
        [Fact(Skip = "Moet nog geimplementeerd worden")]
        public void Index_ToonLid() {
        }
        [Fact(Skip = "Moet nog geimplementeerd worden")]
        public void Index_ToonLesgever() {
        }
        [Fact(Skip = "Moet nog geimplementeerd worden")]
        public void Index_ToonError() {
        }
        #endregion
    }
}
