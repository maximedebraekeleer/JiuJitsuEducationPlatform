using Microsoft.AspNetCore.Mvc.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Filters {
    public class GebruikerFilter : ActionFilterAttribute {
        private readonly IGebruikerRepository _gebruikerRepository;
        Gebruiker _gebruiker;

        public GebruikerFilter(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated) {
                _gebruiker = _gebruikerRepository.GetByUserName(context.HttpContext.User.Identity.Name);
                context.ActionArguments["gebruiker"] = _gebruiker;
            }
            base.OnActionExecuting(context);
        }
    }
}