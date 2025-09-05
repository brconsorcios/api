using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BrConsorcio.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Contrato")]
    public class ContratoController : Controller
    {
        private Exp_WebAPI _exp_webapi;
        private readonly BrConsorcioConfig brConsorcioConfig;

        public ContratoController(IOptions<Exp_WebAPI> exp_webapi, IOptions<BrConsorcioConfig> brConsorcioConfig)
        {
            _exp_webapi = exp_webapi.Value;
            this.brConsorcioConfig = brConsorcioConfig.Value;
        }

        [HttpGet]
        [Route("BuscarContratoGrupo")]
        public async Task<JsonResult> BuscarContratoGrupo(string grupo)
        {

            try
            {
                var http = new HttpHelpers(_exp_webapi.Url, _exp_webapi.Usuario, _exp_webapi.Senha);
                var resultado = await http.Get<ValidarGrupoResult>(string.Concat(_exp_webapi.ApiPasta, "/api/ValidarGrupo?grupo=" + grupo + ""), true);


                grupo = String.Concat(grupo, "downloadcontrato");
                grupo = grupo.toEncod64();
                string retorno = resultado.ST_Situacao;
                string link = String.Format("{0}/restrito/contratos/download/?id={1}&id_adm={2}&st_grupo={3}", brConsorcioConfig.Url, grupo, resultado.id_adm, resultado.ST_Situacao);
                return Json(new { retorno, link });
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
           
        }
    }
}