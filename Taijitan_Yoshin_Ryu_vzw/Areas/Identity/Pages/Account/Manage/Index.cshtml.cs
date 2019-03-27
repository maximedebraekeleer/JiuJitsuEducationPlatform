using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Data;
using Taijitan_Yoshin_Ryu_vzw.Data.Repositories;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly GebruikerRepository _gebruikers;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _gebruikers = new GebruikerRepository(dbContext);
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            #region verplichteVelden
            //[Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            //[Display(Name = "Gebruikersnaam")]
            //public string Username { get; set; }

            [Display(Name = "E-mailadres")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            [EmailAddress(ErrorMessage = "Ongeldig {0}")]
            public string Email { get; set; }

            [Display(Name = "Straat")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
            public string Straat { get; set; }

            [Display(Name = "Gemeente")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
            public string Gemeente { get; set; }

            [Display(Name = "Huisnummer")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            [RegularExpression(@"^[0-9]+[a-zA-Z]*", ErrorMessage = "Ongeldig {0}")]
            public string HuisNummer { get; set; }

            [Display(Name = "Postcode")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")] 
            [RegularExpression(@"^\d{4}$", ErrorMessage = "{0} moet uit vier cijfers bestaan")]
            public string Postcode { get; set; }

            [Display(Name = "Naam")]
            [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            public string Naam { get; set; }

            [Display(Name = "Voornaam")]
            [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            public string Voornaam { get; set; }

            [Display(Name = "GSM-nummer")]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
            [RegularExpression(@"^\d{10}$|^\+\d{11}$", ErrorMessage = "Ongeldig {0}")]
            public string GsmNummer { get; set; }

            [Display(Name = "Ik wens info te ontvangen over club aangelegenheden")]
            public bool InfoClubAangelegenheden { get; set; }

            [Display(Name = "Ik wens info te ontvangen over federale aangelegenheden")]
            public bool InfoFederaleAangelegenheden { get; set; }
            #endregion

            #region nietVerplichteVelden
            [Display(Name = "Telefoonnummer")]
            [RegularExpression(@"^\d{9}$|^\+\d{10}$|^$", ErrorMessage = "Ongeldig {0}")]
            public string TelefoonNummer { get; set; } //Niet verplicht

            [Display(Name = "E-mailadres van ouders")]
            [RegularExpression(@"^$|^.*@.*\..*$", ErrorMessage = "Ongeldig {0}")]
            public string EmailOuders { get; set; } //Niet verplicht
            #endregion

            #region onAanpasbaardeVelden            
            [Display(Name = "Geboortedatum")]
            public DateTime GeboorteDatum { get; set; }

            [Display(Name = "Geboortestad")]
            public string GeboorteStad { get; set; }

            [Display(Name = "Geboorteland")]
            public string GeboorteLand { get; set; }

            [Display(Name = "Rijksregisternummer")] //niet
            public string RijksregisterNummer { get; set; }
            #endregion
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kon gebruiker niet laden met ID '{_userManager.GetUserId(User)}'.");
            }
            //gebruiker uit de repository halen
            Gebruiker gebruiker = _gebruikers.GetByUserName(user.UserName);

            //var username = gebruiker.Username;
            var email = await _userManager.GetEmailAsync(user);
            var naam = gebruiker.Naam;
            var voorNaam = gebruiker.Voornaam;
            //var geslacht = gebruiker.Geslacht;
            var geboorteDatum = gebruiker.GeboorteDatum;
            var geboorteLand = gebruiker.GeboorteLand;
            var geboorteStad = gebruiker.GeboorteStad;
            var straat = gebruiker.Straat;
            var huisNummer = gebruiker.HuisNummer;
            var gemeente = gebruiker.Gemeente;
            var postcode = gebruiker.Postcode;
            var telefoonNummer = gebruiker.TelefoonNummer;
            var gsmNummer = gebruiker.GsmNummer;
            var rijksregister = gebruiker.RijksregisterNummer;
            //var inschrijvingsDatum = gebruiker.InschrijvingsDatum;
            var emailOuders = gebruiker.EmailOuders;
            var infoClubAangelegenheden = gebruiker.InfoClubAangelegenheden;
            var infoFederale = gebruiker.InfoFederaleAangelegenheden;


            Input = new InputModel
            {
                Email = email,
                Naam = naam,
                Voornaam = voorNaam,
                GeboorteDatum = geboorteDatum,
                GeboorteLand = geboorteLand,
                GeboorteStad = geboorteStad,
                Straat = straat,
                HuisNummer = huisNummer,
                Gemeente = gemeente,
                Postcode = postcode,
                TelefoonNummer = telefoonNummer,
                GsmNummer = gsmNummer,
                RijksregisterNummer = rijksregister,
                EmailOuders = emailOuders,
                InfoClubAangelegenheden = infoClubAangelegenheden,
                InfoFederaleAangelegenheden = infoFederale
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            Gebruiker gebruiker = _gebruikers.GetByUserName(user.UserName);

            if (user == null)
            {
                return NotFound($"Kon gebruiker niet laden met ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Er vond een onbekende error plaats bij het aanpassen van het mailadres van de gerbuiker met het ID '{userId}'.");
                }
                gebruiker.Email = Input.Email;

            }

                gebruiker.Naam = Input.Naam;
                gebruiker.Voornaam = Input.Voornaam;
                //gebruiker.GeboorteDatum = Input.GeboorteDatum;
                //gebruiker.GeboorteLand = Input.GeboorteLand;
                //gebruiker.GeboorteStad = Input.GeboorteStad;
                gebruiker.Straat = Input.Straat;
                gebruiker.HuisNummer = Input.HuisNummer;
                gebruiker.Gemeente = Input.Gemeente;
                gebruiker.Postcode = Input.Postcode;
                gebruiker.TelefoonNummer = Input.TelefoonNummer;
                gebruiker.GsmNummer = Input.GsmNummer;
                //gebruiker.RijksregisterNummer = Input.RijksregisterNummer;
                gebruiker.EmailOuders = Input.EmailOuders;
                gebruiker.InfoClubAangelegenheden = Input.InfoClubAangelegenheden;
                gebruiker.InfoFederaleAangelegenheden = Input.InfoFederaleAangelegenheden;

                _gebruikers.SaveChanges();
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Uw profiel is aangepast";
                return RedirectToPage();
        }
    }
}
