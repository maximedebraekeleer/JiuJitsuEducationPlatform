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

        public IActionResult Index(int formuleId = -1, string naam = "", bool datumFilter = true, DateTime datum = new DateTime())
        {
            List<Aanwezigheid> aanwezigheden = _aanwezigheden.GetAll().ToList();
            aanwezigheden = filterOpFormules(aanwezigheden, formuleId);
            aanwezigheden = filterOpNaam(aanwezigheden, naam);
            aanwezigheden = filterOpDatum(aanwezigheden, datumFilter, datum);

            ViewData["Formules"] = GetFormulesAsSelectList(formuleId);

            return View(new AanwezigenViewModel(aanwezigheden));
        }

        private SelectList GetFormulesAsSelectList(int selected = -1)
        {
            return new SelectList(_formules.getAll().OrderBy(f => f.FormuleNaam).ToList(), 
                nameof(Formule.Id), nameof(Formule.FormuleNaam), selected);
        }

        private List<Aanwezigheid> filterOpFormules(List<Aanwezigheid> aanwezigheden, int formuleId)
        {
            if (formuleId == -1)
                return aanwezigheden;
            else
                return aanwezigheden.Where(a => a.Lid.bevatFormule(formuleId)).ToList();
        }

        private List<Aanwezigheid> filterOpNaam(List<Aanwezigheid> aanwezigheden, string naam)
        {
            if (naam == "" || naam == null)
                return aanwezigheden;
            else
                return aanwezigheden.Where(a => (a.Lid.Voornaam + a.Lid.Naam).ToLower().Contains(naam.ToLower())).ToList();
        }

        private List<Aanwezigheid> filterOpDatum(List<Aanwezigheid> aanwezigheden, bool datumFilter, DateTime datum)
        {
            if (datumFilter)
                return aanwezigheden;
            else
                return aanwezigheden.Where(a => a.Sessie.bevatDatumEnTijd(datum)).ToList();
        }

    }
}