using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        //Users
        IdentityUser user1;
        IdentityUser user2;
        IdentityUser user3;
        IdentityUser user4;

        Gebruiker gebruiker1;
        Gebruiker gebruiker2;
        Gebruiker gebruiker3;
        Gebruiker gebruiker4;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager) {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            //Users maken
            await InitializeUsers();

            //Lesgroepen maken
            Lesgroep groep1 = new Lesgroep("groep 1");
            Lesgroep groep2 = new Lesgroep("groep 2");
            Lesgroep groep3 = new Lesgroep("groep 3");

            _dbContext.Lesgroepen.Add(groep1);
            _dbContext.Lesgroepen.Add(groep2);
            _dbContext.Lesgroepen.Add(groep3);

            //Leden in lesgroep steken
            gebruiker1.AddLesgroep(groep1);
            gebruiker2.AddLesgroep(groep1);
            gebruiker3.AddLesgroep(groep3);
            gebruiker4.AddLesgroep(groep2);

            //Sessies aanmaken
            Sessie sessie1 = new Sessie(new DateTime(2019, 03, 20));
            Sessie sessie2 = new Sessie(new DateTime(2019, 03, 22));

            _dbContext.Sessies.Add(sessie1);
            _dbContext.Sessies.Add(sessie2);

            //Groepen in sessie steken
            sessie1.AddLesgroep(groep1);
            sessie1.AddLesgroep(groep2);
            sessie2.AddLesgroep(groep3);

            //Wijzigingen opslaan
            _dbContext.SaveChanges();
        }

        private async Task InitializeUsers() {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            //User1
            string eMailAddress = "daan@gmail.com";
            user1 = new IdentityUser { Email = eMailAddress };
            await _userManager.CreateAsync(user1, "P@ssword1");
            await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "Gebruiker"));
            gebruiker1 = new Gebruiker
            {
                Email = eMailAddress,
                Naam = "Van Vooren",
                Voornaam = "Daan",
                GeboorteDatum = new DateTime(2000, 1, 10),
                Straat = "Rijschootstraat",
                HuisNummer = 23,
                Gemeente = "Ertvelde",
                Postcode = 9940,
                TelefoonNummer = 047001231
            };

            //User2
            eMailAddress = "hans@gmail.com";
            user2 = new IdentityUser { UserName = eMailAddress };
            gebruiker2 = new Gebruiker {               
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
            await _userManager.CreateAsync(user2, "P@ssword1");
            await _userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "Gebruiker"));

            //User3
            eMailAddress = "maxime@gmail.com";
            user3 = new IdentityUser { UserName = eMailAddress };
            gebruiker3 = new Gebruiker {
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
            await _userManager.CreateAsync(user3, "P@ssword1");
            await _userManager.AddClaimAsync(user3, new Claim(ClaimTypes.Role, "lesgever"));

            //User4
            eMailAddress = "dirk@gmail.com";
            user4 = new IdentityUser { UserName = eMailAddress };
            gebruiker4 = new Gebruiker {
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
            await _userManager.CreateAsync(user4, "P@ssword1");

            _dbContext.SaveChanges();
        }
    }
}
