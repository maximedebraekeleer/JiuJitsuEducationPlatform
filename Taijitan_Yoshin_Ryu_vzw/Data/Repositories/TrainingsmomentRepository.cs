using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories {
    public class TrainingsmomentRepository : ITrainingsmomentRepository {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Trainingsmoment> _trainingsmoment;

        public TrainingsmomentRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
            _trainingsmoment = dbContext.Trainingsmomenten;
        }

        public IEnumerable<Trainingsmoment> getByDagNummer(int dag) {
            return _trainingsmoment.Where(t => t.DagNummer == dag).ToList();
        }

        public Trainingsmoment getById(int id) {
            return _trainingsmoment.SingleOrDefault(t => t.Id == id);
        }

        IEnumerable<Trainingsmoment> ITrainingsmomentRepository.getAll() {
            return _trainingsmoment.ToList();
        }
    }
}
