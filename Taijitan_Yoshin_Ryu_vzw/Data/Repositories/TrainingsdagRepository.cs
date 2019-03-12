using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class TrainingsdagRepository : ITrainingsdagRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Trainingsdag> _trainingsdagen;

        public TrainingsdagRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _trainingsdagen = dbContext.Trainingsdagen;
        }

        public IEnumerable<Trainingsdag> getByDagNummer(int dag)
        {
            return _trainingsdagen.Where(t => t.DagNummer == dag).ToList();
        }

        public Trainingsdag getById(int id)
        {
            return _trainingsdagen.SingleOrDefault(t => t.Id == id);
        }

        IEnumerable<Trainingsdag> ITrainingsdagRepository.getAll()
        {
            return _trainingsdagen.ToList();
        }
    }
}
