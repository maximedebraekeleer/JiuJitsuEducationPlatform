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

        private readonly IFormuleRepository _formules;
        private readonly ITrainingsdagRepository _trainingsdagen;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IAanwezigheidRepository _aanwezigheden;
        private Sessie HuidigeSessie;

        public SessieController(IFormuleRepository formules, ITrainingsdagRepository trainingsdagen, IGebruikerRepository gebruikers, IAanwezigheidRepository aanwezigheden)
        {
            _formules = formules;
            _trainingsdagen = trainingsdagen;
            _gebruikers = gebruikers;
            _aanwezigheden = aanwezigheden;
        }
        public IActionResult Index()
        {
            //new Sessie(beginDatumEnTijd, eindDatumEnTijd, lesgever);
            return View(GeefLeden(GeefFormules(GeefTrainingsdagen())));            
        }

        //public IActionResult RegistreerAanwezigheid(string username)
        //{            
        //    Lid lid = (Lid)_gebruikers.GetByUserName(username);
        //    if (_aanwezigheden.GetbyLid(lid).Any(a => a.Sessie == HuidigeSessie))
        //    {
        //        //melding dat lid al is geregistreerd
        //    }
        //    new Aanwezigheid(lid, HuidigeSessie);
        //    return View();
        //}

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