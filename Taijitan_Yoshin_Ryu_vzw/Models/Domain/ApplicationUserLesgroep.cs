using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class ApplicationUserLesgroep {
        #region Properties
        public string ApplicationUser_Id { get; set; }
        public string Lesgroep_Groepsnaam { get; set; }
        #endregion

        #region Navigational Properties
        public ApplicationUser ApplicationUser { get; set; }
        public Lesgroep Lesgroep { get; set; }
        #endregion

        #region Constructors
        protected ApplicationUserLesgroep() {

        }

        public ApplicationUserLesgroep(ApplicationUser applicationUser, Lesgroep lesgroep) : this() {
            ApplicationUser = applicationUser;
            ApplicationUser_Id = ApplicationUser.Id;

            Lesgroep = lesgroep;
            Lesgroep_Groepsnaam = Lesgroep.Groepsnaam;
        }
        #endregion
    }
}
