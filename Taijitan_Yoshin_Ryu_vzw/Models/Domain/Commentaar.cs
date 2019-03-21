using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Commentaar
    {
        #region Properties
        public int Id { get; set; }
        public string Inhoud { get; set; }
        public bool IsNew { get; set; }
        #endregion

        #region Relations
        public Lid Lid { get; set; }
        public Lesmateriaal Lesmateriaal { get; set; }
        #endregion

        #region Constructors
        public Commentaar(string inhoud, Lid lid, Lesmateriaal lesmateriaal)
        {
            Inhoud = inhoud;
            Lid = lid;
            Lesmateriaal = lesmateriaal;
            IsNew = true;
        }
        public Commentaar()
        {
        }
        #endregion
        #region Methods
        public void markeerGezien()
        {
            IsNew = false;
        }
        #endregion
    }
}
