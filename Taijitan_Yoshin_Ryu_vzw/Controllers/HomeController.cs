using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Taijitan_Yoshin_Ryu_vzw.Models;

namespace Taijitan_Yoshin_Ryu_vzw.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> signin;

        public HomeController(SignInManager<IdentityUser> signin)
        {
            this.signin = signin;
        }
        public IActionResult Index()
        {
            if(signin.IsSignedIn(User))
            {
                return RedirectToAction(nameof(Index), "Gebruiker");
            }
            //return RedirectToAction("Login", "Identity/Account");
            return LocalRedirect("/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
