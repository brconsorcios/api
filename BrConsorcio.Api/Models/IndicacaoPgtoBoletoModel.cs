using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class IndicacaoPgtoBoletoModel : IndicacaoPgtoDeposito
    {
        public virtual int id { get; set; } // id da indicacao
   
        public bool? check_dadosbancarios { get; set; }
        public bool? check_termo { get; set; }


        public IndicacaoPgtoBoletoModel()
        {
            check_termo = false;
            check_dadosbancarios = false;

        }
    }
}
