using Microsoft.AspNetCore.Mvc.Filters;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Filters {
    public class GebruikerFilter : ActionFilterAttribute {

        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerFilter(IGebruikerRepository gebruikerRepository) {
            _gebruikerRepository = gebruikerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            Gebruiker gebruiker;
            if (context.HttpContext.User.Identity.IsAuthenticated) {
                gebruiker = _gebruikerRepository.GetByEmail(context.HttpContext.User.Identity.Name);

                context.ActionArguments["gebruiker"] = gebruiker;
            }
            base.OnActionExecuting(context);

        }
    }
}