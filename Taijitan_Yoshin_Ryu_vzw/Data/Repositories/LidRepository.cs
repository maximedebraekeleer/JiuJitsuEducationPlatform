//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

//namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
//{
//    public class LidRepository : ILidRepository 
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly DbSet<Lid> _leden;
//        public LidRepository(ApplicationDbContext context)
//        {
//            _context = context;
//            _leden = context.Leden;
//        }
//        public void Add(Lid lid)
//        {
//            _leden.Add(lid);
//        }

//        public void Delete(Lid lid)
//        {
//            _leden.Remove(lid);
//        }

//        public Lid GetByEmail(string email)
//        {
//           return _leden.SingleOrDefault(l => l.Email.Equals(email.ToLower()));
//        }

//        public void SaveChanges()
//        {
//            _context.SaveChanges();
//        }
//    }
//}
