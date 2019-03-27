using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Filters
{
    public class LidFilter : ActionFilterAttribute
    {
        private readonly IGebruikerRepository _gebruikerRepository;
        Lid _gebruiker;

        public LidFilter(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                _gebruiker = (Lid)_gebruikerRepository.GetByUserName(context.HttpContext.User.Identity.Name);
                context.ActionArguments["gebruiker"] = _gebruiker;
            }
            base.OnActionExecuting(context);
        }
    }
}
