using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
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
            Trainingsmoment trainingsMoment = GeefTrainingsmomenten().FirstOrDefault();
                      
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
            Aanwezigheid aanwezigheid = _aanwezigheden.GetbyLid(lid).Where(a => a.Sessie == HuidigeSessie).FirstOrDefault();
            if (aanwezigheid != null) {
                //TempData["error"] = $"{lid.Voornaam}{lid.Naam} is reeds geregistreerd als aanwezig.";                
                _aanwezigheden.Remove(aanwezigheid);
                _aanwezigheden.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            _aanwezigheden.Add(new Aanwezigheid(lid, HuidigeSessie));
            _aanwezigheden.SaveChanges();
            //TempData["message"] = $"{lid.Voornaam}{lid.Naam} is succesvol geregistreerd als aanwezig.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RegistreerAanwezigheidNietInLijst()
        {
            return View();
        }
        
        public IActionResult Cancel(string password)
        {
            //var result = await _signing.PasswordSignInAsync(User.Identity.Name, password);
            GeefHuidigeSessie();
            _sessies.Remove(HuidigeSessie);
            _sessies.SaveChanges();
            TempData["error"] = $"De sessie is geannuleerd.";
            return RedirectToAction(nameof(Lesgever), "Gebruiker");
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

        private IEnumerable<Trainingsmoment> GeefTrainingsmomenten()
        {
            IEnumerable<Trainingsmoment> trainingsmomenten;
            //Donderdag wordt gekozen op localhost, anders de huidige dag
            if (HttpContext.Request.Host.Host.ToLower().Equals("localhost"))
            {
                trainingsmomenten = _trainingsmomenten.getByDagNummer(4/*Donderdag*/);
            }
            else {
                trainingsmomenten = _trainingsmomenten.getByDagNummer((int)DateTime.Now.DayOfWeek);
            }
            
            return trainingsmomenten;
        }
    }
}