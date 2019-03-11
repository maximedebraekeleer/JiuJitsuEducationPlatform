using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class LesmateriaalThema
    {
        #region properties

        public int Id { get; set; }
        public string Naam { get; set; }

        #endregion

        #region constructor

        public LesmateriaalThema(string Naam)
        {
            this.Naam = Naam;
        }

        #endregion
    }
}
