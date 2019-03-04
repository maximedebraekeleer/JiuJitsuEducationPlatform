using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Models;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class HomeController : Controller
    {

        SignInManager<IdentityUser> signin;

        public HomeController(Microsoft.AspNetCore.Identity.SignInManager<IdentityUser> signin)
        {
            this.signin = signin;
        }
        public IActionResult Index()
        {
            
            if(signin.IsSignedIn(User))
            {
                return View();
            }
            return RedirectToAction("Login", "Identity/Account");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
