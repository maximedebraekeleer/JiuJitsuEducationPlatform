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
        public string Username { get; set; } //Unieke waarde
        [Display(Name = "E-mailadres")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [EmailAddress(ErrorMessage = "Ongeldig E-mailadres.")]
        public string Email { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public char Geslacht { get; set; }
        [Display(Name = "Geboortedatum")]
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [DataType(DataType.Date)]
        public DateTime GeboorteDatum { get; set; }
        public string GeboorteLand { get; set; }
        public string GeboorteStad { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Gemeente { get; set; }
        public string Postcode { get; set; }
        public string TelefoonNummer { get; set; } //Niet verplicht
        public string GsmNummer { get; set; }
        public string RijksregisterNummer { get; set; }
        public string EmailOuders { get; set; } //Niet verplicht
        #endregion
    }
}
