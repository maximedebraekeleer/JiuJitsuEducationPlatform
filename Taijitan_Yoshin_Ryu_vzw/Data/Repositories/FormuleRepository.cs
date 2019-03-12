using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class FormuleRepository : IFormuleRepository
    {
        private readonly DbSet<Formule> _formules;
        public FormuleRepository(ApplicationDbContext dbContext)
        {
            _formules = dbContext.Formules;
        }
        public IEnumerable<Formule> getAll()
        {
            return _formules.ToList();

        }

        public IEnumerable<Formule> getByTrainingsdag(Trainingsdag trainingsdag)
        {
            IEnumerable<Formule> formules = _formules.Include(f => f.Trainingsdagen).Where( f=> f.Trainingsdagen.Contains(trainingsdag));
            return formules;
            
        }
    }
}
