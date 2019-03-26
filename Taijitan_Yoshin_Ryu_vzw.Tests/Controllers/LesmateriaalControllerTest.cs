using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Taijitan_Yoshin_Ryu_vzw.Controllers;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Tests.Data;
using Xunit;

namespace taijitan_yoshin_ryu_vzw.tests.controllers
{
    public class lesmateriaalcontrollertest
    {
        private readonly LesmateriaalController _lesmateriaalController;
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly Mock<IGraadRepository> _graadRepo;
        private readonly Mock<ICommentaarRepository> _commentaarRepo;

        public lesmateriaalcontrollertest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _graadRepo = new Mock<IGraadRepository>();
            _commentaarRepo = new Mock<ICommentaarRepository>();
            _lesmateriaalController = new LesmateriaalController(_graadRepo.Object, _commentaarRepo.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }

        #region index
        [Fact]
        public void index_geefviewmodelterug()
        {
        }

        //[fact]
        //public void index_trowsnotfound() {
        //    _graadrepo.setup(g => g.getall()).returns((graad)null);
        //    iactionresult action = _lesmateriaalcontroller.index(_gebruiker);
        //    assert.istype<notfoundresult>(action);
        //}
        #endregion
        #region ThemaView

        #endregion
        #region LesmateriaalView

        #endregion
        #region LesmateriaalViewHead

        #endregion
        #region NieuweCommentaren

        #endregion
    }
}

