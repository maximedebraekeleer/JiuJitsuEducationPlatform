using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void InitializeData() {
            //Tabellen leeg maken
            try {
                _dbContext.Database.ExecuteSqlCommand(
                "DELETE FROM [Lid_Lesgroep]" +
                "DBCC CHECKIDENT ([Lid_Lesgroep], RESEED, 0);" +
                "DELETE FROM [Lid]" +
                "DBCC CHECKIDENT ([Lid], RESEED, 0);" +
                "DELETE FROM [Lesgroep]" +
                "DBCC CHECKIDENT ([Lesgroep], RESEED, 0);" +
                "DELETE FROM [Sessie]" +
                "DBCC CHECKIDENT ([Sessie], RESEED, 0);"
                );
            }
            catch (Exception e) {

            }

            //Databank opvullen
            //Leden
            Lid daan = new Lid("Daan", "Van vooren", Convert.ToDateTime("10/01/1997 12:10:15 PM"), "Molenstraat", 14, "Aalst", 9300, 0497707832, "daan.vv@Hogent.be", true, true);
            Lid annelies = new Lid("Annelies", "Van Achter", Convert.ToDateTime("4/6/1971 12:10:15 PM"), "Stationstraat", 12, "Lede", 9340, 0487708832, "anneva@gmail.be", true, false);
            Lid michael = new Lid("Michaël", "Vermassen", Convert.ToDateTime("3/12/1997 12:10:15 PM"), "lange zoutstraat", 34, "Aalst", 9300, 0497808832, "michver@gmail.be", false, true);
            Lid maxime = new Lid("Maxime", "De Braekeleer", Convert.ToDateTime("9/2/1999 12:10:15 PM"), "Ottergemsesteenweg", 14, "Gent", 9000, 0498808832, "maxdebraek@gmail.be", false, false);
            Lid hans = new Lid("Hans", "van der Staak", Convert.ToDateTime("10/2/1999 12:10:15 PM"), "Bosstraat", 23, "Mere", 9420, 0497205832, "Hans.vds@gmail.be", false, false);
            Lid christophe = new Lid("Christophe", "Ponnet", Convert.ToDateTime("8/01/1997 12:10:15 PM"), "Rozemarijnstraat", 19, "Gent", 9000, 0497707231, "chrisponnet@hotmail.be", false, false);
            Lid aaron = new Lid("Aron", "De backer", Convert.ToDateTime("10/8/2001 12:10:15 PM"), "Voskenslaan", 65, "Gent", 9000, 0497708672, "aron.db@gmail.com", false, false);

            _dbContext.AddRange(annelies, daan, michael, maxime, hans, christophe, aaron);

            //Lesgroepen
            Lesgroep groep1 = new Lesgroep("groep 1");
            Lesgroep groep2 = new Lesgroep("groep 2");
            Lesgroep groep3 = new Lesgroep("groep 3");
            var lesgroepen = new List<Lesgroep>
            {
                    groep1,
                    groep2,
                    groep3,
                    new Lesgroep("groep 4"),
                    new Lesgroep("groep 5"),
                    new Lesgroep("groep 6"),
                    new Lesgroep("groep 7"),
                    new Lesgroep("Dan-graden")
            };
            _dbContext.Lesgroepen.AddRange(lesgroepen);

            //vullen lidlesgroep, methode addlesgroep maakt een nieuwe lidlesgroep
            daan.AddLesgroep(groep1);
            annelies.AddLesgroep(groep2);
            michael.AddLesgroep(groep3);
            maxime.AddLesgroep(groep3);
            hans.AddLesgroep(groep1);
            christophe.AddLesgroep(groep1);
            aaron.AddLesgroep(groep2);

            //Sessies
            Sessie sessie1 = new Sessie(new DateTime(2019, 03, 20));
            Sessie sessie2 = new Sessie(new DateTime(2019, 03, 22));

            _dbContext.Sessies.Add(sessie1);
            _dbContext.Sessies.Add(sessie2);

            sessie1.AddLesgroep(groep1);
            sessie1.AddLesgroep(groep2);
            sessie2.AddLesgroep(groep3);

            //opslaan in databank
            _dbContext.SaveChanges();
        }
    }
}

