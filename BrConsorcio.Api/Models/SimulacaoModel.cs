using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Models
{
    public class SimulacaoModel
    {
        private string _tipoConsorcio;


        [Required]
        [Display(Name = "Tipo Consorcio")]
        public string TipoConsorcio
        {
            get
            {
                switch (_tipoConsorcio)
                {
                    case "Consórcio Automóveis":
                        return "1";

                    case "Consórcio Motos":
                        return "2";
                    case "Consórcio Imóveis":
                        return "4";

                    case "Consórcio Serviços":
                        return "7";

                    case "Consórcio Maquinas e Equip.":
                        return "11";

                    default:
                        return "1";

                }
            }
            set { _tipoConsorcio = value; }
        }

        private string _tipoSimulacao;

        [Required]
        [Display(Name = "Tipo Simulação")]
        public string TipoSimulacao
        {
            get
            {

                switch (_tipoSimulacao)
                {
                    case "Pelo valor do crédito":
                        return "pelo-valor-do-credito";

                    case "Pelo valor da parcela":
                        return "pelo-valor-da-mensalidade";


                    default:
                        return "pelo-valor-do-credito";

                }

            }
            set { _tipoSimulacao = value; }
        }





        [Required]
        [Display(Name = "Valor minimo")]
        public string ValorMin { get; set; }

        [Required]
        [Display(Name = "Valor maximo")]
        public string ValorMax { get; set; }

    }
}