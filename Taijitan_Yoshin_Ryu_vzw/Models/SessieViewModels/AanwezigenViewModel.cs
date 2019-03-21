using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class AanwezigenViewModel
    {
        public List<Lid> AanwezigeLeden { get; set; }

        public AanwezigenViewModel(List<Lid> aanwezigeLeden)
        {
            AanwezigeLeden = aanwezigeLeden;
        }
    }
}
