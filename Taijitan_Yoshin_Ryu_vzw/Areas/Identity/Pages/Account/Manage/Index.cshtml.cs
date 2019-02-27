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
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "E-mailadres")]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            [Display(Name = "Telefoonnummer")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Naam { get; set; }

            [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
            public string Voornaam { get; set; }

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
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var naam = user.Naam;
            var voorNaam = user.Voornaam;
            var geboorteDatum = user.GeboorteDatum;
            var straat = user.Straat;
            var huisNummer = user.HuisNummer;
            var gemeente = user.Gemeente;
            var postcode = user.Postcode;


            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                Naam = naam,
                Voornaam = voorNaam,
                GeboorteDatum = geboorteDatum,
                Straat = straat,
                HuisNummer = huisNummer,
                Gemeente = gemeente,
                PostCode = postcode
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            if(Input.Naam != user.Naam)
            {
                user.Naam = Input.Naam;
            }
            if(Input.Voornaam != user.Voornaam)
            {
                user.Voornaam = Input.Voornaam;
            }
            if(Input.GeboorteDatum != user.GeboorteDatum)
            {
                user.GeboorteDatum = Input.GeboorteDatum;
            }
            if (Input.Straat != user.Straat)
            {
                user.Straat = Input.Straat;
            }
            if (Input.HuisNummer != user.HuisNummer)
            {
                user.HuisNummer = Input.HuisNummer;
            }
            if (Input.Gemeente != user.Gemeente)
            {
                user.Gemeente = Input.Gemeente;
            }
            if (Input.PostCode != user.Postcode)
            {
                user.Postcode = Input.PostCode;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
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
