using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class EnderecoPessoa
    {
        public int ID_Pessoa { get; set; }
        public int ID_Endereco { get; set; }
        public int ID_Cidade { get; set; }
        public int ID_Tipo_Endereco { get; set; }
        public string ID_UF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string NO_Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Caixa_Postal { get; set; }
        public string DS_Referencia_Endereco { get; set; }
    }
}
