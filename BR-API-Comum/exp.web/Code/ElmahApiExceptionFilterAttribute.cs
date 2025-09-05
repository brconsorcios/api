using System.Web.Http.Filters;
using Elmah;

namespace exp.web.Code
{
    public class ElmahApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}