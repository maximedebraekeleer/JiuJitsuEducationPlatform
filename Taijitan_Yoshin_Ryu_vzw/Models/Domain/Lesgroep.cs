using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Lesgroep
    {
        public string Groepsnaam { get; set; }

        public Lesgroep(string groepsnaam)
        {
            Groepsnaam = groepsnaam;
        }
    }
}
