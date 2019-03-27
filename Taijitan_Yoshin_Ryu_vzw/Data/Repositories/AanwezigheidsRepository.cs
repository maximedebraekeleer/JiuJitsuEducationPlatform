using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class AanwezigheidsRepository : IAanwezigheidRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Aanwezigheid> _aanwezigheden;
        public AanwezigheidsRepository(ApplicationDbContext context)
        {
            _context = context;
            _aanwezigheden = _context.aanwezigheden;
        }

        public void Add(Aanwezigheid aanwezigheid)
        {
            _aanwezigheden.Add(aanwezigheid);
        }

        public IEnumerable<Aanwezigheid> GetAll()
        {
            return _aanwezigheden.Include(a => a.Sessie).Include(a => a.Lid).ThenInclude(l => l.Formule).ToList();
        }

        public IEnumerable<Aanwezigheid> GetbyLid(Lid lid)
        {
            return _aanwezigheden.Where(a => a.Lid == lid).ToList();
        }

        public void Remove(Aanwezigheid aanwezigheid)
        {
            _aanwezigheden.Remove(aanwezigheid);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
