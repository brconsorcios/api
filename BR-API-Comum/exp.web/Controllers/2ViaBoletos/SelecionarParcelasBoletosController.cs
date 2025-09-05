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
    // [CustomAuthorize(Roles = "consulta")]
    public class SelecionarParcelasBoletosController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TransitoBoleto transito)
        {
            var IdenticarGrupoCotaRetorno = new HttpResposta<List<prcMarcaBAParcelaResult>>();

            var BoletoModelResult = new List<prcMarcaBAParcelaResult>();

            try
            {
                BoletoModelResult =
                    AcessoWebService.SelecionandoParcalaParaPagamentoBolerto(transito.id_identificador.toDencod64(),
                        transito.id_cobranca);

                if (BoletoModelResult != null)
                {
                    IdenticarGrupoCotaRetorno.objeto = BoletoModelResult;
                    return Request.CreateResponse(HttpStatusCode.OK, IdenticarGrupoCotaRetorno);
                }

                ModelState.AddModelError("segundaviaboleto",
                    "Não foi possível selecionar para gerar o boleto, tente outra vez mais tarde.");

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