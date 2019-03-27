using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class CommentaarRepository : ICommentaarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Commentaar> _commentaren;
        public CommentaarRepository(ApplicationDbContext context)
        {
            _context = context;
            _commentaren = _context.Commentaren;
        }

        public IEnumerable<Commentaar> GetNew()
        {
            return _commentaren.Where(c => c.IsNew).Include(c => c.Lesmateriaal).Include(c => c.Lid).ToList();
        }

        public void VoegCommentaarToe(Lid Lid, string Inhoud, Lesmateriaal Lesmateriaal)
        {
            _commentaren.Add(new Commentaar(Inhoud, Lid, Lesmateriaal));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
