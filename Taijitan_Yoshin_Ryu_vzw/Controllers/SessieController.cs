using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModel;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class SessieController : Controller
    {
        IEnumerable<Formule> _formules;

        public SessieController()
        {

        }
        public IActionResult Index()
        {
            bepaalFormule();
            return View(new StartSessieViewModel());
        }

        public IActionResult Sessie()
        {
            return View();
        }

        private Formule bepaalFormule()
        {
            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 0 : return new Formule(); //zondag
                case 1 : return new Formule(); //maandag
                case 2 : return new Formule(); //dinsdag formule3+4+6
                case 3 : return new Formule(); //woensdag formule1+5
                case 4 : return new Formule(); //donderdag formule6
                case 5 : return new Formule(); //vrijdag
                case 6 : return new Formule(); //zaterdag formule2+4+5

            }

            return null;
        }
    }
}