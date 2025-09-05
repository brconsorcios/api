using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class BuscaCepModel
    {
        

        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string NM_Cidade { get; set; }
        public string DDD { get; set; }
        public string ID_UF { get; set; }
        public string ID_Cidade { get; set; }
        public string ErrMsg { get; set; }
    }
}
