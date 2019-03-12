using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class FormuleTrainingsdag {
        #region Properties
        public int Formule_Id { get; set; }
        public int Trainingsdag_Id { get; set; }
        #endregion

        #region Navigational Properties
        public Formule Formule { get; set; }
        public Trainingsdag Trainingsdag { get; set; }
        #endregion

        #region Constructors
        protected FormuleTrainingsdag() {

        }

        public FormuleTrainingsdag(Formule formume, Trainingsdag trainingsdag) : this() {
            Formule = formume;
            Formule_Id = Formule.Id;

            Trainingsdag = trainingsdag;
            Trainingsdag_Id = Trainingsdag.Id;
        }
        #endregion
    }
}
