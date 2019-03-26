using System;
using System.Collections.Generic;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Sessie
    {
        #region Regions
        private DateTime _beginDatumEnTijd;
        private DateTime _eindDatumEnTijd;
        private Lesgever _lesgever;
        #endregion

        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public DateTime BeginDatumEnTijd
        {
            get => _beginDatumEnTijd;
            set => _beginDatumEnTijd = value;
        }

        public DateTime EindDatumEnTijd
        {
            get => _eindDatumEnTijd;
            set
            {
                if (DateTime.Compare(value, BeginDatumEnTijd) < 0)
                    throw new ArgumentException("Einddatum en Tijd kan niet voor Begindatum en Tijd liggen");
                _eindDatumEnTijd = value;
            }
        }

        public Lesgever Lesgever
        {
            get => _lesgever;
            set
            {
                _lesgever = value ?? throw new ArgumentException("Lesgever mag niet leeg zijn");
            }
        }
        #endregion

        #region Collections
        public ICollection<Aanwezigheid> Aanwezigheden { get; set; }
        #endregion

        #region Constructors
        public Sessie()
        {
            Aanwezigheden = new List<Aanwezigheid>();
        }

        public Sessie(DateTime beginDatumEnTijd, DateTime eindDatumEnTijd, Lesgever lesgever) : this()
        {
            BeginDatumEnTijd = beginDatumEnTijd;
            EindDatumEnTijd = eindDatumEnTijd;
            Lesgever = lesgever;
        }
        #endregion

        #region Methods
        public void VoegAanwezigheidToe(Lid lid, Boolean extraAanwezigheid)
        {
            Aanwezigheden.Add(new Aanwezigheid(lid, this, extraAanwezigheid));
        }

        public List<Lid> GeefExtraAanwezigeLeden()
        {
            List<Lid> extraAanwezigheden = new List<Lid>();
            foreach(var aanwezigheid in Aanwezigheden)
            {
                if(aanwezigheid.IsExtra)
                extraAanwezigheden.Add(aanwezigheid.Lid);
            }

            return extraAanwezigheden;
        }

        public List<Lid> GeefAanwezigeLeden()
        {
            List<Lid> aanwezigheden = new List<Lid>();
            foreach (var aanwezigheid in Aanwezigheden)
            {
                aanwezigheden.Add(aanwezigheid.Lid);
            }
            return aanwezigheden;
        }

        public void ClearAanwezigheden()
        {
            Aanwezigheden.Clear();
        }

        public bool bevatDatumEnTijd(DateTime datumEnUur)
        {
            return datumEnUur >= BeginDatumEnTijd.Date && datumEnUur <= EindDatumEnTijd.Date;
        }
        #endregion
    }
}
