using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public interface ITrainingsdagRepository
    {
        Trainingsdag getById(int id);
        IEnumerable<Trainingsdag> getByDagNummer(int dag);
        IEnumerable<Trainingsdag> getAll();
    }
}
