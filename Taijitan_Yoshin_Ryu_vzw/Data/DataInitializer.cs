using Taijitan_Yoshin_Ryu_vzw.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taijitan_Yoshin_Ryu_vzw.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //Trainingsmomenten (van site gehaald)
                Trainingsmoment Dinsdag = new Trainingsmoment(2, "Dinsdag", "18:00", "20:00");
                Trainingsmoment Woensdag = new Trainingsmoment(3, "Woensdag", "14:00", "15:30");
                Trainingsmoment Donderdag = new Trainingsmoment(4, "Donderdag", "18:00", "20:00");
                Trainingsmoment Zaterdag = new Trainingsmoment(6, "Zaterdag", "10:00", "11:30");
                Trainingsmoment Zaterdag1 = new Trainingsmoment(6, "Zaterdag", "11:30", "13:00");
                Trainingsmoment Zondag = new Trainingsmoment(0, "Zondag", "10:00", "12:30");
                Trainingsmoment Develop = new Trainingsmoment(3, "Woensdag", "07:00", "23:59");


                var trainingsmomenten = new List<Trainingsmoment> {
                    Dinsdag, Woensdag, Donderdag, Zaterdag, Develop
                };
                _dbContext.Trainingsmomenten.AddRange(trainingsmomenten);

                //Formules (van powerpoint gehaald)
                Formule DI_DO = new Formule("DI_DO");
                Formule DI_ZA = new Formule("DI_ZA");
                Formule WO_ZA = new Formule("WO_ZA");
                Formule DI = new Formule("DI");
                Formule WO = new Formule("WO");
                Formule ZA = new Formule("ZA");
                Formule gast = new Formule("gast");

                Formule Develop1 = new Formule("Develop1");
                Formule Develop2 = new Formule("Develop2");

                var formules = new List<Formule> {
                    DI_DO, DI_ZA, WO_ZA, WO, ZA, gast, Develop1, Develop2
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

                Develop1.AddTrainingsmoment(Develop);
                Develop2.AddTrainingsmoment(Develop);
                Develop2.AddTrainingsmoment(Dinsdag);
                Develop2.AddTrainingsmoment(Zondag);

                //Lesmateriaal
                //1-Thema's toevoegen
                LesmateriaalThema thema1 = new LesmateriaalThema("Standen");
                LesmateriaalThema thema2 = new LesmateriaalThema("Aanvallen");
                LesmateriaalThema thema3 = new LesmateriaalThema("Worpen");

                var themas = new List<LesmateriaalThema> {
                    thema1, thema2, thema3
                };
                _dbContext.LesmateriaalThemas.AddRange(themas);

                //2-Graden toevoegen
                Graad kyu6 = new Graad(1, "6e kyu", "#ffffff");
                Graad kyu5 = new Graad(2, "5e kyu", "#e6d259");
                Graad kyu4 = new Graad(3, "4e kyu", "#dc8e4e");
                Graad kyu3 = new Graad(4, "3e kyu", "#8edb4f");
                Graad kyu2 = new Graad(5, "2e kyu", "#4eafda");
                Graad kyu1 = new Graad(6, "1e kyu", "#80371c");
                Graad dan1 = new Graad(7, "1e dan", "#000000");
                Graad dan2 = new Graad(8, "2e dan", "#000000");
                Graad dan3 = new Graad(9, "3e dan", "#000000");
                Graad dan4 = new Graad(10, "4e dan", "#000000");
                Graad dan5 = new Graad(11, "5e dan", "#000000");

                var graden = new List<Graad> {
                    kyu6, kyu5, kyu4, kyu3, kyu2, kyu1, dan1, dan2, dan3, dan4, dan5
                };
                _dbContext.Graden.AddRange(graden);

                kyu6.AddLesmateriaalThema(thema1, thema2, thema3);
                kyu5.AddLesmateriaalThema(thema1, thema2, thema3);
                kyu4.AddLesmateriaalThema(thema1, thema2, thema3);
                kyu3.AddLesmateriaalThema(thema1, thema2);
                kyu2.AddLesmateriaalThema(thema1, thema3);
                kyu1.AddLesmateriaalThema(thema1, thema2, thema3);
                dan1.AddLesmateriaalThema(thema1, thema2, thema3);
                dan2.AddLesmateriaalThema(thema1);
                dan3.AddLesmateriaalThema(thema1, thema2, thema3);
                dan4.AddLesmateriaalThema(thema3);
                dan5.AddLesmateriaalThema(thema2, thema3);

                //3-Lesmateriaal toevoegen
                Lesmateriaal lm1 = new Lesmateriaal(kyu3, thema1, "Lesmateriaal 1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "placeholder.jpg,placeholder.jpg,placeholder.jpg", "LW9X2fKjqCE");
                Lesmateriaal lm2 = new Lesmateriaal(kyu3, thema2, "Lesmateriaal 2", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "LW9X2fKjqCE");
                Lesmateriaal lm3 = new Lesmateriaal(kyu1, thema3, "Lesmateriaal 3", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "n6FpLqLLbxY");
                Lesmateriaal lm4 = new Lesmateriaal(kyu2, thema3, "Lesmateriaal 4", "UITLEG", "placeholder.jpg", "");
                Lesmateriaal lm5 = new Lesmateriaal(kyu2, thema1, "Lesmateriaal 5", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "eQF3wyz0-XA");
                Lesmateriaal lm6 = new Lesmateriaal(kyu3, thema2, "Lesmateriaal 6", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "", "QiC8jL90CFA");
                Lesmateriaal lm7 = new Lesmateriaal(kyu4, thema3, "Lesmateriaal 7", "UITLEG", "placeholder.jpg", "");
                Lesmateriaal lm8 = new Lesmateriaal(kyu5, thema1, "Lesmateriaal 8", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "j635OEznJVc");
                Lesmateriaal lm9 = new Lesmateriaal(kyu6, thema2, "Lesmateriaal 9", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "Q7SgyO0DNYs");
                Lesmateriaal lm10 = new Lesmateriaal(kyu6, thema3, "Lesmateriaal 10", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "4CNpMlF3pMs");
                Lesmateriaal lm11 = new Lesmateriaal(dan1, thema3, "Lesmateriaal 10", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg", "DXXE0Rs5EDY");
                Lesmateriaal lm12 = new Lesmateriaal(dan2, thema3, "Lesmateriaal 10", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "S99HTXM96go");
                Lesmateriaal lm13 = new Lesmateriaal(dan3, thema2, "Lesmateriaal 10", "UITLEG", "placeholder.jpg", "S99HTXM96go");
                Lesmateriaal lm14 = new Lesmateriaal(dan4, thema1, "Lesmateriaal 10", "UITLEG", "", "S99HTXM96go");
                Lesmateriaal lm15 = new Lesmateriaal(dan5, thema3, "Lesmateriaal 10", "UITLEG", "placeholder.jpg,placeholder.jpg,placeholder.jpg,placeholder.jpg", "S99HTXM96go");

                var lesmaterialen = new List<Lesmateriaal> {
                    lm1, lm2, lm3, lm4, lm5, lm6, lm7, lm8, lm9, lm10, lm11, lm12, lm13, lm14, lm15
                };
                _dbContext.Lesmaterialen.AddRange(lesmaterialen);

                //Gebruikers en corresponderende ASPUsers
                //--Leden met login
                Gebruiker lid1 = new Lid("LidMaxime", "maxime@gmail.com", "De Braekeleer", "Maxime", 'm',
                    new DateTime(1998, 02, 03), "België", "Gent", "Vossenlaan", "2", "Beerle", "9000",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "maxime@ouders.com", true, false,
                    Develop1, kyu3);
                await CreateUser(lid1.Username, lid1.Email, "P@ssword1", "lid");

                Gebruiker lid2 = new Lid("LidMichael", "michael@gmail.com", "Vermassen", "Michael", 'm',
                    new DateTime(1997, 05, 14), "België", "Gent", "Laanstraat", "72", "Hasselt", "6547",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 09), "michael@ouders.com", true, true,
                    Develop1, kyu4);
                await CreateUser(lid2.Username, lid2.Email, "P@ssword1", "lid");

                //--Leden zonder login
                Gebruiker lid3 = new Lid("Lid0003", "Lid3@gmail.com", "Pervool", "Pol", 'm',
                    new DateTime(1997, 11, 05), "België", "Beerle", "Molenstraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "pol@ouders.com", true, false,
                    Develop2, kyu4);

                Gebruiker lid4 = new Lid("Lid0004", "Lid4@gmail.com", "Van Spaendonck", "Mark", 'm',
                    new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "mark@ouders.com", true, false,
                    Develop2, kyu4);

                Gebruiker lid5 = new Lid("Lid0005", "Lid5@gmail.com", "De Neve", "Louis", 'm',
                    new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "louis@ouders.com", true, false,
                    Develop1, kyu4);

                Gebruiker lid6 = new Lid("Lid0006", "Lid6@gmail.com", "Van Hoven", "Justine", 'v',
                    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "justine@ouders.com", true, false,
                    Develop1, kyu3);

                Gebruiker lid7 = new Lid("Lid0007", "Lid6@gmail.com", "De Krem", "Sien", 'v',
                    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "sien@ouders.com", true, false,
                    Develop2, kyu5);

                Gebruiker lid8 = new Lid("Lid0008", "Lid8@gmail.com", "Van de Voorde", "Neeri", 'm',
                    new DateTime(1960, 08, 05), "Duitsland", "Passichi", "Jiaefestraat", "8", "Verdegem", "1234",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "sien@ouders.com", true, false,
                    Develop2, kyu5);

                //--Lesgevers
                Gebruiker lesgever1 = new Lesgever("LesgeverHans", "hans@gmail.com", "Van Der Staak", "Hans", 'm',
                    new DateTime(1999, 08, 18), "België", "Gent", "Kerkstraat", "47", "Aalter", "1436",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 09), "", false, false);
                await CreateUser(lesgever1.Username, lesgever1.Email, "P@ssword1", "lesgever");

                Gebruiker lesgever2 = new Lesgever("LesgeverDaan", "daan@gmail.com", "Van Vooren", "Daan", 'm',
                    new DateTime(1997, 01, 10), "België", "Gent", "Rijschootstraat", "32", "Ertvelde", "9040",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 06), "", true, true);
                await CreateUser(lesgever2.Username, lesgever2.Email, "P@ssword1", "lesgever");

                //--Toevoegen
                var gebruikers = new List<Gebruiker> {
                    lesgever1, lesgever2, lid1, lid2, lid3, lid4, lid5, lid6, lid7, lid8,
                };

                _dbContext.Gebruikers.AddRange(gebruikers);

                //--Commentaar
                _dbContext.Commentaren.Add(new Commentaar("nieuwe comment", (Lid)lid1, lm1));
                _dbContext.Commentaren.Add(new Commentaar("nog een comment", (Lid)lid1, lm1));
                _dbContext.Commentaren.Add(new Commentaar("derde comment", (Lid)lid2, lm7));
                _dbContext.Commentaren.Add(new Commentaar("vierde comment", (Lid)lid1, lm2));

                //Alles opslaan
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string userName, string email, string password, string role)
        {
            var user = new IdentityUser { UserName = userName, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
