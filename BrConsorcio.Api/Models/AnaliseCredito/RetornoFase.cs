using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class RetornoFase
    {
        public int Ocorrencia { get; set; }
        public int Fase { get; set; }
        public string TipoProduto { get; set; }
        public string ID_CONCR015 { get; set; }
        public string NM_OCORRENCIA { get; set; }
        public string PENDENCIA { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Mensagem { get; set; }

    }
}
