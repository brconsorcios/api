using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using exp.core;
using exp.core.Utilitarios;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers.API
{
    //  [CustomAuthorize(Roles = "consulta")]
    public class IdenticarGrupoCotaBoletoController : ApiController
    {
        //verificar grupo e cota e retornar identificados
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TransitoBoleto transito)
        {
            var IdenticarGrupoCotaRetorno = new HttpResposta<prcGeraBAParcelasResult>();

            var gcboleto = new prcGeraBAParcelasResult();

            try
            {
                gcboleto = AcessoWebService.IdenticarGrupoCotaBoleto(transito.cd_grupo.toDencod64(),
                    transito.cd_cota.toDencod64(), transito.versao.toDencod64());
                if (gcboleto != null)
                {
                    IdenticarGrupoCotaRetorno.objeto = gcboleto;
                    return Request.CreateResponse(HttpStatusCode.OK, IdenticarGrupoCotaRetorno);
                }

                ModelState.AddModelError("segundaviaboleto",
                    "Não foi possível identificar seu grupo e conta no momento, tente outra vez mais tarde.");

                var errorList = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

                IdenticarGrupoCotaRetorno.objeto = gcboleto;
                IdenticarGrupoCotaRetorno.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, IdenticarGrupoCotaRetorno);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("segundaviaboleto", e.Message);

                var errorList = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

                IdenticarGrupoCotaRetorno.objeto = gcboleto;
                IdenticarGrupoCotaRetorno.erros = errorList;

                #region ===== LOG 5 =====

                //path = "content/indicacao_LOG_5.txt";
                //msg = String.Empty;
                //foreach (var item in errorList)
                //{
                //    msg += String.Format("{0} = {1}\r\n", item.Key, item.Value);
                //}
                //Logs.Save(path, msg);

                #endregion

                return Request.CreateResponse(HttpStatusCode.BadRequest, IdenticarGrupoCotaRetorno);
            }
        }
    }
    
}