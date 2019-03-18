using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers {
    public class SessieController : Controller {

        private readonly IFormuleRepository _formules;
        private readonly ITrainingsmomentRepository _trainingsmomenten;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IAanwezigheidRepository _aanwezigheden;
        private readonly ISessieRepository _sessies;
        private Sessie HuidigeSessie;

        public SessieController(IFormuleRepository formules, ITrainingsmomentRepository trainingsmomenten, IGebruikerRepository gebruikers, IAanwezigheidRepository aanwezigheden, ISessieRepository sessieRepository) {
            _formules = formules;
            _trainingsmomenten = trainingsmomenten;
            _gebruikers = gebruikers;
            _aanwezigheden = aanwezigheden;
            _sessies = sessieRepository;
        }
        public IActionResult Index() {
            IEnumerable<Trainingsmoment> trainingsmomenten = GeefTrainingsmomenten();
            //return View(GeefLeden(GeefFormules(trainingsmomenten)));

            //WERENDE VERSIE
            Trainingsmoment trainingsMoment;            

            //Donderdag wordt gekozen op localhost
            if (HttpContext.Request.Host.Host.ToLower().Equals("localhost")) {
                 trainingsMoment = _trainingsmomenten.getByDagNummer(4/*Donderdag*/).FirstOrDefault();
            }
            //Welk trainingsmomenten
            else
            {
                trainingsMoment = _trainingsmomenten.getByDagNummer((int)DateTime.Today.DayOfWeek).FirstOrDefault();
            }            
            if (trainingsMoment == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            MaakHuidigeSessie(trainingsMoment);

            //Formules ophalen die deze trainingsmomenten bevatten
            IList<Formule> formulesFiltered = _formules.getAll().Where(f => f.bevatTrainingsmoment(trainingsMoment)).ToList();

            //Leden uit deze modules halen
            List<Lid> ledenOpdag = new List<Lid>();

            foreach (Formule f in formulesFiltered) {
                ledenOpdag.AddRange(f.Leden);
            }
            ledenOpdag.ToList();

            List<Lid> aanwezigeLeden = _aanwezigheden.GetbySessie(HuidigeSessie).Select(l => l.Lid).ToList();

            //Gefilterde leden teruggeven
            return View(new SessieViewModel(ledenOpdag, HuidigeSessie, aanwezigeLeden));
        }

        public IActionResult RegistreerAanwezigheid(string username) {
            GeefHuidigeSessie();

            Lid lid = (Lid)_gebruikers.GetByUserName(username);
            if (_aanwezigheden.GetbyLid(lid).Any(a => a.Sessie == HuidigeSessie)) {
                //TempData["error"] = $"{lid.Voornaam}{lid.Naam} is reeds geregistreerd als aanwezig.";
                return RedirectToAction(nameof(Index));
            }
            _aanwezigheden.Add(new Aanwezigheid(lid, HuidigeSessie));
            _aanwezigheden.SaveChanges();
            //TempData["message"] = $"{lid.Voornaam}{lid.Naam} is succesvol geregistreerd als aanwezig.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AanwezigLidNietInLijst()
        {
            return View();
        }
        public IActionResult AanwezigGast()
        {
            return View();
        }


        private void MaakHuidigeSessie(Trainingsmoment trainingsmoment) {
            DateTime datumBeginUur = trainingsmoment.geefDatumBeginUur();
            DateTime datumEindUur = trainingsmoment.geefDatumEindUur();
            Lesgever sensei = (Lesgever)_gebruikers.GetByUserName(User.Identity.Name);

            if (!_sessies.GetAll().Any(x => x.BeginDatumEnTijd == datumBeginUur)) {
                HuidigeSessie = new Sessie(datumBeginUur, datumEindUur, sensei);
                _sessies.Add(HuidigeSessie);
                _sessies.SaveChanges();
            }
            else {
                HuidigeSessie = _sessies.GetByDatumBeginUur(datumBeginUur);
            }
        }

        private void GeefHuidigeSessie() {
            IEnumerable<Trainingsmoment> trainingsmomenten = GeefTrainingsmomenten();
            DateTime datumBeginUur = trainingsmomenten.FirstOrDefault().geefDatumBeginUur();
            HuidigeSessie = _sessies.GetByDatumBeginUur(datumBeginUur);
        }

        //private List<Lid> GeefLeden(List<Formule> formules)
        //{
        //    List<Lid> leden = new List<Lid>();
        //    formules.ForEach(f => leden.AddRange(_gebruikers.getLedenByFormule(f)));
        //    return leden;
        //}

        //private List<Formule> GeefFormules(IEnumerable<Trainingsmoment> trainingsmomenten)
        //{
        //    List<Formule> formules2 = _formules.getByTrainingsmoment(trainingsmomenten.FirstOrDefault()).ToList();
        //    List<Formule> formules = _formules.getAll().ToList();
        //    return formules;
        //}

        private IEnumerable<Trainingsmoment> GeefTrainingsmomenten()
        {
            IEnumerable<Trainingsmoment> trainingsmomenten = _trainingsmomenten.getByDagNummer((int)DateTime.Now.DayOfWeek);
            return trainingsmomenten;
        }
    }
}