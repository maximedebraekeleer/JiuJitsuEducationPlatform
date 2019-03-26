using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Lesmateriaal
    {
        #region Properties
        public int Id { get; set; }
        public string Titel { get; set; }
        public string InhoudTekst { get; set; }
        public string InhoudAfbeeldingen { get; set; }
        public string InhoudVideo { get; set; }
        #endregion

        #region Relations
        public Graad Graad { get; set; }
        public LesmateriaalThema LesmateriaalThema { get; set; }
        public ICollection<Commentaar> Commentaren { get; set; }
        #endregion

        #region Constructor
        protected Lesmateriaal()
        {

        }

        public Lesmateriaal(Graad graad, LesmateriaalThema lesmateriaalThema, string titel, string inhoudTekst, string inhoudAfbeeldingen, string inhoudVideo)
        {
            Graad = graad;
            LesmateriaalThema = lesmateriaalThema;
            Titel = titel;
            InhoudTekst = inhoudTekst;
            InhoudAfbeeldingen = inhoudAfbeeldingen;
            InhoudVideo = inhoudVideo;
        }
        #endregion

        #region Methods
        public ICollection<string> geefAlleAfbeeldingen()
        {
            return InhoudAfbeeldingen.Split(',');
        }
        #endregion
    }
}
