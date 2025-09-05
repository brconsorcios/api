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

namespace exp.web.Controllers.Newsletter
{
    public class NewsletterController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post([FromBody] string email)
        {
            //string id = UserWebApiHelper.Id.ToString();
            //string Nome = UserWebApiHelper.Nome;
            //string Login = UserWebApiHelper.Login;
            var Empresa = UserWebApiHelper.Empresa;


            var
                path = string
                    .Empty;
            var msg = string.Empty;

            //Definindo de que site foi feito a indicação quando a emsma não for informada no objeto original

            var Respostaindicacao = new HttpResposta<string>();

            try
            {
                if (Funcao.EmailValido(email))
                {

                    Respostaindicacao.objeto = email;

                    return Request.CreateResponse(HttpStatusCode.Created, Respostaindicacao);
                }

                {
                    ModelState.AddModelError("email", "O Email ( " + email + " ) não é válido.");
                    //ModelState.AddModelError("email", e.Message); 

                    //---O FORMULÀRIO NÂO FOI VALIDADO-----------------------------------------------
                    var errorList = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                    Respostaindicacao.objeto = email;
                    Respostaindicacao.erros = errorList;

                    return Request.CreateResponse(HttpStatusCode.BadRequest, Respostaindicacao);
                    // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                Respostaindicacao.objeto = "";

                //var errorList = ModelState.ToDictionary(
                //kvp => kvp.Key,
                //kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                var errorList = new Dictionary<string, string[]>();
                errorList.Add("ERRO", new[] { "Não foi possível cadastrar o e-mail!" });

                Respostaindicacao.objeto = email;
                Respostaindicacao.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, Respostaindicacao);
            }
        }

        //[HttpGet]
        //public bool RemoverNewsletter(string Newsletter)
        //{
        //    return true;
        //}

        [HttpPost]
        public HttpResponseMessage RemoverNewsletter([FromBody] NewsletterModel Newsletter)
        {
            var Empresa = Convert.ToInt32(UserWebApiHelper.Empresa);

            var existe = true;
            var msg = string.Empty;
            var retorno = new HttpResposta<NewsletterModel>();
            retorno.objeto = Newsletter;

            //string[] modelo = new string[] { "", "", "" };

            //modelo[0] = email; // email
            //modelo[1] = Guid.NewGuid().ToString(); // link

            try
            {
                if (Funcao.EmailValido(Newsletter.email))
                {

                    retorno.objeto = Newsletter;

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }
                //ModelState.AddModelError("ERRO", "O Email ( " + email + " ) não é válido.");

                //var errorList = ModelState.ToDictionary(
                //kvp => kvp.Key,
                //kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                retorno.objeto = Newsletter;
                retorno.erros = new Dictionary<string, string[]>(); // errorList;

                retorno.erros.Add("ERRO", new[] { "E-mail inválido!" });

                return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception e)
            {
                retorno.objeto = Newsletter;

                var errorList = new Dictionary<string, string[]>();
                errorList.Add("ERRO", new[] { "Não foi possível realizar a operação!" });

                retorno.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);
            }
        }

        [HttpPost]
        public HttpResponseMessage JaEhCadastrado([FromBody] string email)
        {
            var Empresa = Convert.ToInt32(UserWebApiHelper.Empresa);

            var existe = true;
            var msg = string.Empty;
            var retorno = new HttpResposta<bool>();
            // retorno.objeto = existe;

            try
            {
                if (Funcao.EmailValido(email))
                {
                    
                    retorno.objeto = existe;

                    return Request.CreateResponse(HttpStatusCode.OK, retorno);
                }

                ModelState.AddModelError("email", "O Email ( " + email + " ) não é válido.");

                //---O FORMULÀRIO NÂO FOI VALIDADO-----------------------------------------------
                var errorList = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                retorno.objeto = existe;
                retorno.erros = new Dictionary<string, string[]>(); // errorList;

                retorno.erros.Add("ERRO", new[] { "E-mail inválido!" });

                return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception e)
            {
                retorno.objeto = existe;

                var errorList = new Dictionary<string, string[]>();
                errorList.Add("ERRO", new[] { "Não foi possível realizar a operação!" });

                //retorno.objeto = email;
                retorno.erros = errorList;

                return Request.CreateResponse(HttpStatusCode.BadRequest, retorno);
            }
        }
    }
}