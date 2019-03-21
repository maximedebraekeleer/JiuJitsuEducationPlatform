using System;
using System.Collections.Generic;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Data {
    class DummyApplicationDbContext {
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
        public IEnumerable<Aanwezigheid> Aanwezigheden { get; set; }
        public IEnumerable<Formule> Formules { get; set; }
        public IEnumerable<Sessie> Sessies { get; set; }
        public IEnumerable<Trainingsmoment> Trainingsmomenten { get; set; }
        public IEnumerable<Graad> Graden { get; set; }

        public Trainingsmoment Dinsdag;
        public Trainingsmoment Woensdag;
        public Gebruiker lid3;
        public Gebruiker lid4;
        public Gebruiker lesgever1;
        public Gebruiker lesgever2;
        public Gebruiker gebruiker1;

        public DummyApplicationDbContext() {
            #region Trainingsmomenten
            //Trainingsmomenten (van site gehaald)
            Dinsdag = new Trainingsmoment(2, "Dinsdag", "18:00", "20:00");
            Woensdag = new Trainingsmoment(3, "Woensdag", "14:00", "15:30");
            Trainingsmoment Donderdag = new Trainingsmoment(4, "Donderdag", "18:00", "20:00");
            Trainingsmoment Zaterdag = new Trainingsmoment(6, "Zaterdag", "10:00", "11:30");

            //toevoegen aan lijst
            Trainingsmomenten = new[] { Dinsdag, Woensdag, Donderdag, Zaterdag };
            #endregion
            #region Formules
            //Formules (van powerpoint gehaald)
            Formule DI_DO = new Formule("DI_DO");
            Formule DI_ZA = new Formule("DI_ZA");
            Formule WO_ZA = new Formule("WO_ZA");
            Formule WO = new Formule("WO");
            Formule ZA = new Formule("ZA");

            //toevoegen aan lijst
            Formules = new[] { DI_DO, DI_ZA, WO_ZA, WO, ZA };
            #endregion

            #region Graden
            Graad graad1Kyu1 = new Graad(1, "Kyu1");
            Graad graad2Kyu2 = new Graad(2, "Kyu2");
            Graad graad3Dan1 = new Graad(3, "Dan1");
            Graad graad4Dan2 = new Graad(4, "Dan2");

            Graden = new[] { graad1Kyu1, graad2Kyu2, graad3Dan1, graad4Dan2 };
            #endregion

            #region Gebruikers
            //--Leden zonder login
            lid3 = new Lid("Lid0003", "Lid3@gmail.com", "Van Achteren", "Pol", 'm',
                new DateTime(1997, 11, 05), "België", "Beerle", "Molenstraat", "8", "Verdegem", "1234",
                "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "pol@ouders.com", true, false, ZA, graad1Kyu1);

            lid4 = new Lid("Lid0004", "Lid4@gmail.com", "Van Rechtsen", "Mark", 'm',
                new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "mark@ouders.com", true, false, DI_DO, graad2Kyu2);

            //Gebruiker lid5 = new Lid("Lid5", "Lid5@gmail.com", "Van Linksen", "Louis", 'm',
            //    new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
            //    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "louis@ouders.com", true, false, DI_DO, graad3Dan1);

            //Gebruiker lid6 = new Lid("Lid6", "Lid6@gmail.com", "Van Onderen", "Justine", 'v',
            //    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
            //    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "justine@ouders.com", true, false, DI_DO, graad4Dan2);

            //Gebruiker lid7 = new Lid("Lid7", "Lid6@gmail.com", "Van Onderen", "Sien", 'v',
            //    new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
            //    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, WO, graad1Kyu1);

            //Gebruiker lid8 = new Lid("Lid8", "Lid8@gmail.com", "Van Schuinen", "Neeri", 'm',
            //    new DateTime(1960, 08, 05), "Duitsland", "Passichi", "Jiaefestraat", "8", "Verdegem", "1234",
            //    "094834583", "0470477701", "123456789", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, WO_ZA, graad2Kyu2);

            //--Lesgevers
            lesgever1 = new Lesgever("LesgeverHans", "hans@gmail.com", "Van Der Staak", "Hans", 'm',
                new DateTime(1999, 08, 18), "België", "Gent", "Kerkstraat", "47", "Aalter", "1436",
                "0978956147", "0478945159", "159487263", new DateTime(2019, 03, 09), null, false, false);

            lesgever2 = new Lesgever("LesgeverDaan", "daan@gmail.com", "Van Vooren", "Daan", 'm',
                new DateTime(1997, 01, 10), "België", "Gent", "Rijschootstraat", "32", "Ertvelde", "9040",
                "093447501", "0470067701", "321654789", new DateTime(2019, 03, 06), null, true, true);

            //Gebruikers

            gebruiker1 = new Gebruiker {
                Username = "Gebruiker1",
                Email = "gebruiker@gmail.com",
                Naam = "Van Achter",
                Voornaam = "Jan",
                Geslacht = 'm',
                GeboorteDatum = new DateTime(1997, 11, 05),
                GeboorteLand = "Belgie",
                GeboorteStad = "Gent",
                Straat = "StationStraat",
                HuisNummer = "21",
                Gemeente = "Oostakker",
                Postcode = "9000",
                TelefoonNummer = "094834583", //Niet verplicht
                GsmNummer = "0470477701",
                RijksregisterNummer = "123456789",
                InschrijvingsDatum = new DateTime(2019, 03, 05),
                EmailOuders = "jan@ouders.com", //Niet verplicht
                InfoClubAangelegenheden = true,
                InfoFederaleAangelegenheden = false
            };


            //toevoegen aan lijst
            Gebruikers = new[] { lid3,lid4, /* lid5, lid6, lid7, lid8, lesgever1, lesgever2,*/ gebruiker1 };
            #endregion


            #region Sessies
            DateTime feb14 = new DateTime(2019, 02, 14, 18, 00, 00);//Les op een donderdag
            DateTime mar10 = new DateTime(2019, 03, 10, 14, 00, 00);//Les op woensdag
            Sessie sessie14_2 = new Sessie(feb14, feb14.AddMinutes(120), (Lesgever)lesgever1);
            Sessie sessie10_3 = new Sessie(mar10, mar10.AddMinutes(90), (Lesgever)lesgever2);
            //toevoegen aan lijst
            Sessies = new[] { sessie14_2, sessie10_3 };
            #endregion


            #region Aanwezigheden
            Aanwezigheid aanwezigheid3 = new Aanwezigheid((Lid)lid3, sessie14_2);
            Aanwezigheid aanwezigheid4 = new Aanwezigheid((Lid)lid4, sessie14_2);
            //Aanwezigheid aanwezigheid1 = new Aanwezigheid((Lid)lid7, sessie10_3);
            //Aanwezigheid aanwezigheid2 = new Aanwezigheid((Lid)lid8, sessie10_3);
            //toevoegen aan lijst
            Aanwezigheden = new[] {aanwezigheid3, aanwezigheid4};
            #endregion


        }
    }
}
