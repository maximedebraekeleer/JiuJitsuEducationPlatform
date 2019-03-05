using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
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
            Sessie sessie1 = new Sessie(new DateTime(2019, 03, 20), "12:00", "14:00");
            Sessie sessie2 = new Sessie(new DateTime(2019, 03, 21), "15:00", "17:00");

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
            //User1
            string eMailAddress = "daan@gmail.com";
            user1 = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user1, "P@ssword1");
            await _userManager.AddClaimAsync(user1, new Claim(ClaimTypes.Role, "lid"));
            gebruiker1 = new Gebruiker {
                Email = eMailAddress,
                Naam = "Van Vooren",
                Voornaam = "Daan",
                GeboorteDatum = new DateTime(2000, 1, 10),
                Straat = "Rijschootstraat",
                HuisNummer = 23,
                Gemeente = "Ertvelde",
                Postcode = 9940,
                TelefoonNummer = 0470011701,
                IsLid = true,
                IsLesgever = false
            };

            //User2
            eMailAddress = "hans@gmail.com";
            user2 = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user2, "P@ssword1");
            await _userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "lid"));
            gebruiker2 = new Gebruiker {
                Email = eMailAddress,
                Naam = "van der Staak",
                Voornaam = "Hans",
                GeboorteDatum = new DateTime(1999, 1, 11),
                Straat = "Ottergemstraat",
                HuisNummer = 28,
                Gemeente = "Mere",
                Postcode = 9420,
                TelefoonNummer = 0497708826,
                IsLid = true,
                IsLesgever = false
            };

            //User3
            eMailAddress = "maxime@gmail.com";
            user3 = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user3, "P@ssword1");
            await _userManager.AddClaimAsync(user3, new Claim(ClaimTypes.Role, "lesgever"));
            gebruiker3 = new Gebruiker {
                Email = eMailAddress,
                Naam = "De Braekeleer",
                Voornaam = "Maxime",
                GeboorteDatum = new DateTime(1999, 5, 2),
                Straat = "Houtstraat",
                HuisNummer = 12,
                Gemeente = "Zulte Waregem",
                Postcode = 9870,
                TelefoonNummer = 046969669,
                IsLid = false,
                IsLesgever = true
            };

            //User4
            eMailAddress = "michael@gmail.com";
            user4 = new IdentityUser { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user4, "P@ssword1");
            await _userManager.AddClaimAsync(user4, new Claim(ClaimTypes.Role, "lesgever"));
            gebruiker4 = new Gebruiker {
                Email = eMailAddress,
                Naam = "Vermassen",
                Voornaam = "Michael",
                GeboorteDatum = new DateTime(1998, 4, 12),
                Straat = "Vlasstraat",
                HuisNummer = 12,
                Gemeente = "Opwijk",
                Postcode = 1234,
                TelefoonNummer = 0415789124,
                IsLid = false,
                IsLesgever = true
            };

            _dbContext.Gebruikers.Add(gebruiker1);
            _dbContext.Gebruikers.Add(gebruiker2);
            _dbContext.Gebruikers.Add(gebruiker3);
            _dbContext.Gebruikers.Add(gebruiker4);

            _dbContext.SaveChanges();
        }
    }
}
