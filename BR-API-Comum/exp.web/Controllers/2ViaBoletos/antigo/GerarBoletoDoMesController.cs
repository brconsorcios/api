using System.Collections.Generic;
using System.Web.Http;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    public class GerarBoletoDoMesController : ApiController
    {
        //int site = UserWebApiHelper.Id;
        //string Nome = UserWebApiHelper.Nome;
        //string Login = UserWebApiHelper.Login;
        //int Empresa = Convert.ToInt32(UserWebApiHelper.Empresa);

        // private Entities01 db = new Entities01();

        // GET api/BuscaCidades
        public List<Boleto2ViaMensal> GetGerarBoletoDoMes(string cd_grupo, string cd_cota)
        {
            // db.ContextOptions.ProxyCreationEnabled = false;
            //exemplo de busca  http://localhost:45978/api/GerarBoletoDoMes/?cd_grupo=5023N&cd_cota=100

            var BoletoModelResult = new List<Boleto2ViaMensal>();
            BoletoModelResult = AcessoWebService.GerarBoletoDoMes(cd_grupo, cd_cota);

            return BoletoModelResult;
        }

        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}