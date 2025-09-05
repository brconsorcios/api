using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BrConsorcio.Api.Services;
using Microsoft.AspNetCore.Authorization;
using BrConsorcio.Api.Helpers;
using Microsoft.Extensions.Options;
using System.Linq;
using System;
using System.Globalization;
using System.Net.Http;
using BrConsorcio.Api.Models;
using Newtonsoft.Json;
using BrConsorcio.Api.Services.Interfaces;
using BoletoAvulsoService;
using System.Dynamic;
using Serilog;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrConsorcio.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class BoletosController : Controller
    {
        //1. gera id identificação a partir do grupo e cota
        //2. busca as parcelas com o id identificação
        //3. Marca a parcela desejada para impressao usando o id cobranca e o id identificador.
        //4. Confirma a parcela selecionada.
        //5. Gera o boleto passando id identificador, grupo, cota.

        private readonly IBrConsorcio _brConsorcio;
        private readonly BrConsorcioConfig _brConsorcioConfig;
        private BRApi _BRApi;
        private IBoletoAvulso _IBoletoAvulso;

        public BoletosController(IBoletoAvulso iBoletoAvulso, IBrConsorcio brConsorcio, IOptions<BrConsorcioConfig> brConsorcioConfig, IOptions<BRApi> BRApi)
        {
            _brConsorcio = brConsorcio;
            _brConsorcioConfig = brConsorcioConfig.Value;
            _BRApi = BRApi.Value;
            _IBoletoAvulso = iBoletoAvulso;
        }

        [HttpGet]
        [Route("ConsultarParcelas")]
        public async Task<ExpandoObject> Get(string grupo, int cota, string cpfCnpj)
        {
            Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "ConsultarParcela".PadRight(30), $"Início do endpoint (grupo: {grupo} , cota: {cota}, cpfCnpj: {cpfCnpj} ");

            dynamic ret = new ExpandoObject();
            try
            {
                string grupo_provider;

                if (grupo.Where(c => char.IsLetter(c)).Count() > 0)
                    grupo_provider = grupo;
                else
                    grupo_provider = grupo.PadLeft(6, '0');
                var retorno =  await _IBoletoAvulso.ConsultarParcelas(grupo_provider, cota, cpfCnpj);
                var parcelas = retorno.Parcelas;
                _IBoletoAvulso.Close();
                foreach (var parcela in parcelas)
                {
                    if (parcela.numeroParcela != "DIF")
                    {

                        ret.iD_Identificador = parcela.identificadorBoleto;
                        break;
                    }
                }
                return ret;
            }
            catch (Exception e)
            {
                Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "ConsultarParcela".PadRight(30), $"Exception {e.StackTrace} ");

                //ret.errMsg = e.Message;
                ret.errMsg = "Grupo/Cota/Cpf ou Cnpj informados não encontrado!";
                ret.iD_Identificador = 0;

                return ret;
            }

        }
        

        [HttpGet]
        [Route("Gerar")]
        public async Task<IActionResult> Gerar(string idIdentificador, string grupo, string cota)
        {
            Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "Gerar".PadRight(30), $"Início do endpoint (Identificador:{idIdentificador} , grupo: {grupo} , cota: {cota} ");
            //4. Confirma a parcela selecionada.
            //5. Gera o boleto passando id identificador, grupo, cota.
            idIdentificador = idIdentificador.toEncod64();

            if (grupo.Where(c => char.IsLetter(c)).Count() > 0)
                grupo = grupo;
            else
                grupo = grupo.PadLeft(6, '0');

            var retorno = await _brConsorcio.EmitirBoletoSegundaVia(grupo, cota, idIdentificador);

            if (retorno.erros != null)
            {
                return BadRequest(retorno);
            }
            
            string[] pdf = retorno.Objeto.Split(';');

            string urlboleto = _brConsorcioConfig.Url + "/restrito/content/boletos2via/" + pdf[0];

            retorno.Objeto = urlboleto;

            return Ok(retorno);

            


        }
        [HttpGet]
        [Route("GerarBoletoComParcelas")]
        public async Task<IActionResult> GerarBoletoComParcelas(string idIdentificador, string grupo, string cota, string idCobrancas)
        {
            int[] idCobrancasArray = idCobrancas
            .Split(',')
            .Select(int.Parse)
            .ToArray();
            
            Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "Gerar".PadRight(30), $"Início do endpoint (Identificador:{idIdentificador} , grupo: {grupo} , cota: {cota} ");
            //4. Confirma a parcela selecionada.
            //5. Gera o boleto passando id identificador, grupo, cota.
            idIdentificador = idIdentificador.toEncod64();

            if (grupo.Where(c => char.IsLetter(c)).Count() > 0)
                grupo = grupo;
            else
                grupo = grupo.PadLeft(6, '0');

            var retorno = await _brConsorcio.EmitirBoletoSegundaVia(grupo, cota, idIdentificador);

            if (retorno.erros != null)
            {
                return BadRequest(retorno);
            }

            string[] pdf = retorno.Objeto.Split(';');

            string urlboleto = _brConsorcioConfig.Url + "/restrito/content/boletos2via/" + pdf[0];

            retorno.Objeto = urlboleto;

            return Ok(retorno);




        }

        [HttpGet]
        [Route("VerificarBoleto")]
        public async Task<HttpResposta<string>> VerificarBoleto(string idIdentificador, string grupo, string cota)
        {
            Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "VerificarBoleto".PadRight(30), $"Início do endpoint (Identificador:{idIdentificador} , grupo: {grupo} , cota: {cota} ");

            idIdentificador = idIdentificador.toEncod64();

            if (grupo.Where(c => char.IsLetter(c)).Count() > 0)
                grupo = grupo;
            else
                grupo = grupo.PadLeft(6, '0');

            var retorno = await _brConsorcio.EmitirBoletoSegundaVia(grupo, cota, idIdentificador);

            string[] pdf = retorno.Objeto.Split(';');

            string urlboleto = _brConsorcioConfig.Url + "/restrito/content/boletos2via/" + pdf[0] + pdf[4];

            retorno.Objeto = urlboleto;

            return retorno;
        }
        [HttpGet]
        [Route("PrecisaAtualizarBoleto")]
        public async Task<JsonResult> PrecisaAtualizarBoleto(string grupo, int cota, int versao, string dataVencimento)
        {
            Log.Information("{p} {e}-> {m}", "Boletocontroller".PadRight(30), "PrecisaAtualizarBoleto".PadRight(30), $"Início do endpoint (grupo: {grupo} , cota: {cota} , Versao: {versao} , dataVencimento: {dataVencimento}");

            HttpClient client;
            client = new HttpClient();

            client.BaseAddress = new Uri(_BRApi.Url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string atualizarBoleto = "N";
            string contemplada = string.Empty;
            int diasTolerancia = 0;
            int? diasAtraso = null;
            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("{0}api/GetCotaContemplada?grupo={1}&cota={2}&versao={3}", _BRApi.ApiPasta, grupo, cota, versao)).Result;
            if (response.IsSuccessStatusCode)
            {
                string retorno = response.Content.ReadAsStringAsync().Result;
                string json = JsonConvert.DeserializeObject<string>(retorno);
                dynamic Array = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach (var item in Array)
                {
                    contemplada = item.contemplado;
                    break;
                }
                diasTolerancia = contemplada == "N" ? 10 : 36;

                CultureInfo culturaBrasileira = new CultureInfo("pt-BR");

                try
                {
                    diasAtraso = (DateTime.Today.Subtract(DateTime.ParseExact(dataVencimento, "dd/MM/yyyy", culturaBrasileira))).Days;

                    if (diasAtraso >= diasTolerancia) atualizarBoleto = "S";

                }
                catch (Exception)
                {
                    atualizarBoleto = "S";
                    diasAtraso = null;
                }
            }
            return Json(new { atualizarBoleto, diasAtraso, diasTolerancia, contemplada });
        }

    }
}
