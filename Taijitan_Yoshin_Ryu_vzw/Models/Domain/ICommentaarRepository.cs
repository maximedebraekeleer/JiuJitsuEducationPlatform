using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public interface ICommentaarRepository
    {
        IEnumerable<Commentaar> GetNew();
        void SaveChanges();
        void VoegCommentaarToe(Lid Lid, string Inhoud, Lesmateriaal Lesmateriaal);
    }
}
