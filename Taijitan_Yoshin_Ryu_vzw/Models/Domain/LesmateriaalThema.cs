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
        public string LesmateriaalThemaNaam { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<GraadLesmateriaalThema> GraadLesmateriaalThemas { get; set; }
        public IEnumerable<Graad> Graden => GraadLesmateriaalThemas.Select(l => l.Graad);

        public virtual ICollection<Lesmateriaal> Lesmaterialen { get; set; }
        #endregion

        #region Constructors
        public LesmateriaalThema()
        {
            GraadLesmateriaalThemas = new HashSet<GraadLesmateriaalThema>();
            Lesmaterialen = new List<Lesmateriaal>();
        }

        public LesmateriaalThema(string lesmateriaalThemaNaam) : this()
        {
            LesmateriaalThemaNaam = lesmateriaalThemaNaam;
        }
        #endregion

        #region Methods
        //public void AddLesmateriaal(Lesmateriaal lesmateriaal)
        //{
        //    Lesmaterialen.Add(lesmateriaal);
        //}

        public override string ToString()
        {
            return LesmateriaalThemaNaam;
        }
        #endregion
    }
}
