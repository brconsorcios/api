using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace BrConsorcio.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cartilha")]
    public class CartilhaController : Controller
    {
        private Exp_WebAPI _exp_webapi;
        private readonly BrConsorcioConfig brConsorcioConfig;

        public CartilhaController(IOptions<Exp_WebAPI> exp_webapi, IOptions<BrConsorcioConfig> brConsorcioConfig)
        {
            _exp_webapi = exp_webapi.Value;
            this.brConsorcioConfig = brConsorcioConfig.Value;
        }


        [HttpGet]
        [Route("BaixarCartilha")]
        public JsonResult Get(int? PorCodigo)
        {
            try
            {
                string link = string.Empty;

                switch (PorCodigo)
                {
                    case 1:
                        link = "https://example.com";
                        break;
                    case 6:
                        link = "https://example.com";
                        break;
                    case 4:
                        link = "https://example.com";
                        break;
                    case 5:
                        link = "https://example.com";
                        break;
                    case 7:
                        link = "https://example.com";
                        break;
                    case 2:
                        link = "https://example.com";
                        break;
                    default:
                        break;
                }

                return Json(new { link });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

    }
}