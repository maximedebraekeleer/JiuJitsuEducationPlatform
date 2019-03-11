using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Trainingsdag {
        #region Properties
        public int DagId { get; set; }
        public string BeginUur { get; set; }
        public string EindUur { get; set; }
        public string DagNaam { get; set; }
        #endregion

        #region Collections
        public ICollection<FormuleTrainingsdag> FormuleTrainingsdagen{ get; private set; }
        public IEnumerable<Formule> Formules => FormuleTrainingsdagen.Select(f => f.Formule);
        #endregion

        #region Constructors
        protected Trainingsdag() {
            FormuleTrainingsdagen = new HashSet<FormuleTrainingsdag>();
        }

        public Trainingsdag(int dagId, string beginUur, string eindUur, string dagNaam) : this() {
            DagId = dagId;
            BeginUur = beginUur;
            EindUur = eindUur;
            DagNaam = dagNaam;
        }
        #endregion

        #region Methods
        public void AddFormume(Formule f) {
            FormuleTrainingsdagen.Add(new FormuleTrainingsdag(f, this));
        }

        //LATER
        //public DateTime geefDatumMetbeginUur(){
        //    var dateStr = "14:00";
        //    var dateTime = DateTime.ParseExact(dateStr, "H:mm", null, System.Globalization.DateTimeStyles.None);
        //}
        #endregion
    }
}
