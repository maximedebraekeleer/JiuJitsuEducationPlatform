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

        //Werkt niet door javascript
        public IActionResult LesmateriaalView(string Username, string ThemaNaam, int GraadId, int LesmateriaalId)
        {
            Lesmateriaal lm = _graden.GetGraadWithId(GraadId).GeefLesmateriaalMetThema(ThemaNaam).Where(l => l.Id == LesmateriaalId).FirstOrDefault();
            ViewBag.Lesmateriaal = (lm == null ? null : lm);
            ViewBag.CommentaarLid = (lm == null ? null : lm.GetCommentaarLid());
            _loggings.AddLogging(new Logging((Lid)_gebruikers.GetByUserName(Username), ViewBag.Lesmateriaal));
            _loggings.SaveChanges();
            return PartialView("~/Views/Lesmateriaal/Lesmateriaal.cshtml");
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker, string username)
        {
            if(gebruiker is Lesgever)
            {
                Gebruiker huidigLid = _gebruikers.GetByUserName(username);
                return View(new LesmateriaalViewModel(huidigLid, _graden.GetAll().ToList()));
            }
            else
            {
                return View(new LesmateriaalViewModel(gebruiker, _graden.GetAll().ToList()));
            }
        }

        public IActionResult NieuweCommentaren()
        {
            List<Commentaar> commentaren = _commentaren.GetNew().ToList();
            commentaren.ForEach(c => c.markeerGezien());
            _commentaren.SaveChanges();
            return View(new CommentaarViewModel(commentaren));
        }

        public void VoegCommentaarToe(string Username, string Inhoud, string ThemaNaam, int GraadId, int LesmateriaalId)
        {
            _commentaren.VoegCommentaarToe(
                (Lid)_gebruikers.GetByUserName(Username),
                Inhoud,
                _graden.GetGraadWithId(GraadId).GeefLesmateriaalMetThema(ThemaNaam).Where(l => l.Id == LesmateriaalId).First()
                );
            _commentaren.SaveChanges();
        }

    }
}