using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly ICommentaarRepository _commentaren;

        public GebruikerController(IGebruikerRepository gebruikerRepository, ICommentaarRepository commentaren)
        {
            _gebruikerRepository = gebruikerRepository;
            _commentaren = commentaren;
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker)
        {
            if(gebruiker is Lid)
                return View("Lid");

            else if (gebruiker is Lesgever)
                return View("Lesgever", _commentaren.GetNew().Count());

            else
                return View("Error");
        }

        [Authorize(Policy = "Lid")]
        public IActionResult Lid() {
            return View();
        }

        [Authorize(Policy = "Lesgever")]
        public IActionResult Lesgever() {
            return View(_commentaren.GetNew().Count());
        }
    }
}