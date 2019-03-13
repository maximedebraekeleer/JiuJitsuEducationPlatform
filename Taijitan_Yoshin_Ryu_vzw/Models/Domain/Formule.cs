using System;
using System.Collections.Generic;
using System.Linq;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Formule {
        #region Properties
        public int Id { get; set; } //Id is auto-increment
        public string FormuleNaam { get; set; }
        #endregion

        #region Collections
        public virtual ICollection<FormuleTrainingsmoment> FormuleTrainingsmomenten { get; set; }
        public IEnumerable<Trainingsmoment> Trainingsmomenten => FormuleTrainingsmomenten.Select(f => f.Trainingsmoment);

        public virtual ICollection<Lid> Leden { get; set; }
        #endregion

        #region Constructors
        public Formule() {
            FormuleTrainingsmomenten = new HashSet<FormuleTrainingsmoment>();
            Leden = new List<Lid>();
        }

        public Formule(string formuleNaam) : this() {
            FormuleNaam = formuleNaam;
        }
        #endregion

        #region Methods
        public void AddTrainingsmoment(Trainingsmoment trainingsmoment) {
            FormuleTrainingsmomenten.Add(new FormuleTrainingsmoment(this, trainingsmoment));
        }

        public bool bevatTrainingsmoment(Trainingsmoment trainingsmoment) {
            return Trainingsmomenten.Contains(trainingsmoment);
        }

        public override string ToString() {
            return FormuleNaam;
        }
        #endregion
    }
}
