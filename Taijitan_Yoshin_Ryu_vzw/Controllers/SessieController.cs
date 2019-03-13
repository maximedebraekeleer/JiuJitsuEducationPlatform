using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModel;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class SessieController : Controller
    {

        private readonly IFormuleRepository _formules;
        private readonly ITrainingsdagRepository _trainingsdagen;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IAanwezigheidRepository _aanwezigheden;
        private readonly ISessieRepository _sessies;
        private Sessie HuidigeSessie;

        public SessieController(IFormuleRepository formules, ITrainingsdagRepository trainingsdagen, IGebruikerRepository gebruikers, IAanwezigheidRepository aanwezigheden, ISessieRepository sessieRepository)
        {
            _formules = formules;
            _trainingsdagen = trainingsdagen;
            _gebruikers = gebruikers;
            _aanwezigheden = aanwezigheden;
            _sessies = sessieRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Trainingsdag> trainingsdagen = GeefTrainingsdagen();
            MaakHuidigeSessie(trainingsdagen);
            return View(GeefLeden(GeefFormules(trainingsdagen)));
        }

        

        public IActionResult RegistreerAanwezigheid(string username)
        {
            GeefHuidigeSessie();

            Lid lid = (Lid)_gebruikers.GetByUserName(username);
            if (_aanwezigheden.GetbyLid(lid).Any(a => a.Sessie == HuidigeSessie))
            {
                TempData["error"] = $"{lid.Voornaam}{lid.Naam} is reeds geregistreerd als aanwezig.";
                return RedirectToAction(nameof(Index));
            }
            _aanwezigheden.Add(new Aanwezigheid(lid, HuidigeSessie));
            _aanwezigheden.SaveChanges();
            TempData["message"] = $"{lid.Voornaam}{lid.Naam} is succesvol geregistreerd als aanwezig.";
            return RedirectToAction(nameof(Index));
        }

        private void MaakHuidigeSessie(IEnumerable<Trainingsdag> trainingsdagen)
        {            
            DateTime datumBeginUur = trainingsdagen.FirstOrDefault().geefDatumBeginUur();
            DateTime datumEindUur = trainingsdagen.FirstOrDefault().geefDatumEindUur();
            Lesgever sensei = (Lesgever)_gebruikers.GetByUserName(User.Identity.Name);

            if (!_sessies.GetAll().Any(x => x.BeginDatumEnTijd == datumBeginUur))
            {
                HuidigeSessie = new Sessie(datumBeginUur, datumEindUur, sensei);
                _sessies.Add(HuidigeSessie);
                _sessies.SaveChanges();
            }
            else
            {
                HuidigeSessie = _sessies.GetByDatumBeginUur(datumBeginUur);

            }
        }

        private void GeefHuidigeSessie()
        {
            IEnumerable<Trainingsdag> trainingsdagen = GeefTrainingsdagen();
            DateTime datumBeginUur = trainingsdagen.FirstOrDefault().geefDatumBeginUur();
            HuidigeSessie = _sessies.GetByDatumBeginUur(datumBeginUur);
        }

        private List<Lid> GeefLeden(List<Formule> formules)
        {
            List<Lid> leden = new List<Lid>();
            formules.ForEach(f => leden.AddRange(_gebruikers.getLedenByFormule(f)));
            return leden;
        }

        private List<Formule> GeefFormules(IEnumerable<Trainingsdag> trainingsdagen)
        {
            List<Formule> formules2 = _formules.getByTrainingsdag(trainingsdagen.FirstOrDefault()).ToList();
            List<Formule> formules = _formules.getAll().ToList();
            return formules;
        }

        private IEnumerable<Trainingsdag> GeefTrainingsdagen()
        {
            IEnumerable<Trainingsdag> trainingsdagen = _trainingsdagen.getByDagNummer((int)DateTime.Now.DayOfWeek);
            return trainingsdagen;
        }
    }
}