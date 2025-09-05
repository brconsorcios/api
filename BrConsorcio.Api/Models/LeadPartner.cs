using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class LeadPartner
    {
        public string produto { get; set; }
        public string cnpjcpf { get; set; }
        public string portal { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telCelular { get; set; }
        public string telComercial { get; set; }
        public string telResidencial { get; set; }
        public string receberSMS { get; set; }
       
    }
}
