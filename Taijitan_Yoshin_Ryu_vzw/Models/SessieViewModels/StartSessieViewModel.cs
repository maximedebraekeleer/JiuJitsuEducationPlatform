using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModel
{
    public class StartSessieViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Datum van de sessie")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [DataType(DataType.Time)]
        [Display(Name = "De sessie start om")]
        public DateTime BeginUur { get; set; }
        [Required(ErrorMessage = "{0} is verplicht om in te vullen.")]
        [DataType(DataType.Time)]
        [Display(Name = "De sessie eindigt om")]
        public DateTime EindUur { get; set; }
        
        
        public StartSessieViewModel()
        {
            DateTime dateNow = DateTime.Now;
            Datum = dateNow.Date;
            BeginUur = new DateTime(dateNow.Year,dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute,0);
            EindUur = BeginUur.AddMinutes(90);
        }        

    }
}
