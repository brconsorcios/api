using System;
using System.Threading.Tasks;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrConsorcio.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/RDStation")]
    
    public class RDStationController : Controller
    {
        private readonly IRDStation _IRDStation;

        public RDStationController(IRDStation iRDStation)
        {
            _IRDStation = iRDStation;
        }
        
        [HttpPost]
        [Route("Event")]
        public async Task<string> Post([FromBody] Lead lead)
        {
            try
            {
                return await _IRDStation.Event(lead);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}