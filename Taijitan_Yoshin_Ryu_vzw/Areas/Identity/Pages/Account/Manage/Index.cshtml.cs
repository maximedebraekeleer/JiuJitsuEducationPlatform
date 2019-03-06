using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Taijitan_Yoshin_Ryu_vzw.Data;
using Taijitan_Yoshin_Ryu_vzw.Data.Repositories;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly GebruikerRepository _gebruikers;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _gebruikers = new GebruikerRepository(dbContext);
        }
 
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {                       
            #region required inputs
            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "E-mailadres")]
            [EmailAddress]
            public string Email { get; set; }
            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "Geboortedatum")]
            [DataType(DataType.Date)]
            public DateTime GeboorteDatum { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Straat { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Gemeente { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "Huisnummer")]
            public int HuisNummer { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "Postcode")]
            [DataType(DataType.PostalCode)]
            public int PostCode { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Naam { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Voornaam { get; set; }
            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public int GsmNummer { get; set; }
            #endregion

            #region disabled input fields            
            public char Geslacht { get; set; }
            public string GeboorteStad { get; set; }
            public string GeboorteLand { get; set; }
            public int RijksregisterNummer { get; set; }
            public DateTime InschrijvingsDatum { get; set; }
            #endregion
                       
            [Display(Name = "Telefoonnummer")]
            //[Phone]
            public int TelefoonNummer { get; set; } //Niet verplicht

            [Display(Name = "E-mailadres van ouders")]
            public string EmailOuders { get; set; } //Niet verplicht

            [Display(Name = "Ik wens info te ontvangen over club aangelegenheden.")]
            public bool InfoClubAangelegenheden { get; set; }

            [Display(Name = "Ik wens info te ontvangen over federale aangelegenheden.")]
            public bool InfoFederaleAangelegenheden { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kon gebruiker niet laden met ID '{_userManager.GetUserId(User)}'.");
            }
            //gebruiker uit de repository halen
            Gebruiker gebruiker = _gebruikers.GetByEmail(user.Email);

            var email = await _userManager.GetEmailAsync(user);
            var naam = gebruiker.Naam;
            var voorNaam = gebruiker.Voornaam;
            var geslacht = gebruiker.Geslacht;
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
                PostCode = postcode,
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
            Gebruiker gebruiker = _gebruikers.GetByEmail(user.Email);

            if (user == null)
            {
                return NotFound($"Kon gebruiker niet laden met ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                var setUserNameResult = await _userManager.SetUserNameAsync(user, Input.Email);
                if (!setEmailResult.Succeeded || !setUserNameResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user); 
                    throw new InvalidOperationException($"Er vond een onbekende error plaats bij het aanpassen van het mailadres van de gerbuiker met het ID '{userId}'.");
                }
                gebruiker.Email = Input.Email;
                
            }

            gebruiker.Naam = Input.Naam;
            gebruiker.Voornaam = Input.Voornaam;
            gebruiker.GeboorteDatum = Input.GeboorteDatum;
            gebruiker.GeboorteLand = Input.GeboorteLand;
            gebruiker.GeboorteStad = Input.GeboorteStad;
            gebruiker.Straat = Input.Straat;
            gebruiker.HuisNummer = Input.HuisNummer;
            gebruiker.Gemeente = Input.Gemeente;
            gebruiker.Postcode = gebruiker.Postcode;
            gebruiker.TelefoonNummer = Input.TelefoonNummer;
            gebruiker.GsmNummer = Input.GsmNummer;
            gebruiker.RijksregisterNummer = Input.RijksregisterNummer;
            gebruiker.EmailOuders = Input.EmailOuders;
            gebruiker.InfoClubAangelegenheden = Input.InfoClubAangelegenheden;
            gebruiker.InfoFederaleAangelegenheden = Input.InfoFederaleAangelegenheden;
               
            _gebruikers.SaveChanges();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Uw profiel is aangepast";
            return RedirectToPage();
        }
       
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
