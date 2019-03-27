using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class GraadRepository : IGraadRepository
    {
        private readonly DbSet<Graad> _graden;
        ApplicationDbContext _dbContext;

        public GraadRepository(ApplicationDbContext dbContext)
        {
            _graden = dbContext.Graden;
            _dbContext = dbContext;
        }

        public IEnumerable<Graad> GetAll()
        {
            return _graden
                .Include(f => f.GraadLesmateriaalThemas).ThenInclude(op => op.LesmateriaalThema)
                .ThenInclude(t => t.Lesmaterialen).ToList();
        }

        public Graad GetGraadWithId(int Graadid)
        {
            return _graden.Where(g => g.GraadId == Graadid).Include(f => f.GraadLesmateriaalThemas).ThenInclude(op => op.LesmateriaalThema)
                .ThenInclude(t => t.Lesmaterialen).ThenInclude(c => c.Commentaren).ThenInclude(c => c.Lid).First();
        }

    }
}
