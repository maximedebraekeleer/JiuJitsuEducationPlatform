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
    public class OverzichtControllerTest {

        private readonly OverzichtController _overzichtController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IAanwezigheidRepository> _aanwezigheidRepo;

        public OverzichtControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _aanwezigheidRepo = new Mock<IAanwezigheidRepository>();
            _overzichtController = new OverzichtController(_aanwezigheidRepo.Object) {
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
