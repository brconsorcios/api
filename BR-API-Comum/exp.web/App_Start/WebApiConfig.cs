using System.Web.Http;
using exp.web.Code;

namespace exp.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var namespacessite = new[] { "exp.web.Controllers.API" };

            config.Filters.Add(new RollbarExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                //routeTemplate: "{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ElmahApiExceptionFilterAttribute());
        }
    }
}