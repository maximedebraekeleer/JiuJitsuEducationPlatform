using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;
        public GebruikerRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = context.Gebruikers;
        }
        public void Add(Gebruiker Gebruiker) {
            _gebruikers.Add(Gebruiker);
        }

        public void Delete(Gebruiker Gebruiker) {
            _gebruikers.Remove(Gebruiker);
        }

        public Gebruiker GetByEmail(string email) {
            return _gebruikers.SingleOrDefault(l => l.Email.Equals(email));
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
