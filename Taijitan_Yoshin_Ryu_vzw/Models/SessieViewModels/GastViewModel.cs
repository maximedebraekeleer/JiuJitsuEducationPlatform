using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels.CustomDataAnnotations;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class GastViewModel
    {
        #region Properties
        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [StringLength(25,MinimumLength = 7, ErrorMessage = "{0} moet minstens 7 karakters bevatten")]
        public string Username { get; set; }

        [Display(Name = "E-mailadres")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [EmailAddress(ErrorMessage = "Ongeldig {0}")]
        public string Email { get; set; }

        [Display(Name = "Naam")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        public string Naam { get; set; }

        [Display(Name = "Voornaam")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        public string Voornaam { get; set; }

        [Display(Name = "Geslacht")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        public char Geslacht { get; set; }

        [Display(Name = "Geboortedatum")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum")]
        [GeboorteDatum(ErrorMessage = "Gebruiker moet tussen de 6 en 99 jaar zijn")]
        public DateTime GeboorteDatum { get; set; }

        [Display(Name = "Geboorteland")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        public string GeboorteLand { get; set; }

        [Display(Name = "Geboortestad")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        public string GeboorteStad { get; set; }

        [Display(Name = "Straat")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        public string Straat { get; set; }

        [Display(Name = "Huisnummer")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^[0-9]+[a-zA-Z]*", ErrorMessage = "Ongeldig {0}")]
        public string HuisNummer { get; set; }

        [Display(Name = "Gemeente")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^([^0-9]*)$", ErrorMessage = "{0} mag geen cijfers bevatten")]
        public string Gemeente { get; set; }

        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "{0} moet uit vier cijfers bestaan")]
        public string Postcode { get; set; }

        [Display(Name = "Telefoonnummer")]
        [RegularExpression(@"^\d{9}$|^\+\d{10}$|^$", ErrorMessage = "Ongeldig {0}")]
        public string TelefoonNummer { get; set; } //Niet verplicht

        [Display(Name = "GSM-nummer")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RegularExpression(@"^\d{10}$|^\+\d{11}$", ErrorMessage = "Ongeldig {0}")]
        public string GsmNummer { get; set; }

        [Display(Name = "Rijksregisternummer")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen")]
        [RijksregisterNummer(ErrorMessage = "Ongeldig {0}")]
        public string RijksregisterNummer { get; set; }

        [Display(Name = "E-mailadres van ouders")]
        [RegularExpression(@"^$|^.*@.*\..*$", ErrorMessage = "Ongeldig {0}")]
        public string EmailOuders { get; set; } //Niet verplicht
        #endregion
    }
}
