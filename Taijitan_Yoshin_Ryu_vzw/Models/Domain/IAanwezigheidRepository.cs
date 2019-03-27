using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public interface IAanwezigheidRepository
    {
        IEnumerable<Aanwezigheid> GetAll();
        //IEnumerable<Aanwezigheid> GetbySessie(Sessie sessie);
        IEnumerable<Aanwezigheid> GetbyLid(Lid lid);
        //IEnumerable<Aanwezigheid> GetbyFormule(Formule formule);
        //void RemoveBySessie(Sessie sessie);
        void Add(Aanwezigheid aanwezigheid);
        void Remove(Aanwezigheid aanwezigheid);
        void SaveChanges();
    }
}
