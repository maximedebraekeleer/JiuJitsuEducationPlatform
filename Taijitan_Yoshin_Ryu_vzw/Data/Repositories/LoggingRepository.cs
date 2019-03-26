using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly DbSet<Logging> _loggings;
        ApplicationDbContext _dbContext;

        public LoggingRepository(ApplicationDbContext dbContext)
        {            
            _dbContext = dbContext;
            _loggings = _dbContext.Loggings;
        }
        
        public void AddLogging(Logging logging)
        {
            _loggings.Add(logging);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
