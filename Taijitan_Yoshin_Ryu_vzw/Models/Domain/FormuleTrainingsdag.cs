using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class FormuleTrainingsdag {
        public int FormuleId { get; set; }
        public Formule Formule { get; set; }
        public int TrainingsdagId { get; set; }
        public Trainingsdag Trainingsdag { get; set; }

        public FormuleTrainingsdag() {

        }

        public FormuleTrainingsdag(Formule formule, Trainingsdag trainingsdag) : this() {
            Formule = formule;
            FormuleId = Formule.Id;

            Trainingsdag = trainingsdag;
            TrainingsdagId = Trainingsdag.Id;
        }
    }
}
