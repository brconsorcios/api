using System.Web.Mvc;
using System.Web.Routing;

namespace exp.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var namespacessite = new[] { "exp.web.Controllers" };

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespacessite
            );
        }
    }
}