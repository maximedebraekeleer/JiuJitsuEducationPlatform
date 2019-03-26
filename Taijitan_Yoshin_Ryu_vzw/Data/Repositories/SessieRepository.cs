using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;
        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessies = _context.Sessies;
        }

        public void Add(Sessie sessie)
        {
            _sessies.Add(sessie);
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();
        }

        public Sessie GetByDatumBeginUur(DateTime datumBeginUur)
        {
            return _sessies.Include(s => s.Aanwezigheden).Where(x => x.BeginDatumEnTijd == datumBeginUur).FirstOrDefault();
        }

        public Sessie GetByDatumEnUur(DateTime huidigeDatumEnUur)
        {
            return _sessies
                .Include(s => s.Aanwezigheden)
                .ThenInclude(a => a.Lid)
                .Where(s => huidigeDatumEnUur >= s.BeginDatumEnTijd && huidigeDatumEnUur <= s.EindDatumEnTijd)
                .FirstOrDefault();
        }

        public void Remove(Sessie sessie)
        {
            _sessies.Remove(sessie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
