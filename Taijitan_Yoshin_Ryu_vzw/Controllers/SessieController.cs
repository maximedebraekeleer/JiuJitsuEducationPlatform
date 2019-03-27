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

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    [Authorize(Policy = "Lesgever")]
    [ServiceFilter(typeof(GebruikerFilter))]
    [ServiceFilter(typeof(SessieFilter))]
    public class SessieController : Controller
    {
        private readonly IFormuleRepository _formules;
        private readonly ITrainingsmomentRepository _trainingsmomenten;
        private readonly IGebruikerRepository _gebruikers;
        private readonly IAanwezigheidRepository _aanwezigheden;
        private readonly ISessieRepository _sessies;
        private readonly IGraadRepository _graden;

        public SessieController(IFormuleRepository formules, ITrainingsmomentRepository trainingsmomenten, IGebruikerRepository gebruikers, IAanwezigheidRepository aanwezigheden, ISessieRepository sessieRepository, IGraadRepository graden)
        {
            _formules = formules;
            _trainingsmomenten = trainingsmomenten;
            _gebruikers = gebruikers;
            _aanwezigheden = aanwezigheden;
            _sessies = sessieRepository;
            _graden = graden;
        }

        public IActionResult Index(Gebruiker gebruiker, Sessie huidigeSessie)
        {
            Trainingsmoment trainingsMoment;
            try
            {
                trainingsMoment = GeefTrainingsmoment();
            }
            catch (Exception e)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }

            if (trainingsMoment == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }

            DateTime datumBeginUur = trainingsMoment.geefDatumBeginUur();
            DateTime datumEindUur = trainingsMoment.geefDatumEindUur();
            Lesgever huidigeLesgever = (Lesgever)gebruiker;
            
            if (huidigeSessie == null)
            {
                huidigeSessie = new Sessie(datumBeginUur, datumEindUur, huidigeLesgever);
                _sessies.Add(huidigeSessie);
                _sessies.SaveChanges();
            }
            
            //Formules ophalen die deze trainingsmomenten bevatten
            List<Formule> formulesFiltered = _formules.getAll().Where(f => f.bevatTrainingsmoment(trainingsMoment)).ToList();

            //Leden uit deze modules halen
            List<Lid> ledenOpdag = new List<Lid>();

            foreach (Formule f in formulesFiltered)
            {
                ledenOpdag.AddRange(f.Leden);
            }
            ledenOpdag.ToList();

            List<Lid> aanwezigeLeden = huidigeSessie.GeefAanwezigeLeden();
            List<Lid> andereLeden = huidigeSessie.GeefExtraAanwezigeLeden();

            //Gefilterde leden teruggeven
            return View(new SessieViewModel(ledenOpdag, huidigeSessie, aanwezigeLeden, andereLeden));
        }

        public IActionResult RegistreerAanwezigheid(Sessie huidigeSessie, string username)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            Lid lid = (Lid)_gebruikers.GetByUserName(username);
            if(lid == null)
            {
                TempData["error"] = $"Kon geen gebruiker vinden met de meegegeven username";
                return RedirectToAction(nameof(Index));
            }
            Aanwezigheid aanwezigheid = _aanwezigheden.GetbyLid(lid).Where(a => a.Sessie == huidigeSessie).FirstOrDefault();
            if (aanwezigheid != null)
            {          
                _aanwezigheden.Remove(aanwezigheid);
                _aanwezigheden.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            aanwezigheid = new Aanwezigheid(lid, huidigeSessie, true);
            huidigeSessie.VoegAanwezigheidToe(lid, true);
            _sessies.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RegistreerAanwezigNietInLijst(Sessie huidigeSessie)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            Trainingsmoment trainingsMoment = GeefTrainingsmoment();

            //Formules ophalen die deze trainingsmomenten niet bevatten
            IList<Formule> formulesFiltered = _formules.getAll().Where(f => !f.bevatTrainingsmoment(trainingsMoment)).ToList();
            List<Lid> ledenNietOpDag = new List<Lid>();
            foreach (Formule f in formulesFiltered)
            {
                ledenNietOpDag.AddRange(f.Leden);
            }

            ledenNietOpDag.ToList();
            List<Lid> extraAanwezigheden = huidigeSessie.GeefExtraAanwezigeLeden();

            return View(new andereLedenViewModel(ledenNietOpDag, extraAanwezigheden));
        }

        public IActionResult RegistreerAanwezigGast(Sessie huidigeSessie)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            //Gastviewmodel wordt gebruikt
            return View();
        }
        [HttpPost]
        public IActionResult RegistreerAanwezigGast(Sessie huidigeSessie, GastViewModel gvm)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Lid gast = new Lid(
                gvm.Username,
                gvm.Email,
                gvm.Naam,
                gvm.Voornaam,
                gvm.Geslacht,
                gvm.GeboorteDatum,
                gvm.GeboorteLand,
                gvm.GeboorteStad,
                gvm.Straat,
                gvm.HuisNummer,
                gvm.Gemeente,
                gvm.Postcode,
                gvm.TelefoonNummer,
                gvm.GsmNummer,
                gvm.RijksregisterNummer,
                DateTime.Today,
                gvm.EmailOuders,
                false,
                false,
                _formules.getAll().Where(f => f.FormuleNaam == "gast").FirstOrDefault(),
                _graden.GetGraadWithId(1)
                    );
                _gebruikers.Add(gast);
                _gebruikers.SaveChanges();

                huidigeSessie.VoegAanwezigheidToe(gast, true);
                _sessies.SaveChanges();
            }
            catch (Exception e)
            {
                string[] error = e.Message.Split('/');
                ModelState.AddModelError(error[0], error[1]);
                return View(gvm);
            }

                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Cancel(Sessie huidigeSessie)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            _sessies.Remove(huidigeSessie);
            _sessies.SaveChanges();
            TempData["error"] = $"De sessie is geannuleerd.";
            return RedirectToAction(nameof(Lesgever), "Gebruiker");
        }

        [HttpPost]
        public void AanwezigenToevoegen(Sessie huidigeSessie, string aanwezigen)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            else
            {
                String[] aanwezig = JsonConvert.DeserializeObject<string[]>(aanwezigen);
                huidigeSessie.ClearAanwezigheden();
                Lid lid;
                bool isExtra;
                List<Formule> formulesMetLes = _formules.getAll().Where(f => f.bevatTrainingsmoment(GeefTrainingsmoment())).ToList();
                foreach (var a in aanwezig)
                {
                    lid = (Lid)_gebruikers.GetByUserName(a);
                    isExtra = lid.IsExtra(formulesMetLes);
                    huidigeSessie.VoegAanwezigheidToe(lid, isExtra);
                }
                _sessies.SaveChanges();
            }
        }

        public IActionResult SessieAanwezigen(Sessie huidigeSessie)
        {
            if (huidigeSessie == null)
            {
                TempData["error"] = $"Er zijn vandaag geen sessies";
                return RedirectToAction(nameof(Lesgever), "Gebruiker");
            }
            List<Aanwezigheid> aanwezigheden = huidigeSessie.Aanwezigheden.ToList();
            return View(new AanwezigenViewModel(aanwezigheden));
        }

        private Trainingsmoment GeefTrainingsmoment()
        {
            return _trainingsmomenten.getByDagNummer((int)DateTime.Now.DayOfWeek).First();
        }
    }
}