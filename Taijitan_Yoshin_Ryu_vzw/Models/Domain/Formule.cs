using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Formule {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public string FormuleNaam { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<FormuleTrainingsdag> FormuleTrainingsdagen { get; set; }
        public IEnumerable<Trainingsdag> Trainingsdagen => FormuleTrainingsdagen.Select(f => f.Trainingsdag);

        public virtual ICollection<Lid> Leden { get; set; }
        #endregion

        #region Constructors
        public Formule(){
            FormuleTrainingsdagen = new HashSet<FormuleTrainingsdag>();
            Leden = new List<Lid>();
        }

        public Formule(string formuleNaam) : this() {
            FormuleNaam = formuleNaam;
        }
        #endregion

        #region Methods
        public void AddTrainingsdag(Trainingsdag trainingsdag) {
            FormuleTrainingsdagen.Add(new FormuleTrainingsdag(this, trainingsdag));
        }

        public bool bevatTrainingsdag(int dagNummer) {
            bool res = false;
            foreach(Trainingsdag dag in Trainingsdagen) {
                if (dag.DagNummer == dagNummer)
                    res = true;
            }
            return res;
        }

        public override string ToString() {
            return FormuleNaam;
        }
        #endregion
    }
}
