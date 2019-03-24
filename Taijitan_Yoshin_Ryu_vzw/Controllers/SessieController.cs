using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Taijitan_Yoshin_Ryu_vzw.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers {
    [ServiceFilter(typeof(GebruikerFilter))]
    [Authorize(Policy = "Lesgever")]
    public class SessieController : Controller {

        private readonly IFormuleRepository _formules;
        private readonly ITrainingsmomentRepository _trainingsmomenten;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IAanwezigheidRepository _aanwezigheden;
        private readonly ISessieRepository _sessies;

        public SessieController(IFormuleRepository formules, ITrainingsmomentRepository trainingsmomenten, IGebruikerRepository gebruikers, IAanwezigheidRepository aanwezigheden, ISessieRepository sessieRepository)
        {
            _formules = formules;
            _trainingsmomenten = trainingsmomenten;
            _gebruikers = gebruikers;
            _aanwezigheden = aanwezigheden;
            _sessies = sessieRepository;
        }
        public IActionResult Index() {

            Trainingsmoment trainingsMoment = GeefTrainingsmoment();
                      
            if (trainingsMoment == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            Sessie HuidigeSessie = MaakHuidigeSessie(trainingsMoment);

            //Formules ophalen die deze trainingsmomenten bevatten
            IList<Formule> formulesFiltered = _formules.getAll().Where(f => f.bevatTrainingsmoment(trainingsMoment)).ToList();

            //Leden uit deze modules halen
            List<Lid> ledenOpdag = new List<Lid>();

            foreach (Formule f in formulesFiltered) {
                ledenOpdag.AddRange(f.Leden);
            }
            ledenOpdag.ToList();

            List<Lid> aanwezigeLeden = _aanwezigheden.GetbySessie(HuidigeSessie).Select(l => l.Lid).ToList();
            List<Lid> andereLeden =  _aanwezigheden.GetbySessie(HuidigeSessie).Where(a => a.IsExtra).Select(l => l.Lid).ToList();

            //Gefilterde leden teruggeven
            return View(new SessieViewModel(ledenOpdag, HuidigeSessie, aanwezigeLeden, andereLeden));
        }

        public IActionResult RegistreerAanwezigheid(string username) {
            Sessie HuidigeSessie = GeefHuidigeSessie();

            Lid lid = (Lid)_gebruikers.GetByUserName(username);
            Aanwezigheid aanwezigheid = _aanwezigheden.GetbyLid(lid).Where(a => a.Sessie == HuidigeSessie).FirstOrDefault();
            if (aanwezigheid != null) {
                //TempData["error"] = $"{lid.Voornaam}{lid.Naam} is reeds geregistreerd als aanwezig.";                
                _aanwezigheden.Remove(aanwezigheid);
                _aanwezigheden.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            _aanwezigheden.Add(new Aanwezigheid(lid, HuidigeSessie, true));
            _aanwezigheden.SaveChanges();
            //TempData["message"] = $"{lid.Voornaam}{lid.Naam} is succesvol geregistreerd als aanwezig.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RegistreerAanwezigNietInLijst()
        {
            Trainingsmoment trainingsMoment = GeefTrainingsmoment();
            if (trainingsMoment == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            //Formules ophalen die deze trainingsmomenten niet bevatten
            IList<Formule> formulesFiltered = _formules.getAll().Where(f => !f.bevatTrainingsmoment(trainingsMoment)).ToList();
            List<Lid> ledenNietOpDag = new List<Lid>();
            foreach (Formule f in formulesFiltered)
            {
                ledenNietOpDag.AddRange(f.Leden);
            }

            ledenNietOpDag.ToList();
            List<Lid> extraAanwezigheden = _aanwezigheden.GetbySessie(GeefHuidigeSessie()).Where(a => a.IsExtra).Select(l => l.Lid).ToList();
            return View(new andereLedenViewModel(ledenNietOpDag, extraAanwezigheden));
        }
        public IActionResult RegistreerAanwezigGast()
        {
            //Gastviewmodel wordt gebruikt
            return View();
        }
        [HttpPost]
        public IActionResult RegistreerAanwezigGast(GastViewModel gvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }                              
                    Lid gast = new Lid(gvm.Username,
                        gvm.Email,
                       gvm.Naam,
                       gvm.Voornaam,
                       'm',
                       gvm.GeboorteDatum,                       
                       gvm.GeboorteLand,
                        gvm.GeboorteStad,
                        gvm.Straat,
                        gvm.HuisNummer,
                        gvm.Gemeente,
                        gvm.Postcode,
                        "+3291112211",
                        "0470055701",
                        "96032732925",
                        DateTime.Today,
                        gvm.EmailOuders,
                        false,
                        false,
                        _formules.getAll().Where(f => f.FormuleNaam == "gast").FirstOrDefault(),    
                        new Graad(0, "gast")
                        );
                   
                    _gebruikers.Add(gast);
                    _gebruikers.SaveChanges();

                    _aanwezigheden.Add(new Aanwezigheid(gast, GeefHuidigeSessie(), true));
                    _aanwezigheden.SaveChanges();

                    return RedirectToAction(nameof(Index));   
        }
        
        [HttpPost]
        public IActionResult Cancel()
        {         
                _sessies.Remove(GeefHuidigeSessie());
                _sessies.SaveChanges();
                TempData["error"] = $"De sessie is geannuleerd.";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");  
        }


        private Sessie MaakHuidigeSessie(Trainingsmoment trainingsmoment) {
            DateTime datumBeginUur = trainingsmoment.geefDatumBeginUur();
            DateTime datumEindUur = trainingsmoment.geefDatumEindUur();
            Lesgever lesgever = (Lesgever)_gebruikers.GetByUserName(User.Identity.Name);

            if (!_sessies.GetAll().Any(x => x.BeginDatumEnTijd == datumBeginUur)) {
                Sessie sessie = new Sessie(datumBeginUur, datumEindUur, lesgever);
                _sessies.Add(sessie); 
                _sessies.SaveChanges();
                return sessie;
            }
            else {
                return _sessies.GetByDatumBeginUur(datumBeginUur);
            }
        }

        private Sessie GeefHuidigeSessie() {
            DateTime datumBeginUur = GeefTrainingsmoment().geefDatumBeginUur();
            return _sessies.GetByDatumBeginUur(datumBeginUur);
        }

        private Trainingsmoment GeefTrainingsmoment()
        {
            IEnumerable<Trainingsmoment> trainingsmomenten;
            //Donderdag wordt gekozen op localhost, anders de huidige dag
            if (HttpContext.Request.Host.Host.ToLower().Equals("localhost"))
            {
                return _trainingsmomenten.getByDagNummer(4/*Donderdag*/).First();
            }
            else {
                return _trainingsmomenten.getByDagNummer((int)DateTime.Now.DayOfWeek).First();
            }            
        }
        [HttpPost]
        public void AanwezigenToevoegen(string aanwezigen)
        {
            String[] aanwezig = JsonConvert.DeserializeObject<string[]>(aanwezigen);
            Sessie huidigesessie = GeefHuidigeSessie();
            foreach (var a in aanwezig)
            {
                huidigesessie.voegAanwezigheidToe((Lid)_gebruikers.GetByUserName(a));
            }
            _sessies.SaveChanges();                        
        }
        public IActionResult SessieAanwezigen() {
            List<Lid> aanwezigeLeden = _aanwezigheden.GetbySessie(GeefHuidigeSessie()).Select(l => l.Lid).ToList();
            return View(new AanwezigenViewModel(aanwezigeLeden));            
        }
    }
}