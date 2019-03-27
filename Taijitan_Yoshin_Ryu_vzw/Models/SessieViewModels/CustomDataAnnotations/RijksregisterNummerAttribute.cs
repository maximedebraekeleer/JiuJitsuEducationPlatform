using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Taijitan_Yoshin_Ryu_vzw.Models.SessieViewModels.CustomDataAnnotations
{
    public class RijksregisterNummerAttribute : ValidationAttribute
    {
        public RijksregisterNummerAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            string nummer = (string)value;

            if (string.IsNullOrWhiteSpace(nummer))
                return false;

            Regex regex = new Regex(@"^\d{11}$");
            Match match = regex.Match(nummer);
            if (!match.Success)
                return false;

            int beginGetal = Int32.Parse(nummer.Substring(0, 9));
            int controleGetal = Int32.Parse(nummer.Substring(nummer.Length - 2));
            if (beginGetal % 97 != (97 - controleGetal))
                return false;

            return true;
        }
    }
}
