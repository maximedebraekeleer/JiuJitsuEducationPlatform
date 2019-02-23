using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            if (_dbContext.Database.EnsureCreated())
            {
                var leden = new List<Lid> {
                new Lid("Daan", "Van vooren", Convert.ToDateTime("10/01/1997 12:10:15 PM"), "Molenstraat", 14, "Aalst", 9300, 0497707832, "daan.vv@Hogent.be", true, true),
                new Lid("Annelies", "Van Achter", Convert.ToDateTime("4/6/1971 12:10:15 PM"), "Stationstraat", 12, "Lede", 9340, 0487708832, "anneva@gmail.be", true, false),
                new Lid("Michaël", "Vermassen", Convert.ToDateTime("3/16/1997 12:10:15 PM"), "lange zoutstraat", 34, "Aalst", 9300, 0497808832, "michver@gmail.be", false, true),
                new Lid("Maxime", "De Braekeleer", Convert.ToDateTime("9/2/1999 12:10:15 PM"), "Ottergemsesteenweg", 14, "Gent", 9000, 0498808832, "maxdebraek@gmail.be", false, false),
                new Lid("Hans", "van der Staak", Convert.ToDateTime("10/22/199912:10:15 PM"), "Bosstraat", 23, "Mere", 9420, 0497205832, "Hans.vds@gmail.be", false, false),
                new Lid("Christophe", "Ponnet", Convert.ToDateTime("8/01/1997 12:10:15 PM"), "Rozemarijnstraat", 19, "Gent", 9000, 0497707231, "chrisponnet@hotmail.be", false, false),
                new Lid("Aron", "De backer", Convert.ToDateTime("10/8/2001 12:10:15 PM"), "Voskenslaan", 65, "Gent", 9000, 0497708672, "aron.db@gmail.com", false, false)
                };
                _dbContext.Leden.AddRange(leden);

                var lesgroepen = new List<Lesgroep>
                {
                    new Lesgroep("groep 1"),
                    new Lesgroep("groep 2"),
                    new Lesgroep("groep 3"),
                    new Lesgroep("groep 4"),
                    new Lesgroep("groep 5"),
                    new Lesgroep("groep 6"),
                    new Lesgroep("groep 7"),
                    new Lesgroep("Dan-graden")
                };
                _dbContext.Lesgroepen.AddRange(lesgroepen);

                _dbContext.SaveChanges();


            }

        }
    }
    }

