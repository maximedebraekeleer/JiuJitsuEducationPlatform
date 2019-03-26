using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class OverzichtController : Controller
    {
        private readonly IAanwezigheidRepository _aanwezigheden;
        private readonly IFormuleRepository _formules;
        public OverzichtController(IAanwezigheidRepository aanwezigheden, IFormuleRepository formules)
        {
            _aanwezigheden = aanwezigheden;
            _formules = formules;

        }
        public IActionResult Index(int formuleId = -1)
        {
            List<Aanwezigheid> aanwezigheden;
            if (formuleId == -1)
            {
                aanwezigheden = _aanwezigheden.GetAll().ToList();
            }
            else
            {
                aanwezigheden = _aanwezigheden.GetAll().Where(a => a.Lid.Formule.Id == formuleId).ToList();
            }

            ViewData["Formules"] = GetFormulesAsSelectList(formuleId);
            return View(new AanwezigenViewModel(aanwezigheden));
        }

        private SelectList GetFormulesAsSelectList(int selected = -1)
        {
            return new SelectList(_formules.getAll().OrderBy(f => f.FormuleNaam).ToList(), 
                nameof(Formule.Id), nameof(Formule.FormuleNaam), selected);
        }  
    }
}