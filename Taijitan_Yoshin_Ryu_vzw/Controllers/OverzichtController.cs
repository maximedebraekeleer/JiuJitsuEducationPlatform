using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class OverzichtController : Controller
    {
        private readonly IAanwezigheidRepository _aanwezigheden;
        public OverzichtController(IAanwezigheidRepository aanwezigheden)
        {
            _aanwezigheden = aanwezigheden;
        }
        public IActionResult Index()
        {
            List<Aanwezigheid> aanwezigheden = _aanwezigheden.GetAll().ToList();
            return View(aanwezigheden);
        }
    }
}