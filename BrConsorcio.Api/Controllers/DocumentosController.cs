using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrConsorcio.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    
    public class DocumentosController : Controller
    {
        private readonly IBrConsorcio brConsorcio;
        private readonly BrConsorcioConfig brConsorcioConfig;

        public DocumentosController(IOptions<BrConsorcioConfig> brConsorcioConfig, IBrConsorcio brConsorcio)
        {
            this.brConsorcioConfig = brConsorcioConfig.Value;
            this.brConsorcio = brConsorcio;

        }



        // GET api/<controller>/5
        [HttpGet]
        [Route("ObterBoleto")]
        public async Task<string> ObterBoleto(int id)
        {
            var boleto = await brConsorcio.ObterBoleto(id);
            if (string.IsNullOrWhiteSpace(boleto))
                return "";
            else
                return $"{brConsorcioConfig.Url.TrimEnd('/')}/restrito/content/boletos/{boleto}";
        }
        [HttpGet]
        [Route("ObterContrato")]
        public async Task<string> ObterContrato(int id)
        {
            var contrato = await brConsorcio.ObterContrato(id);
            if (string.IsNullOrWhiteSpace(contrato))
                return "";
            else
                return $"{brConsorcioConfig.Url.TrimEnd('/')}/restrito/content/contratos/{contrato}";
        }

    }
}
