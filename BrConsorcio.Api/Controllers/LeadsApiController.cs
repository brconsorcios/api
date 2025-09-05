
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/LeadsApi")]

    public class LeadsApiController : Controller
    {

        private readonly ICompApiService _ICompApiService;

        public LeadsApiController(ICompApiService iCompApiService)
        {
            _ICompApiService = iCompApiService;
         }
        // POST: api/LeadsApi
        [HttpPost]
        [Route("Salvar")]
        public async Task<string> Post([FromBody] LeadPartner leadPartner)
        {
            try
            {
                return await _ICompApiService.Salvar(leadPartner, leadPartner.produto);
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
