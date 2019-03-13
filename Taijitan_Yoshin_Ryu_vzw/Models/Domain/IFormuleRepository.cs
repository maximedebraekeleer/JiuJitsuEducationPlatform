using System.Collections.Generic;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public interface IFormuleRepository {
        IEnumerable<Formule> getAll();
        IEnumerable<Formule> getByTrainingsmoment(Trainingsmoment trainingsmoment);
    }
}
