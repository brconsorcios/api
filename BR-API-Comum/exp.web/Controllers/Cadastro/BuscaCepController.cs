using System.Web.Http;
using exp.dados;
using exp.web.Code;
//using System.Data.Entity.Infrastructure;

namespace exp.web.Controllers.API
{
    public class BuscaCepController : ApiController
    {
        // private Entities01 db = new Entities01();

        // GET api/BuscaCidades
        public BuscaCepModel Get([FromUri] string cep)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;

            //exemplo de busca  http://localhost:45978/api/buscacep/?cep=86020030

            var resultado = new BuscaCepModel();

            if (!string.IsNullOrEmpty(cep)) resultado = AcessoWebService.BuscaCep(cep);

            return resultado;
        }

        public BuscaCepModel Post([FromUri] string cep)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;

            //exemplo de busca  http://localhost:45978/api/buscacep/?cep=86020030

            var resultado = new BuscaCepModel();

            if (!string.IsNullOrEmpty(cep)) resultado = AcessoWebService.BuscaCep(cep);

            return resultado;
        }

        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}