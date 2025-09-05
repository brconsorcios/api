using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class OfertaLanceHistorico
    {
        public long ID { get; set; }

        public string LanceStatus { get; set; }

        public string DataOferta { get; set; }

        public string DataAssembleia { get; set; }

        public string Modalidade { get; set; }

        public string TipoOferta { get; set; }

        public string TipoReducao { get; set; }

        public string ValorLance { get; set; }

        public string PercentualLance { get; set; }

        public string ParcelaLance { get; set; }

        public string ValorEmbutido { get; set; }

        public string PercentualEmbutido { get; set; }

        public string Url { get; set; }
        public string StatusCode { get; set; }
    }
}

