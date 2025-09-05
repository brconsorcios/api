using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    public class BuscaProfissoesController : ApiController
    {
        // GET api/BuscaCidades
        public List<BuscaProfissoesModel> GetBuscaProfissoes(string busca)
        {
            //exemplo de busca  http://localhost:45978/api/BuscaProfissoes/?busca=EMPRE
            var BuscaProfissoes = new List<BuscaProfissoesModel>();
            BuscaProfissoes = AcessoWebService.BuscaProfissoes(busca);
            return BuscaProfissoes.ToList();
        }
    }
}