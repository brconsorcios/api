using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BrConsorcio.Api.Services;
using System.Threading.Tasks;
using BrConsorcio.Api.Models;
using System.Linq;
using System;
using BrConsorcio.Api.Helpers;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;
using BrConsorcio.Api.Services.Interfaces;
using MimeKit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrConsorcio.Api.Controllers
{
    [Authorize(Policy = "User")]
    [Route("api/[controller]")]
    public class ConsorciadoController : Controller
    {
        private readonly IEmailService _emailservice;
        private Exp_WebAPI _exp_webapi;
        private BRApi _BRApi;

        public ConsorciadoController(IEmailService emailservice, IOptions<Exp_WebAPI> exp_webapi, IOptions<BRApi> BRApi)

        {
            _emailservice = emailservice;
            _exp_webapi = exp_webapi.Value;
            _BRApi = BRApi.Value;
        }

        //AssembleiaDoMes
        [HttpGet]
        [Route("BuscarCotasCanceladas")]
        public JsonResult BuscarCotasCanceladas(string data, string grupo)
        {
            var http = new HttpHelpers(_exp_webapi.Url, _exp_webapi.Usuario, _exp_webapi.Senha);
            var resultado = http.Get<List<AssembleiaCotaResult>>(string.Concat(_exp_webapi.ApiPasta, "/api/Assembleia/Cotas?data=", data, "&grupo=", grupo), true);

            return Json(resultado.Result);
        }

        
        [HttpGet]
        [Route("BuscarAssembleiasDoMes")]
        public JsonResult BuscarAssembleiasDoMes(string mes, string ano, string cdGrupo)
        {
            string parametro;
            if (cdGrupo != null && cdGrupo != "")
            {
                parametro = string.Concat("mes=", mes, "&ano=", ano, "&cdGrupo=", cdGrupo);
            }
            else
            {
                parametro = string.Concat("mes=", mes, "&ano=", ano);
            }
            var http = new HttpHelpers(_exp_webapi.Url, _exp_webapi.Usuario, _exp_webapi.Senha);

            //var resultado = http.Get<List<AssembleiaDoMes>>(string.Concat(_exp_webapi.ApiPasta, "/api/Assembleia/AssembleiasDoMes?mes=", mes, "&ano=", ano),true);
            var resultado = http.Get<List<AssembleiaDoMes>>(string.Concat(_exp_webapi.ApiPasta, "/api/Assembleia/AssembleiasDoMes?", parametro), true);
            return Json(resultado.Result);
        }


        [HttpGet]
        [Route("BuscaOfertaLanceHistorico")]
        public IEnumerable<OfertaLanceHistorico> BuscaOfertaLanceHistorico(string ID_Cota)
        {
            //var http = new HttpHelpers(_exp_webapi.Url, _exp_webapi.Usuario, _exp_webapi.Senha);

            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
            var listaOfertaLanceHistorico = new List<OfertaLanceHistorico>();
            HttpClient client;
            client = new HttpClient();
            
            client.BaseAddress = new Uri(_BRApi.Url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format( "{0}api/GetHistoricosOfertaLance?ID_Cota={1}", _BRApi.ApiPasta, ID_Cota)).Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                //usuarioUri = response.Headers.Location;
                string retorno = response.Content.ReadAsStringAsync().Result;
                string json = JsonConvert.DeserializeObject<string>(retorno);
                dynamic Array = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach (var item in Array)
                {
                    listaOfertaLanceHistorico.Add(new OfertaLanceHistorico
                    {
                        ID = item.ID,
                        LanceStatus = item.SN_Ativo == "S" ? "Ativo" : "Cancelado",
                        DataOferta = item.DH_Credenciamento.ToString("dd/MM/yyyy"),
                        DataAssembleia = item.DT_Assembleia.ToString("dd/MM/yyyy"),
                        Modalidade = item.NM_Modalidade,
                        TipoOferta = item.Tipo_Oferta,
                        TipoReducao = item.Tipo_Reducao,
                        ValorLance = string.Concat("R$ ", item.VL_Lance.ToString("N2", culturaBrasileira)),
                        PercentualLance = string.Concat(item.PE_Lance.ToString("N4", culturaBrasileira), " %"),
                        ParcelaLance = item.PC_Lance.ToString("N0", culturaBrasileira),
                        ValorEmbutido = string.Concat("R$ ", item.VL_Lance_Embutido.ToString("N2", culturaBrasileira)),
                        PercentualEmbutido = string.Concat(item.PE_Lance_Embutido.ToString("N4", culturaBrasileira), " %"),
                        Url = string.Concat(_BRApi.Url, _BRApi.ApiPasta),
                        StatusCode = response.StatusCode.ToString(),
                    });

                }
            }
            else
            {
                
                listaOfertaLanceHistorico.Add(new OfertaLanceHistorico
                {
                    Url = string.Concat(_BRApi.Url, _BRApi.ApiPasta),
                    StatusCode = response.StatusCode.ToString(),
                });

            }


            return listaOfertaLanceHistorico;
        }
        

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
