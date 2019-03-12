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

        public SessieController(IFormuleRepository formules, ITrainingsdagRepository trainingsdagen, IGebruikerRepository gebruikers)
        {
            _formules = formules;
            _trainingsdagen = trainingsdagen;
            _gebruikers = gebruikers;
        }
        public IActionResult Index()
        {
            return View(GeefLeden(GeefFormules(GeefTrainingsdagen())));            
        }

        private List<Lid> GeefLeden(List<Formule> formules)
        {
            List<Lid> leden = new List<Lid>();
            formules.ForEach(f => leden.AddRange(_gebruikers.getLedenByFormule(f)));
            return leden;
        }

        private List<Formule> GeefFormules(IEnumerable<Trainingsdag> trainingsdagen)
        {
            //List<Formule> formulesOpVandaag = _formules.getByTrainingsdag(trainingsdagen.FirstOrDefault()).ToList();
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