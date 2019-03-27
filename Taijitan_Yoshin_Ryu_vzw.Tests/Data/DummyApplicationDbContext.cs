using System;
using System.Collections.Generic;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Tests.Data
{
    class DummyApplicationDbContext
    {
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
        public IEnumerable<Aanwezigheid> Aanwezigheden { get; set; }
        public IEnumerable<Formule> Formules { get; set; }
        public IEnumerable<Sessie> Sessies { get; set; }
        public Sessie HuidigeSessie { get; }
        public IEnumerable<Trainingsmoment> Trainingsmomenten { get; set; }
        public IEnumerable<Graad> Graden { get; set; }
        public IEnumerable<Commentaar> Commentaren { get; set; }

        public Trainingsmoment Dinsdag;
        public Trainingsmoment Woensdag;
        public Gebruiker lid1;
        public Gebruiker lid4;
        public Gebruiker lesgever1;
        public Gebruiker lesgever2;
        public Gebruiker gebruiker1;
        public Commentaar commentaar1;
        public Commentaar commentaar2;
        public Graad kyu6;
        public Aanwezigheid aanwezigheid3;

        public DummyApplicationDbContext()
        {
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
            Formule gast = new Formule("gast");
            //toevoegen aan lijst
            Formules = new[] { DI_DO, DI_ZA, WO_ZA, WO, ZA, gast };
            #endregion

            #region Graden
            kyu6 = new Graad(1, "6e kyu", "#ffffff");
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

            Graden = new[] { kyu6, kyu5, kyu4, kyu3, kyu2, kyu1, dan1, dan2, dan3, dan4, dan5 };
            #endregion

            #region Gebruikers
            //--Leden zonder login
            lid1 = new Lid("LidMaxime", "maxime@gmail.com", "De Braekeleer", "Maxime", 'm',
                    new DateTime(1998, 02, 03), "België", "Gent", "Vossenlaan", "2", "Beerle", "9000",
                    "", "0470011701", "97011033155", new DateTime(2019, 03, 05), "maxime@ouders.com", true, false,
                    DI_DO, kyu3);

            lid4 = new Lid("Lid0004", "Lid4@gmail.com", "Van Rechtsen", "Mark", 'm',
                new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                "+3291112211", "0470477701", "97011033155", new DateTime(2019, 03, 05), "mark@ouders.com", true, false, DI_DO, kyu2);

            Gebruiker lid5 = new Lid("Lid0005", "Lid5@gmail.com", "Van Linksen", "Louis", 'm',
                new DateTime(1997, 08, 05), "Japan", "Tokyo", "Jiaefstraat", "8", "Verdegem", "1234",
                "+3291112211", "0470477701", "97011033155", new DateTime(2019, 03, 05), "louis@ouders.com", true, false, DI_DO, kyu2);

            Gebruiker lid6 = new Lid("Lid0006", "Lid6@gmail.com", "Van Onderen", "Justine", 'v',
                new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                "+3291112211", "0470477701", "97011033155", new DateTime(2019, 03, 05), "justine@ouders.com", true, false, DI_DO, kyu2);

            Gebruiker lid7 = new Lid("Lid0007", "Lid6@gmail.com", "Van Onderen", "Sien", 'v',
                new DateTime(1997, 08, 05), "China", "Passichi", "Jiaefstraat", "8", "Verdegem", "1234",
                "+3291112211", "0470477701", "97011033155", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, WO, kyu3);

            Gebruiker lid8 = new Lid("Lid0008", "Lid8@gmail.com", "Van Schuinen", "Neeri", 'm',
                new DateTime(1960, 08, 05), "Duitsland", "Passichi", "Jiaefestraat", "8", "Verdegem", "1234",
                "+3291112211", "0470477701", "97011033155", new DateTime(2019, 03, 05), "sien@ouders.com", true, false, WO_ZA, kyu3);

            //--Lesgevers
            lesgever1 = new Lesgever("LesgeverHans", "hans@gmail.com", "Van Der Staak", "Hans", 'm',
                new DateTime(1999, 08, 18), "België", "Gent", "Kerkstraat", "47", "Aalter", "1436",
                "+3291112211", "0478945159", "97011033155", new DateTime(2019, 03, 09), null, false, false);

            lesgever2 = new Lesgever("LesgeverDaan", "daan@gmail.com", "Van Vooren", "Daan", 'm',
                new DateTime(1997, 01, 10), "België", "Gent", "Rijschootstraat", "32", "Ertvelde", "9040",
                "+3291112211", "0470067701", "97011033155", new DateTime(2019, 03, 06), null, true, true);

            //Gebruikers

            gebruiker1 = new Gebruiker
            {
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
                RijksregisterNummer = "97011033155",
                InschrijvingsDatum = new DateTime(2019, 03, 05),
                EmailOuders = "jan@ouders.com", //Niet verplicht
                InfoClubAangelegenheden = true,
                InfoFederaleAangelegenheden = false
            };


            //toevoegen aan lijst
            Gebruikers = new[] { lid1, lid4,  lid5, lid6, lid7, lid8, lesgever1, lesgever2, gebruiker1 };
            #endregion


            #region Sessies
            DateTime feb14 = new DateTime(2019, 02, 14, 18, 00, 00);//Les op een donderdag
            DateTime mar10 = new DateTime(2019, 03, 10, 14, 00, 00);//Les op woensdag
            Sessie sessie14_2 = new Sessie(feb14, feb14.AddMinutes(120), (Lesgever)lesgever1);
            Sessie sessie10_3 = new Sessie(mar10, mar10.AddMinutes(90), (Lesgever)lesgever2);
            //huidige sessie instellen 
            HuidigeSessie = sessie14_2;
            //toevoegen aan lijst
            Sessies = new[] { sessie14_2, sessie10_3 };
            #endregion


            #region Aanwezigheden
            aanwezigheid3 = new Aanwezigheid((Lid)lid1, sessie14_2);
            Aanwezigheid aanwezigheid4 = new Aanwezigheid((Lid)lid5, sessie14_2);
            Aanwezigheid aanwezigheid1 = new Aanwezigheid((Lid)lid7, sessie10_3);
            Aanwezigheid aanwezigheid2 = new Aanwezigheid((Lid)lid8, sessie10_3);
            //toevoegen aan lijst
            Aanwezigheden = new[] { aanwezigheid3, aanwezigheid4 };
            #endregion

            #region LesmateriaalThema

            LesmateriaalThema lesmateriaalThema1 = new LesmateriaalThema("Thema 1");
            LesmateriaalThema lesmateriaalThema2 = new LesmateriaalThema("Thema 2");
            #endregion

            #region Lesmateriaal

            Lesmateriaal lesmateriaal1 = new Lesmateriaal(kyu1, lesmateriaalThema1, "Lesmateriaal1", "wat tekst", "afbeelding", "video");
            Lesmateriaal lesmateriaal2 = new Lesmateriaal(dan1, lesmateriaalThema2, "Lesmateriaal2", "wat tekst", "afbeelding", "video");
            #endregion

            #region Commentaar
            commentaar1 = new Commentaar("Commentaar 1", (Lid)lid1, lesmateriaal1);
            commentaar2 = new Commentaar("Commentaar 2", (Lid)lid4, lesmateriaal2);

            Commentaren = new[] { commentaar1, commentaar2 };

            #endregion

        }
    }
}
