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
    public class LesmateriaalControllerTest {
        private readonly LesmateriaalController _lesmateriaalController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGraadRepository> _graadRepo;

        public LesmateriaalControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _graadRepo = new Mock<IGraadRepository>();
            _lesmateriaalController = new LesmateriaalController(_graadRepo.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }

        #region Index
        [Fact(Skip = "Moet nog geimplementeerd worden")]
        public void Index_GeefViewModelTerug() {
        }
        
        #endregion

    }
}
