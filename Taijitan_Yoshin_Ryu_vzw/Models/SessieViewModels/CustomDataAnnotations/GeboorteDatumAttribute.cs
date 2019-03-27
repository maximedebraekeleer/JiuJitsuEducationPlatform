using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels.CustomDataAnnotations
{
    public class GeboorteDatumAttribute : ValidationAttribute
    {
        public GeboorteDatumAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (!(value is DateTime))
                return false;
            if (DateTime.Today.Year - ((DateTime)value).Year < 6)
                return false;
            if (DateTime.Compare((DateTime)value, (DateTime.Today).AddYears(-99)) < 0)
                return false;
            return true;
        }
    }
}
