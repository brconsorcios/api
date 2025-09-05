using System.Collections.Generic;
using System.Web.Http;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    public class ClienteCotasController : ApiController
    {
        public List<ClienteCotasModel> Get([FromUri] string id_pessoa)
        {
            return AcessoWebService.CotasCliente(id_pessoa);
        }
    }
}