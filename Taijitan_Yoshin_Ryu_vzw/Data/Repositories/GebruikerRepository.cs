using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories {
    public class GebruikerRepository : IGebruikerRepository {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;
        public GebruikerRepository(ApplicationDbContext context) {
            _context = context;
            _gebruikers = context.Gebruikers;
        }
        public void Add(Gebruiker Gebruiker) {
            _gebruikers.Add(Gebruiker);
        }

        public void Delete(Gebruiker Gebruiker) {
            _gebruikers.Remove(Gebruiker);
        }

        public IEnumerable<Gebruiker> GetAll() {
            return _gebruikers.ToList();
        }

        public IEnumerable<Lid> GetLeden() {
            return _gebruikers.Where(g => g is Lid)
                .Select(g => (Lid)g)
                .Include(l => l.Formule)
                .ThenInclude(f => f.FormuleTrainingsmomenten)
                .ThenInclude(op => op.Trainingsmoment)
                .ToList();
        }

        public Gebruiker GetByEmail(string email) {
            return _gebruikers.SingleOrDefault(l => l.Email.Equals(email));
        }

        public Gebruiker GetByUserName(string username) {
            return _gebruikers.SingleOrDefault(l => l.Username.Equals(username));
        }

        public IEnumerable<Lid> getLedenByFormule(Formule formule) {
            return _gebruikers.Where(g => g is Lid).Select(g => (Lid)g).Where(l => l.Formule == formule).ToList();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
