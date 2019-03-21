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
        public void voegAanwezigheidToe(Lid lid)
        {
            Aanwezigheden.Add(new Aanwezigheid(lid, this));
        }
        #endregion
    }
}
