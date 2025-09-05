using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class ValoresDevolverModel
    {
        public int IdCota { get; set; }
        public string Grupo { get; set; }
        public string Cota { get; set; }
        public string Versao { get; set; }

        public string DataPosicao { get; set; }

        public string ValorTotalDevolver { get; set; }
        public string ValorDevolvido { get; set; }
        public string DataDevolcao { get; set; }
        public string NomeBancoDevolucao { get; set; }
        public string ValorSaldoPendente { get; set; }

        public string  ErroMsg { get; set; }
       

    }
}
