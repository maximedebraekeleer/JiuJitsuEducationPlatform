using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Models
{
    public class Sessie
    {
        #region Properties
        public DateTime Tijdstip { get; private set; }
        public Lesgroep Lesgroep { get; private set; }
        #endregion
    }
}
