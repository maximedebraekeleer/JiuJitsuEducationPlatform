using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByEmail(string email);
        void Add(Gebruiker Gebruiker);
        void Delete(Gebruiker Gebruiker);
        void SaveChanges();
        IEnumerable<Lid> getLedenByFormule(Formule formule);
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetByUserName(string username);
        IEnumerable<Lid> GetLeden();
    }
}
