//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Taijitan_Yoshin_Ryu_vzw.Filters;
//using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
//using Taijitan_Yoshin_Ryu_vzw.Models.LidViewModels;

//namespace Taijitan_Yoshin_Ryu_vzw.Controllers {
//    [ServiceFilter(typeof(LidFilter))]
//    public class LidController : Controller {
//        private readonly ILidRepository _lidRepository;

//        public LidController(ILidRepository lidRepository) {
//            _lidRepository = lidRepository;
//        }

//        public IActionResult Index(Lid lid) {
//            TempData["Lid"] = lid.Voornaam + " " + lid.Naam;
//            return View(lid);
//        }

//        [HttpGet]
//        public IActionResult Edit(string email) {
//            Lid lid = _lidRepository.GetByEmail(email);
//            TempData["Lid"] = lid.Voornaam + " " + lid.Naam;
//            if (lid == null)
//                return NotFound();
//            return View(new EditViewModel(lid));
//        }

//        [HttpPost]
//        public IActionResult Edit(EditViewModel levm, string email) { //levm = lidEditViewModel (verkorte versie)
//            if (ModelState.IsValid) {
//                Lid lid = null;

//                try {
//                    lid = _lidRepository.GetByEmail(email);

//                    //map LidViewModel to Lid
//                    lid.Naam = levm.Naam;
//                    lid.Voornaam = levm.Voornaam;
//                    lid.GeboorteDatum = levm.GeboorteDatum;
//                    lid.Straat = levm.Straat;
//                    lid.Gemeente = levm.Gemeente;
//                    lid.HuisNummer = levm.HuisNummer;
//                    lid.Postcode = levm.PostCode;
//                    lid.TelefoonNummer = levm.TelefoonNummer;
//                    lid.Email = levm.Email;

//                    _lidRepository.SaveChanges();
//                    TempData["message"] = $"Je hebt je gegevens succesvol geupdated {lid.Naam}!";
//                }
//                catch (Exception e) {
//                    ModelState.AddModelError("", e.Message);
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(nameof(Edit), levm);
//        }
//    }
//}