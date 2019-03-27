using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class GastViewModel
    {
        #region Properties
        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [StringLength(25,MinimumLength = 7, ErrorMessage ="Gebruikersnaam moet minstens 7 karakters bevatten")]
        public string Username { get; set; } //Unieke waarde
        [Display(Name = "E-mailadres")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [EmailAddress(ErrorMessage = "Ongeldig E-mailadres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string Voornaam { get; set; }
        public char Geslacht { get; set; }
        [Display(Name = "Geboortedatum")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum.")]
        public DateTime GeboorteDatum { get; set; }
        [Display(Name = "Geboorteland")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string GeboorteLand { get; set; }
        [Display(Name = "Geboortestad")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string GeboorteStad { get; set; }
        [Display(Name = "Straat")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string Straat { get; set; }
        [Display(Name = "Huisnummer")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string HuisNummer { get; set; }
        [Display(Name = "Gemeente")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string Gemeente { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string Postcode { get; set; }
        [Display(Name = "Telefoonnummer")]
        public string TelefoonNummer { get; set; } //Niet verplicht
        [Display(Name = "Gsmnummer")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string GsmNummer { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        public string RijksregisterNummer { get; set; }
        [Display(Name = "E-mailadres ouders")]
        [EmailAddress(ErrorMessage = "Ongeldig E-mailadres.")]
        public string EmailOuders { get; set; } //Niet verplicht
        #endregion        
    }
}
