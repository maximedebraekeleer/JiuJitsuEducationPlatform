using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels
{
    public class andereLedenViewModel
    {
        public List<Lid> LedenNietOpDag { get; set; }
        public List<Lid> Aanwezigheden { get; set; }
        public andereLedenViewModel(List<Lid> ledenNietOpDag, List<Lid> extraAanwezigheden)
        {
            LedenNietOpDag = ledenNietOpDag;
            Aanwezigheden = extraAanwezigheden;
        }

        
    }
}
