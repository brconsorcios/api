using System;

namespace BrConsorcio.Api.Models
{

    public class CotasCanceladasModel
    {
        public AssembleiaCotaResult[] Property1 { get; set; }
    }

    public class AssembleiaCotaResult
    {
        public string CD_Grupo { get; set; }
        public string CD_Cota { get; set; }
        public string Versao { get; set; }
        public string DT_Contemplacao { get; set; }
        public string ST_Contemplacao { get; set; }
    }

}
