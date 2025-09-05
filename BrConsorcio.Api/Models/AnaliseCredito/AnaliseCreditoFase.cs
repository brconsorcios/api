using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models.AnaliseCredito
{
    public class AnaliseCreditoFase
    {
        public string CD_OCORRENCIA { get; set; }
        public string ID_CONCR015 { get; set; }
        public DateTime? DT_CONCLUSAO { get; set; }
        public string PENDENCIA { get; set; }
        public string NM_OCORRENCIA { get; set; }
    }
}
