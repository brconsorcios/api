using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers.Cadastro
{
    public class BuscaCidadeListaController : ApiController
    {
        public List<BuscaCidadesModel> GetbuscacidadesLista(string cidade, string uf)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;

            //exemplo de busca  http://localhost:45978/api/buscacidades/?cidade=LON&uf=PR

            var BuscaCidades = new List<BuscaCidadesModel>();

            BuscaCidades = AcessoWebService.BuscaCidades(cidade, uf);


            if (BuscaCidades != null && BuscaCidades.Count() > 0)
                //BuscaCidadesModel resultado = BuscaCidades.First();//q => q.NM_Cidade.ToLower().Contains(cidade.ToLower())
                return BuscaCidades;

            return new List<BuscaCidadesModel>();
        }

        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}