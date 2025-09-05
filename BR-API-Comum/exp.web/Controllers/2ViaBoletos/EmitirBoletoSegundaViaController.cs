using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using exp.core;
using exp.core.Utilitarios;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers
{
    public class EmitirBoletoSegundaViaController : ApiController
    {
        private string msg = string.Empty;
        private string path = string.Empty;

        [HttpPost]
        public HttpResponseMessage Post([FromBody] TransitoBoleto transito)
        {
            var msgerro = string.Empty;

            var id = transito.id_identificador.toDencod64();

            var EmissaoBoletoRetorno = new HttpResposta<string>();

            #region ===== LOG 1 =====

            //path = @"content/EmitirBoleto_LOG_w1.txt";
            //msg = "=========== EMITIR BOLETO ===========\r\n";
            //msg += "[ID]: " + id;

            //Logs.Save(path, msg);

            #endregion

            // CONFIRMAR EMISSAO DO BOLETO ANTES DE EMITIR
            var confirmacao =
                AcessoWebService.ComfirmarParcaleaSelecionadaBoleto(transito.cd_grupo, transito.cd_cota, id);

            if (!string.IsNullOrWhiteSpace(id) && confirmacao != null)
            {
                if (confirmacao.Return_Code == "0")
                {
                    var emissao = Boleto2Via.Emitir(Convert.ToInt32(id));

                    try
                    {
                        if (!string.IsNullOrEmpty(emissao))
                        {
                            // return Redirect("/content/boletos/" + novoboleto.none_do_pdf);

                            EmissaoBoletoRetorno.objeto = emissao; // novoboleto.none_do_pdf;

                            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, EmissaoBoletoRetorno);
                            //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));
                            //return response;

                            msgerro = "";
                        }
                        else
                        {
                            msgerro = "Não foi possível Gerar o boleto em PDF.";

                            //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                        }
                    }
                    catch (Exception e)
                    {
                        #region ===== LOG 2 =====

                        //path = @"content/EmitirBoleto_LOG_w2.txt";
                        //msg = "=========== EXCEPTION ===========\r\n";
                        //msg += "[EX]: " + e.ToString();

                        //Logs.Save(path, msg);

                        #endregion

                        msgerro = e.Message;

                        //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                    }
                }
                else
                {
                    msgerro = "Não foi possível confirmar a seleção da parcela.";
                    //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                }
            }
            else
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                msgerro = "Não foi Possível identificar.";
            }

            if (string.IsNullOrEmpty(msgerro))
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, EmissaoBoletoRetorno);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));
                return Request.CreateResponse(HttpStatusCode.OK, EmissaoBoletoRetorno);

            ModelState.AddModelError("emissao", msgerro);

            var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

            EmissaoBoletoRetorno.erros = errorList;

            return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
        }
    }
}