using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Lid> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<Lid> userManager) {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                await InitializeUsers();

                //Tabellen leeg maken
                try {
                    _dbContext.Database.ExecuteSqlCommand(
                    "DELETE FROM [Lid_Lesgroep]" +
                    "DBCC CHECKIDENT ([Lid_Lesgroep], RESEED, 0);" +
                    "DELETE FROM [Sessie_Lesgroep]" +
                    "DBCC CHECKIDENT ([Sessie_Lesgroep], RESEED, 0);" +
                    "DELETE FROM [Lesgroep]" +
                    "DBCC CHECKIDENT ([Lesgroep], RESEED, 0);" +
                    "DELETE FROM [Sessie]" +
                    "DBCC CHECKIDENT ([Sessie], RESEED, 0);" +

                    "DELETE FROM [AspNetUsers]" +
                    "DBCC CHECKIDENT ([AspNetUsers], RESEED, 0);" +
                    "DELETE FROM [AspNetUserClaims]" +
                    "DBCC CHECKIDENT ([AspNetUserClaims], RESEED, 0);" +
                    "DELETE FROM [AspNetRoleClaims]" +
                    "DBCC CHECKIDENT ([AspNetRoleClaims], RESEED, 0);" +
                    "DELETE FROM [AspNetRoles]" +
                    "DBCC CHECKIDENT ([AspNetRoles], RESEED, 0);"
                    );
                }
                catch (Exception e) {

                }

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
                Lid litter = _dbContext.Leden.FirstOrDefault(l => l.Voornaam == "Daan");
                litter.AddLesgroep(groep1);
                Lid lit = _dbContext.Leden.FirstOrDefault(l => l.Voornaam == "Hans");
                litter.AddLesgroep(groep1);
                Lid lit2 = _dbContext.Leden.FirstOrDefault(l => l.Voornaam == "Maxime");
                litter.AddLesgroep(groep2);
                Lid litter2 = _dbContext.Leden.FirstOrDefault(l => l.Voornaam == "Dirk");
                litter.AddLesgroep(groep3);
                

                //Sessies
                Sessie sessie1 = new Sessie(new DateTime(2019, 03, 20));
                Sessie sessie2 = new Sessie(new DateTime(2019, 03, 22));

                _dbContext.Sessies.Add(sessie1);
                _dbContext.Sessies.Add(sessie2);

                sessie1.AddLesgroep(groep1);
                sessie1.AddLesgroep(groep2);
                sessie2.AddLesgroep(groep3);
            }
        }

        private async Task InitializeUsers() {
            //User1
            string eMailAddress = "daan@gmail.com";
            Lid user = new Lid {
                UserName = eMailAddress,
                Email = eMailAddress,
                Naam = "Van Vooren",
                Voornaam = "Daan",
                GeboorteDatum = new DateTime(2000, 1, 10),
                Straat = "Rijschootstraat",
                HuisNummer = 23,
                Gemeente = "Ertvelde",
                Postcode = 9940,
                TelefoonNummer = 0470012312
            };
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "beheerder"));

            //User2
            eMailAddress = "hans@gmail.com";
            user = new Lid {
                UserName = eMailAddress,
                Email = eMailAddress,
                Naam = "van der Staak",
                Voornaam = "Hans",
                GeboorteDatum = new DateTime(1999, 1, 11),
                Straat = "Ottergemstraat",
                HuisNummer = 28,
                Gemeente = "Mere",
                Postcode = 9420,
                TelefoonNummer = 0497708826
            };
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "beheerder"));

            //User3
            eMailAddress = "maxime@gmail.com";
            user = new Lid {
                UserName = eMailAddress,
                Email = eMailAddress,
                Naam = "De Braekeleer",
                Voornaam = "Maxime",
                GeboorteDatum = new DateTime(502, 1, 10),
                Straat = "Glazenstraat",
                HuisNummer = 69,
                Gemeente = "Zulte Waregem",
                Postcode = 9870,
                TelefoonNummer = 046969669
            };
            await _userManager.CreateAsync(user, "P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "lesgever"));

            //User4
            eMailAddress = "dirk@gmail.com";
            user = new Lid {
                UserName = eMailAddress,
                Email = eMailAddress,
                Naam = "Dirk",
                Voornaam = "Dirkie",
                GeboorteDatum = new DateTime(200, 1, 11),
                Straat = "Yikesstraat",
                HuisNummer = 28,
                Gemeente = "Merel",
                Postcode = 9420,
                TelefoonNummer = 0497708826
            };
            await _userManager.CreateAsync(user, "P@ssword1");

            _dbContext.SaveChanges();
        }
    }
}

