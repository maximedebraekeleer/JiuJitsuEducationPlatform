using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.LesmateriaalViewModels;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class LesmateriaalController : Controller
    {
        private readonly IGraadRepository _graden;
        private readonly ICommentaarRepository _commentaren;
        private readonly ILoggingRepository _loggings;
        private readonly IGebruikerRepository _gebruikers;

        public LesmateriaalController(IGraadRepository graden, ICommentaarRepository commentaren, ILoggingRepository loggings, IGebruikerRepository gebruikers)
        {
            _graden = graden;
            _commentaren = commentaren;
            _loggings = loggings;
            _gebruikers = gebruikers;
        }

        public IActionResult ThemaView(int GraadId)
        {
            ViewBag.GeselecteerdeGraad = _graden.GetGraadWithId(GraadId);
            return PartialView("~/Views/Lesmateriaal/Thema.cshtml");
        }

        public IActionResult LesmateriaalViewHead(string ThemaNaam, int GraadId)
        {
            ViewBag.ThemaNaam = ThemaNaam;
            ViewBag.Lesmaterialen = _graden.GetGraadWithId(GraadId).GeefLesmateriaalMetThema(ThemaNaam);
            return PartialView("~/Views/Lesmateriaal/LesmateriaalHead.cshtml");
        }

        public IActionResult LesmateriaalView(string ThemaNaam, int GraadId, int LesmateriaalId)
        {
            ViewBag.Lesmateriaal = _graden.GetGraadWithId(GraadId).GeefLesmateriaalMetThema(ThemaNaam).Where(l => l.Id == LesmateriaalId).First();
            _loggings.AddLogging(new Logging(new Lid(), new Lesmateriaal()));
            return PartialView("~/Views/Lesmateriaal/Lesmateriaal.cshtml");
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker, string username)
        {
            return View(new LesmateriaalViewModel(gebruiker, _graden.GetAll().ToList()));
        }

        public IActionResult NieuweCommentaren()
        {
            List<Commentaar> commentaren = _commentaren.GetNew().ToList();
            commentaren.ForEach(c => c.markeerGezien());
            _commentaren.SaveChanges();
            return View(new CommentaarViewModel(commentaren));
        }

    }
}