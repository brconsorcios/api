using System.Web;
using System.Web.Mvc;

namespace exp.core.Utilitarios
{
    public class DisabledAttribute : ActionFilterAttribute
    {
        public DisabledAttribute()
        {
            Order = 0;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new HttpException(404, "Página desabilitada.");
        }
    }
}