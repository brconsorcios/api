using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
    }


    public class RDStationApi
    {
        public string Url { get; set;}
        public string cf_ambiente_destino { get; set; }
        public ICollection<RDScp> SCPS  { get; set; }
    }
    public class RDScp
    {
        public string scp { get; set; }
        public string client_id { get; set; }

        public string client_secret { get; set; }
        public string refresh_token { get; set; }
    }
    public class Lead
    {
        public string event_type { get; set; }
        public string event_family { get; set; }
        public Payload payload { get; set; }
    }
    public class Payload
    {
        public string conversion_identifier { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string personal_phone { get; set; }
        public string cf_tipo { get; set; }
        public string cf_categoria { get; set; }
        public string cf_forma_de_contato { get; set; }
        public string cf_tipo_contemplacao { get; set; }
        public string cf_valor { get; set; }
        public string cf_categoria_produto { get; set; }
        public string cf_scp { get; set; }
        public string cf_ambiente_destino { get; set; }
        public string cf_dcontact { get; set; }
        public string cf_informacoes_novidades { get; set; }
        public string cf_origem_lead { get; set; }

    }
}
