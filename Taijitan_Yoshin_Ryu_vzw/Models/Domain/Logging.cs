using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Logging
    {
        #region Properties
        public int Id { get; set;}
        public DateTime DatumTijdRaadplegen { get; set; }
        #endregion
        #region Relations
        public Lid Lid { get; set; }
        public Lesmateriaal Lesmateriaal { get; set; }
        #endregion
        #region Constructors
        public Logging()
        {
        }
        public Logging(Lid lid, Lesmateriaal lesmateriaal)
        {
            DatumTijdRaadplegen = DateTime.Now;
            Lid = lid;
            Lesmateriaal = lesmateriaal;
        }
        #endregion
    }
}
