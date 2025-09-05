using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Services
{
    public class RDStationApiService : IRDStation
    {
        private RDStationApi _rDStationApi;
        private HttpHelpers http;

        public RDStationApiService(IOptions<RDStationApi> rDStationApi)
        {
            _rDStationApi = rDStationApi.Value;
            http = new HttpHelpers(_rDStationApi.Url, "", "");
        }
        public async Task<Token> Token(RDScp rDScp)
        {
            try
            {
                return await http.Post<RDScp,Token>($"/auth/token", rDScp);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> Event(Lead lead)
        {
             try
            {
                lead.event_type = "CONVERSION";
                lead.event_family = "CDP";
                lead.payload.conversion_identifier = _rDStationApi.cf_ambiente_destino == "prod_" ? "site" : "site_hml";
                lead.payload.cf_tipo_contemplacao = "1";
                lead.payload.cf_origem_lead = "site";
                lead.payload.cf_ambiente_destino = _rDStationApi.cf_ambiente_destino;
                
                foreach (var rDScp in _rDStationApi.SCPS)
                {
                    if (rDScp.scp == lead.payload.cf_scp)
                    {
                        var token = await this.Token(rDScp);
                        if (token == null)
                            return null;

                        var auth = new AuthenticationHeaderValue("Bearer", token.access_token);


                        return await http.Post<Lead, string>($"/platform/events/", lead, auth);
                    } 
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
