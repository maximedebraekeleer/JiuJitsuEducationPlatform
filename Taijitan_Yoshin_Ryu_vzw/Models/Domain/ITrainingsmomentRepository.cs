using System.Collections.Generic;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public interface ITrainingsmomentRepository {
        Trainingsmoment getById(int id);
        IEnumerable<Trainingsmoment> getByDagNummer(int dag);
        IEnumerable<Trainingsmoment> getAll();
    }
}
