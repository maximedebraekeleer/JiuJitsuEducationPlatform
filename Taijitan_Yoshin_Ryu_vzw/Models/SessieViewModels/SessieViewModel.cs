using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class SessieViewModel
    {
        public List<Lid> Leden { get; }
        public List<Lid> AanwezigeLeden { get; set; }
        public Sessie Sessie { get; }
        [Required(ErrorMessage = "Geef een wachtwoord op.")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        public SessieViewModel(List<Lid> leden, Sessie sessie, List<Lid> aanwezigheden)
        {            
            Leden = leden;
            Sessie = sessie;
            AanwezigeLeden = aanwezigheden;
        }                    
    }
}
