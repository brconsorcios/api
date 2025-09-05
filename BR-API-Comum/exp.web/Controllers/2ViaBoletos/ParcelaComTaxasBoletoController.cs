using System;
using System.Collections.Generic;
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
    //[CustomAuthorize(Roles = "consulta")]
    public class ParcelaComTaxasBoletoController : ApiController
    {
        //verificar grupo e cota e retornar identificados
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TransitoBoleto transito)
        {
            var IdenticarGrupoCotaRetorno = new HttpResposta<List<resultadoParcelas>>();

            var BoletoModelResult = new List<resultadoParcelas>();

            try
            {
                BoletoModelResult = AcessoWebService.ParcelasComTaxasBoleto(transito.id_identificador.toDencod64());

                if (BoletoModelResult != null)
                {
                    IdenticarGrupoCotaRetorno.objeto = BoletoModelResult;
                    return Request.CreateResponse(HttpStatusCode.OK, IdenticarGrupoCotaRetorno);
                }

                ModelState.AddModelError("segundaviaboleto",
                    "Não foi possível identificar seu grupo e conta no momento, tente outra vez mais tarde.");

                var errorList = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

                IdenticarGrupoCotaRetorno.objeto = BoletoModelResult;
                IdenticarGrupoCotaRetorno.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, IdenticarGrupoCotaRetorno);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("segundaviaboleto", e.Message);

                var errorList = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

                IdenticarGrupoCotaRetorno.objeto = BoletoModelResult;
                IdenticarGrupoCotaRetorno.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, IdenticarGrupoCotaRetorno);
            }
        }
    }
}