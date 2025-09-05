using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Provider
    {

        public string WebAtendimento { get; set; }
        public string NWSRVCPAuthEndpoint { get; set; }
        public string CotaServiceAuthEndpoint { get; set; }
        public string Web_Credito { get; set; }
        public string Ws_ConsultaProvider { get; set; }
        public string Ws_BoletoAvulso { get;  set; }
    }
}
