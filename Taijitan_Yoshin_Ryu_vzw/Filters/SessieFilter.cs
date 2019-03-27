using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan_Yoshin_Ryu_vzw.Models.Domain;

namespace Taijitan_Yoshin_Ryu_vzw.Filters
{
    public class SessieFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;

        public SessieFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
                DateTime huidigeDatumEnUur = DateTime.Now;
                _sessie = _sessieRepository.GetByDatumEnUur(huidigeDatumEnUur);
                context.ActionArguments["huidigeSessie"] = _sessie;
            base.OnActionExecuting(context);
        }
    }
}
