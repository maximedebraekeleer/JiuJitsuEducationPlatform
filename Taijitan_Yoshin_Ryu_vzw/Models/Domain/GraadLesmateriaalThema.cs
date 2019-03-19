using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain
{
    public class GraadLesmateriaalThema
    {
        public int GraadId { get; set; }
        public Graad Graad { get; set; }
        public int LesmateriaalThemaId { get; set; }
        public LesmateriaalThema LesmateriaalThema { get; set; }

        public GraadLesmateriaalThema()
        {

        }

        public GraadLesmateriaalThema(Graad graad, LesmateriaalThema lesmateriaalThema) : this()
        {
            Graad = graad;
            GraadId = Graad.GraadId;

            LesmateriaalThema = lesmateriaalThema;
            LesmateriaalThemaId = LesmateriaalThema.Id;
        }
    }
}
