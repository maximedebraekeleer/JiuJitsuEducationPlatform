using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Gebruiker
    {
        #region Fields
        private string _username; //Unieke waarde
        private string _email;
        private string _naam;
        private string _voornaam;
        private char _geslacht;
        private DateTime _geboorteDatum;
        private string _geboorteLand;
        private string _geboorteStad;
        private string _straat;
        private string _huisNummer;
        private string _gemeente;
        private string _postcode;
        private string _telefoonNummer; //Niet verplicht
        private string _gsmNummer;
        private string _rijksregisterNummer;
        private DateTime _inschrijvingsDatum;
        private string _emailOuders; //Niet verplicht
        #endregion


        #region Properties
        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                    throw new ArgumentException("Username/Username mag niet leeg zijn en moet minstens 7 karakters bevatten");
                _username = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email/E-mailadres mag niet leeg zijn");

                Regex regex = new Regex(@"[^@]+@.*\..*$");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Email/Ongeldig E-mailadres");

                _email = value;
            }
        }

        public string Naam
        {
            get => _naam;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naam/Naam mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("Naam/Naam mag geen cijfers bevatten");
                _naam = value;
            }
        }

        public string Voornaam
        {
            get => _voornaam;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Voornaam/Voornaam mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("Voornaam/Voornaam mag geen cijfers bevatten");
                _voornaam = value;
            }
        }

        public char Geslacht
        {
            get => _geslacht;
            set
            {
                if (value != 'm' && value != 'v')
                    throw new ArgumentException("Geslacht/Geslacht moet 'm' of 'v' zijn");
                _geslacht = value;
            }
        }

        public DateTime GeboorteDatum
        {
            get => _geboorteDatum;
            set
            {
                if (DateTime.Today.Year - value.Year < 6)
                    throw new ArgumentException("GeboorteDatum/Gebruiker moet minstens 6 jaar oud zijn");
                if (DateTime.Compare(value, (DateTime.Today).AddYears(-99)) < 0)
                    throw new ArgumentException("GeboorteDatum/Geboortedatum kan niet meer dan 99 jaar geleden zijn");
                _geboorteDatum = value;
            }
        }

        public string GeboorteLand
        {
            get => _geboorteLand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("GeboorteLand/Geboorteland mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("GeboorteLand/Geboorteland mag geen cijfers bevatten");
                _geboorteLand = value;
            }
        }

        public string GeboorteStad
        {
            get => _geboorteStad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("GeboorteStad/Geboortestad mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("GeboorteStad/Geboortestad mag geen cijfers bevatten");
                _geboorteStad = value;
            }
        }

        public string Straat
        {
            get => _straat;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Straat/Straat mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("Straat/Straat mag geen cijfers bevatten");
                _straat = value;
            }
        }

        public string HuisNummer
        {
            get => _huisNummer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("HuisNummer/Huisnummer mag niet leeg zijn");

                Regex regex = new Regex(@"^[0-9]+[a-zA-Z]*");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("HuisNummer/Ongeldig huisnummer");
                _huisNummer = value;
            }
        }

        public string Gemeente
        {
            get => _gemeente;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gemeente/Gemeente mag niet leeg zijn");

                Regex regex = new Regex(@"\d");
                Match match = regex.Match(value);
                if (match.Success)
                    throw new ArgumentException("Gemeente/Gemeente mag geen cijfers bevatten");
                _gemeente = value;
            }
        }

        public string Postcode
        {
            get => _postcode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Postcode/Postcode mag niet leeg zijn");

                Regex regex = new Regex(@"^\d{4}$");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Postcode/Postcode moet uit vier cijfers bestaan");
                _postcode = value;
            }
        }

        public string TelefoonNummer
        {
            get => _telefoonNummer;
            set
            {
                //Mag leeg zijn
                if (value != null)
                {
                    Regex regex = new Regex(@"^\d{9}$|^\+\d{10}$|^$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                        throw new ArgumentException("TelefoonNummer/Ongeldig telefoonnummer");
                }

                _telefoonNummer = value;
            }
        }

        public string GsmNummer
        {
            get => _gsmNummer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("GsmNummer/Gsmnummer mag niet leeg zijn");

                Regex regex = new Regex(@"^\d{10}$|^\+\d{11}$");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("GsmNummer/Ongeldig GSM-nummer");
                _gsmNummer = value;
            }
        }

        public string RijksregisterNummer
        {
            get => _rijksregisterNummer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("RijksregisterNummer/Rijksregisternummer mag niet leeg zijn");

                Regex regex = new Regex(@"^\d{11}$");
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new ArgumentException("RijksregisterNummer/Ongeldig Rijksregisternummer");

                int beginGetal = Int32.Parse(value.Substring(0, 9));
                int controleGetal = Int32.Parse(value.Substring(value.Length - 2));
                if (beginGetal % 97 != (97 - controleGetal))
                    throw new ArgumentException("RijksregisterNummer/Ongeldig Rijksregisternummer");

                _rijksregisterNummer = value;
            }
        }

        public DateTime InschrijvingsDatum
        {
            get => _inschrijvingsDatum;
            set
            {
                if (DateTime.Compare(value, DateTime.Today) > 0)
                    throw new ArgumentException("InschrijvingsDatum/InschrijvingsDatum kan niet ouder zijn dan vandaag");
                _inschrijvingsDatum = value;
            }
        }

        public string EmailOuders
        {
            get => _emailOuders;
            set
            {
                if (value != null)
                {
                    Regex regex = new Regex(@"[^@]+@.*\..*$|^$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                        throw new ArgumentException("EmailOuders/Ongeldig E-mailadres");
                }

                _emailOuders = value;
            }
        }

        public bool InfoClubAangelegenheden { get; set; }
        public bool InfoFederaleAangelegenheden { get; set; }
        #endregion

        #region Constructors
        public Gebruiker()
        {
        }

        public Gebruiker(string username, string email, string naam, string voornaam, char geslacht, DateTime geboorteDatum,
            string geboorteLand, string geboorteStad, string straat, string huisNummer, string gemeente,
            string postcode, string telefoonNummer, string gsmNummer, string rijksregisterNummer, DateTime inschrijvingsDatum,
            string emailOuders, bool infoClubAangelegenheden, bool infoFederaleAangelegenheden)
        {
            Username = username;
            Email = email;
            Naam = naam;
            Voornaam = voornaam;
            Geslacht = geslacht;
            GeboorteDatum = geboorteDatum;
            GeboorteLand = geboorteLand;
            GeboorteStad = geboorteStad;
            Straat = straat;
            HuisNummer = huisNummer;
            Gemeente = gemeente;
            Postcode = postcode;
            TelefoonNummer = telefoonNummer; //Niet verplicht
            GsmNummer = gsmNummer;
            RijksregisterNummer = rijksregisterNummer;
            InschrijvingsDatum = inschrijvingsDatum;
            EmailOuders = emailOuders; //Niet verplicht
            InfoClubAangelegenheden = infoClubAangelegenheden;
            InfoFederaleAangelegenheden = infoFederaleAangelegenheden;
            //if (Errors.Count > 0)
            //{
            //    throw new GebruikerGegevensException(Errors);
            //}
        }
        #endregion
    }
}