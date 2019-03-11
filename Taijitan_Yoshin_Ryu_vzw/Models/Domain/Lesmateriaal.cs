using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Lesmateriaal
    {
        #region properties

        public int Id { get; set; }
        public string InhoudTekst { get; set; }
        public string InhoudAfbeeldingen { get; set; }
        public string InhoudVideo { get; set; }

        #endregion

        #region constructor

        public Lesmateriaal(string InhoudTekst, string InhoudAfbeeldingen, string InhoudVideo)
        {
            this.InhoudTekst = InhoudTekst;
            this.InhoudAfbeeldingen = InhoudAfbeeldingen;
            this.InhoudVideo = InhoudVideo;
        }

        #endregion

        #region methods

        public ICollection<string> geefAlleAfbeeldingen()
        {
            return this.InhoudAfbeeldingen.Split(',');
        }

        #endregion
    }
}
