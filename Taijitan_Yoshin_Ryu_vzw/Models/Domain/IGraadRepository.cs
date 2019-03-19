using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public interface IGraadRepository
    {
        IEnumerable<Graad> GetAll();
        Graad GetGraadWithId(int graad);
    }
}
