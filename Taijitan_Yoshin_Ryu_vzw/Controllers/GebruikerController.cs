using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    //[ServiceFilter(typeof(GebruikerFilter))]
    public class GebruikerController : Controller
    {
            //private readonly IAuthorizationService authorizationService;
        //private readonly IGebruikerRepository _gebruikerRepository;

            //public GebruikerController(IAuthorizationService authorizationService) {
            //    this.authorizationService = authorizationService;
            //}

        //de variable en de contstructor moeten vervangen worden door deze

        //public GebruikerController(IGebruikerRepository gebruikerRepository) {
        //    _gebruikerRepository = gebruikerRepository;
        //}

        public async Task<IActionResult> Index()
        {
            //var authorizationResult_lid = await authorizationService.AuthorizeAsync(User, "Lid");
            //var authorizationResult_lesgever = await authorizationService.AuthorizeAsync(User, "Lesgever");

            //if (authorizationResult_lid.Succeeded) {
            //    return View("Lid");
            //}
            //else if (authorizationResult_lesgever.Succeeded) {
            //    return View("Lesgever");
            //}
            //else {
            //    return View("Error");
            //}
            return View("Lesgever");
        }

        [Authorize(Policy = "Lid")]
        public IActionResult Lid() {
            return View();
        }

        [Authorize(Policy = "Lesgever")]
        public IActionResult Lesgever() {
            return View();
        }
    }
}