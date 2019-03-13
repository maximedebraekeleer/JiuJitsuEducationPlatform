namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class FormuleTrainingsmoment {
        public int FormuleId { get; set; }
        public Formule Formule { get; set; }
        public int TrainingsmomentId { get; set; }
        public Trainingsmoment Trainingsmoment { get; set; }

        public FormuleTrainingsmoment() {

        }

        public FormuleTrainingsmoment(Formule formule, Trainingsmoment trainingsmoment) : this() {
            Formule = formule;
            FormuleId = Formule.Id;

            Trainingsmoment = trainingsmoment;
            TrainingsmomentId = Trainingsmoment.Id;
        }
    }
}
