using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrConsorcio.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    
    public class SimuladorController : Controller
    {
        private readonly IBrConsorcio _brConsorcio;
        public SimuladorController(IBrConsorcio brConsorcio)
        {
            _brConsorcio = brConsorcio;
        }
        // GET: api/values
        [HttpGet]
        // [Route("Listar")]
        public async Task<IEnumerable<Plano>> Get(SimulacaoModel simulacao)
        {

            var bens = await _brConsorcio.Simulacao(simulacao);

            return bens;
        }

        // GET api/values/5
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
