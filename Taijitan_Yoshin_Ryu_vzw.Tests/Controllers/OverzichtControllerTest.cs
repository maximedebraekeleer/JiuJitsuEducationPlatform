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
        [Fact]
        public void Index_GeefViewModelTerug() {
            _aanwezigheidRepo.Setup(a => a.GetAll()).Returns(_dummyContext.Aanwezigheden);
            IActionResult actionResult = _overzichtController.Index();
            IList<Aanwezigheid> aanwezigheden = (actionResult as ViewResult)?.Model as IList<Aanwezigheid>;

            Assert.Equal(2, aanwezigheden.Count);
            Assert.Equal("Lid0003", aanwezigheden?[0].Lid.Username);
            Assert.Equal("Lid0004", aanwezigheden?[1].Lid.Username);
        }


        //[Fact]
        //public void Index_TrowsNotFound() {
        //    _aanwezigheidRepo.Setup(a => a.GetAll()).Returns((Aanwezigheid)null);
        //    IActionResult action = _overzichtController.Index();
        //    Assert.IsType<NotFoundResult>(action);
        //}

        #endregion
    }
}
