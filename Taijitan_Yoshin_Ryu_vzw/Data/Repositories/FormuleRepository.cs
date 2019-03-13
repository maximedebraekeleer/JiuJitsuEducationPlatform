using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories {
    public class FormuleRepository : IFormuleRepository {
        private readonly DbSet<Formule> _formules;
        ApplicationDbContext _dbContext;

        public FormuleRepository(ApplicationDbContext dbContext) {
            _formules = dbContext.Formules;
            _dbContext = dbContext;
        }

        public IEnumerable<Formule> getAll() {
            return _formules.Include(f => f.Leden).Include(f => f.FormuleTrainingsmomenten).ThenInclude(op => op.Trainingsmoment).ToList();
        }

        public IEnumerable<Formule> getByTrainingsmoment(Trainingsmoment trainingsmoment) {
            return _formules.Where(f => f.Trainingsmomenten.SelectMany(o => o.FormuleTrainingsmomenten).Select(o => o.Trainingsmoment).Contains(trainingsmoment));
        }
    }
}
