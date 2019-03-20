using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.LesmateriaalViewModels
{
    public class LesmateriaalViewModel
    {
        public Lid HuidigLid { get; set; }
        public List<Graad> Graden { get; set; }

        public LesmateriaalViewModel(Gebruiker huidigLid, List<Graad> graden)
        {
            HuidigLid = (Lid)huidigLid;
            Graden = graden;
        }
    }
}
