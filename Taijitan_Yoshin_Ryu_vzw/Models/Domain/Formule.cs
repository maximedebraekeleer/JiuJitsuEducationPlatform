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
        public ICollection<FormuleTrainingsdag> FormuleTrainingsdagen { get; private set; }
        public IEnumerable<Trainingsdag> Trainingsdagen => FormuleTrainingsdagen.Select(f => f.Trainingsdag);

        public ICollection<Lid> Leden { get; set; }
        #endregion

        #region Constructors
        protected Formule(){
            FormuleTrainingsdagen = new HashSet<FormuleTrainingsdag>();
            Leden = new List<Lid>();
        }

        public Formule(string formuleNaam) : this() {
            //Id = id;
            FormuleNaam = formuleNaam;
        }
        #endregion

        #region Methods
        public void addTrainingsdag(Trainingsdag trainingsdag) {
            FormuleTrainingsdagen.Add(new FormuleTrainingsdag(this, trainingsdag));
        }
        #endregion
    }
}
