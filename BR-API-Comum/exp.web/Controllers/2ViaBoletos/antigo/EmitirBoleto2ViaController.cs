using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using exp.core.Utilitarios;
using exp.dados;
using exp.web.Code;

namespace exp.web.Controllers
{
    public class EmitirBoleto2ViaController : ApiController
    {
        private string msg = string.Empty;
        private string path = string.Empty;

        [HttpPost]
        public HttpResponseMessage PostEmitirBoleto2Via([FromUri] int id) //
        {
            var EmissaoBoletoRetorno = new HttpResposta<string>();

            #region ===== LOG 1 =====

            //path = @"content/AAAAAAEmitirBoleto_LOG_w1.txt";
            //msg = "=========== EMITIR BOLETO ===========\r\n";
            //msg += "[ID]: " + id;

            //Logs.Save(path, msg);

            #endregion

            if (id != null)
                try
                {
                    var emissao = Boleto2Via.Emitir(id);

                    if (!string.IsNullOrEmpty(emissao))
                    {
                        // return Redirect("/content/boletos/" + novoboleto.none_do_pdf);
                        EmissaoBoletoRetorno.objeto = emissao; // novoboleto.none_do_pdf;

                        var response = Request.CreateResponse(HttpStatusCode.Created, EmissaoBoletoRetorno);
                        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id }));

                        return response;
                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                }
                catch (Exception e)
                {
                    #region ===== LOG 2 =====

                    path = @"content/ERRO_EmitirBoleto_LOG_w2.txt";
                    msg = "=========== EXCEPTION ===========\r\n";
                    msg += "[EX]: " + e + "\n";
                    msg += "[EXCEPTION]: " + e.InnerException + "\n";
                    msg += "[TRACE]: " + e.StackTrace + "\n";

                    Logs.Save(path, msg);

                    #endregion

                    return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
                }

            //}
            //else
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
            //}
            return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
        }
    }


    #region ###  ###

    ////[CustomAuthorize(Roles = "modificar")]
    //public class EmitirBoleto2ViaController : ApiController
    //{
    //    string path = String.Empty;
    //    string msg = String.Empty;

    //    private Entities01 db = new Entities01();

    //    [HttpPost]
    //    public HttpResponseMessage Post([FromBody] TransitoBoleto transito)
    //    {
    //        db.ContextOptions.ProxyCreationEnabled = false;

    //        string msgerro = string.Empty;

    //        string id = transito.id_identificador.toDencod64();

    //        var EmissaoBoletoRetorno = new HttpResposta<string>();

    //        #region ===== LOG 1 =====

    //        //path = @"content/EmitirBoleto_LOG_w1.txt";
    //        //msg = "=========== EMITIR BOLETO ===========\r\n";
    //        //msg += "[ID]: " + id;

    //        //Logs.Save(path, msg);

    //        #endregion

    //        // CONFIRMAR EMISSAO DO BOLETO ANTES DE EMITIR
    //        var confirmacao = AcessoWebService.ComfirmarParcaleaSelecionadaBoleto(transito.cd_grupo, transito.cd_cota, id);

    //        if (!String.IsNullOrWhiteSpace(id) && confirmacao != null)
    //        {


    //            if (confirmacao.Return_Code == "0")
    //            {
    //                string emissao = Boleto2Via.Emitir(Convert.ToInt32(id));

    //                try
    //                {
    //                    if (!string.IsNullOrEmpty(emissao))
    //                    {
    //                        // return Redirect("/content/boletos/" + novoboleto.none_do_pdf);

    //                        EmissaoBoletoRetorno.objeto = emissao;// novoboleto.none_do_pdf;

    //                        //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, EmissaoBoletoRetorno);
    //                        //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));
    //                        //return response;

    //                        msgerro = "";

    //                    }
    //                    else
    //                    {
    //                        msgerro = "Não foi possível Gerar o boleto em PDF.";

    //                        //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
    //                    }
    //                }
    //                catch (Exception e)
    //                {
    //                    #region ===== LOG 2 =====

    //                    //path = @"content/EmitirBoleto_LOG_w2.txt";
    //                    //msg = "=========== EXCEPTION ===========\r\n";
    //                    //msg += "[EX]: " + e.ToString();

    //                    //Logs.Save(path, msg);

    //                    #endregion

    //                    msgerro = e.Message;

    //                    //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
    //                }

    //            }
    //            else
    //            {
    //                msgerro = "Não foi possível confirmar a seleção da parcela.";
    //                //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
    //            }

    //        }
    //        else
    //        {
    //            //return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
    //            msgerro = "Não foi Possível identificar.";
    //        }

    //        if (string.IsNullOrEmpty(msgerro))
    //        {

    //            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, EmissaoBoletoRetorno);
    //            //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = id }));


    //            return Request.CreateResponse(HttpStatusCode.OK, EmissaoBoletoRetorno);
    //        }
    //        else
    //        {


    //            ModelState.AddModelError("emissao", msgerro);

    //            var errorList = ModelState.ToDictionary(
    //                kvp => kvp.Key,
    //                kvp => kvp.Value.Errors.Select(b => b.ErrorMessage).ToArray());

    //            EmissaoBoletoRetorno.erros = errorList;

    //            return Request.CreateResponse(HttpStatusCode.BadRequest, EmissaoBoletoRetorno);
    //        }

    //    }


    //    protected override void Dispose(bool disposing)
    //    {
    //        db.Dispose();
    //        base.Dispose(disposing);
    //    }
    //}

    #endregion
}