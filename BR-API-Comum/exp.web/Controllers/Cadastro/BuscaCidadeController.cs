using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using exp.dados;
using exp.web.Code;
//using System.Data.Entity.Infrastructure;

namespace exp.web.Controllers.API
{
    public class BuscaCidadeController : ApiController
    {
        // private Entities01 db = new Entities01();

        // GET api/BuscaCidades
        public BuscaCidadesModel Getbuscacidades(string cidade, string uf)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;

            //exemplo de busca  http://localhost:45978/api/buscacidades/?cidade=LON&uf=PR

            var BuscaCidades = new List<BuscaCidadesModel>();

            BuscaCidades = AcessoWebService.BuscaCidades(cidade, uf);


            if (BuscaCidades != null && BuscaCidades.Count() > 0)
            {
                var resultado = BuscaCidades.First(); //q => q.NM_Cidade.ToLower().Contains(cidade.ToLower())
                return resultado;
            }

            return new BuscaCidadesModel();
        }


        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}