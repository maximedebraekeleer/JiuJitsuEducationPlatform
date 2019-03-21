using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class Graad
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GraadId { get; set; }
        public string GraadNaam { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<GraadLesmateriaalThema> GraadLesmateriaalThemas { get; set; }
        public IEnumerable<LesmateriaalThema> LesmateriaalThemas => GraadLesmateriaalThemas.Select(g => g.LesmateriaalThema);
        #endregion

        #region Constructors
        public Graad()
        {
            GraadLesmateriaalThemas = new HashSet<GraadLesmateriaalThema>();
        }

        public Graad(int graadId, string graadNaam) : this()
        {
            GraadId = graadId;
            GraadNaam = graadNaam;
        }
        #endregion

        #region Methods
        public void AddLesmateriaalThema(params LesmateriaalThema[] list)
        {
            foreach(LesmateriaalThema l in list)
            {
                GraadLesmateriaalThemas.Add(new GraadLesmateriaalThema(this, l));
            }
        }

        public override string ToString()
        {
            return GraadNaam;
        }

        public GraadLesmateriaalThema GetLesmateriaalThemaByName(string Thema)
        {
            return GraadLesmateriaalThemas.Where(g => g.LesmateriaalThema.LesmateriaalThemaNaam == Thema).First();
        }

        public List<Lesmateriaal> GeefLesmateriaalMetThema(string Thema)
        {
            return LesmateriaalThemas.Where(l => l.LesmateriaalThemaNaam == Thema).First()
                .Lesmaterialen.Where(l => l.Graad == this).ToList();       
        }
        #endregion
    }
}
