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
            //Welk trainingsmomenten
            Trainingsmoment trainingsMoment = _trainingsmomenten.getByDagNummer((int)DateTime.Today.DayOfWeek).FirstOrDefault();
            MaakHuidigeSessie(trainingsMoment);

            //Formules ophalen die deze trainingsmomenten bevatten
            IList<Formule> formulesFiltered = _formules.getAll().Where(f => f.bevatTrainingsmoment(trainingsMoment)).ToList();

            //Leden uit deze modules halen
            List<Lid> ledenOpdag = new List<Lid>();

            foreach (Formule f in formulesFiltered) {
                ledenOpdag.AddRange(f.Leden);
            }
            ledenOpdag.ToList();

            //Gefilterde leden teruggeven
            return View(new SessieViewModel(ledenOpdag, HuidigeSessie));
        }

        public void RegistreerAanwezigheid(string username) {
            GeefHuidigeSessie();
            Lid lid = (Lid)_gebruikers.GetByUserName(username);

            if (HuidigeSessie.isLidAanwezig(lid))
            {
                HuidigeSessie.verwijderAanwezigheid(lid);
            }else
                HuidigeSessie.voegAanwezigheidToe(lid);
                

            _aanwezigheden.SaveChanges();
            
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

        private IEnumerable<Trainingsmoment> GeefTrainingsmomenten() {
            IEnumerable<Trainingsmoment> trainingsmomenten = _trainingsmomenten.getByDagNummer((int)DateTime.Now.DayOfWeek);
            return trainingsmomenten;
        
    }
}