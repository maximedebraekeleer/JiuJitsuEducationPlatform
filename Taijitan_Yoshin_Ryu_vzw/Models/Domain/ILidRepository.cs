using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public interface ILidRepository {
        Lid GetByEmail(string email);
        void Add(Lid lid);
        void Delete(Lid lid);
        void SaveChanges();
    }
}
