using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class IndicacaoPgtoDeposito
    {
        public int id { get; set; } // id pessoa
        public string tipo_conta { get; set; }
        public string nome_banco { get; set; }
        public string agencia { get; set; }
        public string numero_conta { get; set; }
        public int id_site { get; set; }
        public bool exibirconta { get; set; }
    }
}
