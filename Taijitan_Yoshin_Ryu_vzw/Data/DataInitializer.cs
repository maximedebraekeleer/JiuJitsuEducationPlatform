using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taijitan_Yoshin_Ryu_vzw.Data {
    public class DataInitializer {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager) {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                //Trainingsmomenten (van site gehaald)
                Trainingsmoment Dinsdag = new Trainingsmoment(2, "Dinsdag", "18:00", "20:00");
                Trainingsmoment Woensdag = new Trainingsmoment(3, "Woensdag", "14:00", "15:30");
                Trainingsmoment Donderdag = new Trainingsmoment(4, "Donderdag", "18:00", "20:00");
                Trainingsmoment Zaterdag = new Trainingsmoment(6, "Zaterdag", "10:00", "11:30");

                var trainingsmomenten = new List<Trainingsmoment> {
                    Dinsdag, Woensdag, Donderdag, Zaterdag
                };
                _dbContext.Trainingsmomenten.AddRange(trainingsmomenten);

                //Formules (van powerpoint gehaald)
                Formule DI_DO = new Formule("DI_DO");
                Formule DI_ZA = new Formule("DI_ZA");
                Formule WO_ZA = new Formule("WO_ZA");
                Formule WO = new Formule("WO");
                Formule ZA = new Formule("ZA");

                var formules = new List<Formule> {
                    DI_DO, DI_ZA, WO_ZA, WO, ZA
                };
                _dbContext.Formules.AddRange(formules);

                //Trainingsmoment in formule steken
                DI_DO.AddTrainingsmoment(Dinsdag);
                DI_DO.AddTrainingsmoment(Donderdag);

                DI_ZA.AddTrainingsmoment(Dinsdag);
                DI_ZA.AddTrainingsmoment(Zaterdag);

                WO_ZA.AddTrainingsmoment(Woensdag);
                WO_ZA.AddTrainingsmoment(Zaterdag);

                WO.AddTrainingsmoment(Woensdag);

                ZA.AddTrainingsmoment(Zaterdag);

                //Gebruikers en corresponderende ASPUsers
                //--Leden met login
                Gebruiker lid1 = new Lid("LidMaxime", "maxime@gmail.com", "De Braekeleer", "Maxime", 'm',
                    new DateTime(1998, 02, 03), "België", "Gent", "Vossenlaan", "2", "Beerle", "9000",
                    "091234583", "Lid", "123456789", new DateTime(2019, 03, 05), "maxime@ouders.com", true, false, DI_DO);
                await CreateUser(lid1.Username, lid1.Email, "P@ssword1", "lid");

                Gebruiker lid2 = new Lid("LidMichael", "michael@gmail.com", "Vermassen", "Michael", 'm',
                    new DateTime(1997, 05, 14), "België", "Gent", "Laanstraat", "72", "Hasselt", "6547",
                    "094782662", "0470477701", "324754747", new DateTime(2019, 03, 09), "michael@ouders.com", true, true, DI_DO);
                await CreateUser(lid2.Username, lid2.Email, "P@ssword1", "lid");

                //--Leden zonder login
                Gebruiker lid3 = new Lid("Lid3", "Lid3@gmail.com", "Van Achteren", "Pol", 'm',
                    new DateTime(1997, 11, 05), "België", "Beerle", "Molenstraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "pol@ouders.com", true, false, ZA);

                Gebruiker lid4 = new Lid("Lid4", "Lid4@gmail.com", "Van Rechtsen", "Mark", 'm',
                    new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "mark@ouders.com", true, false, DI_DO);

                Gebruiker lid5 = new Lid("Lid5", "Lid5@gmail.com", "Van Linksen", "Louis", 'm',
                    new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "louis@ouders.com", true, false, DI_DO);

                Gebruiker lid6 = new Lid("Lid6", "Lid6@gmail.com", "Van Onderen", "Justine", 'v',
                    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "justine@ouders.com", true, false, DI_DO);

                Gebruiker lid7 = new Lid("Lid7", "Lid6@gmail.com", "Van Onderen", "Sien", 'v',
                    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, DI_DO);

                Gebruiker lid8 = new Lid("Lid8", "Lid8@gmail.com", "Van Schuinen", "Neeri", 'm',
                    new DateTime(1960, 08, 05), "Duitsland", "Passichi", "Jiaefestraat", "8", "Verdegem", "1234",
                    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, DI_DO);

                //--Lesgevers
                Gebruiker lesgever1 = new Lesgever("LesgeverHans", "hans@gmail.com", "Van Der Staak", "Hans", 'm',
                    new DateTime(1999, 08, 18), "België", "Gent", "Kerkstraat", "47", "Aalter", "1436",
                    "0978956147", "0478945159", "159487263", new DateTime(2019, 03, 09), null, false, false);
                await CreateUser(lesgever1.Username, lesgever1.Email, "P@ssword1", "lesgever");

                Gebruiker lesgever2 = new Lesgever("LesgeverDaan", "daan@gmail.com", "Van Vooren", "Daan", 'm',
                    new DateTime(1997, 01, 10), "België", "Gent", "Rijschootstraat", "32", "Ertvelde", "9040",
                    "093447501", "0470067701", "321654789", new DateTime(2019, 03, 06), null, true, true);
                await CreateUser(lesgever2.Username, lesgever2.Email, "P@ssword1", "lesgever");

                //--Toevoegen
                var gebruikers = new List<Gebruiker> {
                    lesgever1, lesgever2, lid1, lid2, lid3, lid4, lid5, lid6, lid7, lid8,
                };

                _dbContext.Gebruikers.AddRange(gebruikers);

                //Alles opslaan
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string userName, string email, string password, string role) {
            var user = new IdentityUser { UserName = userName, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
