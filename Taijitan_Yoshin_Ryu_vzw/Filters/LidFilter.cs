//using Microsoft.AspNetCore.Mvc.Filters;
//using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

//namespace Taijitan_Yoshin_Ryu_vzw.Filters {
//    public class LidFilter : ActionFilterAttribute {

//        private readonly ILidRepository _lidRepository;

//        public LidFilter(ILidRepository lidRepository) {
//            _lidRepository = lidRepository;
//        }

//        public override void OnActionExecuting(ActionExecutingContext context) {
//            Lid lid;
//            if (context.HttpContext.User.Identity.IsAuthenticated) {
//                lid = _lidRepository.GetByEmail(context.HttpContext.User.Identity.Name);

//                context.ActionArguments["lid"] = lid;
//            }
//            base.OnActionExecuting(context);

//        }
//    }
//}
