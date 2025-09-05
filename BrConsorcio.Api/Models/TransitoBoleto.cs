using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class TransitoBoleto
    {

        public string id_identificador { get; set; }
        public string id_cobranca { get; set; }
        public string versao { get; set; }
        public string cd_grupo { get; set; }
        public string cd_cota { get; set; }
    }
}
