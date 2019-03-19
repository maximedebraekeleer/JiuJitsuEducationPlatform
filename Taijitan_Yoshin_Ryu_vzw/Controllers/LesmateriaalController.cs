using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class LesmateriaalController : Controller
    {
        private readonly IGraadRepository _graden;

        public LesmateriaalController(IGraadRepository graden)
        {
            _graden = graden;
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        public IActionResult Index(Gebruiker gebruiker)
        {
            return View(new LesmateriaalViewModel(gebruiker, _graden.GetAll().ToList()));
        }
    }
}