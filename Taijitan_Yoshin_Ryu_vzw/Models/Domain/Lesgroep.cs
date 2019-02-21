using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.Domain {
    public class Lesgroep {

        #region Fields
        private string _groepsnaam;
        #endregion

        #region Properties
        public string Groepsnaam {
            get => _groepsnaam;
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 45)
                    throw new ArgumentException("Groepsnaam kan niet leeg zijn of meer dan 45 caracters bevatten");
                _groepsnaam = value;
            }
        }
        #endregion

        #region Constructors
        public Lesgroep(string groepsnaam) {
            Groepsnaam = groepsnaam;
        }
        #endregion

        #region Methods

        #endregion
    }
}
