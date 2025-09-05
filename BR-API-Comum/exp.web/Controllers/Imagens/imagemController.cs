using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    //[CustomAuthorize(Roles = "modificar")]
    public class imagemController : ApiController
    {
        //// GET api/menus
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;
            //string id = UserWebApiHelper.Id.ToString();
            //string Nome = UserWebApiHelper.Nome;
            //string Login = UserWebApiHelper.Login;
            //string Empresa = UserWebApiHelper.Empresa;
            var urlimg = string.Empty;
            if (File.Exists(SiteSettings.BR_PATH + "restrito\\content\\arquivos\\bens\\" + id))
                urlimg = "content/arquivos/bens/" + id;
            return Request.CreateResponse(HttpStatusCode.OK, urlimg);
        }
    }
}