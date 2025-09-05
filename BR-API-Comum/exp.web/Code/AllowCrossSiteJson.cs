using System.Web.Http.Filters;

public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Response != null)
        {
            actionExecutedContext.Response.Headers.Add("Access-Control-Request-Method", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Request-Headers", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
        }

        base.OnActionExecuted(actionExecutedContext);
    }
}