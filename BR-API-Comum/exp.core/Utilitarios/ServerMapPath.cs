using System.Web;
using System.Web.Hosting;

namespace exp.core.Utilitarios
{
    public class ServerMap
    {
        public static string Path(string path)
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath(path);

            return HostingEnvironment.MapPath(path);
        }
    }
}